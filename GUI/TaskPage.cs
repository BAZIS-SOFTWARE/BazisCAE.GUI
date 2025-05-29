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
using Newtonsoft.Json;
using Geometry;
using BaseModule.Utilities;
using ModelControllerInterfaces;
using System.Text.RegularExpressions;
using PropertiesCalculator.MaterialData;
using PropertiesCalculator.FunctionData;
using PropertiesDataBases.DataBases;
using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BazisGUI.TasksControls;
using Project.Interfaces;
using PreProc.Interfaces;
using PreProc;
using Project.Interfaces.Tasks;
using Model.Interfaces;
using Project.TaskParameters;
using BazisGUI.Utilities;
using BaseModule.Navigator;
using BaseModule.GanttChart;
using Project.Tasks.Functions;
using Project.Tasks.FrameCreators;
using BaseModule.Tasks.TasksFromNavigator;
using Project.Tasks;

namespace BazisGUI
{
    public partial class TaskPage: ToolStripPage
    {
        public ProcessType ProcessType{ get; set; }
        public string SolverPath { get; set; }

        IGeneralData GeneralData { get { return BasePage.GetGeneralData(); } }

        PreProc.PreProc preProc;

        private protected ITaskData taskData;

        private Form ganttDiagramForm;

        public void SetPreProc(PreProc.PreProc preProc)
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

            selectToolStrip.Location = new Point(3, 0);

            instrumentalToolStrip.Location = new Point(selectToolStrip.Size.Width + 4, 0);
            BasePage.OnValuableDataSelectedEvent += BasePage_ValuableEvent;
            BasePage.panelProvider.GetAllGroupElements = () => ModelData.GroupData.ToList();
            BasePage.panelProvider.GetFuncDB = () => GetDataBase<FunctionDBData>(GeneralData.Functions, GeneralData.Path).Keys.ToList();
            BasePage.panelProvider.GetMatDB = () => GetDataBase<MaterialDBData>(GeneralData.Materials, GeneralData.Path).Keys.ToList();
            BasePage.panelProvider.OnUpdateNavigator += () => PresentTaskDataOnTree(taskData);
        }
        private void BasePage_ValuableEvent(TreeNode arg1, SelectionType arg2)
        {
            var info = arg1.Text; 
            var groups = taskData.First(x => x.ToString() == info);
            BasePage.panelProvider.ShowPropertiesPanel(groups, arg1);
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
            GetTaskAdvisor()?.SetFunctions(funData.Keys.ToList());
            PresentMatAndFuncDataOnTree();
        }

        public void ChangeMaterialDBEventHandler(MaterialsDataBasePage matBasePage)
        {
            if (matBasePage.DbPath != GeneralData.Path)
                IOFileController.CopyFile(matBasePage.DbName, matBasePage.DbPath, GeneralData.Path);

            GeneralData.Materials = matBasePage.DbName;
            var matData = matBasePage.Materials;
            GetTaskAdvisor()?.SetMaterials(matData.Keys.ToList());
            PresentMatAndFuncDataOnTree();
        }

