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
                nodes[0].Remove();

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
                console.PrintInfo("Проект сохранен в " + WorkingDir, Color.Black);

                CheckProjectDataBeforeCreationTCF();

                var compDir = $@"{WorkingDir}\ComputationData";

                if (!Directory.Exists(compDir))
                    Directory.CreateDirectory(compDir);

                var result = new List<string>
            {
                $@"\\загрузка сетки и данных",
                $@"загрузить проект {lblStatus.Text}",
                /*
                $@"\\загрузка материалов",
                $@"загрузить материалы {project.Path}\{project.MaterialsDB}",
                $@"\\загрузка функций",
                $@"загрузить функции {project.Path}\{project.FunctionsDB}",
                */
                $@"\\расчет"
            };

                var tasks = new List<string>();
                navigator.TrySearchNodes(NodeName.расчеты, out List<TreeNode> task);
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
                if (!File.Exists($@"{lblStatus.Text}"))
                    throw new Exception($"В папке проекта {WorkingDir} отсутствует файл проекта {project.Name}. " +
                        $"Верните файл проекта в папку проекта или выберете другой проект");

                if (!File.Exists($@"{WorkingDir}\{project.MaterialsDB.Name}"))
                    throw new Exception($"В папке проекта {WorkingDir} отсутствует файл материалов {project.MaterialsDB}. " +
                        $"Верните файл материалов в папку проекта или выберете другой файл материалов");

                if (!File.Exists($@"{WorkingDir}\{project.FunctionsDB.Name}"))
                    throw new Exception($"В папке проекта {WorkingDir} отсутствует файл функций {project.FunctionsDB}. " +
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

                var compDir = $@"{WorkingDir}\ComputationData";
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

        private void navigator_ChangeObjectsViewStateEvent(bool state)
        {
            try
            {
                var node = navigator.SelectedNode.Name.ToEnum<NodeName>();
                var types = new List<ObjType>() ;
                if (node == NodeName.геометрия)
                {
                    types = new List<ObjType>()
                    {
                        ObjType.Точка,
                        ObjType.Кривая,
                        ObjType.Поверхность
                    };
                }

                else if (node == NodeName.сетка)
                {
                    types = new List<ObjType>()
                    {
                        ObjType.Узел,
                        ObjType.Элемент1D,
                        ObjType.Элемент2D,
                        ObjType.Элемент3D
                    };
                }

                foreach (var type in types)
                {
                    foreach (var set in project.GetModelSetsInfo(type))
                    {
                        set.SetViewState(state);
                        VBOController.DeleteVBObjects(set.Name);
                    }
                }

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

        private void navigator_InfoGroupEvent(int obj)
        {
            var group = project.GetModelGroup(obj);
            console.PrintInfo(group.ToString(), Color.Black);
        }

        private void navigator_ShowAllGroupsEvent()
        {
            try
            {
                foreach (var group in project.GetAllModelGroups())
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
            var group = project.GetModelGroup(obj);
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
        private void navigator_DelAllObjectsEvent()
        {
            try
            {
                var nodeName = navigator.SelectedNode.Name.ToEnum<NodeName>();

                // TODO Подумать над очисткой данных геометрии
                if(nodeName == NodeName.сетка)
                {
                    project.ClearAllData();

                    PresentGeoData();
                    PresentMeshData();
                    PresentGroupDataOnTree();
                    PresentCondDataOnTree();

                    ClearAllDataOnScene();
                }

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

            if (nodeName == NodeName.Объемы)
            {
                foreach (var item in project.GetModelVolumes())
                {
                    var text = $"{item.Number} {item.Name} {item.NumberOfSides}";
                    var r_node = navigator.CreateRealNode(NodeName.Объем, text);
                    //r_node.ImageIndex = 14;
                    //r_node.SelectedImageIndex = 14;
                    node.Nodes.Add(r_node);
                }
            }
            else
            {
                var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeName);

                var setName = node.Text.Split(' ')[1];
                if (nodeName == NodeName.Поверхности)
                {
                    var ar = node.Text.Split(' ');
                    setName = string.Join(" ", ar, 1, ar.Length - 2);
                }

                var setInfo = project.GetModelSetInfo(objType, setName);
                var childs = navigator.CreateRealNodes(objType.ToString(), setInfo.GetObjectsInfo());
                node.Nodes.AddRange(childs);
            }

 
        }

        private void navigator_GetSetsInfoEvent(TreeNode node)
        {
            var nodeType = node.Name.ToEnum<NodeName>();
            //var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeType);

            //var sets = project.GetModelSetsInfo(objType);

            List<ObjType> objTypes;
            if (nodeType == NodeName.сетка)
                objTypes = new List<ObjType>()
                {
                    ObjType.Узел,
                    ObjType.Элемент1D,
                    ObjType.Элемент2D,
                    ObjType.Элемент3D
                };
            else
            {
                objTypes = new List<ObjType>()
                {
                    ObjType.Точка,
                    ObjType.Кривая,
                    ObjType.Поверхность
                };
            }
            foreach (var item in objTypes)
                foreach (var set in project.GetModelSetsInfo(item))
                {
                    var nodeName = Converters.ConvertToNavigatorNodeType(set.ObjType);
                    var text = $"{nodeName} {set.Name} {set.NumberOfObjects}";
                    var r_node = navigator.CreateRealNode(nodeName, text);
                    r_node.ImageIndex = 14;
                    r_node.SelectedImageIndex = 14;
                    var v_node = navigator.CreateVirtualNode();
                    r_node.Nodes.Add(v_node);
                    node.Nodes.Add(r_node);
                    navigator.SetContextMenu(r_node);
                }
            // загрузка объемов
            if (nodeType == NodeName.геометрия)
            {
                var text = $"{NodeName.Объемы} {NodeName.Объем} {project.GetModelVolumes().Count()}";
                var r_node = navigator.CreateRealNode(NodeName.Объемы, text);

                r_node.ImageIndex = 14;
                r_node.SelectedImageIndex = 14;
                var v_node = navigator.CreateVirtualNode();
                r_node.Nodes.Add(v_node);
                node.Nodes.Add(r_node);
                navigator.SetContextMenu(r_node);
            }
                //foreach (var item in project.GetModelVolumes())
                //{
                //    var r_node = navigator.CreateRealNode(NodeName.Объем, $"{NodeName.Объем} {item.Name} {item.NumberOfSides}");
                //    r_node.ImageIndex = 14;
                //    r_node.SelectedImageIndex = 14;
                //    node.Nodes.Add(r_node);
                //}
        }

        private void navigator_GetResultInfoEvent(TreeNode node)
        {
            var times = resultTimes.Select(x => x.ToString());

            var childs = navigator.CreateRealNodes(NodeName.Время.ToString(), times);
            node.Nodes.AddRange(childs);
        }
    }
}
