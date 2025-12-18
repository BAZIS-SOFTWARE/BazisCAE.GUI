using BazisGUI.Extensions;
using Geometry;
using Model.Interfaces;
using Model.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using BazisGUI.Scene.VBO;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void создатьГруппуItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedObjects == "Объекты" |
                    SelectedObjects == "Фигуры" |
                    SelectedObjects == "Элементы")
                {

                    console.PrintInfo($"Нельзя создать группу {SelectedObjects}", Color.Orange);
                }
                else
                {
                    //CreatedMeshGroupEvent?.Invoke(this, spbSelectObject.ToolTipText);
                    var objTypeStr = SelectedObjects;
                    var selObjs = GetModelObjects(SelectedObjects).
                        Where(x => x.Color == settingsConfig.SelectObjectColor);

                    if (selObjs.Count() > 0)
                    {
                        var objType = objTypeStr.ToEnum<ObjType>();
                        var name = $"newGroup{objType}";
                        project.ModelData.GroupData.Create(name, selObjs);

                        console.PrintInfo(string.Format("Создана новая группа {0}", name), Color.Black);

                        PresentGroupDataOnTree();
                        OnGroupCreated?.Invoke(objType, name);
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
                var objTypeStr = SelectedObjects;

                var selObjs = GetModelObjects(objTypeStr).
        Where(x => x.Color == settingsConfig.SelectObjectColor);
                //& x.ViewState == true);
                
                foreach (var selObj in selObjs)
                    selObj.ViewState = false;  


                var sets = selObjs.Select(x => project.GetModelSetInfo(x.ObjType,x.Number)).
        Distinct(new DefaultSetInfoComparer()).Where(x => x.NumberOfObjects > 0);

                foreach (var set in sets)
                {
                    VBOController.DeleteVBObjects(set.Name);
                    set.SetBackColor();
                    if (set.ViewState)
                    {
                        var pre = project.CreateModelObjectsPresentor(set);
                        VBObject vb;
                        if(TryCreateVBObject(pre, out vb))
                            VBOController.AddVbo(vb);

                        //var vbo = CreateVBObject(pre);
                        //VBOController.AddVbo(vbo);
                    }
                }

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
                foreach (var obj in project.GetAllModelObjects())
                    obj.ViewState = true;

                VBOController.DeleteAllVBObjects();
                CreateVBObjects("Объекты");
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
                var objs = GetModelObjects(SelectedObjects);
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
                // Пока нельзя удалить геометрию рамкой с экрана. Пока только через дерево.
                if (SelectedObjects == ObjType.Точка.ToString() |
                    SelectedObjects == ObjType.Кривая.ToString() |
                    SelectedObjects == ObjType.Поверхность.ToString())
                    return;

                    var selObjs = GetModelObjects(SelectedObjects).
Where(x => x.Color == settingsConfig.SelectObjectColor);

                foreach (var item in selObjs)
                    item.ExistState = false;

                if(SelectedObjects == ObjType.Узел.ToString())
                {
                    DeleteVBObjects("Элементы");
                    CreateVBObjects("Элементы");
                }
 
                var sets = selObjs.Select(x => project.GetModelSetInfo(x.ObjType, x.Number)).
Distinct(new DefaultSetInfoComparer()).Where(x => x.NumberOfObjects > 0);

                foreach (var set in sets)
                {
                    VBOController.DeleteVBObjects(set.Name);
                    if (set.ViewState)
                    {
                        var pre = project.CreateModelObjectsPresentor(set);
                        var vbo = CreateVBObject(pre);
                        VBOController.AddVbo(vbo);
                    }
                }

                DisplayObjects();

                project.ModelData.ObjectData.ClearNotExisted();
                project.ModelData.ObjectData.ClearEmptySet();
                project.ModelData.GroupData.ClearNotExisted();
                project.TaskData.ClearNotExisted(project.ModelData.GroupData);

                PresentMeshData();
                PresentGroupDataOnTree();
                PresentCondDataOnTree();

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
                // Управляем возвратом цвета через контроллер
                //project?.SetModelObjectsBackColor(type);
                if(project != null)
                    foreach (var set in project.GetModelSetsInfo(type))
                    {
                        set.SetBackColor();
                        var pres = project.CreateModelObjectsPresentor(set);
                        if (pres != null)
                            SetVBObjectAttribute(pres, "цвет");
                    }
            }
        }

        private void GlControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DisplayGeometryObjectEvent = null;
                // все таки может выключать весь текст по эскайп?
                DisplayText2DEvent = null;
                DisplayText3DEvent = null;

                SelectedObjects = "_";

                SetBackColorToAllObjects();
                DisplayObjects();
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
                    // добавление прямоугольника выбора по параллелограмму объекта
                    var scrPoints = glObj.BoundingBox.GetCornerPoints().
                        Select(c => GetSceenCoord(c._x, c._y, c._z)).
                        Select(s => GetScreenCoord(s));

                    var rect = new RectangleBox(scrPoints);

                    if (selectionBox.IsInnerOther(rect) |
                        selectionBox.IsIntersectWithOther(rect))
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
                        var distSelection = selection.Distinct();
                        var sortedSelection = distSelection.OrderByDescending(x => x._z);
                        if (sortedSelection.Count() > 0)
                        {
                            SetRotationCentre(sortedSelection.First());
                            break;
                        }
                    }
                }
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
            GL.LoadMatrix(tempViewMatrixAr);
        }

        private void GlControl_Resize(object sender, EventArgs e)
        {
            // установка порта вывода в соответствии с размерами элемента anT 
            GL.Viewport(0, 0, scene.Width, scene.Height);
            // настройка матрицы проекции 
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            //Glu.gluPerspective(camera.AngleOfProjection, (double)scene.Width / scene.Height, 1, 2000);//Учтется при UpdateProjection
            GL.MatrixMode(MatrixMode.Modelview);
            var matrix = ViewMatrix.AsColumnMajorArray();
            GL.LoadMatrix(matrix);

            UpdateProjection();
            averageColorRenderer.Reshape(scene.Width, scene.Height);
        }

        private void SelectObjects(Point2D point, bool isSelected)
        {
            try
            {
                if (project != null)
                {
                    var sets = GetModelSetsInfo(SelectedObjects);
                    //var sets = project.GetModelSetsInfo(spbSelectObject.ToolTipText);
                    if (SelectByPoint(sets, point, isSelected))
                    {
                        foreach (var set in sets)
                        {
                            var pres = project.CreateModelObjectsPresentor(set);
                            SetVBObjectAttribute(pres, "цвет");
                        }
                        DisplayObjects();
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void SelectObjects(RectangleBox rectangleBox, bool isSelected)
        {
            try
            {
                if(project != null)
                {
                    var sets = GetModelSetsInfo(SelectedObjects);
                    SelectByRect(sets, rectangleBox, isSelected);   
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }      
    }
}
