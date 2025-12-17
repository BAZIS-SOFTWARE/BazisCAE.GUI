using BazisGUI.DataBases;
using BazisGUI.Scene;
using BazisGUI.Scene.VBO;
using BazisGUI.SettingsControls;
using ClientGUI;
using ClientLogic;
using LicenseInfo;
using MasterInterface;
using Model.Interfaces;
using Newtonsoft.Json;
using OperationalController;
using OperationalController.GmshController;
using OperationalController.ModelScenePresentator;
using PostProc;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx;

namespace BazisGUI
{

    public partial class BaseForm : Form
    {
        // TODO События ниже должны быть перенесены в ProjectController
        public event Action OnProjectLoaded;
        public event Action<ObjType, string> OnGroupCreated;
        public event Action<ObjType, string, string> OnGroupRenamed;
        public event Action<ObjType, string> OnGroupDeleted;
        public event Action<string[]> OnChangeMaterials;
        public event Action<string[]> OnChangeFunctions;

        Point ScreenMousePosition { get; set; } = new Point(0, 0);
        bool MouseMoveFlag { get; set; }

        string WorkingDir
        {
            get
            {
                return Path.GetDirectoryName(lblStatus.Text);
            }
        }

        private readonly string projFilter = "Project file(*.bpf)|*.bpf|Project file(*.bpf2)|*.bpf2";
        private readonly string meshFilter = "Visual-Mesh ESI Group(*.ASC)|*.ASC|" +
            "GMSH(*.inp)|*.inp|" +
            "GMSH(*.inp_v2)|*.inp_v2|" +
            "STL(*.stl*)|*.stl|" +
            "SOLOMIA(*.dat*)|*.dat";
        private readonly string geomFilter = "(*.brep*)|*.brep|" +
            "(*.geo*)|*.geo|" +
            "*.stp*)|*.stp|" +
            "(*.step*)|*.step|" +
            "(*.iges*)|*.iges|" +
            "(*.igs*)|*.igs";

        //private System.Windows.Forms.Timer connectTimer = new System.Windows.Forms.Timer();
        //ProjectData project;

        ScreenRectangle selectionRectangle;
        ClipPlaneRenderer clipPlaneRenderer;
        Advanced3DClipper advanced3DClipper;
        AverageColorRenderer averageColorRenderer;

        //BasePage module;
        ProjectController project;
        IGmshController GmshController
        {
            get { return project?.GmshController; }
        }
        IODataController dataController = new IODataController();
        PreProc.PreProc preProc = new PreProc.PreProc();
        PostProcController resultsController = new PostProcController();
        IPresentersCreator presentersCreator = new PresentersCreator();
        VBOController VBOController = new VBOController();

        ClientController serverConnection;

        SettingsConfig settingsConfig = new SettingsConfig()
        {
            BackGroundColor = Color.White,
            SelectObjectColor = Color.GreenYellow,
            NodeColor = Color.FromArgb(153, 192, 86),
            Transparency = false,
            Lighting = true,
            BackRibbers = false,
            SolverPath = "?",
            SolverFile = "BazisSolverConsole.exe"
        };

        private Thread serverConnectionPing;

        private void BaseForm_Load(object sender, EventArgs e)
        {
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            var verStr = "Версия " + $"{ver.Major}.{ver.Minor}.{ver.Build}";
            lblVersion.Text = verStr;

            var config = dataController.LoadConfig();

            if (config != null)
                settingsConfig = config;

            SetGeneralSettings();

            DisplayObjects();
        }


        public BaseForm(string[] args)
        {
            InitializeComponent();

            cntrНавигатор.SplitterWidth = 8;
            splitContainer2.SplitterWidth = 8;
            splitContainer3.SplitterWidth = 8;

            SetPadding();

            //scene.InitializeContexts();
            //Gle.Load();//Это скорее всего больше не понадобится
            scene.Load += SceneInitialization;//Это конвертировалось в событие scene.Load!
                                              //ComponentsPainter.Font = this.Font; //попробуем не контролировать кегль вручную. Пусть кон-ет система

            результатыMenuItem.DropDown.Closing += DropDown_Closing;
            Shown += (arg1, arg2) => HandleArgs(args);
            //selectToolStrip.Location = new Point(10, 24);
            //displayToolStrip.Location = new Point(310, 48);
            //instrumentalToolStrip.Location = new Point(597, 48);
            //viewToolStrip.Location = new Point(785, 48);


            //var objs = project.ModelData.ObjectData.GetAllObjects();

            //foreach (var obj in objs)
            //{
            //    var preColor = obj.Color;
            //    var newColor = Color.FromArgb(TransparencyValue, preColor);
            //    obj.Color = newColor;
            //}
        }

