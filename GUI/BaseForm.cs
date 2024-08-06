
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
using Model;
using Tasks;
using Results.ResultsData;
using Model.IO;
using Results.IO;
using GmshApi.GmshController;
using ProjectInterfaces;
using System.Threading.Tasks;
using Results;
using ModelInterfaces;
using System.Runtime.Remoting.Messaging;
using System.Drawing.Drawing2D;
using MathNet.Numerics.LinearAlgebra;
using SceneInterface;
using ProjectInterfaces.Results;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BaseModule.Console;
using ProjectInterfaces.Tasks;
using UserControlsEx;

namespace BazisGUI
{

    public partial class BaseForm : Form
    {
        //private System.Windows.Forms.Timer connectTimer = new System.Windows.Forms.Timer();
        ProjectData project;

        //BasePage module;
        ModelController.ModelController modelController = new ModelController.ModelController(); 
        GmshController gmshController;
        IODataController dataController = new IODataController();
        ToolStripPage toolStripPage = new ToolStripPage() { Dock = DockStyle.Fill};

        SettingsConfig settingsConfig = new SettingsConfig()
        {
            BackGroudColor = Color.White,
            SelectObjectColor = Color.GreenYellow,
            Transparency = false,
            Lighting = true,
            BackRibbers = false
        };

        private Thread serverConnectionPing;

        ClientController serverConnection { get; set; }

        public BaseForm()
        {
            InitializeComponent();
            ComponentsPainter.Font = this.Font;
            ComponentsPainter.ScreenDPI = this.DeviceDpi;
            toolStripContainer.ContentPanel.Controls.Add(toolStripPage);
            tableLayoutPanel.BringToFront();
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
            SetModule("Mesh");

            var module = toolStripPage.BasePage;
            module.ScenePage.SceneControl.DisplayObjects();
        }
        private void анализРезультатов_Click(object sender, EventArgs e)
        {
            SetModule("Result");

            var module = toolStripPage.BasePage;
            module.ScenePage.SceneControl.DisplayObjects();
        }
        private void сварка_Click(object sender, EventArgs e)
        {
            SetModule("Weld");

            var module = toolStripPage.BasePage;
            module.ScenePage.SceneControl.DisplayObjects();
        }
        private void термообработка_Click(object sender, EventArgs e)
        {
            SetModule("HeatTreatment");

            var module = toolStripPage.BasePage;
            module.ScenePage.SceneControl.DisplayObjects();
        }

        private static void SetSceneViewMatrix(Matrix<float> viewMatrix, BasePage newModule)
        {
            newModule.ScenePage.SceneControl.GetCamera().SetViewMatrix(viewMatrix);
            newModule.ScenePage.SceneControl.ScaleObjs(1.0f); // TO DO Разобраться почему без этого компас сворачивается в точку
        }

        private void DisconnectWithServer(string moduleName)
        {
            //if (module != null)
            //{
                StopServerPing();
                serverConnection.RequestServer(moduleName + " Отдать");
            //}
        }

        private async void ResultModule_LoadResultsEvent(object sender,string fileName, bool mergeRes, bool addRes)
        {

            var dbExtension = System.IO.Path.GetExtension(fileName);
            var pureFileName = System.IO.Path.GetFileNameWithoutExtension(fileName);

            if (dbExtension == ".db")
                project.ResultData.Loader = new LoadResultsFileDB();
            else
                project.ResultData.Loader = new LoadResultsFileBrfTextFormat();

            var resultModule = sender as ResultPage;

            Enabled = false;
            if (!addRes)
                project.ResultData.Clear();

            var res = resultModule.LoadResultsAsync(fileName);
            await res;

            if (mergeRes)
                await resultModule.MergeResults(res.Result);

            Enabled = true;

            project.ResultData.AddRange(res.Result);
        } 

        private void SetModule(string moduleName)
        {
            var module = toolStripPage.BasePage;

            var viewMatrix = module.ScenePage.SceneControl.GetCamera().GetViewMatrix();
            var splitters = module.SplittersController.GetSplitters();

            DisconnectWithServer(module.Name);

            CloseActivePageChildControls(module.Name);

            var newModule = CreateModule(moduleName);

            AddModule(newModule);

            SetGeneralSettings(newModule);
            LicenseModule(newModule);

            PresentProjectOnModule(newModule);

            newModule.SplittersController.SetSplitters(splitters);
            SetSceneViewMatrix(viewMatrix, newModule);
        }

        private void AddModule(BasePage module)
        {          
            toolStripPage.BasePage = module;
            //toolStripPage.selectToolStrip.Location = new Point(3, 0);
            toolStripPage.BasePage.SceneInitialization();
            toolStripPage.BringToFront();

            tableLayoutPanel.Hide();

        }

