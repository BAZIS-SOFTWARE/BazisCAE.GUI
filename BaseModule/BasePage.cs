using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project;
using Model;
using Geometry;
using Model.Interfaces;
using System.IO;
using ModelController.MeshObjsUtility;
using Model.GroupsData;
using Scene.Events;
using System.Diagnostics;
using BaseModule.Console;
using BaseModule.CrossSection;
using Project.IO;
using Model.IO;
using BaseModule.Properties;
using BaseModule.Console.Events;
using Project.Interfaces;
using Project.TasksData;
using SceneInterface;
using BaseModule.ToolStrips;
using BaseModule.Navigator;
using Model.ObjectsFinders;
using ModelControllerInterfaces;
using ModelController.ModelScenePresentator;
using ModelController.ModelScenePresentator.GlObjsPresenters;
using Scene;

namespace BaseModule
{
    public partial class BasePage : UserControl
    {
        private ProjectData project;
        public Action<object, ProjectData> ChangeProjectDataEvent;

        public IModelController ModelController { get; set; } = new ModelController.ModelController();

        public IModelScenePresenter ModelPresenter { get; set; }

        List<ToolStripMenuItem> menuItems = new List<ToolStripMenuItem>();

        public Keys PressedKey { get; set; }

        public ProjectData Project
        {
            get { return project; }
            set { project = value; }
        }

        public Color SelectionGroupColor { get; set; }


        public string SelectedObjects 
        {
            get { return selectToolStrip.SelectObjectsType; }
            set { selectToolStrip.SelectObjectsType = value; }
        }

        public BasePage()
        {
            InitializeComponent();
        }

        public void SceneInitialization()
        {
            sceneExControl.BringToFront();
            SceneControl.Initialization();

            ClearAllDataOnScene();

            ModelPresenter = new ModelScenePresentator(Project.Model.ObjectData);

            foreach (var item in ModelPresenter)
                PresentObjectsToScene(item.Key,item.Value);

            SceneControl.FitObjectsToScreen();
            SceneControl.DisplayObjects();
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

        SceneControl SceneControl
        {
            get
            {
                return sceneExControl.SceneControl;
            }
        }

        public ISceneControl SceneInterface
        {
            get
            {
                return sceneExControl.SceneControl;
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
            AddToolStripMenuItem(AddFileInterface());
        }

        private ToolStripMenuItem AddFileInterface()
        {

            var файлToolStripMenuItem = new ToolStripMenuItem();
            var создатьToolStripMenuItem = new ToolStripMenuItem();
            var открытьToolStripMenuItem = new ToolStripMenuItem();
            var toolStripSeparator = new ToolStripSeparator();
            var сохранитьToolStripMenuItem = new ToolStripMenuItem();
            var сохранитькакToolStripMenuItem = new ToolStripMenuItem();
            var toolStripSeparator1 = new ToolStripSeparator();
            var toolStripSeparator2 = new ToolStripSeparator();
            var выходToolStripMenuItem = new ToolStripMenuItem();
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            создатьToolStripMenuItem,
            открытьToolStripMenuItem,
            toolStripSeparator,
            сохранитьToolStripMenuItem,
            сохранитькакToolStripMenuItem,
            toolStripSeparator1,
            toolStripSeparator2,
            выходToolStripMenuItem});
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            файлToolStripMenuItem.Text = "&Файл";
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.Image = Resources.create.ToBitmap();
            создатьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            создатьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            создатьToolStripMenuItem.Text = "&Создать";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Image = Resources.open.ToBitmap();
            открытьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            открытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            открытьToolStripMenuItem.Text = "&Открыть";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Enabled = false;
            сохранитьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            сохранитьToolStripMenuItem.Text = "&Сохранить";
            // 
            // сохранитькакToolStripMenuItem
            // 
            сохранитькакToolStripMenuItem.Enabled = false;
            сохранитькакToolStripMenuItem.Image = Resources.save.ToBitmap();
            сохранитькакToolStripMenuItem.Name = "сохранитькакToolStripMenuItem";
            сохранитькакToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            сохранитькакToolStripMenuItem.Text = "Сохранить &как";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            выходToolStripMenuItem.Text = "Вы&ход";
            
            выходToolStripMenuItem.Click += (ar1, ar2) => { Application.Exit(); };
            создатьToolStripMenuItem.Click += (ar1, ar2) => { CreateNewProject(); };
            открытьToolStripMenuItem.Click += (ar1, ar2) => { LoadProjectData("Bazis project file(*.bpf)|*.bpf|All files(*.*)|*.*"); };
            сохранитьToolStripMenuItem.Click += (ar1, ar2) => { SaveProjectData(); };
            сохранитькакToolStripMenuItem.Click += (ar1, ar2) => { SaveAsProjectData("bpf"); };

            return файлToolStripMenuItem;
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
            видToolStripMenuItem.Size = new System.Drawing.Size(39, 24);
            видToolStripMenuItem.Text = "Вид";
            // 
            // showNavigatorMenuItem
            // 
            showNavigatorMenuItem.Image = BaseModule.Properties.Resources.navigator;
            showNavigatorMenuItem.Name = "showNavigatorMenuItem";
            showNavigatorMenuItem.Size = new System.Drawing.Size(180, 22);
            showNavigatorMenuItem.Text = "Навигатор";
            // 
            // showConsoleMenuItem
            // 
            showConsoleMenuItem.Image = BaseModule.Properties.Resources.console;
            showConsoleMenuItem.Name = "showConsoleMenuItem";
            showConsoleMenuItem.Size = new System.Drawing.Size(180, 22);
            showConsoleMenuItem.Text = "Консоль";

            // singup to show navigator click
            showNavigatorMenuItem.Click += (ar1, ar2) => 
            { splitContainer1.Panel1Collapsed = false; };

            // singup to show console click
            showConsoleMenuItem.Click += (ar1, ar2) => 
            { splitContainer2.Panel2Collapsed = false; };

            return видToolStripMenuItem;
        }

