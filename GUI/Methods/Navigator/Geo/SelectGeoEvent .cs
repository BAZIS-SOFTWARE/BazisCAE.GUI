using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Scene.VBO;
using BazisGUI.Utilities;
using Geometry;
using GmshApi;
using Model.GeometryObjects;
using Model.Interfaces;
using OperationalController;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectGeoEvent()
        {
            try
            {
                if (gmshController.Gmsh == null)
                    return;
                List<RowProperty> rows = new List<RowProperty>();

                var actMinSize = gmshController.Gmsh.Option.GetNumber("Mesh.MeshSizeMin");
                var actMaxSize = gmshController.Gmsh.Option.GetNumber("Mesh.MeshSizeMax");
                var actAlgo2d = gmshController.Gmsh.Option.GetNumber("Mesh.Algorithm");
                var alg2D = actAlgo2d.ToString().ToEnum<MeshAlgorithm2D>();
                var actAlgo3d = gmshController.Gmsh.Option.GetNumber("Mesh.Algorithm3D");
                var alg3D = actAlgo2d.ToString().ToEnum<MeshAlgorithm3D>();
                var actSizeFactor = gmshController.Gmsh.Option.GetNumber("Mesh.MeshSizeFactor");

                var algs2D = Enum.GetValues(typeof(MeshAlgorithm2D)).
                    Cast<MeshAlgorithm2D>().Select(x => x.ToString());
                var algs3D = Enum.GetValues(typeof(MeshAlgorithm3D)).
                    Cast<MeshAlgorithm3D>().Select(x => x.ToString());

                rows.Add(new RowProperty("Мин.размер", actMinSize));
                rows.Add(new RowProperty("Макс.размер", actMaxSize));
                rows.Add(new RowProperty("Алгоритм 2D",new DropDownPropertyValue(alg2D, algs2D.ToList())));
                rows.Add(new RowProperty("Алгоритм 3D",new DropDownPropertyValue(alg3D, algs3D.ToList())));
                rows.Add(new RowProperty("Масштаб. коэфициент", actSizeFactor));
                rows.Add(new RowProperty("Показать узлы на кривых", settingsConfig.ShowNodesOnCurves));
                rows.Add(new RowProperty("Показать кол-во узлов на кривых", new ButtonPropertyValue("Показать",
                    () => 
                    { 
                        ShowNumberOfCurveNodes();
                        DisplayObjects();
                    })));
                rows.Add(new RowProperty("Показать номера поверхностей", new ButtonPropertyValue("Показать",
                    () => { 
                        ShowSurfaceNumbers();
                        DisplayObjects();
                    })));
                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void ShowNodesOnCurves(bool flag)
        {
            try
            {
                VBOController.DeleteVBObjects("transPoints");

                if(flag)
                {
                    // генерисуем 1д элементы для сбора информации об узлах
                    gmshController.Gmsh.Model.Mesh.Generate(1);
                    var dic = GetCurvesNumbersAndNodes();

                    var points = new List<GeometryPoint>();
                    foreach (var item in dic.Keys)
                    {
                        points.AddRange(GetTransPointsCoords(item));
                    }

                    var presentor = presentersCreator.CreatePointObjectsPresenter(points);
                    presentor.Name = "transPoints";
                    var vbo = CreateVBObject(presentor);
                    VBOController.AddVbo(vbo);
                }

                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private List<GeometryPoint> GetTransPointsCoords(int curveTag)
        {
            var data = gmshController.Gmsh.Model.Mesh.GetNodes(1, curveTag, false, false);
            var nodeTags = data.Item1;
            var coords = data.Item2;
            var parametric = data.Item3;

            var gPoints = new List<GeometryPoint>();
            var num = 0;
            for (int i = 0; i < coords.Length; i += 3)
            {
                var gPoint = new GeometryPoint(num++, new Point3D((float)coords[i], (float)coords[i + 1], (float)coords[i + 2]));
                gPoint.Color = settingsConfig.SelectObjectColor;
                gPoints.Add(gPoint);
            }
            return gPoints;
        }

        private Dictionary<int, int> GetCurvesNumbersAndNodes()
        {
            var curveDict = new Dictionary<int, int>();
            //1)Добавляем в словарь сначала размеченные кривые
            var attribList = gmshController.Gmsh.Model.GetAttributeNames().Where(x => x.Contains("curve"));
            foreach (var item in project.GetModelObjects(ObjType.Кривая))
            {
                //var tag = Int32.Parse(item.Split(' ')[2]);

                // тут будем учитывать видна кривая илиь нет
                if(item.ViewState)
                {
                    var attributes = GetCurrentCurveAttributes(item.Number);
                    var points = attributes.Length == 3 && !string.IsNullOrEmpty(attributes[0]) ? Int32.Parse(attributes[0]) : 0;
                    curveDict.Add(item.Number, points);
                }
            }
            //2)Добавляем в словарь неразмеченные кривые, которых нет в словаре (со значением ноль)
            
            // TODO Это место нужно переписать. Все можно хранить в классе SurfaceFigure
            var dimTags = gmshController.Gmsh.Model.GetEntities(1);
            for (var i = 1; i < dimTags.Length; i += 2)
                if (project.GetModelObject(ObjType.Кривая, dimTags[i]).ViewState)
                    if (!curveDict.ContainsKey(dimTags[i]))
                        curveDict.Add(dimTags[i], 0);
            return curveDict;
        }

        private string[] GetCurrentCurveAttributes(int tag)
        {
            var attributes = gmshController.Gmsh.Model.GetAttribute($"transfinite curve {tag}");
            return attributes;
        }

        private void ShowSurfaceNumbers()
        {
            foreach (var item in project.GetModelObjects(ObjType.Поверхность))
            {
                if(item.ViewState)
                {
                    var point = GetCenterOfGeometryEntity(2, item.Number);
                    //var point = GetOffsetPointFromCenter(2, dimTags[i], 10);
                    var text = $"Поверхность {item.Number}";

                    DisplaySurfaceNumbers(text, Color.Black, point);
                }
            }
        }

        public void DisplaySurfaceNumbers(string str, Color color, Point3D coord)
        {
            var met = new Action(() =>
            {
                //if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                //    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                DisplayText3DTemplate(str, color, coord);
                //if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                //    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);

            });

            DisplayText3DEvent += met;
        }

        private void ShowNumberOfCurveNodes()
        {
            var attribList = gmshController.Gmsh.Model.GetAttributeNames();

            foreach (var item in attribList)
            {
                var tag = Int32.Parse(item.Split(' ')[2]);
                if (project.GetModelObject(ObjType.Кривая, tag).ViewState)
                {
                    var attributes = GetCurrentCurveAttributes(tag);

                    if (attributes.Length == 3)
                    {
                        // var text = $"{attributes[2]} {attributes[1]} {attributes[0]}";
                        var text = $"{attributes[0]}";
                        var point = GetCenterOfGeometryEntity(1, tag);

                        DisplayText3D(text, Color.Black, point);
                    }
                }

            }
        }

        /// <summary>
        /// Вернуть центр масс текущей геометрической сущности
        /// </summary>
        /// <param name="dim">Геометрическая размерность</param>
        /// <param name="tag">Идентификатор геометрической сущности</param>
        /// <returns>Центр масс</returns>
        private Point3D GetCenterOfGeometryEntity(int dim, int tag)
        {
            var data = gmshController.Gmsh.Model.Occ.GetCenterOfMass(dim, tag);
            var point = new Point3D((float)data.Item1, (float)data.Item2, (float)data.Item3);
            return point;
        }
    }
}
