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
using ProjectController.IO;
using ModelController.IO;
using ModelController.MeshObjsUtility;
using Model.GroupsData;
using Scene.Events;
using ModelController;
using System.Diagnostics;
using BaseModule.Console;
using BaseModule.CrossSection;

namespace BaseModule
{
    public partial class BasePage : UserControl
    {
        private ProjectData project;
        public Action<object, ProjectData> ChangeProjectDataEvent;

        List<ToolStripMenuItem> menuItems;

        public Keys PressedKey { get; set; }

        public ProjectData Project
        {
            get { return project; }
            set { project = value; }
        }

        [Category("TreeView")]
        [Description("Set imageIndex for expand node")]
        public int ExpandIndex { get; set; }

        [Category("TreeView")]
        [Description("Set imageIndex for collapse node")]
        public int CollapseIndex { get; set; }

        [Category("TreeView")]
        [Description("Set imageIndex for project info nodes")]
        public int ProjectInfoIndex { get; set; }

        public BasePage()
        {
            InitializeComponent();
        }

        public void SceneInitialization()
        {
            pctScreenSaver.Hide();

            sceneControl.BringToFront();
            sceneControl.Initialization();

            PresentProjectOnTree();

            PresentModelOnSelectToolStrip();

            var presenter = new ModelScenePresentator(project.Model);
            sceneControl.SetPresentor(presenter);

            PresentAllModelObjectsOnScene();

            sceneControl.FitObjectsToScreen();
            sceneControl.DisplayObjects();
        }

        public void AddToolStrip(ToolStrip toolStrip)
        {
            toolStripContainer.TopToolStripPanel.Join(toolStrip, 1);
        }

        public TreeView TreeView
        {
            get
            {
                return treeView;
            }
        }

        public SceneControl SceneControl
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
            throw new Exception("Интерфейс не реализован!");
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

        public void FindVersion(string version)
        {
            lblVersion.Text = version;
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

        public void PrintCommand(string message)
        {
            lblInputCmd.Text = message;
        }

        public void PresentModelObjectsOnScene(string objectsType)
        {
            sceneControl.UnPlugVBObjects();
            sceneControl.DeleteVBObjects(objectsType);

            sceneControl.CreateVBObjects(objectsType);
            sceneControl.PlugVBObjects();
        }

        public void PresentAllModelObjectsOnScene()
        {
            sceneControl.UnPlugVBObjects();
            sceneControl.DeleteAllVBObjects();

            sceneControl.CreateVBObjects();
            sceneControl.PlugVBObjects();
        }

        private void grbNavigator_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Навигатор", Font, new SolidBrush(System.Drawing.Color.Black), 16, 0);
            PaintCloseRectangle((Control)sender, e);
        }

        private void PaintCloseRectangle(Control control, PaintEventArgs e)
        {
            var textSize = TextRenderer.MeasureText(control.Text, this.Font).Width;
            var locRect = new Point(control.Width - 16, 3);
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
            var rect = new Rectangle(locRect, new Size(8, 8));

            e.Graphics.DrawRectangle(blackPen, rect);
            e.Graphics.DrawString("х", Font, new SolidBrush(System.Drawing.Color.Black), control.Width - 16, 0);
        }

        private void grbNavigator_MouseClick(object sender, MouseEventArgs e)
        {
            var grb = (Panel)sender;
            var textSize = TextRenderer.MeasureText(grb.Text, this.Font).Width;
            if (e.Location.X > grb.Width - 16 & e.Location.X < grb.Width - 8 && e.Location.Y <= 10)
                splitContainer1.Panel1Collapsed = true;
        }

        private void grbConsole_MouseClick(object sender, MouseEventArgs e)
        {
            var grb = (Panel)sender;
            var textSize = TextRenderer.MeasureText(grb.Text, this.Font).Width;
            if (e.Location.X > grb.Width - 16 & e.Location.X < grb.Width - 8 && e.Location.Y <= 10)
                splitContainer2.Panel2Collapsed = true;
        }

        private void StandartToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag.ToString() == "0")
            {
                project = new ProjectData("newProject", Environment.CurrentDirectory);
                consoleControl.PrintInfo("Создан новый проект", Color.Black);

                PresentProjectOnTree();
                PresentModelOnSelectToolStrip();
                ClearAllDataOnScene();
                sceneControl.DisplayObjects();

                lblInputCmd.Text = "Начните работу с загрузки проекта или импорта сеточной модели";
            }

