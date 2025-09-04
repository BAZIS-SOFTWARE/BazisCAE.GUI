using BaseModule.Mesh;
using BaseModule.Mesh.SettingsControls;
using BazisGUI.Scene;
using BazisGUI.Utilities;
using Geometry;
using GmshApi;
using Model.GeometryObjects;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Windows.Forms;
using static BaseModule.Interfaces.GeneralParams;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void показатьПлотностьСеткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                HideGeometryObj("DisplaySceneScale");

                var curvesInfo = GetCurvesNumbersAndNodes();
                var max = curvesInfo.Max(x => x.Value);
                var min = curvesInfo.Min(x => x.Value);

                resultsController.FillRange(min, max, 3,2);
  
                //var scale = new SceneScale();
                //scale.FontBase = FontBase;
                //scale.Coord_X = settingsConfig.Scale_X_Coord;
                //scale.Coord_Y = settingsConfig.Scale_Y_Coord;

                DisplaySceneScale("","");

                foreach (var item in curvesInfo)
                {
                    var color = resultsController.GetValueColor(item.Value);
                    project.ModelData.ObjectData.CurveSet[item.Key].Color = color;
                }

                var linePres = presentersCreator.CreateLineObjectsPresenter(project.ModelData.ObjectData.CurveSet.Values);
                VBOController.DeleteVBObjects(ObjType.Кривая.ToString());
                CreateVBObject(linePres);
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
        private void mesh3DGeneratorMenuItem_Click(object sender, EventArgs e)
        {
            if (mesh3DGeneratorMenuItem.Checked)
            {
                var res = MessageBox.Show("Вы собираетесь запустить сеточный генератор. При нажатии на кнопку \"OK\" " +
    "Все данные о задаче будут удалены!",
"Внимание!", MessageBoxButtons.OKCancel);

                if (res == DialogResult.OK)
                    project.TaskData.Clear();
                else
                {
                    mesh3DGeneratorMenuItem.Checked = false;
                    return;
                }

                var meshGenerator = new GMSHGeneralMeshControl();

                meshGenerator.setMeshAlgoEvent += (ar) =>
                {
                    gmshController.Gmsh.Option.SetNumber("Mesh.Algorithm", ar);
                };


                meshGenerator.delMeshGradientEvent += MeshGenerator_delMeshGradientEvent;
                meshGenerator.showShowSurfaceNumbersEvent += MeshGenerator_showSurfaceNumbers;
                meshGenerator.showNumberOfCurveNodesEvent += MeshGenerator_showNumberOfCurveNodes;
                
                meshGenerator.generate2DTriangleMeshEvent += MeshGenerator_generate2DMeshEvent;
                meshGenerator.deleteMeshEvent += MeshGenerator_deleteMeshEvent;
                meshGenerator.showNodesOnCurvesEvent += MeshGenerator_showNodesOnCurves;
      
                //meshGenerator.updateTreeViewEvent += () => { PresentProjectOnTree(); };
                meshGenerator.refineMesh += MeshGenerator_refineMesh;
       
                meshGenerator.generate2DQuadMesh += MeshGenerator_generate2DQuadMesh;

                meshGenerator.SetCurveAttributeEvent += MeshGenerator_SetCurveAttributeEvent;
                meshGenerator.GetCurveAttribEvent += MeshGenerator_GetCurveAttribEvent;
                meshGenerator.CurveAttribDeleteEvent += MeshGenerator_CurveAttribDeleteEvent;

                meshGenerator.deleteElementEvent += DeleteElementsByNumber;
                meshGenerator.setMeshGradientSettingsEvent += MeshGenerator_setMeshGradientSettingsEvent;

                meshGenerator.SetPointSizeEvent += SetPointSizesEventHandler;
                meshGenerator.PointAttribDeleteEvent += MeshGenerator_PointAttribDeleteEvent;
                meshGenerator.GetPointSizeEvent += MeshGenerator_GetPointSizeEvent;

                meshGenerator.setMinMaxSizesEvent += SetMinMaxSizesEvent;

                //SetGMSHController(project.ModelData);
            }
        }

        private void MeshGenerator_SetCurveAttributeEvent(object arg1, CurveAttribsEventArgs arg2)
        {
            gmshController.Gmsh.Model.SetAttribute($"transfinite {arg2.Tag}", arg2.Attributes);
            if (!string.IsNullOrEmpty(arg2.Attributes[0]) && !string.IsNullOrEmpty(arg2.Attributes[2]))
            {
                MeshType meshtType = (MeshType)Enum.Parse(typeof(MeshType), arg2.Attributes[1], true);
                gmshController.Gmsh.Model.Mesh.SetTransfiniteCurve(arg2.Tag, arg2.Points, meshtType, arg2.Coef);
            }
        }

        private void MeshGenerator_CurveAttribDeleteEvent(int obj)
        {
            var dimTags = new int[] { 1, obj };
            gmshController.Gmsh.Model.RemoveAttribute($"transfinite {obj}");
            gmshController.Gmsh.Model.Mesh.RemoveConstraints(dimTags);
        }

        private void MeshGenerator_GetCurveAttribEvent(object arg1, int arg2)
        {
            try
            {
                var attributes = gmshController.Gmsh.Model.GetAttribute($"transfinite {arg2}");
                var curveControl = arg1 as GMSHCurveSettingsControl;
                curveControl.SetCurveAttributes(attributes);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void MeshGenerator_PointAttribDeleteEvent(int obj)
        {
            var dimTags = new int[] { 0, obj };
            gmshController.Gmsh.Model.Mesh.RemoveConstraints(dimTags);
        }

        private void MeshGenerator_GetPointSizeEvent(object arg1, int arg2)
        {
            try
            {
                var dimTags = new int[] { 0, arg2 };
                var meshSize = gmshController.Gmsh.Model.Mesh.GetSizes(dimTags);
                var pointControl = arg1 as GMSHPointSettingsControl;
                pointControl.SetPointSize(meshSize[0]);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void MeshGenerator_setMeshGradientSettingsEvent(object arg1, MeshGradientSettingsEventArgs arg2)
        {
            gmshController.Gmsh.Model.Mesh.Field.Add(FieldType.Extend);

            var list = gmshController.Gmsh.Model.Mesh.Field.List();
            if (list.Length != 0)
            {
                var field = list.First();
                var points = gmshController.Gmsh.Model.GetEntities(0);
                var curves = gmshController.Gmsh.Model.GetEntities(1);
                var surfaces = gmshController.Gmsh.Model.GetEntities(2);
                var curveTags = curves.Where((v, i) => (i & 1) != 0)
                                      .Select(v => (double)v).ToArray();
                var surfTags = surfaces.Where((v, i) => (i & 1) != 0)
                                       .Select(v => (double)v).ToArray();
                gmshController.Gmsh.Model.Mesh.SetSize(points, arg2.surfaceMeshSize);
                gmshController.Gmsh.Model.Mesh.Field.SetNumbers(field, ExtendOptions.CurvesList.ToString(), curveTags);
                gmshController.Gmsh.Model.Mesh.Field.SetNumbers(field, ExtendOptions.SurfacesList.ToString(), surfTags);
                gmshController.Gmsh.Model.Mesh.Field.SetNumber(field, ExtendOptions.Power.ToString(), arg2.gradientMeshPower);
                gmshController.Gmsh.Model.Mesh.Field.SetNumber(field, ExtendOptions.DistMax.ToString(), arg2.layerThickness);
                gmshController.Gmsh.Model.Mesh.Field.SetNumber(field, ExtendOptions.SizeMax.ToString(), arg2.coreMeshSize);
                gmshController.Gmsh.Model.Mesh.Field.SetAsBackgroundMesh(field);
                gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeExtendFromBoundary", -2);
            }
        }

        private void SetPointSizesEventHandler(object sender, int pointNumber, double[] pointSize)
        {
            var dimTags = new int[] { 0, pointNumber };
            gmshController.Gmsh.Model.Mesh.SetSize(dimTags, pointSize[0]);
        }

        private void SetMinMaxSizesEvent(object sender, double[] sizes)
        {
            gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeMin", sizes[0]);
            gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeMax", sizes[1]);
        }

        private void MeshGenerator_delMeshGradientEvent(object arg1)
        {
            var list = gmshController.Gmsh.Model.Mesh.Field.List();
            gmshController.Gmsh.Model.Mesh.Field.Remove(list.First());
            var points = gmshController.Gmsh.Model.GetEntities(0);
            gmshController.Gmsh.Model.Mesh.RemoveConstraints(points);
            gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeExtendFromBoundary", 1);
        }

        private void DeleteElementsByNumber(object sender, DeleteElementEventArgs args)
        {
            var cntr = (GMSHGeneralMeshControl)sender;
            var intType = cntr.GetElementTypeByString(ref args.keyData[0]);

            var dimTags = args.isNumeric ? new int[] { args.dim, Int32.Parse(args.keyData[1]) }
                         : GetElementsByType(intType, args.dim, args.tag);


            DeleteElementsByNumbers(dimTags, args.keyData[0], cntr.ElementsType);
        }

        private int[] GetElementsByType(int intType, int dim, int tag)
        {
            var data = gmshController.Gmsh.Model.Mesh.GetElements(dim, tag);
            var elTypes = data.Item1;
            var elTags = data.Item2;
            var nodeTags = data.Item3;
            int[] dimTags = null;
            for (var i = 0; i < elTypes.Length; ++i)
                if (elTypes[i] == intType)
                {
                    var tags = elTags[i];
                    dimTags = new int[tags.Length * 2];
                    for (var j = 0; j < tags.Length; ++j)
                    {
                        dimTags[j * 2] = dim;
                        dimTags[j * 2 + 1] = Convert.ToInt32(tags[j]);
                    }
                    break;
                }
            return dimTags;
        }

        private void DeleteElementsByNumbers(int[] dimTags, string keyData, IEnumerable<string> elementType)
        {
            foreach (var element in elementType)
                if (element.Contains(keyData))
                {
                    var idElems = dimTags.Where((i, v) => (v & 1) == 1)
                                            .Select(v => (IntPtr)v)
                                            .ToArray();
                    gmshController.DeleteMeshElements(idElems);
                    return;
                }
            gmshController.Gmsh.Model.Mesh.Clear(dimTags);
        }


        private void MeshGenerator_showSurfaceNumbers(object sender, bool flag)
        {
            if (flag)
            {
                ShowSurfaceNumbers();
            }
            else
            {
                var cnt = sender as GMSHGeneralMeshControl;
                DisplayText3DEvent = null;

                if (cnt.IsNumberOfCurveNodesShowen)
                    ShowNumberOfCurveNodes();
            }

            DisplayObjects();
        }

        private void MeshGenerator_showNumberOfCurveNodes(object sender, bool obj)
        {
            // тут нужно перебрать все кривые которые есть в модели и показать их параметры разметки
            if (obj)
            {
                ShowNumberOfCurveNodes();
            }
            else
            {
                var cnt = sender as GMSHGeneralMeshControl;
                DisplayText3DEvent = null;

                if (cnt.IsSurfaceNumbersShowen)
                    ShowSurfaceNumbers();
            }


            DisplayObjects();
        }

        private void ShowSurfaceNumbers()
        {
            var dimTags = gmshController.Gmsh.Model.GetEntities(2);

            for (var i = 1; i < dimTags.Length; i += 2)
            {
                var point = GetCenterOfGeometryEntity(2, dimTags[i]);
                //var point = GetOffsetPointFromCenter(2, dimTags[i], 10);
                var text = $"Поверхность {dimTags[i]}";

                DisplaySurfaceNumbers(text, Color.Black, point.Sum(new Point3D(5, 5, 5)));
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
                var tag = Int32.Parse(item.Split(' ')[1]);
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

        private void MeshGenerator_generate2DQuadMesh(object obj)
        {
            var cntr = (GMSHGeneralMeshControl)obj;
            var filename = gmshController.Gmsh.Model.GetFileName();
            var ext = Path.GetExtension(filename);
            if (ext.Contains("igs") || ext.Contains("iges"))
            {
                gmshController.Gmsh.Model.Mesh.Recombine();
                var error = gmshController.Gmsh.Logger.GetLastError();
                if (!string.IsNullOrEmpty(error))
                    console.PrintInfo(error, Color.Red);
                cntr.ShowHideTabControls(3, false);
                cntr.ClearTreeView(3);
                var objs = gmshController.GetMeshObjects();

                project.ModelData.ObjectData.Clear(ObjType.Узел);
            }
        }

        private void MeshGenerator_refineMesh(object sender)
        {
            gmshController.Gmsh.Model.Mesh.Refine();

            project.ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем

            FitObjectsToScreen();
            DisplayObjects();
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void MeshGenerator_generate2DMeshEvent(object sender, double meshDencity)
        {
            try
            {
                var cntr = (GMSHGeneralMeshControl)sender;
                gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeFactor", meshDencity);

                DeleteGMSHMeshObjects(ObjType.Узел);
                gmshController.Gmsh.Model.Mesh.Generate(1);
                gmshController.Gmsh.Model.Mesh.Generate(2);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
                return;
            }
            var error = gmshController.Gmsh.Logger.GetLastError();
            if (!string.IsNullOrEmpty(error))
                console.PrintInfo(error, Color.Red);

            project.ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем

            FitObjectsToScreen();
            DisplayObjects();
        }

        private void MeshGenerator_deleteMeshEvent(Objects objects)
        {
            var objType = Converters.ConvertToObjsType(objects);

            if (objType == ObjType.Элемент2D)
            {
                DeleteGMSHMeshObjects(ObjType.Узел);
            }
            else if (objType == ObjType.Элемент3D)
            {
                DeleteGMSHMeshObjects(ObjType.Элемент3D);
            }

            project.ModelData.ObjectData.Clear(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем

            FitObjectsToScreen();
            DisplayObjects();
        }

        private void DeleteGMSHMeshObjects(ObjType type)
        {
            int[] dimTags = null;
            var dim = 0;
            if (type == ObjType.Узел) //удаляем всю сетку узлы,1d,2d,3d
            {
                dimTags = new int[0];
            }
            if (type == ObjType.Элемент1D)//удаляем все 1d элементы
            {
                dim = 1;
                dimTags = gmshController.Gmsh.Model.GetEntities(dim);
            }
            else if (type == ObjType.Элемент2D)//удаляем все 2d элементы
            {
                dim = 2;
                dimTags = gmshController.Gmsh.Model.GetEntities(dim);
            }
            else if (type == ObjType.Элемент3D)//удаляем все 3d элементы
            {
                dim = 3;
                gmshController.Gmsh.Model.GetEntities(dim);
            }
            gmshController.Gmsh.Model.Mesh.Clear(dimTags);
        }

        private void MeshGenerator_showNodesOnCurves(bool flag)
        {
            VBOController.DeleteVBObjects("transPoints");

            if (flag)
            {
                var dic = GetCurvesNumbersAndNodes();

                var points = new List<GeometryPoint>();
                foreach (var item in dic.Keys)
                {
                    points.AddRange(GetTransPointsCoords(item));
                }

                var presentor = presentersCreator.CreatePointObjectsPresenter(points);
                presentor.Name = "transPoints";
                CreateVBObject(presentor);
            }

            DisplayObjects();
        }

        private Dictionary<int, int> GetCurvesNumbersAndNodes()
        {
            var curveDict = new Dictionary<int, int>();
            //1)Добавляем в словарь сначала размеченные кривые
            var attribList = gmshController.Gmsh.Model.GetAttributeNames();
            foreach (var item in attribList)
            {
                var tag = Int32.Parse(item.Split(' ')[1]);
                var attributes = GetCurrentCurveAttributes(tag);
                var points = attributes.Length == 3 && !string.IsNullOrEmpty(attributes[0]) ? Int32.Parse(attributes[0]) : 0;
                curveDict.Add(tag, points);
            }
            //2)Добавляем в словарь неразмеченные кривые, которых нет в словаре (со значением ноль)
            var dimTags = gmshController.Gmsh.Model.GetEntities(1);
            for (var i = 1; i < dimTags.Length; i += 2)
                if (!curveDict.ContainsKey(dimTags[i]))
                    curveDict.Add(dimTags[i], 0);
            return curveDict;
        }

        private string[] GetCurrentCurveAttributes(int tag)
        {
            var attributes = gmshController.Gmsh.Model.GetAttribute($"transfinite {tag}");
            return attributes;
        }

        private List<GeometryPoint> GetTransPointsCoords(int curveTag)
        {
            gmshController.Gmsh.Model.Mesh.Generate(1);
            var data = gmshController.Gmsh.Model.Mesh.GetNodes(1, curveTag, false, false);
            var nodeTags = data.Item1;
            var coords = data.Item2;
            var parametric = data.Item3;

            var gPoints = new List<GeometryPoint>();
            var num = 0;
            for (int i = 0; i < coords.Length; i += 3)
            {
                var gPoint = new GeometryPoint(num++, new Point3D((float)coords[i], (float)coords[i + 1], (float)coords[i + 2]));
                gPoints.Add(gPoint);
            }
            return gPoints;
        }      
    }
}
