using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Diagnostics;
using System.IO;
using TaskModule.BasicTaskAdvisor;
using TaskModule.BasicAdvisorControls.Events;
using BaseModule;
using Functions.Parser;
using DataBaseController.MaterialData;
using DataBaseController.FunctionData;
using Newtonsoft.Json;
using BaseModule.Navigator;
using DataBasesGUI;
using Geometry;
using Tasks;
using ProjectInterfaces.Tasks;
using ModelInterfaces;
using System.Xml.XPath;
using TaskModule.BasicAdvisorControls.TaskPlannerControls;
using System.Text.RegularExpressions;

namespace TaskModule
{
    public partial class TaskPage: BasePage
    {
        string activeTask  = String.Empty;
        public string SolverPath { get; set; }

        //public MaterialDBData MatData { get; set; }
        //public FunctionDBData FunData { get; set; }

        private ToolStripStatusLabel solverStatusLabel;

        public TaskPage()
        {
            InitializeComponent();

            var list = new List<StatusStrip>();
            SearchControl(this, list);          

            solverStatusLabel = new ToolStripStatusLabel() { Name = "solverStatus"};
            list[0].Items.Insert(1,solverStatusLabel);

            var taskNode = new TreeNode("Данные", 1, 1) { Name = "Данные", Tag = "6" };
            NavigatorControl.TreeView.Nodes.Add(taskNode);

            ChangeProjectDataEvent += () => { GetTaskAdvisor()?.SetProjectData(Project); };
        }

        public override void CreateMenuInterface()
        {
            AddToolStripMenuItem(CreateDataBaseInterface());
            AddToolStripMenuItem(CreateTasksInterface());
            base.CreateMenuInterface();
        }

        public virtual ToolStripMenuItem CreateTasksInterface()
        {
            ToolStripMenuItem tasksMenuItem = new ToolStripMenuItem()
            {
                Name = "tasksMenuItem",
                Text = "Задачи"
            };    

            return tasksMenuItem;
        }

        private ToolStripMenuItem CreateDataBaseInterface()
        {
            ToolStripMenuItem dataBaseMenuItem = new ToolStripMenuItem()
            {
                Name = "dataBaseMenuItem",
                Text = "Базы данных"
            };

            ToolStripMenuItem matDataMenuItem = new ToolStripMenuItem()
            {
                Name = "matDataMenuItem",
                Text = "База материалов",
            };

            ToolStripMenuItem funDataMenuItem = new ToolStripMenuItem()
            {
                Name = "funDataMenuItem",
                Text = "База функций"
            };

            dataBaseMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            matDataMenuItem,
            funDataMenuItem
            });

            matDataMenuItem.Click += (ar1, ar2) =>
            {
                try
                {
                    var matBasePage = new MaterialsDataBasePage() { Dock = DockStyle.Fill };
                    matBasePage.LoadEvent += () =>
                    {
                        ChangeMaterialDBEventHandler(matBasePage);
                    };

                    matBasePage.SaveEvent += () =>
                    {
                        ChangeMaterialDBEventHandler(matBasePage);
                    };

                    var filePath = FindFileByPath(Project.Path, Project.Materials);
                    if (filePath == null)
                        ConsoleControl.PrintInfo($"База данных {Project.Materials} не найдена в директории {Project.Path}", Color.Red);
                    else
                        matBasePage.Load($@"{filePath}\{Project.Materials}", false);

                    var icon = TaskModule.Properties.Resources.Материалы;
                    var name = "База материалов";
                    var form = new Form() { Name = name, Text = name, TopMost = true, Size = matBasePage.Size, Icon = icon };
                    form.Controls.Add(matBasePage);
                    form.Show();

                }
                catch (Exception ex)
                {
                    ConsoleControl.PrintInfo(ex.Message, Color.Red);
                }
            };
            funDataMenuItem.Click += (ar1, ar2) =>
            {
                try
                {
                    var funBasePage = new FunctionDataBasePage() { Dock = DockStyle.Fill };
                    funBasePage.LoadEvent += () =>
                    {
                        ChangeFuncDBEventHandler(funBasePage);
                    };

                    funBasePage.SaveEvent += () =>
                    {
                        ChangeFuncDBEventHandler(funBasePage);
                    };

                    var filePath = FindFileByPath(Project.Path, Project.Functions);
                    if (filePath == null)
                        ConsoleControl.PrintInfo($"База данных {Project.Functions} не найдена в директории {Project.Path}", Color.Red);
                    else
                        funBasePage.Load($@"{filePath}\{Project.Functions}", false);

                    var icon = TaskModule.Properties.Resources.Функции;
                    var name = "База функций";
                    var form = new Form() { Name = name, Text = name, TopMost = true, Size = funBasePage.Size, Icon = icon };
                    form.Controls.Add(funBasePage);
                    form.Show();
                }
                catch (Exception ex)
                {
                    ConsoleControl.PrintInfo(ex.Message, Color.Red);
                }
            };

