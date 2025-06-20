using BaseModule.GanttChart;
using BaseModule.Mesh;
using BaseModule.Navigator;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using BaseModule.Tasks.TasksFromNavigator;
using BaseModule.Utilities;
using BazisGUI.Extensions;
using BazisGUI.TasksControls;
using BazisGUI.Utilities;
using Geometry;
using Model;
using Model.Interfaces;
using ModelControllerInterfaces;
using Newtonsoft.Json;
using PreProc;
using PreProc.Interfaces;
using Project;
using Project.Interfaces;
using Project.Interfaces.Tasks;
using Project.TaskParameters;
using Project.Tasks;
using Project.Tasks.FrameCreators;
using Project.Tasks.Functions;
using Project.Tasks.Functions.Welding;
using PropertiesCalculator.FunctionData;
using PropertiesCalculator.MaterialData;
using PropertiesDataBases.DataBases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskModule.BasicTaskAdvisor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BazisGUI
{
    public partial class TaskPage: ToolStripPage
    {
        public ProcessType ProcessType{ get; set; }
        public string SolverPath { get; set; }

        PreProc.PreProc preProc = new PreProc.PreProc();

        public event Action<object> NeedSaveProjectEvent;
        public event Action<object,TreeNode> SelectPhysicalDataEvent;
        public event Action<object, AddDataEventArgs> CreatePhysicalDataEvent;
        public event Action<object> DeleteAllPhysicalDataEvent;
        public event Action<object> ShowGantChartEvent;
        public event Action<object,string> AddPhysicalDataEvent;

        public event Action<object, Tasks, Priority> GenerateTSFEvent;
        public event Action<object, EventArgs> StopComputationEvent;
        public event Action<object, GenerateTCFEventArgs> GenerateTCFEvent;
        public event Action<object, string> EditTSFEvent;
        public TaskPage()
        {
            InitializeComponent();
            var taskNode = new TreeNode("Данные", 14, 14) { Name = "Данные", Tag = "6" };
            taskNode.ContextMenuStrip = taskMenuStrip;
            BasePage.NavigatorControl.TreeView.Nodes.Add(taskNode);

            selectToolStrip.Location = new Point(3, 0);

            instrumentalToolStrip.Location = new Point(selectToolStrip.Size.Width + 4, 0);
            BasePage.SelectPhysicalDataEvent += basePage_SelectPhysicalData;

            var pContr = (PinnedTaskPlannerControl)EmbeddedControls.Find("pinnedTaskPlannerControl", false)[0];
            pContr.GenerateTSFEvent += GenerateTSFEvent;
            pContr.GenerateTCFEvent += GenerateTCFEvent;
            pContr.EditTSFEvent += EditTSFEvent;
            pContr.StopComputationEvent += StopComputationEvent;
        }
        private void basePage_SelectPhysicalData(TreeNode arg1)
        {
            SelectPhysicalDataEvent?.Invoke(this, arg1);
        }

        public void OpenFunctionsDB(IGeneralData generalData)
        {
            try
            {
                var funBasePage = new FunctionDataBasePage() { Dock = DockStyle.Fill, HeadColor = Color.Gainsboro };
                funBasePage.LoadEvent += () =>
                {
                    ChangeFuncDBEventHandler(generalData,funBasePage);
                };

                funBasePage.SaveEvent += () =>
                {
                    ChangeFuncDBEventHandler(generalData,funBasePage);
                };

                var filePath = FindFileByPath(generalData.Path, generalData.Functions);
                if (filePath == null)
                    BasePage.ConsoleControl.PrintInfo($"База данных {generalData.Functions} не найдена в директории {generalData.Path}", Color.Red);
                else
                    funBasePage.Load($@"{filePath}\{generalData.Functions}", false);

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

        public void OpenMaterialsDB(IGeneralData generalData)
        {
            try
            {
                var matBasePage = new MaterialsDataBasePage() { Dock = DockStyle.Fill, HeadColor = Color.Gainsboro };

                matBasePage.LoadEvent += () =>
                {
                    ChangeMaterialDBEventHandler(generalData,matBasePage);
                };

                matBasePage.SaveEvent += () =>
                {
                    ChangeMaterialDBEventHandler(generalData,matBasePage);
                };

                var filePath = FindFileByPath(generalData.Path, generalData.Materials);
                if (filePath == null)
                    BasePage.ConsoleControl.PrintInfo($"База данных {generalData.Materials} не найдена в директории {generalData.Path}", Color.Red);
                else
                    matBasePage.Load($@"{filePath}\{generalData.Materials}", false);

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

        public void ChangeFuncDBEventHandler(IGeneralData generalData, FunctionDataBasePage funBasePage)
        {
            if (funBasePage.DbPath != generalData.Path)
                IOFileController.CopyFile(funBasePage.DbName, funBasePage.DbPath, generalData.Path);

            generalData.Functions = funBasePage.DbName;
            var funData = funBasePage.Functions;
            GetTaskAdvisor()?.SetFunctions(funData.Keys.ToList());
            PresentMatAndFuncDataOnTree(generalData);
        }

        public void ChangeMaterialDBEventHandler(IGeneralData generalData, MaterialsDataBasePage matBasePage)
        {
            if (matBasePage.DbPath != generalData.Path)
                IOFileController.CopyFile(matBasePage.DbName, matBasePage.DbPath, generalData.Path);

            generalData.Materials = matBasePage.DbName;
            var matData = matBasePage.Materials;
            GetTaskAdvisor()?.SetMaterials(matData.Keys.ToList());
            PresentMatAndFuncDataOnTree(generalData);
        }

        public void FillAdvisor(TaskAdvisor taskAdv)
        {
            //try
            //{
            //    var generalData = GeneralData;
            //    //var btn = sender as ToolStripMenuItem;
            //    var appFolder = Path.GetDirectoryName(Application.ExecutablePath);
            //    if (appFolder == generalData.Path)
            //    {
            //        MessageBox.Show("Рабочая папка проекта должна отличаться от папки установки программы!");
            //        return;
            //    }

            //    taskAdv.TaskType = generalData.TaskType.ToString();

            //    var matDB = GetDataBase<MaterialDBData>(generalData.Materials, generalData.Path);

            //    if (matDB == null)
            //        BasePage.ConsoleControl.PrintInfo($"Не загружена база {generalData.Materials}", Color.Orange);
            //    else

            //        taskAdv.SetMaterials(matDB.Keys.ToList());

            //    var funDB = GetDataBase<FunctionDBData>(generalData.Functions, generalData.Path);

            //    if (funDB == null)
            //        BasePage.ConsoleControl.PrintInfo($"Не загружена база {generalData.Functions}", Color.Orange);
            //    else
            //        taskAdv.SetFunctions(funDB.Keys.ToList());

            //    SetProjectData(taskAdv);

            //    var inputDir = $@"{generalData.Path}\InputData";

            //    if (Directory.Exists(inputDir))
            //    {
            //        var tsfFiles = Directory.GetFiles(inputDir, "*.tsf");

            //        var sortedFiles = preProc.SortCompDataByTimeAndType(tsfFiles);
            //        taskAdv.SetTaskPlannerlData(sortedFiles);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            //}
        }

        public void SetAdvisor(TaskAdvisor taskAdv)
        {
            //try
            //{
            //    //activeAdvisor = taskAdv.Name;
            //    taskAdv.GenerateTCFEvent += TaskAdv_GenerateTCFEvent;
            //    taskAdv.EditTSFEvent += TaskAdv_EditTSFEvent;
            //    taskAdv.AddDataUseTaskConditionsEvent += (ar1,ar2,ar3) => { TaskAdv_AddDataUseTaskConditions(taskData, preProc,ar2,ar3); };
            //    taskAdv.AddDataEvent += (ar1, ar2) => { TaskAdvisor_AddData(taskData, ar2); };
            //    taskAdv.DeleteDataEvent += (ar1, ar2) => { TaskAdvisor_DeleteData(taskData, ar2); };
            //    taskAdv.DeleteAllDataEvent += (ar1, ar2) => { TaskAdvisor_DeleteAllData(taskData, ar2); };
            //    taskAdv.CheckDataEvent += (ar1, ar2) => { TaskAdvisor_CheckData(taskData, ar2); };
            //    taskAdv.HideDataEvent += TaskAdvisor_HideDataEvent;
            //    taskAdv.ShowDataEvent += (ar1, ar2) => { TaskAdvisor_ShowData(taskData, ar2); };
            //    taskAdv.ChangeDataEvent += (ar1,ar2) => { TaskAdvisor_ChangeData(taskData,ar2); };
            //    taskAdv.StopComputationEvent += TaskAdv_StopComputationEvent;
            //    taskAdv.Select2DAxiEvent += (ar1,ar2) => { TaskAdvisor_ChangeTaskType(taskData,ar2); };
            //    taskAdv.Select2DPlaneEvent += (ar1, ar2) => { TaskAdvisor_ChangeTaskType(taskData, ar2); };
            //    taskAdv.Select3DEvent += (ar1, ar2) => { TaskAdvisor_ChangeTaskType(taskData, ar2); };

            //    ConfigureMenuItemEnabledForModule(taskAdv.Parent);
            //}
            //catch (Exception ex)
            //{
            //    BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            //}
        }

        public void EditTSFFile(string fileName)
        {
            try
            {
                var parameters = ReadTaskParametersFromFile(fileName);

                var cntr = new TaskControl();
                cntr.BtnSave_ClickEvent += (arg) =>
                {
                    File.WriteAllText(fileName, arg);
                    BasePage.ConsoleControl.PrintInfo($"Файл {fileName} изменен", Color.Green);
                };
                cntr.InputData(parameters);

                var location = BasePage.ScenePage.PointToScreen(Point.Empty);

                var form = new Form()
                {
                    Text = fileName,
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

        private void CheckProjectDataBeforeCreationTCF(IGeneralData generalData)
        {
            try
            {
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

        public void GenerateTSFFiles(IProjectData project, Tasks tasks,Priority priority)
        {
            try
            {
                var data = project.TaskData.ToList();

                var adv = GetTaskAdvisor();

                var inputDir = $@"{project.GeneralData.Path}\InputData";

                if (!Directory.Exists(inputDir))
                    Directory.CreateDirectory(inputDir);

                var oldTSF = Directory.GetFiles(inputDir);
                if (oldTSF.Length > 0) Array.ForEach(oldTSF, x => File.Delete(x));

                var taskKind = Converters.ConvertToPreProcType(tasks);

                var procProp = new ProcessProperty()
                {
                    TaskKind = taskKind,
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

        public T GetDataBase<T>(string dbName, string dbPath)
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

        public void StopComputation()
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

        public void StartComputation(IGeneralData generalData)
        {
            try
            {
                var myProcess = new Process();

                myProcess.StartInfo.FileName = $@"{SolverPath}\BazisSolverCP.exe";

                var compDir = $@"{generalData.Path}\ComputationData";
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

        public void PresentMatAndFuncDataOnTree(IGeneralData generalData)
        {
            try
            {
                var navigator = BasePage.NavigatorControl;

                navigator.TreeView.BeginUpdate();

                navigator.TreeView.Nodes.RemoveByKey("База материалов");
                var matNode = new TreeNode($"База материалов : {generalData.Materials}") { Name = "База материалов" };
                navigator.TreeView.Nodes.Insert(4, matNode);

                navigator.TreeView.Nodes.RemoveByKey("База функций");
                var funNode = new TreeNode($"База функций : {generalData.Functions}") { Name = "База функций" };
                navigator.TreeView.Nodes.Insert(4, funNode);

                navigator.TreeView.EndUpdate();

            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void PresentTaskDataOnTree(IGeneralData generalData, ITaskData taskData)
        {
            try
            {
                var navigator = BasePage.NavigatorControl;

                navigator.TreeView.BeginUpdate();

                navigator.TreeView.Nodes["Данные"].Nodes.Clear();

                navigator.TreeView.Nodes.RemoveByKey("База материалов");
                var matNode = new TreeNode($"База материалов : {generalData.Materials}") { Name = "База материалов" };
                navigator.TreeView.Nodes.Insert(4, matNode);

                navigator.TreeView.Nodes.RemoveByKey("База функций");
                var funNode = new TreeNode($"База функций : {generalData.Functions}") { Name = "База функций" };
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

        private List<string> GetLoadGroupsNames(TaskType taskType, IModelData modelData)
        {
            if (taskType == TaskType.AxiPlain || taskType == TaskType.Plain)
                return modelData.GroupData.FindMany(ObjType.Элемент2D).Select(x => x.Name).ToList();
            else
                return modelData.GroupData.FindMany(ObjType.Элемент3D).Select(x => x.Name).ToList();
        }

        private List<string> GetBoundaryGroupsNames(TaskType taskType, IModelData modelData)
        {
            if (taskType == TaskType.AxiPlain || taskType == TaskType.Plain)
                return modelData.GroupData.FindMany(ObjType.Элемент1D).Select(x => x.Name).ToList();
            else
                return modelData.GroupData.FindMany(ObjType.Элемент2D).Select(x => x.Name).ToList();
        }

        private List<string> GetMaterialGroupsNames(TaskType taskType, IModelData modelData)
        {
            if (taskType == TaskType.AxiPlain || taskType == TaskType.Plain)
                return modelData.GroupData.FindMany(ObjType.Элемент2D).Select(x => x.Name).ToList();
            else
                return modelData.GroupData.FindMany(ObjType.Элемент3D).Select(x => x.Name).ToList();
        }

        public virtual TaskAdvisor GetTaskAdvisor()
        {
            throw new Exception("Мастер не реализован");
        }

        public void TaskAdvisor_DeleteAllData(IGeneralData generalData, ITaskData taskData, DeleteAllDataEventArgs arg2)
        {
            try
            {
                if (arg2.DataName == "Расчет")
                {
                    foreach (var file in Directory.GetFiles($@"{generalData.Path}\InputData"))
                    {
                        if (Regex.IsMatch(file, @"(\w*)(\.tsf)"))
                            File.Delete(file);
                    }
                    var tsfFiles = Directory.GetFiles($@"{generalData.Path}\InputData", "*.tsf");

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File can't be deleted: {ex.Message}");
            }
        }

        private void DisplayMRF(float time, IPhysicalData data)
        {
            var scenePage = BasePage.ScenePage;
            var mf = data.FrameFunction.LocalFrame as MovedFrame;
            mf.Time = time - data.StartTime;

            scenePage.SceneControl.DisplayLocalFrame(mf.Frame);
            var trajPoints = mf.BaseLine.Select(x => x.CalcCentr()).ToArray();
            scenePage.SceneControl.DisplayPath(trajPoints);

            if (data.FrameFunction is SphereFunction sphear )
            {
                scenePage.SceneControl.DisplaySphere(sphear.Width, mf.Frame);
            }
            else if (data.FrameFunction is CillindricalFunction cilinder )
            {
                scenePage.SceneControl.DisplayConus(cilinder.UpperDiam, cilinder.BottomDiam, cilinder.Length, mf.Frame);
            }
        }

        public void DisplayDirection(float time, IPhysicalData data, IEnumerable<IModelObject> modelObjs)
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

            foreach (var obj in modelObjs)
            {
                foreach (var point in obj.GetCoordinates())
                {
                    var scenePage = BasePage.ScenePage;
                    var scl = 10 * (1.0f / Height * 1.0f / scenePage.SceneControl.ScaleFactor);
                    vector = vector.Mult(scl);
                    var p1 = point.Sum(vector);
                    scenePage.SceneControl.DisplayLine(point, p1, color);
                }

                //SceneControl.DisplayText3D(data.CalcValue(time, point).ToString(), Color.FromArgb(0, 0, 0), point);
            }
        }

        public void Navigator_HideDataEvent(object arg1, IModelData modelData,HideDataEventArgs arg2)
        {
            
            var scenePage = BasePage.ScenePage;
            scenePage.SceneControl.HideAllGeometryObjs();
            scenePage.SceneControl.HideDisplayText3D();
            foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
            {
                modelData.ObjectData.SetBackColor(type);
                var pres = scenePage.CreateObjectsPresentor(modelData, type);
                scenePage.SetObjectsSceneAttribute(pres, type.ToString(), "цвет");
            }
            scenePage.SceneControl.DisplayObjects();
        }

        public void Navigator_CheckData(ITaskData taskData, IModelData modelData, CheckDataEventArgs arg2)
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
                        }
                        if (data.Direction != Direction.None)
                            DisplayDirection(arg2.Time, data, group);
                        var pres = scenePage.CreateObjectsPresentor(modelData, group.ObjType);
                        scenePage.SetObjectsSceneAttribute(pres,group.ObjType.ToString(), "цвет");

                        scenePage.SceneControl.DisplayObjects();
                    }
                }
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void Navigator_DeleteData(IGeneralData generalData, ITaskData taskData, DeleteDataEventArgs arg2)
        {
            var dataKind = Converters.ConvertToDataKind(arg2.DataName);
            var dataArray = taskData.Find(dataKind).ToArray();

            var index = taskData.IndexOf(dataArray[arg2.Index]);
            BasePage.NavigatorControl.TreeView.Nodes["Данные"].Nodes.RemoveAt(index);

            taskData.Remove(dataArray[arg2.Index]);

            PresentTaskDataOnTree(generalData,taskData);
        }

        public async void Navigator_AddData(IProjectData project, AddDataEventArgs arg2)
        {
            try
            {
                if (arg2.DataInfo.Contains("LRF"))
                {
                    var scenePage = BasePage.ScenePage;
                    foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
                    {
                        project.ModelData.ObjectData.SetBackColor(type);
                        var pres = scenePage.CreateObjectsPresentor(project.ModelData, type);
                        scenePage.SetObjectsSceneAttribute(pres, type.ToString(), "цвет");
                    }

                    scenePage.SceneControl.DisplayObjects();
                    SelectedObjects = ObjType.Узел.ToString();

                    var taskStrLRF = BasePage.CreateSurfaceAsync(project.ModelData, ObjType.Узел);
                    await taskStrLRF;
                    var vec = taskStrLRF.Result.Normal;
                    var nVec = Geometry.Vector.GetVectorNorm(vec);

                    AddDataLRF(project,nVec, arg2.DataName, arg2.DataInfo);
                }
                else
                {
                    var newData = project.TaskData.Create(arg2.DataName.ToDataKind(), arg2.DataInfo, project.ModelData.GroupData);
                    project.TaskData.Add(newData);
                }

                PresentTaskDataOnTree(project.GeneralData, project.TaskData);
            }
            catch (Exception ex)
            {
                BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void AddDataLRF(IProjectData project,Point3D vec, string dataName, string dataInfo)
        {
            var dataAr = dataInfo.Split(' ');

            var lrfStr = dataAr.First(x => x.Contains("LRF"));
            var lrfInd = lrfStr.IndexOf("LRF");
            var valStr = dataAr[lrfInd + 1];

            var val = float.Parse(valStr);
            var rVec = vec.Mult(val);

            dataAr[lrfInd] = "X";
            dataAr[lrfInd] = rVec._x.ToString();

            var x_data = project.TaskData.Create(dataName.ToDataKind(), string.Join(" ", dataAr), project.ModelData.GroupData);
            project.TaskData.Add(x_data);

            dataAr[lrfInd] = "Y";
            dataAr[lrfInd] = rVec._y.ToString();

            var y_data = project.TaskData.Create(dataName.ToDataKind(), string.Join(" ", dataAr), project.ModelData.GroupData);
            project.TaskData.Add(y_data);

            dataAr[lrfInd] = "Z";
            dataAr[lrfInd] = rVec._z.ToString();

            var z_data = project.TaskData.Create(dataName.ToDataKind(), string.Join(" ", dataAr), project.ModelData.GroupData);
            project.TaskData.Add(z_data);
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

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAllPhysicalDataEvent?.Invoke(this);
        }

        private void diagram_gantt_toolStripMenuItem_Click(object sender, EventArgs eventArgs)
        {
            if (!(sender is ToolStripMenuItem toolStripMenuItem))
                return;

            ShowGantChartEvent?.Invoke(this);
        }

        public void ShowGantChart(IEnumerable<string> tasks)
        {
            var ganttContol = new GanttChartTreeView(tasks, 10);
            var ganttDiagramForm = new Form
            {
                ClientSize = new Size(850, 600),
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false,
                MinimizeBox = false
            };

            ganttDiagramForm.Controls.Add(ganttContol);
            ganttDiagramForm.Show(this);
        }

        private void ConfigureMenuItemEnabledForModule(string processType)
        {
            if (processType == "ТО")
            {
                var mainItem = taskMenuStrip.Items["добавитьToolStripMenuItem"] as ToolStripMenuItem;
                if (mainItem != null)
                {
                    var subItem = mainItem.DropDownItems["нагревToolStripMenuItem"];
                    if (subItem != null) subItem.Enabled = false;
                }
            }
        }

        public void AddPhysicalData(IProjectData project, string dataType)
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

            var elLoadGrpsNames = GetLoadGroupsNames(project.GeneralData.TaskType, project.ModelData);
            var ndGrpsNames = project.ModelData.GroupData.FindMany(ObjType.Узел).Select(x => x.Name).ToList();

            var appFolder = Path.GetDirectoryName(Application.ExecutablePath);
            if (appFolder == project.GeneralData.Path)
            {
                MessageBox.Show("Рабочая папка проекта должна отличаться от папки установки программы!");
                return;
            }
            var matDB = GetDataBase<MaterialDBData>(project.GeneralData.Materials, project.GeneralData.Path);
            var funDB = GetDataBase<FunctionDBData>(project.GeneralData.Functions, project.GeneralData.Path);

            if (matDB == null || funDB == null)
            {
                BasePage.ConsoleControl.PrintInfo("Не выбран источник базы данных!", Color.Red);
                return;
            }
            var mat = matDB.Keys.ToList();
            var func = funDB.Keys.ToList();

            var generalControlCreator = new GeneralСontrol(dataType, mat, func, elLoadGrpsNames, ndGrpsNames);
            generalControlCreator.CreatePhysicalDataEvent += (arg) => { CreatePhysicalDataEvent?.Invoke(this, arg); };
            //generalControlCreator.CreatePhysicalDataEvent += (s) => generalForm.Close();
            generalForm.Controls.Add(generalControlCreator);
            generalForm.Show(this);
        }

        private void Navigator_AddPhysicalData(object sender, ToolStripItemClickedEventArgs e)
        {
            AddPhysicalDataEvent?.Invoke(this, e.ClickedItem.Name);
        }

        public void GenerateAndSolveTCFfile(IGeneralData generalData, List<string> inputLines)
        {
            CheckProjectDataBeforeCreationTCF(generalData);

            var compDir = $@"{generalData.Path}\ComputationData";

            if (!Directory.Exists(compDir))
                Directory.CreateDirectory(compDir);

            var result = new List<string>
            {
                $@"\\загрузка сетки и данных",
                $@"загрузить проект {generalData.Path}\{generalData.Name}",
                $@"\\загрузка материалов",
                $@"загрузить материалы {generalData.Path}\{generalData.Materials}",
                $@"\\загрузка функций",
                $@"загрузить функции {generalData.Path}\{generalData.Functions}",
                $@"\\расчет"
            };

            var tasks = new List<string>();
            foreach (var item in inputLines)
                tasks.Add("расчет " + item);

            result.AddRange(tasks);

            var cmdFile = $@"{compDir}\computation.tcf";

            File.WriteAllLines(cmdFile, result);

            BasePage.ConsoleControl.PrintInfo($"Сформирован командный файл {cmdFile}", Color.Green);

            StartComputation(generalData);
        }

        private void расчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pContr = (PinnedTaskPlannerControl)EmbeddedControls.Find("pinnedTaskPlannerControl", false)[0];
            pContr.BringToFront();
        }
    }
}