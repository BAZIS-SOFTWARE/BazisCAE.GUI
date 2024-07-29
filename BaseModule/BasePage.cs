using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Geometry;
using ModelInterfaces;
using System.Diagnostics;
using BaseModule.Console;
using BaseModule.CrossSection;
using BaseModule.Console.Events;
using BaseModule.Navigator;
using ModelControllerInterfaces;
using System.Threading;
using ModelInterfaces.MeshObjects;
using ModelInterfaces.GeometryObjects;
using System.ComponentModel;
using ProjectInterfaces;
using BaseModule.Utilities;
using SceneInterface;
using ProjectInterfaces.Tasks;
using ProjectInterfaces.Results;
using Model;
using UserControlsEx;

namespace BaseModule
{
    public partial class BasePage : UserControl
    {
        public Action ChangeProjectDataEvent;
        public Action CreateProjectDataEvent;

        //public ObjType scenePage.SelectedObjects
        //{
        //    get
        //    {
        //        ObjType objType;
        //        Enum.TryParse(spbSelectObject.ToolTipText, out objType);
        //        return objType;
        //    }
        //    set
        //    {
        //        if (spbSelectObject.DropDownItems.ContainsKey(value.ToString()))
        //        {
        //            spbSelectObject.ToolTipText = value.ToString();
        //            spbSelectObject.Invalidate();

        //            scenePage.SetBackColorToAllObjects();
        //            scenePage.SceneControl.DisplayObjects();
        //        }
        //    }
        //} 
        [Category("General")]
        [Description("Меню выбора")]
        public ToolStripEx SelectToolStrip { get { return selectToolStrip; } }

        [Category("General")]
        [Description("Задать цвет выбора групп объектов")]
        public Color SelectionGroupColor { get; set; }              

        public SplittersController SplittersController { get; internal set; }

        public IGeneralData GeneralData { get; set; }

        public event Action DeleteGroupEvent;
        public event Action DeleteAllGroupsEvent;
        public event Action DeleteObjectsEvent;
        public event Action DeleteSelectedObjectsEvent;

        //public IModelController ModelController { get; set; }

        //public IPresentersCreator PresentersCreator 
        //{ 
        //    get { return ModelController.PresentersCreator; }
        //}  

        public Keys PressedKey { get; set; }

        //public IProjectData Project { get; set; }

        public BasePage()
        {
            InitializeComponent();

            SplittersController = new SplittersController(this);

            //if(ComponentsPainter.ScreenDPI == 120 | ComponentsPainter.ScreenDPI == 144)
            //selectToolStrip_1.Location = new Point(3,0);
        }

        public void SceneInitialization()
        {
            scenePage.SceneControl.Initialization();
            ClearAllDataOnScene();
        }

        //public void PresentAllModelObjectsToScene()
        //{
        //    foreach (var item in scenePage.ModelData.ObjectData.ObjsTypes)
        //    {
        //        var presentor = CreateObjectsPresentor(item);
        //        if (presentor.Count() > 0)
        //            CreateObjectsOnScene(item.ToString(), presentor);
        //    }
        //}  

        //public IObjsPresenter CreateObjectsPresentor(ObjType objType)
        //{
        //    IObjsPresenter presenter;

        //    switch (objType)
        //    {
        //        case ObjType.Узел:
        //            presenter = PresentersCreator.CreatePointObjectsPresenter(scenePage.ModelData.ObjectData.NodeCollection);
        //            break;
        //        case ObjType.Линия:
        //            presenter = PresentersCreator.CreateLineObjectsPresenter(scenePage.ModelData.ObjectData.LineCollection);
        //            break;
        //        case ObjType.Фигура2D:
        //            presenter = PresentersCreator.CreateSurfaceObjectsPresenter(scenePage.ModelData.ObjectData.Fig2DCollection, false);
        //            break;
        //        case ObjType.Фигура3D:
        //            presenter = PresentersCreator.CreateSurfaceObjectsPresenter(scenePage.ModelData.ObjectData.Fig3DCollection, false);
        //            break;
        //        case ObjType.Элемент1D:
        //            presenter = PresentersCreator.CreateLineObjectsPresenter(scenePage.ModelData.ObjectData.E1DCollection);
        //            break;
        //        case ObjType.Элемент2D:
        //            presenter = PresentersCreator.CreateSurfaceObjectsPresenter(scenePage.ModelData.ObjectData.E2DCollection, false);
        //            break;
        //        case ObjType.Элемент3D:
        //            presenter = PresentersCreator.CreateSurfaceObjectsPresenter(scenePage.ModelData.ObjectData.E3DCollection, true);
        //            break;
        //        default:
        //            presenter = PresentersCreator.CreatePointObjectsPresenter(scenePage.ModelData.ObjectData.PointCollection);
        //            break;
        //    }

