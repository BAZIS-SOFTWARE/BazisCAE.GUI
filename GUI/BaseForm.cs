using BazisGUI.SettingsControls;
using ClientGUI;
using ClientLogic;
using LicenseInfo;
using Model.Interfaces;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using UserControlsEx;
using PostProc;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene;
using Tao.OpenGl;
using BazisGUI.Scene.VBO;
using OperationalController.GmshController;
using OperationalController.ModelScenePresentator;
using System.Collections.Generic;
using OperationalController;
using Model;
using BaseModule.Utilities;
using System.Xml.Linq;

namespace BazisGUI
{

    public partial class BaseForm : Form
    {
        Point ScreenMousePosition { get; set; } = new Point(0, 0);
        bool MouseMoveFlag { get; set; }

        string WorkingDir
        {
            get
            {
               return Path.GetDirectoryName(lblStatus.Text);
            }
        }

        //private System.Windows.Forms.Timer connectTimer = new System.Windows.Forms.Timer();
        //ProjectData project;

        ScreenRectangle selectionRectangle;
        ClipPlaneRenderer clipPlaneRenderer;
        Advanced3DClipper advanced3DClipper;
        AverageColorRenderer averageColorRenderer;

        //BasePage module;
        Controller project;
        GmshController gmshController = new GmshController();
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

            SetPadding();

            scene.InitializeContexts();
            Gle.Load();
            SceneInitialization();
            //ComponentsPainter.Font = this.Font; //попробуем не контролировать кегль вручную. Пусть кон-ет система

            splitContainer1.SplitterWidth = 8;
            splitContainer2.SplitterWidth = 8;
            splitContainer3.SplitterWidth = 8;
            resultsMenuItem.DropDown.Closing += DropDown_Closing;
            selectToolStrip.Location = new Point(3, 24);
            displayToolStrip.Location = new Point(303, 24);
            instrumentalToolStrip.Location = new Point(595, 24);
            viewToolStrip.Location = new Point(783, 24);


            //var objs = project.ModelData.ObjectData.GetAllObjects();

            //foreach (var obj in objs)
            //{
            //    var preColor = obj.Color;
            //    var newColor = Color.FromArgb(TransparencyValue, preColor);
            //    obj.Color = newColor;
            //}

            if (args.Length != 0)
            {
                var path = string.Empty;
                if (args.Contains("-proj"))
                {
                    var projInd = Array.IndexOf(args, "-proj");

                    if (args.Length - 1 - projInd < 1)
                        throw new Exception($"Отсутствуют необходимые аргументы для -proj path file");

                    path = Path.GetDirectoryName(args[projInd + 1]);
                    var name = Path.GetFileName(args[projInd + 1]);

                    project = new Controller();
                    project.Load(path);
                }
                if (args.Contains("-res"))
                {
                    var resInd = Array.IndexOf(args, "-res");

                    if (args.Length - 1 - resInd < 1)
                        throw new Exception($"Отсутствуют необходимые аргументы для -res file");

                    var fullPath = Path.GetFullPath(args[resInd + 1]);

                    if (project == null)
                        throw new Exception($"Для загрузки результатов требуется сперва загрузить проект");

                    navigator.TrySearchNodes("результаты", out List<TreeNode> nodes);

                    nodes.First().Nodes[0].Text = fullPath;
                }
                if (args.Contains("-cad"))
                {
                    var resInd = Array.IndexOf(args, "-cad");

                    if (args.Length - 1 - resInd < 1)
                        throw new Exception($"Отсутствуют необходимые аргументы для -cad file");

                    var fullPath = Path.GetFullPath(args[resInd + 1]);

                    if (gmshController == null)
                        gmshController = dataController.LoadGMSH();

                    if (project == null)
                        project = new Controller();
                    project.ImportCAD(fullPath, gmshController);
                    path = Path.GetDirectoryName(fullPath);
                }
   
                lblStatus.Text = $"{path}\\{project.Name}";
            }


        }

