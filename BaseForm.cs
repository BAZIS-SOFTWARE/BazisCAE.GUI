
using BazisGUI.AboutProgramControl;
using DataBaseController;
using Newtonsoft.Json;
using Project;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using ConnectionController;
using BazisGUI.SettingsControl;
using System.Diagnostics;
using System.Threading;
using HeatTreatmentModule;
using BaseModule;
using WeldingModule;
using ConnectionModule;
using TaskModule;
using ResultModule;
using ModelModule;

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
            SelectionColor = Color.GreenYellow
        };

        EventHandler openProjectEventHandler = null;
        EventHandler showNavigatorEventHandler = null;
        EventHandler showConsoleEventHandler = null;
        private Thread serverConnectionThread;

        public Controller connectionContr { get; private set; }

        public BaseForm()
        {
            InitializeComponent();
            project = new ProjectData("newProject", Application.StartupPath);
            activePage = "none";
            //connectTimer.Interval = 500;
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
            var licToken = new LicenseToken();
            toolStripContainer.ContentPanel.Controls.RemoveByKey(activePage);

            activePage = moduleName;

            foreach (var activeMenuItem in activeMenuItems)
                menuStrip.Items.Remove(activeMenuItem);

            BasePage module;
            if (moduleName == "Weld")
            {
                var taskPage = new WeldingPage() { Dock = DockStyle.Fill, Name = activePage, Project = project };
                taskPage.MatDataLoader = new LoadMaterialDataBaseFromTextFormat();
                taskPage.FunDataLoader = new LoadFunctionDataBaseFromTextFormat();
                taskPage.MatDataSaver = new SaveMaterialDataBaseToTextFormat();
                taskPage.FunDataSaver = new SaveFunctionDataBaseToTextFormat();
                taskPage.DataInformer = new DataBaseInformer();
                taskPage.SolverPath = settingsConfig.SolverPath;

                module = taskPage;
                licToken = CheckLicense("Weld");
            }

            else if (moduleName == "HeatTreatment")
            {
                var taskPage = new HeatTreatmentPage() { Dock = DockStyle.Fill, Name = activePage, Project = project };
                taskPage.MatDataLoader = new LoadMaterialDataBaseFromTextFormat();
                taskPage.FunDataLoader = new LoadFunctionDataBaseFromTextFormat();
                taskPage.MatDataSaver = new SaveMaterialDataBaseToTextFormat();
                taskPage.FunDataSaver = new SaveFunctionDataBaseToTextFormat();
                taskPage.DataInformer = new DataBaseInformer();
                taskPage.SolverPath = settingsConfig.SolverPath;

                module = taskPage;
                licToken = CheckLicense("HeatTreatment");
            }

            else if (moduleName == "Result")
            {
                module = new ResultPage() { Dock = DockStyle.Fill, Name = activePage, Project = project };
                licToken = CheckLicense("Result");
            }

            else
            {
                module = new ModelPage() { Dock = DockStyle.Fill, Name = activePage, Project = project };
                licToken = CheckLicense("Mesh");
            }
            
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

            if (licToken.Answer == "можно")
                StartLicensing(licToken, module);

            else StartLisenceForm(licToken.Request);
        }

        private void StartLicensing(LicenseToken licToken, BasePage module)
        {
            сохранитьToolStripMenuItem.Enabled = true;
            сохранитькакToolStripMenuItem.Enabled = true;
            module.UnBlockInterface();

            licToken.Request = licToken.Request.Replace("Взять", "Работа");


            if (serverConnectionThread != null)
            {
                serverConnectionThread.Abort();

                while (true)
                    if (!serverConnectionThread.IsAlive)
                        break;
            }


            serverConnectionThread = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        Thread.Sleep(5000);
                        connectionContr.RequestServer(licToken);
                    }

                }
                catch (Exception ex)
                {
                    if(ex is ThreadAbortException != true)
                    {
                        MessageBox.Show(ex.Message);
                        Invoke(new Action(() => { Application.ExitThread(); }));
                    }

                }
            });
            serverConnectionThread.Start();

        }

        private void SetGeneralSettings(BasePage module)
        {
            module.SceneControl.BackGroundColor = settingsConfig.BackGroudColor;
            module.SceneControl.SelectionColor = settingsConfig.SelectionColor;
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

            form.Controls.Add(control);
            form.ShowDialog();
        }

        public LicenseToken CheckLicense(string request)
        {
            var licToken = new LicenseToken() { Request = request + " Взять"};

            connectionContr = new ConnectionController.Controller();
            var net = Environment.GetEnvironmentVariable("BazisServerPath", EnvironmentVariableTarget.Machine);
            
            if (net != null)
            {
                try
                {
                    licToken.IPAddress = IPAddress.Parse(net.Split(':')[0]);
                    licToken.Port = int.Parse(net.Split(':')[1]);
                    connectionContr.RequestServer(licToken);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return licToken;
        }

        private void StartLisenceForm(string request)
        {
            var form = new Form() { Name = "checkForm", Text = "Лицензирование", ShowIcon = false, Size = new Size(450, 250) };
            var control = new ConnectionControl() { Dock = DockStyle.Fill };

            control.AddAction(request);
            control.LicenseActionEvent += (ar1) => 
            {
                if(ar1.Answer == "можно")
                {
                    var controls = toolStripContainer.ContentPanel.Controls.Find(activePage, false);

                    if (controls.Length > 0)
                    {
                        var page = (BasePage)controls[0];
                        StartLicensing(ar1, page);
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

                var controls = toolStripContainer.ContentPanel.Controls.Find(activePage, false);

                if (controls.Length > 0)
                {
                    var basePage = (BasePage)controls[0];
                    basePage.SceneControl.BackGroundColor = ar.BackGroudColor;
                    basePage.SceneControl.SelectionColor = ar.SelectionColor;

                    if (basePage is TaskPage taskPage)
                        taskPage.SolverPath = ar.SolverPath;
                    basePage.SceneControl.DisplayObjects();
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
            KillAlreadyLaunchdExamples();
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
            var controls = toolStripContainer.ContentPanel.Controls.Find(activePage, false);
            if (controls.Length > 0)
            {
                var form = new Form() { Name = "checkForm", Text = "Лицензирование", ShowIcon = false, Size = new Size(500, 315) };
                var control = new ConnectionControl() { Dock = DockStyle.Fill };

                control.AddAction(activePage);
                control.LicenseActionEvent += (ar1) =>
                {
                    if (ar1.Answer == "можно")
                    {

                        var page = (BasePage)controls[0];
                        StartLicensing(ar1, page);
                    }
                };
                form.Controls.Add(control);
                form.ShowDialog();
            }
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