        public void FillAdvisor(TaskAdvisor taskAdv)
        {
            try
            {
                var generalData = GeneralData;
                //var btn = sender as ToolStripMenuItem;
                var appFolder = Path.GetDirectoryName(Application.ExecutablePath);
                if (appFolder == generalData.Path)
                {
                    MessageBox.Show("Рабочая папка проекта должна отличаться от папки установки программы!");
                    return;
                }

                taskAdv.TaskType = generalData.TaskType.ToString();

                var matDB = GetDataBase<MaterialDBData>(generalData.Materials, generalData.Path);

                if (matDB == null)
                    BasePage.ConsoleControl.PrintInfo($"Не загружена база {generalData.Materials}", Color.Orange);
                else

                    taskAdv.SetMaterials(matDB.Keys.ToList());

                var funDB = GetDataBase<FunctionDBData>(generalData.Functions, generalData.Path);

                if (funDB == null)
                    BasePage.ConsoleControl.PrintInfo($"Не загружена база {generalData.Functions}", Color.Orange);
                else
                    taskAdv.SetFunctions(funDB.Keys.ToList());

                SetProjectData(taskAdv);

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

        public void SetAdvisor(TaskAdvisor taskAdv)
        {
            try
            {
                //activeAdvisor = taskAdv.Name;
                taskAdv.GenerateTCFEvent += TaskAdv_GenerateTCFEvent;
                taskAdv.EditTSFEvent += TaskAdv_EditTSFEvent;
                taskAdv.AddDataUseTaskConditionsEvent += (ar1,ar2,ar3) => { TaskAdv_AddDataUseTaskConditions(taskData, preProc,ar2,ar3); };
                taskAdv.AddDataEvent += (ar1, ar2) => { TaskAdvisor_AddData(taskData, ar2); };
                taskAdv.DeleteDataEvent += (ar1, ar2) => { TaskAdvisor_DeleteData(taskData, ar2); };
                taskAdv.DeleteAllDataEvent += (ar1, ar2) => { TaskAdvisor_DeleteAllData(taskData, ar2); };
                taskAdv.CheckDataEvent += (ar1, ar2) => { TaskAdvisor_CheckData(taskData, ar2); };
                taskAdv.HideDataEvent += TaskAdvisor_HideDataEvent;
                taskAdv.ShowDataEvent += (ar1, ar2) => { TaskAdvisor_ShowData(taskData, ar2); };
                taskAdv.ChangeDataEvent += (ar1,ar2) => { TaskAdvisor_ChangeData(taskData,ar2); };
                taskAdv.StopComputationEvent += TaskAdv_StopComputationEvent;
                taskAdv.Select2DAxiEvent += (ar1,ar2) => { TaskAdvisor_ChangeTaskType(taskData,ar2); };
                taskAdv.Select2DPlaneEvent += (ar1, ar2) => { TaskAdvisor_ChangeTaskType(taskData, ar2); };
                taskAdv.Select3DEvent += (ar1, ar2) => { TaskAdvisor_ChangeTaskType(taskData, ar2); };

                ConfigureMenuItemEnabledForModule(taskAdv.Parent);
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void TaskAdv_EditTSFEvent(object arg1, string arg3)
        {
            try
            {
                var parameters = ReadTaskParametersFromFile(arg3);

                var cntr = new TaskControl();
                cntr.BtnSave_ClickEvent += (arg) =>
                {
                    File.WriteAllText(arg3, arg);
                    BasePage.ConsoleControl.PrintInfo($"Файл {arg3} изменен", Color.Green);
                };
                cntr.InputData(parameters);

                var location = BasePage.ScenePage.PointToScreen(Point.Empty);

                var form = new Form()
                {
                    Text = arg3,
                    ShowIcon = false,
                    ClientSize = cntr.Size,
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    Owner = Application.OpenForms[0],

                };
                form.Controls.Add(cntr);
                form.Location = location;
                form.Show();
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Green);
            }
       
        }

        public GeneralParameters ReadTaskParametersFromFile(string filePath)
        {
            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var taskName = fileName.Split('_')[0];

            Tasks tasksSet;
            Enum.TryParse(taskName, out tasksSet);

            if (tasksSet == Tasks.термическая)
            {
                return JsonConvert.DeserializeObject<TermalParameters>
(File.ReadAllText(filePath), settingsSerializer);
            }
            else if (tasksSet == Tasks.механическая)
            {
                return JsonConvert.DeserializeObject<MechanicalParameters>
(File.ReadAllText(filePath), settingsSerializer);
            }
            else return JsonConvert.DeserializeObject<ChemicalParameters>
(File.ReadAllText(filePath), settingsSerializer);

        }

        private void TaskAdv_GenerateTCFEvent(object arg1, GenerateTCFEventArgs arg2)
        {
            CheckProjectDataBeforeCreationTCF();
            
            var compDir = $@"{GeneralData.Path}\ComputationData";

            if (!Directory.Exists(compDir))
                Directory.CreateDirectory(compDir);

            var result = new List<string>
            {
                $@"\\загрузка сетки и данных",
                $@"загрузить проект {GeneralData.Path}\{GeneralData.Name}",
                $@"\\загрузка материалов",
                $@"загрузить материалы {GeneralData.Path}\{GeneralData.Materials}",
                $@"\\загрузка функций",
                $@"загрузить функции {GeneralData.Path}\{GeneralData.Functions}",
                $@"\\расчет"
            };

            var tasks = new List<string>();
            foreach (var item in arg2)
                tasks.Add("расчет " + item);

            result.AddRange(tasks);

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

        private void TaskAdv_AddDataUseTaskConditions(ITaskData taskData, IPreProc preProc,Tasks tasks,Priority priority)
        {
            try
            {
                var data = taskData.ToList();

                var adv = GetTaskAdvisor();

                var inputDir = $@"{GeneralData.Path}\InputData";

                if (!Directory.Exists(inputDir))
                    Directory.CreateDirectory(inputDir);

                var oldTSF = Directory.GetFiles(inputDir);
                if (oldTSF.Length > 0) Array.ForEach(oldTSF, x => File.Delete(x));

                var taskType = Converters.ConvertToPreProcType(tasks);

                var procProp = new ProcessProperty()
                {
                    GeneralTaskType = taskType,
                    CommonTaskType = ProcessType
                };

                preProc.CalcCompDataV2(data, procProp, inputDir);

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

        public void TaskAdvisor_StartComputationEvent()
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
                    AddTaskDataToNavigator(data);
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
            var adv = GetTaskAdvisor();
            SetProjectData(adv);
        }

        public void SetProjectData(TaskAdvisor taskAdv)
        {
            var ndGrpsNames = ModelData.GroupData.FindMany(ObjType.Узел).Select(x => x.Name).ToList();
            var elMatsGrpsNames = GetMaterialGroupsNames(GeneralData.TaskType);
            var elBndsGrpsNames = GetBoundaryGroupsNames(GeneralData.TaskType);
            var elLoadGrpsNames = GetLoadGroupsNames(GeneralData.TaskType);

            taskAdv?.SetProjectData(taskData.Select(x => x.ToString()));
            taskAdv?.SetBoundaryGroups(ndGrpsNames,elBndsGrpsNames);
            taskAdv?.SetMaterialGroups(elMatsGrpsNames);
            taskAdv?.SetLoadGroups(ndGrpsNames, elLoadGrpsNames);
        }

        private List<string> GetLoadGroupsNames(TaskType taskType)
        {
            if (taskType == TaskType.AxiPlain || taskType == TaskType.Plain)
                return ModelData.GroupData.FindMany(ObjType.Элемент2D).Select(x => x.Name).ToList();
            else
                return ModelData.GroupData.FindMany(ObjType.Элемент3D).Select(x => x.Name).ToList();
        }

        private List<string> GetBoundaryGroupsNames(TaskType taskType)
        {
            if (taskType == TaskType.AxiPlain || taskType == TaskType.Plain)
                return ModelData.GroupData.FindMany(ObjType.Элемент1D).Select(x => x.Name).ToList();
            else
                return ModelData.GroupData.FindMany(ObjType.Элемент2D).Select(x => x.Name).ToList();
        }

        private List<string> GetMaterialGroupsNames(TaskType taskType)
        {
            if (taskType == TaskType.AxiPlain || taskType == TaskType.Plain)
                return ModelData.GroupData.FindMany(ObjType.Элемент2D).Select(x => x.Name).ToList();
            else
                return ModelData.GroupData.FindMany(ObjType.Элемент3D).Select(x => x.Name).ToList();
        }

        public virtual TaskAdvisor GetTaskAdvisor()
        {
            throw new Exception("Мастер не реализован");
        }

        public void TaskAdvisor_ChangeData(ITaskData taskData, ChangeDataEventArgs arg2)
        {
            try
            {
                var dataKind = Converters.ConvertToDataKind(arg2.DataName);
                var dataArray = taskData.Find(dataKind).ToArray();

                var ar = arg2.DataInfo.Split(' ');
                var group = GetDataGroup(arg2.DataName, ar);

                var data = taskData.Create(arg2.DataName, arg2.DataInfo, group);
                if (data.FrameFunction != null)
                    SetMFF(data, ar.Last());

                dataArray[arg2.Index] = data;

                var adv = GetTaskAdvisor();
                SetProjectData(adv);

                var dataIndex = taskData.IndexOf(dataArray[arg2.Index]);
                BasePage.NavigatorControl.TreeView.Nodes["Данные"].Nodes[dataIndex].Text = dataArray[arg2.Index].ToString();
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
                groupName = ar[3];
   
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
                    var dataKind = Converters.ConvertToDataKind(arg2.DataName);
                    var dataArray = taskData.Find(dataKind).ToArray();

                    foreach (var data in dataArray)
                    {
                        var index = taskData.IndexOf(data);
                        BasePage.NavigatorControl.TreeView.Nodes["Данные"].Nodes.RemoveAt(index);

                        taskData.Remove(data);
                    }
                    var adv = GetTaskAdvisor();
                    SetProjectData(adv);
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

            var dataKind = Converters.ConvertToDataKind(arg2.DataName);
            var data = taskData.Find(dataKind).ToArray();

            foreach (var index in arg2.GetDataInfo())
            {
                var group = data[index].Group;

                if (data[index].FrameFunction != null)
                    DisplayMRF(data[index].StartTime, data[index]);

                foreach (var iobj in group)
                {                   
                    if (data[index].Kind == DataKind.Материал)
                        iobj.Color = Color.FromArgb(255, 255, 0);
                    else if (data[index].Kind == DataKind.Среда)
                        iobj.Color = Color.FromArgb(255, 155, 0);
                    else if (data[index].Kind == DataKind.Закрепление | data[index].Kind == DataKind.Нагрузка)
                        iobj.Color = Color.FromArgb(255, 0, 0);
                    else if (data[index].Kind == DataKind.Нагрев)
                        iobj.Color = Color.FromArgb(125,155, 255, 0);

                    if (data[index].Direction != Direction.None)
                        DisplayDirection(data[index].StartTime, data[index], iobj);
                }

                scenePage.SetObjectsSceneAttribute(group.ObjType, "цвет");

                //SetVBObjColor(group.ObjType);

            }
            scenePage.SceneControl.DisplayObjects();
        }

        private void DisplayMRF(float time, IPhysicalData data)
        {
            var scenePage = BasePage.ScenePage;
            var mf = data.LocalFrame as MovedFrame;
            var frame = mf.CalcFrame(time - data.StartTime);
            scenePage.SceneControl.DisplayLocalFrame(frame);
            var trajPoints = mf.BaseLine.Select(x => x.CalcCentr()).ToArray();
            scenePage.SceneControl.DisplayPath(trajPoints);

            if (data.FrameFunction is SphereFunction sphear )
            {
                scenePage.SceneControl.DisplaySphere(sphear.Width, frame);
            }
            else if (data.FrameFunction is CillindricalFunction cilinder )
            {
                scenePage.SceneControl.DisplayConus(cilinder.UpperDiam, cilinder.BottomDiam, cilinder.Length, frame);
            }
        }

        private void DisplayDirection(float time, IPhysicalData data, IModelObject modelObj)
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
                var dataKind = Converters.ConvertToDataKind(arg2.DataName);
                var selectedData = taskData.Find(dataKind);

                foreach (var data in selectedData)
                {
                    if (arg2.Time >= data.StartTime & arg2.Time <= data.StopTime)
                    {
                        if (data.FrameFunction != null)
                            DisplayMRF(arg2.Time, data);

                        var group = data.Group;

                        foreach (var iobj in group)
                        {
                            if (data.Kind == DataKind.Материал)
                                iobj.Color = Color.FromArgb(255, 255, 0);
                            else if (data.Kind == DataKind.Среда)
                                iobj.Color = Color.FromArgb(255, 155, 0);
                            else if (data.Kind == DataKind.Закрепление | data.Kind == DataKind.Нагрузка)
                                iobj.Color = Color.FromArgb(255, 0, 0);
                            else if (data.Kind == DataKind.Нагрев)
                                iobj.Color = Color.FromArgb(125, 155, 255, 0);

                            //PresentProjectTaskDataOnScene(arg2.Time, data, modelObj);
                            if (data.Direction != Direction.None)
                                DisplayDirection(arg2.Time, data, iobj);
                        }

                        scenePage.SetObjectsSceneAttribute(group.ObjType, "цвет");

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
            var dataKind = Converters.ConvertToDataKind(arg2.DataName);
            var dataArray = taskData.Find(dataKind).ToArray();

            var index = taskData.IndexOf(dataArray[arg2.Index]);
            BasePage.NavigatorControl.TreeView.Nodes["Данные"].Nodes.RemoveAt(index);

            taskData.Remove(dataArray[arg2.Index]);

            PresentTaskDataOnTree(taskData);
        }

        public async void TaskAdvisor_AddData(ITaskData taskData, AddDataEventArgs arg2)
        {
            try
            {
                var ar = arg2.DataInfo.Split(' ');

                var group = GetDataGroup(arg2.DataName, ar);

                if (arg2.DataInfo.Contains("LRF"))
                    await AddDataLRF(taskData, arg2, ar, group);

                else
                {
                    var data = taskData.Create(arg2.DataName, arg2.DataInfo, group);
                    if (data.FrameFunction == null)
                        SetMFF(data, ar.Last());
                    taskData.Add(data);

                    AddTaskDataToNavigator(data);
                }

                var adv = GetTaskAdvisor();
                SetProjectData(adv);
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private async Task AddDataLRF(ITaskData taskData,AddDataEventArgs arg2, string[] ar, IGroup group)
        {
            BasePage.ScenePage.SelectedObjects = ObjType.Узел.ToString();
            var taskStrLRF = BasePage.CreateSurfaceAsync(ObjType.Узел);
            await taskStrLRF;
            var vec = taskStrLRF.Result.Normal;
            var nVec = Vector.GetVectorNorm(vec);

            var val = float.Parse(ar[3]);

            var rVec = nVec.Mult(val);

            //TO DO
            ar[2] = "X";
            ar[3] = rVec._x.ToString();

            var data = taskData.Create(arg2.DataName, string.Join(" ", ar), group);
            if (data.FrameFunction != null)
                SetMFF(data, ar.Last());

            taskData.Add(data);
            AddTaskDataToNavigator(data);

            ar[2] = "Y";
            ar[3] = rVec._y.ToString();

            data = taskData.Create(arg2.DataName, string.Join(" ", ar), group);
            if (data.FrameFunction != null)
                SetMFF(data, ar.Last());

            taskData.Add(data);
            AddTaskDataToNavigator(data);

            ar[2] = "Z";
            ar[3] = rVec._z.ToString();

            data = taskData.Create(arg2.DataName, string.Join(" ", ar), group);
            if (data.FrameFunction != null)
                SetMFF(data, ar.Last());

            taskData.Add(data);
            AddTaskDataToNavigator(data);
        }

        private void AddTaskDataToNavigator(IData data)
        {
            NodeType nodeType;
            Enum.TryParse(data.Kind.ToString(), out nodeType);
            var imgIndex = BasePage.NavigatorControl.GetObjectImageIndex(nodeType);

            var child = new TreeNode($"{data}", imgIndex, imgIndex)
            { Tag = "6.1", Name = data.Kind.ToString() };
            BasePage.NavigatorControl.TreeView.Nodes["Данные"].Nodes.Add(child);
        }


        private void SetMFF(IPhysicalData data, string trajInfo)
        {
            //var trajInfo = data.TrajectoryInfo;
            var scenePage = BasePage.ScenePage;
            var ar = trajInfo.Split(';');
            if (ar.Length == 4)
            {
                var baseLineGrName = ar[0].Split('|')[0];
                var refLineGrName = ar[0].Split('|')[1];
                var stNodesGrName = ar[1];
                var baseLineGr = ModelData.GroupData.Find(baseLineGrName);
                var refLineGr = ModelData.GroupData.Find(refLineGrName);
                var stNodesGr = ModelData.GroupData.Find(stNodesGrName);
                var vel = float.Parse(ar[2]);

                var mfb = new MovedFrameBuilder().Build(stNodesGr, baseLineGr, refLineGr, vel);
                data.LocalFrame = mfb;

                //Проверка самопересечения от скорости движения

                if (data.FrameFunction != null)
                    if (!data.FrameFunction.IsOverlappingSelf(mfb.Velosity))
                        BasePage.ConsoleControl.PrintInfo("Скорость источника не позволяет добиться самопересечения при движении! " +
                            "Рекомендуется снизить скорость", Color.Orange);
                //Sort
                data.StopTime = data.StartTime + (float)Math.Round(mfb.CalcMotionTime(), 4);
            }

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskData?.Clear();
            PresentTaskDataOnTree(taskData);
            var adv = GetTaskAdvisor();

            SetProjectData(adv);
        }

        private void TaskPage_ChangedGroupNameEvent()
        {
            PresentTaskDataOnTree(taskData);
            var adv = GetTaskAdvisor();
            SetProjectData(adv);
        }

        private void TaskPage_CreatedMeshGroupEvent()
        {
            var adv = GetTaskAdvisor();
            SetProjectData(adv);
        }

        private void TaskPage_DeleteAllGroupsEvent()
        {
            taskData?.Clear();
            PresentTaskDataOnTree(taskData);
            var adv = GetTaskAdvisor();
            SetProjectData(adv);
        }

        private void TaskPage_DeleteGroupEvent()
        {
            taskData?.ClearNotExisted(ModelData.GroupData);
            PresentTaskDataOnTree(taskData);
            var adv = GetTaskAdvisor();
            SetProjectData(adv);
        }

        private void diagram_gantt_toolStripMenuItem_Click(object sender, EventArgs eventArgs)
        {
            if (!(sender is ToolStripMenuItem toolStripMenuItem))
                return;
            if(toolStripMenuItem.Checked)
            {
                ganttDiagramForm.Close();
                toolStripMenuItem.Checked = false;
                return;
            }
            var tasks = taskData.Select(t => t.ToString());
            var ganttContol = new GanttChartTreeView(tasks, 10);
            ganttDiagramForm = new Form
            {
                ClientSize = new Size(850, 600),
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false,
                MinimizeBox = false
            };
            ganttDiagramForm.Controls.Add(ganttContol);
            ganttDiagramForm.Show(this);
            toolStripMenuItem.Checked = true;
            ganttDiagramForm.FormClosed += (s, e) => toolStripMenuItem.Checked = false;
        }

        private void ConfigureMenuItemEnabledForModule(Control parent)
        {

            if(parent is BaseModule.Tasks.HeatTreatmentModule.PinnedHTAdvControl)
            {
                var mainItem = taskMenuStrip.Items["добавитьToolStripMenuItem"] as ToolStripMenuItem;
                if (mainItem != null)
                {
                    var subItem = mainItem.DropDownItems["нагревToolStripMenuItem"];
                    if (subItem != null) subItem.Enabled = false;
                }
            }
        }

        private void AddPhysicalData(object sender, EventArgs eventArgs)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            var generalForm = new Form
            {
                Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon"))),
                Text = "Инструмент создания физических данных",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var elLoadGrpsNames = GetLoadGroupsNames(GeneralData.TaskType);
            var ndGrpsNames = ModelData.GroupData.FindMany(ObjType.Узел).Select(x => x.Name).ToList();
            var generalData = GeneralData;
            var appFolder = Path.GetDirectoryName(Application.ExecutablePath);
            if (appFolder == generalData.Path)
            {
                MessageBox.Show("Рабочая папка проекта должна отличаться от папки установки программы!");
                return;
            }
            var matDB = GetDataBase<MaterialDBData>(generalData.Materials, generalData.Path);
            var funDB = GetDataBase<FunctionDBData>(generalData.Functions, generalData.Path);
            
            if(matDB == null || funDB == null)
            {
                BasePage.ConsoleControl.PrintInfo("Не выбран источник базы данных!", Color.Red);
                return;
            }
            var mat = matDB.Keys.ToList();
            var func = funDB.Keys.ToList();

            var generalControlCreator = new GeneralСontrol(sender.ToString(), mat, func, elLoadGrpsNames, ndGrpsNames);
            generalControlCreator.CreatePhysicalDataEvent += CreateTaskData;
            generalControlCreator.CreatePhysicalDataEvent += (s) => generalForm.Close();
            generalForm.Controls.Add(generalControlCreator);
            generalForm.Show(this);
        }

        public void CreateTaskData(AddDataEventArgs arg2)
        {
            PhysicalData genData = null;
            var data = arg2.DataInfo.Split(' ');
            var group = GetDataGroup(arg2.DataName, data);
            switch (arg2.DataName)
            {
                case "Материал":
                    MatData matData = new MatData(group, arg2.DataInfo);
                    genData = matData as PhysicalData;
                    break;
                case "Закрепление":
                    ClampData clampData = new ClampData(group, arg2.DataInfo);
                    genData = clampData as PhysicalData;
                    break;
                case "Нагрузка":
                    LoadData loadData = new LoadData(group, arg2.DataInfo);
                    genData = loadData as PhysicalData;
                    break;
                case "Среда":
                    MediaData mediaData = new MediaData(group, arg2.DataInfo);
                    genData = mediaData as PhysicalData;
                    break;
                case "Нагрев":
                    HeatData heatData = new HeatData(group, arg2.DataInfo);
                    genData = heatData as PhysicalData;
                    var func = data[2].Split(';');
                    genData.FrameFunction = (FrameFunction)(new FrameFunctionBuilder(func));
                    break;
            }
            taskData.Add(genData);
            PresentTaskDataOnTree(taskData);
        }
    }
}