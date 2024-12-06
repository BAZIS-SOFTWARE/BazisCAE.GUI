
using BaseModule;
using Newtonsoft.Json;
using Project;
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
using ClientLogic;
using LicenseInfo;
using ClientGUI;
using BazisGUI.SettingsControls;
using Tasks;
using Results.IO;
using GmshApi.GmshController;
using Results;
using MathNet.Numerics.LinearAlgebra;
using ProjectInterfaces.Tasks;
using UserControlsEx;
using BazisGUI.Properties;
using System.Xml.Linq;
using ModelInterfaces;
using Results.ResultsData;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BaseModule.Utilities;
using ModelController;
using Scene.Interfaces;
using Scene;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using BaseModule.Tasks.WeldingModule;
using TaskModule.HeatTreatmentModule;
using BaseModule.Results;
using BaseModule.Tasks;
using BaseModule.Results.Animation;
using System.Runtime.InteropServices.ComTypes;
using BaseModule.Mesh;
using Model;

namespace BazisGUI
{

    public partial class BaseForm : Form
    {
        //private System.Windows.Forms.Timer connectTimer = new System.Windows.Forms.Timer();
        ProjectData project;

        //BasePage module;
        ModelController.ModelController modelController;
        GmshController gmshController;
        IODataController dataController = new IODataController();
        ResultsController resultsController = new ResultsController();
        PreProc preProc = new PreProc();
        ClientController serverConnection;

        public ToolStripPage ModulePage
        {
            get
            {
                return toolStripContainer.ContentPanel.Controls.Count == 0 ?
                    null :
                    toolStripContainer.ContentPanel.Controls[0] as ToolStripPage;
            }
            set
            {
                toolStripContainer.ContentPanel.Controls.Clear();
                toolStripContainer.ContentPanel.Controls.Add(value);
            }
        }

        SettingsConfig settingsConfig = new SettingsConfig()
        {
            BackGroudColor = Color.White,
            SelectObjectColor = Color.GreenYellow,
            Elem2DColor = Color.FromArgb(151, 188, 93),
            Elem3DColor = Color.Orange,
            NodeColor = Color.FromArgb(153, 192, 86),
            Transparency = false,
            Lighting = true,
            BackRibbers = false,
            Projection = false
        };

        private Thread serverConnectionPing;



