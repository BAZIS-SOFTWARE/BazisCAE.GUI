using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using TaskModule.BasicTaskAdvisor;
using TaskModule.BasicAdvisorControls.Events;
using BaseModule;
using DataBaseController.MaterialData;
using DataBaseController.FunctionData;
using Newtonsoft.Json;
using DataBasesGUI;
using Geometry;
using ProjectInterfaces.Tasks;
using ModelInterfaces;
using TaskModule.BasicAdvisorControls.TaskPlannerControls;
using BaseModule.Utilities;
using ModelControllerInterfaces;
using ProjectInterfaces;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace TaskModule
{
    public partial class TaskPage: ToolStripPage
    {
        string activeAdvisor  = String.Empty;
        public string SolverPath { get; set; }

        IGeneralData GeneralData { get { return basePage.GetGeneralData(); } }

        IPreProc preProc;

        private protected ITaskData taskData;

        public void SetPreProc(IPreProc preProc)
        {
            this.preProc = preProc;
        }

        public void SetTaskData(ITaskData taskData)
        {
            this.taskData = taskData;
        }

        IModelController ModelController
        {
            get { return BasePage.ScenePage.GetModelController(); }
        }

        IModelData ModelData
        {
            get { return ModelController.ModelData; }
        }

        public event Action<object> NeedSaveProjectEvent;

        public TaskPage()
        {
            InitializeComponent();

            var taskNode = new TreeNode("Данные", 14, 14) { Name = "Данные", Tag = "6" };
            taskNode.ContextMenuStrip = taskMenuStrip;
            BasePage.NavigatorControl.TreeView.Nodes.Add(taskNode);
        }

        public void OpenFunctionsDB()
        {
            try
            {
                var funBasePage = new FunctionDataBasePage() { Dock = DockStyle.Fill, HeadColor = Color.Gainsboro };
                funBasePage.LoadEvent += () =>
                {
                    ChangeFuncDBEventHandler(funBasePage);
                };

                funBasePage.SaveEvent += () =>
                {
                    ChangeFuncDBEventHandler(funBasePage);
                };

                var filePath = FindFileByPath(GeneralData.Path, GeneralData.Functions);
                if (filePath == null)
                    BasePage.ConsoleControl.PrintInfo($"База данных {GeneralData.Functions} не найдена в директории {GeneralData.Path}", Color.Red);
                else
                    funBasePage.Load($@"{filePath}\{GeneralData.Functions}", false);

                var name = "База функций";
                var form = new Form() { Name = name, Text = name, TopMost = true, Owner = Application.OpenForms[0], Size = funBasePage.Size, ShowIcon = false };
                form.Controls.Add(funBasePage);
                form.ClientSize = funBasePage.Size;
                form.Show();
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void OpenMaterialsDB()
        {
            try
            {
                var matBasePage = new MaterialsDataBasePage() { Dock = DockStyle.Fill, HeadColor = Color.Gainsboro };

                matBasePage.LoadEvent += () =>
                {
                    ChangeMaterialDBEventHandler(matBasePage);
                };

                matBasePage.SaveEvent += () =>
                {
                    ChangeMaterialDBEventHandler(matBasePage);
                };

                var filePath = FindFileByPath(GeneralData.Path, GeneralData.Materials);
                if (filePath == null)
                    BasePage.ConsoleControl.PrintInfo($"База данных {GeneralData.Materials} не найдена в директории {GeneralData.Path}", Color.Red);
                else
                    matBasePage.Load($@"{filePath}\{GeneralData.Materials}", false);

                var name = "База материалов";
                var form = new Form() { Name = name, Text = name, TopMost = true, Owner = Application.OpenForms[0], Size = matBasePage.Size, ShowIcon = false };
                form.Controls.Add(matBasePage);
                form.ClientSize = matBasePage.Size;
                form.Show();

            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void ChangeFuncDBEventHandler(FunctionDataBasePage funBasePage)
        {
            if (funBasePage.DbPath != GeneralData.Path)
                IOFileController.CopyFile(funBasePage.DbName, funBasePage.DbPath, GeneralData.Path);

            GeneralData.Functions = funBasePage.DbName;
            var funData = funBasePage.Functions;
            GetTaskAdvisor()?.SetFunctionData(funData.Keys.ToList());
            PresentMatAndFuncDataOnTree();
        }

        public void ChangeMaterialDBEventHandler(MaterialsDataBasePage matBasePage)
        {
            if (matBasePage.DbPath != GeneralData.Path)
                IOFileController.CopyFile(matBasePage.DbName, matBasePage.DbPath, GeneralData.Path);

            GeneralData.Materials = matBasePage.DbName;
            var matData = matBasePage.Materials;
            GetTaskAdvisor()?.SetMaterialData(matData.Keys.ToList());
            PresentMatAndFuncDataOnTree();
        }

        public void DeleteAdvisor()
        {
            Application.OpenForms[activeAdvisor]?.Close();
            activeAdvisor = "";
        }

        public void ShowAdvisor(object sender, TaskAdvisor taskAdv)
        {
            try
            {
                var generalData = GeneralData;
                var btn = sender as ToolStripMenuItem;
                var appFolder = Path.GetDirectoryName(Application.ExecutablePath);
                if (appFolder == generalData.Path)
                {
                    MessageBox.Show("Рабочая папка проекта должна отличаться от папки установки программы!");
                    return;
                }

                activeAdvisor = taskAdv.Name;

                var form = new Form() 
                { Text = taskAdv.Text, 
                    Name = taskAdv.Name, 
                    TopMost = true, Owner = Application.OpenForms[0],
                    Size = taskAdv.Size, 
                    ShowIcon = false
                };

                form.FormClosed += (ar1, ar2) =>
                {
                    if (ar2.CloseReason == CloseReason.UserClosing)
                        btn.Checked = false;
                    activeAdvisor = "";
                };
                form.Controls.Add(taskAdv);
                
                form.Show();
                form.ClientSize = new Size(taskAdv.Width, this.BasePage.ScenePage.Height);
                var location = BasePage.ScenePage.PointToScreen(Point.Empty);
                form.Location = location;

                taskAdv.GenerateTCFEvent += TaskAdv_GenerateTCFEvent;
                taskAdv.AddDataUseTaskConditionsEvent += (ar1,ar2) => { TaskAdv_AddDataUseTaskConditions(taskData, preProc); };
                taskAdv.AddDataEvent += (ar1, ar2) => { TaskAdvisor_AddData(taskData, ar2); };
                taskAdv.DeleteDataEvent += (ar1, ar2) => { TaskAdvisor_DeleteData(taskData, ar2); };
                taskAdv.DeleteAllDataEvent += (ar1, ar2) => { TaskAdvisor_DeleteAllData(taskData, ar2); };
                taskAdv.CheckDataEvent += (ar1, ar2) => { TaskAdvisor_CheckData(taskData, ar2); };
                taskAdv.HideDataEvent += TaskAdvisor_HideDataEvent;
                taskAdv.ShowDataEvent += (ar1, ar2) => { TaskAdvisor_ShowData(taskData, ar2); };
                taskAdv.ChangeDataEvent += (ar1,ar2) => { TaskAdvisor_ChangeData(taskData,ar2); };
                taskAdv.StartComputationEvent += TaskAdvisor_StartComputationEvent;
                taskAdv.StopComputationEvent += TaskAdv_StopComputationEvent;
                taskAdv.Select2DAxiEvent += (ar1,ar2) => { TaskAdvisor_ChangeTaskType(taskData,ar2); };
                taskAdv.Select2DPlaneEvent += (ar1, ar2) => { TaskAdvisor_ChangeTaskType(taskData, ar2); };
                taskAdv.Select3DEvent += (ar1, ar2) => { TaskAdvisor_ChangeTaskType(taskData, ar2); };

                var matDB = GetDataBase<MaterialDBData>(generalData.Materials, generalData.Path);

                if (matDB == null)
                    BasePage.ConsoleControl.PrintInfo($"Не загружена база {generalData.Materials}", Color.Orange);
                else

                    taskAdv.SetMaterialData(matDB.Keys.ToList());

                var funDB = GetDataBase<FunctionDBData>(generalData.Functions, generalData.Path);

                if (funDB == null)
                    BasePage.ConsoleControl.PrintInfo($"Не загружена база {generalData.Functions}", Color.Orange);
                else
                    taskAdv.SetFunctionData(funDB.Keys.ToList());


                taskAdv.SetProjectData(generalData, ModelData, taskData);

                var inputDir = $@"{generalData.Path}\InputData";

                if (Directory.Exists(inputDir))
                {
                    var tsfFiles = Directory.GetFiles(inputDir, "*.tsf");

                    var sortedFiles = preProc.SortCompDataByTimeAndType(tsfFiles);
                    taskAdv.SetTaskPlannerlData(sortedFiles);
                }
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void TaskAdv_GenerateTCFEvent(object arg1, GenerateTCFEventArgs arg2)
        {
            CheckProjectDataBeforeCreationTCF();

            var generalData = GeneralData;
            var result = new List<string>
            {
                $@"\\загрузка сетки и данных",
                $@"загрузить проект {generalData.Path}\{generalData.Name}",
                $@"\\загрузка материалов",
                $@"загрузить материалы {generalData.Path}\{generalData.Materials}",
                $@"\\загрузка функций",
                $@"загрузить функции {generalData.Path}\{generalData.Functions}",

            };
            result.Add($@"\\расчет");

            var tasks = new List<string>();
            foreach (var item in arg2)
                tasks.Add("расчет " + item);

            result.AddRange(tasks);

            var compDir = $@"{generalData.Path}\ComputationData";

            if (!Directory.Exists(compDir))
                Directory.CreateDirectory(compDir);

            var cmdFile = $@"{compDir}\computation.tcf";

            File.WriteAllLines(cmdFile, result);

            BasePage.ConsoleControl.PrintInfo($"Сформирован командный файл {cmdFile}", Color.Green);

            NeedSaveProjectEvent?.Invoke(this);
        }

        private void CheckProjectDataBeforeCreationTCF()
        {
            try
            {
                var generalData = GeneralData;
                if (!File.Exists($@"{generalData.Path}\{generalData.Name}"))
                throw new Exception($"В папке проекта {generalData.Path} отсутствует файл проекта {generalData.Name}. " +
                    $"Верните файл проекта в папку проекта или выберете другой проект");

            if (!File.Exists($@"{generalData.Path}\{generalData.Materials}"))
                throw new Exception($"В папке проекта {generalData.Path} отсутствует файл материалов {generalData.Materials}. " +
                    $"Верните файл материалов в папку проекта или выберете другой файл материалов");

            if (!File.Exists($@"{generalData.Path}\{generalData.Functions}"))
                throw new Exception($"В папке проекта {generalData.Path} отсутствует файл функций {generalData.Functions}. " +
                    $"Верните файл функций в папку проекта или выберете другой файл функций");

            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void TaskAdv_AddDataUseTaskConditions(ITaskData taskData, IPreProc preProc)
        {
            try
            {
                var data = taskData.Select(x => x as IValuableData).ToList();

                var adv = GetTaskAdvisor();

                var inputDir = $@"{GeneralData.Path}\InputData";

                if (!Directory.Exists(inputDir))
                    Directory.CreateDirectory(inputDir);

                preProc.CalcCompDataV1(data, adv.ProcessType, inputDir);

                var tsfFiles = Directory.GetFiles(inputDir, "*.tsf");

                var sortedFiles = preProc.SortCompDataByTimeAndType(tsfFiles);

                GetTaskAdvisor()?.SetTaskPlannerlData(sortedFiles);

                BasePage.ConsoleControl.PrintInfo($"Входные Данные задачи сгенерированы в {inputDir}", Color.Green);

            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private T GetDataBase<T>(string dbName, string dbPath)
        {
            var filePath = FindFileByPath(dbPath, dbName);
            if (filePath == null)
            {
                BasePage.ConsoleControl.PrintInfo($"Не найдена база {dbName} в папке {dbPath}", Color.Orange);
                return default;
            }
 
            else 
                return LoadDataBase<T>(dbName, dbPath);
        }

        private void TaskAdv_StopComputationEvent(object arg1, EventArgs arg2)
        {
            var runProc = Process.GetProcessesByName("BazisSolverCP");

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

        public void TaskAdvisor_StartComputationEvent(object arg1, EventArgs arg2)
        {
            try
            {
                var myProcess = new Process();

                myProcess.StartInfo.FileName = $@"{SolverPath}\BazisSolverCP.exe";

                var compDir = $@"{GeneralData.Path}\ComputationData";
                var cmdFile = $@"{compDir}\computation.tcf";

                var argStr = string.Join(" ", new string[] { cmdFile });

                myProcess.StartInfo.Arguments = argStr;
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                myProcess.Start();
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void PresentMatAndFuncDataOnTree()
        {
            try
            {
                var navigator = BasePage.NavigatorControl;

                navigator.TreeView.BeginUpdate();

                navigator.TreeView.Nodes.RemoveByKey("База материалов");
                var matNode = new TreeNode($"База материалов : {GeneralData.Materials}") { Name = "База материалов" };
                navigator.TreeView.Nodes.Insert(4, matNode);

                navigator.TreeView.Nodes.RemoveByKey("База функций");
                var funNode = new TreeNode($"База функций : {GeneralData.Functions}") { Name = "База функций" };
                navigator.TreeView.Nodes.Insert(4, funNode);

                navigator.TreeView.EndUpdate();

            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void PresentTaskDataOnTree(ITaskData taskData)
        {
            try
            {
                var navigator = BasePage.NavigatorControl;

                navigator.TreeView.BeginUpdate();

                navigator.TreeView.Nodes["Данные"].Nodes.Clear();

                navigator.TreeView.Nodes.RemoveByKey("База материалов");
                var matNode = new TreeNode($"База материалов : {GeneralData.Materials}") { Name = "База материалов" };
                navigator.TreeView.Nodes.Insert(4, matNode);

                navigator.TreeView.Nodes.RemoveByKey("База функций");
                var funNode = new TreeNode($"База функций : {GeneralData.Functions}") { Name = "База функций" };
                navigator.TreeView.Nodes.Insert(4, funNode);

                foreach (var data in taskData)
                {
                    navigator.CreateChildNode("Данные", data.Name, data.ToString(), "6.1");
                }

                navigator.TreeView.EndUpdate();
                navigator.TreeView.Nodes["Данные"].Expand();


            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void TaskAdvisor_ChangeTaskType(ITaskData taskData, ChangeTaskTypeEventArgs arg2)
        {
            var generalData = GeneralData;
            if (arg2.Index == 0)
                generalData.TaskType = TaskType.Plain;
            else if (arg2.Index == 1)
                generalData.TaskType = TaskType.AxiPlain;
            else generalData.TaskType = TaskType.Volume;

            BasePage.NavigatorControl.TreeView.Nodes[3].Text = "Вид : " + generalData.TaskType;

            GetTaskAdvisor()?.SetProjectData(generalData, ModelData,taskData);
        }

        public TaskAdvisor GetTaskAdvisor()
        {
            var taskForm = Application.OpenForms[activeAdvisor];
            if (taskForm != null)
            {
                var taskAdvisor = (TaskAdvisor)taskForm.Controls[0];
                //var advPresenter = new AdvisorPresenter(Project);
                return taskAdvisor;
            }
            else return null;
        }

        public void TaskAdvisor_ChangeData(ITaskData taskData, ChangeDataEventArgs arg2)
        {
            try
            {
                var dataArray = taskData.Find(arg2.DataName).ToArray();

                dataArray[arg2.Index].SetInfo(arg2.DataInfo);

                var valData = dataArray[arg2.Index] as IValuableData;
                var group = GetDataGroup(arg2.DataName, arg2.DataInfo.Split(' '));

                valData.Group = group;

                if (valData.MovedFrame != null)
                    SetMFF(valData, arg2.DataInfo.Split(' ').Last());

                GetTaskAdvisor()?.SetProjectData(GeneralData, ModelData, taskData);

                var dataIndex = taskData.IndexOf(dataArray[arg2.Index]);
                BasePage.NavigatorControl.TreeView.Nodes["Данные"].Nodes[dataIndex].Text = dataArray[arg2.Index].ToString();
                //PresentProjectOnTree();
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }

        }

        private IGroup GetDataGroup(string dataName, string[] ar)
        {
            IGroup group;
            var groupName = ar[0];
            if (dataName == "Нагрев")
                groupName = ar[1];
   
            group = ModelData.GroupData.Find(groupName);

            if (group == null)
                throw new Exception(@"Группа ""groupName"" не найдена!");
            return group;
        }

        public void TaskAdvisor_DeleteAllData(ITaskData taskData, DeleteAllDataEventArgs arg2)
        {
            try
            {
                if (arg2.DataName == "Расчет")
                {
                    foreach (var file in Directory.GetFiles($@"{GeneralData.Path}\InputData"))
                    {
                        if (Regex.IsMatch(file, @"(\w*)(\.tsf)"))
                            File.Delete(file);
                    }
                    var tsfFiles = Directory.GetFiles($@"{GeneralData.Path}\InputData", "*.tsf");

                    var sortedFiles = preProc.SortCompDataByTimeAndType(tsfFiles);

                    GetTaskAdvisor()?.SetTaskPlannerlData(sortedFiles);
                }
                else
                {
                    var dataArray = taskData.Find(arg2.DataName).ToArray();

                    foreach (var data in dataArray)
                    {
                        var index = taskData.IndexOf(data);
                        BasePage.NavigatorControl.TreeView.Nodes["Данные"].Nodes.RemoveAt(index);

                        taskData.Remove(data);
                    }
                    GetTaskAdvisor()?.SetProjectData(GeneralData, ModelData, taskData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File can't be deleted: {ex.Message}");
            }
        }

        public void TaskAdvisor_ShowData(ITaskData taskData, ShowDataEventArgs arg2)
        {
            var scenePage = BasePage.ScenePage;
            scenePage.SceneControl.HideAllGeometryObjs();
            var data = taskData.Find(arg2.DataName).
                Select(x => (IValuableData)x).ToArray();

            foreach (var index in arg2.GetDataInfo())
            {
                var group = data[index].Group;

                if (data[index].FrameFunction != null)
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

                    if (data[index].Direction != Direction.None)
                        DisplayDirection(data[index].StartTime, data[index], iobj);
                }

                scenePage.SetObjectsSceneColor(group.ObjType);

                //SetVBObjColor(group.ObjType);

            }
            scenePage.SceneControl.DisplayObjects();
        }

        private void DisplayMRF(float time, IValuableData data)
        {
            var scenePage = BasePage.ScenePage;
            var frame = data.MovedFrame.CalcFrame(time - data.StartTime);
            scenePage.SceneControl.DisplayLocalFrame(frame);
            var trajPoints = data.MovedFrame.BaseLine.Select(x => x.CalcCentr()).ToArray();
            scenePage.SceneControl.DisplayPath(trajPoints);

            if (data.FrameFunction is ISphereFunction sphear )
            {
                scenePage.SceneControl.DisplaySphere(sphear.Width, frame);
            }
            else if (data.FrameFunction is ICillindricalFunction cilinder )
            {
                scenePage.SceneControl.DisplayConus(cilinder.UpperDiam, cilinder.BottomDiam, cilinder.Length, frame);
            }
        }

        private void DisplayDirection(float time, IValuableData data, IModelObject modelObj)
        {
            var vector = new Point3D();
            Color color;

            if (data.Direction == Direction.X)
            {
                vector = new Point3D(1, 0, 0);
                color = Color.FromArgb(255, 0, 0);
            }

            else if (data.Direction == Direction.Y)
            {
                vector = new Point3D(0, 1, 0);
                color = Color.FromArgb(0, 255, 0);
            }

            else
            {
                vector = new Point3D(0, 0, 1);
                color = Color.FromArgb(0, 0, 255);
            }

            foreach (var point in modelObj.GetCoordinates())
            {
                var scenePage = BasePage.ScenePage;
                var scl = 10 * (1.0f / Height * 1.0f / scenePage.SceneControl.ScaleFactor);
                vector = vector.Mult(scl);
                var p1 = point.Sum(vector);
                scenePage.SceneControl.DisplayLine(point, p1, color);
                //SceneControl.DisplayText3D(data.CalcValue(time, point).ToString(), Color.FromArgb(0, 0, 0), point);
            }
        }

        public void TaskAdvisor_HideDataEvent(object arg1, HideDataEventArgs arg2)
        {
            var scenePage = BasePage.ScenePage;
            scenePage.SceneControl.HideAllGeometryObjs();
            scenePage.SceneControl.HideDisplayText3D();
            scenePage.SetBackColorToAllObjects();
            scenePage.SceneControl.DisplayObjects();
        }

        public void TaskAdvisor_CheckData(ITaskData taskData, CheckDataEventArgs arg2)
        {
            try
            {
                var scenePage = BasePage.ScenePage;
                scenePage.SceneControl.HideAllGeometryObjs();
                var selectedData = taskData.Find(arg2.DataName).Select(x => (IValuableData)x);
                foreach (var data in selectedData)
                {
                    if (arg2.Time >= data.StartTime & arg2.Time <= data.StopTime)
                    {
                        if (data.FrameFunction != null)
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
                                iobj.MasterColor = Color.FromArgb(125, 155, 255, 0);

                            //PresentProjectTaskDataOnScene(arg2.Time, data, modelObj);
                            if (data.Direction != Direction.None)
                                DisplayDirection(arg2.Time, data, iobj);
                        }

                        scenePage.SetObjectsSceneColor(group.ObjType);

                        scenePage.SceneControl.DisplayObjects();
                    }
                }
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }       
        }

        public void TaskAdvisor_DeleteData(ITaskData taskData, DeleteDataEventArgs arg2)
        {
            var dataArray = taskData.Find(arg2.DataName).ToArray();

            var index = taskData.IndexOf(dataArray[arg2.Index]);
            BasePage.NavigatorControl.TreeView.Nodes["Данные"].Nodes.RemoveAt(index);

            taskData.Remove(dataArray[arg2.Index]);

            PresentTaskDataOnTree(taskData);
        }

        public async void TaskAdvisor_AddData(ITaskData taskData, AddDataEventArgs arg2)
        {
            try
            {
                if(arg2 is GenerateTSFEventArgs args)
                {
                    var settingsSerializer = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        Formatting = Newtonsoft.Json.Formatting.Indented
                    };

                    if (!Directory.Exists($@"{GeneralData.Path}\InputData"))
                        Directory.CreateDirectory($@"{GeneralData.Path}\InputData");

                    var adv = GetTaskAdvisor();

                    preProc.SetDraftParameters(args.Parameters, adv.ProcessType);
                    var parLine = JsonConvert.SerializeObject(args.Parameters, settingsSerializer);

                    File.WriteAllText($@"{GeneralData.Path}\InputData\{args.DataInfo}", parLine);

                    var tsfFiles = Directory.GetFiles($@"{GeneralData.Path}\InputData", "*.tsf");
                    var sortedFiles = preProc.SortCompDataByTimeAndType(tsfFiles);

                    GetTaskAdvisor()?.SetTaskPlannerlData(sortedFiles);
                }

                else
                {
                    var ar = arg2.DataInfo.Split(' ');

                    var group = GetDataGroup(arg2.DataName, ar);

                    if (arg2.DataInfo.Contains("LRF"))
                        await AddDataLRF(taskData, arg2, ar, group);

                    else
                        AddData(taskData, arg2, ar, group);

                    GetTaskAdvisor()?.SetProjectData(GeneralData, ModelData, taskData);
                }
 
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void AddData(ITaskData taskData, AddDataEventArgs arg2, string[] ar, IGroup group)
        {
            var data = (IValuableData)taskData.Create(arg2.DataName, arg2.DataInfo, group);
            if (data.FrameFunction != null)
                SetMFF(data, ar.Last());
            taskData.Add(data);
            BasePage.NavigatorControl.CreateChildNode("Данные", data.Name, $"{data.Name} : {data.GetInfo}", "6.1");
        }

        private async Task AddDataLRF(ITaskData taskData,AddDataEventArgs arg2, string[] ar, IGroup group)
        {
            BasePage.ScenePage.SelectedObjects = ObjType.Узел;
            var taskStrLRF = BasePage.CreateSurfaceAsync(ObjType.Узел);
            await taskStrLRF;
            var vec = taskStrLRF.Result.Normal;
            var nVec = Vector.GetVectorNorm(vec);

            var val = float.Parse(ar[3]);

            var rVec = nVec.Mult(val);

            //TO DO
            ar[2] = "X";
            ar[3] = rVec._x.ToString();

            var data = (IValuableData)taskData.Create(arg2.DataName, string.Join(" ", ar), group);
            if (data.FrameFunction != null)
                SetMFF(data, ar.Last());

            taskData.Add(data);
            BasePage.NavigatorControl.CreateChildNode("Данные", data.Name, $"{data.Name} : {data.GetInfo}", "6.1");

            ar[2] = "Y";
            ar[3] = rVec._y.ToString();

            data = (IValuableData)taskData.Create(arg2.DataName, string.Join(" ", ar), group);
            if (data.FrameFunction != null)
                SetMFF(data, ar.Last());

            taskData.Add(data);
            BasePage.NavigatorControl.CreateChildNode("Данные", data.Name, $"{data.Name} : {data.GetInfo}", "6.1");

            ar[2] = "Z";
            ar[3] = rVec._z.ToString();

            data = (IValuableData)taskData.Create(arg2.DataName, string.Join(" ", ar), group);
            if (data.FrameFunction != null)
                SetMFF(data, ar.Last());

            taskData.Add(data);
            BasePage.NavigatorControl.CreateChildNode("Данные", data.Name, $"{data.Name} : {data.GetInfo}", "6.1");
        }

        private void SetMFF(IValuableData data, string trajInfo)
        {
            //var trajInfo = data.TrajectoryInfo;
            var scenePage = BasePage.ScenePage;

            var baseLineGrName = trajInfo.Split(';')[0].Split('|')[0];
            var refLineGrName = trajInfo.Split(';')[0].Split('|')[1];
            var stNodesGrName = trajInfo.Split(';')[2];
            var baseLineGr = ModelData.GroupData.Find(baseLineGrName);
            var refLineGr = ModelData.GroupData.Find(refLineGrName);
            var stNodesGr = ModelData.GroupData.Find(stNodesGrName);

            data.MovedFrame.BaseLine = baseLineGr;
            data.MovedFrame.RefLine = refLineGr;
            data.MovedFrame.StartPoints = stNodesGr;
            data.MovedFrame.StopPoints = stNodesGr;

            //Проверка узлов траектории
            data.MovedFrame.CheckTrajNodes();
            var vel = data.MovedFrame.Velosity;
            //Проверка самопересечения от скорости движения

            if (data.FrameFunction != null)
                if (!data.FrameFunction.IsOverlappingSelf(vel))
                    BasePage.ConsoleControl.PrintInfo("Скорость источника не позволяет добиться самопересечения при движении! " +
                        "Рекомендуется снизить скорость", Color.Orange);
            //Sort
            data.MovedFrame.SortTrajNodes();

            data.StopTime = data.StartTime + data.MovedFrame.CalcMotionTime();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskData?.Clear();
            PresentTaskDataOnTree(taskData);
            GetTaskAdvisor()?.SetProjectData(GeneralData, ModelData, taskData);
        }

        private void TaskPage_ChangedGroupNameEvent()
        {
            PresentTaskDataOnTree(taskData);
            GetTaskAdvisor()?.SetProjectData(GeneralData, ModelData, taskData);
        }

        private void TaskPage_CreatedMeshGroupEvent()
        {
            GetTaskAdvisor()?.SetProjectData(GeneralData, ModelData, taskData);
        }

        private void TaskPage_DeleteAllGroupsEvent()
        {
            taskData?.Clear();
            PresentTaskDataOnTree(taskData);
            GetTaskAdvisor()?.SetProjectData(GeneralData, ModelData, taskData);
        }

        private void TaskPage_DeleteGroupEvent()
        {
            taskData?.ClearNotExisted(ModelData.GroupData);
            PresentTaskDataOnTree(taskData);
            GetTaskAdvisor()?.SetProjectData(GeneralData, ModelData, taskData);
        }
    }
}
