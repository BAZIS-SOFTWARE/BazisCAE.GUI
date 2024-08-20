using BaseModule;
using BaseModule.Console;
using BaseModule.CrossSection;
using Geometry;
using ModelControllerInterfaces;
using ModelInterfaces;
using ModelInterfaces.GeometryObjects;
using ModelInterfaces.MeshObjects;
using ProjectInterfaces;
using Scene;
using SceneInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule
{
    public partial class ToolStripPage : UserControl
    {
        public ToolStripPage()
        {
            InitializeComponent();
            selectToolStrip.Location = new Point(0, 0);
        }

        public BasePage BasePage 
        { 
            get
            {
                return basePage;
            }
        }

        public void PresentModelOnSelectToolStrip(IObjectsData objectsData)
        {
            foreach (var item in objectsData.ObjsTypes)
                AddObjectsType(item);

            AddObjectsType(ObjType.Объект);
            AddObjectsType(ObjType.Фигура);
            AddObjectsType(ObjType.Элемент);

            BasePage.ScenePage.SelectedObjects = ObjType.Объект;

            spbSelectObject.ToolTipText = ObjType.Объект.ToString();
        }

        public void AddObjectsType(ObjType objsType)
        {
            if (!spbSelectObject.DropDownItems.ContainsKey(objsType.ToString()))
            {
                var newItem = new ToolStripMenuItem(objsType.ToString()) { Name = objsType.ToString() };
                spbSelectObject.DropDownItems.Add(newItem);
            }

        }

        private void spb_Select_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            spbSelectObject.ToolTipText = e.ClickedItem.Text;

            ObjType objType;
            Enum.TryParse(spbSelectObject.ToolTipText, out objType);

            var scenePage = BasePage.ScenePage;
            scenePage.SelectedObjects = objType;

            scenePage.SetBackColorToAllObjects();
            scenePage.SceneControl.DisplayObjects();
        }

        private void ViewToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var btn = (ToolStripButton)e.ClickedItem;
            var scenePage = BasePage.ScenePage;
            var consoleControl = BasePage.ConsoleControl;

            if (e.ClickedItem.Tag.ToString() == "0")
            {
                scenePage.SceneControl.PlaneObjs(ViewPlane.XY);
            }
            else if (e.ClickedItem.Tag.ToString() == "1")
            {
                scenePage.SceneControl.PlaneObjs(ViewPlane.XZ);
            }
            else if (e.ClickedItem.Tag.ToString() == "2")
            {
                scenePage.SceneControl.PlaneObjs(ViewPlane.YZ);
            }
            else if (e.ClickedItem.Tag.ToString() == "3")
            {
                if (!btn.Checked)
                    scenePage.SceneControl.RotationAxis = ViewAxis.X;
                else
                    scenePage.SceneControl.RotationAxis = ViewAxis.XYZ;

            }
            else if (e.ClickedItem.Tag.ToString() == "4")
            {
                if (!btn.Checked)
                    scenePage.SceneControl.RotationAxis = ViewAxis.Y;
                else
                    scenePage.SceneControl.RotationAxis = ViewAxis.XYZ;

            }
            else if (e.ClickedItem.Tag.ToString() == "5")
            {
                if (!btn.Checked)
                    scenePage.SceneControl.RotationAxis = ViewAxis.Z;
                else
                    scenePage.SceneControl.RotationAxis = ViewAxis.XYZ;

            }
            else if (e.ClickedItem.Tag.ToString() == "6")
            {
                scenePage.SceneControl.RotationAxis = ViewAxis.Y;
                scenePage.SceneControl.RotationAngle = 90;
                scenePage.SceneControl.RotateObjs();
                scenePage.SceneControl.RotationAxis = ViewAxis.XYZ;
                scenePage.SceneControl.RotationAngle = 2.5f;
            }
            else if (e.ClickedItem.Tag.ToString() == "7")
            {
                scenePage.SceneControl.RotationAxis = ViewAxis.X;
                scenePage.SceneControl.RotationAngle = 90;
                scenePage.SceneControl.RotateObjs();
                scenePage.SceneControl.RotationAxis = ViewAxis.XYZ;
                scenePage.SceneControl.RotationAngle = 2.5f;
            }
            else if (e.ClickedItem.Tag.ToString() == "8")
            {
                scenePage.SceneControl.FitObjectsToScreen();
            }
            scenePage.SceneControl.DisplayObjects();
        }

        private void DisplayToolStrip_ItemClick(object arg1, ToolStripItemClickedEventArgs arg2)
        {
            var scenePage = BasePage.ScenePage;
            var consoleControl = BasePage.ConsoleControl;
            try
            {

                if (arg2.ClickedItem.Tag.ToString() == "0")
                {
                    scenePage.SceneControl.DrawInsideObjects = true;
                    var vbobj = scenePage.SceneControl.FindVBObj("Элемент3D");
                    if (vbobj != null)
                    {
                        var viewMode = vbobj.ViewMode;

                        scenePage.SceneControl.DeleteVBObjects("Элемент3D");

                        foreach (var item in scenePage.ModelData.ObjectData.E3DCollection)
                            if (item.ViewState)
                                item.ViewState = true;

                        var presentor = scenePage.CreateObjectsPresentor(ObjType.Элемент3D);
                        scenePage.CreateObjectsOnScene("Элемент3D", presentor);
                        scenePage.SceneControl.ChangeViewModeVBObjects("Элемент3D", viewMode);
                    }

                    consoleControl.PrintInfo("Показаны все объекты", Color.Black);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "1")
                {
                    scenePage.SceneControl.DrawInsideObjects = false;

                    var vbobj = scenePage.SceneControl.FindVBObj("Элемент3D");
                    if (vbobj != null)
                    {
                        var viewMode = vbobj.ViewMode;
                        scenePage.SceneControl.DeleteVBObjects("Элемент3D");

                        var presentor = scenePage.CreateObjectsPresentor(ObjType.Элемент3D);
                        scenePage.CreateObjectsOnScene("Элемент3D", presentor);
                        scenePage.SceneControl.ChangeViewModeVBObjects("Элемент3D", viewMode);
                    }

                    consoleControl.PrintInfo("Скрыты внутренние объекты", Color.Black);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "2")
                {
                    scenePage.PresentersCreator.SetView(ObjType.Фигура2D.ToString(), PresenterView.LineSurface);
                    scenePage.PresentersCreator.SetView(ObjType.Фигура3D.ToString(), PresenterView.LineSurface);
                    scenePage.PresentersCreator.SetView(ObjType.Элемент2D.ToString(), PresenterView.LineSurface);
                    scenePage.PresentersCreator.SetView(ObjType.Элемент3D.ToString(), PresenterView.LineSurface);

                    foreach (var obj in scenePage.SceneControl.GetVBObjs())
                        scenePage.SceneControl.ChangeViewModeVBObjects(obj.ObjName, ObjView.LinesSurface);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "3")
                {
                    scenePage.PresentersCreator.SetView(ObjType.Фигура2D.ToString(), PresenterView.Line);
                    scenePage.PresentersCreator.SetView(ObjType.Фигура3D.ToString(), PresenterView.Line);
                    scenePage.PresentersCreator.SetView(ObjType.Элемент2D.ToString(), PresenterView.Line);
                    scenePage.PresentersCreator.SetView(ObjType.Элемент3D.ToString(), PresenterView.Line);
                    foreach (var obj in scenePage.SceneControl.GetVBObjs())
                        scenePage.SceneControl.ChangeViewModeVBObjects(obj.ObjName, ObjView.Lines);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "4")
                {
                    scenePage.PresentersCreator.SetView(ObjType.Фигура2D.ToString(), PresenterView.Surface);
                    scenePage.PresentersCreator.SetView(ObjType.Фигура3D.ToString(), PresenterView.Surface);
                    scenePage.PresentersCreator.SetView(ObjType.Элемент2D.ToString(), PresenterView.Surface);
                    scenePage.PresentersCreator.SetView(ObjType.Элемент3D.ToString(), PresenterView.Surface);
                    foreach (var obj in scenePage.SceneControl.GetVBObjs())
                        scenePage.SceneControl.ChangeViewModeVBObjects(obj.ObjName, ObjView.Surface);
                }
                else if (arg2.ClickedItem.Tag.ToString() == "5")
                {
                    var btn = (ToolStripButton)arg2.ClickedItem;
                    if (!btn.Checked)
                        scenePage.SceneControl.DisplayBasis = true;
                    else scenePage.SceneControl.DisplayBasis = false;
                }
                else if (arg2.ClickedItem.Tag.ToString() == "6")
                {
                    var btn = (ToolStripButton)arg2.ClickedItem;
                    if (!btn.Checked)
                    {
                        var surfElems = scenePage.ModelData.ObjectData.GetAllElements().Where(x => x is ISurfaceElement);
                        if (surfElems.Count() > 0)
                        {
                            var elemsNormals = scenePage.ModelController.NormalCalculator.CalcElemsNormals(surfElems.Select(x => x as ISurfaceElement));

                            var linePresenter = scenePage.PresentersCreator.CreateLineObjectsPresenter(elemsNormals);

                            scenePage.CreateObjectsOnScene("Normals", linePresenter);
                        }
                        else
                            throw new Exception("Для отображения нормалей модели не заданы объекты типа \"Элемент\"," +
                                "возможно вы пользуетесь модулем Геометрии");
                    }
                    else scenePage.SceneControl.DeleteVBObjects("Normals");
                }
                else if (arg2.ClickedItem.Tag.ToString() == "7")
                {
                    var btn = (ToolStripButton)arg2.ClickedItem;
                    if (!btn.Checked)
                    {
                        var surfElems = scenePage.ModelData.ObjectData.GetAllElements().Select(x => (ISurfaceElement)x);
                        var linesNodes = scenePage.ModelController.BoundaryEdgesFinder.Find(surfElems);
                        var edges = scenePage.ModelController.BoundaryEdgesFinder.CreateBoundaryEdges(linesNodes, scenePage.ModelData);
                        var linePresenter = scenePage.PresentersCreator.CreateLineObjectsPresenter(edges);

                        scenePage.CreateObjectsOnScene("Boundary", linePresenter);
                    }
                    else scenePage.SceneControl.DeleteVBObjects("Boundary");
                }
                scenePage.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void InstrumentalToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var scenePage = BasePage.ScenePage;
            var consoleControl = BasePage.ConsoleControl;
            try
            {
                var btn = (ToolStripButton)e.ClickedItem;
                if (!btn.Checked)
                {
                    if (e.ClickedItem.Tag.ToString() == "0")
                    {
                        var form = new Form()
                        {
                            Name = "measureForm",
                            Text = "Измерить",
                            ShowIcon = false,
                            Owner = Application.OpenForms[0],
                            TopMost = true
                        };

                        form.FormClosed += (s1, s2) =>
                        {
                            btn.Checked = false;
                            scenePage.SceneControl.HideAllGeometryObjs();
                            scenePage.SceneControl.HideDisplayText3D();
                            scenePage.SceneControl.DisplayObjects();
                        };

                        var measuringControl = new MeasuringSet() { Dock = DockStyle.Fill };
                        measuringControl.PreparingMeasureEvent += (ar) =>
                        {
                            scenePage.SelectedObjects = ar;
                            scenePage.SceneControl.HideAllGeometryObjs();
                            scenePage.SceneControl.HideDisplayText3D();
                            scenePage.SceneControl.DisplayObjects();
                        };
                        measuringControl.MakeMeasureEvent += MeasuringControl_MakeMeasureEvent;
                        form.ClientSize = measuringControl.Size;
                        form.Controls.Add(measuringControl);

                        form.Show();
                    }

                    else if (e.ClickedItem.Tag.ToString() == "1")
                    {
                        var form = new Form()
                        {
                            Name = "CrossSectionForm",
                            Text = "Построить сечение",
                            ShowIcon = false,
                            Size = new Size(268, 203),
                            Owner = Application.OpenForms[0],
                            TopMost = true
                        };

                        var crossSection = new CrossSectionControl() { Dock = DockStyle.Fill };
                        form.ClientSize = crossSection.Size;
                        form.Controls.Add(crossSection);

                        crossSection.RemoveCrossEvent += () =>
                        {
                            scenePage.SceneControl.DeleteVBObjects("crossSection");
                            scenePage.SceneControl.DisplayObjects();
                        };

                        crossSection.SelectNodesEvent += () => { scenePage.SelectedObjects = ObjType.Узел; };

                        crossSection.CreateCrossFromTextArgs += (ar1, ar2) =>
                        {
                            try
                            {
                                var elems3D = scenePage.ModelData.ObjectData.E3DCollection;
                                var surface = CreateSectionSurfaces(elems3D, ar2.point1, ar2.point2, ar2.point3);

                                scenePage.PresentCrossSection(surface);

                            }
                            catch (Exception ex)
                            {
                                consoleControl.PrintInfo(ex.Message, Color.Red);
                            }
                        };
                        crossSection.CreateCrossFromNodesEvent += () =>
                        {
                            try
                            {
                                var objs = scenePage.ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);
                                var selObjs = objs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor).ToArray();
                                if (selObjs.Length < 3)
                                {
                                    consoleControl.PrintInfo("Ошибка, выбрано неверное количество узлов", Color.Red);
                                    return;
                                }

                                var p0 = selObjs[0];
                                var p1 = selObjs[1];
                                var p2 = selObjs[2];

                                var elems3D = scenePage.ModelData.ObjectData.E3DCollection;

                                var surface = CreateSectionSurfaces(
                                    elems3D, p0.CalcCentr(),
                                    p1.CalcCentr(),
                                    p2.CalcCentr());

                                scenePage.PresentCrossSection(surface);

                            }
                            catch (Exception ex)
                            {
                                consoleControl.PrintInfo(ex.Message, Color.Red);
                            }
                        };

                        form.FormClosed += (ar1, ar2) =>
                        {
                            btn.Checked = false;

                            scenePage.SceneControl.DeleteVBObjects("crossSection");

                            if (scenePage.SceneControl.GetVBObjs().Count() == 0)
                            {
                                scenePage.SceneControl.DeleteAllVBObjects();
                                foreach (var objsType in scenePage.ModelData.ObjectData.ObjsTypes)
                                {
                                    var presentor = scenePage.CreateObjectsPresentor(objsType);
                                    scenePage.CreateObjectsOnScene(objsType.ToString(), presentor);
                                }

                            }
                            scenePage.SceneControl.DisplayObjects();
                        };

                        form.Show();
                    }

                    else if (e.ClickedItem.Tag.ToString() == "2")
                    {
                        var generalData = BasePage.GeneralData;
                        BasePage.CreateScreenShot(generalData.Path + "\\screenShot.bmp");
                        consoleControl.PrintInfo($"Сделан снимок экрана {generalData.Path}\\screenShot.bmp", Color.Black);
                    }
                }
                else
                {
                    if (e.ClickedItem.Tag.ToString() == "0")
                    {
                        var forms = Application.OpenForms.Cast<Form>().ToList();
                        var form = forms.Find(x => x.Name == "measureForm");
                        if (form != null)
                        {
                            form.Close();
                            btn.Checked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public ISurfaceFigure CreateSectionSurfaces(IEnumerable<IElement3D> elems3D, Point3D p0, Point3D p1, Point3D p2)
        {
            var plane = new Plane(p0, p1, p2);
            var scenePage = BasePage.ScenePage;
            return scenePage.ModelController.CrossSectionMaker.GetSectionSurfaces(elems3D, plane);
        }

        private async void MeasuringControl_MakeMeasureEvent(object arg1, MeasureEventArgs arg2)
        {
            var scenePage = BasePage.ScenePage;
            var consoleControl = BasePage.ConsoleControl;
            try
            {
                switch (arg2.Kind)
                {
                    case MeasureKind.DistancePointToPoint:
                        {
                            var objs = scenePage.ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);
                            var selObjs = objs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor).ToList();

                            if (selObjs.Count() > 1)
                            {
                                var nodes = selObjs.Select(x => (IPoint)x);
                                var p0 = nodes.First();
                                var p1 = nodes.Last();
                                var line = new Segment3D(p0.Position, p1.Position);

                                consoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);

                                scenePage.SceneControl.DisplayDistance(line);
                                scenePage.SceneControl.DisplayObjects();
                            }
                            else consoleControl.PrintInfo($"{scenePage.SelectedObjects} не выбраны", Color.Red);
                            break;
                        }
                    case MeasureKind.DistancePointToPlane:
                        {
                            var plane = BasePage.CreateSurfaceAsync(scenePage.SelectedObjects);
                            await plane;

                            var objects = scenePage.ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);
                            foreach (var _object in objects)
                                _object.SetBackColor();

                            scenePage.SetObjectsSceneColor(scenePage.SelectedObjects);

                            scenePage.SceneControl.DisplayObjects();

                            var res = BasePage.SelectObjectAsync(scenePage.SelectedObjects);
                            await res;

                            if (res.Result is IPoint point)
                            {
                                var proj = point.Position.GetPointProectionOnPlane(plane.Result);
                                var line = new Segment3D(point.Position, proj);
                                consoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);
                                scenePage.SceneControl.DisplayDistance(line);
                                scenePage.SceneControl.DisplayObjects();
                            }

                            break;
                        }
                    case MeasureKind.Path:
                        await BasePage.CreatePathAsync();
                        break;
                    case MeasureKind.Square:
                        {
                            var square = 0.0;

                            var objs = scenePage.ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);

                            var selObjs = objs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor);

                            foreach (var obj in selObjs)
                            {
                                var sObj = (ISquare)obj;
                                square += sObj.CalcSquare();
                            }
                            consoleControl.PrintInfo($"Площадь : {square}", Color.Black);
                            break;
                        }

                    case MeasureKind.Volume:
                        {
                            var vol = 0.0f;

                            var objs = scenePage.ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);
                            var selObjs = objs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor);

                            foreach (var obj in selObjs)
                            {
                                var e3DObj = (IElement3D)obj;
                                vol += e3DObj.CalcVolume();
                            }
                            consoleControl.PrintInfo(string.Format("Объем : {0}", vol), Color.Black);
                            break;
                        }

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void SelectToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var selectStrip = (ToolStrip)sender;
            var scenePage = BasePage.ScenePage;
            var consoleControl = BasePage.ConsoleControl;

            if (e.ClickedItem.Tag.ToString() == "1")
                scenePage.SelectedObjects = ObjType.Узел;
            else if (e.ClickedItem.Tag.ToString() == "2")
                scenePage.SelectedObjects = ObjType.Элемент;
            else if (e.ClickedItem.Tag.ToString() == "3")
                scenePage.SelectedObjects = ObjType.Объект;
            else if (e.ClickedItem.Tag.ToString() == "4")
            {
                var btn = e.ClickedItem as ToolStripButton;
                if (!btn.Checked)
                {
                    var form = new Form()
                    {
                        Name = "selectForm",
                        Text = "Выбрать",
                        AutoSize = false,
                        ShowIcon = false,
                        TopMost = true,
                        Owner = Application.OpenForms[0]
                    };

                    form.FormClosing += (s1, s2) => { btn.Checked = false; };
                    var selectionControl = new SelectionSet() { Dock = DockStyle.Fill };
                    selectionControl.SelectInDirection += SelectionControl_SelectInDirection;
                    selectionControl.SelectInPlain += SelectionControl_SelectInPlain;
                    selectionControl.SelectNodes += (s1, s2) =>
                    {
                        //selectStrip.SelectObjectsType = ObjType.Узел;
                        var size = form.Size;
                        consoleControl.PrintInfo("Выберите два узла для направления или три для плоскости", Color.Black);
                    };
                    selectionControl.SelectElements += (s1, s2) =>
                    {
                        //selectStrip.SelectObjectsType = ObjType.Элемент2D;
                        consoleControl.PrintInfo("Выберите плоский элемент \"2D\"", Color.Black);
                    };
                    form.ClientSize = selectionControl.Size;
                    form.Controls.Add(selectionControl);
                    form.Show();

                }
                else
                {
                    var forms = Application.OpenForms.Cast<Form>().ToList();
                    var form = forms.Find(x => x.Name == "selectForm");
                    if (form != null)
                    {
                        form.Close();
                        btn.Checked = true;
                    }
                }
            }

        }

        private void SelectionControl_SelectInPlain(object arg1, SelectInPlainEventArgs arg2)
        {
            var scenePage = BasePage.ScenePage;
            var consoleControl = BasePage.ConsoleControl;
            try
            {
                //var selectHelper = new SelectionHelper(scenePage.ModelData.ObjectData);

                var objs = scenePage.ModelData.ObjectData.GetObjects(arg2.ObjsType).Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor).ToList();

                if (arg2.ObjsType == ObjType.Узел)
                {
                    if (objs.Count > 2)
                    {
                        var n1 = (INode)objs[0];
                        var n2 = (INode)objs[1];
                        var n3 = (INode)objs[2];

                        var plane = new Plane(n1.Position, n2.Position, n3.Position);
                        scenePage.ModelController.SelectionHelper.SelectNodeInPlane(scenePage.ModelData.ObjectData,
                            plane, scenePage.SceneControl.SelectionColor);
                        scenePage.SetObjectsSceneColor(ObjType.Узел);
                    }
                }
                else
                {
                    if (objs.Count > 0)
                    {
                        var element = objs.Last();
                        scenePage.ModelController.SelectionHelper.SelectE2DInPlane(scenePage.ModelData.ObjectData,
                            arg2.Angle, element.Number, scenePage.SceneControl.SelectionColor);
                        scenePage.SetObjectsSceneColor(ObjType.Элемент2D);
                    }
                }

                scenePage.SceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void SelectionControl_SelectInDirection(object arg1, SelectInDirectionEventArgs arg2)
        {
            var scenePage = BasePage.ScenePage;
            var consoleControl = BasePage.ConsoleControl;
            try
            {
                //var selectHelper = new SelectionHelper(scenePage.ModelData.ObjectData);

                var objs = scenePage.ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);
                var selObjs = objs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor).ToArray();
                if (selObjs.Length > 1)
                {
                    if (!arg2.Reverse)
                    {
                        scenePage.ModelController.SelectionHelper.SelectNodeInDirection(scenePage.ModelData.ObjectData,
                            arg2.Angle, selObjs[selObjs.Length - 2].Number, selObjs[selObjs.Length - 1].Number, scenePage.SceneControl.SelectionColor);
                    }

                    else
                    {
                        scenePage.ModelController.SelectionHelper.SelectNodeInDirection(scenePage.ModelData.ObjectData,
                            arg2.Angle, selObjs[selObjs.Length - 1].Number, selObjs[selObjs.Length - 2].Number, scenePage.SceneControl.SelectionColor);
                    }

                    //selObjs = objs.Where(x => x.MasterColor == sceneControl.SelectionColor).ToArray();
                    scenePage.SetObjectsSceneColor(scenePage.SelectedObjects);

                    scenePage.SceneControl.DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        

        
    }
}