        public BaseForm(string[] args)
        {
            InitializeComponent();
            ComponentsPainter.Font = this.Font;
            ComponentsPainter.ScreenDPI = this.DeviceDpi;

            tableLayoutPanel.BringToFront();
            GetServerConnection();

            if (args.Length != 0)
            {
                if(args.Contains("-proj"))
                {
                    var projInd = Array.IndexOf(args, "-proj");

                    if (args.Length - 1 - projInd < 1)
                        throw new Exception($"Отсутствуют необходимые аргументы для -proj path file");

                    var path = Path.GetDirectoryName(args[projInd + 1]);
                    var name = Path.GetFileName(args[projInd + 1]);

                    project = dataController.CreateNewProject(path,name);
                    project.Load();
                    modelController = new ModelController.ModelController(project.ModelData);
                }
                if(args.Contains("-res"))
                {
                    var resInd = Array.IndexOf(args, "-res");

                    if (args.Length - 1 - resInd < 1)
                        throw new Exception($"Отсутствуют необходимые аргументы для -res file");

                    var fullPath = Path.GetFullPath(args[resInd + 1]);

                    if(project == null)
                        throw new Exception($"Для загрузки результатов требуется сперва загрузить проект");

                    project.ResultData.Load(fullPath);
                }
                if (args.Contains("-cad"))
                {
                    var resInd = Array.IndexOf(args, "-cad");

                    if (args.Length - 1 - resInd < 1)
                        throw new Exception($"Отсутствуют необходимые аргументы для -cad file");

                    var fullPath = Path.GetFullPath(args[resInd + 1]);

                    if (gmshController == null)
                        gmshController = dataController.LoadGMSH();

                    var ierr = 0;
                    gmshController.Clear(ref ierr);
                    gmshController.Open(fullPath, ref ierr);

                    var path = Path.GetDirectoryName(fullPath);
                    var name = "new_Project.bpf";

                    project = dataController.CreateNewProject(path, name);
                    modelController = new ModelController.ModelController(project.ModelData);
                    dataController.UpdateGeometry(gmshController, project, ObjType.Точка);
                    dataController.UpdateGeometry(gmshController, project, ObjType.Линия);
                }
                lblStatus.Text = $"{project.GeneralData.Path}\\{project.GeneralData.Name}";

                модулиMenuItem.Enabled = true;

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
            модулиMenuItem.Image = Resources.м_34;
            ModulePage.BasePage.ScenePage.SceneControl.DisplayObjects();
        }
        private void анализРезультатов_Click(object sender, EventArgs e)
        {
            SetModule("Result");
            модулиMenuItem.Image = Resources.м_37;
            ModulePage.BasePage.ScenePage.SceneControl.DisplayObjects();
        }
        private void сварка_Click(object sender, EventArgs e)
        {
            SetModule("Weld");
            модулиMenuItem.Image = Resources.м_36;
            ModulePage.BasePage.ScenePage.SceneControl.DisplayObjects();
        }
        private void термообработка_Click(object sender, EventArgs e)
        {
            SetModule("HeatTreatment");
            модулиMenuItem.Image = Resources.м_35;
            ModulePage.BasePage.ScenePage.SceneControl.DisplayObjects();
        }

        private static void SetSceneViewMatrix(Matrix<float> viewMatrix, ScenePage scenePage)
        {
            scenePage.SceneControl.GetCamera().SetViewMatrix(viewMatrix);
            scenePage.SceneControl.FitObjectsToScreen();
            //scenePage.SceneControl.ScaleObjs(1.0f); // TO DO Разобраться почему без этого компас сворачивается в точку
        }

        private void DisconnectWithServer(string moduleName)
        {
            //if (module != null)
            //{
                StopServerPing();
                serverConnection.RequestServer(moduleName + " Отдать");
            //}
        }

        private async void ResultModule_LoadResultsEvent(object sender, string fileName, bool mergeRes, bool addRes)
        {

            var dbExtension = System.IO.Path.GetExtension(fileName);
            var pureFileName = System.IO.Path.GetFileNameWithoutExtension(fileName);

            if (dbExtension == ".db")
                project.ResultData.Loader = new LoadResultsFileDB();
            else
                project.ResultData.Loader = new LoadResultsFileBrfTextFormat();

            var resultModule = sender as ResultsPage;

            Enabled = false;
            if (!addRes)
                project.ResultData.Clear();

            var res = resultModule.LoadResultsAsync(fileName, project.ResultData);
            await res;

            if (mergeRes)
                await resultModule.MergeResults();

            Enabled = true;

            project.ResultData.AddRange(res.Result);

            var pAnPage = (PinnedAnimationControl)resultModule.EmbeddedControls.Find("pinnedAnimationControl", false)[0];

            var anPage = pAnPage.AnimationPage;

            if (!addRes)
                anPage.ClearResultsItems();

            var resDic = resultModule.CreateResultsDic();
            if (resDic.Count != 0)
            {
                anPage.SetResultsItems(resDic);
                anPage.ShowResultsTimeSteps(resDic.First().Key);
            }       
        }

        private void SetModule(string moduleName)
        {
            var module = ModulePage;

            var viewMatrix = module?.BasePage.ScenePage.SceneControl.GetCamera().GetViewMatrix();
            var splitters = module?.BasePage.GetSplitters();

            DisconnectWithServer(module?.Name);

            CloseActivePageChildControls(module?.Name);

            var newModule = CreateModule(moduleName);
            //Important to see in future

            //modelController = new ModelController.ModelController(project.ModelData);
            newModule.BasePage.SetGeneralData(project.GeneralData);
            newModule.BasePage.ScenePage.SetModelController(modelController);

            AddModule(newModule);

            SetGeneralSettings(newModule);
            LicenseModule(newModule);

            PresentProjectOnModule(newModule);

            if (splitters != null)
                newModule.BasePage.SetSplitters(splitters);
            if (viewMatrix != null)
                SetSceneViewMatrix(viewMatrix, newModule.BasePage.ScenePage);
        }

        private void AddModule(ToolStripPage module)
        {
            //toolStripPage.BasePage = module;
            ModulePage = module;
            //module.BasePage.SceneInitialization();
            module.BringToFront();

            tableLayoutPanel.Hide();
        }

        private void LicenseModule(ToolStripPage module)
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

        private ToolStripPage CreateModule(string moduleName)
        {
            if (moduleName == "Weld" | moduleName == "HeatTreatment")
            {
                TaskPage taskPage;
                if(moduleName == "Weld")
                    taskPage = new WeldingPage() { Dock = DockStyle.Fill, Name = moduleName};
                else
                    taskPage = new HeatTreatmentPage() { Dock = DockStyle.Fill, Name = moduleName };

                taskPage.SetTaskData(project.TaskData);
                taskPage.SetPreProc(preProc);

                taskPage.SolverPath = settingsConfig.SolverPath;
                taskPage.NeedSaveProjectEvent += TaskPage_NeedSaveProjectEvent;

                return taskPage;
            }

            else if (moduleName == "Result")
            {
                resultsMenuItem.Visible = true;
                var resPage = new ResultsPage() { Dock = DockStyle.Fill, Name = moduleName};
                resPage.SetResultsController(resultsController);
                resPage.SetResultData(project.ResultData);
                resPage.LoadResultsEvent += ResultModule_LoadResultsEvent;
                return resPage;
            }

            else
            {
                meshMenuItem.Visible = true;
                var modelPage = new ModelPage() { Dock = DockStyle.Fill, Name = moduleName };
                return modelPage;
            }


        }

        private void TaskPage_NeedSaveProjectEvent(object sender)
        {
            project.Save();

            var basePage = (sender as ToolStripPage).BasePage;
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

        private void StartLicensing(ToolStripPage module)
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

        private void SetGeneralSettings(ToolStripPage module)
        {
            viewMenuItem.Visible = true;

            var basePage = module.BasePage;

            ViewInterface(module.Name);

            var que = new Queue<int>();
            que.Enqueue((int)(Screen.PrimaryScreen.Bounds.Width * 0.25f));
            que.Enqueue((int)(Screen.PrimaryScreen.Bounds.Height * 0.65f));

            basePage.SetSplitters(que);

            basePage.ScenePage.TransparencyValue = (int)(255 * settingsConfig.TransparencyValue / 100.0f);
    
            basePage.ScenePage.SceneControl.BackGroundColor = settingsConfig.BackGroudColor;
            basePage.ScenePage.SceneControl.IsBlending = settingsConfig.Transparency;
            basePage.ScenePage.SceneControl.IsLighting = settingsConfig.Lighting;

            basePage.ScenePage.SceneControl.SelectionColor = Color.FromArgb(basePage.ScenePage.TransparencyValue, settingsConfig.SelectObjectColor);
            basePage.SelectionGroupColor = Color.FromArgb(basePage.ScenePage.TransparencyValue, settingsConfig.SelectGroupColor);
            basePage.ScenePage.NodeColor = settingsConfig.NodeColor;
            basePage.ScenePage.E2DColor = settingsConfig.Elem2DColor;
            basePage.ScenePage.E3DColor = settingsConfig.Elem3DColor;

            basePage.ScenePage.SceneControl.Projection = settingsConfig.Projection
                ? ViewProjection.Parallel : ViewProjection.Perspective;
            basePage.ScenePage.SceneControl.UpdateProjection();

            var objs = project.ModelData.ObjectData.GetAllObjects();

            foreach (var obj in objs)
            {
                var preColor = obj.SlaveColor;
                var newColor = Color.FromArgb(basePage.ScenePage.TransparencyValue, preColor);
                obj.MasterColor = newColor;
                obj.SlaveColor = newColor;
            }
        }

        private void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            var module = ModulePage;
            if(module != null)
            {
                module.BasePage.PressedKey = e.KeyCode;             
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

        private void StartLisenceForm(ToolStripPage module)
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

                    if (serverConnection.Answer == "можно")
                    {
                        control.LabelAnswer = "Лицензирование проведено";
                        UnBlockGeneralMenuInterface(module.Name, true);
                        StartLicensing(module);
                    }
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
                    ShowIcon = false,
                    CausesValidation = true,
                    Owner = Application.OpenForms[0]
                };

                form.ClientSize = settings.Size;
                form.Controls.Add(settings);
                form.Show();
            }

            if (ModulePage != null)
            {
                SetSettingsToModule(settings);
            }
        }

