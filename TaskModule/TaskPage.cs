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
using BaseModule.Navigator;
using DataBasesGUI;
using Geometry;
//using Tasks;
using ProjectInterfaces.Tasks;
using ModelInterfaces;
using TaskModule.BasicAdvisorControls.TaskPlannerControls;
using BaseModule.Console;

namespace TaskModule
{
    public partial class TaskPage: BasePage
    {
        string activeAdvisor  = String.Empty;
        public string SolverPath { get; set; }

        public IPreProc PreProc { get; set; }

        //public MaterialDBData MatData { get; set; }
        //public FunctionDBData FunData { get; set; }

        public TaskPage()
        {
            InitializeComponent();

            var taskNode = new TreeNode("Данные", 1, 1) { Name = "Данные", Tag = "6" };
            taskNode.ContextMenuStrip = taskMenuStrip;
            NavigatorControl.TreeView.Nodes.Add(taskNode);

            ChangeProjectDataEvent += () => { GetTaskAdvisor()?.SetProjectData(Project); };
        }

        public override void CreateMenuInterface()
        {
            AddMenuItem(CreateDataBaseInterface());
            AddMenuItem(CreateTasksInterface());
            base.CreateMenuInterface();
        }

        public virtual ToolStripMenuItem CreateTasksInterface()
        {
            ToolStripMenuItem tasksMenuItem = new ToolStripMenuItem()
            {
                Name = "tasksMenuItem",
                Text = "Задачи",
                Enabled = false
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
                    var form = new Form() { Name = name, Text = name, TopMost = true, Owner = Application.OpenForms[0],Size = matBasePage.Size, Icon = icon };
                    form.Controls.Add(matBasePage);
                    form.ClientSize = matBasePage.Size;
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
                    var form = new Form() { Name = name, Text = name, TopMost = true, Owner = Application.OpenForms[0],Size = funBasePage.Size, Icon = icon };
                    form.Controls.Add(funBasePage);
                    form.ClientSize = funBasePage.Size;
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
                Project.CopyFile(funBasePage.DbName, funBasePage.DbPath, Project.Path);

            Project.Functions = funBasePage.DbName;
            var funData = funBasePage.Functions;
            GetTaskAdvisor()?.SetFunctionData(funData.Keys.ToList());
            PresentProjectOnTree();
        }

        private void ChangeMaterialDBEventHandler(MaterialsDataBasePage matBasePage)
        {
            if (matBasePage.DbPath != Project.Path)
                Project.CopyFile(matBasePage.DbName, matBasePage.DbPath, Project.Path);

            Project.Materials = matBasePage.DbName;
            var matData = matBasePage.Materials;
            GetTaskAdvisor()?.SetMaterialData(matData.Keys.ToList());
            PresentProjectOnTree();
        }

        public void DeleteAdvisor()
        {
            Application.OpenForms[activeAdvisor]?.Close();
            activeAdvisor = "";
        }

        public virtual void UnCheckToolStripButton(string toolStripButtonText)
        {
            foreach (var item in GetMenuItems())
                foreach (var dropItem in item.DropDownItems)
                    if (dropItem is ToolStripMenuItem tls)
                        if(tls.Text == toolStripButtonText)
                            tls.Checked = false;
        }

        public void CreateAdvisor(TaskAdvisor taskAdv)
        {
            try
            {
                var appFolder = Path.GetDirectoryName(Application.ExecutablePath);
                if (appFolder == Project.Path)
                {
                    MessageBox.Show("Рабочая папка проекта должна отличаться от папки установки программы!");
                    return;
                }

                activeAdvisor = taskAdv.Name;
                var form = new Form() { Text = taskAdv.Text, Name = taskAdv.Name, TopMost = true, Owner = Application.OpenForms[0],Size = taskAdv.Size, ShowIcon = false };
                form.FormClosed += (ar1, ar2) =>
                {
                    if (ar2.CloseReason == CloseReason.UserClosing)
                    {
                        UnCheckToolStripButton(taskAdv.Text);
                    }
                    activeAdvisor = "";
                };
                form.Controls.Add(taskAdv);
                form.ClientSize = taskAdv.Size;
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
                    ConsoleControl.PrintInfo($"Не загружена база {Project.Materials}", Color.Orange);
                else

                    taskAdv.SetMaterialData(matDB.Keys.ToList());

                var funDB = GetDataBase<FunctionDBData>(Project.Functions, Project.Path);

                if (funDB == null)
                    ConsoleControl.PrintInfo($"Не загружена база {Project.Functions}", Color.Orange);
                else
                    taskAdv.SetFunctionData(funDB.Keys.ToList());


                taskAdv.SetProjectData(Project);

                var inputDir = $@"{Project.Path}\InputData";

                if (Directory.Exists(inputDir))
                {
                    var tsfFiles = Directory.GetFiles(inputDir, "*.tsf");

                    var sortedFiles = PreProc.SortCompDataByTimeAndType(tsfFiles);
                    taskAdv.SetTaskPlannerlData(sortedFiles);
                }
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void TaskAdv_GenerateTCFEvent(object arg1, GenerateTCFEventArgs arg2)
        {
            CheckProjectDataBeforeCreationTCF();
            var result = new List<string>
            {
                $@"\\загрузка сетки и данных",
                $@"загрузить проект {Project.Path}\{Project.Name}",
                $@"\\загрузка материалов",
                $@"загрузить материалы {Project.Path}\{Project.Materials}",
                $@"\\загрузка функций",
                $@"загрузить функции {Project.Path}\{Project.Functions}",

            };
            result.Add($@"\\расчет");

            var tasks = new List<string>();
            foreach (var item in arg2)
                tasks.Add("расчет " + item);

            result.AddRange(tasks);

            var compDir = $@"{Project.Path}\ComputationData";

            if (!Directory.Exists(compDir))
                Directory.CreateDirectory(compDir);

            var cmdFile = $@"{compDir}\computation.tcf";

            File.WriteAllLines(cmdFile, result);

            ConsoleControl.PrintInfo($"Сформирован командный файл {cmdFile}", Color.Green);
        }

        private void CheckProjectDataBeforeCreationTCF()
        {
            try
            {
            if (!File.Exists($@"{Project.Path}\{Project.Name}"))
                throw new Exception($"В папке проекта {Project.Path} отсутствует файл проекта {Project.Name}. " +
                    $"Верните файл проекта в папку проекта или выберете другой проект");

            if (!File.Exists($@"{Project.Path}\{Project.Materials}"))
                throw new Exception($"В папке проекта {Project.Path} отсутствует файл материалов {Project.Materials}. " +
                    $"Верните файл материалов в папку проекта или выберете другой файл материалов");

            if (!File.Exists($@"{Project.Path}\{Project.Functions}"))
                throw new Exception($"В папке проекта {Project.Path} отсутствует файл функций {Project.Functions}. " +
                    $"Верните файл функций в папку проекта или выберете другой файл функций");

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void TaskAdv_AddDataUseTaskConditionsEvent(object arg1, EventArgs arg2)
        {
            try
            {
                var data = Project.TaskData.Select(x => x as IValuableData).ToList();

                var adv = GetTaskAdvisor();

                var inputDir = $@"{Project.Path}\InputData";

                if (!Directory.Exists(inputDir))
                    Directory.CreateDirectory(inputDir);

                PreProc.CalcCompDataV1(data, adv.ProcessType, inputDir);

                var tsfFiles = Directory.GetFiles(inputDir, "*.tsf");

                var sortedFiles = PreProc.SortCompDataByTimeAndType(tsfFiles);

                GetTaskAdvisor()?.SetTaskPlannerlData(sortedFiles);

                ConsoleControl.PrintInfo($"Входные Данные задачи сгенерированы в {inputDir}", Color.Green);

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private T GetDataBase<T>(string dbName, string dbPath)
        {
            var filePath = FindFileByPath(dbPath, dbName);
            if (filePath == null)
            {
                ConsoleControl.PrintInfo($"Не найдена база {dbName} в папке {dbPath}", Color.Orange);
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

        public void TaskAdvisor_StartComputationEvent(object arg1, EventArgs arg2)
        {
            try
            {
                Project.Save();

                ConsoleControl.PrintInfo("Проект сохранен в " + Project.Path, Color.Black);

                var myProcess = new Process();

                myProcess.StartInfo.FileName = $@"{SolverPath}\BazisSolver.exe";

                var compDir = $@"{Project.Path}\ComputationData";
                var cmdFile = $@"{compDir}\computation.tcf";

                var argStr = string.Join(" ", new string[] { cmdFile });

                myProcess.StartInfo.Arguments = argStr;
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                myProcess.Start();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        public override void PresentProjectOnTree()
        {
            try
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


            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
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
            var taskForm = Application.OpenForms[activeAdvisor];
            if (taskForm != null)
            {
                var taskAdvisor = (TaskAdvisor)taskForm.Controls[0];
                //var advPresenter = new AdvisorPresenter(Project);
                return taskAdvisor;
            }
            else return null;
        }

        public void TaskAdvisor_ChangeDataEvent(object arg1, ChangeDataEventArgs arg2)
        {
            try
            {
                var dataArray = Project.TaskData.Find(arg2.DataName).ToArray();

                dataArray[arg2.Index].SetInfo(arg2.DataInfo);

                var valData = dataArray[arg2.Index] as IValuableData;
                var group = GetDataGroup(arg2.DataName, arg2.DataInfo.Split(' '));

                valData.Group = group;

                if (valData.MovedFrame != null)
                    SetMFF(valData, arg2.DataInfo.Split(' ').Last());

                GetTaskAdvisor()?.SetProjectData(Project);

                var dataIndex = Project.TaskData.IndexOf(dataArray[arg2.Index]);
                NavigatorControl.TreeView.Nodes["Данные"].Nodes[dataIndex].Text = dataArray[arg2.Index].ToString();
                //PresentProjectOnTree();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }

        }

        private IGroup GetDataGroup(string dataName, string[] ar)
        {
            IGroup group;
            var groupName = ar[0];
            if (dataName == "Нагрев")
                groupName = ar[1];
   
            group = Project.ModelData.GroupData.Find(groupName);

            if (group == null)
                throw new Exception(@"Группа ""groupName"" не найдена!");
            return group;
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

                SetObjectsSceneColor(group.ObjType);

                //SetVBObjColor(group.ObjType);

            }
            SceneControl.DisplayObjects();
        }

        private void DisplayMRF(float time, IValuableData data)
        {
            var frame = data.MovedFrame.CalcFrame(time - data.StartTime);
            SceneControl.DisplayLocalFrame(frame);
            var trajPoints = data.MovedFrame.BaseLine.Select(x => x.CalcCentr()).ToArray();
            SceneControl.DisplayPath(trajPoints);

            if (data.FrameFunction is ISphereFunction sphear )
            {
                SceneControl.DisplaySphere(sphear.Width, frame);
            }
            else if (data.FrameFunction is ICillindricalFunction cilinder )
            {
                SceneControl.DisplayConus(cilinder.UpperDiam, cilinder.BottomDiam, cilinder.Length, frame);
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
                var scl = 10 * (1.0f / Height * 1.0f / SceneControl.ScaleFactor);
                vector = vector.Mult(scl);
                var p1 = point.Sum(vector);
                SceneControl.DisplayLine(point, p1, color);
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
            try
            {
                SceneControl.HideAllGeometryObjs();
                var selectedData = Project.TaskData.Find(arg2.DataName).Select(x => (IValuableData)x);
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

                        SetObjectsSceneColor(group.ObjType);

                        SceneControl.DisplayObjects();
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
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
                var ar = arg2.DataInfo.Split(' ');

                var group = GetDataGroup(arg2.DataName, ar);

                if (arg2.DataInfo.Contains("LRF"))
                    await AddDataLRF(arg2, ar, group);

                else
                    AddData(arg2, ar, group);

                GetTaskAdvisor()?.SetProjectData(Project);
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void AddData(AddDataEventArgs arg2, string[] ar, IGroup group)
        {
            var data = (IValuableData)Project.TaskData.Create(arg2.DataName, arg2.DataInfo, group);
            if (data.FrameFunction != null)
                SetMFF(data, ar.Last());
            Project.TaskData.Add(data);
            NavigatorControl.CreateChildNode("Данные", data.Name, $"{data.Name} : {data.GetInfo}", "6.1");
        }

        private async Task AddDataLRF(AddDataEventArgs arg2, string[] ar, IGroup group)
        {
            SelectedObjects = ObjType.Узел;
            var taskStrLRF = CreateSurfaceAsync(ObjType.Узел);
            await taskStrLRF;
            var vec = taskStrLRF.Result.Normal;
            var nVec = Vector.GetVectorNorm(vec);

            var val = float.Parse(ar[3]);

            var rVec = nVec.Mult(val);

            //TO DO
            ar[2] = "X";
            ar[3] = rVec._x.ToString();

            var data = (IValuableData)Project.TaskData.Create(arg2.DataName, string.Join(" ", ar), group);
            if (data.FrameFunction != null)
                SetMFF(data, ar.Last());

            Project.TaskData.Add(data);
            NavigatorControl.CreateChildNode("Данные", data.Name, $"{data.Name} : {data.GetInfo}", "6.1");

            ar[2] = "Y";
            ar[3] = rVec._y.ToString();

            data = (IValuableData)Project.TaskData.Create(arg2.DataName, string.Join(" ", ar), group);
            if (data.FrameFunction != null)
                SetMFF(data, ar.Last());

            Project.TaskData.Add(data);
            NavigatorControl.CreateChildNode("Данные", data.Name, $"{data.Name} : {data.GetInfo}", "6.1");

            ar[2] = "Z";
            ar[3] = rVec._z.ToString();

            data = (IValuableData)Project.TaskData.Create(arg2.DataName, string.Join(" ", ar), group);
            if (data.FrameFunction != null)
                SetMFF(data, ar.Last());

            Project.TaskData.Add(data);
            NavigatorControl.CreateChildNode("Данные", data.Name, $"{data.Name} : {data.GetInfo}", "6.1");
        }

        private void SetMFF(IValuableData data, string trajInfo)
        {
            //var trajInfo = data.TrajectoryInfo;
            var baseLineGrName = trajInfo.Split(';')[0].Split('|')[0];
            var refLineGrName = trajInfo.Split(';')[0].Split('|')[1];
            var stNodesGrName = trajInfo.Split(';')[2];
            var baseLineGr = Project.ModelData.GroupData.Find(baseLineGrName);
            var refLineGr = Project.ModelData.GroupData.Find(refLineGrName);
            var stNodesGr = Project.ModelData.GroupData.Find(stNodesGrName);

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
                    ConsoleControl.PrintInfo("Скорость источника не позволяет добиться самопересечения при движении! " +
                        "Рекомендуется снизить скорость", Color.Orange);
            //Sort
            data.MovedFrame.SortTrajNodes();

            data.StopTime = data.StartTime + data.MovedFrame.CalcMotionTime();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project.TaskData.Clear();
            PresentProjectOnTree();
            ChangeProjectDataEvent?.Invoke();
        }
    }
}