        private void LicenseModule(BasePage module)
        {
            serverConnection.RequestServer(module.Name + " Взять");

            if (serverConnection.Answer == "можно")
            {
                UnBlockGeneralMenuInterface(module.Name, true);
                StartLicensing(module);
            }

            else StartLisenceForm(module);
        }

        private void ViewInterface(string moduleName)
        {
            resultsMenuItem.Visible = false;
            tasksMenuItem.Visible = false;
            dataBasesMenuItem.Visible = false;
            meshMenuItem.Visible = false;

            if (moduleName == "Mesh")
            {
                meshMenuItem.Visible = true;
            }
            else if (moduleName == "Result")
            {
                resultsMenuItem.Visible = true;
            }
            else if (moduleName == "Weld" | moduleName == "HeatTreatment")
            {
                tasksMenuItem.Visible = true;
                dataBasesMenuItem.Visible = true;

                foreach (var item in tasksMenuItem.DropDownItems.Cast<ToolStripMenuItem>())
                    item.Visible = false;

                if (moduleName == "Weld")
                {
                    arcWeldingMenuItem.Visible = true;
                    lazerWeldingMenuItem.Visible = true;
                    fsWeldingMenuItem.Visible = true;
                }
                else
                {
                    heatingMenuItem.Visible = true;
                    quenchingMenuItem.Visible = true;
                    temperingMenuItem.Visible = true;
                }
            }
        }

        private void UnBlockGeneralMenuInterface(string moduleName, bool flag)
        {
            if(moduleName == "Mesh")
            {
                if(flag)
                    meshMenuItem.Enabled = true;
                else
                    meshMenuItem.Enabled = false;
            }
            else if(moduleName == "Result")
            {
                if (flag)
                    resultsMenuItem.Enabled = true;
                else
                    resultsMenuItem.Enabled = false;
            }
            else if(moduleName == "Weld" | moduleName == "HeatTreatment")
            {
                if (flag)
                {
                    tasksMenuItem.Enabled = true;
                    dataBasesMenuItem.Enabled = true;
                }
                else
                {
                    tasksMenuItem.Enabled = false;
                    dataBasesMenuItem.Enabled = false;
                }
            }
        }

        private BasePage CreateModule(string moduleName)
        {
            BasePage module;
            if (moduleName == "Weld")
            {
                var taskPage = new WeldingPage() { Dock = DockStyle.Fill, Name = moduleName, TaskData = project.TaskData };
                taskPage.SolverPath = settingsConfig.SolverPath;
                taskPage.PreProc = new PreProc();
                taskPage.NeedSaveProjectEvent += TaskPage_NeedSaveProjectEvent;
                module = taskPage;
            }

            else if (moduleName == "HeatTreatment")
            {

                //модулиMenuItem.Image = термообработка.Image;
                var taskPage = new HeatTreatmentPage() { Dock = DockStyle.Fill, Name = moduleName, TaskData = project.TaskData };
                taskPage.SolverPath = settingsConfig.SolverPath;
                taskPage.PreProc = new PreProc();
                taskPage.NeedSaveProjectEvent += TaskPage_NeedSaveProjectEvent;
                module = taskPage;
            }

            else if (moduleName == "Result")
            {
                resultsMenuItem.Visible = true;
                var resPage = new ResultPage() { Dock = DockStyle.Fill, Name = moduleName, ResultData = project.ResultData };
                resPage.ResultsController = new ResultsController();
                resPage.LoadResultsEvent += ResultModule_LoadResultsEvent;
                module = resPage;
            }

            else
            {
                meshMenuItem.Visible = true;
                var modelPage = new ModelPage() { Dock = DockStyle.Fill, Name = moduleName };
                modelPage.GmshController = gmshController;
                module = modelPage;
            }

            return module;
        }

