using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Geometry;
using ModelInterfaces;
using Scene.Events;
using System.Diagnostics;
using BaseModule.Console;
using BaseModule.CrossSection;
using BaseModule.Console.Events;
using ProjectInterfaces;
using SceneInterface;
using BaseModule.ToolStrips;
using BaseModule.Navigator;
using ModelControllerInterfaces;
using System.Threading;
using ModelInterfaces.MeshObjects;
using ModelInterfaces.GeometryObjects;
using System.Data.Odbc;
using System.ComponentModel;

namespace BaseModule
{
    public partial class BasePage : UserControl
    {
        public Action ChangeProjectDataEvent;
        public Action CreateProjectDataEvent;

        BaseToolStrRender BaseToolStrRender { get; set; } = new BaseToolStrRender();


        [Category("SelectToolStrip")]
        [Description("Иконка выбора узлов сцены")]
        public Image SelectNodeImage
        {
            get { return selectToolStrip.NodeImage; }
            set { selectToolStrip.NodeImage = value; }
        }
        [Category("SelectToolStrip")]
        [Description("Иконка выбора элементов сцены")]
        public Image SelectElementImage
        {
            get { return selectToolStrip.ElementsImage; }
            set { selectToolStrip.ElementsImage = value; }
        }
        [Category("SelectToolStrip")]
        [Description("Иконка выбора элементов сцены")]
        public Image SelectGeometryImage
        {
            get { return selectToolStrip.GeomsImage; }
            set { selectToolStrip.GeomsImage = value; }
        }
        [Category("SelectToolStrip")]
        [Description("Иконка выбора элементов сцены")]
        public Image SelectHelperImage
        {
            get { return selectToolStrip.HelperImage; }
            set { selectToolStrip.HelperImage = value; }
        }

        [Category("SelectToolStrip")]
        [Description("Выбранный объект сцены")]
        public ObjType SelectedObjects
        {
            get { return selectToolStrip.SelectObjectsType; }
            set { selectToolStrip.SelectObjectsType = value; }
        }

        [Category("General")]
        [Description("Задать верхний цвет градиента для кнопочного меню быстрого доступа")]
        public Color ToolStrTopColor 
        { 
            get { return BaseToolStrRender.TopColor; }
            set { BaseToolStrRender.TopColor = value; }
        }

        [Category("General")]
        [Description("Задать нижний цвет градиента для кнопочного меню быстрого доступа")]
        public Color ToolStrBottomColor 
        { 
            get { return BaseToolStrRender.BottomColor; }
            set { BaseToolStrRender.BottomColor = value; }
        }

        [Category("General")]
        [Description("Задать цвет выбора групп объектов")]
        public Color SelectionGroupColor { get; set; }


        [Category("ViewToolStrip")]
        [Description("Иконка установки в плоскость XY")]
        public Image PlaneXYImage
        {
            get { return viewToolStrip.PlaneXYImage; }
            set { viewToolStrip.PlaneXYImage = value; }
        }

        [Category("ViewToolStrip")]
        [Description("Иконка установки в плоскость XZ")]
        public Image PlaneXZImage
        {
            get { return viewToolStrip.PlaneXZImage; }
            set { viewToolStrip.PlaneXZImage = value; }
        }

        [Category("ViewToolStrip")]
        [Description("Иконка установки в плоскость YZ")]
        public Image PlaneYZImage
        {
            get { return viewToolStrip.PlaneYZImage; }
            set { viewToolStrip.PlaneYZImage = value; }
        }

        [Category("ViewToolStrip")]
        [Description("Иконка поворота по оси X")]
        public Image RotXImage
        {
            get { return viewToolStrip.RotXImage; }
            set { viewToolStrip.RotXImage = value; }
        }

        [Category("ViewToolStrip")]
        [Description("Иконка поворота по оси Y")]
        public Image RotYImage
        {
            get { return viewToolStrip.RotYImage; }
            set { viewToolStrip.RotYImage = value; }
        }

        [Category("ViewToolStrip")]
        [Description("Иконка поворота по оси Z")]
        public Image RotZImage
        {
            get { return viewToolStrip.RotZImage; }
            set { viewToolStrip.RotZImage = value; }
        }

        [Category("ViewToolStrip")]
        [Description("Иконка поворота на 90 по горизонтали")]
        public Image Rot90HorImage
        {
            get { return viewToolStrip.Rot90HorImage; }
            set { viewToolStrip.Rot90HorImage = value; }
        }

        [Category("ViewToolStrip")]
        [Description("Иконка поворота на 90 по вертикали")]
        public Image Rot90VerImage
        {
            get { return viewToolStrip.Rot90VerImage; }
            set { viewToolStrip.Rot90VerImage = value; }
        }

        [Category("ViewToolStrip")]
        [Description("Иконка вписывания всех объектов в экран")]
        public Image FitImage
        {
            get { return viewToolStrip.FitImage; }
            set { viewToolStrip.FitImage = value; }
        }


        [Category("displayToolStrip")]
        [Description("Иконка отображения граничного контура")]
        public Image BoundaryContoursImage
        {
            get { return displayToolStrip.BoundaryContoursImage; }
            set { displayToolStrip.BoundaryContoursImage = value; }
        }

        [Category("displayToolStrip")]
        [Description("Иконка отображения ребер элементов")]
        public Image ElementsFramesImage
        {
            get { return displayToolStrip.ElementsFramesImage; }
            set { displayToolStrip.ElementsFramesImage = value; }
        }

        [Category("displayToolStrip")]
        [Description("Иконка отображения поверхностей и ребер элементов")]
        public Image ElementsFramesAndSurfacesImage
        {
            get { return displayToolStrip.ElementsFramesAndSurfacesImage; }
            set { displayToolStrip.ElementsFramesAndSurfacesImage = value; }
        }

        [Category("displayToolStrip")]
        [Description("Иконка отображения поверхностей элементов")]
        public Image ElementsSurfacesImage
        {
            get { return displayToolStrip.ElementsSurfacesImage; }
            set { displayToolStrip.ElementsSurfacesImage = value; }
        }

        [Category("displayToolStrip")]
        [Description("Иконка отображения нормалей элементов")]
        public Image ElementsNormalsImage
        {
            get { return displayToolStrip.ElementsNormalsImage; }
            set { displayToolStrip.ElementsNormalsImage = value; }
        }

        [Category("displayToolStrip")]
        [Description("Иконка отображения базиса")]
        public Image ShowBasisImage
        {
            get { return displayToolStrip.ShowBasisImage; }
            set { displayToolStrip.ShowBasisImage = value; }
        }

        [Category("displayToolStrip")]
        [Description("Иконка отображения только открытых поверхностей")]
        public Image SurfaceNodesImage
        {
            get { return displayToolStrip.SurfaceNodesImage; }
            set { displayToolStrip.SurfaceNodesImage = value; }
        }

        [Category("displayToolStrip")]
        [Description("Иконка отображения всех поверхностей")]
        public Image VolumeNodesImage
        {
            get { return displayToolStrip.VolumeNodesImage; }
            set { displayToolStrip.VolumeNodesImage = value; }
        }

        [Category("displayToolStrip")]
        [Description("Иконка отображения названия проекта")]
        public Image TitleInfoImage
        {
            get { return displayToolStrip.TitleInfoImage; }
            set { displayToolStrip.TitleInfoImage = value; }
        }

        [Category("instrumentalToolStrip")]
        [Description("Иконка запуска измерения")]
        public Image MeasureImage
        {
            get { return instrumentToolStrip.MeasureImage; }
            set { instrumentToolStrip.MeasureImage = value; }
        }

