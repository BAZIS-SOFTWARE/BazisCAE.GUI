using BaseModule;
using BaseModule.Clip;
using BaseModule.CrossSection;
using BaseModule.Reflect;
using BazisGUI.Utilities;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.GeometryObjects;
using Model.Interfaces.MeshObjects;
using Model.MeshObjects;
using ModelControllerInterfaces;
using Project.Interfaces;
using Scene.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using UserControlsEx;

namespace BazisGUI
{
    public partial class ToolStripPage : UserControl
    {
        public event Action ChangedGroupNameEvent;
        public event Action CreatedMeshGroupEvent;
        public event Action DeleteAllGroupsEvent;
        public event Action DeleteGroupEvent;
        public event Action DeleteObjectsEvent;
        public event Action DeleteSelectedObjectsEvent;

        public ControlCollection EmbeddedControls
        {
            get
            {
                return embendentPage1.EmbeddedControls;
            }
        }

        public SplitContainerEx EmbeddedSplitContainer
        {
            get
            {
                return embendentPage1.EmbeddedSplitContainer;
            }
        }

        IModelController ModelController 
        { 
            get { return BasePage.ScenePage.GetModelController(); } 
        }

        IGeneralData GeneralData
        {
            get { return BasePage.GetGeneralData(); }
        }

        IModelData ModelData
        {
            get { return ModelController.ModelData; }
        }
        public ToolStripPage()
        {
            InitializeComponent();
            //selectToolStrip.Location = new Point(3, 0);
            BasePage.SplitterWidthEx = 8;
            //instrumentalToolStrip.Location = new Point(selectToolStrip.Size.Width + 4, 0);
        }

        public BasePage BasePage 
        { 
            get
            {
                return embendentPage1.BasePage;
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

                        foreach (var item in ModelData.ObjectData.E3DCollection)
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
                    ModelController.PresentersCreator.SetView(ObjType.Фигура2D.ToString(), PresenterView.LineSurface);
                    ModelController.PresentersCreator.SetView(ObjType.Фигура3D.ToString(), PresenterView.LineSurface);
                    ModelController.PresentersCreator.SetView(ObjType.Элемент2D.ToString(), PresenterView.LineSurface);
                    ModelController.PresentersCreator.SetView(ObjType.Элемент3D.ToString(), PresenterView.LineSurface);

                    foreach (var obj in scenePage.SceneControl.GetVBObjs())
                        scenePage.SceneControl.ChangeViewModeVBObjects(obj.ObjName, ObjView.LinesSurface);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "3")
                {
                    ModelController.PresentersCreator.SetView(ObjType.Фигура2D.ToString(), PresenterView.Line);
                    ModelController.PresentersCreator.SetView(ObjType.Фигура3D.ToString(), PresenterView.Line);
                    ModelController.PresentersCreator.SetView(ObjType.Элемент2D.ToString(), PresenterView.Line);
                    ModelController.PresentersCreator.SetView(ObjType.Элемент3D.ToString(), PresenterView.Line);
                    foreach (var obj in scenePage.SceneControl.GetVBObjs())
                        scenePage.SceneControl.ChangeViewModeVBObjects(obj.ObjName, ObjView.Lines);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "4")
                {
                    ModelController.PresentersCreator.SetView(ObjType.Фигура2D.ToString(), PresenterView.Surface);
                    ModelController.PresentersCreator.SetView(ObjType.Фигура3D.ToString(), PresenterView.Surface);
                    ModelController.PresentersCreator.SetView(ObjType.Элемент2D.ToString(), PresenterView.Surface);
                    ModelController.PresentersCreator.SetView(ObjType.Элемент3D.ToString(), PresenterView.Surface);
                    foreach (var obj in scenePage.SceneControl.GetVBObjs())
                        scenePage.SceneControl.ChangeViewModeVBObjects(obj.ObjName, ObjView.Surface);
                }

                scenePage.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }       

        public ISurfaceFigure CreateSectionSurfaces(IEnumerable<IElement3D> elems3D, Vector3 p0, Vector3 p1, Vector3 p2)
        {
            var mP0 = new Point3D(p0.X, p0.Y, p0.Z);
            var mP1 = new Point3D(p1.X, p1.Y, p1.Z);
            var mP2 = new Point3D(p2.X, p2.Y, p2.Z);
            var plane = new Geometry.Plane(mP0, mP1, mP2);
            var scenePage = BasePage.ScenePage;
            return ModelController.CrossSectionMaker.GetSectionSurfaces(elems3D, plane);
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
                            var objs = ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);
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