            else if (e.ClickedItem.Tag.ToString() == "1")
            {
                var filterProject = "Bazis project file(*.bpf)|*.bpf|" +
            "All files(*.*)|*.*";
                LoadProjectData(filterProject);
            }
            else if (e.ClickedItem.Tag.ToString() == "2")
            {
                SaveProjectData("bpf");
            }
            else if (e.ClickedItem.Tag.ToString() == "3")
            {
                var form = new Form() { Name = "helpForm", Text = "Справка", ShowIcon = false, Size = new Size(555, 283) };
                form.TopMost = true;
                var helpFile = Directory.GetFiles(Application.StartupPath, "ПО Bazis. Руководство пользователя.chm", SearchOption.AllDirectories);

                if (helpFile.Count() != 0)
                    Help.ShowHelp(form, helpFile[0]);
                else MessageBox.Show("Отсутствует файл справки!");
            }
            else if (e.ClickedItem.Tag.ToString() == "4")
            {
                var filterMesh = "Visual-Mesh ESI Group(*.ASC)|*.ASC|" +
"GMSH(*.inp*)|*.inp";
                LoadProjectData(filterMesh);
            }
        }

        public void LoadProjectData(string extFilter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = extFilter;
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            project = new ProjectData("newProject", Environment.CurrentDirectory);
            consoleControl.PrintInfo("Создан новый проект", Color.Black);

            var ext = Path.GetExtension(dialog.FileName);
            if (ext == ".bpf")
            {
                var loader = new LoadProjectFromTextFormat();
                loader.LoadEvent += (ar1, ar2) => { consoleControl.PrintInfo(ar2.Message, Color.Black); };

                var projectLoad = loader.Load(dialog.FileName);
                project.Load(projectLoad);
            }
            else if (ext == ".inp")
            {
                var loader = new LoadModelFromGMSHTextFile();
                loader.LoadEvent += (ar1, ar2) => { consoleControl.PrintInfo(ar2.Message, Color.Black); };

                var modelINP = loader.Load(dialog.FileName);
                project.Model.Load(modelINP);
            }
            else if (ext == ".ASC")
            {
                var loader = new LoadModelFromASCIITextFile();
                loader.LoadEvent += (ar1, ar2) => { consoleControl.PrintInfo(ar2.Message, Color.Black); };

                var modelASCII = loader.Load(dialog.FileName);
                project.Model.Load(modelASCII);
            }

            lblInputCmd.Text = string.Empty;

            ChangeProjectDataEvent(this, project);

            SceneInitialization();
        }

        public bool SaveProjectData(string extFilter)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.DefaultExt = extFilter;

            if (saveDialog.ShowDialog() == DialogResult.Cancel)
                return false;
            project.Path = Path.GetDirectoryName(saveDialog.FileName);
            project.Name = Path.GetFileName(saveDialog.FileName);
            saveDialog.Dispose();

            var saver = new SaveProjectTextFormat();
            saver.SaveEvent += (ar1, ar2) => { consoleControl.PrintInfo(ar2.Message, Color.Black); };
            saver.Save(project);

            PresentProjectOnTree();
            sceneControl.DisplayObjects();

            consoleControl.PrintInfo("Проект сохранен в " + project.Path, Color.Black);
            return true;
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
        }

        public void ClearAllDataOnScene()
        {
            sceneControl.UnPlugVBObjects();
            sceneControl.UnPlugGeometryObjs();
            sceneControl.UnPlugDisplayText3D();
            sceneControl.DeleteAllVBObjects();
        }

        private void SelectToolStrip_SelectObjectEvent(object arg1, SelectObjectEventArgs arg2)
        {
            sceneControl.SelectionType = arg2.ObjsType;

            sceneControl.SetBackColorToAll_VBObjects();
            sceneControl.DisplayObjects();
        }

        private void SelectToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem is ToolStripButton btn)
                if (!btn.Checked)
                {
                    var selectToolStrip = FindToolStrip<SelectToolStrip>();
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
                            selectToolStrip.SelectObjectsType = "Узлы";
                            lblInputCmd.Text = "Выберите два узла для направления или три для плоскости";
                        };
                        selectionControl.SelectElements += (s1, s2) =>
                        {
                            selectToolStrip.SelectObjectsType = "Элементы2D";
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
            var selector = new SelectionHelper(project.Model.ObjectData);

            var objs = sceneControl.GetSelectedObjects().ToArray();
            var selectToolStrip = FindToolStrip<SelectToolStrip>();

            if (selectToolStrip.SelectObjectsType == "Узлы")
            {
                if (objs.Length > 2)
                {
                    var n1 = (Node)project.Model.ObjectData.Find(objs[0]);
                    var n2 = (Node)project.Model.ObjectData.Find(objs[1]);
                    var n3 = (Node)project.Model.ObjectData.Find(objs[2]);

                    var plane = new Plane(n1.Position, n2.Position, n3.Position);
                    selector.SelectInPlane<Node>(plane, sceneControl.SelectionColor);
                }
            }
            else
            {
                if (objs.Length > 0)
                {
                    var element = project.Model.ObjectData.Find(objs.Last());
                    selector.SelectInPlane<Element2D>(arg2.Angle, element.Number, sceneControl.SelectionColor);
                }
            }
            sceneControl.ChangeColorsVBObjects(sceneControl.SelectionType);

            sceneControl.DisplayObjects();

        }

        private void SelectionControl_SelectInDirection(object arg1, SelectInDirectionEventArgs arg2)
        {
            try
            {
                var selector = new SelectionHelper(project.Model.ObjectData);

                var objs = sceneControl.GetSelectedObjects().ToArray();
                if (objs.Length > 1)
                {
                    if (!arg2.Reverse)
                    {
                        selector.SelectInDirecion<Element3D>(10, objs[objs.Length - 2], objs[objs.Length - 1], sceneControl.SelectionColor);
                    }
                    else
                    {
                        selector.SelectInDirecion<Element3D>(10, objs[objs.Length - 1], objs[objs.Length - 2], sceneControl.SelectionColor);
                    }
                    sceneControl.ChangeColorsVBObjects(sceneControl.SelectionType);

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
                    measuringControl.MakeMeasureEvent += MeasuringControl_MakeMeasureEvent; ;
                    form.Controls.Add(measuringControl);
                    form.Show();
                }

                else if (e.ClickedItem.Tag.ToString() == "1")
                {
                    sceneControl.SelectionType = "Узлы";
                    var form = new Form() { Name = "CrossSectionForm", Text = "Построить сечение", ShowIcon = false, Size = new Size(268, 203) };
                    form.TopMost = true;
                    
                    var crossSection = new CrossSectionControl() { Dock = DockStyle.Fill };
                    form.Controls.Add(crossSection);

                    crossSection.CreatePlaneFromTextArgs += CrossSection_CreatePlane;
                    crossSection.CreatePlaneFromNodesArgs += CrossSection_CreatePlaneFromNodesArgs;
                    
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

        private void CrossSection_CreatePlaneFromNodesArgs(object arg1)
        {
            int counter = 0;
            ModelData modelData = new ModelData();
            List<Node> tempNodes = new List<Node>();
            var elems3D = project.Model.ObjectData.FindMany("Элементы3D").Cast<Element3D>().ToList();

            var selObjsNumbers = sceneControl.GetSelectedObjects().ToArray();
            if (selObjsNumbers.Length != 3)
            {
                consoleControl.PrintInfo("Ошибка, выбрано неверное количество узлов", Color.Red);
            }
            var p0 = (Node)project.Model.ObjectData.Find(selObjsNumbers[selObjsNumbers.Length - 3]);
            var p1 = (Node)project.Model.ObjectData.Find(selObjsNumbers[selObjsNumbers.Length - 2]);
            var p2 = (Node)project.Model.ObjectData.Find(selObjsNumbers[selObjsNumbers.Length - 1]);

            var plane = new Plane(p0.Position, p1.Position, p2.Position);

            var getCrossPoints = new GetCrossPoints();
            Dictionary<int, List<Point3D>> dic = getCrossPoints.CreateCrossNodes(elems3D, plane);

            foreach (var element in dic.Values)
            {
                if (element.Count > 0)
                {
                    for (int i = 0; i < element.Count; i++)
                    {
                        tempNodes.Add(new Node(counter, element[i]));
                        tempNodes.Last().MasterColor = Color.Red;
                        counter++;
                    }
                }
            }
            modelData.ObjectData.AddRange(tempNodes);
            var presenter = new ModelScenePresentator(modelData);
            sceneControl.SetPresentor(presenter);
            sceneControl.PlugVBObjects();
            sceneControl.DisplayObjects();
        }

        private void CrossSection_CreatePlane(object arg1, CreatePlaneFromTextArgs arg2)
        {
            int counter = 0;
            List<Node> tempNodes = new List<Node>();

            var elems3D = project.Model.ObjectData.FindMany("Элементы3D").Cast<Element3D>().ToList();
            var plane = new Plane(arg2.point1, arg2.point2,arg2.point3);

            var getCrossPoints = new GetCrossPoints();
            Dictionary<int, List<Point3D>> dic = getCrossPoints.CreateCrossNodes(elems3D, plane);

            foreach (var element in dic.Values)
            {
                if (element.Count > 0)
                {
                    for (int i = 0; i < element.Count; i++)
                    {
                        tempNodes.Add(new Node(counter, element[i]));
                        tempNodes.Last().MasterColor = Color.Red;
                        counter++;
                    }
                }
            }
            ClearAllDataOnScene();
            ModelData modelData = new ModelData();

            modelData.ObjectData.AddRange(tempNodes);
            var presenter = new ModelScenePresentator(modelData);

            sceneControl.SetPresentor(presenter);
            sceneControl.CreateVBObjects("Узлы");
            
            sceneControl.PlugVBObjects();
            sceneControl.DisplayObjects();
            

        }

        private void MeasuringControl_MakeMeasureEvent(object arg1, MeasureEventArgs arg2)
        {
            var selObjsNumbers = sceneControl.GetSelectedObjects().ToArray();
            switch (arg2.Kind)
            {
                case MeasureKind.DistanceNodeToNode:

                    if (selObjsNumbers.Length > 1)
                    {
                        var p0 = (Node)project.Model.ObjectData.Find(selObjsNumbers[selObjsNumbers.Length - 2]);
                        var p1 = (Node)project.Model.ObjectData.Find(selObjsNumbers[selObjsNumbers.Length - 1]);
                        var line = new Line(p0.Position, p1.Position);
                        sceneControl.CreateDistance(line);
                        sceneControl.DisplayObjects();
                    }
                    else consoleControl.PrintInfo("Узлы не выбраны", Color.Red);
                    break;
                case MeasureKind.DistanceNodeToPlane:
                    break;
                case MeasureKind.Path:
                    break;
                case MeasureKind.Square:
                    var square = 0.0f;
                    foreach (var selObjsNumber in selObjsNumbers)
                    {
                        var sObj = (ISurfaceObject)project.Model.ObjectData.Find(selObjsNumber);
                        square += sObj.GetSurface().First().CalcSquare();
                    }
                    consoleControl.PrintInfo(string.Format("Площадь : {0}", square), Color.Black);
                    break;
                case MeasureKind.Volume:
                    var vol = 0.0f;
                    foreach (var selObjsNumber in selObjsNumbers)
                    {
                        var e3DObj = (IElement3D)project.Model.ObjectData.Find(selObjsNumber);
                        vol += e3DObj.CalcVolume();
                    }
                    consoleControl.PrintInfo(string.Format("Объем : {0}", vol), Color.Black);
                    break;
                default:
                    break;
            }
        }

        private void MeasuringControl_PreparingMeasureEvent(object arg1, MeasureEventArgs arg2)
        {
            sceneControl.UnPlugGeometryObjs();
            sceneControl.DisplayObjects();

            var selectToolStrip = FindToolStrip<SelectToolStrip>();

            switch (arg2.Kind)
            {
                case MeasureKind.DistanceNodeToNode:
                    selectToolStrip.SelectObjectsType = "Узлы";
                    lblInputCmd.Text = "Выберите два узла...";
                    break;
                case MeasureKind.DistanceNodeToPlane:
                    break;
                case MeasureKind.Path:
                    selectToolStrip.SelectObjectsType = "Узлы";
                    lblInputCmd.Text = "Выберите узлы...";
                    break;
                case MeasureKind.Square:
                    selectToolStrip.SelectObjectsType = "Элементы2D";
                    lblInputCmd.Text = "Выберите элементы 2D или поверхности...";
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
                    sceneControl.ShowBoundaries();
                }

                else if (arg2.ClickedItem.Tag.ToString() == "1")
                {
                    sceneControl.DrawInsideObjects = true;
                    PresentAllModelObjectsOnScene();
                    consoleControl.PrintInfo("Показаны все объекты", Color.Black);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "2")
                {
                    sceneControl.DrawInsideObjects = false;
                    PresentAllModelObjectsOnScene();
                    consoleControl.PrintInfo("Скрыты внутренние объекты", Color.Black);
                }

                else if (arg2.ClickedItem.Tag.ToString() == "3")
                {
                    sceneControl.UnPlugVBObjects();

                    foreach (var objsType in sceneControl.GetVBObjsTypes())
                        if (objsType != "Узлы")
                            sceneControl.ChangeViewModeVBObjects(objsType, Scene.VBO.ObjView.LinesSurface);

                    sceneControl.PlugVBObjects();
                }

                else if (arg2.ClickedItem.Tag.ToString() == "4")
                {
                    sceneControl.UnPlugVBObjects();

                    foreach (var objsType in sceneControl.GetVBObjsTypes())
                        if (objsType != "Узлы")
                            sceneControl.ChangeViewModeVBObjects(objsType, Scene.VBO.ObjView.Lines);

                    sceneControl.PlugVBObjects();
                }

                else if (arg2.ClickedItem.Tag.ToString() == "5")
                {
                    sceneControl.UnPlugVBObjects();

                    foreach (var objsType in sceneControl.GetVBObjsTypes())
                        if (objsType != "Узлы")
                            sceneControl.ChangeViewModeVBObjects(objsType, Scene.VBO.ObjView.Surface);

                    sceneControl.PlugVBObjects();
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

        public async Task AsyncMethodContainer(Func<bool> actConfirm, Action actBreak, string cmdMessage)
        {
            Invoke(new Action(() => { lblInputCmd.Text = cmdMessage; }));
            await System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (PressedKey == Keys.Enter)
                    {
                        var res = actConfirm.Invoke();
                        if (res)
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
        }

        public virtual void sceneControl_CreateMeshGroupEvent(object arg1, Scene.Events.CreateGroupEventArgs arg2)
        {
            var name = arg2.ObjsType + "_" + (project.Model.GroupData.Count + 1).ToString();
            var group = new Group(name, arg2.ObjsType);

            group.AddRange(arg2.ObjsNumbers);

            project.Model.GroupData.Add(group);
            consoleControl.PrintInfo(string.Format("Создана новая группа {0}", name), Color.Black);

            sceneControl.SetBackColorToAll_VBObjects();
            sceneControl.DisplayObjects();
        }

        private void sceneControl_CreateVBObjectsEvent(object arg1, Scene.Events.VBOPresenterEventArgs arg2)
        {
            PresentModelOnSelectToolStrip();
        }

        public virtual void sceneControl_DeleteSelectionEvent(object arg1, EventArgs arg2)
        {
            var selectedObjects = sceneControl.GetSelectedObjects();
            var selectionType = sceneControl.SelectionType;

            project.Model.ObjectData.RemoveRange(selectionType, selectedObjects);

            var groups = project.Model.GroupData.FindMany(selectionType);

            foreach (var group in groups)
            {
                var exceptNumbers = group.ObjsNumbers.Except(selectedObjects).ToArray();
                group.Clear();
                group.AddRange(exceptNumbers);
            }

            PresentAllModelObjectsOnScene();
            PresentModelOnSelectToolStrip();
            sceneControl.SetBackColorToAll_VBObjects();
            sceneControl.DisplayObjects();
        }

        private void sceneControl_InfoObjectsEvent(object arg1, Scene.InfoObjectsEventArgs arg2)
        {
            try
            {
                consoleControl.PrintInfo("Выбраны " + arg2.ObjsType + " " + arg2.CountSelectedObjects.ToString(), Color.Black);

                var numbers = string.Join(" ", arg2.GetObjectsNumbers().ToArray());
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


        public virtual void UnBlockInterface()
        {
            var toolStr = FindToolStrip<StandartToolStrip>();
            toolStr.Enabled = true;

            foreach (ToolStripButton item in toolStr.Items)
                item.Enabled = true;
        }  

        private void BasePage_Load(object sender, EventArgs e)
        {
            menuItems = new List<ToolStripMenuItem>();

            grbNavigator.MouseClick += grbNavigator_MouseClick;
            grbConsole.MouseClick += grbConsole_MouseClick;

            var standartToolStrip = new StandartToolStrip();
            var viewToolStrip = new ViewToolStrip();
            var selectToolStrip = new SelectToolStrip();
            var displayToolStrip = new DisplayToolStrip();
            var instrumentalToolStrip = new InstrumentToolStrip();

            toolStripContainer.TopToolStripPanel.Join(selectToolStrip, 1);
            toolStripContainer.TopToolStripPanel.Join(displayToolStrip, 1);
            toolStripContainer.TopToolStripPanel.Join(viewToolStrip, 1);
            toolStripContainer.TopToolStripPanel.Join(instrumentalToolStrip, 1);
            toolStripContainer.TopToolStripPanel.Join(standartToolStrip, 1);

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
    }
}
