
using BaseModule;
using TaskModule.HeatTreatmentModule;
using ModelModule;
using Newtonsoft.Json;
using Project;
using ResultModule;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using TaskModule;
using TaskModule.WeldingModule;
using ClientLogic;
using LicenseInfo;
using ClientGUI;
using BazisGUI.SettingsControls;
using Project.IO;
using ModelInterfaces;
using Model;
using Tasks;
using Results.ResultsData;
using BaseModule.Console;
using Model.IO;
using ModelController.ModelScenePresentator;
using ModelControllerInterfaces;

namespace BazisGUI
{

    public partial class BaseForm : Form
    {
        //private System.Windows.Forms.Timer connectTimer = new System.Windows.Forms.Timer();
        ProjectData project;
        private string activePage;
        private List<ToolStripMenuItem> activeMenuItems = new List<ToolStripMenuItem>();
        BasePage module;


        SettingsConfig settingsConfig = new SettingsConfig()
        {
            BackGroudColor = Color.White,
            SelectObjectColor = Color.GreenYellow,
            Transparency = true,
            Lighting = true
        };

        private Thread serverConnectionThread;

        ClientController serverConnection { get; set; }

        public BaseForm()
        {
            InitializeComponent();

            activePage = "none";

            GetServerConnection();
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
                MessageBox.Show
                    (
                    $@"Адресс подключения: {IPAddress.Loopback}, порт: {8001}\n
                                Внимание! Не найдена переменная среды ""BazisServerPath"""
                    );
                serverConnection = new ClientController(IPAddress.Loopback, 8001);
            }
        }

        private void построениеСетки_Click(object sender, EventArgs e)
        {
            CloseActivePageChildControls();

            DisconnectWithServer();
            serverConnection.RequestServer(activePage + " Отдать");

            var module = CreateModule("Mesh");
            module.ModelController = new ModelController.ModelController();

            AddModule(module);
        }

        private void анализРезультатов_Click(object sender, EventArgs e)
        {

            CloseActivePageChildControls();

            DisconnectWithServer();
            serverConnection.RequestServer(activePage + " Отдать");

            var module = CreateModule("Result");
            module.ModelController = new ModelController.ModelController();
            module.PresentersCreator.Add("Results", PresenterView.Surface);

            AddModule(module);
        }

        private void сварка_Click(object sender, EventArgs e)
        {
            CloseActivePageChildControls();

            DisconnectWithServer();
            serverConnection.RequestServer(activePage + " Отдать");

            var module = CreateModule("Weld");
            module.ModelController = new ModelController.ModelController();

            AddModule(module);
        }

        private void термообработка_Click(object sender, EventArgs e)
        {
            if (project != null)
            {
                CloseActivePageChildControls();

                DisconnectWithServer();
                serverConnection.RequestServer(activePage + " Отдать");

                var module = CreateModule("HeatTreatment");
                module.ModelController = new ModelController.ModelController();

                AddModule(module);
            }
        }

        private void AddModule(BasePage module)
        {
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            var verStr = "Версия " + $"{ver.Major}.{ver.Minor}.{ver.Build}";
            module.SetVersion(verStr);

            SetGeneralSettings(module);

            toolStripContainer.ContentPanel.Controls.Add(module);

            module.CreateMenuInterface();
            module.SceneInitialization();
            module.PresentProjectOnTree();
            module.PresentModelOnSelectToolStrip();
            module.SetLblInputCmb();

            activeMenuItems.Clear();

            foreach (var menuItem in module.GetToolStripMenuItems())
            {
                menuStrip.Items.Insert(2,menuItem);
                activeMenuItems.Add(menuItem);
            }

            tableLayoutPanel.Hide();

            serverConnection.RequestServer(activePage + " Взять");

            if (serverConnection.Answer == "можно")
                StartLicensing(activePage, module);
            else StartLisenceForm();

        }

        private BasePage CreateModule(string moduleName)
        {
            activePage = moduleName;

            if (moduleName == "Weld")
            {
                //модулиMenuItem.Image = сварка.Image;
                модулиMenuItem.Text = "Сварка";

                var taskPage = new WeldingPage() { Dock = DockStyle.Fill, Name = activePage, Project = project };
                taskPage.SolverPath = settingsConfig.SolverPath;

                return taskPage;
            }

            else if (moduleName == "HeatTreatment")
            {
                //модулиMenuItem.Image = термообработка.Image;
                модулиMenuItem.Text = "Термообработка";

                var taskPage = new HeatTreatmentPage() { Dock = DockStyle.Fill, Name = activePage, Project = project };
                taskPage.SolverPath = settingsConfig.SolverPath;

                return taskPage;
            }

            else if (moduleName == "Result")
            {
                //модулиMenuItem.Image = анализРезультатов.Image;
                модулиMenuItem.Text = "Результаты";
                return new ResultPage() { Dock = DockStyle.Fill, Name = activePage, Project = project };
            }

            else
            {
                //модулиMenuItem.Image = построениеСетки.Image;
                модулиMenuItem.Text = "Сетка";
                return new ModelPage() { Dock = DockStyle.Fill, Name = activePage, Project = project };
            }
        }

        private void CloseActivePageChildControls()
        {
            toolStripContainer.ContentPanel.Controls.RemoveByKey(activePage);

            var openForms = Application.OpenForms.Cast<Form>().ToArray();

            foreach (Form form in openForms)
            {
                if (!form.Name.Equals(this.Name))
                    form.Close();
            }

            foreach (var activeMenuItem in activeMenuItems)
                menuStrip.Items.Remove(activeMenuItem);
        }

        private void StartLicensing(string moduleName, BasePage module)
        {
            //сохранитьToolStripMenuItem.Enabled = true;
            //сохранитькакToolStripMenuItem.Enabled = true;
            module.UnBlockInterface(true);

            serverConnectionThread = new Thread(() =>
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
                            module.UnBlockInterface(false);
                        }));
                    }
                }
            });
            serverConnectionThread.Start();

        }

        private void DisconnectWithServer()
        {
            if (serverConnectionThread != null)
            {
                while (true)
                {
                    if (serverConnectionThread.ThreadState == System.Threading.ThreadState.WaitSleepJoin |
                        serverConnectionThread.ThreadState == System.Threading.ThreadState.Running                       
                        )
                        serverConnectionThread.Abort();
                    if (serverConnectionThread.ThreadState == System.Threading.ThreadState.Aborted |
                        serverConnectionThread.ThreadState == System.Threading.ThreadState.Stopped
                        )
                        break;
                }
            }
        }

        private void SetGeneralSettings(BasePage module)
        {
            module.SceneControl.BackGroundColor = settingsConfig.BackGroudColor;
            module.SceneControl.SelectionColor = settingsConfig.SelectObjectColor;
            module.SceneControl.IsBlending = settingsConfig.Transparency;
            module.SceneControl.IsLighting = settingsConfig.Lighting;
            module.SelectionGroupColor = settingsConfig.SelectGroupColor;
        }

        private void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            var controls = toolStripContainer.ContentPanel.Controls.Find(activePage,false);

            if(controls.Length > 0)
            {
                var baseControl = (BasePage)controls[0];
                baseControl.PressedKey = e.KeyCode;
            }

        }

        private void модулиMenuItem_Paint(object sender, PaintEventArgs e)
        {
            var x = модулиMenuItem.Width;
            var y = модулиMenuItem.Height / 2;

            var points = new Point[]
{
                        new Point(x,модулиMenuItem.Height - 3 - y),
                        new Point(x - 4,модулиMenuItem.Height + 1 - y),
                        new Point(x - 7,модулиMenuItem.Height - 3 - y)
};
            e.Graphics.FillPolygon(Brushes.Black, points);
        }

        private void содержаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form() { Name = "helpForm", Text = "Справка", ShowIcon = false, Size = new Size(555, 283) };
            form.TopMost = true;
            var helpFile = Directory.GetFiles(Application.StartupPath, "ПО Bazis. Руководство пользователя.chm", SearchOption.AllDirectories);

            if (helpFile.Count() != 0)
                Help.ShowHelp(form, helpFile[0]);
            else MessageBox.Show("Отсутствует файл справки!");
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form() { Name = "aboutProgrammForm", Text = "О программе", ShowIcon = false, Size = new Size(555, 283) };
            var control = new AboutProgrammControl { Dock = DockStyle.Fill };

            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void сведенияMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form() { Name = "aboutLicenseForm", Text = "Информация о лицензии", ShowIcon = false, Size = new Size(555, 283) };
            form.TopMost = true;
            var control = new AboutLicenseControl { Dock = DockStyle.Fill };

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
                MessageBox.Show(ex.Message);
            }

            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void StartLisenceForm()
        {
            var form = new Form() { Name = "checkForm", Text = "Лицензирование", ShowIcon = false, Size = new Size(450, 250) };
            var control = new ClientControl() { Dock = DockStyle.Fill };

            control.LicenseActionEvent += (ar1,ar2) => 
            {
                var controls = toolStripContainer.ContentPanel.Controls.Find(activePage, false);
                if(controls.Length > 0)
                {
                    serverConnection = new ClientController(ar1, ar2);
                    serverConnection.RequestServer(activePage + " Взять");

                    control.LabelAnswer = serverConnection.Answer;

                    if (serverConnection.Answer == "можно")
                    {
                        var page = (BasePage)controls[0];
                        StartLicensing(activePage, page);
                    }
                }
            };
            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var settings = new SettingsControl() { Dock = DockStyle.Fill };

            settings.SetSettings(settingsConfig);
            
            settings.SaveSettingsEvent += (ar) =>
            {
                settingsConfig = ar;
            };

            var controls = toolStripContainer.ContentPanel.Controls.Find(activePage, false);

            if (controls.Length > 0)
            {
                var basePage = (BasePage)controls[0];
                settings.SetSelectionGroupColorEvent += (ar) => basePage.SelectionGroupColor = ar;
                settings.SetSelectionObjectColorEvent += (ar) => 
                basePage.SceneControl.SelectionColor = ar;

                settings.SetSolverPathEvent += (ar) =>
                {
                    if (basePage is TaskPage taskPage)
                        taskPage.SolverPath = ar;
                };
                settings.SetBackGroundColorEvent += (ar) =>
                {
                    basePage.SceneControl.BackGroundColor = ar;
                    basePage.SceneControl.DisplayObjects();
                };
 

                settings.SetLightingEvent += (ar) =>
                {
                    basePage.SceneControl.IsLighting = ar;
                    basePage.SceneControl.DisplayObjects();
                };

                settings.SetTransparencyEvent += (ar) =>
                {
                    basePage.SceneControl.IsBlending = ar;
                    basePage.SceneControl.DisplayObjects();
                };

                settings.SetLightingIntensityEvent += (ar) =>
                {
                    basePage.SceneControl.LightAttenuation = 1 - ar / 100.0f;
                    basePage.SceneControl.DisplayObjects();
                };
 

                settings.SetLighterPositionEvent += (ar) =>
                {
                    var kx = (float)(basePage.SceneControl.SceneWidth / settings.Width);
                    var ky = (float)(basePage.SceneControl.SceneHeight / settings.Height);

                    var x = ar.X * kx;
                    var y = ar.Y * ky;

                    basePage.SceneControl.LightTranslateX = x;
                    basePage.SceneControl.LightTranslateY = y;

                    basePage.SceneControl.DisplayObjects();
                };
            }
                 
            var form = new Form() {
                Name = "settings",
                Text = "Настройки",
                TopMost = true,
                ShowIcon = false,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Width = 350,
                Height = 465
            };

            form.Controls.Add(settings);
            form.Show();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            //KillAlreadyLaunchdExamples();
            LoadConfig();
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

        private void LoadConfig()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fullPath = $@"{folder}\settingsConfig.json";

            if (File.Exists(fullPath))
            {
                var settings = File.ReadAllText(fullPath);
                var settingsConfig =(SettingsConfig)JsonConvert.DeserializeObject(settings, typeof(SettingsConfig));
                if (settingsConfig != null)
                {
                    this.settingsConfig = settingsConfig;
                }
            }
        }

        private void получитьЛицензиюMenuItem_Click(object sender, EventArgs e)
        {
            StartLisenceForm();
        }

        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serverConnectionThread != null)
            {
                serverConnectionThread.Abort();

                while (true)
                    if (!serverConnectionThread.IsAlive)
                        break;
            }
        }

        private void новостиВерсииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReleaseNotes();
        }

        private static void ShowReleaseNotes()
        {
            var form = new Form() { Name = "newsForm", Text = "Новости версии", ShowIcon = false, Size = new Size(555, 283) };
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
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var folderName = dialog.SelectedPath;
                
                project = new ProjectData("newProject", folderName);

                project.ModelData = new ModelData();
                project.TaskData = new TaskData();
                project.ResultData = new ResultData();

                project.Loader = new LoadProjectFromTextFormat();
                project.Saver = new SaveProjectTextFormat();
            }

            MessageBox.Show("Создан новый проект");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.DefaultExt = "bpf";
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;

                var path = Path.GetDirectoryName(dialog.FileName);
                var name = Path.GetFileName(dialog.FileName);

                project = new ProjectData(name, path);

                project.ModelData = new ModelData();
                project.TaskData = new TaskData();
                project.ResultData = new ResultData();

                project.Loader = new LoadProjectFromTextFormat();
                project.Saver = new SaveProjectTextFormat();

                project.Load();

                модулиMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.DefaultExt = "bpf";

                if (saveDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                module.SaveAsProjectData(saveDialog.FileName);
            }
            module.PresentProjectOnTree();
        }

        private void импортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var filterMesh =
"All files(*.*)|*.*|" +
"Visual-Mesh ESI Group(*.ASC)|*.ASC|" +
"GMSH(*.inp*)|*.inp|" +
"ANSYS(*.cdb*)|*.cdb|" +
"SOLOMIA(*.dat*)|*.dat";

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = filterMesh;
                if (dialog.ShowDialog() == DialogResult.Cancel)
                    return;

                project.ClearAllData();
                project.Name = "newProject";
                project.Comments = "newComments";

                var folder = Path.GetDirectoryName(dialog.FileName);
                project.Path = folder;

                var ext = Path.GetExtension(dialog.FileName);

                if (ext == ".inp")
                    project.ModelData.Loader = new LoadModelFromGMSHTextFile();
                else if (ext == ".ASC")
                    project.ModelData.Loader = new LoadModelFromASCIITextFile();
                else if (ext == ".dat")
                    project.ModelData.Loader = new LoadModelFromSalomeFile();
                else if (ext == ".stl")
                    project.ModelData.Loader = new LoadModelFromSTLFile();
                else
                    project.ModelData.Loader = new LoadModelFromCDBTextFile();

                project.ModelData.Load(dialog.FileName);

                модулиMenuItem.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