                            var objects = ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);
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

                            var objs = ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);

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

                            var objs = ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);
                            var selObjs = objs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor);

                            foreach (var obj in selObjs)
                            {
                                var e3DObj = (IElement3D)obj;
                                vol += (float)e3DObj.CalcVolume();
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

        private void SelectionControl_SelectInPlain(object arg1, SelectInPlainEventArgs arg2)
        {
            var scenePage = BasePage.ScenePage;
            var consoleControl = BasePage.ConsoleControl;
            try
            {
                var objTypes = ObjectsConverter.ConvertToObjsType(arg2.Objects);
                if (objTypes == scenePage.SelectedObjects)
                {
                    var selObjs = ModelData.ObjectData.GetObjects(objTypes).
                        Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor).ToArray();

                    if (scenePage.SelectedObjects == ObjType.Узел)
                    {

                        if (selObjs?.Count() > 2)
                        {
                            var n1 = (Node)selObjs.First();
                            var n2 = (Node)selObjs.Skip(1).First();
                            var n3 = (Node)selObjs.Skip(2).First();

                            var plane = new Geometry.Plane(n1.Position, n2.Position, n3.Position);
                            ModelController.SelectionHelper.SelectNodeInPlane(ModelData.ObjectData,
                                plane, scenePage.SceneControl.SelectionColor);
                            scenePage.SetObjectsSceneColor(ObjType.Узел);
                        }
                        else consoleControl.PrintInfo("Не выбрано три узла", Color.Red);

                    }
                    else
                    {
                        if (selObjs?.Count() > 0)
                        {
                            var element = selObjs.Last();
                            ModelController.SelectionHelper.SelectE2DInPlane(ModelData.ObjectData,
                                arg2.Angle, element.Number, scenePage.SceneControl.SelectionColor);
                            scenePage.SetObjectsSceneColor(ObjType.Элемент2D);
                        }
                        else consoleControl.PrintInfo("Выберите хотя бы один элемент", Color.Red);
                    }

                    scenePage.SceneControl.DisplayObjects();
                }
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
                var objTypes = ObjectsConverter.ConvertToObjsType(arg2.Objects);
                if (objTypes == scenePage.SelectedObjects)
                {
                    //var result = await BasePage.SelectObjectsAsync(scenePage.SelectedObjects);
                    //var objs = result as IEnumerable<IModelObject>;
                    
                    var selObjs = ModelData.ObjectData.GetObjects(objTypes).
                        Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor).ToArray();
                    if (selObjs?.Count() > 1)
                    {
                        if (!arg2.Reverse)
                        {
                            ModelController.SelectionHelper.SelectNodeInDirection(ModelData.ObjectData,
                                arg2.Angle, selObjs.Skip(1).First().Number, selObjs.First().Number, scenePage.SceneControl.SelectionColor);
                        }

                        else
                        {
                            ModelController.SelectionHelper.SelectNodeInDirection(ModelData.ObjectData,
                                arg2.Angle, selObjs.First().Number, selObjs.Skip(1).First().Number, scenePage.SceneControl.SelectionColor);
                        }

                        //selObjs = objs.Where(x => x.MasterColor == sceneControl.SelectionColor).ToArray();
                        scenePage.SetObjectsSceneColor(scenePage.SelectedObjects);

                        scenePage.SceneControl.DisplayObjects();
                    }
                    else
                        consoleControl.PrintInfo("Выбранных объектов должно быть больше двух", Color.Red);
                }
                    
            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void btnSelectObjects_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;
            var scenePage = BasePage.ScenePage;

            if (btn.Tag.ToString() == "1")
                scenePage.SelectedObjects = ObjType.Узел;
            else if (btn.Tag.ToString() == "2")
                scenePage.SelectedObjects = ObjType.Элемент;
            else
                scenePage.SelectedObjects = ObjType.Фигура;

            spbSelectObject.ToolTipText = scenePage.SelectedObjects.ToString();
            spbSelectObject.Invalidate();
            scenePage.SetBackColorToAllObjects();
            scenePage.SceneControl.DisplayObjects();
        }

        private void btnAdvanceSelection_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;
            if (btn.Checked)
            {
                var form = new Form()
                {
                    Name = "selectForm",
                    Text = "Дополненный выбор",
                    AutoSize = false,
                    ShowIcon = false,
                    TopMost = true,
                    Owner = Application.OpenForms[0]
                };

                form.FormClosing += (s1, s2) => { btn.Checked = false; };
                var selectionControl = new AdvanceSelectionSet() { Dock = DockStyle.Fill };
                selectionControl.SelectInDirection += SelectionControl_SelectInDirection;
                selectionControl.SelectInPlain += SelectionControl_SelectInPlain;
                selectionControl.SelectNodes += (s1, s2) =>
                {
                    BasePage.ScenePage.SelectedObjects = ObjType.Узел;
                    spbSelectObject.ToolTipText = ObjType.Узел.ToString();
                    spbSelectObject.Invalidate();
                };

                selectionControl.SelectElements += (s1, s2) =>
                {
                    BasePage.ScenePage.SelectedObjects = ObjType.Элемент2D;
                    spbSelectObject.ToolTipText = ObjType.Элемент2D.ToString();
                    spbSelectObject.Invalidate();
                };

                form.ClientSize = selectionControl.Size;
                form.Controls.Add(selectionControl);
                form.Show();
                var location = BasePage.ScenePage.PointToScreen(Point.Empty);
                form.Location = location;
            }
            else
            {
                var forms = Application.OpenForms.Cast<Form>().ToList();
                var form = forms.Find(x => x.Name == "selectForm");
                if (form != null)
                {
                    form.Close();
                    btn.Checked = false;
                }
            }
        }

        private void btnSetRotAxis_Click(object sender, EventArgs e)
        {
            var btn = (ToolStripButton)sender;

            var scenePage = BasePage.ScenePage;
            if (btn.Checked)
            {
                if (btn.Tag.ToString() == "3")
                {
                    scenePage.SceneControl.RotationAxis = ViewAxis.X;
                    btnSetRotY.Checked = false;
                    btnSetRotZ.Checked = false;
                }

                else if (btn.Tag.ToString() == "4")
                {
                    scenePage.SceneControl.RotationAxis = ViewAxis.Y;
                    btnSetRotX.Checked = false;
                    btnSetRotZ.Checked = false;
                }

                else
                {
                    scenePage.SceneControl.RotationAxis = ViewAxis.Z;
                    btnSetRotX.Checked = false;
                    btnSetRotY.Checked = false;
                }

            }
            else
                scenePage.SceneControl.RotationAxis = ViewAxis.XYZ;
        }

        private void btnCrossSection_Click(object sender, EventArgs e)
        {
            var scenePage = BasePage.ScenePage;
            var consoleControl = BasePage.ConsoleControl;
            try
            {
                var btn = (ToolStripButton)sender;
                if (btn.Checked)
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
                            var elems3D = ModelData.ObjectData.E3DCollection;
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
                            var objs = ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);
                            var selObjs = objs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor).ToArray();
                            if (selObjs.Length < 3)
                            {
                                consoleControl.PrintInfo("Ошибка, выбрано неверное количество узлов", Color.Red);
                                return;
                            }

                            var mP0 = selObjs[0].CalcCentr();
                            var mP1 = selObjs[1].CalcCentr();
                            var mP2 = selObjs[2].CalcCentr();

                            var p0 = new Vector3(mP0._x, mP0._y, mP0._z);
                            var p1 = new Vector3(mP1._x, mP1._y, mP1._z);
                            var p2 = new Vector3(mP2._x, mP2._y, mP2._z);

                            var elems3D = ModelData.ObjectData.E3DCollection;

                            var surface = CreateSectionSurfaces(
                                elems3D, p0,
                                p1,
                                p2);

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
                            foreach (var objsType in ModelData.ObjectData.ObjsTypes)
                            {
                                var presentor = scenePage.CreateObjectsPresentor(objsType);
                                scenePage.CreateObjectsOnScene(objsType.ToString(), presentor);
                            }

                        }
                        scenePage.SceneControl.DisplayObjects();
                    };

                    form.Show();
                    var location = BasePage.ScenePage.PointToScreen(Point.Empty);
                    form.Location = location;
                }
            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void btnMeasuring_Click(object sender, EventArgs e)
        {
            try
            {
                var scenePage = BasePage.ScenePage;
                var btn = (ToolStripButton)sender;
                if (btn.Checked)
                {

                    var form = new Form()
                    {
                        Name = "measureForm",
                        Text = "Панель измерений",
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
                        var objTypes = ObjectsConverter.ConvertToObjsType(ar);
                        scenePage.SelectedObjects = objTypes;
                        scenePage.SceneControl.HideAllGeometryObjs();
                        scenePage.SceneControl.HideDisplayText3D();
                        scenePage.SceneControl.DisplayObjects();
                    };
                    measuringControl.MakeMeasureEvent += MeasuringControl_MakeMeasureEvent;
                    form.ClientSize = measuringControl.Size;
                    form.Controls.Add(measuringControl);

                    form.Show();
                    var location = BasePage.ScenePage.PointToScreen(Point.Empty);
                    form.Location = location;
                }
                else
                {
                    var forms = Application.OpenForms.Cast<Form>().ToList();
                    var form = forms.Find(x => x.Name == "measureForm");
                    if (form != null)
                    {
                        form.Close();
                        btn.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void btnScreenShot_Click(object sender, EventArgs e)
        {
            var generalData = GeneralData;
            BasePage.CreateScreenShot(generalData.Path + "\\screenShot.bmp");
            BasePage.ConsoleControl.PrintInfo($"Сделан снимок экрана {generalData.Path}\\screenShot.bmp", Color.Black);
        }

        private void btnShowCountours_Click(object sender, EventArgs e)
        {
            try
            {
                var scenePage = BasePage.ScenePage;

                var btn = (ToolStripButton)sender;
                if (btn.Checked)
                {
                    var surfElems = ModelData.ObjectData.GetAllElements().Where(x => x is ISurfaceElement).
                        Select(x => (ISurfaceElement)x);
                    var linesNodes = ModelController.BoundaryEdgesFinder.Find(surfElems);
                    var edges = ModelController.BoundaryEdgesFinder.CreateBoundaryEdges(linesNodes, ModelData);
                    var linePresenter = ModelController.PresentersCreator.CreateLineObjectsPresenter(edges);

                    scenePage.CreateObjectsOnScene("Boundary", linePresenter);
                }
                else scenePage.SceneControl.DeleteVBObjects("Boundary");

                scenePage.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void btnShowNormals_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = (ToolStripButton)sender;
                var scenePage = BasePage.ScenePage;
                if (btn.Checked)
                {
                    var surfElems = ModelData.ObjectData.GetAllElements().Where(x => x is ISurfaceElement);
                    if (surfElems.Count() > 0)
                    {
                        var elemsNormals = ModelController.NormalCalculator.CalcElemsNormals(surfElems.Select(x => x as ISurfaceElement));

                        var linePresenter = ModelController.PresentersCreator.CreateLineObjectsPresenter(elemsNormals);

                        scenePage.CreateObjectsOnScene("Normals", linePresenter);
                    }
                    else
                        throw new Exception("Для отображения нормалей модели не заданы объекты типа \"Элемент\"," +
                            "возможно вы пользуетесь модулем Геометрии");
                }
                else scenePage.SceneControl.DeleteVBObjects("Normals");

                scenePage.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }

            
        }

        private void btnShowBasis_Click(object sender, EventArgs e)
        {
            var btn = (ToolStripButton)sender;
            var scenePage = BasePage.ScenePage;

            if (btn.Checked)
                scenePage.SceneControl.DisplayBasis = true;
            else scenePage.SceneControl.DisplayBasis = false;

            scenePage.SceneControl.DisplayObjects();
        }

        private void BasePage_ChangedGroupNameEvent()
        {
            ChangedGroupNameEvent?.Invoke();
        }

        private void BasePage_CreatedMeshGroupEvent()
        {
            CreatedMeshGroupEvent?.Invoke();
        }

        private void BasePage_DeleteAllGroupsEvent()
        {
            DeleteAllGroupsEvent?.Invoke();
        }

        private void BasePage_DeleteGroupEvent()
        {
            DeleteGroupEvent?.Invoke();
        }

        private void BasePage_DeleteObjectsEvent()
        {
            DeleteObjectsEvent?.Invoke();
        }

        private void BasePage_DeleteSelectedObjectsEvent()
        {
            DeleteSelectedObjectsEvent?.Invoke();
        }

        private void btnClipPlane_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ToolStripButton;
                var sceneControl = BasePage.ScenePage.SceneControl;
                if (btn.Checked)
                {
                    var clip = new ClipControl() { Dock = DockStyle.Fill };
                    var clipForm = new Form()
                    {
                        Name = "clipPlaneForm",
                        TopMost = true,
                        ShowIcon = false,
                        ClientSize = clip.Size,
                        MaximizeBox = false,
                        Text = "Сечение",
                        Owner = Application.OpenForms[0]
                    };

                    sceneControl.IsClipPlane = true;
                    clipForm.Controls.Add(clip);

                    clip.SetClipPlaneEvent += (plane) =>
                    {
                        var normal = plane.Normal;
                        var scPlane = new Geometry.Plane(new Point3D(normal.X, normal.Y, normal.Z), plane.D);
                        sceneControl.ChangeClipPlane(scPlane);
                    };

                    clip.RedrawClipPlane += () => sceneControl.DisplayObjects();
                    clipForm.FormClosing += (o, ev) =>
                    {
                        sceneControl.IsClipPlane = false;
                        btn.Checked = false;
                        sceneControl.DisplayObjects();
                    };
                    clipForm.Show();
                    var location = BasePage.ScenePage.PointToScreen(Point.Empty);
                    clipForm.Location = location;
                }
                else
                {
                    var forms = Application.OpenForms.Cast<Form>().ToList();
                    var form = forms.Find(x => x.Name == "clipPlaneForm");
                    if (form != null)
                    {
                        sceneControl.IsClipPlane = true;
                        form.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void btnReflect_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ToolStripButton;

                if (btn.Checked)
                {
                    var sceneControl = BasePage.ScenePage.SceneControl;
                    var reflect = new ReflectControl() { Dock = DockStyle.Fill };

                    var objs = sceneControl.GetVBObjs();
                    reflect.SetGlObjs(objs?.Select(x => x.ObjName));
                    reflect.SelectedObjects(objs?.First().ObjName);

                    var reflectForm = new Form()
                    {
                        TopMost = true,
                        ShowIcon = false,
                        ClientSize = reflect.Size,
                        Text = "Отражение",
                        Owner = Application.OpenForms[0],
                        Name = "reflectForm",
                    };
                    reflectForm.Controls.Add(reflect);

                    reflect.ShowObjs += (ar) =>
                    {
                        //TO DO Можно ли закрасить желтым цветом выбранный VBO?
                        sceneControl.DisplayObjects();
                    };

                    reflect.CreateReflectObj += (ar1, ar2) =>
                    {
                        var copyObjs = sceneControl.GetVBObjs().Where(x => x.ObjName.Contains($"{ar1}_copy")).
                        Select(x => x.ObjName);
                        sceneControl.CreateReflectedVBObject(ar1, $"{ar1}_copy_{copyObjs.Count() + 1}", ar2);
                        reflect.SetGlObjs(copyObjs);
                        sceneControl.DisplayObjects();
                    };

                    reflect.DeleteReflectedObjs += () =>
                    {
                        var listVbo = sceneControl.GetVBObjs().Where(x => x.ObjName.Contains("copy")).ToList();
                        foreach (var item in listVbo)
                            sceneControl.DeleteVBObjects(item.ObjName);
                    };

                    reflect.UpdateReflectPlane += (s, p) =>
                    {
                        //var obj = sceneControl.FindVBObj(s);
                        //var mat = Matrix<float>.Build.Dense(4, 4, obj.ModelMatrix);
                        //mat = mat.Inverse();
                        //var vec = Vector<float>.Build.Dense(p);
                        //vec = vec.Normalize(2);
                        //vec = mat.Multiply(vec);
                        //vec = vec.Normalize(2);
                        //vec[0] = vec[0].Round(2);
                        //vec[1] = vec[1].Round(2);
                        //vec[2] = vec[2].Round(2);
                        if(p.Sum() != 0) // костыль, потом уберем
                            sceneControl.DisplayReflectionPlane(s, p);
                        sceneControl.DisplayObjects();
                    };

                    reflectForm.FormClosing += (o, ev) =>
                    {
                        sceneControl.HideReflectionPlane();
                        var listVbo = sceneControl.GetVBObjs().Where(x => x.ObjName.Contains("copy")).ToList();
                        foreach (var item in listVbo)
                            sceneControl.DeleteVBObjects(item.ObjName);

                        btn.Checked = false;
                        sceneControl.DisplayObjects();
                    };
                    reflectForm.Show();

                    var location = BasePage.ScenePage.PointToScreen(Point.Empty);
                    reflectForm.Location = location;

                    
                }
                else
                {
                    var forms = Application.OpenForms.Cast<Form>().ToList();
                    var form = forms.Find(x => x.Name == "reflectForm");
                    if (form != null)
                    {
                        form.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }
    }  
}