        public void SetVersion(string version)
        {
            lblVersion.Text = version;
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

        public Form FindOpenedForm(string formName)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == formName)
                    return form;
            }
            return null;
        }

        public void CreateScreenShot(string fileName)
        {
            this.BringToFront();
            var bmpPicture = new Bitmap(SceneControl.Width, SceneControl.Height);
            var gr = Graphics.FromImage(bmpPicture);
            var pos = SceneControl.PointToScreen(Point.Empty);
            var size = new Size(SceneControl.Size.Width - 5, SceneControl.Size.Height - 5);
            gr.CopyFromScreen(pos, Point.Empty, size);

            bmpPicture.Save($@"{Project.Path}\{fileName}.bmp");
        }

        public void PrintCommand(string message)
        {
            lblInputCmd.Text = message;
        }

        public void PresentObjectsToScene(string objsName, IObjsPresenter presenter)
        {
            if (!SceneControl.DrawInsideObjects & objsName == "Элементы3D")
            {
                var elms3D = Project.Model.ObjectData.FindMany<Element3D>();
                ModelPresenter.HideInsideSurfaces(elms3D);
            }

            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");
            var edges = presenter.CreateEdgeFlags(inds.Item4);

            if (presenter.PresenterType == PresenterType.Surface)
            {
                SceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName);
            }

            else if (presenter.PresenterType == PresenterType.Line)
            {
                SceneControl.CreateLineVBObjects(ptrs, coords, colors, normals, edges, objsName);
            }

            else
                SceneControl.CreatePointVBObjects(ptrs, coords, colors, normals, objsName);
        }

        public void SetBackColorToAllObjects()
        {
            foreach (var presentor in ModelPresenter)
            {
                foreach (var modelObject in presentor.Value)
                    modelObject.SetBackColor();

                var vboObjs = SceneControl.FindVBObj(presentor.Key);

                if(vboObjs != null)
                {
                    var colors = presentor.Value.CreateVertexes(vboObjs.ColorLength, "цвет");
                    vboObjs.PointsColors = colors;
                }

            }
        }

        private void StandartToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag.ToString() == "0")
            {
                CreateNewProject();
            }

            else if (e.ClickedItem.Tag.ToString() == "1")
            {
                var filterProject = "Bazis project file(*.bpf)|*.bpf|" +
            "All files(*.*)|*.*";
                LoadProjectData(filterProject);
            }
            else if (e.ClickedItem.Tag.ToString() == "2")
            {
                SaveAsProjectData("bpf");
            }
            else if (e.ClickedItem.Tag.ToString() == "4")
            {
                var filterMesh =
                    "All files(*.*)|*.*|" +
                    "Visual-Mesh ESI Group(*.ASC)|*.ASC|" +
                    "GMSH(*.inp*)|*.inp|" + 
                    "ANSYS(*.cdb*)|*.cdb|" +
                    "SOLOMIA(*.dat*)|*.dat";
                ImportModelData(filterMesh);
            }
        }

        public void CreateNewProject()
        {
            project = new ProjectData("newProject", Environment.CurrentDirectory);

            ModelPresenter = new ModelScenePresentator(project.Model.ObjectData);

            consoleControl.PrintInfo("Создан новый проект", Color.Black);

            PresentProjectOnTree();
            PresentModelOnSelectToolStrip();
            ClearAllDataOnScene();
            SceneControl.DisplayObjects();

            lblInputCmd.Text = "Начните работу с загрузки проекта или импорта сеточной модели";
        }

        private void ImportModelData(string filterMesh)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filterMesh;
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            project = new ProjectData("newProject", Environment.CurrentDirectory);
            consoleControl.PrintInfo("Создан новый проект", Color.Black);

            var ext = Path.GetExtension(dialog.FileName);

            IModelLoader loader;

            if (ext == ".inp")
                loader = new LoadModelFromGMSHTextFile();
            else if (ext == ".ASC")
                loader = new LoadModelFromASCIITextFile();
            else if (ext == ".dat")
                loader = new LoadModelFromSalomeFile();
            else
                loader = new LoadModelFromCDBTextFile();

            loader.LoadEvent += (ar1, ar2) => { consoleControl.PrintInfo(ar2.Message, Color.Black); };

            var model = loader.Load(dialog.FileName);
            project.Model.Load(model);

            lblInputCmd.Text = string.Empty;

            ChangeProjectDataEvent(this, project);

            ModelPresenter = new ModelScenePresentator(project.Model.ObjectData);

            PresentProjectOnTree();
            PresentModelOnSelectToolStrip();

            SceneInitialization();
        }

        public virtual void LoadProjectData(string extFilter)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = extFilter;
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;

                var ext = Path.GetExtension(dialog.FileName);

                if (ext == ".bpf")
                {
                    project = new ProjectData("newProject", Environment.CurrentDirectory);
                    consoleControl.PrintInfo("Создан новый проект", Color.Black);

                    var loader = new LoadProjectFromTextFormat();
                    loader.LoadEvent += (ar1, ar2) => { consoleControl.PrintInfo(ar2.Message, Color.Black); };

                    var projectLoad = loader.Load(dialog.FileName);
                    project.Load(projectLoad);

                    lblInputCmd.Text = string.Empty;

                    ChangeProjectDataEvent(this, project);

                    ModelPresenter = new ModelScenePresentator(project.Model.ObjectData);

                    PresentProjectOnTree();
                    PresentModelOnSelectToolStrip();

                    SceneInitialization();
                }
                else
                {
                    consoleControl.PrintInfo("Неизвестный формат файла!", Color.Red);
                    return;
                }

            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public bool SaveAsProjectData(string extFilter)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.DefaultExt = extFilter;

            if (saveDialog.ShowDialog() == DialogResult.Cancel)
                return false;

            var path = Path.GetDirectoryName(saveDialog.FileName);
            project.Name = Path.GetFileName(saveDialog.FileName);

            var compData = project.TaskData.Find("Расчет");

            if (project.Path != path)
                foreach (CompData data in compData)
                {
                    var oldfilePath = $@"{project.Path}\{data.FileParameters}";
                    var newfilePath = $@"{path}\{data.FileParameters}";

                    File.Create(newfilePath).Close();
                    File.Copy(oldfilePath, newfilePath, true);
                }

            project.Path = path;

            saveDialog.Dispose();

            SaveProjectData();

            PresentProjectOnTree();
            SceneControl.DisplayObjects();

            return true;
        }

        public void SaveProjectData()
        {
            var saver = new SaveProjectTextFormat();
            saver.SaveEvent += (ar1, ar2) => { consoleControl.PrintInfo(ar2.Message, Color.Black); };
            saver.Save(project);

            consoleControl.PrintInfo("Проект сохранен в " + project.Path, Color.Black);
        }

        public void PresentModelOnSelectToolStrip()
        {
            selectToolStrip.Clear();

            var objTypes = project.Model.ObjectData.GetObjectTypes();

            foreach (var objType in objTypes)
            {
                selectToolStrip.AddObjectsType(objType);
            }
        }

        public virtual void PresentProjectOnTree()
        {
            SceneControl.TitleText = project.Name;

            navigator.SetProjectTitleInfo("названиеПроекта", "Название : " + project.Name);
            navigator.SetProjectTitleInfo("путь", "Путь : " + project.Path);
            navigator.SetProjectTitleInfo("сведения", "Сведения : " + project.Comments);
            navigator.SetProjectTitleInfo("вид", "Вид: " + project.TaskType);

            navigator.TreeView.BeginUpdate();

            navigator.TreeView.Nodes["объекты"].Expand();
            navigator.TreeView.Nodes["объекты"].Nodes.Clear();

            foreach (var objInfo in ModelPresenter)
            {
                navigator.CreateChildNode("объекты", objInfo.Key, $"{objInfo.Key} : {objInfo.Value.Count()}", "4.1");
                navigator.ShowObjectsNode(objInfo.Key);
            }            

            navigator.TreeView.Nodes["группыОбъектов"].Expand();
            navigator.TreeView.Nodes["группыОбъектов"].Nodes.Clear();

            foreach (var group in Project.Model.GroupData)
            {
                navigator.CreateChildNode("группыОбъектов", group.ObjType,group.GroupName, "5.1");
            }

            navigator.TreeView.EndUpdate();
        }


        public void ClearAllDataOnScene()
        {
            SceneControl.HideAllGeometryObjs();
            SceneControl.HideDisplayText2D();
            SceneControl.HideDisplayText3D();
            SceneControl.DeleteAllVBObjects();
        }

        private void SelectToolStrip_SelectObjectEvent(object arg1, SelectObjectEventArgs arg2)
        {
            SetBackColorToAllObjects();
            SceneControl.DisplayObjects();
        }

        private void SelectToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var selectStrip = (SelectToolStrip)sender;
            if (e.ClickedItem is ToolStripButton btn)
                if (!btn.Checked)
                {

                    if (e.ClickedItem.Tag.ToString() == "4")
                    {
                        var form = new Form() { Name = "selectForm", Text = "Выбрать", ShowIcon = false, Size = new Size(300, 300) };
                        form.TopMost = true;

                        form.FormClosing += (s1, s2) => { btn.Checked = false; lblInputCmd.Text = ""; };
                        var selectionControl = new SelectionSet() { Dock = DockStyle.Fill };
                        selectionControl.SelectInDirection += SelectionControl_SelectInDirection;
                        selectionControl.SelectInPlain += SelectionControl_SelectInPlain;
                        selectionControl.SelectNodes += (s1, s2) =>
                        {
                            selectStrip.SelectObjectsType = "Узлы";
                            lblInputCmd.Text = "Выберите два узла для направления или три для плоскости";
                        };
                        selectionControl.SelectElements += (s1, s2) =>
                        {
                            selectStrip.SelectObjectsType = "Элементы2D";
                            lblInputCmd.Text = "Выберите плоский элемент \"2D\"";
                        };

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
                var selectHelper = new SelectionHelper(project.Model.ObjectData);

                var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];

                var objs = objsPresenter.Where(x => x.MasterColor == SceneControl.SelectionColor).ToList();

                if (selectToolStrip.SelectObjectsType == "Узлы")
                {
                    if (objs.Count > 2)
                    {
                        var n1 = (Node)objs[0];
                        var n2 = (Node)objs[1];
                        var n3 = (Node)objs[2];

                        var plane = new Plane(n1.Position, n2.Position, n3.Position);
                        selectHelper.SelectInPlane<Node>(plane, SceneControl.SelectionColor);
                    }
                }
                else
                {
                    if (objs.Count > 0)
                    {
                        var element = objs.Last();
                        selectHelper.SelectInPlane<Element2D>(arg2.Angle, element.Number, SceneControl.SelectionColor);
                    }
                }

                var vboObjs = SceneControl.FindVBObj(selectToolStrip.SelectObjectsType);
                var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                vboObjs.PointsColors = colors;

                SceneControl.DisplayObjects();

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
                var selectHelper = new SelectionHelper(project.Model.ObjectData);

                var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];
                var objs = objsPresenter.Where(x => x.MasterColor == SceneControl.SelectionColor).ToArray();
                if (objs.Length > 1)
                {
                    if (!arg2.Reverse)
                    {
                        var search = selectHelper.SelectInDirection<Element3D>(arg2.Angle, objs[objs.Length - 2].Number, objs[objs.Length - 1].Number, SceneControl.SelectionColor);
                    }
                    else
                    {
                        selectHelper.SelectInDirection<Element3D>(arg2.Angle, objs[objs.Length - 1].Number, objs[objs.Length - 2].Number, SceneControl.SelectionColor);
                    }
                    var vboObjs = SceneControl.FindVBObj(selectToolStrip.SelectObjectsType);
                    var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                    vboObjs.PointsColors = colors;

                    SceneControl.DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void InstrumentalToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var btn = (ToolStripButton)e.ClickedItem;
            if (!btn.Checked)
            {
                if (e.ClickedItem.Tag.ToString() == "0")
                {
                    var form = new Form() { Name = "measureForm", Text = "Измерить", ShowIcon = false, Size = new Size(555, 283) };
                    form.TopMost = true;

                    form.FormClosed += (s1, s2) =>
                    {
                        btn.Checked = false;
                        lblInputCmd.Text = "";
                        SceneControl.HideAllGeometryObjs();
                        SceneControl.HideDisplayText3D();
                        SceneControl.DisplayObjects();
                    };

                    var measuringControl = new MeasuringSet() { Dock = DockStyle.Fill };
                    measuringControl.PreparingMeasureEvent += MeasuringControl_PreparingMeasureEvent;
                    measuringControl.MakeMeasureEvent += MeasuringControl_MakeMeasureEvent;
                    form.Controls.Add(measuringControl);
                    form.Show();
                }

                else if (e.ClickedItem.Tag.ToString() == "1")
                {
                    var form = new Form() { Name = "CrossSectionForm", Text = "Построить сечение", ShowIcon = false,  Size = new Size(268, 203),TopMost = true};
  
                    var crossSection = new CrossSectionControl() { Dock = DockStyle.Fill };
                    form.Controls.Add(crossSection);

                    crossSection.RemoveCrossEvent += () => 
                    {
                        SceneControl.DeleteVBObjects("crossSection");
                        SceneControl.DisplayObjects();
                    };

                    crossSection.SelectNodesEvent += () => { selectToolStrip.SelectObjectsType = "Узлы"; };

                    crossSection.CreateCrossFromTextArgs += (ar1,ar2) =>
                    {
                        try
                        {
                            var elems3D = project.Model.ObjectData.FindMany("Элементы3D").Cast<Element3D>().ToList();
                            var surfaces = CreateSectionSurfaces(elems3D, ar2.point1, ar2.point2, ar2.point3);

                            PresentCrossSection(surfaces);

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
                            var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];
                            var objs = objsPresenter.Where(x => x.MasterColor == SceneControl.SelectionColor).ToArray();
                            if (objs.Length < 3)
                            {
                                consoleControl.PrintInfo("Ошибка, выбрано неверное количество узлов", Color.Red);
                                return;
                            }

                            var p0 = objs[0];
                            var p1 = objs[1];
                            var p2 = objs[2];

                            var elems3D = project.Model.ObjectData.FindMany<Element3D>().ToList();

                            var surfaces = CreateSectionSurfaces(
                                elems3D, p0.CalcCentralPoint(),
                                p1.CalcCentralPoint(),
                                p2.CalcCentralPoint());

                            PresentCrossSection(surfaces);

                        }
                        catch (Exception ex)
                        {
                            ConsoleControl.PrintInfo(ex.Message, Color.Red);
                        }
                    };

                    form.FormClosed += (ar1, ar2) =>
                    {
                        btn.Checked = false;
                        lblInputCmd.Text = "";

                        SceneControl.DeleteVBObjects("crossSection");

                        if(SceneControl.GetVBObjsName().Count() == 0)
                        {
                            SceneControl.DeleteAllVBObjects();
                            foreach (var presenter in ModelPresenter)
                                PresentObjectsToScene(presenter.Key, presenter.Value);
                        }
                        SceneControl.DisplayObjects();
                    };

                    form.Show();
                }

                else if (e.ClickedItem.Tag.ToString() == "2")
                {
                    var scrShot = CreateScreenShot();
                    scrShot.Save(project.Path + "\\screenShot.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                    consoleControl.PrintInfo($"Сделан снимок экрана {project.Path}\\screenShot.bmp", Color.Black);
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

        public virtual void PresentCrossSection(Dictionary<int, Surface> surfaces)
        {
            var presenter = ModelPresenter.CreateSurfaceObjectsPresenter(surfaces.Values.Select(x => (ISurfaceObject)x));

            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");
            var edges = presenter.CreateEdgeFlags(inds.Item4);

            SceneControl.CreateSurfaceVBObjects(ptrs, coords, colors,normals, edges, "crossSection");
            SceneControl.DisplayObjects();
        }

        public Dictionary<int, Surface> CreateSectionSurfaces(List<Element3D> elems3D, Point3D p0, Point3D p1, Point3D p2)
        {
            var plane = new Plane(p0, p1, p2);

            var sectionMaker = new ModelController.MeshObjsUtility.CrossSection();

            return sectionMaker.GetSectionSurfaces(elems3D, plane);
        }

        private async void MeasuringControl_MakeMeasureEvent(object arg1, MeasureEventArgs arg2)
        {
            try
            {
                switch (arg2.Kind)
                {
                    case MeasureKind.DistanceNodeToNode:
                        {
                            var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];
                            var objs = objsPresenter.Where(x => x.MasterColor == SceneControl.SelectionColor).ToList();

                            if (objs.Count() > 1)
                            {
                                var nodes = objs.Select(x => (Node)x);
                                var p0 = nodes.First();
                                var p1 = nodes.Last();
                                var line = new Segment3D(p0.Position, p1.Position);

                                consoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);

                                SceneControl.CreateDistance(line);
                                SceneControl.DisplayObjects();
                            }
                            else consoleControl.PrintInfo("Узлы не выбраны", Color.Red);
                            break;
                        }
                    case MeasureKind.DistanceNodeToPlane:
                        {
                            PressedKey = Keys.None;
                            var plane = CreateSurfaceAsync();
                            await plane;

                            var nodesPresentor = ModelPresenter["Узлы"];
                            foreach (var _node in nodesPresentor)
                                _node.SetBackColor();

                            var vboObjs = SceneControl.FindVBObj("Узлы");
                            var colors = nodesPresentor.CreateVertexes(vboObjs.ColorLength, "цвет");
                            vboObjs.PointsColors = colors;
                            SceneControl.DisplayObjects();

                            var node = SelectNodeAsync();
                            await node;
                            var proj = node.Result.Position.GetPointProectionOnPlane(plane.Result);
                            var line = new Segment3D(node.Result.Position, proj);
                            consoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);
                            SceneControl.CreateDistance(line);
                            SceneControl.DisplayObjects();
                            break;
                        }
                    case MeasureKind.Path:
                        break;
                    case MeasureKind.Square:
                        {
                            var square = 0.0f;

                            var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];

                            var objs = objsPresenter.Where(x => x.MasterColor == SceneControl.SelectionColor);

                            foreach (var obj in objs)
                            {
                                var sObj = (ISurfaceObject)obj;
                                square += sObj.GetSurface().First().CalcSquare();
                            }
                            consoleControl.PrintInfo(string.Format("Площадь : {0}", square), Color.Black);
                            break;
                        }

                    case MeasureKind.Volume:
                        {
                            var vol = 0.0f;

                            var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];

                            var objs = objsPresenter.Where(x => x.MasterColor == SceneControl.SelectionColor);

                            foreach (var obj in objs)
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

        private async Task<Node> SelectNodeAsync()
        {
            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    ConsoleControl.PrintInfo("Операция отменена", Color.Black);
                    PrintCommand("");
                }));
            });

            var message = "Выберите узел и нажмите на кнопку Enter или нажмите кнопку ESC";

            var actPointConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];
                
                var objs = objsPresenter.Where(x => x.MasterColor == SceneControl.SelectionColor);

                if (objs.Count() == 0)
                {
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo("Не выбран ни один узел!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    var node = (Node)objs.First();
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo($"Выбран узел {node.Number}", Color.Green);
                        PrintCommand("");
                    }));
                    return new Tuple<bool, object>(true, node);
                }
            });

            var pointAwait = AsyncMethodContainer(actPointConfirm, actBreak, message);
            await pointAwait;
            return (Node)pointAwait.Result;
        }

        private async Task<Plane> CreateSurfaceAsync()
        {
            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    ConsoleControl.PrintInfo("Операция отменена", Color.Black);
                    PrintCommand("");
                }));
            });
            var message = "Задайте поверхность, выбрав три узла, и нажмите на кнопку Enter или нажмите кнопку ESC";
            var actSurfaceConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];
                var selObjs = objsPresenter.Where(x => x.MasterColor == SceneControl.SelectionColor).ToArray();

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

                    var plane = new Plane(p0.CalcCentralPoint(), p1.CalcCentralPoint(), p2.CalcCentralPoint());
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo("Задана плоскость", Color.Green);
                        PrintCommand("");
                    }));
                    return new Tuple<bool, object>(true, plane);
                }
            });
            var surfaceAwait = AsyncMethodContainer(actSurfaceConfirm, actBreak, message);
            await surfaceAwait;
            return (Plane)surfaceAwait.Result;
        }

        private void MeasuringControl_PreparingMeasureEvent(object arg1, MeasureEventArgs arg2)
        {
            SceneControl.HideAllGeometryObjs();
            SceneControl.HideDisplayText3D();
            SceneControl.DisplayObjects();

            switch (arg2.Kind)
            {
                case MeasureKind.DistanceNodeToNode:
                    selectToolStrip.SelectObjectsType = "Узлы";
                    lblInputCmd.Text = "Выберите два узла";
                    break;
                case MeasureKind.DistanceNodeToPlane:
                    lblInputCmd.Text = "Создайте поверхность и выберите узел";
                    break;
                case MeasureKind.Path:
                    selectToolStrip.SelectObjectsType = "Узлы";
                    lblInputCmd.Text = "Выберите узлы";
                    break;
                case MeasureKind.Square:
                    selectToolStrip.SelectObjectsType = "Элементы2D";
                    lblInputCmd.Text = "Выберите элементы 2D или поверхности";
                    break;
                case MeasureKind.Volume:
                    selectToolStrip.SelectObjectsType = "Элементы3D";
                    lblInputCmd.Text = "Выберите элементы 3D";
                    break;
                default:
                    break;
            }
        }

        private Image CreateScreenShot()
        {
            this.BringToFront();
            var bmpPicture = new Bitmap(SceneControl.Width, SceneControl.Height);
            var gr = Graphics.FromImage(bmpPicture);
            var pos = SceneControl.PointToScreen(new Point(10, 10));
            var size = new Size(SceneControl.Size.Width - 10, SceneControl.Size.Height - 20);
            gr.CopyFromScreen(pos, Point.Empty, size);

            return bmpPicture;
        }

        private void ViewToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var btn = (ToolStripButton)e.ClickedItem;

            if (e.ClickedItem.Tag.ToString() == "0")
            {
                SceneControl.PlaneObjs(ViewPlane.XY);
            }
            else if (e.ClickedItem.Tag.ToString() == "1")
            {
                SceneControl.PlaneObjs(ViewPlane.XZ);
            }
            else if (e.ClickedItem.Tag.ToString() == "2")
            {
                SceneControl.PlaneObjs(ViewPlane.YZ);
            }
            else if (e.ClickedItem.Tag.ToString() == "3")
            {
                if (!btn.Checked)
                    SceneControl.RotationAxis = ViewAxis.X;
                else
                    SceneControl.RotationAxis = ViewAxis.XYZ;

            }
            else if (e.ClickedItem.Tag.ToString() == "4")
            {
                if (!btn.Checked)
                    SceneControl.RotationAxis = ViewAxis.Y;
                else
                    SceneControl.RotationAxis = ViewAxis.XYZ;

            }
            else if (e.ClickedItem.Tag.ToString() == "5")
            {
                if (!btn.Checked)
                    SceneControl.RotationAxis = ViewAxis.Z;
                else
                    SceneControl.RotationAxis = ViewAxis.XYZ;

            }
            else if (e.ClickedItem.Tag.ToString() == "6")
            {
                SceneControl.RotationAxis = ViewAxis.Y;
                SceneControl.RotationAngle = 90;
                SceneControl.RotateObjs();
                SceneControl.RotationAxis = ViewAxis.XYZ;
                SceneControl.RotationAngle = 2.5f;
            }
            else if (e.ClickedItem.Tag.ToString() == "7")
            {
                SceneControl.RotationAxis = ViewAxis.X;
                SceneControl.RotationAngle = 90;
                SceneControl.RotateObjs();
                SceneControl.RotationAxis = ViewAxis.XYZ;
                SceneControl.RotationAngle = 2.5f;
            }
            else if (e.ClickedItem.Tag.ToString() == "8")
            {
                SceneControl.FitObjectsToScreen();
            }
            SceneControl.DisplayObjects();
        }

        private void DisplayToolStrip_ItemClick(object arg1, ToolStripItemClickedEventArgs arg2)
        {
            try
            {
                if (arg2.ClickedItem.Tag.ToString() == "0")
                {
                    var btn = (ToolStripButton)arg2.ClickedItem;

                    if (!btn.Checked)
                        SceneControl.DisplayTitle();
                    else SceneControl.UnPlugTitle();
                }
                else if (arg2.ClickedItem.Tag.ToString() == "8")
                {
                    var btn = (ToolStripButton)arg2.ClickedItem;
                    if (!btn.Checked)
                    {
                        var boundaryCreator = new FindBoundaryEdges(Project.Model);
                        var lines = boundaryCreator.Find();
                        var nodes = Project.Model.ObjectData.FindMany<Node>().ToArray();

                        var curves = new List<Line>();

                        var counter = 0;
                        foreach (var item in lines)
                        {
                            var numbers = item.Split(' ');
                            var po = Convert.ToInt32(numbers[0]);
                            var p1 = Convert.ToInt32(numbers[1]);
                            var node0 = ByNumberFinder.Find(nodes, po);
                            var node1 = ByNumberFinder.Find(nodes, p1);
                            var curve = new Line(counter, new Node[] { node0, node1 })
                            { MasterColor = Color.Red };
                            curves.Add(curve);
                            counter++;
                        }

                        var linePresenter = ModelPresenter.CreateLineObjectsPresenter(curves);

                        PresentObjectsToScene("Boundary", linePresenter);
                    }
                    else SceneControl.DeleteVBObjects("Boundary");
                }

                else if (arg2.ClickedItem.Tag.ToString() == "1")
                {
                    SceneControl.DrawInsideObjects = true;

                    if (ModelPresenter.ContainsKey("Элементы3D"))
                    {
                        var vbobj = SceneControl.FindVBObj("Элементы3D");
                        var viewMode = vbobj.ViewMode;

                        SceneControl.DeleteVBObjects("Элементы3D");

                        foreach (var item in ModelPresenter["Элементы3D"])
                            if (item.ViewState)
                                item.ViewState = true;
   
                        PresentObjectsToScene("Элементы3D", ModelPresenter["Элементы3D"]);
                        SceneControl.ChangeViewModeVBObjects("Элементы3D", viewMode);
                    }
    
                    consoleControl.PrintInfo("Показаны все объекты", Color.Black);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "2")
                {
                    SceneControl.DrawInsideObjects = false;

                    if (ModelPresenter.ContainsKey("Элементы3D"))
                    {
                        var vbobj = SceneControl.FindVBObj("Элементы3D");
                        var viewMode = vbobj.ViewMode;
                        SceneControl.DeleteVBObjects("Элементы3D");

                        PresentObjectsToScene("Элементы3D", ModelPresenter["Элементы3D"]);
                        SceneControl.ChangeViewModeVBObjects("Элементы3D", viewMode);
                    }
  
                    consoleControl.PrintInfo("Скрыты внутренние объекты", Color.Black);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "3")
                {
                    //SceneControl.HideAllVBObjects();

                    foreach (var objsType in SceneControl.GetVBObjsName())
                        SceneControl.ChangeViewModeVBObjects(objsType, ObjView.LinesSurface);

                    //SceneControl.ShowAllVBObjects();
                }

                else if (arg2.ClickedItem.Tag.ToString() == "4")
                {
                    //SceneControl.HideAllVBObjects();

                    foreach (var objsType in SceneControl.GetVBObjsName())
                        SceneControl.ChangeViewModeVBObjects(objsType, ObjView.Lines);

                    //SceneControl.ShowAllVBObjects();
                }

                else if (arg2.ClickedItem.Tag.ToString() == "5")
                {
                    //SceneControl.HideAllVBObjects();

                    foreach (var objsType in SceneControl.GetVBObjsName())
                        SceneControl.ChangeViewModeVBObjects(objsType, ObjView.Surface);

                    //SceneControl.ShowAllVBObjects();
                }
                SceneControl.DisplayObjects();
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
 
            Invoke(new Action(() => { lblInputCmd.Text = cmdMessage; }));
            await System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (PressedKey == Keys.Enter)
                    {
                        var resAction = actConfirm.Invoke();
                        if (resAction.Item1)
                            resObject = resAction.Item2;
                            break;
                    }
                    if (PressedKey == Keys.Escape)
                    {
                        actBreak.Invoke();
                        break;
                    }
                }
                PressedKey = Keys.None;
            });
            return resObject;
        }

        public virtual void SceneControl_CreateMeshGroupEvent()
        {
            if (!ModelPresenter.ContainsKey(selectToolStrip.SelectObjectsType))
                return;

            var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];

            var selObjs = objsPresenter.Where(x => x.MasterColor == SceneControl.SelectionColor);

            if (selObjs.Count() > 0)
            {
                var name = $"{selectToolStrip.SelectObjectsType}_{project.Model.GroupData.Count + 1}";
                var group = new Group(name, selectToolStrip.SelectObjectsType);

                group.AddRange(selObjs);
                project.Model.GroupData.Add(group);

                ChangeProjectDataEvent(this, project);

                consoleControl.PrintInfo(string.Format("Создана новая группа {0}", name), Color.Black);

                foreach (var selObj in selObjs)
                    selObj.SetBackColor();

                var vboObjs = SceneControl.FindVBObj(selectToolStrip.SelectObjectsType);
                var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                vboObjs.PointsColors = colors;

                SceneControl.DisplayObjects();

                navigator.CreateChildNode("группыОбъектов", group.ObjType, group.GroupName, "5.1");
            }
        }

        public virtual void SceneControl_DeleteSelectionEvent()
        {
            if (!ModelPresenter.ContainsKey(selectToolStrip.SelectObjectsType))
                return;


            var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];
            var selObjs = objsPresenter.Where(x => x.MasterColor == SceneControl.SelectionColor);

            foreach (var selObj in selObjs)
                selObj.ExistState = false;

            var groups = Project.Model.GroupData.FindMany(selectToolStrip.SelectObjectsType);

            foreach (var group in groups)
            {
                var exObjs = group.Where(x => x.ExistState == true).ToArray();

                if(exObjs.Count() != group.Count)
                {
                    group.Clear();
                    if (exObjs.Length > 0)
                        group.AddRange(exObjs);
                }
            }  

            Project.Model.ObjectData.ClearRemoved();

            ModelPresenter = new ModelScenePresentator(Project.Model.ObjectData);

            var vbObj = SceneControl.FindVBObj(selectToolStrip.SelectObjectsType);
            var viewMode = vbObj.ViewMode;

            SceneControl.DeleteAllVBObjects();

            foreach (var _objsPresenter in ModelPresenter)
                PresentObjectsToScene(_objsPresenter.Key, _objsPresenter.Value);


            SceneControl.ChangeViewModeVBObjects(selectToolStrip.SelectObjectsType, viewMode);
            SceneControl.DisplayObjects();

            PresentProjectOnTree();
        }

        private void SceneControl_InfoObjectsEvent()
        {
            try
            {
                var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];
                var selObjs = objsPresenter.Where(x => x.MasterColor == SceneControl.SelectionColor);

                consoleControl.PrintInfo($"Выбраны {selectToolStrip.SelectObjectsType} {selObjs.Count()}", Color.Black);

                var numbers = string.Join(" ", selObjs.Select(x => x.Number).ToArray());
                consoleControl.PrintInfo("Номера : " + numbers, Color.Black);
            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void SceneControl_MessageEvent(object arg1, MessageEventArgs arg2)
        {
            consoleControl.PrintInfo(arg2.Message, Color.Red);
        }

        private void SceneControl_SelectObjectsEvent(object arg1, SelectObjectsEventArgs arg2)
        {
            if (ModelPresenter.ContainsKey(selectToolStrip.SelectObjectsType))
            {
                var selection = SearchObjects(selectToolStrip.SelectObjectsType, arg2.SelectionBox);

                if (arg2.IsSorted & selection.Count > 0)
                {
                    var near = selection.OrderByDescending(x => x.CalcCentralPoint()._z).Last();
                    near.SetBackColor();
                }
                else
                {
                    foreach (var obj in selection)
                        if (arg2.IsSelected)
                            obj.MasterColor = SceneControl.SelectionColor;
                        else
                            obj.SetBackColor();
                }


                var vboObjs = SceneControl.FindVBObj(selectToolStrip.SelectObjectsType);

                var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];
                var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                vboObjs.PointsColors = colors;

                SceneControl.DisplayObjects();
            }
        }

        private void SceneControl_ShowAllHiddenObjectsEvent()
        {
            ShowAllObjects();

            foreach (var item in ModelPresenter)
                navigator.ShowObjectsNode(item.Key);

            SceneControl.DisplayObjects();
        }

        private void SceneControl_HideSelectedObjectsEvent()
        {
            if (!ModelPresenter.ContainsKey(selectToolStrip.SelectObjectsType))
                return;

            var presentor = ModelPresenter[selectToolStrip.SelectObjectsType];

            var hideObjects = 0;
            foreach (var obj in presentor)
            {
                if (obj.MasterColor == SceneControl.SelectionColor)
                    obj.ViewState = false;

                if (!obj.ViewState)
                    hideObjects++;
            }

            if (hideObjects == presentor.Count())
                navigator.HideObjectsNode(selectToolStrip.SelectObjectsType);

            var vbObj = SceneControl.FindVBObj(selectToolStrip.SelectObjectsType);
            var viewMode = vbObj.ViewMode;

            SceneControl.DeleteVBObjects(selectToolStrip.SelectObjectsType);
            var vbObj1 = SceneControl.FindVBObj(selectToolStrip.SelectObjectsType);
            PresentObjectsToScene(selectToolStrip.SelectObjectsType, presentor);

            SceneControl.ChangeViewModeVBObjects(selectToolStrip.SelectObjectsType, viewMode);
            SceneControl.DisplayObjects();
        }

        private void SceneControl_SetBackColorEvent()
        {
            SetBackColorToAllObjects();
            SceneControl.HideDisplayText3D();
            SceneControl.DisplayObjects();
        }

        private void WebPageLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(webPageLabel.Text); //где path это путь к сайту
        }


        public virtual void UnBlockInterface(bool status)
        {
            //var toolStr = FindToolStrip<StandartToolStrip>();
            //toolStr.Enabled = true;

            standartToolStrip.Items[2].Enabled = status;
            standartToolStrip.Items[3].Enabled = status;

            //foreach (ToolStripButton item in toolStr.Items)
            //    item.Enabled = true;

            var items = menuItems.Find(x => x.Name == "файлToolStripMenuItem");

            items.DropDownItems[3].Enabled = status;
            items.DropDownItems[4].Enabled = status;

            //foreach (var item in items.DropDownItems)
            //    if (item is ToolStripMenuItem tsmItem)
            //        tsmItem.Enabled = true;
            
        }  

        private void BasePage_Load(object sender, EventArgs e)
        {
            navigator.NavigatorPanelCollapseEvent += () => { splitContainer1.Panel1Collapsed = true; };
            sceneExControl.ScenePanelExpandEvent += () => 
            { 
                splitContainer1.Panel1Collapsed = true;
                splitContainer2.Panel2Collapsed = true;
            };

            sceneExControl.ScenePanelUnwrapEvent += () =>
            {
                splitContainer1.Panel1Collapsed = false;
                splitContainer2.Panel2Collapsed = false;
            };
            consoleControl.ConsolePanelCollapseEvent += () => { splitContainer2.Panel2Collapsed = true; };

            displayToolStrip.Location = new Point(0, 0);
            instrumentalToolStrip.Location = new Point(0, 0);
            standartToolStrip.Location = new Point(0, 0);
            selectToolStrip.Location = new Point(0, 0);
            viewToolStrip.Location = new Point(0, 0);
            instrumentalToolStrip.Location = new Point(0, 0);

            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.viewToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.instrumentalToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.displayToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.selectToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.standartToolStrip);
                         
            displayToolStrip.Renderer = new BaseToolStrRender();
            instrumentalToolStrip.Renderer = new BaseToolStrRender();
            standartToolStrip.Renderer = new BaseToolStrRender();
            selectToolStrip.Renderer = new BaseToolStrRender();
            viewToolStrip.Renderer = new BaseToolStrRender();
            instrumentalToolStrip.Renderer = new BaseToolStrRender();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            navigator.Invalidate();

            SetLblInputCmb();
        }

        

        public async void ConsoleControl_InEvent(object arg1, EventArgs arg2)
        {
            try
            {
                if (arg2 is ModelFindFreeNodesEventArgs freeNodesEventArgs)
                {
                    var finder = new FreeNodesFinder(project.Model.ObjectData);
                    var freeNodes = finder.Find<Element>();

                    Invoke(new Action(() => 
                    { 
                        consoleControl.PrintInfo($"Найдено {freeNodes.Count()} свободных узлов", Color.Black);

                        HideAllObjects();

                        foreach (var freeNode in freeNodes)
                            Project.Model.ObjectData.Find(freeNode).ViewState = true;

                        SceneControl.DeleteVBObjects("Узлы");
                        PresentObjectsToScene("Узлы", ModelPresenter["Узлы"]);

                        SceneControl.DisplayObjects();
                    }));
                }
                else if (arg2 is ModelFindCoincidentsNodesEventArgs coincidentNodesEventArgs)
                {
                    Invoke(new Action(() => { consoleControl.PrintInfo("Выполняется поиск совпадающих узлов сетки...", Color.Black); }));
                    var coincidentFinder = new FindCoincidentObjects(project.Model.ObjectData, 0.001f);
                    coincidentFinder.ProgressEvent += (ar1, ar2) =>
                    {
                        Invoke(new Action(() => { consoleControl.PrintInfo(string.Format("{0:00}%", ar2 * 100), Color.Black); }));
                    };
                    var coincidentNodes = coincidentFinder.Find<Node>();

                    Invoke(new Action(() => { consoleControl.PrintInfo($"Найдено {coincidentNodes.Where(x => x.Count > 2).Count()} совпадений", Color.Black); }));
                    Invoke(new Action(() =>
                    {
                        foreach (var objType in ModelPresenter)
                            PresentObjectsToScene(objType.Key, objType.Value);
                        SceneControl.DisplayObjects();
                    }));
                    var actConfirm = new Func<Tuple<bool, object>>(() =>
                    {
                        var merge = new MergeObjects(project.Model.ObjectData);
                        merge.Merge<Node>(coincidentNodes);

                        Invoke(new Action(() =>
                        {
                            PresentProjectOnTree();
                            consoleControl.PrintInfo("Узлы слиты", Color.Green);
                            lblInputCmd.Text = "";
                        }));
                        return new Tuple<bool, object>(true,new object());
                    });

                    var actBreak = new Action(() =>
                    {
                        Invoke(new Action(() =>
                        {
                            consoleControl.PrintInfo("Операция отменена", Color.Black);
                            lblInputCmd.Text = "";
                        }));
                    });
                    await AsyncMethodContainer(actConfirm, actBreak, $"Нажмите {"Enter"} для слияния, {"Esc"} для отмены");
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => { consoleControl.PrintInfo(ex.Message, Color.Red); }));
            }
        }

        

        public List<IModelObject> SearchObjects(string objType, RectangleBox selectionBox)
        {
            var camera = SceneControl.Camera;

            var objsPresenter = ModelPresenter[objType];
            var selections = new List<IModelObject>();

            foreach (var obj in objsPresenter)
            {
                if(obj.ViewState)
                {
                    var scrPoints = new Point2D[obj.NumberOfPoints];
                    var scnPoints = new Point3D[obj.NumberOfPoints];

                    var pointCounter = 0;
                    foreach (var point in obj.GetPoints())
                    {
                        var scnPoint = camera.GetSceenCoord(point);
                        scnPoints[pointCounter] = scnPoint;

                        var scrPoint = camera.GetScreenCoord(scnPoint);
                        scrPoints[pointCounter] = scrPoint;

                        pointCounter++;
                    }

                    if (selectionBox.IsPointsInside(scrPoints))
                        selections.Add(obj);
                }

            }
            return selections;
        }

        

        private void lblInputCmd_TextChanged(object sender, EventArgs e)
        {
            SetLblInputCmb();
        }

        public void SetLblInputCmb()
        {
            var messageSize = CreateGraphics().MeasureString(lblInputCmd.Text, Font);
            var size = (Width - (int)messageSize.Width) / 2;
            lblInputCmd.Width = size;
        }

        private void navigator_DelGroupEvent(int obj)
        {
            var group = Project.Model.GroupData[obj];
            Project.Model.GroupData.Remove(group);

            var valData = Project.TaskData.Where(x => x is IValuableData).Select(x => (IValuableData)x).
Where(x => x.GroupName == group.GroupName).ToArray();

            foreach (Data data in valData)
                Project.TaskData.Remove(data);

            ChangeProjectDataEvent?.Invoke(this, Project);
        }

        private void navigator_DelObjectsEvent(string objs)
        {
            SceneControl.DeleteVBObjects(objs);
            ModelPresenter.Remove(objs);
            Project.Model.ObjectData.RemoveRange(objs);
            selectToolStrip.RemoveObjectsType(objs);

            SceneControl.DisplayObjects();
        }

        private async void navigator_EditGroupEvent(int obj)
        {
            var group = Project.Model.GroupData[obj];
            selectToolStrip.SelectObjectsType = group.ObjType;

            var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];
            //SelectToolStrip.SelectObjectsType = group.ObjType;

            foreach (var iobj in group)
                iobj.MasterColor = SceneControl.SelectionColor;

            var vboObjs = SceneControl.FindVBObj(selectToolStrip.SelectObjectsType);
            var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
            vboObjs.PointsColors = colors;

            SceneControl.DisplayObjects();

            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                if (objsPresenter.Where(x => x.MasterColor == SceneControl.SelectionColor).Count() == 0)
                {
                    Invoke(new Action(() => {
                        ConsoleControl.PrintInfo("Не выбран ни один объект!", Color.Black);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    group.Clear();
                    var objs = objsPresenter.Where(x => x.MasterColor == SceneControl.SelectionColor); ;
                    group.AddRange(objs);
                    Project.Model.GroupData.Add(group);
                    Invoke(new Action(() => {
                        consoleControl.PrintInfo("Группа изменена успешно", Color.Green);
                        PrintCommand("");
                    }));
                    return new Tuple<bool, object>(true, new object());
                }
            });

            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    consoleControl.PrintInfo("Операция отменена", Color.Black);
                    PrintCommand("");
                }));
            });

            var message = "измените группу, добавив или удалив объекты, и нажмите на кнопку Enter или нажмите кнопку ESC";

            await AsyncMethodContainer(actConfirm, actBreak, message);
        }

        private void navigator_HideAllGroupsEvent()
        {
            foreach (var group in Project.Model.GroupData)
            {
                foreach (var iobj in group)
                {
                    iobj.ViewState = false;
                }
            }

            foreach (var item in ModelPresenter)
            {
                var vbobj = SceneControl.FindVBObj(item.Key);
                var viewMode = vbobj.ViewMode;

                SceneControl.DeleteVBObjects(item.Key);
                PresentObjectsToScene(item.Key, item.Value);
                SceneControl.ChangeViewModeVBObjects(item.Key, viewMode);
            }

            SceneControl.DisplayObjects();
        }

        private void navigator_HideAllObjectsEvent()
        {
            HideAllObjects();

            SceneControl.DisplayObjects();
        }

        private void HideAllObjects()
        {
            foreach (var item in ModelPresenter)
            {
                foreach (var modelObject in item.Value)
                    modelObject.ViewState = false;

                var vbobj = SceneControl.FindVBObj(item.Key);
                var viewMode = vbobj.ViewMode;

                SceneControl.DeleteVBObjects(item.Key);
                PresentObjectsToScene(item.Key,item.Value);
                SceneControl.ChangeViewModeVBObjects(item.Key, viewMode);
            }
        }

        private void ShowAllObjects()
        {
            foreach (var item in ModelPresenter)
            {
                foreach (var modelObject in item.Value)
                    modelObject.ViewState = true;

                var vbobj = SceneControl.FindVBObj(item.Key);
                var viewMode = vbobj.ViewMode;

                SceneControl.DeleteVBObjects(item.Key);

                if(!SceneControl.DrawInsideObjects & item.Key == "Элементы3D")
                {
                    var elms3D = Project.Model.ObjectData.FindMany<Element3D>();
                    ModelPresenter.HideInsideSurfaces(elms3D);
                }

                PresentObjectsToScene(item.Key,item.Value);
                SceneControl.ChangeViewModeVBObjects(item.Key, viewMode);
            }
        }

        private void navigator_HideGroupEvent(int obj)
        {
            var group = Project.Model.GroupData[obj];

            foreach (var iobj in group)
                iobj.ViewState = false;

            var vbobj = SceneControl.FindVBObj(group.ObjType);
            var viewMode = vbobj.ViewMode;

            SceneControl.DeleteVBObjects(group.ObjType);
            PresentObjectsToScene(group.ObjType, ModelPresenter[group.ObjType]);
            SceneControl.ChangeViewModeVBObjects(group.ObjType, viewMode);

            SceneControl.DisplayObjects();
        }

        private void navigator_HideObjectsEvent(string obj)
        {
            var modelObjects = Project.Model.ObjectData.FindMany(obj);
            foreach (var modelObject in modelObjects)
                modelObject.ViewState = false;

            var vbobj = SceneControl.FindVBObj(obj);
            var viewMode = vbobj.ViewMode;

            SceneControl.DeleteVBObjects(obj);
            PresentObjectsToScene(obj, ModelPresenter[obj]);
            SceneControl.ChangeViewModeVBObjects(obj, viewMode);

            SceneControl.DisplayObjects();
        }

        private void navigator_ShowAllObjectsEvent()
        {
            ShowAllObjects();

            SceneControl.DisplayObjects();
        }

        private void navigator_ShowObjectsEvent(string obj)
        {
            if (ModelPresenter.ContainsKey(obj))
            {
                var presenter = ModelPresenter[obj];

                foreach (var modelObject in presenter)
                    modelObject.ViewState = true;

                var vbobj = SceneControl.FindVBObj(obj);
                var viewMode = vbobj.ViewMode;

                SceneControl.DeleteVBObjects(obj);
                PresentObjectsToScene(obj, presenter);
                SceneControl.ChangeViewModeVBObjects(obj, viewMode);

                SceneControl.DisplayObjects();
            }
        }

        private void navigator_InfoGroupEvent(int obj)
        {
            var group = Project.Model.GroupData[obj];
            consoleControl.PrintInfo(group.ToString(), Color.Black);
        }

        private void navigator_RenameGroup(string newName, string oldName)
        {
            var gr = Project.Model.GroupData.Find(oldName);
            if (gr != null)
            {
                gr.GroupName = newName;
                foreach (var data in Project.TaskData)
                {
                    var dataStr = data.GetInfo;
                    if (dataStr.Contains(oldName))
                    {
                        dataStr = dataStr.Replace(oldName, newName);
                        data.SetInfo(dataStr);
                    }
                }
                ChangeProjectDataEvent?.Invoke(this, Project);
            }

        }

        private void navigator_SelectGroupEvent(string obj)
        {
            try
            {
                SetBackColorToAllObjects();

                var group = Project.Model.GroupData.Find(obj);

                var presenter = ModelPresenter[group.ObjType];
                foreach (var iobj in group)
                    iobj.MasterColor = SelectionGroupColor;

                var vboObjs = SceneControl.FindVBObj(group.ObjType);
                var colors = presenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                vboObjs.PointsColors = colors;

                SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowAllGroupsEvent()
        {
            foreach (var group in Project.Model.GroupData)
            {
                foreach (var iobj in group)
                {
                    iobj.ViewState = true;
                }
            }

            foreach (var item in ModelPresenter)
            {
                var vbobj = SceneControl.FindVBObj(item.Key);
                var viewMode = vbobj.ViewMode;

                SceneControl.DeleteVBObjects(item.Key);
                PresentObjectsToScene(item.Key, item.Value);
                SceneControl.ChangeViewModeVBObjects(item.Key, viewMode);
            }

            SceneControl.DisplayObjects();
        }

        private void navigator_ShowGroupEvent(int obj)
        {
            var group = Project.Model.GroupData[obj];

            foreach (var iobj in group)
                iobj.ViewState = true;


            var vbobj = SceneControl.FindVBObj(group.ObjType);
            var viewMode = vbobj.ViewMode;

            SceneControl.DeleteVBObjects(group.ObjType);
            PresentObjectsToScene(group.ObjType, ModelPresenter[group.ObjType]);
            SceneControl.ChangeViewModeVBObjects(group.ObjType, viewMode);

            SceneControl.DisplayObjects();
        }

        private void navigator_ChangeViewModeEvent(string objs, ViewRegime viewRegime)
        {
            switch (viewRegime)
            {
                case ViewRegime.ribbers:
                    SceneControl.ChangeViewModeVBObjects(objs, ObjView.Lines);
                    break;
                case ViewRegime.surfaces:
                    SceneControl.ChangeViewModeVBObjects(objs, ObjView.Surface);
                    break;
                case ViewRegime.ribbersSurfaces:
                    SceneControl.ChangeViewModeVBObjects(objs, ObjView.LinesSurface);
                    break;
                default:
                    break;
            }

            SceneControl.DisplayObjects();
        }

        private void navigator_ShowGroupWithNodesEvent(int obj)
        {
            var group = Project.Model.GroupData[obj];

            foreach (var iobj in group)
            {
                var elem = (IElement)iobj;
                elem.ViewState = true;

                foreach (var node in elem.GetNodes())
                    node.ViewState = true;

            }

            SceneControl.DeleteVBObjects("Узлы");
            PresentObjectsToScene("Узлы", ModelPresenter["Узлы"]);

            var vbobj = SceneControl.FindVBObj(group.ObjType);
            var viewMode = vbobj.ViewMode;

            SceneControl.DeleteVBObjects(group.ObjType);
            PresentObjectsToScene(group.ObjType, ModelPresenter[group.ObjType]);
            SceneControl.ChangeViewModeVBObjects(group.ObjType, viewMode);  

            SceneControl.DisplayObjects();
        }
    }
}