        private void TaskPage_NeedSaveProjectEvent(object sender)
        {
            project.Save();

            var basePage = (BasePage)sender;
            basePage.ConsoleControl.PrintInfo("Проект сохранен в " + project.GeneralData.Path, Color.Black);
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

        private void StartLicensing(BasePage module)
        {

            serverConnectionPing = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        lock (serverConnection)
                        {
                            serverConnection.RequestServer(module.Name + " Работа");
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
                            UnBlockGeneralMenuInterface(module.Name, false);
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

        private void SetGeneralSettings(BasePage module)
        {
            viewMenuItem.Visible = true;
            ViewInterface(module.Name);

            var que = new Queue<int>();
            que.Enqueue((int)(Screen.PrimaryScreen.Bounds.Width * 0.1f));
            que.Enqueue((int)(Screen.PrimaryScreen.Bounds.Height * 0.45f));

            module.SplittersController.SetSplitters(que);

            module.GeneralData = project.GeneralData;
            module.ScenePage.ModelData = project.ModelData;
            module.ScenePage.ModelController = modelController;
            module.ScenePage.SceneControl.BackGroundColor = settingsConfig.BackGroudColor;
            module.ScenePage.SceneControl.IsBlending = settingsConfig.Transparency;
            module.ScenePage.SceneControl.IsLighting = settingsConfig.Lighting;

            module.ScenePage.PresentersCreator.TransparencyValue = (int)(255 * settingsConfig.TransparencyValue / 100.0f);

            module.ScenePage.SceneControl.SelectionColor = Color.FromArgb(module.ScenePage.PresentersCreator.TransparencyValue, settingsConfig.SelectObjectColor);
            module.SelectionGroupColor = Color.FromArgb(module.ScenePage.PresentersCreator.TransparencyValue, settingsConfig.SelectGroupColor);

            var objs = project.ModelData.ObjectData.GetAllObjects();

            foreach (var obj in objs)
            {
                var preColor = obj.SlaveColor;
                var newColor = Color.FromArgb(module.ScenePage.PresentersCreator.TransparencyValue, preColor);
                obj.MasterColor = newColor;
                obj.SlaveColor = newColor;
            }
        }

        private void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            var module = toolStripPage.BasePage;
            if(module != null)
            {
                var controls = toolStripContainer.ContentPanel.Controls.Find(module.Name, false);

                if (controls.Length > 0)
                {
                    var baseControl = (BasePage)controls[0];
                    baseControl.PressedKey = e.KeyCode;
                }
            }
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
                MessageBox.Show(ex.Message);
            }

            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void StartLisenceForm(BasePage module)
        {
            var form = new Form() { Name = "checkForm", Text = "Лицензирование", ShowIcon = false };
            var control = new ClientControl() { Dock = DockStyle.Fill };



            control.LicenseActionEvent += (ar1,ar2) => 
            {
                //var controls = toolStripContainer.ContentPanel.Controls.Find(activePage, false);
                if(module != null)
                {
                    serverConnection = new ClientController(ar1, ar2);
                    serverConnection.RequestServer(module.Name + " Взять");

                    control.LabelAnswer = serverConnection.Answer;

                    if (serverConnection.Answer == "можно")
                    {
                        UnBlockGeneralMenuInterface(module.Name,true);
                        StartLicensing(module);
                    }
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
            
            settings.SaveSettingsEvent += (ar) =>
            {
                settingsConfig = ar;
            };

            var forms = Application.OpenForms.Cast<Form>().ToList();

            if (forms.Find(x => x.Name == "settings") == null)
            {
                var form = new Form()
                {
                    Name = "settings",
                    Text = "Настройки",
                    TopMost = true,
                    ShowIcon = false
                };

                form.ClientSize = settings.Size;
                form.Controls.Add(settings);
                form.Show();
            }


            var module = toolStripPage.BasePage;
            if (module != null)
            {
                SetSettingsToModule(module,settings);
            }
        }

        private void SetSettingsToModule(BasePage module,SettingsControl settings)
        {
            settings.SetSelectionGroupColorEvent += (ar) => module.SelectionGroupColor = ar;
            settings.SetSelectionObjectColorEvent += (ar) =>
            module.ScenePage.SceneControl.SelectionColor = ar;

            settings.SetSolverPathEvent += (ar) =>
            {
                if (module is TaskPage taskPage)
                    taskPage.SolverPath = ar;
            };
            settings.SetBackGroundColorEvent += (ar) =>
            {
                module.ScenePage.SceneControl.BackGroundColor = ar;
                module.ScenePage.SceneControl.DisplayObjects();
            };


            settings.SetLightingEvent += (ar) =>
            {
                module.ScenePage.SceneControl.IsLighting = ar;
                module.ScenePage.SceneControl.DisplayObjects();
            };

            settings.SetTransparencyEvent += (ar) =>
            {
                module.ScenePage.SceneControl.IsBlending = ar;
                module.ScenePage.ClearAllDataOnScene();
                module.ScenePage.PresentAllModelObjectsToScene();
                module.ScenePage.SceneControl.DisplayObjects();
            };

            settings.SetTransparencyValueEvent += (ar1) =>
            {
                module.ScenePage.PresentersCreator.TransparencyValue = (int)(ar1 / 100.0f * 255);

                module.ScenePage.SceneControl.SelectionColor = Color.FromArgb(module.ScenePage.PresentersCreator.TransparencyValue, settingsConfig.SelectObjectColor);
                module.SelectionGroupColor = Color.FromArgb(module.ScenePage.PresentersCreator.TransparencyValue, settingsConfig.SelectGroupColor);

                var objs = project.ModelData.ObjectData.GetAllObjects();

                foreach (var obj in objs)
                {
                    var preColor = obj.SlaveColor;
                    var newColor = Color.FromArgb(module.ScenePage.PresentersCreator.TransparencyValue, preColor);
                    obj.MasterColor = newColor;
                    obj.SlaveColor = newColor;
                } 
                
                module.ScenePage.ClearAllDataOnScene();
                module.ScenePage.PresentAllModelObjectsToScene();
                module.ScenePage.SceneControl.DisplayObjects();
            };

            settings.SetLightingIntensityEvent += (ar) =>
            {
                module.ScenePage.SceneControl.LightAttenuation = 1 - ar / 100.0f;
                module.ScenePage.SceneControl.DisplayObjects();
            };


            settings.SetLighterPositionEvent += (ar) =>
            {
                var kx = (float)(module.ScenePage.Width / settings.Width);
                var ky = (float)(module.ScenePage.Height / settings.Height);

                var x = ar.X * kx;
                var y = ar.Y * ky;

                module.ScenePage.SceneControl.LightTranslateX = x;
                module.ScenePage.SceneControl.LightTranslateY = y;

                module.ScenePage.SceneControl.DisplayObjects();
            };
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            var verStr = "Версия " + $"{ver.Major}.{ver.Minor}.{ver.Build}";
            lblVersion.Text = verStr;

            this.settingsConfig = dataController.LoadConfig();
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

        private void получитьЛицензиюMenuItem_Click(object sender, EventArgs e)
        {
            var module = toolStripPage.BasePage;

            if (module != null)
                StartLisenceForm(module);
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

                project = dataController.CreateNewProject(folderName, "newProject");

                lblStatus.Text = $"{project.GeneralData.Path}\\{project.GeneralData.Name}";

                модулиMenuItem.Enabled = true;

                SetModule("Mesh");

                var module = toolStripPage.BasePage;
                module.ScenePage.SceneControl.FitObjectsToScreen();
                module.ScenePage.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private async void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                project =  await dataController.OpenProject();

                if(project != null)
                {
                    lblStatus.Text = $"{project.GeneralData.Path}\\{project.GeneralData.Name}";

                    var ierr = 0;
                    gmshController?.Clear(ref ierr);

                    модулиMenuItem.Enabled = true;

                    SetModule("Mesh");

                    var module = toolStripPage.BasePage;
                    module.ScenePage.SceneControl.FitObjectsToScreen();
                    module.ScenePage.SceneControl.DisplayObjects();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private async void импортСеткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                project = await dataController.ImportMesh();

                lblStatus.Text = $"{project.GeneralData.Path}\\{project.GeneralData.Name}";

                var ierr = 0;
                gmshController?.Clear(ref ierr);

                модулиMenuItem.Enabled = true;

                SetModule("Mesh");

                var module = toolStripPage.BasePage;
                module.ScenePage.SceneControl.FitObjectsToScreen();
                module.ScenePage.SceneControl.DisplayObjects();
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

        private void webPageLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(webPageLabel.Text); //где path это путь к сайту
        }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataController.SaveAsProject(project);

            var module = toolStripPage.BasePage;
            module?.ConsoleControl.PrintInfo("Проект сохранен", Color.Black);
            lblStatus.Text = $"{project.GeneralData.Path}\\{project.GeneralData.Name}";

            module?.PresentProjectOnTree();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            project?.Save();
            var module = toolStripPage.BasePage;
            module?.ConsoleControl.PrintInfo("Проект сохранен", Color.Black);
        }

        private async void импортГеометрииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                project = dataController.ImportGeometry(ref gmshController);

                if(project != null)
                {
                    lblStatus.Text = $"{project.GeneralData.Path}\\{project.GeneralData.Name}";

                    модулиMenuItem.Enabled = true;

                    SetModule("Mesh");

                    var module = toolStripPage.BasePage;
                    module.ScenePage.SceneControl.FitObjectsToScreen();
                    module.ScenePage.SceneControl.DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PresentProjectOnModule(BasePage module)
        {
            module.ScenePage.PresentAllModelObjectsToScene();
            module.PresentProjectOnTree();
            toolStripPage.PresentModelOnSelectToolStrip(project.ModelData.ObjectData);
        }

        private void OnClosingForm(object sender, FormClosingEventArgs e)
        {
                var ierr = 0;
                gmshController?.Finalize(ref ierr);
        }

        private void модулиMenuItem_Paint(object sender, PaintEventArgs e)
        {
            // тут можно порисовать на кнопке "модули"
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var module = toolStripPage.BasePage;
            var splitContainer = (SplitContainer)module.NavigatorControl.Parent.Parent;
            splitContainer.Panel1Collapsed = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var module = toolStripPage.BasePage;
            var splitContainer = (SplitContainer)module.ConsoleControl.Parent.Parent;
            splitContainer.Panel2Collapsed = false;
        }

        private void createSurfaceElementsMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ModelPage)toolStripPage.BasePage;
            module.CreateSurfaceElements();
        }

        private void mesh3DGeneratorMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ModelPage)toolStripPage.BasePage;

            var res = MessageBox.Show("Вы собираетесь запустить сеточный генератор. При нажатии на кнопку \"OK\" Все данные о задаче будут удалены!",
"Внимание!", MessageBoxButtons.OKCancel);

            if (res == DialogResult.OK)
            {
                project.TaskData.Clear();
                module.OpenMesh3DGenerator();
            }
          
        }

        private void arcWeldingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (WeldingPage)toolStripPage.BasePage;

            var adv = module.CreateWeldingAdvisor(WeldingKind.ARC);

            module.DeleteAdvisor();

            if (arcWeldingMenuItem.Checked)
                module.ShowAdvisor(sender,adv);
            else module.DeleteAdvisor();
        }

        private void материалыMenuItem_Click(object sender, EventArgs e)
        {
            var module = (TaskPage)toolStripPage.BasePage;
            module.OpenMaterialsDB();
        }

        private void функцииMenuItem_Click(object sender, EventArgs e)
        {
            var module = (TaskPage)toolStripPage.BasePage;
            module.OpenFunctionsDB();
        }

        private void lazerWeldingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (WeldingPage)toolStripPage.BasePage;

            var adv = module.CreateWeldingAdvisor(WeldingKind.Lazer);

            module.DeleteAdvisor();

            if (lazerWeldingMenuItem.Checked)
                module.ShowAdvisor(sender, adv);
            else module.DeleteAdvisor();
        }

