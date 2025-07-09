using BaseModule.Extensions;
using BazisGUI.Scene.EventsArgs;
using BazisGUI.Utilities;
using Geometry;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tao.OpenGl;
using static BaseModule.Interfaces.GeneralParams;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void создатьГруппуItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (spbSelectObject.ToolTipText == "Объекты" |
spbSelectObject.ToolTipText == "Фигуры" |
spbSelectObject.ToolTipText == "Элементы")
                {

                    console.PrintInfo($"Нельзя создать группу {spbSelectObject.ToolTipText}", Color.Orange);
                }
                else
                {
                    //CreatedMeshGroupEvent?.Invoke(this, spbSelectObject.ToolTipText);
                    var objTypeStr = spbSelectObject.ToolTipText;
                    var selObjs = ObjectsProvider.SelectorProvider(project.ModelData.ObjectData, objTypeStr).
                        Where(x => x.Color == settingsConfig.SelectObjectColor);

                    if (selObjs.Count() > 0)
                    {
                        var objType = objTypeStr.ToEnum<ObjType>();
                        var grps = project.ModelData.GroupData.FindMany(objType);

                        var counter = 1;
                        var name = $"{objTypeStr}_{grps.Count() + counter}";

                        while (true)
                        {
                            if (project.ModelData.GroupData.Find(name) != null)
                            {
                                counter++;
                                name = $"{objTypeStr}_{grps.Count() + counter}";
                            }
                            else break;
                        }

                        var group = project.ModelData.GroupData.Create(name, objType);

                        group.AddRange(selObjs);
                        project.ModelData.GroupData.Add(group);

                        console.PrintInfo(string.Format("Создана новая группа {0}", group.Name), Color.Black);

                        var text = $"{group.Name} {selObjs.Count()}";
                        var node = navigator.CreateRealNode(objType.ToString(), text);

                        navigator.TrySearchNodes("группыОбъектов", out List<TreeNode> nodes);
                        nodes.First().Nodes.Add(node);
                        navigator.SetContextMenu(node);
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void скрытьВыбранноеItem_Click(object sender, EventArgs e)
        {
            try
            {
                var objTypeStr = spbSelectObject.ToolTipText;
                var selObjs = ObjectsProvider.SelectorProvider(project.ModelData.ObjectData, objTypeStr).
        Where(x => x.Color == settingsConfig.SelectObjectColor);

                foreach (var selObj in selObjs)
                    selObj.ViewState = false;

                DeleteVBObjects(objTypeStr);
                CreateVBObjects(project.ModelData, objTypeStr);
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void показатьСкрытыеItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var obj in project.ModelData.ObjectData.GetAllObjects())
                    obj.ViewState = true;

                VBOController.DeleteAllVBObjects();
                CreateVBObjects(project.ModelData, "Объекты");
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void menuItem_InfoSelectedObjects_Click(object sender, EventArgs e)
        {
            try
            {
                var objs = ObjectsProvider.SelectorProvider(project.ModelData.ObjectData, SelectedObjects);
                var selObjs = objs.Where(x => x.Color == settingsConfig.SelectObjectColor);

                var message = $"Выбраны {SelectedObjects} {selObjs.Count()}";

                var numbers = string.Join("\n", selObjs.Select(x => x.ToString()).ToArray());

                message += "\n" + numbers;

                console.PrintInfo(message, Color.Black);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void menuItem_SetRotPoint_Click(object sender, EventArgs e)
        {
            var left = ScreenMousePosition.X;
            var rigth = ScreenMousePosition.X + 10;
            var top = ScreenMousePosition.Y;
            var bottom = ScreenMousePosition.Y - 10;

            var selectionBox = new RectangleBox(left, rigth, bottom, top);

            var selection = new List<Point3D>();



            foreach (var glObj in VBOController.GetVBObjs())
            {
                var coords = glObj.PointsCoords;

                var length = coords.Length / 3;

                for (int i = 0; i < length; i++)
                {
                    var x = coords[3 * i + 0];
                    var y = coords[3 * i + 1];
                    var z = coords[3 * i + 2];

                    var scnCoord = GetSceenCoord(x, y, z);
                    var scrCoord = GetScreenCoord(scnCoord);

                    if (selectionBox.IsPointInside(scrCoord))
                        selection.Add(scnCoord);
                }
            }

            selection = selection.OrderByDescending(x => x._z).ToList();
            if (selection.Count > 0)
                SetRotationCentre(selection.First());

            DisplayObjects();
        }

        private void menuItem_DeleteSelectedObjects_Click(object sender, EventArgs e)
        {
            try
            {
                var selObjs = ObjectsProvider.SelectorProvider(project.ModelData.ObjectData, spbSelectObject.ToolTipText).
Where(x => x.Color == settingsConfig.SelectObjectColor);

                foreach (var item in selObjs)
                    item.ExistState = false;

                project.ModelData.ObjectData.ClearNotExisted();
                project.ModelData.ObjectData.ClearEmptySet();
                project.ModelData.GroupData.ClearNotExisted();
                project.TaskData.ClearNotExisted(project.ModelData.GroupData);

                PresentObjectsDataOnTree(project.ModelData.ObjectData);
                PresentGroupDataOnTree(project.ModelData.GroupData);

                //if (arg1 is TaskPage taskPage)
                PresentCondDataOnTree(project.GeneralData, project.TaskData);

                ObjType objType;
                if (spbSelectObject.ToolTipText.TryToEnum(out objType))
                {
                    if (objType == ObjType.Узел)
                    {
                        DeleteVBObjects(objType);
                        CreateVBObjects(project.ModelData, spbSelectObject.ToolTipText);
                        CreateVBObjects(project.ModelData, "Элементы");
                    }
                    else if (objType == ObjType.Точка)
                    {
                        DeleteVBObjects(objType);
                        CreateVBObjects(project.ModelData, spbSelectObject.ToolTipText);
                        CreateVBObjects(project.ModelData, ObjType.Кривая.ToString());
                    }
                }
                else
                {
                    DeleteVBObjects(spbSelectObject.ToolTipText);
                    CreateVBObjects(project.ModelData, spbSelectObject.ToolTipText);
                }
                    
                
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void scene_SceneInfoEvent(object arg1, string arg2, Color arg3)
        {
            console.PrintInfo(arg2, arg3);
        }

        internal void SetBackColorToAllObjects()
        {
            foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
            {
                project.ModelData.ObjectData.SetBackColor(type);
                var pres = project.CreateModelObjectsPresentor(type,settingsConfig.IsInsideObjectsShown);
                SetVBObjectAttribute(pres, "цвет");
            }

            DisplayObjects();
        }

        private void GlControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DisplayGeometryObjectEvent = null;
                SetBackColorToAllObjects();
            }
            else if (e.KeyCode == Keys.C)
            {
                var left = ScreenMousePosition.X;
                var rigth = ScreenMousePosition.X + 10;
                var top = ScreenMousePosition.Y;
                var bottom = ScreenMousePosition.Y - 10;

                var selectionBox = new RectangleBox(left, rigth, bottom, top);

                var selection = new List<Point3D>();

                foreach (var glObj in VBOController.GetVBObjs())
                {
                    var coords = glObj.PointsCoords;

                    var length = coords.Length / 3;

                    for (int i = 0; i < length; i++)
                    {
                        var x = coords[3 * i + 0];
                        var y = coords[3 * i + 1];
                        var z = coords[3 * i + 2];

                        var scnPoint = GetSceenCoord(x, y, z);
                        var scrPoint = GetScreenCoord(scnPoint);

                        if (selectionBox.IsPointInside(scrPoint))
                            selection.Add(new Point3D(x, y, z));
                    }
                }
                var distSelection = selection.Distinct();
                var sortedSelection = distSelection.OrderByDescending(x => x._z);
                if (sortedSelection.Count() > 0)
                    SetRotationCentre(sortedSelection.First());

                DisplayObjects();

            }
            else if (e.KeyCode == Keys.F)
            {
                FitObjectsToScreen();
                DisplayObjects();
            }
        }

        /// <inheritdoc/>
        //TO DO добавить тест
        public void SetRotationCentre(Point3D modelPoint)
        {
            var viewMatrix = ViewMatrix;

            Position = modelPoint; // Может быть не хранить мировые кординаты выбранной точки как позицию камеры

            viewMatrix[0, 3] = 0; viewMatrix[1, 3] = 0;
            var tempViewMatrixAr = viewMatrix.AsColumnMajorArray();
            Gl.glLoadMatrixf(tempViewMatrixAr);
        }

        private void GlControl_Resize(object sender, EventArgs e)
        {
            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, scene.Width, scene.Height);
            // настройка матрицы проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            //Glu.gluPerspective(camera.AngleOfProjection, (double)scene.Width / scene.Height, 1, 2000);//Учтется при UpdateProjection
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            var matrix = ViewMatrix.AsColumnMajorArray();
            Gl.glLoadMatrixf(matrix);

            UpdateProjection();
            averageColorRenderer.Reshape(scene.Width, scene.Height);
            DisplayObjects();

            scene.Invalidate();
        }     

        private void SelectObjects(RectangleBox rectangleBox, bool isSorted, bool isSelected)
        {
            try
            {
                if(project != null)
                {
                    var objects = ObjectsProvider.SelectorProvider(project.ModelData.ObjectData, spbSelectObject.ToolTipText);
                    var selections = SearchObjects(objects, rectangleBox, isSorted);

                    if (selections.Count > 0)
                    {
                        foreach (var obj in selections)
                        {
                            var set = project.ModelData.ObjectData.GetSetInfo(obj.ObjType, obj.Number);
                            if (isSelected)
                                obj.Color = settingsConfig.SelectObjectColor;//  page.ScenePage.settingsConfig.SelectObjectColor;
                            else
                                obj.Color = set.Color;
                        }

                        ColorObjects(project.ModelData, spbSelectObject.ToolTipText);
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        internal void ColorObjects(IModelData modelData, string objTypeStr)
        {
            if (objTypeStr == "Объекты")
            {
                foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
                    SetVBObjectAttribute(project.CreateModelObjectsPresentor(type, settingsConfig.IsInsideObjectsShown), "цвет");
            }
            else if (objTypeStr == "Элементы")
            {
                SetVBObjectAttribute(project.CreateModelObjectsPresentor(ObjType.Элемент1D, settingsConfig.IsInsideObjectsShown), "цвет");
                SetVBObjectAttribute(project.CreateModelObjectsPresentor(ObjType.Элемент2D, settingsConfig.IsInsideObjectsShown), "цвет");
                SetVBObjectAttribute(project.CreateModelObjectsPresentor(ObjType.Элемент3D, settingsConfig.IsInsideObjectsShown), "цвет");
            }
            else if (objTypeStr == "Фигуры")
            {
                SetVBObjectAttribute(project.CreateModelObjectsPresentor(ObjType.Поверхность, settingsConfig.IsInsideObjectsShown), "цвет");
                SetVBObjectAttribute(project.CreateModelObjectsPresentor(ObjType.Объем, settingsConfig.IsInsideObjectsShown), "цвет");
            }
            else
            {
                var objType = Converters.ConvertToObjsType(objTypeStr);
                var presentor = project.CreateModelObjectsPresentor(objType, settingsConfig.IsInsideObjectsShown);
                SetVBObjectAttribute(presentor, "цвет");
            }


            DisplayObjects();
        }

        public List<IModelObject> SearchObjects(IEnumerable<IModelObject> objects, RectangleBox selectionBox, bool isSorted)
        {
            var selections = new List<IModelObject>();

            foreach (var item in objects)
            {
                if (item.ViewState)
                {
                    var scrPoints = new Point2D[item.NumberOfPoints];
                    var scnPoints = new Point3D[item.NumberOfPoints];

                    var pointCounter = 0;
                    foreach (var point in item.GetCoordinates())
                    {
                        var scnPoint = GetSceenCoord(point);
                        scnPoints[pointCounter] = scnPoint;

                        var scrPoint = GetScreenCoord(scnPoint);
                        scrPoints[pointCounter] = scrPoint;

                        pointCounter++;
                    }

                    if (selectionBox.IsPointsInside(scrPoints))
                        selections.Add(item);
                }
            }

            if (isSorted & selections.Count > 0)
            {
                var near = selections.OrderByDescending(x => GetSceenCoord(x.CalcCentr())._z).FirstOrDefault();
                selections = new List<IModelObject>() { near };
            }

            return selections;
        }
    }
}