        public async void HandleArgs(string[] args)
        {
            if (args.Length != 0)
            {
                if (args.Contains("-proj"))
                {
                    var projInd = Array.IndexOf(args, "-proj");

                    if (args.Length - 1 - projInd < 1)
                        throw new Exception($"Отсутствуют необходимые аргументы для -proj path file");

                    await OpenProject(Path.GetFullPath(args[projInd + 1]));
                }
                if (args.Contains("-res"))
                {
                    var resInd = Array.IndexOf(args, "-res");

                    if (args.Length - 1 - resInd < 1)
                        throw new Exception($"Отсутствуют необходимые аргументы для -res file");

                    var fullPath = Path.GetFullPath(args[resInd + 1]);

                    if (project == null)
                        throw new Exception($"Для загрузки результатов требуется сперва загрузить проект");

                    ResultDbPath = fullPath;
                    FillingResultsData();
                    //navigator.TrySearchNodes("результаты", out List<TreeNode> nodes);

                    //nodes.First().Nodes[0].Text = fullPath;
                }
                if (args.Contains("-cad"))
                {
                    var resInd = Array.IndexOf(args, "-cad");

                    if (args.Length - 1 - resInd < 1)
                        throw new Exception($"Отсутствуют необходимые аргументы для -cad file");

                    await OpenProject(Path.GetFullPath(args[resInd + 1]));
                }
            }
        }

