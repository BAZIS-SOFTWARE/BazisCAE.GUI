using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scene;
using ToolStrips;
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
using ModelController.ModelScenePresentator;
using Project.IO;
using Model.IO;
using BaseModule.Properties;
using BaseModule.Console.Events;
using Project.Interfaces;
using Project.TasksData;
using SceneInterface;
using Newtonsoft.Json;
using Project.ResultsData;
using Project.TasksData.TaskParameters;

namespace BaseModule
{
    public partial class BasePage : UserControl
    {
        Dictionary<string, int> imgDict;
        private ProjectData project;
        public Action<object, ProjectData> ChangeProjectDataEvent;
        public ModelScenePresentator ModelPresenter { get; set; }

        List<ToolStripMenuItem> menuItems;

        public Keys PressedKey { get; set; }

        public ProjectData Project
        {
            get { return project; }
            set { project = value; }
        }

        [Category("treeView")]
        [Description("Set imageIndex for expand node")]
        public int ExpandIndex { get; set; } = 2;

        [Category("treeView")]
        [Description("Set imageIndex for collapse node")]
        public int CollapseIndex { get; set; } = 1;

        [Category("treeView")]
        [Description("Set imageIndex for project info nodes")]
        public int ProjectInfoIndex { get; set; } = 0;

        public BasePage()
        {
            InitializeComponent();

            imgDict = new Dictionary<string, int>()
            {
                { "Узлы",3},
                { "Элементы3D",4},
                { "Элементы2D",4},
                { "Элементы1D",4}
            };
        }

        public void SceneInitialization()
        {
            sceneControl.BringToFront();
            sceneControl.Initialization();

            ClearAllDataOnScene();

            foreach (var item in ModelPresenter)
                PresentDataToScene(item.Key);

            sceneControl.FitObjectsToScreen();
            sceneControl.DisplayObjects();
        }

        public void AddToolStrip(ToolStrip toolStrip)
        {          
            toolStripContainer.TopToolStripPanel.Join(toolStrip);
        }

        public TreeView TreeView
        {
            get
            {
                return treeView;
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

        public bool SceneTransparency 
        {
            set { sceneControl.IsBlending = value; }
        }
        public bool SceneLighting
        {
            set { sceneControl.IsLighting = value; }
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
            открытьToolStripMenuItem.Click += (ar1, ar2) => { LoadProjectData("Bazis project file(*.bpf)|*.bpf|" + "All files(*.*)|*.*"); };
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
            showNavigatorMenuItem.Click += (ar1, ar2) => { ShowNavigator(); };

            // singup to show console click
            showConsoleMenuItem.Click += (ar1, ar2) => { ShowConsole(); };

            return видToolStripMenuItem;
        }

        private void TreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = ExpandIndex;
            e.Node.SelectedImageIndex = ExpandIndex;
        }

        private void TreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = CollapseIndex;
            e.Node.SelectedImageIndex = CollapseIndex;
        }

        public T FindToolStrip<T>()
        {
            var toolStripContainer = new List<ToolStripContainer>();
            SearchControl(this, toolStripContainer);
            foreach (var item in toolStripContainer?[0].TopToolStripPanel.Controls)
            {
                if (item is T selectToolStrip)
                    return selectToolStrip;
            }
            return default(T);
        }

        public void SetVersion(string version)
        {
            lblVersion.Text = version;
        }

        public ToolStrip FindToolStrip(string name)
        {
            var toolStripContainer = new List<ToolStripContainer>();
            SearchControl(this, toolStripContainer);
            foreach (var item in toolStripContainer?[0].TopToolStripPanel.Controls)
            {
                if (item is ToolStrip toolStrip && toolStrip.Name == name)
                    return toolStrip;
            }
            return null;
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

        public void PresentDataToScene(string objsType)
        {

            if (!sceneControl.DrawInsideObjects)
                ModelPresenter.HideInsideObjects(objsType);

            var inds = ModelPresenter.CreateVBOIndexes(objsType);
            var ptrs = ModelPresenter.CreateVBOPointers(objsType, inds.Item1);
            var coords = ModelPresenter.CreateVBOVertexes(objsType, inds.Item2, "координаты");
            var colors = ModelPresenter.CreateVBOVertexes(objsType, inds.Item3, "цвет");
            var normals = ModelPresenter.CreateVBOVertexes(objsType, inds.Item2, "нормаль");
            var edges = ModelPresenter.CreateVBOEdges(objsType, inds.Item4);


            if (objsType == "Элементы2D" | objsType == "Элементы3D")
            {
                sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors, normals, edges, objsType);
            }

            else if (objsType == "Элементы1D")
            {
                sceneControl.CreateLineVBObjects(ptrs, coords, colors, normals, edges, objsType);
            }

            else
                sceneControl.CreatePointVBObjects(ptrs, coords, colors, normals, objsType);
        }

        public void SetBackColorToAllObjects()
        {
            foreach (var presentor in ModelPresenter)
            {
                foreach (var modelObject in presentor.Value.GetObjs())
                    modelObject.SetBackColor();

                var vboObjs = sceneControl.FindVBObj(presentor.Key);
                var colors = presentor.Value.CreateVertexes(vboObjs.ColorLength, "цвет");
                vboObjs.PointsColors = colors;
            }

        }

        private void grbNavigator_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Навигатор", Font, new SolidBrush(System.Drawing.Color.Black), 16, 0);
            PaintCloseRectangle((Control)sender, e);
        }

        private void PaintCloseRectangle(Control control, PaintEventArgs e)
        {
            var locRect = new Point(control.Width - 16, 3);
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
            var rect = new Rectangle(locRect, new Size(8, 8));

            e.Graphics.DrawRectangle(blackPen, rect);
            e.Graphics.DrawString("х", Font, new SolidBrush(System.Drawing.Color.Black), control.Width - 16, 0);
        }