        private void SetSettingsToModule(SettingsControl settings)
        {
            var module = ModulePage;
            var scenePage = module.BasePage.ScenePage;
            settings.SetSelectionGroupColorEvent += (ar) => module.BasePage.SelectionGroupColor = ar;
            settings.SetSelectionObjectColorEvent += (ar) =>
            scenePage.SceneControl.SelectionColor = ar;

            settings.SetNodeColorEvent += (ar) => { 
                scenePage.NodeColor = ar;
                scenePage.SetObjectsSceneColor(ObjType.Узел);
                scenePage.SceneControl.DisplayObjects();
            };
            settings.Set2DElemColorEvent += (ar) => { 
                scenePage.E2DColor = ar;
                scenePage.SetObjectsSceneColor(ObjType.Элемент2D);
                scenePage.SceneControl.DisplayObjects();
            };
            settings.Set3DElemColorEvent += (ar) => { 
                scenePage.E3DColor = ar;
                scenePage.SetObjectsSceneColor(ObjType.Элемент3D);
                scenePage.SceneControl.DisplayObjects();
            };

            settings.SetSolverPathEvent += (ar) =>
            {
                if (module is TaskPage taskPage)
                    taskPage.SolverPath = ar;
            };
            settings.SetBackGroundColorEvent += (ar) =>
            {
                scenePage.SceneControl.BackGroundColor = ar;
                scenePage.SceneControl.DisplayObjects();
            };


            settings.SetLightingEvent += (ar) =>
            {
                scenePage.SceneControl.IsLighting = ar;
                scenePage.SceneControl.DisplayObjects();
            };

            settings.SetTransparencyEvent += (ar) =>
            {
                scenePage.SceneControl.IsBlending = ar;
                scenePage.ClearAllDataOnScene();
                scenePage.PresentAllModelObjectsToScene();
                scenePage.SceneControl.DisplayObjects();
            };

            settings.SetOrtoProjectionEvent += (ar) =>
            {
                scenePage.SceneControl.Projection = ar ? ViewProjection.Parallel : ViewProjection.Perspective;
                scenePage.SceneControl.UpdateProjection();
                scenePage.SceneControl.DisplayObjects();
            };

            settings.SetTransparencyValueEvent += (ar1) =>
            {
                scenePage.TransparencyValue = (int)(ar1 / 100.0f * 255);

                scenePage.SceneControl.SelectionColor = Color.FromArgb(settingsConfig.TransparencyValue, settingsConfig.SelectObjectColor);
                module.BasePage.SelectionGroupColor = Color.FromArgb(settingsConfig.TransparencyValue, settingsConfig.SelectGroupColor);

                var objs = project.ModelData.ObjectData.GetAllObjects();

                foreach (var obj in objs)
                {
                    var preColor = obj.SlaveColor;
                    var newColor = Color.FromArgb(settingsConfig.TransparencyValue, preColor);
                    obj.MasterColor = newColor;
                    obj.SlaveColor = newColor;
                } 
                
                scenePage.ClearAllDataOnScene();
                scenePage.PresentAllModelObjectsToScene();
                scenePage.SceneControl.DisplayObjects();
            };

            settings.SetLightingIntensityEvent += (ar) =>
            {
                scenePage.SceneControl.LightAttenuation = 1 - ar / 100.0f;
                scenePage.SceneControl.DisplayObjects();
            };


            settings.SetLighterPositionEvent += (ar) =>
            {
                var kx = (float)(scenePage.Width / settings.Width);
                var ky = (float)(scenePage.Height / settings.Height);

                var x = ar.X * kx;
                var y = ar.Y * ky;

                scenePage.SceneControl.LightTranslateX = x;
                scenePage.SceneControl.LightTranslateY = y;

                scenePage.SceneControl.DisplayObjects();
            };
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            var verStr = "Версия " + $"{ver.Major}.{ver.Minor}.{ver.Build}";
            lblVersion.Text = verStr;

            var config = dataController.LoadConfig();

            if(config != null)
                this.settingsConfig = config;
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
            var module = ModulePage;

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
                modelController = new ModelController.ModelController(project.ModelData);
                SetModule("Mesh");
                модулиMenuItem.Image = Resources.м_34;
                var module = ModulePage.BasePage;
                module.ScenePage.SceneControl.FitObjectsToScreen();
                module.ScenePage.SceneControl.DisplayObjects();
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
                project =  await dataController.OpenProject();

                if(project != null)
                {
                    lblStatus.Text = $"{project.GeneralData.Path}\\{project.GeneralData.Name}";

                    var ierr = 0;
                    gmshController?.Clear(ref ierr);

                    модулиMenuItem.Enabled = true;
                    modelController = new ModelController.ModelController(project.ModelData);
                    SetModule("Mesh");
                    модулиMenuItem.Image = Resources.м_34;
                    var module = ModulePage.BasePage;
                    module.ScenePage.SceneControl.FitObjectsToScreen();
                    module.ScenePage.SceneControl.DisplayObjects();
                }

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
                var res = await dataController.ImportMesh();

                if (res == null)
                    return;

                project = res;

                lblStatus.Text = $"{project.GeneralData.Path}\\{project.GeneralData.Name}";

                var ierr = 0;
                gmshController?.Clear(ref ierr);

                модулиMenuItem.Enabled = true;
                modelController = new ModelController.ModelController(project.ModelData);
                SetModule("Mesh");
                модулиMenuItem.Image = Resources.м_34;
                var module = ModulePage.BasePage;
                module.ScenePage.SceneControl.FitObjectsToScreen();
                module.ScenePage.SceneControl.DisplayObjects();
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

            dataController.SaveAsProject(project);

            var module = ModulePage.BasePage;
            module?.ConsoleControl.PrintInfo("Проект сохранен", Color.Black);
            lblStatus.Text = $"{project.GeneralData.Path}\\{project.GeneralData.Name}";

            module?.PresentProjectOnTree();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            project?.Save();
            var module = ModulePage.BasePage;
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
                    modelController = new ModelController.ModelController(project.ModelData);
                    SetModule("Mesh");
                    модулиMenuItem.Image = Resources.м_34;
                    var module = ModulePage.BasePage;
                    module.ScenePage.SceneControl.FitObjectsToScreen();
                    module.ScenePage.SceneControl.DisplayObjects();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PresentProjectOnModule(ToolStripPage module)
        {
            module.BasePage.ScenePage.PresentAllModelObjectsToScene();
            module.BasePage.PresentProjectOnTree();

            (module as TaskPage)?.PresentTaskDataOnTree(project.TaskData);

            ModulePage.PresentModelOnSelectToolStrip(project.ModelData.ObjectData);
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
            var module = ModulePage.BasePage;
            var splitContainer = (SplitContainer)module.NavigatorControl.Parent.Parent;
            splitContainer.Panel1Collapsed = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var module = ModulePage.BasePage;
            var splitContainer = (SplitContainer)module.ConsoleControl.Parent.Parent;
            splitContainer.Panel2Collapsed = false;
        }

        private void createSurfaceElementsMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ModelPage)ModulePage;
            module.CreateSurfaceElements(ObjType.Элемент2D);
        }

