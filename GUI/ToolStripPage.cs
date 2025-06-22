using BaseModule;
using BaseModule.Navigator;
using BaseModule.SceenControls;
using BazisGUI.Extensions;
using BazisGUI.Utilities;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using ModelControllerInterfaces;
using Scene.Events;
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
        public event Action<object,string,string> ChangedGroupNameEvent;
        public event Action<object,string> CreatedMeshGroupEvent;
        public event Action<object> DeleteAllGroupsEvent;
        public event Action<object,int> DeleteGroupEvent;
        public event Action<object, ObjType, string> DeleteObjectsEvent;
        public event Action<object, SelectObjectsEventArgs, string> SelectObjectsEvent;
        public event Action<object,bool> ChangeAllGroupsViewEvent;
        public event Action<object, bool> ChangeAllObjsViewEvent;
        public event Action<object> ShowInsideObjectsEvent;
        public event Action<object> HideInsideObjectsEvent;
        public event Action<object, ViewMode> ChangeViewModeObjectsEvent;
        public event Action<object, CreatePlaneFromTextArgs> CreateSectionSurfacesFromCoordsEvent;
        public event Action<object> CreateSectionSurfacesFromNodesEvent;
        public event Action<object, string> DistancePointToPointEvent;
        public event Action<object, string> DistancePointToPlaneEvent;
        public event Action<object> CreatePathAsyncEvent;
        public event Action<object, string> CalcSquareEvent;
        public event Action<object, string> CalcVolumeEvent;
        public event Action<object> SelectNodeInPlaneEvent;
        public event Action<object> MakeScreenShotEvent;
        public event Action<object> ShowMeshCountorsEvent;
        public event Action<object> ShowMeshNormalsEvent;
        public event Action<object, float> SelectE2DInPlaneEvent;
        public event Action<object, ObjType, float,bool> SelectInDirectionEvent;
        public event Action<object> FindFreeNodesEvent;
        public event Action<object, int, bool> ChangeGroupViewEvent;
        public event Action<object, ObjType, string, bool> ChangeSetViewStateEvent;
        public event Action<object, int> EditGroupEvent;
        public event Action<object,string> DeleteSelectedObjectsEvent;
        public event Action<object, string> SelectGroupEvent;
        public event Action<object> SetBackColorToAllObjectsEvent;
        public event Action<object,string> HideSelectedObjectsEvent;
        public event Action<object, int> InfoGroupEvent;
        public event Action<object, int> ShowGroupWithNodesEvent;
        public event Action<object> DelAllObjectsEvent;
        public event Action<object, ObjType, string> SelectSetEvent;
        public event Action<object> UpdateNavigatorEvent;
        public event Action<object,string,string> GetObjectsInfoEvent;
        public event Action<object, string> GetSetsInfoEvent;
        public event Action<object, string> GetResultsInfoEvent;
        //public event Action<object, TreeNode> SelectPhysicalDataEvent;

        public string SelectedObjects
        {
            get { return spbSelectObject.ToolTipText; }
            set { spbSelectObject.ToolTipText = value; }
        }

        public SplitContainerEx EmbeddedSplitContainer
        {
            get
            {
                return splitContainerEx;
            }
        }

        public ControlCollection EmbeddedControls
        {
            get
            {
                return splitContainerEx.Panel2.Controls;
            }
        }

        public IModelController ModelController { get; set; } = new ModelController.ModelController();


        public ToolStripPage()
        {
            InitializeComponent();
            //selectToolStrip.Location = new Point(3, 0);
            basePage.SplitterWidthEx = 8;

            basePage.NavigatorControl.TrySearchNodes(NodeType.условия, out List<TreeNode> conds);
            conds[0].ContextMenuStrip = condsMenuStrip;

            basePage.NavigatorControl.TrySearchNodes(NodeType.задачи, out List<TreeNode> tasks);
            tasks[0].ContextMenuStrip = tasksMenuStrip;

            basePage.SelectPhysicalDataEvent += basePage_SelectPhysicalData;

            basePage.NavigatorControl.TrySearchNodes(NodeType.результаты, out List<TreeNode> nodes);
            nodes[0].ContextMenuStrip = resultsMenuStrip;   

            selectToolStrip.Location = new Point(3, 0);
            instrumentalToolStrip.Location = new Point(selectToolStrip.Size.Width + 4, 0);

            scale = basePage.ScenePage.SceneControl.CreateScaleObject(0, 1, 2, "", "");
        }
        private void basePage_SelectPhysicalData(string arg1)
        {
            SelectPhysicalDataEvent?.Invoke(this, arg1);
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
            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                AddObjectsType(item.ToString());

            AddObjectsType("Объекты");
            AddObjectsType("Фигуры");
            AddObjectsType("Элементы");

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
            SetBackColorToAllObjectsEvent?.Invoke(this);
        }

        private void ViewToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var btn = (ToolStripButton)e.ClickedItem;
            var scenePage = basePage.ScenePage;
            var consoleControl = basePage.ConsoleControl;

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
            var consoleControl = basePage.ConsoleControl;
            try
            {

                if (arg2.ClickedItem.Tag.ToString() == "0")
                {
                    basePage.ScenePage.ShowInsideObjects = true;
                    ShowInsideObjectsEvent?.Invoke(this);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "1")
                {
                    basePage.ScenePage.ShowInsideObjects = false;
                    HideInsideObjectsEvent?.Invoke(this);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "2")
                {
                    ChangeViewModeObjectsEvent?.Invoke(this,ViewMode.LineSurface);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "3")
                {
                    ChangeViewModeObjectsEvent?.Invoke(this, ViewMode.Line);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "4")
                {
                    ChangeViewModeObjectsEvent?.Invoke(this, ViewMode.Surface);
                }
            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void PresentObjectsOnScene(IObjsPresenter presenter, string name)
        {
            var scenePage = basePage.ScenePage;
            var consoleControl = basePage.ConsoleControl;
            
            var vbobj = scenePage.SceneControl.FindVBObj(name);
            if (vbobj != null)
            {
                var viewMode = vbobj.ViewMode;

                scenePage.SceneControl.DeleteVBObjects(name);
                scenePage.CreateObjectsOnScene(name, presenter);
                scenePage.SceneControl.ChangeViewModeVBObjects(name, viewMode);
            }
        }

        public Geometry.Plane CreateSectionPlane(Vector3 p0, Vector3 p1, Vector3 p2)
        {
            var mP0 = new Point3D(p0.X, p0.Y, p0.Z);
            var mP1 = new Point3D(p1.X, p1.Y, p1.Z);
            var mP2 = new Point3D(p2.X, p2.Y, p2.Z);
            return new Geometry.Plane(mP0, mP1, mP2);
        }

        private async void MeasuringControl_MakeMeasureEvent(object arg1, MeasureEventArgs arg2)
        {
            var scenePage = basePage.ScenePage;
            var consoleControl = basePage.ConsoleControl;
            try
            {
                switch (arg2.Kind)
                {
                    case MeasureKind.DistancePointToPoint:
                        {
                            DistancePointToPointEvent?.Invoke(this, spbSelectObject.ToolTipText);
                            break;
                        }
                    case MeasureKind.DistancePointToPlane:
                        {
                            DistancePointToPlaneEvent?.Invoke(this, spbSelectObject.ToolTipText);
                            break;
                        }
                    case MeasureKind.Path:
                        CreatePathAsyncEvent?.Invoke(this);                  
                        break;
                    case MeasureKind.Square:
                        {           
                            CalcSquareEvent?.Invoke(this, spbSelectObject.ToolTipText);                        
                            break;
                        }

                    case MeasureKind.Volume:
                        {
          
                            CalcVolumeEvent?.Invoke(this, spbSelectObject.ToolTipText);
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
            var scenePage = basePage.ScenePage;
            var consoleControl = basePage.ConsoleControl;
            try
            {
                var objsType = Converters.ConvertToObjsType(arg2.Objects);
                if (objsType == spbSelectObject.ToolTipText.ToObjType())
                {
                    if (objsType == ObjType.Узел)
                    {
                        SelectNodeInPlaneEvent?.Invoke(this);
                    }
                    else
                    {
                        SelectE2DInPlaneEvent?.Invoke(this,arg2.Angle);
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
            var scenePage = basePage.ScenePage;
            var consoleControl = basePage.ConsoleControl;
            try
            {
                var objsType = Converters.ConvertToObjsType(arg2.Objects);
                if (objsType == spbSelectObject.ToolTipText.ToObjType())
                {
                    SelectInDirectionEvent?.Invoke(this, objsType,arg2.Angle,arg2.Reverse);
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
            var scenePage = basePage.ScenePage;

            if (btn.Tag.ToString() == "1")
                spbSelectObject.ToolTipText = "Узел";
            else if (btn.Tag.ToString() == "2")
                spbSelectObject.ToolTipText = "Элементы";
            else
                spbSelectObject.ToolTipText = "Фигуры";

            spbSelectObject.Invalidate();

            SetBackColorToAllObjectsEvent?.Invoke(this);

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
                    spbSelectObject.ToolTipText = ObjType.Узел.ToString();
                    spbSelectObject.Invalidate();
                };

                selectionControl.SelectElements += (s1, s2) =>
                {
                    spbSelectObject.ToolTipText = ObjType.Элемент2D.ToString();
                    spbSelectObject.Invalidate();
                };

                form.ClientSize = selectionControl.Size;
                form.Controls.Add(selectionControl);
                form.Show();
                var location = basePage.ScenePage.PointToScreen(Point.Empty);
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

            var scenePage = basePage.ScenePage;
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
            var scenePage = basePage.ScenePage;
            var consoleControl = basePage.ConsoleControl;
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

                    crossSection.SelectNodesEvent += () => { spbSelectObject.ToolTipText = ObjType.Узел.ToString(); };

                    crossSection.CreateCrossFromTextArgs += (ar1, ar2) =>
                    {
                        try
                        {                           
                            CreateSectionSurfacesFromCoordsEvent?.Invoke(this,ar2);

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
                            CreateSectionSurfacesFromNodesEvent?.Invoke(this);
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
                        scenePage.SceneControl.DisplayObjects();
                    };

                    form.Show();
                    var location = basePage.ScenePage.PointToScreen(Point.Empty);
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
                var scenePage = basePage.ScenePage;
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
                        spbSelectObject.ToolTipText = ar.ToString();
                        scenePage.SceneControl.HideAllGeometryObjs();
                        scenePage.SceneControl.HideDisplayText3D();
                        scenePage.SceneControl.DisplayObjects();
                    };
                    measuringControl.MakeMeasureEvent += MeasuringControl_MakeMeasureEvent;
                    form.ClientSize = measuringControl.Size;
                    form.Controls.Add(measuringControl);

                    form.Show();
                    var location = basePage.ScenePage.PointToScreen(Point.Empty);
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
                basePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void btnScreenShot_Click(object sender, EventArgs e)
        {
            MakeScreenShotEvent?.Invoke(this);
        }

        private void btnShowCountours_Click(object sender, EventArgs e)
        {
            try
            {
                var scenePage = basePage.ScenePage;

                var btn = (ToolStripButton)sender;
                if (btn.Checked)
                {
                    ShowMeshCountorsEvent?.Invoke(this);
                }
                else
                {
                    scenePage.SceneControl.DeleteVBObjects("Boundary");
                    scenePage.SceneControl.DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                basePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void btnShowNormals_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = (ToolStripButton)sender;
                var scenePage = basePage.ScenePage;
                if (btn.Checked)
                {
                    ShowMeshNormalsEvent?.Invoke(this);
                }
                else
                {
                    scenePage.SceneControl.DeleteVBObjects("Normals");
                    scenePage.SceneControl.DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                basePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void btnShowBasis_Click(object sender, EventArgs e)
        {
            var btn = (ToolStripButton)sender;
            var scenePage = basePage.ScenePage;

            if (btn.Checked)
                scenePage.SceneControl.DisplayBasis = true;
            else scenePage.SceneControl.DisplayBasis = false;

            scenePage.SceneControl.DisplayObjects();
        }

        private void basePage_ChangedGroupNameEvent(object sender,string ar1,string ar2)
        {
            ChangedGroupNameEvent?.Invoke(this,ar1,ar2);
        }

        private void basePage_CreatedMeshGroupEvent(object sender)
        {
            if (spbSelectObject.ToolTipText == "Объекты" |
    spbSelectObject.ToolTipText == "Фигуры" |
    spbSelectObject.ToolTipText == "Элементы")
            {

                basePage.ConsoleControl.PrintInfo($"Нельзя создать группу {spbSelectObject.ToolTipText}", Color.Orange);
            }
            else
            {
                CreatedMeshGroupEvent?.Invoke(this, spbSelectObject.ToolTipText);
            }

        }

        private void btnClipPlane_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ToolStripButton;
                var sceneControl = basePage.ScenePage.SceneControl;
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
                    var location = basePage.ScenePage.PointToScreen(Point.Empty);
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
                basePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void btnReflect_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as ToolStripButton;
                var scenePage = basePage.ScenePage;
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

                    reflect.ShowObjs += (ar) =>
                    {
                        var vbo = scenePage.SceneControl.FindVBObj(ar);
       
                        var a  = (int)vbo.PointsColors[0];
                        var r = (int)vbo.PointsColors[1];
                        var g = (int)vbo.PointsColors[2];
                        var b = (int)vbo.PointsColors[3];

                        var color = Color.FromArgb(a, r, g, b);

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
                        //scenePage.PresentAllModelObjectsToScene();
                        //sceneControl.CreateReflectedVBObject("", "", null);
                        scenePage.SceneControl.DisplayObjects();
                    };
                    reflectForm.Show();

                    var location = basePage.ScenePage.PointToScreen(Point.Empty);
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
                basePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void ChangeVBOColor(string ar, Color color)
        {
            var scenePage = basePage.ScenePage;
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

        private void basePage_DeleteObjectsEvent(object arg1, ObjType arg2, string arg3)
        {
            DeleteObjectsEvent?.Invoke(this, arg2, arg3);
        }

        private void basePage_ChangeAllGroupsViewEvent(object arg1,bool arg2)
        {
            ChangeAllGroupsViewEvent?.Invoke(this, arg2);
        }

        private void basePage_DeleteAllGroupsEvent(object obj)
        {
            DeleteAllGroupsEvent?.Invoke(this);
        }

        private void basePage_DeleteGroupEvent(object arg1, int arg2)
        {
            DeleteGroupEvent?.Invoke(this, arg2);
        }

        private void basePage_SelectObjectsEvent(object arg1, Scene.Events.SelectObjectsEventArgs arg2)
        {
            SelectObjectsEvent?.Invoke(this, arg2, spbSelectObject.ToolTipText);
        }

        private void basePage_FindFreeNodesEvent(object obj)
        {
            FindFreeNodesEvent?.Invoke(this);
        }

        private void basePage_ChangeGroupViewEvent(object arg1, int arg2, bool arg3)
        {
            ChangeGroupViewEvent?.Invoke(this, arg2, arg3);
        }

        private void basePage_ChangeSetViewStateEvent(object arg1, ObjType arg2, string arg3, bool arg4)
        {
            ChangeSetViewStateEvent?.Invoke(this, arg2, arg3, arg4);
        }

        private void basePage_EditGroupEvent(object arg1, int arg2)
        {
            EditGroupEvent?.Invoke(this, arg2);
        }

        private void basePage_SelectGroupEvent(object arg1, string arg2)
        {
            SelectGroupEvent?.Invoke(this, arg2);
        }

        private void basePage_SetBackColorToAllObjectsEvent(object obj)
        {
            SetBackColorToAllObjectsEvent?.Invoke(this);
        }

        private void basePage_HideSelectedObjectsEvent(object obj)
        {
            HideSelectedObjectsEvent?.Invoke(this, spbSelectObject.ToolTipText);
        }

        private void basePage_DeleteSelectedObjectsEvent(object obj)
        {
            DeleteSelectedObjectsEvent?.Invoke(this, spbSelectObject.ToolTipText);
        }

        private void basePage_InfoGroupEvent(object arg1, int arg2)
        {
            InfoGroupEvent?.Invoke(this, arg2);
        }

        private void basePage_ChangeAllObjsViewStateEvent(object arg1, bool arg2)
        {
            ChangeAllObjsViewEvent?.Invoke(this, arg2);
        }

        private void basePage_ShowGroupWithNodesEvent(object arg1, int arg2)
        {
            ShowGroupWithNodesEvent?.Invoke(this, arg2);
        }

        private void basePage_DelAllObjectsEvent(object obj)
        {
            DelAllObjectsEvent?.Invoke(this);
        }

        private void basePage_SelectSetEvent(object arg1, ObjType arg2, string arg3)
        {
            SelectSetEvent?.Invoke(this, arg2, arg3);
        }

        private void basePage_UpdateNavigatorEvent(object obj)
        {
            UpdateNavigatorEvent?.Invoke(this);
        }

        private void basePage_GetObjectsInfoEvent(object arg1, string arg2,string arg3)
        {
            GetObjectsInfoEvent?.Invoke(this, arg2,arg3);
        }

        private void basePage_GetSetsInfoEvent(object arg1, string arg2)
        {
            GetSetsInfoEvent?.Invoke(this, arg2);
        }

        private void сформироватьИнструкцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateTSFEvent?.Invoke(this);
        }

        private void низкийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Priority = Priority.Низкий;
        }

        private void среднийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Priority = Priority.Средний;
        }

        private void высокийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Priority = Priority.Высокий;
        }

        private void остановитьРасчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopComputation();
        }

        private void запуститьРасчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateTCFEvent?.Invoke(this);
        }

        private void удалитьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveResultsEvent?.Invoke(this);
        }

        private void скрытьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideResultsEvent?.Invoke(this);
        }

        private void basePage_GetResultsInfoEvent(object arg1, string arg2)
        {
            GetResultsInfoEvent?.Invoke(this, arg2);
        }
    }  
}
