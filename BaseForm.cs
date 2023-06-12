
using BaseModule;
using BazisGUI.AboutProgramControl;
using BazisGUI.SettingsControl;
using ConnectionController;
using ConnectionModule;
using HeatTreatmentModule;
using LicenseData;
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
using WeldingModule;

namespace BaseForm
{

    public partial class BaseForm : Form
    {
        //private System.Windows.Forms.Timer connectTimer = new System.Windows.Forms.Timer();
        ProjectData project;
        private string activePage;
        private List<ToolStripMenuItem> activeMenuItems = new List<ToolStripMenuItem>();

        SettingsConfig settingsConfig = new SettingsConfig()
        {
            BackGroudColor = Color.White,
            SelectionColor = Color.GreenYellow,
            Transparency = true,
            Lighting = true
        };

        EventHandler openProjectEventHandler = null;
        EventHandler showNavigatorEventHandler = null;
        EventHandler showConsoleEventHandler = null;
        private Thread serverConnectionThread;

        Controller serverConnection { get; set; }

        public BaseForm()
        {
            InitializeComponent();
            project = new ProjectData("newProject", Application.StartupPath);
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

                serverConnection = new ConnectionController.Controller(iPAddress, port);
            }
            else
            {
                MessageBox.Show
                    (
                    $@"Адресс подключения: {IPAddress.Loopback}, порт: {8001}\n
                                Внимание! Не найдена переменная среды ""BazisServerPath"""
                    );
                serverConnection = new ConnectionController.Controller(IPAddress.Loopback, 8001);
            }
        }

        private void построениеСетки_Click(object sender, EventArgs e)
        {
            модулиMenuItem.Image = построениеСетки.Image;
            this.Text = "Сетка";
            AddModule("Mesh");
        }

        private void анализРезультатов_Click(object sender, EventArgs e)
        {
            модулиMenuItem.Image = анализРезультатов.Image;
            this.Text = "Результаты";
            AddModule("Result");
        }

        private void сварка_Click(object sender, EventArgs e)
        {
            модулиMenuItem.Image = сварка.Image;
            this.Text = "Сварка";
            AddModule("Weld");
        }

        private void термообработка_Click(object sender, EventArgs e)
        {
            модулиMenuItem.Image = термообработка.Image;
            this.Text = "Термообработка";
            AddModule("HeatTreatment");
        }

        private void AddModule(string moduleName)
        {
            DisconnectWithServer(true);

            toolStripContainer.ContentPanel.Controls.RemoveByKey(activePage);

            activePage = moduleName;

            foreach (var activeMenuItem in activeMenuItems)
                menuStrip.Items.Remove(activeMenuItem);

            BasePage module;
            if (moduleName == "Weld")
            {
                var taskPage = new WeldingPage() { Dock = DockStyle.Fill, Name = activePage, Project = project };
                taskPage.SolverPath = settingsConfig.SolverPath;

                module = taskPage;
            }

            else if (moduleName == "HeatTreatment")
            {
                var taskPage = new HeatTreatmentPage() { Dock = DockStyle.Fill, Name = activePage, Project = project };
                taskPage.SolverPath = settingsConfig.SolverPath;

                module = taskPage;
            }

            else if (moduleName == "Result")
            {
                module = new ResultPage() { Dock = DockStyle.Fill, Name = activePage, Project = project };
            }

            else
            {
                module = new ModelPage() { Dock = DockStyle.Fill, Name = activePage, Project = project };
            }

            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            var verStr = "Версия " + $"{ver.Major}.{ver.Minor}.{ver.Build}";
            module.SetVersion(verStr);

            module.ChangeProjectDataEvent += (object ar1, ProjectData ar2) => { project = ar2; };

            SingMenuItemsEvents(module);
            SetGeneralSettings(module);

            toolStripContainer.ContentPanel.Controls.Add(module);

            module.CreateMenuInterface();
            module.SceneInitialization();
            activeMenuItems.Clear();

            foreach (var menuItem in module.GetToolStripMenuItems())
            {
                menuStrip.Items.Insert(2, menuItem);
                activeMenuItems.Add(menuItem);
            }

            pictureBox.Hide();


            var answer = serverConnection.RequestServer(moduleName + " Взять");

            if (answer == "можно")
                StartLicensing(moduleName, module);
            else StartLisenceForm();

        }

        private void StartLicensing(string moduleName, BasePage module)
        {
            сохранитьToolStripMenuItem.Enabled = true;
            сохранитькакToolStripMenuItem.Enabled = true;
            module.UnBlockInterface();

            serverConnectionThread = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        lock (serverConnection)
                        {
                            var answer = serverConnection.RequestServer(moduleName + " Работа");
                            if(answer == "Остановка")
                            {
                                DisconnectWithServer(false);
                                MessageBox.Show("Внимание! Лицензирование прервано. Зайдите в модуль заново.");
                            }    
                                
                        }
                        Thread.Sleep(3000);
                    }

                }
                catch (Exception ex)
                {                   
                    if (ex is ThreadAbortException != true)
                    {
                        MessageBox.Show(ex.Message);
                        Invoke(new Action(() => { Application.ExitThread(); }));
                    }

                }
            });
            serverConnectionThread.Start();

        }

        private void DisconnectWithServer(bool revertLicense)
        {
            if (serverConnectionThread != null)
            {
                while (true)
                {
                    if (serverConnectionThread.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
                        serverConnectionThread.Abort();
                    if (serverConnectionThread.ThreadState == System.Threading.ThreadState.Aborted)
                        break;
                }

                if(revertLicense)
                    serverConnection.RequestServer(activePage + " Отдать");
            }
        }

        private void SetGeneralSettings(BasePage module)
        {
            module.SceneBackGroundColor = settingsConfig.BackGroudColor;
            module.SceneSelectionColor = settingsConfig.SelectionColor;
            module.SceneTransparency = settingsConfig.Transparency;
            module.SceneLighting = settingsConfig.Lighting;
        }

        private void SingMenuItemsEvents(BasePage module)
        {
            // singup to open project click
            открытьToolStripMenuItem.Click -= openProjectEventHandler;
            openProjectEventHandler = (ar1, ar2) => { module.LoadProjectData("Bazis project file(*.bpf)|*.bpf|" + "All files(*.*)|*.*"); };
            открытьToolStripMenuItem.Click += openProjectEventHandler;

            // singup to show navigator click
            showNavigatorMenuItem.Click -= showNavigatorEventHandler;
            showNavigatorEventHandler = (ar1, ar2) => { module.ShowNavigator(); };
            showNavigatorMenuItem.Click += showNavigatorEventHandler;

            // singup to show console click
            showConsoleMenuItem.Click -= showConsoleEventHandler;
            showConsoleEventHandler = (ar1, ar2) => { module.ShowConsole(); };
            showConsoleMenuItem.Click += showConsoleEventHandler;
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
            var x = модулиMenuItem.Width - 6;
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
            var control = new AboutControl { Dock = DockStyle.Fill };

            try
            {
                var answer = serverConnection.RequestServer("CheckLicenseInfo");
                var licInfo = JsonConvert.DeserializeObject<LicenseInfo>(answer);
                
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
            var control = new ConnectionControl() { Dock = DockStyle.Fill };

            control.LicenseActionEvent += (ar1,ar2) => 
            {
                var controls = toolStripContainer.ContentPanel.Controls.Find(activePage, false);
                if(controls.Length > 0)
                {
                    serverConnection = new Controller(ar1, ar2);
                    var answer = serverConnection.RequestServer(activePage + " Взять");

                    if (answer == "можно")
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
                settingsConfig.BackGroudColor = ar.BackGroudColor;
                settingsConfig.SelectionColor = ar.SelectionColor;
                settingsConfig.SolverPath = ar.SolverPath;
                settingsConfig.Lighting = ar.Lighting;
                settingsConfig.Transparency = ar.Transparency;

                var controls = toolStripContainer.ContentPanel.Controls.Find(activePage, false);

                if (controls.Length > 0)
                {
                    var basePage = (BasePage)controls[0];
                    basePage.SceneBackGroundColor = ar.BackGroudColor;
                    basePage.SceneSelectionColor = ar.SelectionColor;
                    basePage.SceneTransparency = ar.Transparency;
                    basePage.SceneLighting = ar.Lighting;

                    if (basePage is TaskPage taskPage)
                        taskPage.SolverPath = ar.SolverPath;
                    basePage.SceneRedraw();
                }
            };
            var form = new Form() {
                Name = "settings",
                Text = "Настройки",
                TopMost = true,
                ShowIcon = false,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink               
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
                    this.settingsConfig.BackGroudColor = settingsConfig.BackGroudColor;
                    this.settingsConfig.SelectionColor = settingsConfig.SelectionColor;
                    this.settingsConfig.SolverPath = settingsConfig.SolverPath;
                }
            }
        }

        private void получитьЛицензиюMenuItem_Click(object sender, EventArgs e)
        {
            StartLisenceForm();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