        public void AddMaster(Master master)
        {
            try
            {
                if (project == null)
                {
                    MessageBox.Show("Не определен проект", "Ошибка");
                    return;
                }

                else if (project.MaterialsDB == null)
                {
                    console.PrintInfo($"База данных материалов не загружена", Color.Red);
                    return;
                }

                else if (project.FunctionsDB == null)
                {
                    console.PrintInfo($"База данных функций не загружена", Color.Red);
                    return;
                }

                master.Dock = DockStyle.Fill;
                master.Name = $"cntr{master.MasterName}";
                master.Size = cntrНавигатор.Size;
                master.Location = cntrНавигатор.Location;
                master.Anchor = cntrНавигатор.Anchor;

                master.SubmintParametrizedStringsEvent += (taskStrings) =>
                {
                    project.TaskData.Clear();
                    foreach (var item in taskStrings)
                    {
                        var args = item.Split(':');
                        var kind = Enum.Parse<DataKind>(args[0]);
                        var data = project.TaskData.Create(kind, args[1], project.ModelData.GroupData);
                        project.TaskData.Add(data);
                    }
                };

                master.UpdateSceneEvent += () =>
                {
                    ClearAllDataOnScene();
                    foreach (var item in Enum.GetValues<ObjType>())
                        CreateVBObjsByObjsType(item);
                };

                master.PrintInfoEvent += console.PrintInfo;

                // TODO События ниже должны быть перенесены в ProjectController
                OnGroupCreated += master.AddGroup;
                OnGroupRenamed += master.RenameGroup;
                OnGroupDeleted += master.DeleteGroup;
                OnChangeFunctions += master.ChangeFunctions;
                OnChangeMaterials += master.ChangeMaterials;

                var btn = new Button()
                {
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(0, 0, 3, 3),
                    Name = $"btnTab{master.MasterName}",
                    Size = new System.Drawing.Size(27, 130),
                    TabIndex = 1,
                    Tag = "True",
                    UseVisualStyleBackColor = true,
                    Visible = true,
                };
                btn.Paint += buttonTab_Paint;
                btn.MouseDown += button_MouseDown;

                OnProjectLoaded += () =>
                {
                    HideTabButton(btn.Name);
                    splitContainer3.Panel1.Controls.Remove(btn);
                    splitContainer3.Panel1.Controls.Remove(master);
                    foreach (ToolStripMenuItem item in мастерToolStripMenuItem.DropDownItems)
                        item.Checked = false;
                };

                splitContainer3.Panel1.Controls.Add(btn);
                splitContainer3.Panel1.Controls.Add(master);

                ShowTabButton(btn.Name);
                master.BringToFront();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }



        private void UnBlockGeneralMenuInterface(string moduleName, bool flag)
        {
            if (moduleName == "Weld" | moduleName == "HeatTreatment")
            {
                if (flag)
                {
                    tasksMenuItem.Enabled = true;
                    dataBasesMenuItem.Enabled = true;
                    //meshMenuItem.Visible = true;
                    результатыMenuItem.Visible = true;
                }
                else
                {
                    tasksMenuItem.Enabled = false;
                    dataBasesMenuItem.Enabled = false;
                    //meshMenuItem.Visible = false;
                    результатыMenuItem.Visible = false;
                }
            }
        }

        private void CloseActivePageChildControls(string moduleName)
        {
            toolStripContainer.ContentPanel.Controls.RemoveByKey(moduleName);

            var openForms = Application.OpenForms.Cast<Form>().ToArray();

            foreach (Form form in openForms)
            {
                if (!form.Name.Equals(this.Name))
                    form.Close();
            }
        }



        private void SetGeneralSettings()
        {
            try
            {
                var intervals = settingsConfig.Scale_Intervals;
                var min = settingsConfig.Scale_MinValue;
                var max = settingsConfig.Scale_MaxValue;
                var pre = settingsConfig.Scale_Precision;
                resultsController.FillRange(min, max, intervals, pre);
                //BackGroundColor = settingsConfig.BackGroudColor;
                averageColorRenderer.BackgroundColor = settingsConfig.BackGroundColor;
                averageColorRenderer.IsEnable = settingsConfig.Transparency;
                averageColorRenderer.IsLighting = settingsConfig.Lighting;//Синхронизация с рендером прозрачности
                var transpVal = (int)(255 * settingsConfig.TransparencyValue / 100.0f);
                settingsConfig.SelectObjectColor = Color.FromArgb(transpVal, settingsConfig.SelectObjectColor);
                settingsConfig.SelectGroupColor = Color.FromArgb(transpVal, settingsConfig.SelectGroupColor);

                //module.ScenePage.NodeColor = settingsConfig.NodeColor;
                //module.ScenePage.E2DColor = settingsConfig.Elem2DColor;
                //module.ScenePage.E3DColor = settingsConfig.Elem3DColor;
                UpdateProjection();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            PressedKey = e.KeyCode;
        }

        private void содержаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form() { Name = "helpForm", Text = "Справка", ShowIcon = false };
            form.TopMost = true;
            var helpFile = Directory.GetFiles(Application.StartupPath, "ПО Bazis 5.2. Руководство пользователя.pdf", SearchOption.AllDirectories);

            if (helpFile.Count() != 0)
                Help.ShowHelp(form, helpFile[0]);
            else MessageBox.Show("Отсутствует файл справки!");
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form() { Name = "aboutProgrammForm", Text = "О программе", ShowIcon = false };
            var control = new AboutProgrammControl { Dock = DockStyle.Fill };

            form.ClientSize = control.Size;
            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void сведенияMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form() { Name = "aboutLicenseForm", Text = "Информация о лицензии", ShowIcon = false };
            form.TopMost = true;
            var control = new AboutLicenseControl { Dock = DockStyle.Fill };
            form.ClientSize = control.Size;

            try
            {
                if (TryServerConnection())
                {
                    serverConnection.RequestServer("CheckLicenseInfo");
                    var licInfo = JsonConvert.DeserializeObject<License>(serverConnection.Answer);

                    if (licInfo != null)
                    {
                        control.KeysInfo = string.Empty;

                        foreach (var key in licInfo.Keys)
                            control.KeysInfo += $"{key}\n";

                        control.OwnerInfo = licInfo.Company;
                    }
                    control.AdressInfo = $"{serverConnection.IPAddress} : {serverConnection.Port}";
                }
                else
                {
                    var res = MessageBox.Show
    (
    $@"Соединение не установлено. Не найдена переменная среды ""BazisServerPath""
                    Создать переменную?", "Внимание!",
    MessageBoxButtons.YesNo
    );

                    if (res == DialogResult.Yes)
                        StartLisenceForm("");
                    else
                        serverConnection = new ClientController(IPAddress.Loopback, 8001);
                }
            }
            catch (Exception ex)
            {
                if (ex is Newtonsoft.Json.JsonReaderException)
                    MessageBox.Show("Ошибка запроса информации о лицензии");
                else
                    MessageBox.Show(ex.Message);
            }

            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void StartLisenceForm(string request)
        {
            var form = new Form() { Name = "checkForm", Text = "Лицензирование", ShowIcon = false };
            var control = new ClientControl() { Dock = DockStyle.Fill };

            control.LicenseActionEvent += (ar1, ar2) =>
            {
                serverConnection = new ClientController(ar1, ar2);
                if (request != null)
                {
                    serverConnection.RequestServer(request);

                    if (serverConnection.Answer == "можно")
                    {
                        control.LabelAnswer = "Лицензирование проведено";
                        UnBlockGeneralMenuInterface(request.Split(' ')[0], true);
                        StartLicensing(request.Split(' ')[0]);
                    }
                    else if (serverConnection.Answer == "Пустой запрос")
                        control.LabelAnswer = "Соединение установлено";
                    else
                        control.LabelAnswer = serverConnection.Answer;
                }
            };
            form.ClientSize = control.Size;
            form.Controls.Add(control);

            form.ShowDialog();
        }



        public void KillAlreadyLaunchdExamples()
        {
            var runProc = Process.GetProcessesByName("BazisGUI");

            if (runProc.Length > 1)
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = $"/C taskkill /pid {runProc[0].Id} /f",
                    Verb = "runas"
                };
                process.StartInfo = startInfo;
                process.Start();
            }
        }

        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serverConnectionPing != null)
            {
                serverConnectionPing.Abort();

                while (true)
                    if (!serverConnectionPing.IsAlive)
                        break;
            }
        }

        private static void ShowReleaseNotes()
        {
            var form = new Form() { Name = "newsForm", Text = "Новости версии", ShowIcon = false, Size = new Size(500, 300) };
            form.TopMost = true;
            var helpFile = Directory.GetFiles(Application.StartupPath, "ReleaseNotes.pdf", SearchOption.AllDirectories);

            if (helpFile.Count() != 0)
                Help.ShowHelp(form, helpFile[0]);
            else MessageBox.Show("Отсутствует файл!");
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;

                var folderName = dialog.SelectedPath;

                project = new ProjectController();
                project.CreateProject("newProject.bpf2");

                lblStatus.Text = $"{folderName}\\{project.Name}";

                ClearAllDataOnScene();
                PresentProject();
                PresentCompDataOnTree(new List<string>());
                UnblockInterface();

                DisplayObjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Стек: {ex.StackTrace}", "Ошибка");
            }
        }

        private async Task OpenProject(string filePath)
        {
            try
            {
                var ext = Path.GetExtension(filePath).ToLower();

                if (projFilter.Contains(ext))
                {
                    project = await dataController.OpenProject(filePath);
                    GmshController?.Gmsh?.Clear();
                }

                else if (geomFilter.Contains(ext))
                {
                    if (project == null)
                        project = new ProjectController();

                    if (GmshController.Gmsh == null)
                        project.GmshController = dataController.LoadGMSH();
                    project.ImportCAD(filePath);
                }

                else
                {
                    project = await dataController.ImportMesh(filePath);
                    GmshController?.Gmsh?.Clear();
                }

                lblStatus.Text = filePath;
                OnProjectLoaded?.Invoke();

                ClearAllDataOnScene();
                PresentProject();

                UnblockInterface();

                FitObjectsToScreen();
                DisplayObjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Стек: {ex.StackTrace}", "Ошибка");
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = string.Join("|", "All files(*.*)|*.*", projFilter, geomFilter, meshFilter);
            dialog.DefaultExt = "*.bpf2";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            OpenProject(dialog.FileName);
        }

        private void UnblockInterface()
        {
            сеткаToolStripMenuItem.Enabled = true;
            dataBasesMenuItem.Enabled = true;
            tasksMenuItem.Enabled = true;
            расчетыToolStripMenuItem.Enabled = true;
            результатыMenuItem.Enabled = true;
            инструментыToolStripMenuItem.Enabled = true;
            //scene.Enabled = true;

            btnAdvSelection.Enabled = true;
            btnDisplayStates.Enabled = true;
            btnDisplayViews.Enabled = true;

            btnFitToScreen.Enabled = true;
            btnMakeScreenShot.Enabled = true;
            btnShowInsideObjects.Enabled = true;

            console.Enabled = true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void webPageLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(webPageLabel.Text); //где path это путь к сайту
        }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.DefaultExt = "bpf2";

                var filter = "(*.bpf)|*.bpf|(*.bpf2)|*.bpf2";

                saveDialog.Filter = filter;

                if (saveDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                if (project == null)
                    MessageBox.Show("Сначала откройте или создайте новый проект");
                else
                {
                    var newFolder = Path.GetDirectoryName(saveDialog.FileName);
                    var oldFolder = Path.GetDirectoryName(lblStatus.Text);

                    project.Name = Path.GetFileName(saveDialog.FileName);

                    // Пробуем не использовать это свойство
                    //project.Path = newFolder;

                    if (oldFolder != newFolder)
                    {
                        if (project.MaterialsDB != null)
                            IOFileController.CopyFile(project.MaterialsDB.Name, oldFolder, newFolder);
                        if (project.FunctionsDB != null)
                            IOFileController.CopyFile(project.FunctionsDB.Name, oldFolder, newFolder);
                    }

                    project.Save(saveDialog.FileName);

                    console.PrintInfo("Проект сохранен", Color.Black);
                    lblStatus.Text = saveDialog.FileName;
                }
            }


        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Path.GetDirectoryName
            project?.Save(lblStatus.Text);
            console.PrintInfo("Проект сохранен", Color.Black);
        }

        private void PresentProject()
        {
            CreateVBObjects("Объекты");

            PresentGeoData();
            PresentMeshData();
            PresentGroupDataOnTree();
            PresentCondDataOnTree();
            PresentModelObjectsForSelection();
        }

        private void OnClosingForm(object sender, FormClosingEventArgs e)
        {
            GmshController?.Gmsh?.finalize();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var splitContainer = (SplitContainer)navigator.Parent.Parent;
            splitContainer.Panel1Collapsed = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var splitContainer = (SplitContainer)console.Parent.Parent;
            splitContainer.Panel2Collapsed = false;
        }



        private async void экспортСеткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var res = await dataController.ExportMesh(project);

                if (res == null)
                    return;

                console.PrintInfo(res, Color.Green);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Стек: {ex.StackTrace}", "Ошибка");
            }
        }

        private async void добавитьСеткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (project != null)
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = meshFilter;
                    if (dialog.ShowDialog() == DialogResult.Cancel)
                        return;

                    var mb = new MessageBoxEx.MessageBoxEx()
                    { Dock = DockStyle.Fill };
                    var mbf = dataController.CreateMessageBoxExForm(mb);
                    mbf.Show();
                    await Task.Run(new Action(() =>
                    {
                        project.MessageEvent += (ar1) =>
                        {
                            mb.Invoke(new Action(() =>
                            {
                                mb.Message = ar1;
                            }));
                        };
                        project.Append(dialog.FileName);

                    }));
                    mbf.Close();
                    project.UnsubMessasge();
                    // сбрасывать gmsh  не обязательно
                    //gmshController?.Gmsh?.Clear();

                    ClearAllDataOnScene();
                    PresentProject();

                    UnblockInterface();

                    FitObjectsToScreen();
                    DisplayObjects();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Стек: {ex.StackTrace}", "Ошибка");
            }
        }

        // Opening master example
        //private void testToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (testToolStripMenuItem.Checked)
        //        AddMaster(new TestMaster());
        //    else
        //    {
                
        //        var masters = splitContainer3.Panel1.Controls.OfType<IMaster>().Cast<Master>();
        //        foreach(var master in masters)
        //        {
        //            splitContainer3.Panel1.Controls.Remove(master);
        //            HideTabButton($"btnTab{master.MasterName}");
        //        }
                
        //    }
        //}
    }

}