        private void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }

        private void GetServerConnection()
        {
            var net = Environment.GetEnvironmentVariable("BazisServerPath", EnvironmentVariableTarget.Machine);

            if (net != null)
            {
                var iPAddress = IPAddress.Parse(net.Split(':')[0]);
                var port = int.Parse(net.Split(':')[1]);

                serverConnection = new ClientController(iPAddress, port);
            }
            else
            {
                var res = MessageBox.Show
                    (
                    $@"Не найдена переменная среды ""BazisServerPath""
                    Создать переменную?", "Внимание!",
                    MessageBoxButtons.YesNo
                    );

                if (res == DialogResult.Yes)
                    StartLisenceForm("");
                else
                    serverConnection = new ClientController(IPAddress.Loopback, 8001);
            }
        }


        private void сварка_Click(object sender, EventArgs e)
        {
            SetModule("Weld");
            DisplayObjects();
        }
        private void термообработка_Click(object sender, EventArgs e)
        {
            SetModule("HeatTreatment");
            DisplayObjects();
        }

        private void DisconnectWithServer(string moduleName)
        {
            //if (module != null)
            //{
                StopServerPing();
                serverConnection?.RequestServer(moduleName + " Отдать");
            //}
        }

        private void SetModule(string moduleName)
        {
            DisconnectWithServer(moduleName);

            CloseActivePageChildControls(moduleName);

            //var newModule = CreateModule(moduleName);
            //Important to see in future

            //modelController = new ModelController.ModelController(project.ModelData);

            //SetGeneralSettings(moduleName);
            LicenseModule(moduleName);
            PresentProjectOnModule();
            DisplayObjects();
        }

        private void LicenseModule(string moduleName)
        {
            serverConnection?.RequestServer(moduleName + " Взять");

            if (serverConnection?.Answer == "можно")
            {
                UnBlockGeneralMenuInterface(moduleName, true);
                StartLicensing(moduleName);
            }

            else StartLisenceForm(moduleName + " Взять");
        }

        private void UnBlockGeneralMenuInterface(string moduleName, bool flag)
        {
            if(moduleName == "Weld" | moduleName == "HeatTreatment")
            {
                if (flag)
                {
                    tasksMenuItem.Enabled = true;
                    dataBasesMenuItem.Enabled = true;
                    //meshMenuItem.Visible = true;
                    resultsMenuItem.Visible = true;
                }
                else
                {
                    tasksMenuItem.Enabled = false;
                    dataBasesMenuItem.Enabled = false;
                    //meshMenuItem.Visible = false;
                    resultsMenuItem.Visible = false;
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

        private void StartLicensing(string moduleName)
        {

            serverConnectionPing = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        lock (serverConnection)
                        {
                            serverConnection.RequestServer(moduleName + " Работа");
                            if(serverConnection.Answer != "Работай")
                            {
                                throw new AccidentServerDisconnectionException();  
                            }    
                                
                        }
                        Thread.Sleep(3000);
                    }

                }
                catch (Exception ex)
                {
                    if(ex is AccidentServerDisconnectionException)
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show(this, "Внимание! Лицензирование прервано. Приложение будет заблокировано. Проверьте сервер лицензий.");
                            //Application.ExitThread();
                            UnBlockGeneralMenuInterface(moduleName, false);
                        }));
                    }
                }
            });
            serverConnectionPing.Start();

        }

        private void StopServerPing()
        {
            if (serverConnectionPing != null)
            {
                while (true)
                {
                    if (serverConnectionPing.ThreadState == System.Threading.ThreadState.WaitSleepJoin |
                        serverConnectionPing.ThreadState == System.Threading.ThreadState.Running                       
                        )
                        serverConnectionPing.Abort();
                    if (serverConnectionPing.ThreadState == System.Threading.ThreadState.Aborted |
                        serverConnectionPing.ThreadState == System.Threading.ThreadState.Stopped
                        )
                        break;
                }
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
            var form = new Form() { Name = "helpForm", Text = "Справка", ShowIcon = false};
            form.TopMost = true;
            var helpFile = Directory.GetFiles(Application.StartupPath, "ПО Bazis. Руководство пользователя.chm", SearchOption.AllDirectories);

            if (helpFile.Count() != 0)
                Help.ShowHelp(form, helpFile[0]);
            else MessageBox.Show("Отсутствует файл справки!");
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form() { Name = "aboutProgrammForm", Text = "О программе", ShowIcon = false};
            var control = new AboutProgrammControl { Dock = DockStyle.Fill };

            form.ClientSize = control.Size;
            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void сведенияMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form() { Name = "aboutLicenseForm", Text = "Информация о лицензии", ShowIcon = false};
            form.TopMost = true;
            var control = new AboutLicenseControl { Dock = DockStyle.Fill };
            form.ClientSize = control.Size;
            
            try
            {
                serverConnection.RequestServer("CheckLicenseInfo");
                var licInfo = JsonConvert.DeserializeObject<License>(serverConnection.Answer);
                
                if(licInfo != null)
                {
                    control.KeysInfo = string.Empty;

                foreach (var key in licInfo.Keys)
                        control.KeysInfo += $"{key}\n";

                    control.OwnerInfo = licInfo.Company;
                }
                control.AdressInfo = $"{serverConnection.IPAddress} : {serverConnection.Port}";
            }
            catch (Exception ex)
            {
                if(ex is Newtonsoft.Json.JsonReaderException)
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

            control.LicenseActionEvent += (ar1,ar2) => 
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
                    else if(serverConnection.Answer == "Пустой запрос")
                        control.LabelAnswer = "Соединение установлено";
                    else
                        control.LabelAnswer = serverConnection.Answer;
                }
            };
            form.ClientSize = control.Size;
            form.Controls.Add(control);

            form.ShowDialog();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var settings = new SettingsControl() { Dock = DockStyle.Fill };

            settings.SetSettings(settingsConfig);
            
            //settings.SaveSettingsEvent += (ar) =>
            //{
            //    settingsConfig = ar;
            //};

            var forms = Application.OpenForms.Cast<Form>().ToList();

            if (forms.Find(x => x.Name == "settings") == null)
            {
                var form = new Form()
                {
                    Name = "settings",
                    Text = "Настройки",
                    TopMost = true,
                    ShowIcon = false,
                    CausesValidation = true,
                    Owner = Application.OpenForms[0]
                };

                form.ClientSize = settings.Size;
                form.Controls.Add(settings);
                form.Show();

                var location = scene == null ? new Point() :  PointToScreen(Point.Empty);
                form.Location = location;
            }

             SetSettingsToConfig(settings);
            
        }

        private void SetSettingsToConfig(SettingsControl settings)
        {

            settings.SetSelectionGroupColorEvent += (ar) => settingsConfig.SelectGroupColor = ar;
            settings.SetSelectionObjectColorEvent += (ar) =>
            settingsConfig.SelectObjectColor = ar;

            settings.SetNodeColorEvent += (ar) => { 
                //NodeColor = ar;
                var pres = project.CreateModelObjectsPresentor(ObjType.Узел);
                SetVBObjectAttribute(pres,"цвет");
                DisplayObjects();
            };

            settings.SetSolverPathEvent += (ar) =>
            {
                settingsConfig.SolverPath = ar;
            };
            settings.SetBackGroundColorEvent += (ar) =>
            {
                settingsConfig.BackGroundColor = ar;
                averageColorRenderer.BackgroundColor = ar;
                DisplayObjects();
            };


            settings.SetLightingEvent += (ar) =>
            {
                settingsConfig.Lighting = ar;
                averageColorRenderer.IsLighting = ar;
                DisplayObjects();
            };

            settings.SetTransparencyEvent += (ar) =>
            {
                settingsConfig.Transparency = ar;
                averageColorRenderer.IsEnable = ar;
                ClearAllDataOnScene();
                CreateVBObjects("Объекты");
                DisplayObjects();
            };

            settings.SetOrtoProjectionEvent += (ar) =>
            {
                settingsConfig.Projection = ar ? ViewProjection.Parallel : ViewProjection.Perspective;
                UpdateProjection();
                DisplayObjects();
            };

            settings.SetTransparencyValueEvent += (ar1) =>
            {
                settingsConfig.TransparencyValue = (int)(ar1 / 100.0f * 255);

                settingsConfig.SelectObjectColor = Color.FromArgb(settingsConfig.TransparencyValue, settingsConfig.SelectObjectColor);
                settingsConfig.SelectGroupColor = Color.FromArgb(settingsConfig.TransparencyValue, settingsConfig.SelectGroupColor);

                var objs = project.ModelData.ObjectData.GetAllObjects();

                foreach (var obj in objs)
                {
                    var preColor = obj.Color;
                    var newColor = Color.FromArgb(settingsConfig.TransparencyValue, preColor);
                    obj.Color = newColor;
                } 
                
                ClearAllDataOnScene();
                CreateVBObjects("Объекты");
                DisplayObjects();
            };

            settings.SetLightingIntensityEvent += (ar) =>
            {
                settingsConfig.LightingIntensity = ar;
                var lightAttenuation = 1 - ar / 100.0f;
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_LINEAR_ATTENUATION, ref lightAttenuation);
                DisplayObjects();
            };


            settings.SetLighterPositionEvent += (ar) =>
            {
                var kx = (float)(Width / settings.Width);
                var ky = (float)(Height / settings.Height);

                var x = ar.X * kx;
                var y = ar.Y * ky;

                settingsConfig.LighterPosition.X = (int)x;
                settingsConfig.LighterPosition.Y = (int)y;

                DisplayObjects();
            };
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

        private void новостиВерсииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReleaseNotes();
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

        private void releaseNoteslinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowReleaseNotes();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;

                var folderName = dialog.SelectedPath;

                project = new Controller();
                project.CreateProject("newProject.bpf2");

                lblStatus.Text = $"{folderName}\\{project.Name}";
                
                ClearAllDataOnScene();

                DisplayObjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Стек: {ex.StackTrace}", "Ошибка");
            }
        }

        private async void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var filter = "Project file(*.bpf)|*.bpf|Project file(*.bpf2)|*.bpf2";

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = filter;
                dialog.DefaultExt = "bpf";
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;

                project = await dataController.OpenProject(dialog.FileName);

                var path = Path.GetDirectoryName(dialog.FileName);

                lblStatus.Text = $"{path}\\{project.Name}";

                gmshController?.Gmsh?.Clear();

                ClearAllDataOnScene();
                PresentProjectOnModule();

                FitObjectsToScreen();
                DisplayObjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Стек: {ex.StackTrace}", "Ошибка");
            }
        }

        private async void импортСеткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string meshFilter =