        [Category("instrumentalToolStrip")]
        [Description("Иконка снимка экрана")]
        public Image MakePhotoImage
        {
            get { return instrumentToolStrip.MakePhotoImage; }
            set { instrumentToolStrip.MakePhotoImage = value; }
        }

        [Category("instrumentalToolStrip")]
        [Description("Иконка запуска построителя сечения")]
        public Image CrossSectionImage
        {
            get { return instrumentToolStrip.CrossSectionImage; }
            set { instrumentToolStrip.CrossSectionImage = value; }
        }

        public IModelController ModelController { get; set; }

        public IPresentersCreator PresentersCreator 
        { 
            get { return ModelController.PresentersCreator; }
        }  

        List<ToolStripMenuItem> menuItems = new List<ToolStripMenuItem>();

        public Keys PressedKey { get; set; }

        public IProjectData Project { get; set; }

        public BasePage()
        {
            InitializeComponent();
        }

        public void SceneInitialization()
        {
            sceneControl.Initialization();
            ClearAllDataOnScene();

            //sceneControl.FitObjectsToScreen();
            //sceneControl.DisplayObjects();
        }

        public void PresentAllModelObjectsToScene()
        {
            foreach (var item in Project.ModelData.ObjectData.ObjsTypes)
            {
                var presentor = CreateObjectsPresentor(item);
                if (presentor.Count() > 0)
                    CreateObjectsToScene(item.ToString(), presentor);
            }
        }  

        public IObjsPresenter CreateObjectsPresentor(ObjType objType)
        {
            IObjsPresenter presenter;

            switch (objType)
            {
                case ObjType.Узел:
                    presenter = PresentersCreator.CreatePointObjectsPresenter(Project.ModelData.ObjectData.NodeCollection);
                    break;
                case ObjType.Линия:
                    presenter = PresentersCreator.CreateLineObjectsPresenter(Project.ModelData.ObjectData.LineCollection);
                    break;
                case ObjType.Фигура2D:
                    presenter = PresentersCreator.CreateSurfaceObjectsPresenter(Project.ModelData.ObjectData.Fig2DCollection, false);
                    break;
                case ObjType.Фигура3D:
                    presenter = PresentersCreator.CreateSurfaceObjectsPresenter(Project.ModelData.ObjectData.Fig3DCollection, false);
                    break;
                case ObjType.Элемент1D:
                    presenter = PresentersCreator.CreateLineObjectsPresenter(Project.ModelData.ObjectData.E1DCollection);
                    break;
                case ObjType.Элемент2D:
                    presenter = PresentersCreator.CreateSurfaceObjectsPresenter(Project.ModelData.ObjectData.E2DCollection, false);
                    break;
                case ObjType.Элемент3D:
                    presenter = PresentersCreator.CreateSurfaceObjectsPresenter(Project.ModelData.ObjectData.E3DCollection, true);
                    break;
                default:
                    presenter = PresentersCreator.CreatePointObjectsPresenter(Project.ModelData.ObjectData.PointCollection);
                    break;
            }

            return presenter;
        }

        public void AddToolStrip(ToolStrip toolStrip)
        {
            toolStripContainer.TopToolStripPanel.Join(toolStrip);
        }

        public NavigatorControl NavigatorControl
        {
            get
            {
                return navigator;
            }
        }

        public ISceneControl SceneControl
        {
            get
            {
                return sceneControl;
            }
        }

        public ConsoleControl ConsoleControl
        {
            get
            {
                return consoleControl;
            }
        }

        public IEnumerable<ToolStripMenuItem> GetToolStripMenuItems()
        {
            foreach (var menuItem in menuItems)
            {
                yield return menuItem;
            }
        }

        public void AddToolStripMenuItem(ToolStripMenuItem toolStripMenuItem)
        {
            menuItems.Add(toolStripMenuItem);
        }

        public virtual void CreateMenuInterface()
        {
            AddToolStripMenuItem(AddViewInterface());
        }      

        private ToolStripMenuItem AddViewInterface()
        {

            var видToolStripMenuItem = new ToolStripMenuItem();
            var showNavigatorMenuItem = new ToolStripMenuItem();
            var showConsoleMenuItem = new ToolStripMenuItem();

            // 
            // видToolStripMenuItem
            // 
            видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            showNavigatorMenuItem,
            showConsoleMenuItem});
            видToolStripMenuItem.Name = "видToolStripMenuItem";
            видToolStripMenuItem.Text = "Вид";
            // 
            // showNavigatorMenuItem
            // 
            showNavigatorMenuItem.Name = "showNavigatorMenuItem";
            showNavigatorMenuItem.Text = "Навигатор";
            // 
            // showConsoleMenuItem
            // 
            showConsoleMenuItem.Name = "showConsoleMenuItem";
            showConsoleMenuItem.Text = "Консоль";

            // singup to show navigator click
            showNavigatorMenuItem.Click += (ar1, ar2) =>
            { splitContainer1.Panel1Collapsed = false; };

            // singup to show console click
            showConsoleMenuItem.Click += (ar1, ar2) =>
            { splitContainer2.Panel2Collapsed = false; };

