using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Geometry;
using ModelInterfaces;
using System.IO;
using ModelController.MeshObjsUtility;
using Model.GroupsData;
using Scene.Events;
using System.Diagnostics;
using BaseModule.Console;
using BaseModule.CrossSection;
using Model.IO;
using BaseModule.Properties;
using BaseModule.Console.Events;
using ProjectInterfaces;
using SceneInterface;
using BaseModule.ToolStrips;
using BaseModule.Navigator;
using ModelControllerInterfaces;
using ModelController.ModelScenePresentator;
using ProjectInterfaces.Tasks;
using ModelInterfaces.ObjectsFinders;
using System.Threading;
using Model.MeshObjects;
using Model.GeometryObjects;

namespace BaseModule
{
    public partial class BasePage : UserControl
    {
        public Action ChangeProjectDataEvent;
        public Action CreateProjectDataEvent;

        public IModelController ModelController { get; set; } = new ModelController.ModelController();

        public IModelScenePresenter ModelPresenter { get; set; }

        List<ToolStripMenuItem> menuItems = new List<ToolStripMenuItem>();

        public Keys PressedKey { get; set; }

        public IProjectData Project { get; set; }

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
            sceneControl.Initialization();

            ClearAllDataOnScene();

            ModelPresenter = new ModelScenePresentator(Project.ModelData.ObjectData);
            
            foreach (var item in ModelPresenter)
                PresentObjectsToScene(item.Key,item.Value);

            sceneControl.FitObjectsToScreen();
            sceneControl.DisplayObjects();
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
            открытьToolStripMenuItem.Click += (ar1, ar2) => 
            { 
                LoadProjectData("Bazis project file(*.bpf)|*.bpf|All files(*.*)|*.*");
                ChangeProjectDataEvent?.Invoke();
                PresentProjectOnTree();
                PresentModelOnSelectToolStrip();
                SceneInitialization();
            };
            сохранитьToolStripMenuItem.Click += (ar1, ar2) => { SaveProjectData(); };
            сохранитькакToolStripMenuItem.Click += (ar1, ar2) => 
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.DefaultExt = "bpf";