        //    return presenter;
        //}


        public NavigatorControl NavigatorControl
        {
            get
            {
                return navigator;
            }
        }

        public ScenePage ScenePage
        {
            get
            {
                return scenePage;
            }
        }

        public ConsoleControl ConsoleControl
        {
            get
            {
                return consoleControl;
            }
        }           

        public void CreateScreenShot(string fileName)
        {
            this.BringToFront();
            var bmpPicture = new Bitmap(scenePage.Width, scenePage.Height);
            var gr = Graphics.FromImage(bmpPicture);
            var pos = scenePage.PointToScreen(Point.Empty);
            var size = new Size(scenePage.Size.Width - 5, scenePage.Size.Height - 20);
            gr.CopyFromScreen(pos, Point.Empty, size);

            bmpPicture.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        //public void CreateObjectsOnScene(string objsName, IObjsPresenter presenter)
        //{
        //    if (!scenePage.SceneControl.DrawInsideObjects & presenter.IsVolumeObjs)
        //    {
        //        var volPresenter = (IVolumeObjsPresenter)presenter;
        //        volPresenter.HideInsideSurfaces();
        //    }

        //    var inds = presenter.CreateIndexes();
        //    var ptrs = presenter.CreatePointers(inds.Item1);
        //    var coords = presenter.CreateVertexes(inds.Item2, "координаты");
        //    var colors = presenter.CreateVertexes(inds.Item3, "цвет");
        //    var normals = presenter.CreateVertexes(inds.Item2, "нормаль");
        //    var edges = presenter.CreateEdgeFlags(inds.Item4);

        //    if (presenter.PresenterType == PresenterType.Surface)
        //    {
        //        if (PresentersCreator.GetView(objsName) == PresenterView.Line)
        //            scenePage.SceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, ObjView.Lines);
        //        else if (PresentersCreator.GetView(objsName) == PresenterView.LineSurface)
        //            scenePage.SceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, ObjView.LinesSurface);
        //        else
        //            scenePage.SceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, ObjView.Surface);
        //    }

        //    else if (presenter.PresenterType == PresenterType.Line)
        //    {
        //        scenePage.SceneControl.CreateLineVBObjects(ptrs, coords, colors, normals, edges, objsName);
        //    }

        //    else
        //        scenePage.SceneControl.CreatePointVBObjects(ptrs, coords, colors, normals, objsName);
        //}

        //public void SetBackColorToAllObjects()
        //{
        //    foreach (var item in scenePage.ModelData.ObjectData.ObjsTypes)
        //    {
        //        foreach (var obj in scenePage.ModelData.ObjectData.GetObjects(item))
        //            obj.SetBackColor();
        //        SetObjectsSceneColor(item);
        //    }

        //}       

        public void PresentModelOnSelectToolStrip(IObjectsData objectsData)
        {
            foreach (var item in objectsData.ObjsTypes)
                AddObjectsType(item);

            AddObjectsType(ObjType.Объект);
            AddObjectsType(ObjType.Фигура);
            AddObjectsType(ObjType.Элемент);

            scenePage.SelectedObjects = ObjType.Объект;
        }

        public void AddObjectsType(ObjType objsType)
        {
            if (!spbSelectObject.DropDownItems.ContainsKey(objsType.ToString()))
            {
                var newItem = new ToolStripMenuItem(objsType.ToString()) { Name = objsType.ToString() };
                spbSelectObject.DropDownItems.Add(newItem);
            }

        }

        public virtual void PresentProjectOnTree()
        {
            navigator.SetProjectTitleInfo("названиеПроекта", "Название : " + GeneralData.Name);
            navigator.SetProjectTitleInfo("путь", "Путь : " + GeneralData.Path);
            navigator.SetProjectTitleInfo("сведения", "Сведения : " + GeneralData.Comments);
            navigator.SetProjectTitleInfo("вид", "Вид: " + GeneralData.TaskType);

            navigator.TreeView.BeginUpdate();

            navigator.TreeView.Nodes["объекты"].Expand();
            navigator.TreeView.Nodes["объекты"].Nodes.Clear();

            foreach (var objType in scenePage.ModelData.ObjectData.ObjsTypes)
            {
                var objs = scenePage.ModelData.ObjectData.GetObjects(objType);
                navigator.CreateChildNode("объекты", objType.ToString(), $"{objType} : {objs.Count()}", "4.1");
                navigator.ShowObjectsNode(objType.ToString());
            }

            navigator.TreeView.Nodes["группыОбъектов"].Expand();
            navigator.TreeView.Nodes["группыОбъектов"].Nodes.Clear();

            foreach (var group in scenePage.ModelData.GroupData)
            {
                navigator.CreateChildNode("группыОбъектов", group.ObjType.ToString(), group.GroupName, "5.1");
            }

            navigator.TreeView.EndUpdate();
        }


        public void ClearAllDataOnScene()
        {
            scenePage.SceneControl.HideAllGeometryObjs();
            scenePage.SceneControl.HideDisplayText2D();
            scenePage.SceneControl.HideDisplayText3D();
            scenePage.SceneControl.DeleteAllVBObjects();
        }

        private void SelectToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var selectStrip = (ToolStrip)sender;

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
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void SelectionControl_SelectInDirection(object arg1, SelectInDirectionEventArgs arg2)
        {
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

        private void InstrumentalToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                var btn = (ToolStripButton)e.ClickedItem;
                if (!btn.Checked)
                {
                    if (e.ClickedItem.Tag.ToString() == "0")
                    {
                        var form = new Form() { Name = "measureForm", Text = "Измерить", ShowIcon = false, 
                            Owner = Application.OpenForms[0],TopMost = true };

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
                        var form = new Form() { Name = "CrossSectionForm", Text = "Построить сечение", 
                            ShowIcon = false, Size = new Size(268, 203),
                            Owner = Application.OpenForms[0],TopMost = true };

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
                                ConsoleControl.PrintInfo(ex.Message, Color.Red);
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
                                ConsoleControl.PrintInfo(ex.Message, Color.Red);
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
                        CreateScreenShot(GeneralData.Path + "\\screenShot.bmp");
                        consoleControl.PrintInfo($"Сделан снимок экрана {GeneralData.Path}\\screenShot.bmp", Color.Black);
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

            return scenePage.ModelController.CrossSectionMaker.GetSectionSurfaces(elems3D, plane);
        }

        private async void MeasuringControl_MakeMeasureEvent(object arg1, MeasureEventArgs arg2)
        {
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
                            var plane = CreateSurfaceAsync(scenePage.SelectedObjects);
                            await plane;

                            var objects = scenePage.ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);
                            foreach (var _object in objects)
                                _object.SetBackColor();

                            scenePage.SetObjectsSceneColor(scenePage.SelectedObjects);

                            scenePage.SceneControl.DisplayObjects();

                            var res = SelectObjectAsync(scenePage.SelectedObjects);
                            await res;

                            if(res.Result is IPoint point)
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
                        await CreatePathAsync(); 
                        break;
                    case MeasureKind.Square:
                        {
                            var square = 0.0f;

                            var objs = scenePage.ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);

                            var selObjs = objs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor);

                            foreach (var obj in selObjs)
                            {
                                var sObj = (ISquare)obj;
                                square += sObj.CalcSquare();
                            }
                            consoleControl.PrintInfo(string.Format("Площадь : {0}", square), Color.Black);
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
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public async Task<List<IPoint>> CreatePathAsync()
        {
            var nodes = new List<IPoint>();

            var message = @"Начните строить путь нажав на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";
            ConsoleControl.PrintInfo(message, Color.Black);

            while (true)
                {
                    var res = SelectObjectAsync(scenePage.SelectedObjects);
                    await res;

                    if (res.Result is IPoint node)
                    {
                        nodes.Add(node);
                        node.SetBackColor();
                    }
                    else break;

                    if (nodes.Count > 1)
                    {
                        var line = new Segment3D(nodes[nodes.Count - 1].Position, nodes[nodes.Count - 2].Position);
                        consoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);
                        scenePage.SceneControl.DisplayDistance(line);
                        scenePage.SceneControl.DisplayObjects();
                    }
                }
            return nodes;
        }


        public async Task<object> SelectObjectAsync(ObjType objType)
        {
            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    ConsoleControl.PrintInfo("Операция отменена", Color.Black);
                }));
            });

            var message = $@"Выберите {objType} и нажмите на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";

            var actPointConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var objs = scenePage.ModelData.ObjectData.GetObjects(objType);
                
                var selObjs = objs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor);

                if (selObjs.Count() == 0)
                {
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo($"Не выбран ни один {objType}!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else if(selObjs.Count() > 1)
                {
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo($"Выберите один {objType}!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    var node = selObjs.First();
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo($"Выбран {objType} с номером {node.Number}", Color.Green);
                    }));
                    return new Tuple<bool, object>(true, node);
                }
            });

            var pointAwait = AsyncMethodContainer(actPointConfirm, actBreak, message);
            await pointAwait;
            return pointAwait.Result;
        }

        public async Task<Plane> CreateSurfaceAsync(ObjType objType)
        {
            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    ConsoleControl.PrintInfo("Операция отменена", Color.Black);
                }));
            });
            var message = @"Задайте поверхность, выбрав три узла, и нажмите на клавишу ""E"" или нажмите кнопку ""ESC""";
            var actSurfaceConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var pointObjs = scenePage.ModelData.ObjectData.GetObjects(objType);
                var selObjs = pointObjs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor).ToArray();

                if (selObjs.Length < 3)
                {
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo("Выберите три узла или точки!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else if (objType != ObjType.Узел & objType != ObjType.Точка)
                {
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo("Выберите или узлы или точки!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    var p0 = selObjs[0];
                    var p1 = selObjs[1];
                    var p2 = selObjs[2];

                    var plane = new Plane(p0.CalcCentr(), p1.CalcCentr(), p2.CalcCentr());
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo("Задана плоскость", Color.Green);
                    }));
                    return new Tuple<bool, object>(true, plane);
                }
            });
            var surfaceAwait = AsyncMethodContainer(actSurfaceConfirm, actBreak, message);
            await surfaceAwait;
            return (Plane)surfaceAwait.Result;
        }    

        private void ViewToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var btn = (ToolStripButton)e.ClickedItem;

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
                else if(arg2.ClickedItem.Tag.ToString() == "5")
                {
                    var btn = (ToolStripButton)arg2.ClickedItem;
                    if (!btn.Checked)
                        ScenePage.SceneControl.DisplayBasis = true;
                    else ScenePage.SceneControl.DisplayBasis = false;
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

        public async void WaitProcessAsync(Process process, Action<object, EventArgs> action)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                process.WaitForExit();
            });
            action.Invoke(process, new EventArgs());
        }

        public async Task<object> AsyncMethodContainer(Func<Tuple<bool,object>> actConfirm, Action actBreak, string cmdMessage)
        {
            var resObject = new object();
            PressedKey = Keys.None;
            Invoke(new Action(() => 
            {
                scenePage.SceneControl.DisplayText2D(cmdMessage, Color.Black, new Point2D(10, 10));
                scenePage.SceneControl.DisplayObjects();
            }));
            await System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (PressedKey == Keys.E)
                    {
                        var resAction = actConfirm.Invoke();
                        if (resAction.Item1)
                        {
                            resObject = resAction.Item2;
                            break;
                        }
                        PressedKey = Keys.None;
                    }
                    if (PressedKey == Keys.Escape)
                    {
                        actBreak.Invoke();
                        break;
                    }
                }             
            });

            scenePage.SceneControl.HideDisplayText2D();
            scenePage.SceneControl.DisplayObjects();

            PressedKey = Keys.None;
            return resObject;
        }


        //private void sceneControl_MessageEvent(object arg1, MessageEventArgs arg2)
        //{
        //    consoleControl.PrintInfo(arg2.Message, Color.Red);
        //}

        //private void sceneControl_SelectObjectsEvent(object arg1, SelectObjectsEventArgs arg2)
        //{
        //    var selections = SearchObjects(scenePage.SelectedObjects, arg2.SelectionBox);

        //    if(selections.Count > 0)
        //    {
        //        scenePage.SelectObjects(arg2.IsSelected, arg2.IsSorted, selections);

        //        if (scenePage.SelectedObjects == ObjType.Объект)
        //        {
        //            var types = scenePage.ModelData.ObjectData.ObjsTypes;
        //            foreach (var type in types)
        //                SetObjectsSceneColor(type);
        //        }
        //        else if (scenePage.SelectedObjects == ObjType.Элемент)
        //        {
        //            SetObjectsSceneColor(ObjType.Элемент1D);
        //            SetObjectsSceneColor(ObjType.Элемент2D);
        //            SetObjectsSceneColor(ObjType.Элемент3D);
        //        }
        //        else if (scenePage.SelectedObjects == ObjType.Фигура)
        //        {
        //            SetObjectsSceneColor(ObjType.Фигура2D);
        //            SetObjectsSceneColor(ObjType.Фигура3D);
        //        }
        //        else
        //            SetObjectsSceneColor(scenePage.SelectedObjects);

        //        scenePage.SceneControl.DisplayObjects();
        //    }
        //}

        //public void SetObjectsSceneColor(ObjType objsType)
        //{
        //    var objName = objsType.ToString();
        //    var vboObjs = scenePage.SceneControl.FindVBObj(objName);

        //    if (vboObjs != null)
        //    {
        //        var objsPresenter = CreateObjectsPresentor(objsType);

        //        if(objsPresenter.Count() > 0)
        //        {
        //            var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
        //            vboObjs.PointsColors = colors;
        //        }
        //    }
        //}

        //private void SelectObjects(bool isSelected, bool isSorted, List<IModelObject> selections)
        //{
        //    if (isSorted & selections.Count > 0)
        //    {
        //        var camera = scenePage.SceneControl.GetCamera();

        //        var near = selections.OrderByDescending(x => camera.GetSceenCoord(x.CalcCentr())._z).First();
        //        if (isSelected)
        //        {
        //            near.MasterColor = scenePage.SceneControl.SelectionColor;
        //        }
        //        else
        //            near.SetBackColor();
        //    }
        //    else
        //    {
        //        foreach (var obj in selections)
        //            if (isSelected)
        //            {
        //                obj.MasterColor = scenePage.SceneControl.SelectionColor;
        //            }

        //            else
        //                obj.SetBackColor();
        //    }
        //}


        //private void sceneControl_HidescenePage.SelectedObjectsEvent(object sender, EventArgs arg)
        //{
        //    var selObjs = scenePage.ModelData.ObjectData.GetObjects(scenePage.SelectedObjects).
        //        Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor);

        //    foreach (var selObj in selObjs)
        //        selObj.ViewState = false;

        //    if (scenePage.SelectedObjects == ObjType.Объект)
        //    {
        //        scenePage.SceneControl.DeleteAllVBObjects();
        //        PresentAllModelObjectsToScene();
        //    }
        //    else if (scenePage.SelectedObjects == ObjType.Элемент)
        //    {
        //        scenePage.SceneControl.DeleteVBObjects(ObjType.Элемент1D.ToString());
        //        CreateObjectsOnScene(ObjType.Элемент1D.ToString(), CreateObjectsPresentor(ObjType.Элемент1D));
        //        scenePage.SceneControl.DeleteVBObjects(ObjType.Элемент2D.ToString());
        //        CreateObjectsOnScene(ObjType.Элемент2D.ToString(), CreateObjectsPresentor(ObjType.Элемент2D));
        //        scenePage.SceneControl.DeleteVBObjects(ObjType.Элемент3D.ToString());
        //        CreateObjectsOnScene(ObjType.Элемент3D.ToString(), CreateObjectsPresentor(ObjType.Элемент3D));
        //    }
        //    else if (scenePage.SelectedObjects == ObjType.Фигура)
        //    {
        //        scenePage.SceneControl.DeleteVBObjects(ObjType.Фигура2D.ToString());
        //        CreateObjectsOnScene(ObjType.Фигура2D.ToString(), CreateObjectsPresentor(ObjType.Фигура2D));
        //        scenePage.SceneControl.DeleteVBObjects(ObjType.Фигура3D.ToString());
        //        CreateObjectsOnScene(ObjType.Фигура3D.ToString(), CreateObjectsPresentor(ObjType.Фигура3D));
        //    }
        //    else
        //    {
        //        var strObjType = scenePage.SelectedObjects.ToString();
        //        scenePage.SceneControl.DeleteVBObjects(strObjType);
        //        CreateObjectsOnScene(strObjType, CreateObjectsPresentor(scenePage.SelectedObjects));
        //    }


        //    scenePage.SceneControl.DisplayObjects();
        //}

        //private void sceneControl_SetBackColorEvent(object sender, EventArgs arg)
        //{
        //    scenePage.SetBackColorToAllObjects();
        //    scenePage.SceneControl.HideDisplayText3D();
        //    scenePage.SceneControl.DisplayObjects();
        //}

        private void BasePage_Load(object sender, EventArgs e)
        {
            navigator.NavigatorPanelCollapseEvent += () => { splitContainer1.Panel1Collapsed = true; };
            scenePage.SceneControl.SceneControlExpandEvent += () =>
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer2.Panel2Collapsed = true;
            };

            scenePage.SceneControl.SceneControlFoldEvent += () =>
            {
                splitContainer1.Panel1Collapsed = false;
                splitContainer2.Panel2Collapsed = false;
            };
            consoleControl.ConsolePanelCollapseEvent += () => { splitContainer2.Panel2Collapsed = true; };
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            navigator.Invalidate();
        }

        

        public async void ConsoleControl_InEvent(object arg1, EventArgs arg2)
        {
            try
            {
                if (arg2 is ModelFindFreeNodesEventArgs freeNodesEventArgs)
                {
                    var freeNodes = scenePage.ModelController.FreeNodesFinder.Find(scenePage.ModelData.ObjectData);

                    Invoke(new Action(() =>
                    {
                        consoleControl.PrintInfo($"Найдено {freeNodes.Count()} свободных узлов", Color.Black);

                        HideAllObjects();

                        foreach (var freeNode in freeNodes)
                            scenePage.ModelData.ObjectData.Find(ObjType.Узел, freeNode).ViewState = true;

                        var objsTypeStr = ObjType.Узел.ToString();
                        scenePage.SceneControl.DeleteVBObjects(objsTypeStr);
                        scenePage.CreateObjectsOnScene(objsTypeStr, scenePage.CreateObjectsPresentor(ObjType.Узел));

                        scenePage.SceneControl.DisplayObjects();
                    }));
                }
                else if (arg2 is FindObjectEventArgs findObjectEventArgs)
                {
                    Invoke(new Action(() =>
                    {
                        var obj = scenePage.ModelData.ObjectData.Find(findObjectEventArgs.ObjsType, (int)findObjectEventArgs.Number);

                        if (obj != null)
                        {
                            foreach (var item in scenePage.ModelData.ObjectData.GetObjects(ObjType.Объект))
                                item.ViewState = false;
                            obj.ViewState = true;
                            ClearAllDataOnScene();
                            scenePage.PresentAllModelObjectsToScene();
                            scenePage.SceneControl.DisplayObjects();
                        }
                    }));
                }
                else if (arg2 is ModelFindCoincidentsNodesEventArgs coincidentNodesEventArgs)
                {
                    Invoke(new Action(() => { consoleControl.PrintInfo("Выполняется поиск совпадающих узлов сетки...", Color.Black); }));

                    scenePage.ModelController.CoincidentObjectsFinder.ProgressEvent += (ar1, ar2) =>
                    {
                        Invoke(new Action(() => { consoleControl.PrintInfo(string.Format("{0:00}%", ar2 * 100), Color.Black); }));
                    };

                    var nodes = scenePage.ModelData.ObjectData.NodeCollection;
                    var coincidentNodes = scenePage.ModelController.CoincidentObjectsFinder.Find(
                        nodes.ToList(), 0.001f);

                    Invoke(new Action(() => { consoleControl.PrintInfo($"Найдено {coincidentNodes.Where(x => x.Count > 2).Count()} совпадений", Color.Black); }));
                    Invoke(new Action(() =>
                    {
                        foreach (var objType in scenePage.ModelData.ObjectData.ObjsTypes)
                            scenePage.CreateObjectsOnScene(objType.ToString(), scenePage.CreateObjectsPresentor(objType));
                        scenePage.SceneControl.DisplayObjects();
                    }));
                    var actConfirm = new Func<Tuple<bool, object>>(() =>
                    {
                        var mergedNodes = scenePage.ModelController.ObjectsMerger.Merge(coincidentNodes, nodes.ToList());

                        scenePage.ModelData.ObjectData.NodeCollection.Clear();
                        scenePage.ModelData.ObjectData.NodeCollection.AddRange(mergedNodes);

                        Invoke(new Action(() =>
                        {
                            PresentProjectOnTree();
                            consoleControl.PrintInfo("Узлы слиты", Color.Green);
                        }));
                        return new Tuple<bool, object>(true, new object());
                    });

                    var actBreak = new Action(() =>
                    {
                        Invoke(new Action(() =>
                        {
                            consoleControl.PrintInfo("Операция отменена", Color.Black);
                        }));
                    });
                    await AsyncMethodContainer(actConfirm, actBreak, $"Нажмите {"E"} для слияния, {"Esc"} для отмены");
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => { consoleControl.PrintInfo(ex.Message, Color.Red); }));
            }
        }

        

        //public List<IModelObject> SearchObjects(ObjType objType, RectangleBox selectionBox)
        //{
        //    var camera = scenePage.SceneControl.GetCamera();
        //    var selections = new List<IModelObject>();

        //    foreach (var item in scenePage.ModelData.ObjectData.GetObjects(objType))
        //    {
        //        if (item.ViewState)
        //        {
        //            var scrPoints = new Point2D[item.NumberOfPoints];
        //            var scnPoints = new Point3D[item.NumberOfPoints];

        //            var pointCounter = 0;
        //            foreach (var point in item.GetCoordinates())
        //            {
        //                var scnPoint = camera.GetSceenCoord(point);
        //                scnPoints[pointCounter] = scnPoint;

        //                var scrPoint = camera.GetScreenCoord(scnPoint);
        //                scrPoints[pointCounter] = scrPoint;

        //                pointCounter++;
        //            }

        //            if (selectionBox.IsPointsInside(scrPoints))
        //                selections.Add(item);
        //        }
        //    }
        //    return selections;
        //}

        private void navigator_DelGroupEvent(int obj)
        {
            var group = scenePage.ModelData.GroupData[obj];
            scenePage.ModelData.GroupData.Remove(group);

            DeleteGroupEvent?.Invoke();
        }

        private void navigator_DelAllGroupsEvent()
        {
            scenePage.ModelData.GroupData.Clear();

            DeleteAllGroupsEvent?.Invoke();
        }

        private void navigator_DelObjectsEvent(string objs)
        {
            ObjType objType;
            Enum.TryParse(objs, out objType);
 
            scenePage.ModelData.ObjectData.Clear(objType);
            scenePage.ModelData.GroupData.ClearNotExisted();

            DeleteObjectsEvent?.Invoke();
        }

        private async void navigator_EditGroupEvent(int obj)
        {
            var group = scenePage.ModelData.GroupData[obj];
            scenePage.SelectedObjects = group.ObjType;

            foreach (var iobj in group)
                iobj.MasterColor = scenePage.SceneControl.SelectionColor;

            scenePage.SetObjectsSceneColor(scenePage.SelectedObjects);

            scenePage.SceneControl.DisplayObjects();

            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var objs = scenePage.ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);
                var selObj = objs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor);

                if (selObj.Count() == 0)
                {
                    Invoke(new Action(() => {
                        ConsoleControl.PrintInfo("Не выбран ни один объект!", Color.Black);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    group.Clear();
          
                    group.AddRange(selObj);
    
                    Invoke(new Action(() => {
                        consoleControl.PrintInfo("Группа изменена успешно", Color.Green);
                    }));
                    return new Tuple<bool, object>(true, new object());
                }
            });

            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    consoleControl.PrintInfo("Операция отменена", Color.Black);
                }));
            });

            var message = "Измените группу, добавив или удалив объекты, и нажмите на кнопку E или нажмите кнопку ESC";
 
            await AsyncMethodContainer(actConfirm, actBreak, message);
        }

        private void navigator_HideAllGroupsEvent()
        {
            foreach (var group in scenePage.ModelData.GroupData)
            {
                foreach (var iobj in group)
                {
                    iobj.ViewState = false;
                }
            }
            scenePage.SceneControl.DeleteAllVBObjects();
            scenePage.PresentAllModelObjectsToScene();

            scenePage.SceneControl.DisplayObjects();
        }

        private void navigator_HideAllObjectsEvent()
        {
            HideAllObjects();

            scenePage.SceneControl.DisplayObjects();
        }

        private void HideAllObjects()
        {
            try
            {
                foreach (var item in scenePage.ModelData.ObjectData.ObjsTypes)
                {
                    foreach (var modelObject in scenePage.ModelData.ObjectData.GetObjects(item))
                        modelObject.ViewState = false;
                }
                scenePage.SceneControl.DeleteAllVBObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_HideGroupEvent(int obj)
        {
            try
            {
                var group = scenePage.ModelData.GroupData[obj];

                foreach (var iobj in group)
                    iobj.ViewState = false;

                var vbobj = scenePage.SceneControl.FindVBObj(group.ObjType.ToString());
                if (vbobj == null)
                    throw new Exception($"Объект {group.ObjType} не загружен на сцену!");
                var viewMode = vbobj.ViewMode;

                scenePage.SceneControl.DeleteVBObjects(group.ObjType.ToString());
                scenePage.CreateObjectsOnScene(group.ObjType.ToString(), scenePage.CreateObjectsPresentor(group.ObjType));
                scenePage.SceneControl.ChangeViewModeVBObjects(group.ObjType.ToString(), viewMode);

                scenePage.SceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_HideObjectsEvent(string obj)
        {
            try
            {
                ObjType objType;
                Enum.TryParse(obj, out objType);

                foreach (var modelObject in scenePage.ModelData.ObjectData.GetObjects(objType))
                    modelObject.ViewState = false;

                scenePage.SceneControl.DeleteVBObjects(obj);

                scenePage.CreateObjectsOnScene(obj, scenePage.CreateObjectsPresentor(objType));
                scenePage.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowAllObjectsEvent()
        {
            scenePage.ShowAllObjects();
            scenePage.SceneControl.DisplayObjects();
        }

        private void navigator_ShowObjectsEvent(string obj)
        {
            try
            {
                ObjType objType;
                Enum.TryParse(obj, out objType);

                foreach (var modelObject in scenePage.ModelData.ObjectData.GetObjects(objType))
                    modelObject.ViewState = true;

                scenePage.SceneControl.DeleteVBObjects(obj);

                scenePage.CreateObjectsOnScene(obj, scenePage.CreateObjectsPresentor(objType));

                scenePage.SceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_InfoGroupEvent(int obj)
        {
            var group = scenePage.ModelData.GroupData[obj];
            consoleControl.PrintInfo(group.ToString(), Color.Black);
        }

        private void navigator_RenameGroup(string newName, string oldName)
        {
            var gr = scenePage.ModelData.GroupData.Find(oldName);
            if (gr != null)
            {
                gr.GroupName = newName;

                ChangeProjectDataEvent?.Invoke();
                Thread.Sleep(100);
                //PresentProjectOnTree();
            }
        }

        private void navigator_SelectGroupEvent(string obj)
        {
            try
            {
                scenePage.SetBackColorToAllObjects();

                var group = scenePage.ModelData.GroupData.Find(obj);

                foreach (var iobj in group)
                    iobj.MasterColor = SelectionGroupColor;

                scenePage.SetObjectsSceneColor(group.ObjType);

                scenePage.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowAllGroupsEvent()
        {
            foreach (var group in scenePage.ModelData.GroupData)
            {
                foreach (var iobj in group)
                {
                    iobj.ViewState = true;
                }
            }

            scenePage.SceneControl.DeleteAllVBObjects();

            scenePage.PresentAllModelObjectsToScene();

            scenePage.SceneControl.DisplayObjects();
        }

        private void navigator_ShowGroupEvent(int obj)
        {
            var group = scenePage.ModelData.GroupData[obj];

            foreach (var iobj in group)
                iobj.ViewState = true;

            var strObjType = group.ObjType.ToString();
            scenePage.SceneControl.DeleteVBObjects(strObjType);
            scenePage.CreateObjectsOnScene(strObjType, scenePage.CreateObjectsPresentor(group.ObjType));
            scenePage.SceneControl.DisplayObjects();
        }

        private void navigator_ChangeViewModeEventHandler(string objs, ViewRegime viewRegime)
        {
  
            switch (viewRegime)
            {
                case ViewRegime.ribbers:
                    scenePage.SceneControl.ChangeViewModeVBObjects(objs, ObjView.Lines);
                    scenePage.PresentersCreator.SetView(objs, PresenterView.Line);
                    break;
                case ViewRegime.surfaces:
                    scenePage.SceneControl.ChangeViewModeVBObjects(objs, ObjView.Surface);
                    scenePage.PresentersCreator.SetView(objs, PresenterView.Surface);
                    break;
                case ViewRegime.ribbersSurfaces:
                    scenePage.SceneControl.ChangeViewModeVBObjects(objs, ObjView.LinesSurface);
                    scenePage.PresentersCreator.SetView(objs, PresenterView.LineSurface);
                    break;
                default:
                    break;
            }

            scenePage.SceneControl.DisplayObjects();
        }

        private void navigator_ShowGroupWithNodesEvent(int obj)
        {
            var group = scenePage.ModelData.GroupData[obj];

            foreach (var iobj in group)
            {
                var elem = (IElement)iobj;
                elem.ViewState = true;

                foreach (var node in elem.GetVertexes())
                    node.ViewState = true;

            }          

            scenePage.SceneControl.DeleteVBObjects(ObjType.Узел.ToString());
            scenePage.CreateObjectsOnScene(ObjType.Узел.ToString(), scenePage.CreateObjectsPresentor(ObjType.Узел));

            var strObjType = group.ObjType.ToString();
            scenePage.SceneControl.DeleteVBObjects(strObjType);
            scenePage.CreateObjectsOnScene(strObjType, scenePage.CreateObjectsPresentor(group.ObjType));

            scenePage.SceneControl.DisplayObjects();
        }

        private void sceneControl_Load(object sender, EventArgs e)
        {
            SceneInitialization();
        }

        private void spb_Select_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            spbSelectObject.ToolTipText = e.ClickedItem.Text;

            ObjType objType;
            Enum.TryParse(spbSelectObject.ToolTipText, out objType);

            scenePage.SelectedObjects = objType;

            scenePage.SetBackColorToAllObjects();
            scenePage.SceneControl.DisplayObjects();

        }

        private void scenePage_SceneInfoEvent(object arg1, string arg2, Color arg3)
        {
            consoleControl.PrintInfo(arg2, arg3);
        }

        private void scenePage_ShowAllObjectsEvent(object obj)
        {
            foreach (var item in scenePage.ModelData.ObjectData.ObjsTypes)
                navigator.ShowObjectsNode(item.ToString());
        }

        private void scenePage_SelectionDeletedEvent(object obj)
        {
            DeleteSelectedObjectsEvent?.Invoke();
            //PresentProjectOnTree();
        }

        public virtual void scenePage_CreateMeshGroupEvent(object sender, string arg)
        {
            consoleControl.PrintInfo(string.Format("Создана новая группа {0}", arg), Color.Black);

            navigator.CreateChildNode("группыОбъектов", scenePage.SelectedObjects.ToString(), arg, "5.1");

            ChangeProjectDataEvent?.Invoke();

        }
    }
}
