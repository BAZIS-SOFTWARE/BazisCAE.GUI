using BaseModule.Navigator;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BaseModule.Extensions;
using Model.Interfaces.MeshObjects;
using BaseModule.Tasks.TasksFromNavigator;
using PropertiesCalculator.FunctionData;
using PropertiesCalculator.MaterialData;
using System.IO;
using Geometry;
using PreProc;
using System.Diagnostics;
using Model.Interfaces.ObjectsCollections;
using Newtonsoft.Json;
using PreProc.Interfaces;
using BazisGUI.Scene.Interfaces;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_ShowObjectEvent(NodeType arg1, string arg2, int arg3)
        {

        }

        private void navigator_ShowObjectsEvent(NodeType obj)
        {

        }

        private void navigator_HideObjectsEvent(NodeType obj)
        {

        }
        private void navigator_HideObjectEvent(NodeType arg1, string arg2, int arg3)
        {

        }
        private void navigator_DelObjectEvent(NodeType arg1, string arg2,int arg3)
        {

        }
        private void navigator_ShowGantChartEvent()
        {
            try
            {
                ShowGantChart(project.TaskData.Select(x => x.ToString()));
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void navigator_StopComputationEvent()
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

        private void navigator_SetCompPriority(object arg1, Priority arg2)
        {
            
        }
        private void navigator_RemoveAllConditionsEvent()
        {
            try
            {
                project.TaskData?.Clear();
                PresentCondDataOnTree(project.GeneralData, project.TaskData);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        public void navigator_RemoveConditionEvent(int index)
        {
            project.TaskData.RemoveAt(index);
        }

        private void navigator_RemoveResultsEvent()
        {
            try
            {
                navigator.TrySearchNodes(NodeType.результаты, out List<TreeNode> nodes);
                //nodes[0].Nodes["ПоУзлам"].Nodes.Clear();
                //nodes[0].Nodes["Набор результатов"].Nodes["ПоЭлементам"].Nodes.Clear();

                scene.ClearAllDataOnScene();

                foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                    scene.CreateObjectsOnScene(item.ToString(), scene.CreateObjectsPresentor(project.ModelData, item));

                scene.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
        private void navigator_HideResultsEvent()
        {
            try
            {
                scene.ClearAllDataOnScene();

                scene.PresentAllModelObjectsToScene(project.ModelData);

                scene.SceneControl.FitObjectsToScreen();
                scene.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void navigator_CreateAnimationEvent(object arg1, string arg2, List<string> list)
        {
            // To Do
        }      

        private void navigator_GenerateTCFEvent()
        {
            try
            {
                var generalData = project.GeneralData;
                project.Save();
                console.PrintInfo("Проект сохранен в " + generalData.Path, Color.Black);

                CheckProjectDataBeforeCreationTCF();

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
                navigator.TrySearchNodes(NodeType.задачи, out List<TreeNode> task);
                foreach (TreeNode item in task[0].Nodes)
                    tasks.Add("расчет " + item.Text);

                result.AddRange(tasks);

                var cmdFile = $@"{compDir}\computation.tcf";

                File.WriteAllLines(cmdFile, result);

                console.PrintInfo($"Сформирован командный файл {cmdFile}", Color.Green);

                StartComputation();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
  
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

        public void StartComputation()
        {
            try
            {
                var generalData = project.GeneralData;
                var myProcess = new Process();

                myProcess.StartInfo.FileName = $@"{settingsConfig.SolverPath}\BazisSolverCP.exe";

                var compDir = $@"{generalData.Path}\ComputationData";
                var cmdFile = $@"{compDir}\computation.tcf";

                var argStr = string.Join(" ", new string[] { cmdFile });

                myProcess.StartInfo.Arguments = argStr;
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                myProcess.Start();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_GenerateTSFEvent()
        {
            try
            {
                var data = project.TaskData.ToList();

                //var pContr = (PinnedTaskPlannerControl)EmbeddedControls.Find("pinnedTaskPlannerControl", false)[0];

                var inputDir = $@"{project.GeneralData.Path}\InputData";

                if (!Directory.Exists(inputDir))
                    Directory.CreateDirectory(inputDir);

                var oldTSF = Directory.GetFiles(inputDir);
                if (oldTSF.Length > 0) Array.ForEach(oldTSF, x => File.Delete(x));

                var procProp = new ProcessProperty()
                {
                    TaskKind = project.GeneralData.TaskKind,
                    CommonTaskType = ProcessType.Welding // убрать из препроцессора
                };

                preProc.CalcCompDataV2(data, procProp, inputDir);

                var tsfFiles = Directory.GetFiles(inputDir, "*.tsf");

                var sortedFiles = preProc.SortCompDataByTimeAndType(tsfFiles);

                navigator.PresentCompDataOnTree(sortedFiles);

                console.PrintInfo($"Входные Данные задачи сгенерированы в {inputDir}", Color.Green);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void navigator_HideConditionsEvent(object arg1, IModelData modelData, HideDataEventArgs arg2)
        {
            scene.SceneControl.HideAllGeometryObjs();
            scene.SceneControl.HideDisplayText3D();
            foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
            {
                modelData.ObjectData.SetBackColor(type);
                var pres = scene.CreateObjectsPresentor(modelData, type);
                scene.SetObjectsSceneAttribute(pres, type.ToString(), "цвет");
            }
            scene.SceneControl.DisplayObjects();
        }

        public void navigator_CheckConditionsEvent(ITaskData taskData, IModelData modelData, CheckDataEventArgs arg2)
        {
            try
            {
                scene.SceneControl.HideAllGeometryObjs();
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
                        var pres = scene.CreateObjectsPresentor(modelData, group.ObjType);
                        scene.SetObjectsSceneAttribute(pres, group.ObjType.ToString(), "цвет");

                        scene.SceneControl.DisplayObjects();
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }    

        private void navigator_ControlCollapseEvent()
        {

        }

        private void navigator_ControlUnpinnedEvent()
        {

        }

        private void navigator_AddConditionEvent(object arg1, NodeType arg2)
        {
            try
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
                    console.PrintInfo("Не выбран источник базы данных!", Color.Red);
                    return;
                }
                var mat = matDB.Keys.ToList();
                var func = funDB.Keys.ToList();

                var generalControlCreator = new GeneralСontrol(arg2.ToString(), mat, func, elLoadGrpsNames, ndGrpsNames);
                generalControlCreator.CreatePhysicalDataEvent += (arg) => { AddConditions(arg); };
                //generalControlCreator.CreatePhysicalDataEvent += (s) => generalForm.Close();
                generalForm.Controls.Add(generalControlCreator);
                generalForm.Show(this);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
            
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
            {
                var settingsSerializer = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented,
                };

                return JsonConvert.DeserializeObject<T>
    (File.ReadAllText($@"{dbPath}\{dbName}"), settingsSerializer);
            }
        }

        public async void AddConditions(AddDataEventArgs arg2)
        {
            try
            {
                if (arg2.DataInfo.Contains("LRF"))
                {
                    foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
                    {
                        project.ModelData.ObjectData.SetBackColor(type);
                        var pres = scene.CreateObjectsPresentor(project.ModelData, type);
                        scene.SetObjectsSceneAttribute(pres, type.ToString(), "цвет");
                    }

                    scene.SceneControl.DisplayObjects();
                    SelectedObjects = ObjType.Узел.ToString();

                    var taskStrLRF = CreateSurfaceAsync(project.ModelData, ObjType.Узел);
                    await taskStrLRF;
                    var vec = taskStrLRF.Result.Normal;
                    var nVec = Geometry.Vector.GetVectorNorm(vec);

                    AddDataLRF(nVec, arg2.DataName, arg2.DataInfo);
                }
                else
                {
                    var newData = project.TaskData.Create(arg2.DataName.ToEnum<DataKind>(), arg2.DataInfo, project.ModelData.GroupData);
                    project.TaskData.Add(newData);
                }

                PresentCondDataOnTree(project.GeneralData, project.TaskData);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void AddDataLRF(Point3D vec, string dataName, string dataInfo)
        {
            var dataAr = dataInfo.Split(' ');

            var lrfStr = dataAr.First(x => x.Contains("LRF"));
            var lrfInd = lrfStr.IndexOf("LRF");
            var valStr = dataAr[lrfInd + 1];

            var val = float.Parse(valStr);
            var rVec = vec.Mult(val);

            dataAr[lrfInd] = "X";
            dataAr[lrfInd] = rVec._x.ToString();

            var x_data = project.TaskData.Create(dataName.ToEnum<DataKind>(), string.Join(" ", dataAr), project.ModelData.GroupData);
            project.TaskData.Add(x_data);

            dataAr[lrfInd] = "Y";
            dataAr[lrfInd] = rVec._y.ToString();

            var y_data = project.TaskData.Create(dataName.ToEnum<DataKind>(), string.Join(" ", dataAr), project.ModelData.GroupData);
            project.TaskData.Add(y_data);

            dataAr[lrfInd] = "Z";
            dataAr[lrfInd] = rVec._z.ToString();

            var z_data = project.TaskData.Create(dataName.ToEnum<DataKind>(), string.Join(" ", dataAr), project.ModelData.GroupData);
            project.TaskData.Add(z_data);
        }

        private void navigator_HideAllGroupsEvent()
        {
            try
            {
                foreach (var group in project.ModelData.GroupData)
                {
                    foreach (var iobj in group)
                    {
                        iobj.ViewState = false;
                    }
                }
                scene.SceneControl.DeleteAllVBObjects();
                scene.PresentAllModelObjectsToScene(project.ModelData);
                scene.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void navigator_HideAllObjectsEvent()
        {
            try
            {
                foreach (var obj in project.ModelData.ObjectData.GetAllObjects())
                    obj.ViewState = false;

                scene.SceneControl.DeleteAllVBObjects();
                scene.PresentAllModelObjectsToScene(project.ModelData);
                scene.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void navigator_ShowGroupEvent(int obj)
        {
            try
            {
                var group = project.ModelData.GroupData[obj];
                ChangeGroupViewState(group,true);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void ChangeGroupViewState(IGroup group, bool viewState)
        {
            foreach (var iobj in group)
                iobj.ViewState = viewState;

            var vbobj = scene.SceneControl.FindVBObj(group.ObjType.ToString());
            if (vbobj == null)
                throw new Exception($"Объект {group.ObjType} не загружен на сцену!");
            var viewMode = vbobj.ViewMode;

            scene.SceneControl.DeleteVBObjects(group.ObjType.ToString());
            var pres = scene.CreateObjectsPresentor(project.ModelData, group.ObjType);
            scene.CreateObjectsOnScene(group.ObjType.ToString(), pres);
            scene.SceneControl.ChangeViewModeVBObjects(group.ObjType.ToString(), viewMode);

            scene.SceneControl.DisplayObjects();
        }

        private void navigator_HideGroupEvent(int obj)
        {
            try
            {
                var group = project.ModelData.GroupData[obj];
                ChangeGroupViewState(group, false);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_HideSetEvent(NodeType nodeType, string setName)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);
                ChangeSetViewState(setName, objType, false);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowAllObjectsEvent()
        {
            try
            {
                foreach (var obj in project.ModelData.ObjectData.GetAllObjects())
                    obj.ViewState = true;

                scene.SceneControl.DeleteAllVBObjects();
                scene.PresentAllModelObjectsToScene(project.ModelData);
                scene.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void navigator_ShowSetEvent(NodeType nodeType, string setName)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);
                ChangeSetViewState(setName, objType,true);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void ChangeSetViewState(string setName, ObjType objType, bool viewState)
        {
            foreach (var modelObject in project.ModelData.ObjectData.GetObjects(objType, setName))
                modelObject.ViewState = viewState;

            scene.SceneControl.DeleteVBObjects(objType.ToString());
            var pres = scene.CreateObjectsPresentor(project.ModelData, objType);
            scene.CreateObjectsOnScene(objType.ToString(), pres);
            scene.SceneControl.DisplayObjects();
        }

        private void navigator_InfoGroupEvent(int obj)
        {
            var group = project.ModelData.GroupData[obj];
            console.PrintInfo(group.ToString(), Color.Black);
        }

        private void navigator_ShowAllGroupsEvent()
        {
            try
            {
                foreach (var group in project.ModelData.GroupData)
                {
                    foreach (var iobj in group)
                    {
                        iobj.ViewState = true;
                    }
                }
                scene.SceneControl.DeleteAllVBObjects();
                scene.PresentAllModelObjectsToScene(project.ModelData);
                scene.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ChangeSetViewEvent(string objs, ViewRegime viewRegime)
        {
            var objType = objs.ToEnum<ObjType>();
            switch (viewRegime)
            {
                case ViewRegime.ribbers:
                    scene.SceneControl.ChangeViewModeVBObjects(objs, ObjView.Lines);
                    foreach (var item in project.ModelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.Line);
                    break;
                case ViewRegime.surfaces:
                    scene.SceneControl.ChangeViewModeVBObjects(objs, ObjView.Surface);
                    foreach (var item in project.ModelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.Surface);
                    break;
                case ViewRegime.ribbersSurfaces:
                    scene.SceneControl.ChangeViewModeVBObjects(objType.ToString(), ObjView.LinesSurface);
                    foreach (var item in project.ModelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.LineSurface);
                    break;
                default:
                    break;
            }
            scene.SceneControl.DisplayObjects();
        }
        private void navigator_DelGroupEvent(int grIndex)
        {
            var group = project.ModelData.GroupData[grIndex];
            project.DeleteMeshGroup(group.Name);

            PresentGroupDataOnTree(project.ModelData.GroupData);

            //if (arg1 is TaskPage taskPage)
            PresentCondDataOnTree(project.GeneralData, project.TaskData);
        }

        private void navigator_DelAllGroupsEvent()
        {
            try
            {
                project.ModelData.GroupData.Clear();
                project.TaskData.Clear();

                PresentGroupDataOnTree(project.ModelData.GroupData);

                //if (arg1 is TaskPage taskPage)
                PresentCondDataOnTree(project.GeneralData, project.TaskData);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void navigator_DelSetEvent(NodeType nodeType, string setName)
        {
            var objType = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);

            project.DeleteMeshSet(objType, setName);
            scene.SceneControl.DeleteVBObjects(objType.ToString());

            var ndPres = scene.CreateObjectsPresentor(project.ModelData, objType);
            scene.CreateObjectsOnScene(objType.ToString(), ndPres);
            scene.SceneControl.DisplayObjects();
        }

        private async void navigator_EditGroupEvent(int obj)
        {
            var group = project.ModelData.GroupData[obj];
            //scene.SelectedObjects = group.ObjType.ToString();

            foreach (var iobj in group)
                iobj.Color = scene.SceneControl.SelectionColor;

            var pres = scene.CreateObjectsPresentor(project.ModelData, group.ObjType);
            scene.SetObjectsSceneAttribute(pres, group.ObjType.ToString(), "цвет");

            scene.SceneControl.DisplayObjects();

            await EditGroupAsync(group);
        }
        private void navigator_ShowGroupWithNodesEvent(int obj)
        {
            var group = project.ModelData.GroupData[obj];
            foreach (var iobj in group)
            {
                var elem = (IElement)iobj;
                elem.ViewState = true;

                foreach (var node in elem.GetVertexes())
                    node.ViewState = true;

            }

            scene.SceneControl.DeleteVBObjects(ObjType.Узел.ToString());
            var ndPres = scene.CreateObjectsPresentor(project.ModelData, ObjType.Узел);
            scene.CreateObjectsOnScene(ObjType.Узел.ToString(), ndPres);

            var strObjType = group.ObjType.ToString();
            scene.SceneControl.DeleteVBObjects(strObjType);
            var objPres = scene.CreateObjectsPresentor(project.ModelData, group.ObjType);
            scene.CreateObjectsOnScene(strObjType, objPres);

            scene.SceneControl.DisplayObjects();
        }
        private void navigator_NavigatorPanelCollapseEvent()
        {
            embeddedSplitContainer.Panel1Collapsed = true;
        }

        private void navigator_DelObjectsEvent(NodeType obj)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeTypeToObjType(obj);

                project.ClearMeshCollection(objType);
                project.ModelData.ObjectData.ClearEmptySet();

                PresentObjectsDataOnTree(project.ModelData.ObjectData);
                PresentGroupDataOnTree(project.ModelData.GroupData);

                //if (arg1 is TaskPage taskPage)
                PresentCondDataOnTree(project.GeneralData, project.TaskData);

                scene.ClearAllDataOnScene();
                scene.PresentAllModelObjectsToScene(project.ModelData);
                scene.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
        private void navigator_DelAllObjectsEvent()
        {
            try
            {
                project.ClearAllData();

                PresentObjectsDataOnTree(project.ModelData.ObjectData);
                PresentGroupDataOnTree(project.ModelData.GroupData);

                //if (obj is ToolStripPage taskPage)
                PresentCondDataOnTree(project.GeneralData, project.TaskData);

                scene.ClearAllDataOnScene();
                scene.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
        private void navigator_GetObjectsInfoEvent(NodeType obj, string set)
        {
            var objType = Converters.ConvertNavigatorNodeTypeToObjType(obj);
            var setInfo = project.ModelData.ObjectData.GetSetsInfo(objType).Where(x => x.Name == set).First();


            if (navigator.TrySearchNodes(obj, out List<TreeNode> nodes))
            {
                var root = nodes.First(x => x.Text.Split(' ')[0] == set);
                var childs = navigator.CreateRealNodes(obj.ToString(), setInfo.GetObjectsInfo());
                root.Nodes.AddRange(childs);
            }
        }

        private void navigator_GetSetsInfoEvent(NodeType obj)
        {
            var objType = Converters.ConvertNavigatorNodeTypeToObjType(obj);
            var info = project.ModelData.ObjectData.GetSetsInfo(objType);


            if (navigator.TrySearchNodes(obj, out List<TreeNode> nodes))
            {
                foreach (var item in info)
                {
                    var text = $"{item.Name} {item.NumberOfObjects}";
                    var r_node = navigator.CreateRealNode(item.ObjType.ToString(), text);
                    r_node.ImageIndex = 14;
                    r_node.SelectedImageIndex = 14;
                    var v_node = navigator.CreateVirtualNode(item.ObjType.ToString());
                    r_node.Nodes.Add(v_node);
                    nodes.First().Nodes.Add(r_node);
                    navigator.SetContextMenu(r_node);
                }
            }
        }

        private void navigator_GetResultInfoEvent(string obj)
        {
            navigator.TrySearchNodes(NodeType.Результат, out List<TreeNode> nodes);
            var tn = nodes.First(x => x.Text == obj);

            var times = GetResultTimes().Select(x => x.ToString());

            var childs = navigator.CreateRealNodes(NodeType.Время.ToString(), times);
            tn.Nodes.AddRange(childs);
        }

        private void navigator_SelectCondEvent(NodeType arg1, string arg2)
        {
            try
            {
                var data = project.TaskData.First(x => x.ToString() == arg2);

                panelProvider.AllGroup = project.ModelData.GroupData.ToList();

                panelProvider._funcDBNames =
                    GetDataBase<FunctionDBData>(project.GeneralData.Functions, project.GeneralData.Path).Keys.ToList();
                panelProvider._matDBNames =
                    GetDataBase<MaterialDBData>(project.GeneralData.Materials, project.GeneralData.Path).Keys.ToList();

                panelProvider.ShowPropertiesPanel(data);

                scene.SceneControl.HideAllGeometryObjs();

                if (data.Direction != Direction.None)
                    DisplayDirection(data.StartTime, data, data.Group);

                project.ModelData.ObjectData.SetBackColor(data.Group.ObjType);
                var pres = scene.CreateObjectsPresentor(project.ModelData, data.Group.ObjType);

                scene.SetObjectsSceneAttribute(pres, data.Group.ObjType.ToString(), "цвет");

                foreach (var iobj in data.Group)
                    iobj.Color = settingsConfig.SelectGroupColor;

                pres = scene.CreateObjectsPresentor(project.ModelData, data.Group.ObjType);
                scene.SetObjectsSceneAttribute(pres, data.Group.ObjType.ToString(), "цвет");

                scene.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
 
        }

        private void navigator_SelectGeneralInfoEvent(NodeType arg1, string arg2)
        {
            // TO DO
        }

        private void navigator_SelectGroupEvent(int grIndex)
        {

            var group = project.ModelData.GroupData[grIndex];

            project.ModelData.ObjectData.SetBackColor(group.ObjType);

            var pres = scene.CreateObjectsPresentor(project.ModelData, group.ObjType);
            scene.SetObjectsSceneAttribute(pres, group.ObjType.ToString(), "цвет");

            foreach (var iobj in group)
                iobj.Color = settingsConfig.SelectGroupColor;

            //pres = scene.CreateObjectsPresentor(project.ModelData, group.ObjType);
            scene.SetObjectsSceneAttribute(pres, group.ObjType.ToString(), "цвет");

            scene.SceneControl.DisplayObjects();

            panelProvider.ShowPropertiesPanel(group);
        }

        private void navigator_SelectObjectEvent(NodeType arg1, string arg2,int arg3)
        {
            // TO DO
        }

        private void navigator_SelectSetEvent(NodeType arg1, string arg2)
        {
            var setName = arg2.Split(' ')[0]; // Деление по пробелу перед :

            var type = Converters.ConvertNavigatorNodeTypeToObjType(arg1);

            var set = project.ModelData.ObjectData.GetSetsInfo(type).FirstOrDefault(x => x.Name == arg2);

            if (set != null)
                panelProvider.ShowPropertiesPanel(set);
        }

        private void navigator_SelectTaskEvent(NodeType arg1, string arg2)
        {
            EditTSFFile(arg2);
        }

        private void navigator_SelectTimeEvent(string arg1, double arg2)
        {
            // TO DO
        }
    }
}