                    if (saveDialog.ShowDialog() == DialogResult.Cancel)
                        return;
                    SaveAsProjectData(saveDialog.FileName);
                }
                PresentProjectOnTree();
            };

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

        public void PrintCommand(string message)
        {
            lblInputCmd.Text = message;
        }

        public void PresentObjectsToScene(string objsName, IObjsPresenter presenter)
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
                sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsName);
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
            foreach (var presentor in ModelPresenter)
            {
                foreach (var modelObject in presentor.Value)
                    modelObject.SetBackColor();

                var vboObjs = sceneControl.FindVBObj(presentor.Key);

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
                ChangeProjectDataEvent?.Invoke();
                PresentProjectOnTree();
                PresentModelOnSelectToolStrip();
                SceneInitialization();
            }
            else if (e.ClickedItem.Tag.ToString() == "2")
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.DefaultExt = "bpf";

                    if (saveDialog.ShowDialog() == DialogResult.Cancel)
                        return;
                    SaveAsProjectData(saveDialog.FileName);
                }
                PresentProjectOnTree();
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
            Project.ClearAllData();
            Project.Name = "newProject";
            Project.Comments = "newComments";
            Project.Path = Environment.CurrentDirectory;

            ModelPresenter = new ModelScenePresentator(Project.ModelData.ObjectData);

            consoleControl.PrintInfo("Создан новый проект", Color.Black);

            PresentProjectOnTree();
            PresentModelOnSelectToolStrip();
            ClearAllDataOnScene();
            sceneControl.DisplayObjects();

            lblInputCmd.Text = "Начните работу с загрузки проекта или импорта сеточной модели";
        }

        private void ImportModelData(string filterMesh)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = filterMesh;
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;

                Project.ClearAllData();
                Project.Name = "newProject";
                Project.Path = Environment.CurrentDirectory;

                consoleControl.PrintInfo("Создан новый проект", Color.Black);

                var ext = Path.GetExtension(dialog.FileName);

                IModelLoader loader;

                if (ext == ".inp")
                    Project.ModelData.Loader = new LoadModelFromGMSHTextFile();
                else if (ext == ".ASC")
                    Project.ModelData.Loader = new LoadModelFromASCIITextFile();
                else if (ext == ".dat")
                    Project.ModelData.Loader = new LoadModelFromSalomeFile();
                else if(ext == ".stl")
                    Project.ModelData.Loader = new LoadModelFromSTLFile();
                else
                    Project.ModelData.Loader = new LoadModelFromCDBTextFile();

                Project.ModelData.Loader.LoadEvent += (ar1, ar2) => { consoleControl.PrintInfo(ar2.Message, Color.Black); };

                Project.ModelData.Load(dialog.FileName);

                lblInputCmd.Text = string.Empty;

                ChangeProjectDataEvent?.Invoke();

                ModelPresenter = new ModelScenePresentator(Project.ModelData.ObjectData);

                PresentProjectOnTree();
                PresentModelOnSelectToolStrip();

                SceneInitialization();

            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public virtual bool LoadProjectData(string extFilter)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = extFilter;
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return false;

                var ext = Path.GetExtension(dialog.FileName);

                if (ext == ".bpf")
                {
                    consoleControl.PrintInfo("Создан новый проект", Color.Black);

                    Project.Load(dialog.FileName);
                    ModelPresenter = new ModelScenePresentator(Project.ModelData.ObjectData);
                    lblInputCmd.Text = string.Empty;
                    return true;
                }
                else
                {
                    consoleControl.PrintInfo("Неизвестный формат файла!", Color.Red);
                    return false; 
                }

            }
            catch (Exception ex)
            {
                consoleControl.PrintInfo(ex.Message, Color.Red);
                return false;
            }
        }

        public bool CopyFile(string fileName, string oldFolder, string newFolder)
        {
            var oldfilePath = $@"{oldFolder}\{fileName}";

            if (File.Exists(oldfilePath))
            {
                var newfilePath = $@"{newFolder}\{fileName}";

                File.Create(newfilePath).Close();
                File.Copy(oldfilePath, newfilePath, true);

                ConsoleControl.PrintInfo($"Файл {fileName} скопирован в папку {newFolder}", Color.Green);
                return true;
            }
            else return false;
        }

        public virtual void SaveAsProjectData(string path)
        {
            var newFolder = Path.GetDirectoryName(path);
            var oldFolder = Project.Path;

            Project.Name = Path.GetFileName(path);
            Project.Path = newFolder;

            if (oldFolder != Project.Path)
            {
                var oldfilePath = string.Empty;
                var newfilePath = string.Empty;

                var compData = Project.TaskData.Find("Расчет");
                foreach (ICompData data in compData)
                {
                    oldfilePath = $@"{oldFolder}\{data.FileParameters}";
                    newfilePath = $@"{Project.Path}\{data.FileParameters}";

                    File.Create(newfilePath).Close();
                    File.Copy(oldfilePath, newfilePath, true);
                }

                CopyFile(Project.Materials, oldFolder, Project.Path);
                CopyFile(Project.Functions, oldFolder, Project.Path);
            }

            SaveProjectData();
        }

        public virtual void SaveProjectData()
        {
            Project.Save();

            consoleControl.PrintInfo("Проект сохранен в " + Project.Path, Color.Black);
        }

        public void PresentModelOnSelectToolStrip()
        {
            selectToolStrip.Clear();

            foreach (var objItem in Project.ModelData.ObjectData)
            {
                selectToolStrip.AddObjectsType(objItem.Key.ToString());
            }
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

            foreach (var objInfo in Project.ModelData.ObjectData)
            {
                var objType = objInfo.Key.ToString();
                navigator.CreateChildNode("объекты", objType, $"{objType} : {objInfo.Value.Count()}", "4.1");
                navigator.ShowObjectsNode(objType);
            }            

            navigator.TreeView.Nodes["группыОбъектов"].Expand();
            navigator.TreeView.Nodes["группыОбъектов"].Nodes.Clear();

            foreach (var group in Project.ModelData.GroupData)
            {
                navigator.CreateChildNode("группыОбъектов", group.ObjType.ToString(),group.GroupName, "5.1");
            }

            navigator.TreeView.EndUpdate();
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
                var selectHelper = new SelectionHelper(Project.ModelData.ObjectData);

                var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];

                var objs = objsPresenter.Where(x => x.MasterColor == sceneControl.SelectionColor).ToList();

                if (selectToolStrip.SelectObjectsType == "Узлы")
                {
                    if (objs.Count > 2)
                    {
                        var n1 = (Node)objs[0];
                        var n2 = (Node)objs[1];
                        var n3 = (Node)objs[2];

                        var plane = new Plane(n1.Position, n2.Position, n3.Position);
                        selectHelper.SelectInPlane<Node>(plane, sceneControl.SelectionColor);
                    }
                }
                else
                {
                    if (objs.Count > 0)
                    {
                        var element = objs.Last();
                        selectHelper.SelectInPlane<Element2D>(arg2.Angle, element.Number, sceneControl.SelectionColor);
                    }
                }

                var vboObjs = sceneControl.FindVBObj(selectToolStrip.SelectObjectsType);
                var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                vboObjs.PointsColors = colors;

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
                var selectHelper = new SelectionHelper(Project.ModelData.ObjectData);

                var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];
                var objs = objsPresenter.Where(x => x.MasterColor == sceneControl.SelectionColor).ToArray();
                if (objs.Length > 1)
                {
                    if (!arg2.Reverse)
                    {
                        selectHelper.SelectInDirection<Element3D>(arg2.Angle, objs[objs.Length - 2].Number, objs[objs.Length - 1].Number, sceneControl.SelectionColor);
                    }
                    else
                    {
                        selectHelper.SelectInDirection<Element3D>(arg2.Angle, objs[objs.Length - 1].Number, objs[objs.Length - 2].Number, sceneControl.SelectionColor);
                    }
                    var vboObjs = sceneControl.FindVBObj(selectToolStrip.SelectObjectsType);
                    var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                    vboObjs.PointsColors = colors;

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
                        sceneControl.HideAllGeometryObjs();
                        sceneControl.HideDisplayText3D();
                        sceneControl.DisplayObjects();
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
                        sceneControl.DeleteVBObjects("crossSection");
                        sceneControl.DisplayObjects();
                    };

                    crossSection.SelectNodesEvent += () => { selectToolStrip.SelectObjectsType = "Узлы"; };

                    crossSection.CreateCrossFromTextArgs += (ar1,ar2) =>
                    {
                        try
                        {
                            var elems3D = Project.ModelData.ObjectData[ObjType.Элемент3D].Cast<Element3D>().ToList();
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
                            var objs = objsPresenter.Where(x => x.MasterColor == sceneControl.SelectionColor).ToArray();
                            if (objs.Length < 3)
                            {
                                consoleControl.PrintInfo("Ошибка, выбрано неверное количество узлов", Color.Red);
                                return;
                            }

                            var p0 = objs[0];
                            var p1 = objs[1];
                            var p2 = objs[2];

                            var elems3D = Project.ModelData.ObjectData.FindMany<Element3D>().ToList();

                            var surfaces = CreateSectionSurfaces(
                                elems3D, p0.CalcCentr(),
                                p1.CalcCentr(),
                                p2.CalcCentr());

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

                        sceneControl.DeleteVBObjects("crossSection");

                        if(sceneControl.GetVBObjsName().Count() == 0)
                        {
                            sceneControl.DeleteAllVBObjects();
                            foreach (var presenter in ModelPresenter)
                                PresentObjectsToScene(presenter.Key, presenter.Value);
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

        public virtual void PresentCrossSection(Dictionary<int, Figure2D> surfaces)
        {
            var presenter = ModelPresenter.CreateSurfaceGeometryPresenter(surfaces.Values,false);

            var inds = presenter.CreateIndexes();
            var ptrs = presenter.CreatePointers(inds.Item1);
            var coords = presenter.CreateVertexes(inds.Item2, "координаты");
            var colors = presenter.CreateVertexes(inds.Item3, "цвет");
            var normals = presenter.CreateVertexes(inds.Item2, "нормаль");
            var edges = presenter.CreateEdgeFlags(inds.Item4);

            sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors,normals, edges, "crossSection");
            sceneControl.DisplayObjects();
        }

        public Dictionary<int, Figure2D> CreateSectionSurfaces(List<Element3D> elems3D, Point3D p0, Point3D p1, Point3D p2)
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
                            var objs = objsPresenter.Where(x => x.MasterColor == sceneControl.SelectionColor).ToList();

                            if (objs.Count() > 1)
                            {
                                var nodes = objs.Select(x => (Node)x);
                                var p0 = nodes.First();
                                var p1 = nodes.Last();
                                var line = new Segment3D(p0.Position, p1.Position);

                                consoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);

                                sceneControl.CreateDistance(line);
                                sceneControl.DisplayObjects();
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

                            var vboObjs = sceneControl.FindVBObj("Узлы");
                            var colors = nodesPresentor.CreateVertexes(vboObjs.ColorLength, "цвет");
                            vboObjs.PointsColors = colors;
                            sceneControl.DisplayObjects();

                            var node = SelectNodeAsync();
                            await node;
                            var proj = node.Result.Position.GetPointProectionOnPlane(plane.Result);
                            var line = new Segment3D(node.Result.Position, proj);
                            consoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);
                            sceneControl.CreateDistance(line);
                            sceneControl.DisplayObjects();
                            break;
                        }
                    case MeasureKind.Path:
                        break;
                    case MeasureKind.Square:
                        {
                            var square = 0.0f;

                            var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];

                            var objs = objsPresenter.Where(x => x.MasterColor == sceneControl.SelectionColor);

                            foreach (var obj in objs)
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

                            var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];

                            var objs = objsPresenter.Where(x => x.MasterColor == sceneControl.SelectionColor);

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
                
                var objs = objsPresenter.Where(x => x.MasterColor == sceneControl.SelectionColor);

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
                var selObjs = objsPresenter.Where(x => x.MasterColor == sceneControl.SelectionColor).ToArray();

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
            sceneControl.HideAllGeometryObjs();
            sceneControl.HideDisplayText3D();
            sceneControl.DisplayObjects();

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
                    else sceneControl.UnPlugTitle();
                }
                else if (arg2.ClickedItem.Tag.ToString() == "8")
                {
                    var btn = (ToolStripButton)arg2.ClickedItem;
                    if (!btn.Checked)
                    {
                        var boundaryCreator = new FindBoundaryEdges(Project.ModelData);
                        var lines = boundaryCreator.Find();
                        var nodes = Project.ModelData.ObjectData.FindMany<Node>().ToArray();

                        var beams = new List<Beam>();

                        var counter = 0;
                        foreach (var item in lines)
                        {
                            var numbers = item.Split(' ');
                            var po = Convert.ToInt32(numbers[0]);
                            var p1 = Convert.ToInt32(numbers[1]);
                            var node0 = nodes.Find(po);
                            var node1 = nodes.Find(p1);
                            var beam = new Beam(counter, new Node[] { node0, node1 })
                            { MasterColor = Color.Red };
                            beams.Add(beam);
                            counter++;
                        }

                        var linePresenter = ModelPresenter.CreateBeamPresenter(beams);

                        PresentObjectsToScene("Boundary", linePresenter);
                    }
                    else sceneControl.DeleteVBObjects("Boundary");
                }

                else if (arg2.ClickedItem.Tag.ToString() == "1")
                {
                    sceneControl.DrawInsideObjects = true;

                    if (ModelPresenter.ContainsKey("Элемент3D"))
                    {
                        var vbobj = sceneControl.FindVBObj("Элемент3D");
                        var viewMode = vbobj.ViewMode;

                        sceneControl.DeleteVBObjects("Элемент3D");

                        foreach (var item in ModelPresenter["Элемент3D"])
                            if (item.ViewState)
                                item.ViewState = true;
   
                        PresentObjectsToScene("Элемент3D", ModelPresenter["Элемент3D"]);
                        sceneControl.ChangeViewModeVBObjects("Элемент3D", viewMode);
                    }
    
                    consoleControl.PrintInfo("Показаны все объекты", Color.Black);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "2")
                {
                    sceneControl.DrawInsideObjects = false;

                    if (ModelPresenter.ContainsKey("Элемент3D"))
                    {
                        var vbobj = sceneControl.FindVBObj("Элемент3D");
                        var viewMode = vbobj.ViewMode;
                        sceneControl.DeleteVBObjects("Элемент3D");

                        PresentObjectsToScene("Элемент3D", ModelPresenter["Элемент3D"]);
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

        public virtual void sceneControl_CreateMeshGroupEvent(object sender, EventArgs arg)
        {
            if (!ModelPresenter.ContainsKey(selectToolStrip.SelectObjectsType))
                return;

            var presenter = ModelPresenter[selectToolStrip.SelectObjectsType];

            var selObjs = presenter.Where(x => x.MasterColor == sceneControl.SelectionColor);

            if (selObjs.Count() > 0)
            {
                var name = $"{selectToolStrip.SelectObjectsType}_{Project.ModelData.GroupData.Count + 1}";
                var group = new Group(name, presenter.First().ObjType);

                group.AddRange(selObjs);
                Project.ModelData.GroupData.Add(group);

                ChangeProjectDataEvent?.Invoke();

                consoleControl.PrintInfo(string.Format("Создана новая группа {0}", name), Color.Black);

                foreach (var selObj in selObjs)
                    selObj.SetBackColor();

                var vboObjs = sceneControl.FindVBObj(selectToolStrip.SelectObjectsType);
                var colors = presenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                vboObjs.PointsColors = colors;

                sceneControl.DisplayObjects();

                navigator.CreateChildNode("группыОбъектов", group.ObjType.ToString(), group.GroupName, "5.1");
            }
        }

        public virtual void sceneControl_DeleteSelectionEvent(object sender, EventArgs arg)
        {
            if (!ModelPresenter.ContainsKey(selectToolStrip.SelectObjectsType))
                return;


            var presenter = ModelPresenter[selectToolStrip.SelectObjectsType];
            var selObjs = presenter.Where(x => x.MasterColor == sceneControl.SelectionColor);

            foreach (var selObj in selObjs)
                selObj.ExistState = false;

            var groups = Project.ModelData.GroupData.FindMany(presenter.First().ObjType);

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

            Project.ModelData.ObjectData.ClearNotExisted();

            ModelPresenter = new ModelScenePresentator(Project.ModelData.ObjectData);

            var vbObj = sceneControl.FindVBObj(selectToolStrip.SelectObjectsType);
            var viewMode = vbObj.ViewMode;

            sceneControl.DeleteAllVBObjects();

            foreach (var _objsPresenter in ModelPresenter)
                PresentObjectsToScene(_objsPresenter.Key, _objsPresenter.Value);


            sceneControl.ChangeViewModeVBObjects(selectToolStrip.SelectObjectsType, viewMode);
            sceneControl.DisplayObjects();

            PresentProjectOnTree();
        }

        private void sceneControl_InfoObjectsEvent(object sender, EventArgs arg)
        {
            try
            {
                var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];
                var selObjs = objsPresenter.Where(x => x.MasterColor == sceneControl.SelectionColor);

                consoleControl.PrintInfo($"Выбраны {selectToolStrip.SelectObjectsType} {selObjs.Count()}", Color.Black);

                var numbers = string.Join(" ", selObjs.Select(x => x.Number).ToArray());
                consoleControl.PrintInfo("Номера : " + numbers, Color.Black);
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
            if (ModelPresenter.ContainsKey(selectToolStrip.SelectObjectsType))
            {
                var selection = SearchObjects(selectToolStrip.SelectObjectsType, arg2.SelectionBox);

                if (arg2.IsSorted & selection.Count > 0)
                {
                    var near = selection.OrderByDescending(x => x.CalcCentr()._z).First();
                    if (arg2.IsSelected)
                        near.MasterColor = sceneControl.SelectionColor;
                    else
                        near.SetBackColor();
                }
                else
                {
                    foreach (var obj in selection)
                        if (arg2.IsSelected)
                            obj.MasterColor = sceneControl.SelectionColor;
                        else
                            obj.SetBackColor();
                }


                var vboObjs = sceneControl.FindVBObj(selectToolStrip.SelectObjectsType);

                var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];
                var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                vboObjs.PointsColors = colors;

                sceneControl.DisplayObjects();
            }
        }

        private void sceneControl_ShowAllHiddenObjectsEvent(object sender, EventArgs arg)
        {
            ShowAllObjects();

            foreach (var item in ModelPresenter)
                navigator.ShowObjectsNode(item.Key);

            sceneControl.DisplayObjects();
        }

        private void sceneControl_HideSelectedObjectsEvent(object sender, EventArgs arg)
        {
            if (!ModelPresenter.ContainsKey(selectToolStrip.SelectObjectsType))
                return;

            var presentor = ModelPresenter[selectToolStrip.SelectObjectsType];

            var hideObjects = 0;
            foreach (var obj in presentor)
            {
                if (obj.MasterColor == sceneControl.SelectionColor)
                    obj.ViewState = false;

                if (!obj.ViewState)
                    hideObjects++;
            }

            if (hideObjects == presentor.Count())
                navigator.HideObjectsNode(selectToolStrip.SelectObjectsType);

            var vbObj = sceneControl.FindVBObj(selectToolStrip.SelectObjectsType);
            var viewMode = vbObj.ViewMode;

            sceneControl.DeleteVBObjects(selectToolStrip.SelectObjectsType);
            PresentObjectsToScene(selectToolStrip.SelectObjectsType, presentor);
            sceneControl.ChangeViewModeVBObjects(selectToolStrip.SelectObjectsType, viewMode);

            sceneControl.DisplayObjects();
        }

        private void sceneControl_SetBackColorEvent(object sender, EventArgs arg)
        {
            SetBackColorToAllObjects();
            sceneControl.HideDisplayText3D();
            sceneControl.DisplayObjects();
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
            if (Project != null)
            {
                if (Project.ModelData == null)
                    Project.ModelData = new ModelData();
                else if (Project.ModelData.ObjectData.Count > 0)
                    lblInputCmd.Text = "";
            }

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
        }

        

        public async void ConsoleControl_InEvent(object arg1, EventArgs arg2)
        {
            try
            {
                if (arg2 is ModelFindFreeNodesEventArgs freeNodesEventArgs)
                {
                    var finder = new FreeNodesFinder(Project.ModelData.ObjectData);
                    var freeNodes = finder.Find<Element>();

                    Invoke(new Action(() => 
                    { 
                        consoleControl.PrintInfo($"Найдено {freeNodes.Count()} свободных узлов", Color.Black);

                        HideAllObjects();

                        foreach (var freeNode in freeNodes)
                            Project.ModelData.ObjectData.Find(ObjType.Узел,freeNode).ViewState = true;

                        var objsTypeStr = ObjType.Узел.ToString();
                        sceneControl.DeleteVBObjects(objsTypeStr);
                        PresentObjectsToScene(objsTypeStr, ModelPresenter[objsTypeStr]);

                        sceneControl.DisplayObjects();
                    }));
                }
                else if(arg2 is FindObjectEventArgs findObjectEventArgs)
                {
                    var obj = Project.ModelData.ObjectData.Find(ObjType.Узел,(int)findObjectEventArgs.Number);

                    if(obj != null)
                        obj.MasterColor = SceneControl.SelectionColor;
                    
                    var objsTypeStr = ObjType.Узел.ToString();

                    sceneControl.DeleteVBObjects(objsTypeStr);
                    PresentObjectsToScene(objsTypeStr, ModelPresenter[objsTypeStr]);

                    sceneControl.DisplayObjects();
                }
                else if (arg2 is ModelFindCoincidentsNodesEventArgs coincidentNodesEventArgs)
                {
                    Invoke(new Action(() => { consoleControl.PrintInfo("Выполняется поиск совпадающих узлов сетки...", Color.Black); }));
                    var coincidentFinder = new FindCoincidentObjects(Project.ModelData.ObjectData, 0.001f);
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
                        sceneControl.DisplayObjects();
                    }));
                    var actConfirm = new Func<Tuple<bool, object>>(() =>
                    {
                        var merge = new MergeObjects(Project.ModelData.ObjectData);
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
            var camera = sceneControl.Camera;

            var objsPresenter = ModelPresenter[objType];
            var selections = new List<IModelObject>();

            foreach (var obj in objsPresenter)
            {
                if(obj.ViewState)
                {
                    var scrPoints = new Point2D[obj.NumberOfPoints];
                    var scnPoints = new Point3D[obj.NumberOfPoints];

                    var pointCounter = 0;
                    foreach (var point in obj.GetCoordinates())
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
            var group = Project.ModelData.GroupData[obj];
            Project.ModelData.GroupData.Remove(group);

            if(Project.TaskData != null)
            {
                var valData = Project.TaskData.Where(x => x is IValuableData).Select(x => (IValuableData)x).
Where(x => x.GroupName == group.GroupName).ToArray();

                foreach (var data in valData)
                    Project.TaskData.Remove(data);
            }

            ChangeProjectDataEvent?.Invoke();
        }

        private void navigator_DelObjectsEvent(string objs)
        {
            SyncObjsRemove(objs);
            PresentProjectOnTree();
            sceneControl.DisplayObjects();

        }

        public void SyncObjsRemove(string objs)
        {
            ObjType objType;
            Enum.TryParse(objs, out objType);

            if(objType == ObjType.Объект)
            {
                sceneControl.DeleteAllVBObjects();
                ModelPresenter.Clear();
                selectToolStrip.Clear();
            }
            else
            {
                sceneControl.DeleteVBObjects(objs);
                ModelPresenter.Remove(objs);
                selectToolStrip.RemoveObjectsType(objs);
            }

            Project.ModelData.Remove(objType);
        }

        private async void navigator_EditGroupEvent(int obj)
        {
            var group = Project.ModelData.GroupData[obj];
            selectToolStrip.SelectObjectsType = group.ObjType.ToString();

            var objsPresenter = ModelPresenter[selectToolStrip.SelectObjectsType];
            //SelectToolStrip.SelectObjectsType = group.ObjType;

            foreach (var iobj in group)
                iobj.MasterColor = sceneControl.SelectionColor;

            var vboObjs = sceneControl.FindVBObj(selectToolStrip.SelectObjectsType);
            var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
            vboObjs.PointsColors = colors;

            sceneControl.DisplayObjects();

            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                if (objsPresenter.Where(x => x.MasterColor == sceneControl.SelectionColor).Count() == 0)
                {
                    Invoke(new Action(() => {
                        ConsoleControl.PrintInfo("Не выбран ни один объект!", Color.Black);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    group.Clear();
                    var objs = objsPresenter.Where(x => x.MasterColor == sceneControl.SelectionColor); ;
                    group.AddRange(objs);
    
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
            foreach (var group in Project.ModelData.GroupData)
            {
                foreach (var iobj in group)
                {
                    iobj.ViewState = false;
                }
            }

            foreach (var item in ModelPresenter)
            {
                var vbobj = sceneControl.FindVBObj(item.Key);
                var viewMode = vbobj.ViewMode;

                sceneControl.DeleteVBObjects(item.Key);
                PresentObjectsToScene(item.Key, item.Value);
                sceneControl.ChangeViewModeVBObjects(item.Key, viewMode);
            }

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
                foreach (var item in ModelPresenter)
                {
                    foreach (var modelObject in item.Value)
                        modelObject.ViewState = false;

                    var vbobj = sceneControl.FindVBObj(item.Key);
                    if (vbobj == null)
                        throw new Exception($"Объект {item.Key} не загружен на сцену!");
                    var viewMode = vbobj.ViewMode;

                    sceneControl.DeleteVBObjects(item.Key);
                    PresentObjectsToScene(item.Key, item.Value);
                    sceneControl.ChangeViewModeVBObjects(item.Key, viewMode);
                }
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
                foreach (var item in ModelPresenter)
                {
                    foreach (var modelObject in item.Value)
                        modelObject.ViewState = true;

                    var vbobj = sceneControl.FindVBObj(item.Key);
                    if (vbobj == null)
                        throw new Exception($"Объект {item.Key} не загружен на сцену!");
                    
                    var viewMode = vbobj.ViewMode;

   
                    if (!sceneControl.DrawInsideObjects & item.Value.IsVolumeObjs)
                    {
                        var volPresenter = (IVolumeObjsPresenter)item.Value;
                        volPresenter.HideInsideSurfaces();
                    }

                    sceneControl.DeleteVBObjects(item.Key);
                    PresentObjectsToScene(item.Key, item.Value);
                    sceneControl.ChangeViewModeVBObjects(item.Key, viewMode);
                }

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
                PresentObjectsToScene(group.ObjType.ToString(), ModelPresenter[group.ObjType.ToString()]);
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
                var presenter = ModelPresenter[obj];
                foreach (var modelObject in presenter)
                    modelObject.ViewState = false;

                var vbobj = sceneControl.FindVBObj(obj);
                if (vbobj == null)
                    throw new Exception($"Объект {obj} не загружен на сцену!");
                var viewMode = vbobj.ViewMode;

                sceneControl.DeleteVBObjects(obj);
                PresentObjectsToScene(obj, presenter);
                sceneControl.ChangeViewModeVBObjects(obj, viewMode);

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
                if (ModelPresenter.ContainsKey(obj))
                {
                    var presenter = ModelPresenter[obj];

                    foreach (var modelObject in presenter)
                        modelObject.ViewState = true;

                    var vbobj = sceneControl.FindVBObj(obj);
                    if (vbobj == null)
                        throw new Exception($"Объект {obj} не загружен на сцену!");
                    var viewMode = vbobj.ViewMode;

                    sceneControl.DeleteVBObjects(obj);
                    PresentObjectsToScene(obj, presenter);
                    sceneControl.ChangeViewModeVBObjects(obj, viewMode);

                    sceneControl.DisplayObjects();
                }
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

                if (Project.TaskData != null)
                    foreach (var data in Project.TaskData)
                    {
                        var dataStr = data.GetInfo;
                        if (dataStr.Contains(oldName))
                        {
                            dataStr = dataStr.Replace(oldName, newName);
                            data.SetInfo(dataStr);
                        }
                    }
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

                var presenter = ModelPresenter[group.ObjType.ToString()];
                foreach (var iobj in group)
                    iobj.MasterColor = SelectionGroupColor;

                var vboObjs = sceneControl.FindVBObj(group.ObjType.ToString());
                if (vboObjs == null)
                    throw new Exception($"Объект {group.ObjType} не загружен на сцену!");
                
                var colors = presenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                vboObjs.PointsColors = colors;

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

            foreach (var item in ModelPresenter)
            {
                var vbobj = sceneControl.FindVBObj(item.Key);
                var viewMode = vbobj.ViewMode;

                sceneControl.DeleteVBObjects(item.Key);
                PresentObjectsToScene(item.Key, item.Value);
                sceneControl.ChangeViewModeVBObjects(item.Key, viewMode);
            }

            sceneControl.DisplayObjects();
        }

        private void navigator_ShowGroupEvent(int obj)
        {
            var group = Project.ModelData.GroupData[obj];

            foreach (var iobj in group)
                iobj.ViewState = true;


            var vbobj = sceneControl.FindVBObj(group.ObjType.ToString());
            var viewMode = vbobj.ViewMode;

            sceneControl.DeleteVBObjects(group.ObjType.ToString());
            PresentObjectsToScene(group.ObjType.ToString(), ModelPresenter[group.ObjType.ToString()]);
            sceneControl.ChangeViewModeVBObjects(group.ObjType.ToString(), viewMode);

            sceneControl.DisplayObjects();
        }

        private void navigator_ChangeViewModeEvent(string objs, ViewRegime viewRegime)
        {
            switch (viewRegime)
            {
                case ViewRegime.ribbers:
                    sceneControl.ChangeViewModeVBObjects(objs, ObjView.Lines);
                    break;
                case ViewRegime.surfaces:
                    sceneControl.ChangeViewModeVBObjects(objs, ObjView.Surface);
                    break;
                case ViewRegime.ribbersSurfaces:
                    sceneControl.ChangeViewModeVBObjects(objs, ObjView.LinesSurface);
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

            sceneControl.DeleteVBObjects("Узлы");
            PresentObjectsToScene("Узлы", ModelPresenter["Узлы"]);

            var vbobj = sceneControl.FindVBObj(group.ObjType.ToString());
            var viewMode = vbobj.ViewMode;

            sceneControl.DeleteVBObjects(group.ObjType.ToString());
            PresentObjectsToScene(group.ObjType.ToString(), ModelPresenter[group.ObjType.ToString()]);
            sceneControl.ChangeViewModeVBObjects(group.ObjType.ToString(), viewMode);  

            sceneControl.DisplayObjects();
        }

        private void splitContainer1_Paint(object sender, PaintEventArgs e)
        {
            var locRect = new Point(splitContainer1.Panel1.Width - 1, splitContainer2.Panel1.Height / 2);
            var rect = new Rectangle(locRect, new Size(5, 50));
            e.Graphics.DrawRectangle(Pens.DarkGray, rect);

            var x = splitContainer1.Panel1.Width;
            var y = splitContainer2.Panel1.Height / 2;

            var points = new Point[]
            {
                        new Point(x + 4, y + 24),
                        new Point(x + 1, y + 27),
                        new Point(x + 4, y + 31)
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
    }
}