        private void grbNavigator_MouseClick(object sender, MouseEventArgs e)
        {
            var grb = (Panel)sender;

            if (e.Location.X > grb.Width - 16 & e.Location.X < grb.Width - 8 && e.Location.Y <= 10)
                splitContainer1.Panel1Collapsed = true;
        }

        private void grbConsole_MouseClick(object sender, MouseEventArgs e)
        {
            var grb = (Panel)sender;
  
            if (e.Location.X > grb.Width - 16 & e.Location.X < grb.Width - 8 && e.Location.Y <= 10)
                splitContainer2.Panel2Collapsed = true;
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
            //else if (e.ClickedItem.Tag.ToString() == "3")
            //{
            //    var form = new Form() { Name = "helpForm", Text = "Справка", ShowIcon = false, Size = new Size(555, 283) };
            //    form.TopMost = true;
            //    var helpFile = Directory.GetFiles(Application.StartupPath, "ПО Bazis. Руководство пользователя.chm", SearchOption.AllDirectories);

            //    if (helpFile.Count() != 0)
            //        Help.ShowHelp(form, helpFile[0]);
            //    else MessageBox.Show("Отсутствует файл справки!");
            //}
            else if (e.ClickedItem.Tag.ToString() == "4")
            {
                var filterMesh = 
                    "Visual-Mesh ESI Group(*.ASC)|*.ASC|" +
                    "GMSH(*.inp*)|*.inp|" + 
                    "ANSYS(*.cdb*)|*.cdb";
                ImportModelData(filterMesh);
            }
        }

        public void CreateNewProject()
        {
            project = new ProjectData("newProject", Environment.CurrentDirectory);
            ModelPresenter = new ModelScenePresentator(project.Model);

            consoleControl.PrintInfo("Создан новый проект", Color.Black);

            PresentProjectOnTree();
            PresentModelOnSelectToolStrip();
            ClearAllDataOnScene();
            sceneControl.DisplayObjects();

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
            else
                loader = new LoadModelFromCDBTextFile();

            loader.LoadEvent += (ar1, ar2) => { consoleControl.PrintInfo(ar2.Message, Color.Black); };

            var model = loader.Load(dialog.FileName);
            project.Model.Load(model);

            lblInputCmd.Text = string.Empty;

            ChangeProjectDataEvent(this, project);

            ModelPresenter = new ModelScenePresentator(project.Model);

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

                    ModelPresenter = new ModelScenePresentator(project.Model);

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
            sceneControl.DisplayObjects();

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
            var selectToolStrip = FindToolStrip<SelectToolStrip>();
            selectToolStrip.Clear();

            var objTypes = project.Model.ObjectData.GetObjectTypes();

            foreach (var objType in objTypes)
            {
                selectToolStrip.AddObjectsType(objType);
            }
        }

        public virtual void PresentProjectOnTree()
        {
            sceneControl.TitleText = project.Name;

            treeView.Nodes[0].Text = "Название : " + project.Name;
            treeView.Nodes[0].ImageIndex = ProjectInfoIndex;
            treeView.Nodes[0].SelectedImageIndex = ProjectInfoIndex;

            treeView.Nodes[1].Text = "Путь : " + project.Path;
            treeView.Nodes[1].ImageIndex = ProjectInfoIndex;
            treeView.Nodes[1].SelectedImageIndex = ProjectInfoIndex;

            treeView.Nodes[2].Text = "Сведения : " + project.Comments;
            treeView.Nodes[2].ImageIndex = ProjectInfoIndex;
            treeView.Nodes[2].SelectedImageIndex = ProjectInfoIndex;

            treeView.Nodes[3].Text = "Вид : " + project.TaskType;
            treeView.Nodes[3].ImageIndex = ProjectInfoIndex;
            treeView.Nodes[3].SelectedImageIndex = ProjectInfoIndex;

            treeView.BeforeLabelEdit += treeView_BeforeLabelEdit;
            treeView.AfterLabelEdit += treeView_AfterLabelEdit;
            treeView.NodeMouseClick += treeView_NodeMouseClick;

            SetModelObjsInfo();
            SetModelGroupInfo();
        }