            return видToolStripMenuItem;
        }

        public void SearchControl<T>(Control ctrl, List<T> controls) where T : Control
        {
            // Работаем только с элементами искомого типа   
            if (ctrl.GetType() == typeof(T))
            {
                controls.Add((T)ctrl);
            }
            // Проходим через элементы рекурсивно,   
            // чтобы не пропустить элементы,   
            //которые находятся в контейнерах   
            foreach (Control ctrlChild in ctrl.Controls)
            {
                SearchControl(ctrlChild, controls);
            }
        }

        public void CreateScreenShot(string fileName)
        {
            this.BringToFront();
            var bmpPicture = new Bitmap(sceneControl.Width, sceneControl.Height);
            var gr = Graphics.FromImage(bmpPicture);
            var pos = sceneControl.PointToScreen(Point.Empty);
            var size = new Size(sceneControl.Size.Width - 5, sceneControl.Size.Height - 5);
            gr.CopyFromScreen(pos, Point.Empty, size);

            bmpPicture.Save($@"{Project.Path}\{fileName}.bmp");
        }

        public void CreateObjectsToScene(string objsName, IObjsPresenter presenter)
        {
            if (!sceneControl.DrawInsideObjects & presenter.IsVolumeObjs)
            {
                var volPresenter = (IVolumeObjsPresenter)presenter;
                volPresenter.HideInsideSurfaces();
            }

            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");
            var edges = presenter.CreateEdgeFlags(inds.Item4);

            if (presenter.PresenterType == PresenterType.Surface)
            {
                if (PresentersCreator.GetView(objsName) == PresenterView.Line)
                    sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, ObjView.Lines);
                else if (PresentersCreator.GetView(objsName) == PresenterView.LineSurface)
                    sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, ObjView.LinesSurface);
                else
                    sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName, ObjView.Surface);
            }

            else if (presenter.PresenterType == PresenterType.Line)
            {
                sceneControl.CreateLineVBObjects(ptrs, coords, colors, normals, edges, objsName);
            }

            else
                sceneControl.CreatePointVBObjects(ptrs, coords, colors, normals, objsName);
        }

        public void SetBackColorToAllObjects()
        {
            foreach (var item in Project.ModelData.ObjectData.ObjsTypes)
            {
                foreach (var obj in Project.ModelData.ObjectData.GetObjects(item))
                    obj.SetBackColor();
                SetObjectsSceneColor(item);
            }

        }       

        public void PresentModelOnSelectToolStrip()
        {
            foreach (var item in Project.ModelData.ObjectData.ObjsTypes)
                selectToolStrip.AddObjectsType(item);

            selectToolStrip.AddObjectsType(ObjType.Объект);
            selectToolStrip.AddObjectsType(ObjType.Фигура);
            selectToolStrip.AddObjectsType(ObjType.Элемент);

            selectToolStrip.SelectObjectsType = ObjType.Объект;
        }

        public virtual void PresentProjectOnTree()
        {
            sceneControl.TitleText = Project.Name;

            navigator.SetProjectTitleInfo("названиеПроекта", "Название : " + Project.Name);
            navigator.SetProjectTitleInfo("путь", "Путь : " + Project.Path);
            navigator.SetProjectTitleInfo("сведения", "Сведения : " + Project.Comments);
            navigator.SetProjectTitleInfo("вид", "Вид: " + Project.TaskType);

            navigator.TreeView.BeginUpdate();

            navigator.TreeView.Nodes["объекты"].Expand();
            navigator.TreeView.Nodes["объекты"].Nodes.Clear();

            foreach (var objType in Project.ModelData.ObjectData.ObjsTypes)
            {
                var objs = Project.ModelData.ObjectData.GetObjects(objType);
                navigator.CreateChildNode("объекты", objType.ToString(), $"{objType} : {objs.Count()}", "4.1");
                navigator.ShowObjectsNode(objType.ToString());
            }

            navigator.TreeView.Nodes["группыОбъектов"].Expand();
            navigator.TreeView.Nodes["группыОбъектов"].Nodes.Clear();

            foreach (var group in Project.ModelData.GroupData)
            {
                navigator.CreateChildNode("группыОбъектов", group.ObjType.ToString(), group.GroupName, "5.1");
            }

            navigator.TreeView.EndUpdate();
        }

        public void ClearAllGeometryDataOnScene()
        {
            SceneControl.DeleteVBObjects(ObjType.Точка.ToString());
            SceneControl.DeleteVBObjects(ObjType.Линия.ToString());
            SceneControl.DeleteVBObjects(ObjType.Фигура2D.ToString());
            SceneControl.DeleteVBObjects(ObjType.Фигура3D.ToString());
        }

        public void ClearAllMeshDataOnScene()
        {
            SceneControl.DeleteVBObjects(ObjType.Узел.ToString());
            SceneControl.DeleteVBObjects(ObjType.Элемент1D.ToString());
            SceneControl.DeleteVBObjects(ObjType.Элемент2D.ToString());
            SceneControl.DeleteVBObjects(ObjType.Элемент3D.ToString());
        }


        public void ClearAllDataOnScene()
        {
            sceneControl.HideAllGeometryObjs();
            sceneControl.HideDisplayText2D();
            sceneControl.HideDisplayText3D();
            sceneControl.DeleteAllVBObjects();
        }

        private void SelectToolStrip_SelectObjectEvent(object arg1, SelectObjectEventArgs arg2)
        {
            SetBackColorToAllObjects();
            sceneControl.DisplayObjects();
        }

        private void SelectToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var selectStrip = (SelectToolStrip)sender;
            if (e.ClickedItem is ToolStripButton btn)
                if (!btn.Checked)
                {

                    if (e.ClickedItem.Tag.ToString() == "4")
                    {
                        var form = new Form() { Name = "selectForm", Text = "Выбрать", AutoSize = false, ShowIcon = false, TopMost = true };
                        
                        form.FormClosing += (s1, s2) => { btn.Checked = false; };
                        var selectionControl = new SelectionSet() { Dock = DockStyle.Fill };
                        selectionControl.SelectInDirection += SelectionControl_SelectInDirection;
                        selectionControl.SelectInPlain += SelectionControl_SelectInPlain;
                        selectionControl.SelectNodes += (s1, s2) =>
                        {
                            selectStrip.SelectObjectsType = ObjType.Узел;
                            var size = form.Size;
                            consoleControl.PrintInfo("Выберите два узла для направления или три для плоскости",Color.Black);
                        };
                        selectionControl.SelectElements += (s1, s2) =>
                        {
                            selectStrip.SelectObjectsType = ObjType.Элемент2D;
                            consoleControl.PrintInfo("Выберите плоский элемент \"2D\"", Color.Black);
                        };
                        form.ClientSize = selectionControl.Size;
                        form.Controls.Add(selectionControl);
                        form.Show();
                    }
                }
                else
                {
                    if (e.ClickedItem.Tag.ToString() == "4")
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
                //var selectHelper = new SelectionHelper(Project.ModelData.ObjectData);

                var objs = Project.ModelData.ObjectData.GetObjects(arg2.ObjsType).Where(x => x.MasterColor == sceneControl.SelectionColor).ToList();

                if (arg2.ObjsType == ObjType.Узел)
                {
                    if (objs.Count > 2)
                    {
                        var n1 = (INode)objs[0];
                        var n2 = (INode)objs[1];
                        var n3 = (INode)objs[2];

                        var plane = new Plane(n1.Position, n2.Position, n3.Position);
                        ModelController.SelectionHelper.SelectNodeInPlane(Project.ModelData.ObjectData,
                            plane, sceneControl.SelectionColor);
                        SetObjectsSceneColor(ObjType.Узел);
                    }
                }
                else
                {
                    if (objs.Count > 0)
                    {
                        var element = objs.Last();
                        ModelController.SelectionHelper.SelectE2DInPlane(Project.ModelData.ObjectData, 
                            arg2.Angle, element.Number, sceneControl.SelectionColor);
                        SetObjectsSceneColor(ObjType.Элемент2D);
                    }
                }

                sceneControl.DisplayObjects();

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
                //var selectHelper = new SelectionHelper(Project.ModelData.ObjectData);

                var objs = Project.ModelData.ObjectData.GetObjects(selectToolStrip.SelectObjectsType);
                var selObjs = objs.Where(x => x.MasterColor == sceneControl.SelectionColor).ToArray();
                if (selObjs.Length > 1)
                {
                    if (!arg2.Reverse)
                    {
                        ModelController.SelectionHelper.SelectNodeInDirection(Project.ModelData.ObjectData, 
                            arg2.Angle, selObjs[selObjs.Length - 2].Number, selObjs[selObjs.Length - 1].Number, sceneControl.SelectionColor);
                    }

                    else
                    {
                        ModelController.SelectionHelper.SelectNodeInDirection(Project.ModelData.ObjectData, 
                            arg2.Angle, selObjs[selObjs.Length - 1].Number, selObjs[selObjs.Length - 2].Number, sceneControl.SelectionColor);
                    }
                    SetObjectsSceneColor(selectToolStrip.SelectObjectsType);

                    sceneControl.DisplayObjects();
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
                        var form = new Form() { Name = "measureForm", Text = "Измерить", ShowIcon = false, TopMost = true };

                        form.FormClosed += (s1, s2) =>
                        {
                            btn.Checked = false;
                            sceneControl.HideAllGeometryObjs();
                            sceneControl.HideDisplayText3D();
                            sceneControl.DisplayObjects();
                        };

                        var measuringControl = new MeasuringSet() { Dock = DockStyle.Fill };
                        measuringControl.PreparingMeasureEvent += (ar) =>
                        {
                            selectToolStrip.SelectObjectsType = ar;
                            sceneControl.HideAllGeometryObjs();
                            sceneControl.HideDisplayText3D();
                            sceneControl.DisplayObjects();
                        };
                        measuringControl.MakeMeasureEvent += MeasuringControl_MakeMeasureEvent;
                        form.ClientSize = measuringControl.Size;
                        form.Controls.Add(measuringControl);

                        form.Show();
                    }

                    else if (e.ClickedItem.Tag.ToString() == "1")
                    {
                        var form = new Form() { Name = "CrossSectionForm", Text = "Построить сечение", ShowIcon = false, Size = new Size(268, 203), TopMost = true };

                        var crossSection = new CrossSectionControl() { Dock = DockStyle.Fill };
                        form.ClientSize = crossSection.Size;
                        form.Controls.Add(crossSection);

                        crossSection.RemoveCrossEvent += () =>
                        {
                            sceneControl.DeleteVBObjects("crossSection");
                            sceneControl.DisplayObjects();
                        };

                        crossSection.SelectNodesEvent += () => { selectToolStrip.SelectObjectsType = ObjType.Узел; };

                        crossSection.CreateCrossFromTextArgs += (ar1, ar2) =>
                        {
                            try
                            {
                                var elems3D = Project.ModelData.ObjectData.E3DCollection;
                                var surface = CreateSectionSurfaces(elems3D, ar2.point1, ar2.point2, ar2.point3);

                                PresentCrossSection(surface);

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
                                var objs = Project.ModelData.ObjectData.GetObjects(selectToolStrip.SelectObjectsType);
                                var selObjs = objs.Where(x => x.MasterColor == sceneControl.SelectionColor).ToArray();
                                if (selObjs.Length < 3)
                                {
                                    consoleControl.PrintInfo("Ошибка, выбрано неверное количество узлов", Color.Red);
                                    return;
                                }

                                var p0 = selObjs[0];
                                var p1 = selObjs[1];
                                var p2 = selObjs[2];

                                var elems3D = Project.ModelData.ObjectData.E3DCollection;

                                var surface = CreateSectionSurfaces(
                                    elems3D, p0.CalcCentr(),
                                    p1.CalcCentr(),
                                    p2.CalcCentr());

                                PresentCrossSection(surface);

                            }
                            catch (Exception ex)
                            {
                                ConsoleControl.PrintInfo(ex.Message, Color.Red);
                            }
                        };

                        form.FormClosed += (ar1, ar2) =>
                        {
                            btn.Checked = false;

                            sceneControl.DeleteVBObjects("crossSection");

                            if (sceneControl.GetVBObjsName().Count() == 0)
                            {
                                sceneControl.DeleteAllVBObjects();
                                foreach (var objsType in Project.ModelData.ObjectData.ObjsTypes)
                                {
                                    var presentor = CreateObjectsPresentor(objsType);
                                    CreateObjectsToScene(objsType.ToString(), presentor);
                                }

                            }
                            sceneControl.DisplayObjects();
                        };

                        form.Show();
                    }

                    else if (e.ClickedItem.Tag.ToString() == "2")
                    {
                        var scrShot = CreateScreenShot();
                        scrShot.Save(Project.Path + "\\screenShot.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                        consoleControl.PrintInfo($"Сделан снимок экрана {Project.Path}\\screenShot.bmp", Color.Black);
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

        public virtual void PresentCrossSection(ISurfaceFigure surface)
        {
            
            var presenter = ModelController.PresentersCreator.CreateSurfaceObjectsPresenter(new List<ISurfaceFigure>() { surface }, false);

            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");
            var edges = presenter.CreateEdgeFlags(inds.Item4);

            sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, "crossSection", ObjView.LinesSurface);
            sceneControl.DisplayObjects();
        }

        public ISurfaceFigure CreateSectionSurfaces(IEnumerable<IElement3D> elems3D, Point3D p0, Point3D p1, Point3D p2)
        {
            var plane = new Plane(p0, p1, p2);

            return ModelController.CrossSectionMaker.GetSectionSurfaces(elems3D, plane);
        }

        private async void MeasuringControl_MakeMeasureEvent(object arg1, MeasureEventArgs arg2)
        {
            try
            {
                switch (arg2.Kind)
                {
                    case MeasureKind.DistanceNodeToNode:
                        {
                            var objs = Project.ModelData.ObjectData.GetObjects(selectToolStrip.SelectObjectsType);
                            var selObjs = objs.Where(x => x.MasterColor == sceneControl.SelectionColor).ToList();

                            if (selObjs.Count() > 1)
                            {
                                var nodes = selObjs.Select(x => (INode)x);
                                var p0 = nodes.First();
                                var p1 = nodes.Last();
                                var line = new Segment3D(p0.Position, p1.Position);

                                consoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);

                                sceneControl.DisplayDistance(line);
                                sceneControl.DisplayObjects();
                            }
                            else consoleControl.PrintInfo("Узлы не выбраны", Color.Red);
                            break;
                        }
                    case MeasureKind.DistanceNodeToPlane:
                        {
                            var plane = CreateSurfaceAsync();
                            await plane;

                            var nodes = Project.ModelData.ObjectData.GetObjects(ObjType.Узел);
                            foreach (var _node in nodes)
                                _node.SetBackColor();

                            SetObjectsSceneColor(ObjType.Узел);

                            sceneControl.DisplayObjects();

                            var res = SelectNodeAsync();
                            await res;

                            if(res.Result is INode node)
                            {
                                var proj = node.Position.GetPointProectionOnPlane(plane.Result);
                                var line = new Segment3D(node.Position, proj);
                                consoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);
                                sceneControl.DisplayDistance(line);
                                sceneControl.DisplayObjects();
                            }

                            break;
                        }
                    case MeasureKind.Path:
                        await CreatePathAsync(); 
                        break;
                    case MeasureKind.Square:
                        {
                            var square = 0.0f;

                            var objs = Project.ModelData.ObjectData.GetObjects(selectToolStrip.SelectObjectsType);

                            var selObjs = objs.Where(x => x.MasterColor == sceneControl.SelectionColor);

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

                            var objs = Project.ModelData.ObjectData.GetObjects(selectToolStrip.SelectObjectsType);
                            var selObjs = objs.Where(x => x.MasterColor == sceneControl.SelectionColor);

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

        public async Task<List<INode>> CreatePathAsync()
        {
            var nodes = new List<INode>();

            var message = @"Начните строить путь нажав на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";

            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    ConsoleControl.PrintInfo("Операция отменена", Color.Black);
                }));
            });

            var actPointConfirm = new Func<Tuple<bool, object>>(() =>
            {
                Invoke(new Action(() =>
                {
                    ConsoleControl.PrintInfo($"Начато построение пути", Color.Green);
                }));
                return new Tuple<bool, object>(true, true);

            });

            var answer = await AsyncMethodContainer(actPointConfirm, actBreak, message);

            if (answer is bool)
                while (true)
                {
                    var res = SelectNodeAsync();
                    await res;

                    if (res.Result is INode node)
                    {
                        nodes.Add(node);
                        node.SetBackColor();
                    }
                    else break;

                    if (nodes.Count > 1)
                    {
                        var line = new Segment3D(nodes[nodes.Count - 1].Position, nodes[nodes.Count - 2].Position);
                        consoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);
                        sceneControl.DisplayDistance(line);
                        sceneControl.DisplayObjects();
                    }
                }
            return nodes;
        }


        public async Task<object> SelectNodeAsync()
        {
            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    ConsoleControl.PrintInfo("Операция отменена", Color.Black);
                }));
            });

            var message = @"Выберите узел и нажмите на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";

            var actPointConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var objs = Project.ModelData.ObjectData.NodeCollection;
                
                var selObjs = objs.Where(x => x.MasterColor == sceneControl.SelectionColor);

                if (selObjs.Count() == 0)
                {
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo("Не выбран ни один узел!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else if(selObjs.Count() > 1)
                {
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo("Выберите один узел!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    var node = (INode)selObjs.First();
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo($"Выбран узел {node.Number}", Color.Green);
                    }));
                    return new Tuple<bool, object>(true, node);
                }
            });

            var pointAwait = AsyncMethodContainer(actPointConfirm, actBreak, message);
            await pointAwait;
            return pointAwait.Result;
        }

        public async Task<Plane> CreateSurfaceAsync()
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
                var nodes = Project.ModelData.ObjectData.NodeCollection;
                var selObjs = nodes.Where(x => x.MasterColor == sceneControl.SelectionColor).ToArray();

                if (selObjs.Length < 3)
                {
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo("Выберите три узла!", Color.Orange);
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

        private Image CreateScreenShot()
        {
            this.BringToFront();
            var bmpPicture = new Bitmap(sceneControl.Width, sceneControl.Height);
            var gr = Graphics.FromImage(bmpPicture);
            var pos = sceneControl.PointToScreen(new Point(10, 10));
            var size = new Size(sceneControl.Size.Width - 10, sceneControl.Size.Height - 20);
            gr.CopyFromScreen(pos, Point.Empty, size);

            return bmpPicture;
        }

        private void ViewToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var btn = (ToolStripButton)e.ClickedItem;

            if (e.ClickedItem.Tag.ToString() == "0")
            {
                sceneControl.PlaneObjs(ViewPlane.XY);
            }
            else if (e.ClickedItem.Tag.ToString() == "1")
            {
                sceneControl.PlaneObjs(ViewPlane.XZ);
            }
            else if (e.ClickedItem.Tag.ToString() == "2")
            {
                sceneControl.PlaneObjs(ViewPlane.YZ);
            }
            else if (e.ClickedItem.Tag.ToString() == "3")
            {
                if (!btn.Checked)
                    sceneControl.RotationAxis = ViewAxis.X;
                else
                    sceneControl.RotationAxis = ViewAxis.XYZ;

            }
            else if (e.ClickedItem.Tag.ToString() == "4")
            {
                if (!btn.Checked)
                    sceneControl.RotationAxis = ViewAxis.Y;
                else
                    sceneControl.RotationAxis = ViewAxis.XYZ;

            }
            else if (e.ClickedItem.Tag.ToString() == "5")
            {
                if (!btn.Checked)
                    sceneControl.RotationAxis = ViewAxis.Z;
                else
                    sceneControl.RotationAxis = ViewAxis.XYZ;

            }
            else if (e.ClickedItem.Tag.ToString() == "6")
            {
                sceneControl.RotationAxis = ViewAxis.Y;
                sceneControl.RotationAngle = 90;
                sceneControl.RotateObjs();
                sceneControl.RotationAxis = ViewAxis.XYZ;
                sceneControl.RotationAngle = 2.5f;
            }
            else if (e.ClickedItem.Tag.ToString() == "7")
            {
                sceneControl.RotationAxis = ViewAxis.X;
                sceneControl.RotationAngle = 90;
                sceneControl.RotateObjs();
                sceneControl.RotationAxis = ViewAxis.XYZ;
                sceneControl.RotationAngle = 2.5f;
            }
            else if (e.ClickedItem.Tag.ToString() == "8")
            {
                sceneControl.FitObjectsToScreen();
            }
            sceneControl.DisplayObjects();
        }

        private void DisplayToolStrip_ItemClick(object arg1, ToolStripItemClickedEventArgs arg2)
        {
            try
            {
                if (arg2.ClickedItem.Tag.ToString() == "0")
                {
                    var btn = (ToolStripButton)arg2.ClickedItem;

                    if (!btn.Checked)
                        sceneControl.DisplayTitle();
                    else sceneControl.HideTitle();
                }
                else if (arg2.ClickedItem.Tag.ToString() == "1")
                {
                    sceneControl.DrawInsideObjects = true;
                    var vbobj = sceneControl.FindVBObj("Элемент3D");
                    if (vbobj != null)
                    {
                        var viewMode = vbobj.ViewMode;

                        sceneControl.DeleteVBObjects("Элемент3D");

                        foreach (var item in Project.ModelData.ObjectData.E3DCollection)
                            if (item.ViewState)
                                item.ViewState = true;

                        var presentor = CreateObjectsPresentor(ObjType.Элемент3D);
                        CreateObjectsToScene("Элемент3D", presentor);
                        sceneControl.ChangeViewModeVBObjects("Элемент3D", viewMode);
                    }
    
                    consoleControl.PrintInfo("Показаны все объекты", Color.Black);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "2")
                {
                    sceneControl.DrawInsideObjects = false;

                    var vbobj = sceneControl.FindVBObj("Элемент3D");
                    if (vbobj != null)
                    {
                        var viewMode = vbobj.ViewMode;
                        sceneControl.DeleteVBObjects("Элемент3D");

                        var presentor = CreateObjectsPresentor(ObjType.Элемент3D);
                        CreateObjectsToScene("Элемент3D", presentor);
                        sceneControl.ChangeViewModeVBObjects("Элемент3D", viewMode);
                    }
  
                    consoleControl.PrintInfo("Скрыты внутренние объекты", Color.Black);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "3")
                {
                    foreach (var objsType in sceneControl.GetVBObjsName())
                        sceneControl.ChangeViewModeVBObjects(objsType, ObjView.LinesSurface);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "4")
                {

                    foreach (var objsType in sceneControl.GetVBObjsName())
                        sceneControl.ChangeViewModeVBObjects(objsType, ObjView.Lines);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "5")
                {
                    foreach (var objsType in sceneControl.GetVBObjsName())
                        sceneControl.ChangeViewModeVBObjects(objsType, ObjView.Surface);
                }
                else if(arg2.ClickedItem.Tag.ToString() == "6")
                {
                    var btn = (ToolStripButton)arg2.ClickedItem;
                    if (!btn.Checked)
                        SceneControl.DisplayBasis = true;
                    else SceneControl.DisplayBasis = false;
                }
                else if (arg2.ClickedItem.Tag.ToString() == "7")
                {
                    var btn = (ToolStripButton)arg2.ClickedItem;
                    if (!btn.Checked)
                    {
                        var surfElems = Project.ModelData.ObjectData.GetAllElements().Select(x => (ISurfaceElement)x);
                        var elemsNormals = ModelController.NormalCalculator.CalcElemsNormals(surfElems);
    
                        var linePresenter = PresentersCreator.CreateLineObjectsPresenter(elemsNormals);

                        CreateObjectsToScene("Normals", linePresenter);
                    }
                    else sceneControl.DeleteVBObjects("Normals");
                }
                else if (arg2.ClickedItem.Tag.ToString() == "8")
                {
                    var btn = (ToolStripButton)arg2.ClickedItem;
                    if (!btn.Checked)
                    {
                        var surfElems = Project.ModelData.ObjectData.GetAllElements().Select(x => (ISurfaceElement)x);
                        var linesNodes = ModelController.BoundaryEdgesFinder.Find(surfElems);
                        var edges = ModelController.BoundaryEdgesFinder.CreateBoundaryEdges(linesNodes, Project.ModelData);
                        var linePresenter = PresentersCreator.CreateLineObjectsPresenter(edges);

                        CreateObjectsToScene("Boundary", linePresenter);
                    }
                    else sceneControl.DeleteVBObjects("Boundary");
                }
                sceneControl.DisplayObjects();
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
                sceneControl.DisplayText2D(cmdMessage, Color.Black, new Point2D(10, 10));
                sceneControl.DisplayObjects();
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

            sceneControl.HideDisplayText2D();
            sceneControl.DisplayObjects();

            PressedKey = Keys.None;
            return resObject;
        }

        public virtual void sceneControl_CreateMeshGroupEvent(object sender, EventArgs arg)
        {
            if(selectToolStrip.SelectObjectsType == ObjType.Объект |
                selectToolStrip.SelectObjectsType == ObjType.Фигура |
                selectToolStrip.SelectObjectsType == ObjType.Элемент)
            {
                consoleControl.PrintInfo("Выберите объекты одного типа", Color.Red);
                return;
            }

            var selObjs = Project.ModelData.ObjectData.GetObjects(selectToolStrip.SelectObjectsType).
                Where(x =>x.MasterColor == sceneControl.SelectionColor);


            if (selObjs.Count() > 0)
            {
                var grps = Project.ModelData.GroupData.FindMany(selectToolStrip.SelectObjectsType);

                var counter = 1;
                var name = $"{selectToolStrip.SelectObjectsType}_{grps.Count() + counter}";
        
                while(true)
                {
                    if (Project.ModelData.GroupData.Find(name) != null)
                    {
                        counter++;
                        name = $"{selectToolStrip.SelectObjectsType}_{grps.Count() + counter}";
                    }
                    else break;
                }

                var group = Project.ModelData.GroupData.Create(name, selectToolStrip.SelectObjectsType);
               
                group.AddRange(selObjs);
                Project.ModelData.GroupData.Add(group);

                ChangeProjectDataEvent?.Invoke();

                consoleControl.PrintInfo(string.Format("Создана новая группа {0}", name), Color.Black);

                foreach (var selObj in selObjs)
                    selObj.SetBackColor();

                SetObjectsSceneColor(selectToolStrip.SelectObjectsType);

                sceneControl.DisplayObjects();

                navigator.CreateChildNode("группыОбъектов", group.ObjType.ToString(), group.GroupName, "5.1");
            }
        }

        public virtual void sceneControl_DeleteSelectionEvent(object sender, EventArgs arg)
        {

            var selObjs = Project.ModelData.ObjectData.GetObjects(selectToolStrip.SelectObjectsType).
                Where(x => x.MasterColor == sceneControl.SelectionColor);

            foreach (var selObj in selObjs)
                selObj.ExistState = false;

            Project.ModelData.ObjectData.ClearNotExisted();
            Project.ModelData.GroupData.ClearNotExisted();
            Project.TaskData?.ClearNotExisted(Project.ModelData.GroupData);

            sceneControl.DeleteAllVBObjects();

            PresentAllModelObjectsToScene();


            sceneControl.DisplayObjects();

            PresentProjectOnTree();
        }

        private void sceneControl_InfoObjectsEvent(object sender, EventArgs arg)
        {
            try
            {
                var objs = Project.ModelData.ObjectData.GetObjects(selectToolStrip.SelectObjectsType);
                var selObjs = objs.Where(x => x.MasterColor == sceneControl.SelectionColor);

                consoleControl.PrintInfo($"Выбраны {selectToolStrip.SelectObjectsType} {selObjs.Count()}", Color.Black);

                var numbers = string.Join("\n", selObjs.Select(x => x.ToString()).ToArray());
                consoleControl.PrintInfo(numbers, Color.Black);
            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void sceneControl_MessageEvent(object arg1, MessageEventArgs arg2)
        {
            consoleControl.PrintInfo(arg2.Message, Color.Red);
        }

        private void sceneControl_SelectObjectsEvent(object arg1, SelectObjectsEventArgs arg2)
        {
            var selections = SearchObjects(selectToolStrip.SelectObjectsType, arg2.SelectionBox);

            if(selections.Count > 0)
            {
                SelectObjects(arg2.IsSelected, arg2.IsSorted, selections);

                if (selectToolStrip.SelectObjectsType == ObjType.Объект)
                {
                    var types = Project.ModelData.ObjectData.ObjsTypes;
                    foreach (var type in types)
                        SetObjectsSceneColor(type);
                }
                else if (selectToolStrip.SelectObjectsType == ObjType.Элемент)
                {
                    SetObjectsSceneColor(ObjType.Элемент1D);
                    SetObjectsSceneColor(ObjType.Элемент2D);
                    SetObjectsSceneColor(ObjType.Элемент3D);
                }
                else if (selectToolStrip.SelectObjectsType == ObjType.Фигура)
                {
                    SetObjectsSceneColor(ObjType.Фигура2D);
                    SetObjectsSceneColor(ObjType.Фигура3D);
                }
                else
                    SetObjectsSceneColor(selectToolStrip.SelectObjectsType);

                sceneControl.DisplayObjects();
            }
        }

        public void SetObjectsSceneColor(ObjType objsType)
        {
            var objName = objsType.ToString();
            var vboObjs = sceneControl.FindVBObj(objName);

            if (vboObjs != null)
            {
                var objsPresenter = CreateObjectsPresentor(objsType);

                if(objsPresenter.Count() > 0)
                {
                    var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                    vboObjs.PointsColors = colors;
                }
            }
        }

        private void SelectObjects(bool isSelected, bool isSorted, List<IModelObject> selections)
        {
            if (isSorted & selections.Count > 0)
            {
                var camera = sceneControl.Camera;

                var near = selections.OrderByDescending(x => camera.GetSceenCoord(x.CalcCentr())._z).First();
                if (isSelected)
                {
                    near.MasterColor = sceneControl.SelectionColor;
                }
                else
                    near.SetBackColor();
            }
            else
            {
                foreach (var obj in selections)
                    if (isSelected)
                    {
                        obj.MasterColor = sceneControl.SelectionColor;
                    }

                    else
                        obj.SetBackColor();
            }
        }

        private void sceneControl_ShowAllHiddenObjectsEvent(object sender, EventArgs arg)
        {
            ShowAllObjects();

            foreach (var item in Project.ModelData.ObjectData.ObjsTypes)
                navigator.ShowObjectsNode(item.ToString());

            sceneControl.DisplayObjects();
        }

        private void sceneControl_HideSelectedObjectsEvent(object sender, EventArgs arg)
        {
            var selObjs = Project.ModelData.ObjectData.GetObjects(selectToolStrip.SelectObjectsType).
                Where(x => x.MasterColor == sceneControl.SelectionColor);

            foreach (var selObj in selObjs)
                selObj.ViewState = false;

            if (selectToolStrip.SelectObjectsType == ObjType.Объект)
            {
                sceneControl.DeleteAllVBObjects();
                PresentAllModelObjectsToScene();
            }
            else if (selectToolStrip.SelectObjectsType == ObjType.Элемент)
            {
                sceneControl.DeleteVBObjects(ObjType.Элемент1D.ToString());
                CreateObjectsToScene(ObjType.Элемент1D.ToString(), CreateObjectsPresentor(ObjType.Элемент1D));
                sceneControl.DeleteVBObjects(ObjType.Элемент2D.ToString());
                CreateObjectsToScene(ObjType.Элемент2D.ToString(), CreateObjectsPresentor(ObjType.Элемент2D));
                sceneControl.DeleteVBObjects(ObjType.Элемент3D.ToString());
                CreateObjectsToScene(ObjType.Элемент3D.ToString(), CreateObjectsPresentor(ObjType.Элемент3D));
            }
            else if (selectToolStrip.SelectObjectsType == ObjType.Фигура)
            {
                sceneControl.DeleteVBObjects(ObjType.Фигура2D.ToString());
                CreateObjectsToScene(ObjType.Фигура2D.ToString(), CreateObjectsPresentor(ObjType.Фигура2D));
                sceneControl.DeleteVBObjects(ObjType.Фигура3D.ToString());
                CreateObjectsToScene(ObjType.Фигура3D.ToString(), CreateObjectsPresentor(ObjType.Фигура3D));
            }
            else
            {
                var strObjType = selectToolStrip.SelectObjectsType.ToString();
                sceneControl.DeleteVBObjects(strObjType);
                CreateObjectsToScene(strObjType, CreateObjectsPresentor(selectToolStrip.SelectObjectsType));
            }


            sceneControl.DisplayObjects();
        }

        private void sceneControl_SetBackColorEvent(object sender, EventArgs arg)
        {
            SetBackColorToAllObjects();
            sceneControl.HideDisplayText3D();
            sceneControl.DisplayObjects();
        }


        public virtual void UnBlockInterface(bool status)
        {
            throw new Exception("Функция разблокировки не реализована!");  
        }

        private void BasePage_Load(object sender, EventArgs e)
        {
            navigator.NavigatorPanelCollapseEvent += () => { splitContainer1.Panel1Collapsed = true; };
            sceneControl.SceneControlExpandEvent += () =>
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer2.Panel2Collapsed = true;
            };

            sceneControl.SceneControlFoldEvent += () =>
            {
                splitContainer1.Panel1Collapsed = false;
                splitContainer2.Panel2Collapsed = false;
            };
            consoleControl.ConsolePanelCollapseEvent += () => { splitContainer2.Panel2Collapsed = true; };

            //displayToolStrip.Location = new Point(0, 0);
            //instrumentalToolStrip.Location = new Point(0, 0);
            //selectToolStrip.Location = new Point(0, 0);
            //viewToolStrip.Location = new Point(0, 0);
            //instrumentalToolStrip.Location = new Point(0, 0);

            //this.toolStripContainer.TopToolStripPanel.Controls.Add(this.viewToolStrip);
            //this.toolStripContainer.TopToolStripPanel.Controls.Add(this.instrumentalToolStrip);
            //this.toolStripContainer.TopToolStripPanel.Controls.Add(this.displayToolStrip);
            //this.toolStripContainer.TopToolStripPanel.Controls.Add(this.selectToolStrip);

            displayToolStrip.Renderer = BaseToolStrRender;
            selectToolStrip.Renderer = BaseToolStrRender;
            viewToolStrip.Renderer = BaseToolStrRender;
            instrumentToolStrip.Renderer = BaseToolStrRender;
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
                    var freeNodes = ModelController.FreeNodesFinder.Find(Project.ModelData.ObjectData);

                    Invoke(new Action(() =>
                    {
                        consoleControl.PrintInfo($"Найдено {freeNodes.Count()} свободных узлов", Color.Black);

                        HideAllObjects();

                        foreach (var freeNode in freeNodes)
                            Project.ModelData.ObjectData.Find(ObjType.Узел, freeNode).ViewState = true;

                        var objsTypeStr = ObjType.Узел.ToString();
                        sceneControl.DeleteVBObjects(objsTypeStr);
                        CreateObjectsToScene(objsTypeStr, CreateObjectsPresentor(ObjType.Узел));

                        sceneControl.DisplayObjects();
                    }));
                }
                else if (arg2 is FindObjectEventArgs findObjectEventArgs)
                {
                    Invoke(new Action(() =>
                    {
                        var obj = Project.ModelData.ObjectData.Find(findObjectEventArgs.ObjsType, (int)findObjectEventArgs.Number);

                        if (obj != null)
                        {
                            foreach (var item in Project.ModelData.ObjectData.GetObjects(ObjType.Объект))
                                item.ViewState = false;
                            obj.ViewState = true;
                            ClearAllDataOnScene();
                            PresentAllModelObjectsToScene();
                            sceneControl.DisplayObjects();
                        }
                    }));
                }
                else if (arg2 is ModelFindCoincidentsNodesEventArgs coincidentNodesEventArgs)
                {
                    Invoke(new Action(() => { consoleControl.PrintInfo("Выполняется поиск совпадающих узлов сетки...", Color.Black); }));

                    ModelController.CoincidentObjectsFinder.ProgressEvent += (ar1, ar2) =>
                    {
                        Invoke(new Action(() => { consoleControl.PrintInfo(string.Format("{0:00}%", ar2 * 100), Color.Black); }));
                    };

                    var nodes = Project.ModelData.ObjectData.NodeCollection;
                    var coincidentNodes = ModelController.CoincidentObjectsFinder.Find(
                        nodes.ToList(), 0.001f);

                    Invoke(new Action(() => { consoleControl.PrintInfo($"Найдено {coincidentNodes.Where(x => x.Count > 2).Count()} совпадений", Color.Black); }));
                    Invoke(new Action(() =>
                    {
                        foreach (var objType in Project.ModelData.ObjectData.ObjsTypes)
                            CreateObjectsToScene(objType.ToString(), CreateObjectsPresentor(objType));
                        sceneControl.DisplayObjects();
                    }));
                    var actConfirm = new Func<Tuple<bool, object>>(() =>
                    {
                        var mergedNodes = ModelController.ObjectsMerger.Merge(coincidentNodes, nodes.ToList());

                        Project.ModelData.ObjectData.NodeCollection.Clear();
                        Project.ModelData.ObjectData.NodeCollection.AddRange(mergedNodes);

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

        

        public List<IModelObject> SearchObjects(ObjType objType, RectangleBox selectionBox)
        {
            var camera = sceneControl.Camera;
            var selections = new List<IModelObject>();

            foreach (var item in Project.ModelData.ObjectData.GetObjects(objType))
            {
                if (item.ViewState)
                {
                    var scrPoints = new Point2D[item.NumberOfPoints];
                    var scnPoints = new Point3D[item.NumberOfPoints];

                    var pointCounter = 0;
                    foreach (var point in item.GetCoordinates())
                    {
                        var scnPoint = camera.GetSceenCoord(point);
                        scnPoints[pointCounter] = scnPoint;

                        var scrPoint = camera.GetScreenCoord(scnPoint);
                        scrPoints[pointCounter] = scrPoint;

                        pointCounter++;
                    }

                    if (selectionBox.IsPointsInside(scrPoints))
                        selections.Add(item);
                }
            }
            return selections;
        }

        private void navigator_DelGroupEvent(int obj)
        {
            var group = Project.ModelData.GroupData[obj];
            Project.ModelData.GroupData.Remove(group);

            Project.TaskData?.ClearNotExisted(Project.ModelData.GroupData);

            PresentProjectOnTree();
            ChangeProjectDataEvent?.Invoke();
        }

        private void navigator_DelAllGroupsEvent()
        {
            Project.ModelData.GroupData.Clear();
            Project.TaskData?.Clear();
            PresentProjectOnTree();
            ChangeProjectDataEvent?.Invoke();
        }

        private void navigator_DelObjectsEvent(string objs)
        {
            var objType = selectToolStrip.GetObjType(objs);
 
            Project.ModelData.ObjectData.Clear(objType);
            Project.ModelData.GroupData.ClearNotExisted();
            Project.TaskData?.ClearNotExisted(Project.ModelData.GroupData);

            sceneControl.DeleteAllVBObjects();
            PresentAllModelObjectsToScene();

            PresentProjectOnTree();
            sceneControl.DisplayObjects();

        }

        private async void navigator_EditGroupEvent(int obj)
        {
            var group = Project.ModelData.GroupData[obj];
            selectToolStrip.SelectObjectsType = group.ObjType;

            foreach (var iobj in group)
                iobj.MasterColor = sceneControl.SelectionColor;

            SetObjectsSceneColor(selectToolStrip.SelectObjectsType);

            sceneControl.DisplayObjects();

            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var objs = Project.ModelData.ObjectData.GetObjects(selectToolStrip.SelectObjectsType);
                var selObj = objs.Where(x => x.MasterColor == sceneControl.SelectionColor);

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
            foreach (var group in Project.ModelData.GroupData)
            {
                foreach (var iobj in group)
                {
                    iobj.ViewState = false;
                }
            }
            sceneControl.DeleteAllVBObjects();
            PresentAllModelObjectsToScene();

            sceneControl.DisplayObjects();
        }

        private void navigator_HideAllObjectsEvent()
        {
            HideAllObjects();

            sceneControl.DisplayObjects();
        }

        private void HideAllObjects()
        {
            try
            {
                foreach (var item in Project.ModelData.ObjectData.ObjsTypes)
                {
                    foreach (var modelObject in Project.ModelData.ObjectData.GetObjects(item))
                        modelObject.ViewState = false;
                }
                sceneControl.DeleteAllVBObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void ShowAllObjects()
        {
            try
            {
                sceneControl.DeleteAllVBObjects();

                foreach (var item in Project.ModelData.ObjectData.ObjsTypes)
                {
                    foreach (var modelObject in Project.ModelData.ObjectData.GetObjects(item))
                        modelObject.ViewState = true;                  
                }

                PresentAllModelObjectsToScene();

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
                var group = Project.ModelData.GroupData[obj];

                foreach (var iobj in group)
                    iobj.ViewState = false;

                var vbobj = sceneControl.FindVBObj(group.ObjType.ToString());
                if (vbobj == null)
                    throw new Exception($"Объект {group.ObjType} не загружен на сцену!");
                var viewMode = vbobj.ViewMode;

                sceneControl.DeleteVBObjects(group.ObjType.ToString());
                CreateObjectsToScene(group.ObjType.ToString(), CreateObjectsPresentor(group.ObjType));
                sceneControl.ChangeViewModeVBObjects(group.ObjType.ToString(), viewMode);

                sceneControl.DisplayObjects();

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
                var objType = selectToolStrip.GetObjType(obj);

                foreach (var modelObject in Project.ModelData.ObjectData.GetObjects(objType))
                    modelObject.ViewState = false;

                sceneControl.DeleteVBObjects(obj);

                CreateObjectsToScene(obj, CreateObjectsPresentor(objType));
                sceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowAllObjectsEvent()
        {
            ShowAllObjects();

            sceneControl.DisplayObjects();
        }

        private void navigator_ShowObjectsEvent(string obj)
        {
            try
            {
                var objType = selectToolStrip.GetObjType(obj);

                foreach (var modelObject in Project.ModelData.ObjectData.GetObjects(objType))
                    modelObject.ViewState = true;

                sceneControl.DeleteVBObjects(obj);

                CreateObjectsToScene(obj, CreateObjectsPresentor(objType));

                sceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_InfoGroupEvent(int obj)
        {
            var group = Project.ModelData.GroupData[obj];
            consoleControl.PrintInfo(group.ToString(), Color.Black);
        }

        private void navigator_RenameGroup(string newName, string oldName)
        {
            var gr = Project.ModelData.GroupData.Find(oldName);
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
                SetBackColorToAllObjects();

                var group = Project.ModelData.GroupData.Find(obj);

                foreach (var iobj in group)
                    iobj.MasterColor = SelectionGroupColor;

                SetObjectsSceneColor(group.ObjType);

                sceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowAllGroupsEvent()
        {
            foreach (var group in Project.ModelData.GroupData)
            {
                foreach (var iobj in group)
                {
                    iobj.ViewState = true;
                }
            }

            sceneControl.DeleteAllVBObjects();

            PresentAllModelObjectsToScene();

            sceneControl.DisplayObjects();
        }

        private void navigator_ShowGroupEvent(int obj)
        {
            var group = Project.ModelData.GroupData[obj];

            foreach (var iobj in group)
                iobj.ViewState = true;

            var strObjType = group.ObjType.ToString();
            sceneControl.DeleteVBObjects(strObjType);
            CreateObjectsToScene(strObjType, CreateObjectsPresentor(group.ObjType));
            sceneControl.DisplayObjects();
        }

        private void navigator_ChangeViewModeEventHandler(string objs, ViewRegime viewRegime)
        {
  
            switch (viewRegime)
            {
                case ViewRegime.ribbers:
                    sceneControl.ChangeViewModeVBObjects(objs, ObjView.Lines);
                    PresentersCreator.SetView(objs, PresenterView.Line);
                    break;
                case ViewRegime.surfaces:
                    sceneControl.ChangeViewModeVBObjects(objs, ObjView.Surface);
                    PresentersCreator.SetView(objs, PresenterView.Surface);
                    break;
                case ViewRegime.ribbersSurfaces:
                    sceneControl.ChangeViewModeVBObjects(objs, ObjView.LinesSurface);
                    PresentersCreator.SetView(objs, PresenterView.LineSurface);
                    break;
                default:
                    break;
            }

            sceneControl.DisplayObjects();
        }

        private void navigator_ShowGroupWithNodesEvent(int obj)
        {
            var group = Project.ModelData.GroupData[obj];

            foreach (var iobj in group)
            {
                var elem = (IElement)iobj;
                elem.ViewState = true;

                foreach (var node in elem.GetVertexes())
                    node.ViewState = true;

            }


            sceneControl.DeleteVBObjects(ObjType.Узел.ToString());
            CreateObjectsToScene(ObjType.Узел.ToString(), CreateObjectsPresentor(ObjType.Узел));

            var strObjType = group.ObjType.ToString();
            sceneControl.DeleteVBObjects(strObjType);
            CreateObjectsToScene(strObjType, CreateObjectsPresentor(group.ObjType));

            sceneControl.DisplayObjects();
        }

        private void splitContainer1_Paint(object sender, PaintEventArgs e)
        {
            var locRect = new Point(splitContainer1.Panel1.Width-1, splitContainer2.Panel1.Height / 2);
            var rect = new Rectangle(locRect, new Size(5, 50));
            e.Graphics.DrawRectangle(Pens.DarkGray, rect);

            var x = splitContainer1.Panel1.Width;
            var y = splitContainer2.Panel1.Height / 2;

            var points = new Point[]
            {
                        new Point(x + 3, y + 24),
                        new Point(x + 0, y + 27),
                        new Point(x + 3, y + 31)
            };
            e.Graphics.FillPolygon(Brushes.Black, points);

        }

        private void splitContainer1_MouseClick(object sender, MouseEventArgs e)
        {
            var x = splitContainer1.Panel1.Width;
            var y = splitContainer2.Panel1.Height / 2;
            
            if (e.Location.X > x & e.Location.X < x + splitContainer1.SplitterWidth &&
                e.Location.Y > y & e.Location.Y < y + 50)
            {
                splitContainer1.IsSplitterFixed = true;
                splitContainer1.SplitterDistance -= 100;
            }
            else
                splitContainer1.IsSplitterFixed = false;
        }

        private void splitContainer2_Paint(object sender, PaintEventArgs e)
        {
            var locRect = new Point(splitContainer2.Panel1.Width / 2, splitContainer2.Panel1.Height - 1);
            var rect = new Rectangle(locRect, new Size(50, 5));
            e.Graphics.DrawRectangle(Pens.DarkGray, rect);

            var x = splitContainer2.Panel1.Width / 2;
            var y = splitContainer2.Panel1.Height;

            var points = new Point[]
            {
                        new Point(x + 21, y),
                        new Point(x + 27, y),
                        new Point(x + 24, y + 3)
            };
            e.Graphics.FillPolygon(Brushes.Black, points);
        }

        private void splitContainer2_MouseClick(object sender, MouseEventArgs e)
        {
            var x = splitContainer2.Panel1.Width / 2;
            var y = splitContainer2.Panel1.Height;

            if (e.Location.X > x & e.Location.X < x + 50 &&
                e.Location.Y > y - 3 & e.Location.Y < y + 3)
            {
                splitContainer2.IsSplitterFixed = true;
                splitContainer2.SplitterDistance += 50;
            }
            else
                splitContainer2.IsSplitterFixed = false;
        }

        private void sceneControl_Load(object sender, EventArgs e)
        {
            SceneInitialization();
            CreateMenuInterface();
            PresentAllModelObjectsToScene();
            PresentProjectOnTree();
            PresentModelOnSelectToolStrip();
            sceneControl.FitObjectsToScreen();
        }
    }
}
