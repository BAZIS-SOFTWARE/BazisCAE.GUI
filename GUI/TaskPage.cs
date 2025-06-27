using BaseModule.Extensions;
using BaseModule.GanttChart;
using BaseModule.Navigator;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using BaseModule.Tasks.TasksFromNavigator;
using BaseModule.Utilities;
using BazisGUI.PropertiesPanel;
using BazisGUI.TasksControls;
using BazisGUI.Utilities;
using Geometry;
using Model.Interfaces;
using Newtonsoft.Json;
using PreProc;
using PreProc.Interfaces;
using Project.Interfaces;
using Project.Interfaces.Tasks;
using Project.TaskParameters;
using Project.Tasks.FrameCreators;
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
using System.Windows.Forms;
using TaskModule.BasicTaskAdvisor;

namespace BazisGUI
{
    
    public partial class BaseForm
    {
        //public Priority Priority { get; private set; }
        public ProcessType ProcessType{ get; set; }
        public string SolverPath { get; set; }

        PreProc.PreProc preProc = new PreProc.PreProc();

        public event Action<object> NeedSaveProjectEvent;
        public event Action<object,string> SelectConditionEvent;
        public event Action<object, AddDataEventArgs> CreatePhysicalDataEvent;
        public event Action<object> DeleteAllPhysicalDataEvent;
        public event Action<object> ShowGantChartEvent;
        public event Action<object,string> AddPhysicalDataEvent;

        public event Action<object> GenerateTSFEvent;
        public event Action<object, EventArgs> StopComputationEvent;
        public event Action<object> GenerateTCFEvent;
        public event Action<object, string> EditTSFEvent;

        PropertyPanelProvider panelProvider = new PropertyPanelProvider();

        

        

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

        public void EditTSFFile(string fileName)
        {
            try
            {
                var parameters = ReadTaskParametersFromFile(fileName);

                var cntr = new TaskControl();
                cntr.BtnSave_ClickEvent += (arg) =>
                {
                    File.WriteAllText(fileName, arg);
                    console.PrintInfo($"Файл {fileName} изменен", Color.Green);
                };
                cntr.InputData(parameters);

                var location = scene.PointToScreen(Point.Empty);

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
                console.PrintInfo(ex.Message, Color.Green);
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

        private void CheckProjectDataBeforeCreationTCF()
        {
            try
            {
                var generalData = project.GeneralData;

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
                console.PrintInfo(ex.Message, Color.Red);
            }
        }      

        public void PresentCompDataOnTree(List<string> compData)
        {
            navigator.BeginUpdate();
            navigator.TrySearchNodes(NodeType.задачи.ToString(), out List<TreeNode> tasks);

            tasks[0].Nodes.Clear();

            foreach (var item in compData)
            {
                var r = navigator.CreateRealNode("расчет", item);

                tasks[0].Nodes.Add(r);
            }

            navigator.EndUpdate();
        }

        public T GetDataBase<T>(string dbName, string dbPath)
        {
            var filePath = FindFileByPath(dbPath, dbName);
            if (filePath == null)
            {
                console.PrintInfo($"Не найдена база {dbName} в папке {dbPath}", Color.Orange);
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

        

        public void PresentMatAndFuncDataOnTree(IGeneralData generalData)
        {
            try
            {
                navigator.BeginUpdate();
                navigator.TrySearchNodes(NodeType.базаМатериалов, out List<TreeNode> mats);
                mats[0].Text = $"База материалов : {generalData.Materials}";

                navigator.TrySearchNodes(NodeType.базаФункций, out List<TreeNode> func);
                func[0].Text = $"База функций : {generalData.Functions}";

                navigator.EndUpdate();

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
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
                var dataKind = Converters.ConvertToDataKind(arg2.DataName);
                var dataArray = taskData.Find(dataKind).ToArray();

                navigator.TrySearchNodes(NodeType.условия, out List<TreeNode> cond);
                foreach (var data in dataArray)
                {
                    var index = taskData.IndexOf(data);

                    cond[0].Nodes.RemoveAt(index);

                    taskData.Remove(data);
                }
                var adv = GetTaskAdvisor();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File can't be deleted: {ex.Message}");
            }
        }

        private void DisplayMRF(float time, IPhysicalData data)
        {
            var mf = data.FrameFunction.LocalFrame as MovedFrame;
            mf.Time = time - data.StartTime;

            scene.SceneControl.DisplayLocalFrame(mf.Frame);
            var trajPoints = mf.BaseLine.Select(x => x.CalcCentr()).ToArray();
            scene.SceneControl.DisplayPath(trajPoints);

            if (data.FrameFunction is SphereFunction sphear )
            {
                scene.SceneControl.DisplaySphere(sphear.Width, mf.Frame);
            }
            else if (data.FrameFunction is CillindricalFunction cilinder )
            {
                scene.SceneControl.DisplayConus(cilinder.UpperDiam, cilinder.BottomDiam, cilinder.Length, mf.Frame);
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
                    var scl = 10 * (1.0f / Height * 1.0f / scene.SceneControl.ScaleFactor);
                    vector = vector.Mult(scl);
                    var p1 = point.Sum(vector);
                    scene.SceneControl.DisplayLine(point, p1, color);
                }

                //SceneControl.DisplayText3D(data.CalcValue(time, point).ToString(), Color.FromArgb(0, 0, 0), point);
            }
        }         

        public void DeleteConditions(IGeneralData generalData, ITaskData taskData, DeleteDataEventArgs arg2)
        {
            var dataKind = Converters.ConvertToDataKind(arg2.DataName);
            var dataArray = taskData.Find(dataKind).ToArray();

            var index = taskData.IndexOf(dataArray[arg2.Index]);

            navigator.TrySearchNodes(NodeType.условия, out List<TreeNode> cond);
            cond[0].Nodes.RemoveAt(index);

            taskData.Remove(dataArray[arg2.Index]);

            PresentTaskDataOnTree(generalData, taskData);
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

        //private void ConfigureMenuItemEnabledForModule(string processType)
        //{
        //    if (processType == "ТО")
        //    {
        //        var mainItem = condsMenuStrip.Items["добавитьToolStripMenuItem"] as ToolStripMenuItem;
        //        if (mainItem != null)
        //        {
        //            var subItem = mainItem.DropDownItems["нагревToolStripMenuItem"];
        //            if (subItem != null) subItem.Enabled = false;
        //        }
        //    }
        //}

        

        private void Navigator_AddPhysicalData(object sender, ToolStripItemClickedEventArgs e)
        {
            AddPhysicalDataEvent?.Invoke(this, e.ClickedItem.Name);
        }      
    }
}