"All files(*.*)|*.*|" +
"Visual-Mesh ESI Group(*.ASC)|*.ASC|" +
"GMSH(*.inp)|*.inp|" +
"GMSH(*.inp_v2)|*.inp_v2|" +
"ANSYS(*.cdb*)|*.cdb|" +
"STL(*.stl*)|*.stl|" +
"SOLOMIA(*.dat*)|*.dat";

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = meshFilter;
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;

                var res = await dataController.ImportMesh(dialog.FileName);

                if (res == null)
                    return;

                project = res;
                var path = Path.GetDirectoryName(dialog.FileName);
                lblStatus.Text = $"{path}\\{project.Name}";

                gmshController?.Gmsh?.Clear();

                ClearAllDataOnScene();
                PresentProjectOnModule();

                FitObjectsToScreen();
                DisplayObjects();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Стек: {ex.StackTrace}", "Ошибка");
            }

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
                saveDialog.DefaultExt = "bpf";

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

        private async void импортГеометрииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new OpenFileDialog();

                var filter =
    "(*.brep*)|*.brep|" +
    "(*.geo*)|*.geo|" +
    "*.stp*)|*.stp|" +
    "(*.step*)|*.step|" +
    "(*.iges*)|*.iges|" +
    "(*.igs*)|*.igs";

                dialog.Filter = filter;

                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;


                if (gmshController.Gmsh == null)
                    gmshController = dataController.LoadGMSH();

                if (project == null)
                    project = new Controller();
                project.ImportCAD(dialog.FileName, gmshController);

                if (project != null)
                {
                    lblStatus.Text = $"{project.Name}";

                    ClearAllDataOnScene();
                    PresentProjectOnModule();

                    FitObjectsToScreen();
                    DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PresentProjectOnModule()
        {
            CreateVBObjects("Объекты");

            PresentObjectsDataOnTree();

            PresentGroupDataOnTree();
            PresentCondDataOnTree();
            PresentModelOnSelectToolStrip(project.ModelData.ObjectData);
        }

        private void OnClosingForm(object sender, FormClosingEventArgs e)
        {
                gmshController?.Gmsh?.finalize();
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
     

        private void arcWeldingMenuItem_Click(object sender, EventArgs e)
        {
            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if (currentItem.Name != item.Name)
                    item.Checked = false;
        }

        private void lazerWeldingMenuItem_Click(object sender, EventArgs e)
        {
            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if (currentItem.Name != item.Name)
                    item.Checked = false;
        }

        private void fsWeldingMenuItem_Click(object sender, EventArgs e)
        {
 
            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if (currentItem.Name != item.Name)
                    item.Checked = false;
        }            



        private void heatingMenuItem_Click(object sender, EventArgs e)
        {

            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if(currentItem.Name != item.Name)
                    item.Checked = false;
        }

        private void temperingMenuItem_Click(object sender, EventArgs e)
        {
            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if (currentItem.Name != item.Name)
                    item.Checked = false;
        }

        private void quenchingMenuItem_Click(object sender, EventArgs e)
        {
            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if (currentItem.Name != item.Name)
                    item.Checked = false;
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
                if(project != null)
                {
                    string meshFilter =
"All files(*.*)|*.*|" +
"Visual-Mesh ESI Group(*.ASC)|*.ASC|" +
"GMSH(*.inp)|*.inp|" +
"GMSH(*.inp_v2)|*.inp_v2|" +
"ANSYS(*.cdb*)|*.cdb|" +
"STL(*.stl*)|*.stl|" +
"SOLOMIA(*.dat*)|*.dat";

                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = meshFilter;
                    if (dialog.ShowDialog() == DialogResult.Cancel)
                        return;

                    await dataController.AppendModelAsync(project.ModelData, dialog.FileName);

                    var path = Path.GetDirectoryName(dialog.FileName);
                    lblStatus.Text = $"{path}\\{project.Name}";

                    gmshController?.Gmsh?.Clear();

                    //SetModule("Weld");

                    FitObjectsToScreen();
                    DisplayObjects();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Стек: {ex.StackTrace}", "Ошибка");
            }

        }
    }

}
