using BaseModule;
using BaseModule.SceenControls;
using BazisGUI.Utilities;
using Geometry;
using GmshApi;
using Model;
using Model.GeometryObjects;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using Model.Interfaces.ObjectsCollections;
using Model.MeshObjects;
using ModelControllerInterfaces;
using Project.Interfaces;
using Scene.Interfaces;
using Scene.VBO;
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
            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                AddObjectsType(item.ToString());

            AddObjectsType("Объекты");
            AddObjectsType("Фигуры");
            AddObjectsType("Элементы");

            BasePage.ScenePage.SelectedObjects = "Объекты";

            spbSelectObject.ToolTipText = "Объекты";
        }

        public void AddObjectsType(string objsType)
        {
            if (!spbSelectObject.DropDownItems.ContainsKey(objsType))
            {
                var newItem = new ToolStripMenuItem(objsType) { Name = objsType };
                spbSelectObject.DropDownItems.Add(newItem);
            }

        }

        private void spb_Select_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            spbSelectObject.ToolTipText = e.ClickedItem.Text;

            //ObjType objType;
            //Enum.TryParse(spbSelectObject.ToolTipText, out objType);

            var scenePage = BasePage.ScenePage;
            scenePage.SelectedObjects = spbSelectObject.ToolTipText;

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

                        foreach (var item in ModelData.ObjectData.E3DCollection.GetObjects())
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
                    foreach (var item in ModelData.ObjectData.GetSetsInfo(ObjType.Поверхность))
                        item.SetViewMode(ViewMode.LineSurface);
                    foreach (var item in ModelData.ObjectData.GetSetsInfo(ObjType.Элемент2D))
                        item.SetViewMode(ViewMode.LineSurface);
                    foreach (var item in ModelData.ObjectData.GetSetsInfo(ObjType.Элемент3D))
                        item.SetViewMode(ViewMode.LineSurface);

                    foreach (var obj in scenePage.SceneControl.GetVBObjs())
                        scenePage.SceneControl.ChangeViewModeVBObjects(obj.ObjName, ObjView.LinesSurface);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "3")
                {
                    foreach (var item in ModelData.ObjectData.GetSetsInfo(ObjType.Поверхность))
                        item.SetViewMode(ViewMode.Line);
                    foreach (var item in ModelData.ObjectData.GetSetsInfo(ObjType.Элемент2D))
                        item.SetViewMode(ViewMode.Line);
                    foreach (var item in ModelData.ObjectData.GetSetsInfo(ObjType.Элемент3D))
                        item.SetViewMode(ViewMode.Line);
                    foreach (var obj in scenePage.SceneControl.GetVBObjs())
                        scenePage.SceneControl.ChangeViewModeVBObjects(obj.ObjName, ObjView.Lines);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "4")
                {
                    foreach (var item in ModelData.ObjectData.GetSetsInfo(ObjType.Поверхность))
                        item.SetViewMode(ViewMode.Surface);
                    foreach (var item in ModelData.ObjectData.GetSetsInfo(ObjType.Элемент2D))
                        item.SetViewMode(ViewMode.Surface);
                    foreach (var item in ModelData.ObjectData.GetSetsInfo(ObjType.Элемент3D))
                        item.SetViewMode(ViewMode.Surface);
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

        public SurfaceFigure CreateSectionSurfaces(IEnumerable<IElement3D> elems3D, Vector3 p0, Vector3 p1, Vector3 p2)
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
                            var objsType = Converters.ConvertToObjsType(scenePage.SelectedObjects);
                            var objs = ModelData.ObjectData.GetObjects(objsType);
                            var selObjs = objs.Where(x => x.Color == scenePage.SceneControl.SelectionColor).ToList();

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
                            var objsType = Converters.ConvertToObjsType(scenePage.SelectedObjects);
                            var plane = BasePage.CreateSurfaceAsync(objsType);
                            await plane;

                            ModelData.ObjectData.SetBackColor(objsType);

                            scenePage.SetObjectsSceneAttribute(objsType, "цвет");

                            scenePage.SceneControl.DisplayObjects();

                            var res = BasePage.SelectObjectAsync(objsType);
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
                            var objsType = Converters.ConvertToObjsType(scenePage.SelectedObjects);
                            var objs = ModelData.ObjectData.GetObjects(objsType);

                            var selObjs = objs.Where(x => x.Color == scenePage.SceneControl.SelectionColor);

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
                            var objsType = Converters.ConvertToObjsType(scenePage.SelectedObjects);
                            var objs = ModelData.ObjectData.GetObjects(objsType);
                            var selObjs = objs.Where(x => x.Color == scenePage.SceneControl.SelectionColor);

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
                var objsType = Converters.ConvertToObjsType(arg2.Objects);
                if (objsType == Converters.ConvertToObjsType(scenePage.SelectedObjects))
                {
                    var selObjs = ModelData.ObjectData.GetObjects(objsType).
                        Where(x => x.Color == scenePage.SceneControl.SelectionColor).ToArray();

                    if (objsType == ObjType.Узел)
                    {

                        if (selObjs?.Count() > 2)
                        {
                            var n1 = (Node)selObjs.First();
                            var n2 = (Node)selObjs.Skip(1).First();
                            var n3 = (Node)selObjs.Skip(2).First();

                            var plane = new Geometry.Plane(n1.Position, n2.Position, n3.Position);
                            ModelController.SelectionHelper.SelectNodeInPlane(ModelData.ObjectData,
                                plane, scenePage.SceneControl.SelectionColor);
                            scenePage.SetObjectsSceneAttribute(ObjType.Узел, "цвет");
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
                            scenePage.SetObjectsSceneAttribute(ObjType.Элемент2D, "цвет");
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
                var objsType = Converters.ConvertToObjsType(arg2.Objects);
                if (objsType == Converters.ConvertToObjsType(scenePage.SelectedObjects))
                {
                    //var result = await BasePage.SelectObjectsAsync(scenePage.SelectedObjects);
                    //var objs = result as IEnumerable<IModelObject>;
                    
                    var selObjs = ModelData.ObjectData.GetObjects(objsType).
                        Where(x => x.Color == scenePage.SceneControl.SelectionColor).ToArray();
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

                        //selObjs = objs.Where(x => x.Color == sceneControl.SelectionColor).ToArray();
                        scenePage.SetObjectsSceneAttribute(objsType, "цвет");

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
                scenePage.SelectedObjects = "Узел";
            else if (btn.Tag.ToString() == "2")
                scenePage.SelectedObjects = "Элементы";
            else
                scenePage.SelectedObjects = "Фигуры";

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
                    BasePage.ScenePage.SelectedObjects = ObjType.Узел.ToString();
                    spbSelectObject.ToolTipText = ObjType.Узел.ToString();
                    spbSelectObject.Invalidate();
                };

                selectionControl.SelectElements += (s1, s2) =>
                {
                    BasePage.ScenePage.SelectedObjects = ObjType.Элемент2D.ToString();
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

                    crossSection.SelectNodesEvent += () => { scenePage.SelectedObjects = ObjType.Узел.ToString(); };

                    crossSection.CreateCrossFromTextArgs += (ar1, ar2) =>
                    {
                        try
                        {
                            var elems3D = ModelData.ObjectData.E3DCollection.GetObjects();
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
                            var objsType = Converters.ConvertToObjsType(scenePage.SelectedObjects);
                            var objs = ModelData.ObjectData.GetObjects(objsType);
                            var selObjs = objs.Where(x => x.Color == scenePage.SceneControl.SelectionColor).ToArray();
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

                            var elems3D = ModelData.ObjectData.E3DCollection.GetObjects();

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
                            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                            {
                                var presentor = scenePage.CreateObjectsPresentor(item);
                                scenePage.CreateObjectsOnScene(item.ToString(), presentor);
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
                        var objTypes = Converters.ConvertToObjsType(ar);
                        scenePage.SelectedObjects = objTypes.ToString();
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

                    clipForm.Controls.Add(clip);

                    sceneControl.IsClipPlane = true;
                    sceneControl.ChangeClipMode(Scene.ClipMode.Default, ObjType.Элемент3D.ToString());

                    clip.SwitchOnOff += (v) => { sceneControl.IsClipPlane = v; };
                    clip.ChangeClipMode += (mode) =>
                    {
                        sceneControl.ChangeClipMode((Scene.ClipMode)mode, ObjType.Элемент3D.ToString());
                    };

                    clip.ChangeLayerThickness += (layerThickness) => sceneControl.ChangeLayerThickness(layerThickness);

                    clip.SetClipPlaneEvent += (plane) =>
                    {
                        var scPlane = new Geometry.Plane(new Point3D(plane.X, plane.Y, plane.Z), plane.D);
                        sceneControl.ChangeClipPlane(scPlane);
                    };

                    clip.RedrawClipPlane += () => sceneControl.DisplayObjects();

                    clipForm.FormClosing += (o, ev) =>
                    {
                        sceneControl.IsClipPlane = false;
                        sceneControl.ChangeClipMode(Scene.ClipMode.None, ObjType.Элемент3D.ToString());
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
                        sceneControl.IsClipPlane = false;
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
                var scenePage = BasePage.ScenePage;
                if (btn.Checked)
                {
                    var reflect = new ReflectControl();
                    reflect.SetGlObjs(scenePage.SceneControl.GetVBObjs().Select(x => x.ObjName));

                    var reflectForm = new Form()
                    {
                        TopMost = true,
                        ShowIcon = false,
                        ClientSize = new Size(250, 210),
                        MaximizeBox = false,
                        FormBorderStyle = FormBorderStyle.FixedSingle,
                        Text = "Отражение"
                    };
                    reflectForm.Controls.Add(reflect);
                    reflect.Dock = DockStyle.Fill;

                    var color = ModelData.ObjectData.GetObjects(ObjType.Элемент3D).First().Color;

                    reflect.ShowObjs += (ar) =>
                    {
                        foreach (var item in reflect.GetAllSrcObjs())
                            ChangeVBOColor(item, color);

                        ChangeVBOColor(ar, Color.Red);
                        scenePage.SceneControl.DisplayObjects();
                    };

                    reflect.CreateReflectObj += (ar1, ar2) =>
                    {
                        var copyObjs = scenePage.SceneControl.GetVBObjs().Where(x => x.ObjName.Contains($"{ar1}_copy")).
                        Select(x => x.ObjName);
                        scenePage.SceneControl.CreateReflectedVBObject(ar1, $"{ar1}_copy_{copyObjs.Count() + 1}", ar2);
                        reflect.SetGlObjs(copyObjs);
                        scenePage.SceneControl.DisplayObjects();
                    };

                    reflect.MatrixEvent += (s, ev) =>
                    {
                        var obj = scenePage.SceneControl.FindVBObj(s);
                        ev.Matrix = obj.ModelMatrix;
                    };

                    reflect.UpdateReflectPlane += (s, p) =>
                    {
                        scenePage.SceneControl.DisplayReflectionPlane(s, p);
                        scenePage.SceneControl.DisplayObjects();
                    };

                    reflectForm.FormClosing += (o, ev) =>
                    {
                        btn.Checked = false;
                        scenePage.SceneControl.HideReflectionPlane();
                        scenePage.SceneControl.DeleteAllVBObjects();
                        scenePage.PresentAllModelObjectsToScene();
                        //sceneControl.CreateReflectedVBObject("", "", null);
                        scenePage.SceneControl.DisplayObjects();
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

        private void ChangeVBOColor(string ar, Color color)
        {
            var scenePage = BasePage.ScenePage;
            var obj = scenePage.SceneControl.FindVBObj(ar);
            var colors = new float[obj.ColorLength];

            //var count = obj.ColorLength / 4;
            for (int i = 0; i < obj.ColorLength; i += 4)
            {
                colors[i] = Convert.ToInt32(color.R) / 255.0f;
                colors[i + 1] = Convert.ToInt32(color.G) / 255.0f;
                colors[i + 2] = Convert.ToInt32(color.B) / 255.0f;
                colors[i + 3] = Convert.ToInt32(color.A) / 255.0f;
            }
            obj.PointsColors = colors;
        }
    }  
}