            return dataBaseMenuItem;
        }

        private void ChangeFuncDBEventHandler(FunctionDataBasePage funBasePage)
        {
            if (funBasePage.DbPath != Project.Path)
                CopyFile(funBasePage.DbName, funBasePage.DbPath, Project.Path);

            Project.Functions = funBasePage.DbName;
            var funData = funBasePage.Functions;
            GetTaskAdvisor()?.SetFunctionData(funData.Keys.ToList());
            PresentProjectOnTree();
        }

        private void ChangeMaterialDBEventHandler(MaterialsDataBasePage matBasePage)
        {
            if (matBasePage.DbPath != Project.Path)
                CopyFile(matBasePage.DbName, matBasePage.DbPath, Project.Path);

            Project.Materials = matBasePage.DbName;
            var matData = matBasePage.Materials;
            GetTaskAdvisor()?.SetMaterialData(matData.Keys.ToList());
            PresentProjectOnTree();
        }

        public void DeleteAdvisor()
        {
            Application.OpenForms[activeTask]?.Close();
            activeTask = "";
        }

        public virtual void UnCheckToolStripButtons()
        {
            throw new Exception("Метод не реализован");
        }

        public void CreateAdvisor(TaskAdvisor taskAdv, Icon icon)
        {
            try
            {
                var appFolder = Path.GetDirectoryName(Application.ExecutablePath);
                if (appFolder == Project.Path)
                {
                    MessageBox.Show("Рабочая папка проекта должна отличаться от папки установки программы!");
                    return;
                }

                activeTask = taskAdv.Name;
                var form = new Form() { Text = activeTask, Name = activeTask, TopMost = true, Size = taskAdv.Size, Icon = icon };
                form.FormClosed += (ar1, ar2) =>
                {
                    if (ar2.CloseReason == CloseReason.UserClosing)
                    {

                        UnCheckToolStripButtons();

                        foreach (var item in GetToolStripMenuItems())
                            foreach (var dropItem in item.DropDownItems)
                                if (dropItem is ToolStripMenuItem tls)
                                    tls.Checked = false;
                    }
                    activeTask = "";
                };
                form.Controls.Add(taskAdv);
                form.Show();

                taskAdv.GenerateTCFEvent += TaskAdv_GenerateTCFEvent;
                taskAdv.AddDataUseTaskConditionsEvent += TaskAdv_AddDataUseTaskConditionsEvent;
                taskAdv.AddDataEvent += TaskAdvisor_AddDataEvent;
                taskAdv.DeleteDataEvent += TaskAdvisor_DeleteDataEvent;
                taskAdv.DeleteAllDataEvent += TaskAdvisor_DeleteAllDataEvent;
                taskAdv.CheckDataEvent += TaskAdvisor_CheckDataEvent;
                taskAdv.HideDataEvent += TaskAdvisor_HideDataEvent;
                taskAdv.ShowDataEvent += TaskAdvisor_ShowDataEvent;
                taskAdv.ChangeDataEvent += TaskAdvisor_ChangeDataEvent;
                taskAdv.StartComputationEvent += TaskAdvisor_StartComputationEvent;
                taskAdv.StopComputationEvent += TaskAdv_StopComputationEvent;
                taskAdv.Select2DAxiEvent += TaskAdvisor_ChangeTaskTypeEvent;
                taskAdv.Select2DPlaneEvent += TaskAdvisor_ChangeTaskTypeEvent;
                taskAdv.Select3DEvent += TaskAdvisor_ChangeTaskTypeEvent;

                var matDB = GetDataBase<MaterialDBData>(Project.Materials, Project.Path);

                if (matDB == null)
                    ConsoleControl.PrintInfo($"Не загружена база {Project.Materials}", Color.Red);
                else

                    taskAdv.SetMaterialData(matDB.Keys.ToList());

                var funDB = GetDataBase<FunctionDBData>(Project.Functions, Project.Path);

                if (funDB == null)
                    ConsoleControl.PrintInfo($"Не загружена база {Project.Functions}", Color.Red);
                else
                    taskAdv.SetFunctionData(funDB.Keys.ToList());


                taskAdv.SetProjectData(Project);

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void TaskAdv_GenerateTCFEvent(object arg1, GenerateTCFEventArgs arg2)
        {
            var result = new List<string>();

            result.Add($@"\\загрузка сетки и данных");
            result.Add($@"загрузка");
            result.Add($@"{Project.Path}\{Project.Name}");
            result.Add($@"#загрузка");
            result.Add($@"\\загрузка материалов");
            result.Add($@"загрузка");
            result.Add($@"{Project.Path}\{Project.Materials}");
            result.Add($@"#загрузка");
            result.Add($@"\\загрузка функций");
            result.Add($@"загрузка");
            result.Add($@"{Project.Path}\{Project.Functions}");
            result.Add($@"#загрузка");
            result.Add($@"\\расчет задачи");
            result.AddRange(arg2);

            var compDir = $@"{Project.Path}\ComputationData";

            if (!Directory.Exists(compDir))
                Directory.CreateDirectory(compDir);

            var cmdFile = $@"{compDir}\computation.tcf";

            result.Add($@"загрузка");
            File.WriteAllLines(cmdFile, result);
            result.Add($@"#загрузка");

            ConsoleControl.PrintInfo($"Сформирован командный файл {cmdFile}", Color.Green);
        }

        private void TaskAdv_AddDataUseTaskConditionsEvent(object arg1, EventArgs arg2)
        {
            try
            {
                var data = Project.TaskData.Select(x => x as ValuableData).ToList();
                var processType = ParseProcessTypeFromString(activeTask);

                var inputDir = $@"{Project.Path}\InputData";

                if (!Directory.Exists(inputDir))
                    Directory.CreateDirectory(inputDir);

                PreProc.CalcCompDataV1(data, processType, inputDir);

                var tsfFiles = Directory.GetFiles(inputDir, "*.tsf");
                GetTaskAdvisor()?.SetTaskPlannerlData(inputDir,tsfFiles.ToList());

                ConsoleControl.PrintInfo($"Входные Данные задачи сгенерированы в {inputDir}", Color.Green);

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private ProcessType ParseProcessTypeFromString(string processType)
        {
            switch (processType)
            {
                case "Термический анализ":
                    return ProcessType.TermalProcess;
                case "Механический анализ":
                    return ProcessType.MechProcess;
                case "Сварка":
                    return ProcessType.Welding;
                case "Термообработка":
                    return ProcessType.HeatTreatment;
                default:
                    throw new ArgumentException($"Переданную строку нельзя идентифицировать как тип процесса");
            }

        }

        private T GetDataBase<T>(string dbName, string dbPath)
        {
            var filePath = FindFileByPath(dbPath, dbName);
            if (filePath == null)
            {
                ConsoleControl.PrintInfo($"Не найдена база {dbName} в папке {dbPath}", Color.Red);
                return default;
            }
 
            else 
                return LoadDataBase<T>(dbName, dbPath);
        }

        private void TaskAdv_StopComputationEvent(object arg1, EventArgs arg2)
        {
            var runProc = Process.GetProcessesByName("BazisSolver");

            if (runProc.Length != 0)
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    //Arguments = $"/C sc stop BazisSolver",
                    Arguments = $"/C taskkill /pid {runProc[0].Id} /f",
                    Verb = "runas"
                };
                process.StartInfo = startInfo;
                process.Start();
            }
        }

        private string FindFileByPath(string path, string fileName)
        {
            var projFiles = Directory.GetFiles(path, fileName, SearchOption.AllDirectories);
            if (projFiles.Count() > 0)
            {
                return Path.GetDirectoryName(projFiles[0]);
            }
            
            return null;
        }      

        private T LoadDataBase<T>(string dbFileName, string dbPath)
        {
            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
            };

            return JsonConvert.DeserializeObject<T>
(File.ReadAllText($@"{dbPath}\{dbFileName}"), settingsSerializer);
        }

        public override void SaveProjectData()
        {
            base.SaveProjectData();
        }

        public void TaskAdvisor_StartComputationEvent(object arg1, EventArgs arg2)
        {
            try
            {
                var answer = MessageBox.Show("Смена папки проекта", "Перед началом расчета рекомендуется сменить папку проекта", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                {
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.DefaultExt = "bpf";

                        if (saveDialog.ShowDialog() == DialogResult.Cancel)
                            return;

                        SaveAsProjectData(saveDialog.FileName);
                        PresentProjectOnTree();
                    }
                }
                else SaveProjectData();

                var myProcess = new Process();

                myProcess.StartInfo.FileName = $@"{SolverPath}\BazisSolver.exe";

                var projPath = $@"{Project.Path}\{Project.Name}";
                var matPath = $@"{Project.Path}\{Project.Materials}";
                var funPath = $@"{Project.Path}\{Project.Functions}";
                var argStr = string.Join(" ", new string[] { projPath, matPath, funPath });

                myProcess.StartInfo.Arguments = argStr;
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                myProcess.Start();

                Action<object, EventArgs> action = (s1, s2) => { solverStatusLabel.Text = ""; };

                solverStatusLabel.Text = "Идет расчет";
                WaitProcessAsync(myProcess, action);
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public override void PresentProjectOnTree()
        {
            base.PresentProjectOnTree();

            NavigatorControl.TreeView.BeginUpdate();

            NavigatorControl.TreeView.Nodes["Данные"].Nodes.Clear();

            NavigatorControl.TreeView.Nodes.RemoveByKey("База материалов");
            var matNode = new TreeNode($"База материалов : {Project.Materials}") { Name = "База материалов" };
            NavigatorControl.TreeView.Nodes.Insert(4, matNode);

            NavigatorControl.TreeView.Nodes.RemoveByKey("База функций");
            var funNode = new TreeNode($"База функций : {Project.Functions}") { Name = "База функций" };
            NavigatorControl.TreeView.Nodes.Insert(4, funNode);

            foreach (var data in Project.TaskData)
                {
                    NavigatorControl.CreateChildNode("Данные", data.Name, data.ToString(), "6.1");
                }

            NavigatorControl.TreeView.EndUpdate();
            NavigatorControl.TreeView.Nodes["Данные"].Expand();

            //GetTaskAdvisor()?.SetProjectData(Project);
        }

        public void TaskAdvisor_ChangeTaskTypeEvent(object arg1, ChangeTaskTypeEventArgs arg2)
        {
            if (arg2.Index == 0)
                Project.TaskType = TaskType.Plain;
            else if (arg2.Index == 1)
                Project.TaskType = TaskType.AxiPlain;
            else Project.TaskType = TaskType.Volume;

            NavigatorControl.TreeView.Nodes[3].Text = "Вид : " + Project.TaskType;

            GetTaskAdvisor()?.SetProjectData(Project);
        }

        public TaskAdvisor GetTaskAdvisor()
        {
            var taskForm = Application.OpenForms[activeTask];
            if (taskForm != null)
            {
                var taskAdvisor = (TaskAdvisor)taskForm.Controls[0];
                //var advPresenter = new AdvisorPresenter(Project);
                return taskAdvisor;
            }
            else return null;
        }

        public async void TaskAdvisor_ChangeDataEvent(object arg1, ChangeDataEventArgs arg2)
        {
            try
            {
                var dataArray = Project.TaskData.Find(arg2.DataName).ToArray();

                var taskStrAr = FieldsParserTask.ParseLine(arg2.DataInfo);

                if (dataArray[arg2.Index] is IValuableData valuableData)
                {

                    var taskStrLRF = SetTaskDataAsync("setDirection", taskStrAr[0]);

                    await taskStrLRF;
                    var taskStrStopTime = SetTaskDataAsync("setStopTime", taskStrLRF.Result);

                    valuableData.SetInfo(taskStrStopTime.Result);
                }
                else dataArray[arg2.Index].SetInfo(taskStrAr[0]);

                GetTaskAdvisor()?.SetProjectData(Project);

                var dataIndex = Project.TaskData.IndexOf(dataArray[arg2.Index]);
                NavigatorControl.TreeView.Nodes["Данные"].Nodes[dataIndex].Text = dataArray[arg2.Index].ToString();
                //PresentProjectOnTree();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo($"{ex.Message}:{ex.InnerException}", Color.Red);
            }

        }

        public void TaskAdvisor_DeleteAllDataEvent(object arg1, DeleteAllDataEventArgs arg2)
        {
            var dataArray = Project.TaskData.Find(arg2.DataName).ToArray();

            foreach (var data in dataArray)
            {
                var index = Project.TaskData.IndexOf(data);
                NavigatorControl.TreeView.Nodes["Данные"].Nodes.RemoveAt(index);

                Project.TaskData.Remove(data);
            }

            GetTaskAdvisor()?.SetProjectData(Project);
        }

        public void TaskAdvisor_ShowDataEvent(object arg1, ShowDataEventArgs arg2)
        {
            SceneControl.HideAllGeometryObjs();
            var data = Project.TaskData.Find(arg2.DataName).
                Select(x => (IValuableData)x).ToArray();

            foreach (var index in arg2.GetDataInfo())
            {
                var group = data[index].Group;

                if (data[index].MovedFrameFunction != null)
                    DisplayMRF(data[index].StartTime, data[index]);

                foreach (var iobj in group)
                {                   
                    if (data[index].Kind == DataKind.Mat)
                        iobj.MasterColor = Color.FromArgb(255, 255, 0);
                    else if (data[index].Kind == DataKind.Med)
                        iobj.MasterColor = Color.FromArgb(255, 155, 0);
                    else if (data[index].Kind == DataKind.Clamp | data[index].Kind == DataKind.Load)
                        iobj.MasterColor = Color.FromArgb(255, 0, 0);
                    else if (data[index].Kind == DataKind.Heat)
                        iobj.MasterColor = Color.FromArgb(125,155, 255, 0);

                    if (data[index].Direction != "*")
                        DisplayDirection(data[index].StartTime, data[index], iobj);
                }

                SetNewSceneColor(group.ObjType.ToString());

                //SetVBObjColor(group.ObjType);

            }
            SceneControl.DisplayObjects();
        }

        private void DisplayMRF(float time, IValuableData data)
        {
            float[] geomParam;

            var baseLineGr = Project.ModelData.GroupData.Find(data.MovedFrameFunction.BaseLine.Name);
            var basePoints = baseLineGr.Select(x => x.CalcCentr());
            data.MovedFrameFunction.BaseLine.SetPoints(basePoints);

            var refLineGr = Project.ModelData.GroupData.Find(data.MovedFrameFunction.RefLine.Name);
            var refPoints = refLineGr.Select(x => x.CalcCentr());
            data.MovedFrameFunction.RefLine.SetPoints(refPoints);

            var frame = data.MovedFrameFunction.CalcFrame(time);
            SceneControl.CreateLocalFrame(frame);
            SceneControl.CreatePath(basePoints.ToArray());

            if (data.MovedFrameFunction.FunctionType == "Sphere")
            {
                geomParam = data.MovedFrameFunction.GetGeometryParameters();
                SceneControl.CreateSphere(geomParam[0], frame);
            }
            else if (data.MovedFrameFunction.FunctionType == "Cillindrical")
            {
                geomParam = data.MovedFrameFunction.GetGeometryParameters();
                SceneControl.CreateConus(geomParam[0], geomParam[1], geomParam[2], frame);
            }
        }

        private void DisplayDirection(float time, IValuableData data, IModelObject modelObj)
        {
            var vector = new Point3D();
            Color color;

            if (data.Direction == "X")
            {
                vector = new Point3D(1, 0, 0);
                color = Color.FromArgb(255, 0, 0);
            }

            else if (data.Direction == "Y")
            {
                vector = new Point3D(0, 1, 0);
                color = Color.FromArgb(0, 255, 0);
            }

            else if (data.Direction == "Z")
            {
                vector = new Point3D(0, 0, 1);
                color = Color.FromArgb(0, 0, 255);
            }

            else
            {
                var directionAr = data.Direction.Split('|');

                var x = float.Parse(directionAr[0], NumberStyles.Float, CultureInfo.InvariantCulture);
                var y = float.Parse(directionAr[1], NumberStyles.Float, CultureInfo.InvariantCulture);
                var z = float.Parse(directionAr[2], NumberStyles.Float, CultureInfo.InvariantCulture);

                vector = new Point3D(x, y, z);
                color = Color.FromArgb(255, 155, 0);
            }

            foreach (var point in modelObj.GetCoordinates())
            {
                var scl = 10 * (1.0f / Height * 1.0f / SceneControl.ScaleFactor);
                vector = vector.Mult(scl);
                var p1 = point.Sum(vector);
                SceneControl.CreateLine(point, p1, color);
                //SceneControl.DisplayText3D(data.CalcValue(time, point).ToString(), Color.FromArgb(0, 0, 0), point);
            }
        }

        public void TaskAdvisor_HideDataEvent(object arg1, HideDataEventArgs arg2)
        {
            SceneControl.HideAllGeometryObjs();
            SceneControl.HideDisplayText3D();
            SetBackColorToAllObjects();
            SceneControl.DisplayObjects();
        }

        public void TaskAdvisor_CheckDataEvent(object arg1, CheckDataEventArgs arg2)
        {
            SceneControl.HideAllGeometryObjs();
            var selectedData = Project.TaskData.Find(arg2.DataName).Select(x => (IValuableData)x);
            foreach (var data in selectedData)
            {
                if (arg2.Time >= data.StartTime & arg2.Time <= data.StopTime)
                {
                    if (data.MovedFrameFunction != null)
                        DisplayMRF(arg2.Time, data);

                    var group = data.Group;

                    foreach (var iobj in group)
                    {
                        if (data.Kind == DataKind.Mat)
                            iobj.MasterColor = Color.FromArgb(255, 255, 0);
                        else if (data.Kind == DataKind.Med)
                            iobj.MasterColor = Color.FromArgb(255, 155, 0);
                        else if (data.Kind == DataKind.Clamp | data.Kind == DataKind.Load)
                            iobj.MasterColor = Color.FromArgb(255, 0, 0);
                        else if (data.Kind == DataKind.Heat)
                            iobj.MasterColor = Color.FromArgb(125,155, 255, 0);

                        //PresentProjectTaskDataOnScene(arg2.Time, data, modelObj);
                        if (data.Direction != "*")
                            DisplayDirection(arg2.Time, data, iobj);
                    }

                    SetNewSceneColor(group.ObjType.ToString());

                    SceneControl.DisplayObjects();
                }
            }

        }

        public void TaskAdvisor_DeleteDataEvent(object arg1, DeleteDataEventArgs arg2)
        {
            var dataArray = Project.TaskData.Find(arg2.DataName).ToArray();

            var index = Project.TaskData.IndexOf(dataArray[arg2.Index]);
            NavigatorControl.TreeView.Nodes["Данные"].Nodes.RemoveAt(index);

            Project.TaskData.Remove(dataArray[arg2.Index]);

            

            //PresentProjectOnTree();
        }

        public async void TaskAdvisor_AddDataEvent(object arg1, AddDataEventArgs arg2)
        {
            try
            {
                var taskStrAr = FieldsParserTask.ParseLine(arg2.DataInfo);

                foreach (var taskStr in taskStrAr)
                {
                    var setTaskStr = SetTaskDataAsync("setDirection", taskStr);

                    await setTaskStr;
                    setTaskStr = SetTaskDataAsync("setStopTime", setTaskStr.Result);

                    if (arg2.DataName == "Материал")
                        Project.TaskData.Add(new MatData(setTaskStr.Result));
                    else if (arg2.DataName == "Среда")
                        Project.TaskData.Add(new MediaData(setTaskStr.Result));
                    else if (arg2.DataName == "Нагрузка")
                        Project.TaskData.Add(new LoadData(setTaskStr.Result));
                    else if (arg2.DataName == "Нагрев")
                        Project.TaskData.Add(new HeatData(setTaskStr.Result));
                    else
                        Project.TaskData.Add(new ClampData(setTaskStr.Result));

                    NavigatorControl.CreateChildNode("Данные", arg2.DataName, $"{arg2.DataName} : {taskStr}", "6.1");
                }

                GetTaskAdvisor()?.SetProjectData(Project);
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private async Task<string> SetTaskDataAsync(string cmd, string taskStr)
        {
            var taskParamsCalculator = new TaskDataCalculator(Project);
            taskParamsCalculator.CalculatorEvent += (ar1, ar2) =>
            {
                Invoke(new Action(() => { PrintCommand(ar2.Message); }));
            };

            if (cmd == "setDirection" & taskStr.Contains("LRF"))
            {
                PrintCommand("задайте вектор, выбрав 3 точки, и нажмите на кнопку Enter или нажмите кнопку ESC");
                var confirm = false;
                var breaker = false;

                SelectedObjects = ObjType.Узел;

                var func = taskParamsCalculator.SetDirection(taskStr);

                this.KeyDown += delegate (object sender, KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.Escape)
                        breaker = true;
                    if (e.KeyCode == Keys.Enter)
                        confirm = true;
                };
                await System.Threading.Tasks.Task.Run(() =>
                {
                    while (true)
                    {
                        if (confirm)
                        {
                            var res = func.Invoke();
                            if (res.Contains("LRF"))

                            {
                                confirm = false;
                            }
                            else
                            {
                                Invoke(new Action(() => {
                                    ConsoleControl.PrintInfo("Операция завершена успешно", Color.Green);
                                    PrintCommand("");
                                }));
                                Thread.Sleep(100);
                                taskStr = res;
                                break;
                            }
                        }
                        if (breaker)
                            break;
                    }
                });
            }
            else if (cmd == "setStopTime")
                taskStr = taskParamsCalculator.SetStopTime(taskStr);


            return taskStr;
        }

        private void TaskPage_Load(object sender, EventArgs e)
        {
            if(Project.TaskData == null)
                Project.TaskData = new TaskData();
        }

        //public override bool LoadProjectData(string extFilter)
        //{
        //    var resu = base.LoadProjectData(extFilter);

        //    if (resu)
        //    {
        //        Project.TaskData.Load($@"{Project.Path}\{Project.Name}");
        //        return true;
        //    }
        //    else return false;
        //}
    }
}