        private void fsWeldingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (WeldingPage)toolStripPage.BasePage;

            var adv = module.CreateWeldingAdvisor(WeldingKind.FrictionStearing);

            module.DeleteAdvisor();

            if (fsWeldingMenuItem.Checked)
                module.ShowAdvisor(sender, adv);
            else module.DeleteAdvisor();
        }

        private void addResultsMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultPage)toolStripPage.BasePage;
            module.ShowOpenResultsFileDialog(true);
        }

        private void loadResultsMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultPage)toolStripPage.BasePage;
            module.ShowOpenResultsFileDialog(false);
        }

        private void showValueMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultPage)toolStripPage.BasePage;

            if (showValueMenuItem.Checked)
                module.IsResultsValueShowen = true;
            else
            {
                module.IsResultsValueShowen = false;
                module.ScenePage.SceneControl.HideDisplayText3D();
                module.ScenePage.SceneControl.DisplayObjects();
            }
        }

        private void createFieldMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultPage)toolStripPage.BasePage;
            module.ShowAnimation();
        }

        private void createPlotMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultPage)toolStripPage.BasePage;
            module.CreateGraph();
        }

        private void scaleSettingsMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultPage)toolStripPage.BasePage;
            module.ShowScalePage();
        }

        private void exportResultsMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultPage)toolStripPage.BasePage;
            module.ShowExportResultsPage();
        }

        private void heatingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (HeatTreatmentPage)toolStripPage.BasePage;

            var adv = module.CreateHeatTreatmentAdvisor(ProcessType.Heating);

            module.DeleteAdvisor();

            if (heatingMenuItem.Checked)
                module.ShowAdvisor(sender, adv);
            else module.DeleteAdvisor();
        }

        private void temperingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (HeatTreatmentPage)toolStripPage.BasePage;

            var adv = module.CreateHeatTreatmentAdvisor(ProcessType.Tempering);

            module.DeleteAdvisor();

            if (temperingMenuItem.Checked)
                module.ShowAdvisor(sender, adv);
            else module.DeleteAdvisor();
        }

        private void quenchingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (HeatTreatmentPage)toolStripPage.BasePage;

            var adv = module.CreateHeatTreatmentAdvisor(ProcessType.Quenching);

            module.DeleteAdvisor();

            if (quenchingMenuItem.Checked)
                module.ShowAdvisor(sender, adv);
            else module.DeleteAdvisor();
        }
    }
}