        private void SelectGroup(string groupName)
        {
            try
            {
                SetBackColorToAllObjects();

                var group = Project.Model.GroupData.Find(groupName);

                var presenter = ModelPresenter[group.ObjType];
                foreach (var objNumber in group.ObjsNumbers)
                    presenter.FindObj(objNumber).MasterColor = Color.FromArgb(255, 0, 0);

                var vboObjs = sceneControl.FindVBObj(group.ObjType);
                var colors = presenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                vboObjs.PointsColors = colors;

                sceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        //public void SetVBObjColor(float []colors, string objsType)
        //{
        //    var vboObjs = sceneControl.FindObj(objsType);
        //    vboObjs.PointsColors = colors;
        //}

        private void RenameGroup(string newName, string oldName)
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
            }

        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.ContextMenuStrip != null)
                    e.Node.ContextMenuStrip.Show(e.Location);
            }
            else
            {
                if (e.Node.Tag.ToString() == "5.1")
                    SelectGroup(e.Node.Text);
            }
            treeView.SelectedNode = e.Node;
        }

        private void treeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!treeView.LabelEdit)
                e.CancelEdit = true;
        }

        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null | e.Label.Contains(" ") == true)
                e.CancelEdit = true;
            else
            {
                var parentNode = treeView.SelectedNode.Parent;

                var newName = e.Label;
                var oldName = e.Node.Text;

                if (parentNode.Name == "группыОбъектов")
                {
                    RenameGroup(newName, oldName);
                }
            }

            treeView.LabelEdit = false;
        }

        public void SetModelObjsInfo()
        {
            treeView.BeginUpdate();

            treeView.Nodes["объекты"].Expand();

            treeView.Nodes["объекты"].Nodes.Clear();
            foreach (var objInfo in ModelPresenter)
                CreateNewObjectsNode(objInfo.Key,objInfo.Value.Count());

            treeView.EndUpdate();
        }

        public void SetModelGroupInfo()
        {
            treeView.BeginUpdate();
            treeView.Nodes["группыОбъектов"].Expand();

            treeView.Nodes["группыОбъектов"].Nodes.Clear();

            foreach (var group in Project.Model.GroupData)
                CreateNewGroupNode(group.GroupName,group.ObjType);

            treeView.EndUpdate();
        } 

        public void CreateNewObjectsNode(string objsType, int objsCount)
        {
            var trNode = new TreeNode()
            {
                ContextMenuStrip = object_MenuStrip,
                Name = objsType,
                Text = string.Format("{0} : {1}", objsType, objsCount),

                ImageIndex = imgDict[objsType] == 3 ? 5 : 6,
                SelectedImageIndex = imgDict[objsType] == 3 ? 5 : 6,

                Tag = "4.1"
            };

            treeView.Nodes["объекты"].Nodes.Add(trNode);
        }

        public void CreateNewGroupNode(string grName, string objsType)
        {
            var trNode = new TreeNode()
            {
                Text = grName,
                Name = objsType,
                ImageIndex = imgDict[objsType],
                SelectedImageIndex = imgDict[objsType],
                Tag = "5.1"
            };
            treeView.Nodes["группыОбъектов"].Nodes.Add(trNode);

            if (objsType == "Узлы")
                trNode.ContextMenuStrip = ndGroup_MenuStrip;
            else trNode.ContextMenuStrip = elGroup_MenuStrip;


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
                var selectHelper = new SelectionHelper(project.Model.ObjectData);
                var selectStrip = FindToolStrip<SelectToolStrip>();

                var objsPresenter = ModelPresenter[selectStrip.SelectObjectsType];

                var objs = objsPresenter.GetObjs(sceneControl.SelectionColor).ToList();

                if (selectStrip.SelectObjectsType == "Узлы")
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

                var vboObjs = sceneControl.FindVBObj(selectStrip.SelectObjectsType);
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
                var selectHelper = new SelectionHelper(project.Model.ObjectData);
                var selectStrip = FindToolStrip<SelectToolStrip>();

                var objsPresenter = ModelPresenter[selectStrip.SelectObjectsType];
                var objs = objsPresenter.GetObjs(sceneControl.SelectionColor).ToArray();
                if (objs.Length > 1)
                {
                    if (!arg2.Reverse)
                    {
                        selectHelper.SelectInDirection<Element3D>(10, objs[objs.Length - 2].Number, objs[objs.Length - 1].Number, sceneControl.SelectionColor);
                    }
                    else
                    {
                        selectHelper.SelectInDirection<Element3D>(10, objs[objs.Length - 1].Number, objs[objs.Length - 2].Number, sceneControl.SelectionColor);
                    }
                    var vboObjs = sceneControl.FindVBObj(selectStrip.SelectObjectsType);
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
                    };

                    var measuringControl = new MeasuringSet() { Dock = DockStyle.Fill };
                    measuringControl.PreparingMeasureEvent += MeasuringControl_PreparingMeasureEvent;
                    measuringControl.MakeMeasureEvent += MeasuringControl_MakeMeasureEvent;
                    form.Controls.Add(measuringControl);
                    form.Show();
                }

                else if (e.ClickedItem.Tag.ToString() == "1")
                {
                    var form = new Form() 
                    { Name = "CrossSectionForm", 
                        Text = "Построить сечение", 
                        ShowIcon = false, 
                        Size = new Size(268, 203),
                        TopMost = true
                };
  
                    var crossSection = new CrossSectionControl() { Dock = DockStyle.Fill };
                    form.Controls.Add(crossSection);

                    crossSection.CreatePlaneFromTextArgs += (ar1,ar2) =>
                    {
                        try
                        {
                            var elems3D = project.Model.ObjectData.FindMany("Элементы3D").Cast<Element3D>().ToList();
                            var surfaces = CreateSectionSurfaces(elems3D, ar2.point1, ar2.point2, ar2.point3);


                            if (ar2.ShowModel == false)
                                ClearAllDataOnScene();
                            PresentCrossSection(surfaces, "crossSection");

                        }
                        catch (Exception ex)
                        {
                            ConsoleControl.PrintInfo(ex.Message, Color.Red);
                        }
                    };
                    crossSection.CreatePlaneFromNodesArgs += (ar1,ar2) =>
                    {
                        try
                        {
                            var selectStrip = FindToolStrip<SelectToolStrip>();
                            var objsPresenter = ModelPresenter[selectStrip.SelectObjectsType];
                            var objs = objsPresenter.GetObjs(sceneControl.SelectionColor).ToArray();
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

                            if (ar2 == false)
                                ClearAllDataOnScene();

                            PresentCrossSection(surfaces, "crossSection");

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
                            foreach (var objType in ModelPresenter.Keys)
                                PresentDataToScene(objType);
                        }
                        sceneControl.DisplayObjects();
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

        public virtual void PresentCrossSection(Dictionary<int, Surface> surfaces, string name)
        {
            var modelData = new ModelData();

            foreach (var surface in surfaces)
                modelData.ObjectData.Add(surface.Value);

            var presenter = new ModelScenePresentator(modelData);

            var inds = presenter.CreateVBOIndexes("Поверхность");
            var ptrs = presenter.CreateVBOPointers("Поверхность", inds.Item1);
            var coords = presenter.CreateVBOVertexes("Поверхность", inds.Item2, "координаты");
            var colors = presenter.CreateVBOVertexes("Поверхность", inds.Item3, "цвет");
            var normals = presenter.CreateVBOVertexes("Поверхность", inds.Item2, "нормаль");
            var edges = presenter.CreateVBOEdges("Поверхность", inds.Item4);

            sceneControl.CreateSurfaceVBObjects(ptrs, coords, colors,normals, edges, name);
            sceneControl.DisplayObjects();
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
                            var selectStrip = FindToolStrip<SelectToolStrip>();
                            var objsPresenter = ModelPresenter[selectStrip.SelectObjectsType];
                            var objs = objsPresenter.GetObjs(sceneControl.SelectionColor);

                            if (objs.Count() > 1)
                            {
                                var nodes = objs.Select(x => (Node)x);
                                var p0 = nodes.First();
                                var p1 = nodes.Last();
                                var line = new Line(p0.Position, p1.Position);

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
                            var node = SelectNodeAsync();
                            await node;
                            var calcDistance = new CalcDistance();
                            var line = calcDistance.DistanceBetweenPlaneAndNode(plane.Result, node.Result);
                            consoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);
                            sceneControl.CreateDistance(line);
                            sceneControl.DisplayObjects();
                            break;
                        }
                    case MeasureKind.Path:
                        break;
                    case MeasureKind.Square:
                        {
                            var selectStrip = FindToolStrip<SelectToolStrip>();
                            var square = 0.0f;

                            var objsPresenter = ModelPresenter[selectStrip.SelectObjectsType];
  
                            foreach (var selObj in objsPresenter.GetObjs(sceneControl.SelectionColor))
                            {
                                var sObj = (ISurfaceObject)selObj;
                                square += sObj.GetSurface().First().CalcSquare();
                            }
                            consoleControl.PrintInfo(string.Format("Площадь : {0}", square), Color.Black);
                            break;
                        }

                    case MeasureKind.Volume:
                        {
                            var selectStrip = FindToolStrip<SelectToolStrip>();
                            var vol = 0.0f;

                            var objsPresenter = ModelPresenter[selectStrip.SelectObjectsType];
                            foreach (var selObj in objsPresenter.GetObjs(sceneControl.SelectionColor))
                            {
                                var e3DObj = (IElement3D)selObj;
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
                var selectStrip = FindToolStrip<SelectToolStrip>();
                var objsPresenter = ModelPresenter[selectStrip.SelectObjectsType];
                var selObjs = objsPresenter.GetObjs(sceneControl.SelectionColor);

                if (selObjs.Count() == 0)
                {
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo("Не выбран ни один узел!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    var node = (Node)selObjs.First();
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
                var selectStrip = FindToolStrip<SelectToolStrip>();
                var objsPresenter = ModelPresenter[selectStrip.SelectObjectsType];
                var selObjs = objsPresenter.GetObjs(sceneControl.SelectionColor).ToArray();

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
            sceneControl.HideAllGeometryObjs();
            sceneControl.DisplayObjects();

            var selectStrip = FindToolStrip<SelectToolStrip>();

            switch (arg2.Kind)
            {
                case MeasureKind.DistanceNodeToNode:
                    selectStrip.SelectObjectsType = "Узлы";
                    lblInputCmd.Text = "Выберите два узла";
                    break;
                case MeasureKind.DistanceNodeToPlane:
                    lblInputCmd.Text = "Создайте поверхность и выберите узел";
                    break;
                case MeasureKind.Path:
                    selectStrip.SelectObjectsType = "Узлы";
                    lblInputCmd.Text = "Выберите узлы";
                    break;
                case MeasureKind.Square:
                    selectStrip.SelectObjectsType = "Элементы2D";
                    lblInputCmd.Text = "Выберите элементы 2D или поверхности";
                    break;
                case MeasureKind.Volume:
                    selectStrip.SelectObjectsType = "Элементы3D";
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
                    //sceneControl.ShowBoundaries();
                }

                else if (arg2.ClickedItem.Tag.ToString() == "1")
                {
                    sceneControl.DrawInsideObjects = true;
                    sceneControl.DeleteAllVBObjects();
                    foreach (var objType in ModelPresenter.Keys)
                        PresentDataToScene(objType);
                    consoleControl.PrintInfo("Показаны все объекты", Color.Black);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "2")
                {
                    sceneControl.DrawInsideObjects = false;
                    sceneControl.DeleteAllVBObjects();
                    foreach (var objType in ModelPresenter.Keys)
                        PresentDataToScene(objType);
                    consoleControl.PrintInfo("Скрыты внутренние объекты", Color.Black);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "3")
                {
                    //sceneControl.HideAllVBObjects();

                    foreach (var objsType in sceneControl.GetVBObjsName())
                            sceneControl.ChangeViewModeVBObjects(objsType, ObjView.LinesSurface);

                    //sceneControl.ShowAllVBObjects();
                }

                else if (arg2.ClickedItem.Tag.ToString() == "4")
                {
                    //sceneControl.HideAllVBObjects();

                    foreach (var objsType in sceneControl.GetVBObjsName())
                            sceneControl.ChangeViewModeVBObjects(objsType, ObjView.Lines);

                    //sceneControl.ShowAllVBObjects();
                }

                else if (arg2.ClickedItem.Tag.ToString() == "5")
                {
                    //sceneControl.HideAllVBObjects();

                    foreach (var objsType in sceneControl.GetVBObjsName())
                            sceneControl.ChangeViewModeVBObjects(objsType, ObjView.Surface);

                    //sceneControl.ShowAllVBObjects();
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

        public virtual void sceneControl_CreateMeshGroupEvent(object arg1, EventArgs arg2)
        {
            var selectStrip = FindToolStrip<SelectToolStrip>();

            if(ModelPresenter.ContainsKey(selectStrip.SelectObjectsType))
            {
                var objsPresenter = ModelPresenter[selectStrip.SelectObjectsType];

                var selObjs = objsPresenter.GetObjs(sceneControl.SelectionColor);

                if (selObjs.Count() > 0)
                {
                    var name = $"{selectStrip.SelectObjectsType}_{project.Model.GroupData.Count + 1}";
                    var group = new Group(name, selectStrip.SelectObjectsType);

                    var objsNumbs = selObjs.Select(x => x.Number);
                    group.AddRange(objsNumbs);
                    project.Model.GroupData.Add(group);

                    consoleControl.PrintInfo(string.Format("Создана новая группа {0}", name), Color.Black);

                    foreach (var selObj in selObjs)
                        selObj.SetBackColor();

                    var vboObjs = sceneControl.FindVBObj(selectStrip.SelectObjectsType);
                    var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                    vboObjs.PointsColors = colors;

                    sceneControl.DisplayObjects();

                    SetModelGroupInfo();
                }
            }
                  
        }

        public virtual void sceneControl_DeleteSelectionEvent(object arg1, EventArgs arg2)
        {
            var selectStrip = FindToolStrip<SelectToolStrip>();
            var objsPresenter = ModelPresenter[selectStrip.SelectObjectsType];
            var selObjs = objsPresenter.GetObjs(sceneControl.SelectionColor);

            foreach (var selObj in selObjs)
                selObj.ExistState = false;

            project.Model.ObjectData.Clear();

            var groups = project.Model.GroupData.FindMany(selectStrip.SelectObjectsType);

            var objsNumbers = selObjs.Select(x => x.Number);
            foreach (var group in groups)
            {
                var exceptNumbers = group.ObjsNumbers.Except(objsNumbers).ToArray();
                group.Clear();
                group.AddRange(exceptNumbers);
            }

            var vbObj = sceneControl.FindVBObj(selectStrip.SelectObjectsType);
            var viewMode = vbObj.ViewMode;

            sceneControl.DeleteVBObjects(selectStrip.SelectObjectsType);

            PresentDataToScene(selectStrip.SelectObjectsType);

            sceneControl.ChangeViewModeVBObjects(selectStrip.SelectObjectsType, viewMode);
            sceneControl.DisplayObjects();

            SetModelObjsInfo();
            SetModelGroupInfo();
        }

        private void sceneControl_InfoObjectsEvent(object arg1, EventArgs arg2)
        {
            try
            {
                var selectStrip = FindToolStrip<SelectToolStrip>();
                var objsPresenter = ModelPresenter[selectStrip.SelectObjectsType];
                var selObjs = objsPresenter.GetObjs(sceneControl.SelectionColor);

                consoleControl.PrintInfo($"Выбраны {selectStrip.SelectObjectsType} {selObjs.Count()}", Color.Black);

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

        private void WebPageLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(webPageLabel.Text); //где path это путь к сайту
        }

        private void grbConsole_Paint(object sender, PaintEventArgs e)
        {
            var control = (Control)sender;
            e.Graphics.DrawString("Консоль", Font, new SolidBrush(System.Drawing.Color.Black), 16, 0);
            PaintCloseRectangle(control, e);
        }

        public void ShowNavigator()
        {
            splitContainer1.Panel1Collapsed = false;
        }

        public void ShowConsole()
        {
            splitContainer2.Panel2Collapsed = false;
        }


        public virtual void UnBlockInterface(bool status)
        {
            var toolStr = FindToolStrip<StandartToolStrip>();
            //toolStr.Enabled = true;

            toolStr.Items[2].Enabled = status;
            toolStr.Items[3].Enabled = status;

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
            ModelPresenter = new ModelScenePresentator(project.Model);

            menuItems = new List<ToolStripMenuItem>();

            grbNavigator.MouseClick += grbNavigator_MouseClick;
            grbConsole.MouseClick += grbConsole_MouseClick;

            var standartToolStrip = new StandartToolStrip();
            var viewToolStrip = new ViewToolStrip();
            var selectToolStrip = new SelectToolStrip();
            var displayToolStrip = new DisplayToolStrip();
            var instrumentalToolStrip = new InstrumentToolStrip();

            toolStripContainer.TopToolStripPanel.Join(selectToolStrip, 0);
            toolStripContainer.TopToolStripPanel.Join(displayToolStrip, 0);
            toolStripContainer.TopToolStripPanel.Join(viewToolStrip, 0);
            toolStripContainer.TopToolStripPanel.Join(instrumentalToolStrip, 0);
            toolStripContainer.TopToolStripPanel.Join(standartToolStrip, 0);

            standartToolStrip.Renderer = new ToolStrips.BtnToolStrRender();
            standartToolStrip.ItemClicked += StandartToolStrip_ItemClicked;

            selectToolStrip.Renderer = new ToolStrips.BtnToolStrRender();
            selectToolStrip.SelectObjectEvent += SelectToolStrip_SelectObjectEvent;
            selectToolStrip.ItemClicked += SelectToolStrip_ItemClicked;

            displayToolStrip.Renderer = new ToolStrips.BtnToolStrRender();
            displayToolStrip.ItemClicked += DisplayToolStrip_ItemClick;

            viewToolStrip.Renderer = new ToolStrips.BtnToolStrRender();
            viewToolStrip.ItemClicked += ViewToolStrip_ItemClicked;

            instrumentalToolStrip.Renderer = new ToolStrips.BtnToolStrRender();
            instrumentalToolStrip.ItemClicked += InstrumentalToolStrip_ItemClicked;
        }

        private void grbScene_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Сцена", Font, new SolidBrush(System.Drawing.Color.Black), 16, 0);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            grbNavigator.Invalidate();
        }

        private void sceneControl_ShowAllHiddenObjectsEvent(object arg1, EventArgs arg2)
        {
            foreach (var objsName in ModelPresenter.Keys)
            {
                var nodes = treeView.Nodes[4].Nodes.Find(objsName, true);
                if(nodes.Length > 0)
                {
                    nodes[0].ImageIndex = imgDict[objsName] == 3 ? 5 : 6;
                    nodes[0].SelectedImageIndex = imgDict[objsName] == 3 ? 5 : 6;
                }

                var presenter = ModelPresenter[objsName];

                foreach (var modelObject in presenter.GetObjs())
                    modelObject.ViewState = true;

                var vbobj = sceneControl.FindVBObj(objsName);
                var viewMode = vbobj.ViewMode;

                sceneControl.DeleteVBObjects(objsName);

                PresentDataToScene(objsName);

                sceneControl.ChangeViewModeVBObjects(objsName, viewMode);

            }
            sceneControl.DisplayObjects();
        }

        public void SwitchOffAllObjects()
        {
            foreach (var objsName in sceneControl.GetVBObjsName())
            {
                treeView.Nodes[4].Nodes[objsName].ImageIndex = imgDict[objsName];
                treeView.Nodes[4].Nodes[objsName].SelectedImageIndex = imgDict[objsName];
                if (sceneControl.IsVBObjectShown(objsName))
                    sceneControl.SwitchOffVBObject(objsName);
            }
        }

        //public void SwitchOnObjects(string objsName)
        //{
        //    treeView.Nodes[4].Nodes[objsName].ImageIndex = imgDict[objsName] == 3 ? 5 : 6;
        //    treeView.Nodes[4].Nodes[objsName].SelectedImageIndex = imgDict[objsName] == 3 ? 5 : 6;

        //    sceneControl.SwitchOnVBObject(objsName);
        //}

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

                        foreach (var modelObject in Project.Model.ObjectData.FindMany("Узлы"))
                            modelObject.ViewState = false;

                        foreach (var freeNode in freeNodes)
                            Project.Model.ObjectData.Find(freeNode).ViewState = true;

                        SwitchOffAllObjects();

                        sceneControl.DeleteVBObjects("Узлы");
                        PresentDataToScene("Узлы");

                        sceneControl.DisplayObjects();
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
                        foreach (var objType in ModelPresenter.Keys)
                            PresentDataToScene(objType);
                        sceneControl.DisplayObjects();
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

        private void ребраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sceneControl.ChangeViewModeVBObjects(treeView.SelectedNode.Name, ObjView.Lines);
            sceneControl.DisplayObjects();
        }

        private void поверхностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sceneControl.ChangeViewModeVBObjects(treeView.SelectedNode.Name, ObjView.Surface);
            sceneControl.DisplayObjects();
        }

        private void ребраИПоверхностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sceneControl.ChangeViewModeVBObjects(treeView.SelectedNode.Name, ObjView.LinesSurface);
            sceneControl.DisplayObjects();
        }
        private void InfoGroup_Click(object sender, EventArgs e)
        {
            var group = Project.Model.GroupData[treeView.SelectedNode.Index];
            consoleControl.PrintInfo(group.ToString(), Color.Black);
        }

        private async void EditGroup_Click(object sender, EventArgs e) //
        {
            //ChangeGroupEvent(this, new GroupEvArgs(treeView.SelectedNode.Name, treeView.SelectedNode.Index));

            var group = Project.Model.GroupData.Find(treeView.SelectedNode.Text);
            var selToolStrip = FindToolStrip<SelectToolStrip>();
            selToolStrip.SelectObjectsType = group.ObjType;

            var objsPresenter = ModelPresenter[selToolStrip.SelectObjectsType];
            //SelectToolStrip.SelectObjectsType = group.ObjType;

            foreach (var objNumber in group.ObjsNumbers)
                objsPresenter.FindObj(objNumber).MasterColor = sceneControl.SelectionColor;

            var vboObjs = sceneControl.FindVBObj(selToolStrip.SelectObjectsType);
            var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
            vboObjs.PointsColors = colors;

            sceneControl.DisplayObjects();

            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                if (objsPresenter.GetObjs(sceneControl.SelectionColor).Count() == 0)
                {
                    Invoke(new Action(() => {
                        ConsoleControl.PrintInfo("Не выбран ни один объект!", Color.Black);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    group.Clear();
                    var objsNumbs = objsPresenter.GetObjs(sceneControl.SelectionColor).Select(x => x.Number);
                    group.AddRange(objsNumbs);
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

        private void RenameGroup_Click(object sender, EventArgs e)
        {
            treeView.LabelEdit = true;
            treeView.SelectedNode.BeginEdit();
        }

        private void ShowGroupWithNodes_Click(object sender, EventArgs e)
        {
            var group = Project.Model.GroupData[treeView.SelectedNode.Index];

            foreach (var number in group.ObjsNumbers)
            {
                var obj = (IElement)ModelPresenter[group.ObjType].FindObj(number);
                obj.ViewState = true;

                foreach (var node in obj.GetNodes())
                    node.ViewState = true;

            }

            sceneControl.DeleteVBObjects("Узлы");
            PresentDataToScene("Узлы");

            treeView.Nodes[4].Nodes["Узлы"].ImageIndex = 5;
            treeView.Nodes[4].Nodes["Узлы"].SelectedImageIndex = 5;


            var vbobj = sceneControl.FindVBObj(treeView.SelectedNode.Name);
            var viewMode = vbobj.ViewMode;

            sceneControl.DeleteVBObjects(treeView.SelectedNode.Name);
            PresentDataToScene(treeView.SelectedNode.Name);
            sceneControl.ChangeViewModeVBObjects(treeView.SelectedNode.Name, viewMode);

            treeView.Nodes[4].Nodes[treeView.SelectedNode.Name].ImageIndex = imgDict[treeView.SelectedNode.Name] == 3 ? 5 : 6;
            treeView.Nodes[4].Nodes[treeView.SelectedNode.Name].SelectedImageIndex = imgDict[treeView.SelectedNode.Name] == 3 ? 5 : 6;

            sceneControl.DisplayObjects();
        }

        private void ShowAllGroups_Click(object sender, EventArgs e)
        {
            foreach (var group in Project.Model.GroupData)
            {
                foreach (var number in group)
                {
                    ModelPresenter[group.ObjType].FindObj(number).ViewState = true;
                }
            }

            foreach (var item in ModelPresenter)
            {
                var vbobj = sceneControl.FindVBObj(item.Key);
                var viewMode = vbobj.ViewMode;

                sceneControl.DeleteVBObjects(item.Key);
                PresentDataToScene(item.Key);
                sceneControl.ChangeViewModeVBObjects(item.Key, viewMode);

                treeView.Nodes[4].Nodes[item.Key].ImageIndex = imgDict[item.Key] == 3 ? 5 : 6;
                treeView.Nodes[4].Nodes[item.Key].SelectedImageIndex = imgDict[item.Key] == 3 ? 5 : 6;
            }

            sceneControl.DisplayObjects();
        }

        private void ShowGroup_Click(object sender, EventArgs e)
        {
            var group = Project.Model.GroupData[treeView.SelectedNode.Index];

            foreach (var number in group.ObjsNumbers)
                ModelPresenter[group.ObjType].FindObj(number).ViewState = true;


            var vbobj = sceneControl.FindVBObj(treeView.SelectedNode.Name);
            var viewMode = vbobj.ViewMode;

            sceneControl.DeleteVBObjects(treeView.SelectedNode.Name);
            PresentDataToScene(treeView.SelectedNode.Name);
            sceneControl.ChangeViewModeVBObjects(treeView.SelectedNode.Name, viewMode);


            treeView.Nodes[4].Nodes[group.ObjType].ImageIndex = imgDict[group.ObjType] == 3 ? 5 : 6;
            treeView.Nodes[4].Nodes[group.ObjType].SelectedImageIndex = imgDict[group.ObjType] == 3 ? 5 : 6;

            sceneControl.DisplayObjects();
        }

        private void HideGroup_Click(object sender, EventArgs e)
        {
            var group = Project.Model.GroupData[treeView.SelectedNode.Index];

            foreach (var number in group.ObjsNumbers)
                ModelPresenter[group.ObjType].FindObj(number).ViewState = false;

            var vbobj = sceneControl.FindVBObj(treeView.SelectedNode.Name);
            var viewMode = vbobj.ViewMode;

            sceneControl.DeleteVBObjects(treeView.SelectedNode.Name);
            PresentDataToScene(treeView.SelectedNode.Name);
            sceneControl.ChangeViewModeVBObjects(treeView.SelectedNode.Name, viewMode);

            sceneControl.DisplayObjects();
        }

        public void ShowObjects_Click(object sender, EventArgs e)
        {
            if(ModelPresenter.ContainsKey(treeView.SelectedNode.Name))
            {
                var presenter = ModelPresenter[treeView.SelectedNode.Name];

                foreach (var modelObject in presenter.GetObjs())
                    modelObject.ViewState = true;

                var vbobj = sceneControl.FindVBObj(treeView.SelectedNode.Name);
                var viewMode = vbobj.ViewMode;

                sceneControl.DeleteVBObjects(treeView.SelectedNode.Name);
                PresentDataToScene(treeView.SelectedNode.Name);
                sceneControl.ChangeViewModeVBObjects(treeView.SelectedNode.Name, viewMode);

                treeView.SelectedNode.ImageIndex = imgDict[treeView.SelectedNode.Name] == 3 ? 5 : 6;
                treeView.SelectedNode.SelectedImageIndex = imgDict[treeView.SelectedNode.Name] == 3 ? 5 : 6;

                sceneControl.DisplayObjects();
            }

        }

        private void HideObjects_Click(object sender, EventArgs e)
        {
            var modelObjects = Project.Model.ObjectData.FindMany(treeView.SelectedNode.Name);
            foreach (var modelObject in modelObjects)
                modelObject.ViewState = false;

            treeView.Nodes[4].Nodes[treeView.SelectedNode.Name].ImageIndex = imgDict[treeView.SelectedNode.Name];
            treeView.Nodes[4].Nodes[treeView.SelectedNode.Name].SelectedImageIndex = imgDict[treeView.SelectedNode.Name];

            var vbobj = sceneControl.FindVBObj(treeView.SelectedNode.Name);
            var viewMode = vbobj.ViewMode;

            sceneControl.DeleteVBObjects(treeView.SelectedNode.Name);
            PresentDataToScene(treeView.SelectedNode.Name);
            sceneControl.ChangeViewModeVBObjects(treeView.SelectedNode.Name, viewMode);

            sceneControl.DisplayObjects();
        }

        private void ShowAllObjects_Click(object sender, EventArgs e)
        {
            foreach (var item in ModelPresenter)
            {
                foreach (var modelObject in item.Value.GetObjs())
                    modelObject.ViewState = true;

                var vbobj = sceneControl.FindVBObj(item.Key);
                var viewMode = vbobj.ViewMode;

                sceneControl.DeleteVBObjects(item.Key);
                PresentDataToScene(item.Key);
                sceneControl.ChangeViewModeVBObjects(item.Key, viewMode);

                treeView.Nodes[4].Nodes[item.Key].ImageIndex = imgDict[item.Key] == 3 ? 5 : 6;
                treeView.Nodes[4].Nodes[item.Key].SelectedImageIndex = imgDict[item.Key] == 3 ? 5 : 6;
            }

            sceneControl.DisplayObjects();
        }

        private void HideAllObjects_Click(object sender, EventArgs e)
        {
            foreach (var item in ModelPresenter)
            {
                foreach (var modelObject in item.Value.GetObjs())
                    modelObject.ViewState = false;

                treeView.Nodes[4].Nodes[item.Key].ImageIndex = imgDict[item.Key];
                treeView.Nodes[4].Nodes[item.Key].SelectedImageIndex = imgDict[item.Key];

                var vbobj = sceneControl.FindVBObj(item.Key);
                var viewMode = vbobj.ViewMode;

                sceneControl.DeleteVBObjects(item.Key);
                PresentDataToScene(item.Key);
                sceneControl.ChangeViewModeVBObjects(item.Key, viewMode);
            }

            sceneControl.DisplayObjects();
        }

        private void HideAllGroups_Click(object sender, EventArgs e)
        {
            foreach (var group in Project.Model.GroupData)
            {
                foreach (var objNumber in group)
                {
                    Project.Model.ObjectData.Find(objNumber).ViewState = false;
                }
            }

            foreach (var item in ModelPresenter)
            {
                var vbobj = sceneControl.FindVBObj(item.Key);
                var viewMode = vbobj.ViewMode;

                sceneControl.DeleteVBObjects(item.Key);
                PresentDataToScene(item.Key);
                sceneControl.ChangeViewModeVBObjects(item.Key, viewMode);
            }

            sceneControl.DisplayObjects();
        }

        private void DelAllObjects_Click(object sender, EventArgs e)
        {
            treeView.SelectedNode.Nodes.Clear();

            foreach (var obj in Project.Model.ObjectData)
                obj.ExistState = false;
            DeleteAllGroups();

            foreach (var objType in ModelPresenter.Keys)
                PresentDataToScene(objType);

            sceneControl.DisplayObjects();
        }

        private void DelAllGroups_Click(object sender, EventArgs e)
        {
            treeView.SelectedNode.Nodes.Clear();
            DeleteAllGroups();
        }

        private void DeleteAllGroups()
        {
            var valData = Project.TaskData.Where(x => x is IValuableData).Select(x => (IValuableData)x).ToList();
            foreach (var group in Project.Model.GroupData)
            {
                var selData = valData.Where(x => x.GroupName == group.GroupName);

                foreach (Data data in selData)
                    Project.TaskData.Remove(data);
            }

            Project.Model.GroupData.Clear();
        }

        private void DelObjects_Click(object sender, EventArgs e)
        {
            DeleteObjects(treeView.SelectedNode.Name);
            treeView.Nodes["объекты"].Nodes.Remove(treeView.SelectedNode);
        }

        private void DelGroup_Click(object sender, EventArgs e)
        {
            DeleteGroup(treeView.SelectedNode.Name, treeView.SelectedNode.Index);
            treeView.Nodes["группыОбъектов"].Nodes.Remove(treeView.SelectedNode);
        }

        private void DeleteGroup(string objsType, int groupIndex)
        {
            Project.Model.GroupData.RemoveAt(groupIndex);

            var valData = Project.TaskData.Where(x => x is IValuableData).Select(x => (IValuableData)x).
                Where(x => x.GroupName == objsType).ToArray();

            foreach (Data data in valData)
                Project.TaskData.Remove(data);
        }

        private void DeleteObjects(string objsType)
        {
            Project.Model.ObjectData.RemoveRange(objsType);

            var searchGroups = Project.Model.GroupData.FindMany(objsType).ToArray();

            foreach (var searchGroup in searchGroups)
            {
                Project.Model.GroupData.Remove(searchGroup);
            }

            var selectToolStrip = FindToolStrip<SelectToolStrip>();
            selectToolStrip.RemoveObjectsType(objsType);
            SetModelGroupInfo();

            ModelPresenter = new ModelScenePresentator(Project.Model);

            foreach (var objType in ModelPresenter.Keys)
                PresentDataToScene(objType);

            sceneControl.DisplayObjects();
        }

        private void sceneControl_SelectObjectsEvent(object arg1, SelectObjectsEventArgs arg2)
        {
            var tls = FindToolStrip<SelectToolStrip>();
            if (ModelPresenter.ContainsKey(tls.SelectObjectsType))
            {
                var selection = SearchObjects(tls.SelectObjectsType, arg2.SelectionBox);

                if (arg2.IsSorted)
                {
                    selection = selection.OrderByDescending(x => x.Value._z).ToDictionary(x => x.Key, x => x.Value);
                }
                var objsPresenter = ModelPresenter[tls.SelectObjectsType];

                foreach (var index in selection)
                    if (arg2.IsSelected)
                        objsPresenter[index.Key].MasterColor = sceneControl.SelectionColor;
                    else
                        objsPresenter[index.Key].SetBackColor();

                var vboObjs = sceneControl.FindVBObj(tls.SelectObjectsType);
                var colors = objsPresenter.CreateVertexes(vboObjs.ColorLength, "цвет");
                vboObjs.PointsColors = colors;

                sceneControl.DisplayObjects();
            }
        }

        public Dictionary<int, Point3D> SearchObjects(string objType, SelectionBox selectionBox)
        {
            var camera = sceneControl.Camera;

            var objsPresenter = ModelPresenter[objType];
            var selections = new Dictionary<int, Point3D>();

            for (int i = 0; i < objsPresenter.Count(); i++)
            {
                var scrPoints = new Point2D[objsPresenter[i].NumberOfPoints];
                var scnPoints = new Point3D[objsPresenter[i].NumberOfPoints];

                var pointCounter = 0;
                foreach (var point in objsPresenter[i].GetPoints())
                {
                    var scnPoint = camera.GetSceenCoord(point);
                    scnPoints[pointCounter] = scnPoint;

                    var scrPoint = camera.GetScreenCoord(scnPoint);
                    scrPoints[pointCounter] = scrPoint;

                    pointCounter++;
                }

                if (selectionBox.IsPointsInside(scrPoints))
                    selections.Add(i, objsPresenter[i].CalcCentralPoint());
            }
            return selections;
        }

        private void sceneControl_HideSelectedObjectsEvent(object arg1, EventArgs arg2)
        {
            var tls = FindToolStrip<SelectToolStrip>();
            var objsPresenter = ModelPresenter[tls.SelectObjectsType].GetObjs(sceneControl.SelectionColor);

            foreach (var obj in objsPresenter)
            {
                if (obj.MasterColor == sceneControl.SelectionColor)
                    obj.ViewState = false;
            }         

            var vbObj = sceneControl.FindVBObj(tls.SelectObjectsType);
            var viewMode = vbObj.ViewMode;

            sceneControl.DeleteVBObjects(tls.SelectObjectsType);

            PresentDataToScene(tls.SelectObjectsType);

            sceneControl.ChangeViewModeVBObjects(tls.SelectObjectsType, viewMode);
            sceneControl.DisplayObjects();
        }

        private void sceneControl_SetBackColorEvent(object arg1, EventArgs arg2)
        {
            SetBackColorToAllObjects();
            sceneControl.DisplayObjects();
        }
    }
}
