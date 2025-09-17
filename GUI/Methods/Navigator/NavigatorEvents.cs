using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using PreProc;
using PreProc.Interfaces;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_ShowObjectEvent(NodeName arg1, string arg2, int arg3)
        {

        }

     
        private void navigator_HideObjectEvent(NodeName arg1, string arg2, int arg3)
        {

        }
        private void navigator_DelObjectEvent(NodeName arg1, string arg2,int arg3)
        {

        }
        private void navigator_ShowGantChartEvent()
        {
            try
            {
                ShowGantChart(project.TaskData.Select(x => x));
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
                navigator.SelectedNode.Nodes.Clear();
                PresentCondDataOnTree();
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
                navigator.TrySearchNodes(NodeName.результаты, out List<TreeNode> nodes);
                //nodes[0].Nodes["ПоУзлам"].Nodes.Clear();
                //nodes[0].Nodes["Набор результатов"].Nodes["ПоЭлементам"].Nodes.Clear();

                ClearAllDataOnScene();

                foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                    CreateVBObject(project.CreateModelObjectsPresentor(item));

                DisplayObjects();
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
                ClearAllDataOnScene();

                CreateVBObjects("Объекты");

                FitObjectsToScreen();
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void navigator_CreateAnimationEvent(object arg1, string arg2, List<double> list)
        {
            //вызов контрола анимации результатов
            // при создании анимации в нем обработать событие методом
            // CreateGIFAnimation()
        }      

        private void navigator_GenerateTCFEvent()
        {
            try
            {
                project.Save(lblStatus.Text);
                console.PrintInfo("Проект сохранен в " + project.Path, Color.Black);

                CheckProjectDataBeforeCreationTCF();

                var compDir = $@"{project.Path}\ComputationData";

                if (!Directory.Exists(compDir))
                    Directory.CreateDirectory(compDir);

                var result = new List<string>
            {
                $@"\\загрузка сетки и данных",
                $@"загрузить проект {project.Path}\{project.Name}",
                /*
                $@"\\загрузка материалов",
                $@"загрузить материалы {project.Path}\{project.MaterialsDB}",
                $@"\\загрузка функций",
                $@"загрузить функции {project.Path}\{project.FunctionsDB}",
                */
                $@"\\расчет"
            };

                var tasks = new List<string>();
                navigator.TrySearchNodes(NodeName.расчет, out List<TreeNode> task);
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
                if (!File.Exists($@"{project.Path}\{project.Name}"))
                    throw new Exception($"В папке проекта {project.Path} отсутствует файл проекта {project.Name}. " +
                        $"Верните файл проекта в папку проекта или выберете другой проект");

                if (!File.Exists($@"{project.Path}\{project.MaterialsDB}"))
                    throw new Exception($"В папке проекта {project.Path} отсутствует файл материалов {project.MaterialsDB}. " +
                        $"Верните файл материалов в папку проекта или выберете другой файл материалов");

                if (!File.Exists($@"{project.Path}\{project.FunctionsDB}"))
                    throw new Exception($"В папке проекта {project.Path} отсутствует файл функций {project.FunctionsDB}. " +
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
                var myProcess = new Process();

                myProcess.StartInfo.FileName = $@"{settingsConfig.SolverPath}\{settingsConfig.SolverFile}";

                var compDir = $@"{project.Path}\ComputationData";
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

                var inputDir = $@"{project.Path}\InputData";

                if (!Directory.Exists(inputDir))
                    Directory.CreateDirectory(inputDir);

                var oldTSF = Directory.GetFiles(inputDir);
                if (oldTSF.Length > 0) Array.ForEach(oldTSF, x => File.Delete(x));

                var procProp = new ProcessProperty()
                {
                    TaskKind = project.ProjectKind,
                    CommonTaskType = ProcessType.Welding // убрать из препроцессора
                };

                preProc.CalcCompDataV2(data, procProp, inputDir);

                var tsfFiles = Directory.GetFiles(inputDir, "*.tsf");

                var sortedFiles = preProc.SortCompDataByTimeAndType(tsfFiles);

                PresentCompDataOnTree(sortedFiles);

                console.PrintInfo($"Входные Данные задачи сгенерированы в {inputDir}", Color.Green);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        public void navigator_HideConditionsEvent(object arg1, IModelData modelData, HideDataEventArgs arg2)
        {
            DisplayGeometryObjectEvent = null;
            DisplayText3DEvent = null;
            foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
            {
                modelData.ObjectData.SetBackColor(type);
                var pres = project.CreateModelObjectsPresentor(type);
                SetVBObjectAttribute(pres, "цвет");
            }
            DisplayObjects();
        }     

        private void navigator_ControlCollapseEvent()
        {

        }

        private void navigator_ControlUnpinnedEvent()
        {

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
                VBOController.DeleteAllVBObjects();
                CreateVBObjects("Объекты");
                DisplayObjects();
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
                foreach (var obj in project.GetAllModelObjects())
                    obj.ViewState = false;

                VBOController.DeleteAllVBObjects();
                CreateVBObjects("Объекты");
                DisplayObjects();
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
                var group = project.GetModelGroup(obj);
                ChangeGroupViewState(group,true);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }



        private void navigator_HideGroupEvent(int obj)
        {
            try
            {
                var group = project.GetModelGroup(obj);
                ChangeGroupViewState(group, false);

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

                VBOController.DeleteAllVBObjects();
                CreateVBObjects("Объекты");
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

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
                VBOController.DeleteAllVBObjects();
                CreateVBObjects("Объекты");
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }


        private void navigator_DelAllGroupsEvent()
        {
            try
            {               
                project.ModelData.GroupData.Clear();
                project.TaskData.Clear();

                PresentGroupDataOnTree();

                //if (arg1 is TaskPage taskPage)
                PresentCondDataOnTree();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

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

            VBOController.DeleteVBObjects(ObjType.Узел.ToString());
            var ndPres = project.CreateModelObjectsPresentor(ObjType.Узел);
            CreateVBObject(ndPres);

            var strObjType = group.ObjType.ToString();
            VBOController.DeleteVBObjects(strObjType);
            var objPres = project.CreateModelObjectsPresentor(group.ObjType);
            CreateVBObject(objPres);

            DisplayObjects();
        }
        private void navigator_NavigatorPanelCollapseEvent()
        {
            splitContainer1.Panel1Collapsed = true;
        }

        private void navigator_DelObjectsEvent(NodeName obj)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeNameToObjType(obj);

                project.ClearModelCollection(objType);
                project.ModelData.ObjectData.ClearEmptySet();

                PresentObjectsDataOnTree();
                PresentGroupDataOnTree();

                //if (arg1 is TaskPage taskPage)
                PresentCondDataOnTree();

                ClearAllDataOnScene();
                CreateVBObjects("Объекты");
                DisplayObjects();
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

                PresentObjectsDataOnTree();
                PresentGroupDataOnTree();

                //if (obj is ToolStripPage taskPage)
                PresentCondDataOnTree();

                ClearAllDataOnScene();
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
        private void navigator_GetObjectsInfoEvent(TreeNode node)
        {
            var nodeName = node.Name.ToEnum<NodeName>();
            var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeName);

            var setName = node.Text.Split(' ')[0];
            if (nodeName == NodeName.Объем | nodeName == NodeName.Поверхности)
            {
                var ar = node.Text.Split(' ');
                setName = string.Join(" ", ar, 0, ar.Length - 1);
            }

            var setInfo = project.GetModelSetInfo(objType, setName);

            var childs = navigator.CreateRealNodes(objType.ToString(), setInfo.GetObjectsInfo());
            node.Nodes.AddRange(childs);  
        }

        private void navigator_GetSetsInfoEvent(TreeNode node)
        {
            var nodeType = node.Name.ToEnum<NodeName>();
            var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeType);

            var sets = project.GetModelSetsInfo(objType);

            foreach (var set in sets)
            {
                var text = $"{set.Name} {set.NumberOfObjects}";
                var r_node = navigator.CreateRealNode(node.Name, text);
                r_node.ImageIndex = 14;
                r_node.SelectedImageIndex = 14;
                var v_node = navigator.CreateVirtualNode(set.ObjType.ToString());
                r_node.Nodes.Add(v_node);
                node.Nodes.Add(r_node);
                navigator.SetContextMenu(r_node);
            }
        }

        private void navigator_GetResultInfoEvent(TreeNode node)
        {
            var times = resultTimes.Select(x => x.ToString());

            var childs = navigator.CreateRealNodes(NodeName.Время.ToString(), times);
            node.Nodes.AddRange(childs);
        }

        private void navigator_SetElementsOrderEvent(int obj)
        {
            var nodeName = navigator.SelectedNode.Name.ToEnum<NodeName>();

            if (nodeName == NodeName.Элементы1D)
                project.ChangeMeshSetOrder(1, navigator.SelectedNode.Text.Split(' ')[0], obj);
            else if (nodeName == NodeName.Элементы2D)
                project.ChangeMeshSetOrder(2, navigator.SelectedNode.Text.Split(' ')[0], obj);
            else if (nodeName == NodeName.Элементы3D)
                project.ChangeMeshSetOrder(3, navigator.SelectedNode.Text.Split(' ')[0], obj);

            PresentObjectsDataOnTree();
        }
    }
}