        private void mesh3DGeneratorMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ModelPage)ModulePage;

            if (mesh3DGeneratorMenuItem.Checked)
            {
                var res = MessageBox.Show("Вы собираетесь запустить сеточный генератор. При нажатии на кнопку \"OK\" " +
    "Все данные о задаче будут удалены!",
"Внимание!", MessageBoxButtons.OKCancel);

                if (res == DialogResult.OK)
                    project.TaskData.Clear();
                else
                {
                    mesh3DGeneratorMenuItem.Checked = false;
                    return;
                }

                module.EmbeddedSplitContainer.Panel2Collapsed = false;
                if(gmshController != null)
                    module.SetGMSHController(gmshController);
            }
            else 
                module.EmbeddedSplitContainer.Panel2Collapsed = true;         
        }

        private void arcWeldingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (WeldingPage)ModulePage;

            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if (currentItem.Name != item.Name)
                    item.Checked = false;

            module.ConfigAdvisor(WeldingKind.ARC);

            if (arcWeldingMenuItem.Checked)
                module.EmbeddedSplitContainer.Panel2Collapsed = false;
            else module.EmbeddedSplitContainer.Panel2Collapsed = true;
        }

        private void материалыMenuItem_Click(object sender, EventArgs e)
        {
            var module = (TaskPage)ModulePage;
            module.OpenMaterialsDB();
        }

        private void функцииMenuItem_Click(object sender, EventArgs e)
        {
            var module = (TaskPage)ModulePage;
            module.OpenFunctionsDB();
        }

        private void lazerWeldingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (WeldingPage)ModulePage;

            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if (currentItem.Name != item.Name)
                    item.Checked = false;

            module.ConfigAdvisor(WeldingKind.Lazer);

            if (lazerWeldingMenuItem.Checked)
                module.EmbeddedSplitContainer.Panel2Collapsed = false;
            else module.EmbeddedSplitContainer.Panel2Collapsed = true;
        }

        private void fsWeldingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (WeldingPage)ModulePage;

            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if (currentItem.Name != item.Name)
                    item.Checked = false;

            module.ConfigAdvisor(WeldingKind.FrictionStearing);

            if (fsWeldingMenuItem.Checked)
                module.EmbeddedSplitContainer.Panel2Collapsed = false;
            else module.EmbeddedSplitContainer.Panel2Collapsed = true;
        }

        private void addResultsMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;
            module.ShowOpenResultsFileDialog(true);
        }

        private void loadResultsMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;
            module.ShowOpenResultsFileDialog(false);
        }

        private void showValueMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;

            if (showValueMenuItem.Checked)
                module.IsResultsValueShowen = true;
            else
            {
                module.IsResultsValueShowen = false;
                module.BasePage.ScenePage.SceneControl.HideDisplayText3D();
                module.BasePage.ScenePage.SceneControl.DisplayObjects();
            }
        }

        private void createFieldMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;

            if (module.EmbeddedSplitContainer.Panel2Collapsed == true)
                module.ShowAnimation();
        }

        private void createPlotMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;
            module.CreateGraph();
        }

        private void scaleSettingsMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;
            module.ShowScalePage();
        }

        private void exportResultsMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;
            module.ShowExportResultsPage();
        }

        private void heatingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (HeatTreatmentPage)ModulePage;

            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if(currentItem.Name != item.Name)
                    item.Checked = false;

            module.ConfigAdvisor(ProcessType.Tempering);

            if (heatingMenuItem.Checked)
                module.EmbeddedSplitContainer.Panel2Collapsed = false;
            else module.EmbeddedSplitContainer.Panel2Collapsed = true;
        }

        private void temperingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (HeatTreatmentPage)ModulePage;

            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if (currentItem.Name != item.Name)
                    item.Checked = false;

            module.ConfigAdvisor(ProcessType.Tempering);

            if (temperingMenuItem.Checked)
                module.EmbeddedSplitContainer.Panel2Collapsed = false;
            else module.EmbeddedSplitContainer.Panel2Collapsed = true;
        }

        private void quenchingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (HeatTreatmentPage)ModulePage;

            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if (currentItem.Name != item.Name)
                    item.Checked = false;

            module.ConfigAdvisor(ProcessType.Quenching);

            if (quenchingMenuItem.Checked)
                module.EmbeddedSplitContainer.Panel2Collapsed = false;
            else module.EmbeddedSplitContainer.Panel2Collapsed = true;
        }

        private void создать1DПо2DЭлементамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ModelPage)ModulePage;
            module.CreateSurfaceElements(ObjType.Элемент1D);
        }
    }
}
