using BaseModule.Console;
using BaseModule.Navigator;
using BaseModule.Results.Animation;
using BaseModule.Results.ScaleControl;
using BaseModule.SceenControls;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BaseModule.Tasks.WeldingModule;
using BazisGUI.Extensions;
using BazisGUI.Properties;
using BazisGUI.SettingsControls;
using BazisGUI.Utilities;
using ClientGUI;
using ClientLogic;
using Geometry;
using LicenseInfo;
using MathNet.Numerics.LinearAlgebra;
using Model;
using Model.GeometryObjects;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using Model.Interfaces.ObjectsCollections;
using Model.MeshObjects;
using ModelController.GmshController;
using ModelController.ModelScenePresentator;
using ModelControllerInterfaces;
using Newtonsoft.Json;
using PostProc;
using PreProc.Interfaces;
using Project;
using Project.Results;
using Project.Tasks.Functions;
using Project.Tasks;
using PropertiesCalculator.FunctionData;
using PropertiesCalculator.MaterialData;
using Scene;
using Scene.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using UserControlsEx;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Project.Interfaces.Tasks;
using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using System.Threading.Tasks;
using Model.GroupsData;
using Project.Tasks.FrameCreators;
using System.Runtime.InteropServices.ComTypes;
using System.ComponentModel.DataAnnotations;
using GmshApi;


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
            Projection = false,
            SolverPath = "?"
        };

        private Thread serverConnectionPing;


        public BaseForm(string[] args)
        {
            InitializeComponent();
            ComponentsPainter.Font = this.Font;
            ComponentsPainter.ScreenDPI = this.DeviceDpi;

            resultsMenuItem.DropDown.Closing += DropDown_Closing;

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
                    modelController = new ModelController.ModelController();
                }
                if(args.Contains("-res"))
                {
                    var resInd = Array.IndexOf(args, "-res");

                    if (args.Length - 1 - resInd < 1)
                        throw new Exception($"Отсутствуют необходимые аргументы для -res file");

                    var fullPath = Path.GetFullPath(args[resInd + 1]);

                    if(project == null)
                        throw new Exception($"Для загрузки результатов требуется сперва загрузить проект");

                    project.ResultDB = fullPath;
                }
                if (args.Contains("-cad"))
                {
                    var resInd = Array.IndexOf(args, "-cad");

                    if (args.Length - 1 - resInd < 1)
                        throw new Exception($"Отсутствуют необходимые аргументы для -cad file");

                    var fullPath = Path.GetFullPath(args[resInd + 1]);

                    if (gmshController == null)
                        gmshController = dataController.LoadGMSH();

                    gmshController.Gmsh.Clear();
                    gmshController.Gmsh.Open(fullPath);

                    var path = Path.GetDirectoryName(fullPath);
                    var name = "new_Project.bpf";

                    project = dataController.CreateNewProject(path, name);
                    modelController = new ModelController.ModelController();
                    dataController.UpdateGeometry(gmshController, project, ObjType.Точка);
                    dataController.UpdateGeometry(gmshController, project, ObjType.Кривая);
                }
                lblStatus.Text = $"{project.GeneralData.Path}\\{project.GeneralData.Name}";

                модулиMenuItem.Enabled = true;

            }


        }

        private void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
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
                var res = MessageBox.Show
                    (
                    $@"Не найдена переменная среды ""BazisServerPath""
                    Создать переменную?", "Внимание!",
                    MessageBoxButtons.YesNo
                    );

                if (res == DialogResult.Yes)
                    StartLisenceForm();
                else
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
                serverConnection?.RequestServer(moduleName + " Отдать");
            //}
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
            serverConnection?.RequestServer(module.Name + " Взять");

            if (serverConnection?.Answer == "можно")
            {
                UnBlockGeneralMenuInterface(module.Name, true);
                StartLicensing(module);
            }

            else StartLisenceForm();
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
            ToolStripPage page;
            if (moduleName == "Weld" | moduleName == "HeatTreatment")
            {
                TaskPage taskPage;
                if(moduleName == "Weld")
                    taskPage = new WeldingPage() { Dock = DockStyle.Fill, Name = moduleName};
                else
                    taskPage = new HeatTreatmentPage() { Dock = DockStyle.Fill, Name = moduleName };

                taskPage.SolverPath = settingsConfig.SolverPath;
                taskPage.SelectPhysicalDataEvent += TaskPage_SelectPhysicalDataEvent;
                taskPage.CreatePhysicalDataEvent += TaskPage_CreateTaskDataEvent;
                taskPage.DeleteAllPhysicalDataEvent += TaskPage_DeleteAllTaskDataEvent;
                taskPage.ShowGantChartEvent += TaskPage_ShowGantChartEvent;
                taskPage.AddPhysicalDataEvent += TaskPage_AddPhysicalDataEvent;
                taskPage.GenerateTSFEvent += TaskPage_GenerateTSFEvent;
                taskPage.GenerateTCFEvent += TaskPage_GenerateTCFEvent;
                taskPage.EditTSFEvent += TaskPage_EditTSFEvent;
                taskPage.StopComputationEvent += TaskPage_StopComputationEvent;
                page = taskPage;
                //return taskPage;
            }

            else if (moduleName == "Result")
            {
                resultsMenuItem.Visible = true;
                var resPage = new ResultsPage() { Dock = DockStyle.Fill, Name = moduleName};
            
                resPage.PresentResultsInfo(project.ResultDB);
                resPage.RemoveResultsEvent += (object arg) => { resPage.RemoveResults(project.ModelData); };
                resPage.HideResultsEvent += (object arg) => { resPage.HideResults(project.ModelData); };
                resPage.ShowResultsEvent += (object arg1, Result arg2, int arg3) =>
                { 
                    resPage.ShowResults(project.GeneralData, project.ModelData, arg2, arg3); 
                };

                resPage.CreateGIFAnimationEvent += (object arg1, CreateAnimationEventArgs arg2) =>
                {
                    resPage.CreateGIFAnimation(project.GeneralData, project.ModelData, arg2);
                };
                page = resPage;
            }

            else
            {
                meshMenuItem.Visible = true;
                var modelPage = new ModelPage() { Dock = DockStyle.Fill, Name = moduleName };
                page = modelPage;
            }

            page.DeleteObjectsEvent += Page_DeleteObjectsEvent;
            page.ChangeAllGroupsViewEvent += Page_ShowAllGroupsEvent;
            page.DeleteAllGroupsEvent += Page_DeleteAllGroupsEvent;
            page.DeleteGroupEvent += Page_DeleteGroupEvent;
            page.SelectObjectsEvent += Page_SelectObjectsEvent;
            page.ShowInsideObjectsEvent += Page_ShowInsideObjectsEvent;
            page.HideInsideObjectsEvent += Page_HideInsideObjectsEvent;
            page.ChangeViewModeObjectsEvent += Page_ChangeViewModeObjectsEvent;
            page.CreateSectionSurfacesFromCoordsEvent += Page_CreateSectionSurfacesFromCoordsEvent;
            page.DistancePointToPointEvent += Page_DistancePointToPointEvent;
            page.DistancePointToPlaneEvent += Page_DistancePointToPlaneEvent;
            page.CreatePathAsyncEvent += Page_CreatePathAsyncEvent;
            page.CalcSquareEvent += Page_CalcSquareEvent;
            page.CalcVolumeEvent += Page_CalcVolumeEvent;
            page.SelectNodeInPlaneEvent += Page_SelectNodeInPlaneEvent;
            page.SelectE2DInPlaneEvent += Page_SelectE2DInPlaneEvent;
            page.SelectInDirectionEvent += Page_SelectInDirectionEvent;
            page.MakeScreenShotEvent += Page_MakeScreenShotEvent;
            page.ShowMeshCountorsEvent += Page_ShowMeshCountorsEvent;
            page.ShowMeshNormalsEvent += Page_ShowMeshNormalsEvent;
            page.FindFreeNodesEvent += Page_FindFreeNodesEvent;
            page.ChangeGroupViewEvent += Page_ShowGroupEvent;
            page.ChangeSetViewStateEvent += Page_ChangeSetViewStateEvent;
            page.EditGroupEvent += Page_EditGroupEvent;
            page.SelectGroupEvent += Page_SelectGroupEvent;
            page.SetBackColorToAllObjectsEvent += Page_SetBackColorToAllObjectsEvent;
            page.HideSelectedObjectsEvent += Page_HideSelectedObjectsEvent;
            page.CreateSectionSurfacesFromNodesEvent += Page_CreateSectionSurfacesFromNodesEvent;
            page.CreatedMeshGroupEvent += Page_CreatedMeshGroupEvent;
            page.DeleteSelectedObjectsEvent += Page_DeleteSelectedObjectsEvent;
            page.ChangedGroupNameEvent += Page_ChangedGroupNameEvent;
            page.InfoGroupEvent += Page_InfoGroupEvent;
            page.ChangeAllObjsViewEvent += Page_ChangeAllObjsViewEvent;
            page.ShowGroupWithNodesEvent += Page_ShowGroupWithNodesEvent;
            page.DelAllObjectsEvent += Page_DelAllObjectsEvent;
            page.SelectSetEvent += Page_SelectSetEvent;
            page.UpdateNavigatorEvent += Page_UpdateNavigatorEvent;
            page.GetObjectsInfoEvent += Page_GetObjectsInfoEvent;
            page.GetSetsInfoEvent += Page_GetSetsInfoEvent;

            return page;
        }

        private void Page_GetSetsInfoEvent(object arg1, string arg2)
        {
            var page = arg1 as ToolStripPage;

            var objType = Converters.ConvertNavigatorNodeTypeToObjType(arg2.ToNodeType());
            var info = project.ModelData.ObjectData.GetSetsInfo(objType);

            var nodes = new List<TreeNode>();
            if (page.BasePage.NavigatorControl.TrySearchNode(arg2, nodes))
            {
                foreach (var item in info)
                {
                    var text = $"{item.Name} {item.NumberOfObjects}";
                    var r_node = page.BasePage.NavigatorControl.CreateRealNode(item.ObjType.ToString(), text);
                    r_node.ImageIndex = 14;
                    r_node.SelectedImageIndex = 14;
                    var v_node = page.BasePage.NavigatorControl.CreateVirtualNode(item.ObjType.ToString());
                    r_node.Nodes.Add(v_node);
                    nodes.First().Nodes.Add(r_node);
                    page.BasePage.NavigatorControl.SetContextMenu(r_node);
                }
            }
        }

        private void Page_GetObjectsInfoEvent(object arg1, string objsTypeStr,string setName)
        {
            //TO DO
            var page = arg1 as ToolStripPage;
           
            var objType = objsTypeStr.ToObjType();
            var setInfo = project.ModelData.ObjectData.GetSetsInfo(objType).Where(x => x.Name == setName).First();

            var nodes = new List<TreeNode>();
            if (page.BasePage.NavigatorControl.TrySearchNode(objsTypeStr, nodes))
            {
                var root = nodes.First(x => x.Text.Split(' ')[0] == setName);
                var childs = page.BasePage.NavigatorControl.CreateRealNodes(objsTypeStr, setInfo.GetObjectsInfo());
                root.Nodes.AddRange(childs);
            }
        }

        private void TaskPage_StopComputationEvent(object arg1, EventArgs arg2)
        {
            var page = arg1 as TaskPage;
            page.StopComputation();
        }

        private void TaskPage_EditTSFEvent(object arg1, string arg2)
        {
            var page = arg1 as TaskPage;
            page.EditTSFFile(arg2);
        }

        private void TaskPage_GenerateTCFEvent(object arg1, GenerateTCFEventArgs arg2)
        {
            var page = arg1 as TaskPage;
            project.Save();
            page.BasePage.ConsoleControl.PrintInfo("Проект сохранен в " + project.GeneralData.Path, Color.Black);
            page.GenerateAndSolveTCFfile(project.GeneralData, arg2.ToList());
        }

        private void TaskPage_GenerateTSFEvent(object arg1, Tasks arg2, Priority arg3)
        {
            var page = arg1 as TaskPage;
            page.GenerateTSFFiles(project,arg2,arg3);
        }

        private void TaskPage_AddPhysicalDataEvent(object obj,string dataType)
        {
            var page = obj as TaskPage;
            page.AddPhysicalData(project, dataType);
        }

        private void TaskPage_ShowGantChartEvent(object obj)
        {
            var page = obj as TaskPage;
            page.ShowGantChart(project.TaskData.Select(x => x.ToString()));
        }

        private void TaskPage_DeleteAllTaskDataEvent(object obj)
        {
            project.TaskData?.Clear();
            var page = obj as TaskPage;
            page.PresentTaskDataOnTree(project.GeneralData, project.TaskData);
        }

        private void TaskPage_CreateTaskDataEvent(object arg1, AddDataEventArgs arg2)
        {
            var page = arg1 as TaskPage;
            page.Navigator_AddData(project, arg2);
        }       

        private void Page_UpdateNavigatorEvent(object obj)
        {
            var page = obj as ToolStripPage;
            page.BasePage.PresentGeneralDataOnTree(project.GeneralData);
            page.BasePage.PresentObjectsDataOnTree(project.ModelData.ObjectData);
            page.BasePage.PresentGroupDataOnTree(project.ModelData.GroupData);

            if (obj is TaskPage taskPage)
                taskPage.PresentTaskDataOnTree(project.GeneralData, project.TaskData);         
        }

        private void TaskPage_SelectPhysicalDataEvent(object arg1, TreeNode arg2)
        {
            var page = arg1 as TaskPage;

            var info = arg2.Text;
            var data = project.TaskData.First(x => x.ToString() == info);

            page.BasePage.PanelProvider.AllGroup = project.ModelData.GroupData.ToList();

            page.BasePage.PanelProvider._funcDBNames = 
                page.GetDataBase<FunctionDBData>(project.GeneralData.Functions, project.GeneralData.Path).Keys.ToList();
            page.BasePage.PanelProvider._matDBNames =
                page.GetDataBase<MaterialDBData>(project.GeneralData.Materials, project.GeneralData.Path).Keys.ToList();

            page.BasePage.PanelProvider.ShowPropertiesPanel(data);

            var scenePage = page.BasePage.ScenePage;
            scenePage.SceneControl.HideAllGeometryObjs();

            if (data.Direction != Direction.None)
                page.DisplayDirection(data.StartTime, data, data.Group);

            project.ModelData.ObjectData.SetBackColor(data.Group.ObjType);
            var pres = scenePage.CreateObjectsPresentor(project.ModelData, data.Group.ObjType);

            scenePage.SetObjectsSceneAttribute(pres, data.Group.ObjType.ToString(), "цвет");

            foreach (var iobj in data.Group)
                iobj.Color = settingsConfig.SelectGroupColor;

            pres = scenePage.CreateObjectsPresentor(project.ModelData, data.Group.ObjType);
            scenePage.SetObjectsSceneAttribute(pres, data.Group.ObjType.ToString(), "цвет");

            scenePage.SceneControl.DisplayObjects();
        }

        private void Page_SelectSetEvent(object arg1, ObjType arg2, string arg3)
        {
            var page = arg1 as ToolStripPage;

            var set = project.ModelData.ObjectData.GetSetsInfo(arg2).FirstOrDefault(x => x.Name == arg3);

            if (set != null)
                page.BasePage.PanelProvider.ShowPropertiesPanel(set);
        }

        private void Page_DelAllObjectsEvent(object obj)
        {
            var page = obj as ToolStripPage;
            var navigator = page.BasePage.NavigatorControl;
            var scenePage = page.BasePage.ScenePage;

            project.ClearAllData();

            page.BasePage.PresentObjectsDataOnTree(project.ModelData.ObjectData);
            page.BasePage.PresentGroupDataOnTree(project.ModelData.GroupData);

            if (obj is TaskPage taskPage)
                taskPage.PresentTaskDataOnTree(project.GeneralData, project.TaskData);

            scenePage.ClearAllDataOnScene();
            scenePage.SceneControl.DisplayObjects();
        }

        private void Page_ShowGroupWithNodesEvent(object arg1, int arg2)
        {
            var page = arg1 as ToolStripPage;
            page.BasePage.ShowGroupWithNodes(project.ModelData, arg2);
        }

        private void Page_ChangeAllObjsViewEvent(object arg1, bool arg2)
        {
            var page = arg1 as ToolStripPage;
            var navigator = page.BasePage.NavigatorControl;

            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            {
                foreach (var setInfo in project.ModelData.ObjectData.GetSetsInfo(item))
                {
                    var nodeType = Converters.ConvertToNavigatorNodeType(setInfo.ObjType);

                    var imgIndex = navigator.GetObjectImageIndex(nodeType);
                    imgIndex = imgIndex == 3 ? 5 : 6;


                    var root = navigator.TreeView.Nodes["объекты"].Nodes[nodeType.ToString()];
                    var nodes = new List<TreeNode>();
                    navigator.SearchNodeRec(root, setInfo.ObjType.ToString(), nodes);
                    if (nodes.Count != 0)
                    {
                        nodes.First().ImageIndex = imgIndex;
                        nodes.First().SelectedImageIndex = imgIndex;
                    }
                }
            }
        }

        private void Page_InfoGroupEvent(object arg1, int arg2)
        {
            var page = arg1 as ToolStripPage;
            var console = page.BasePage.ConsoleControl;

            var group = project.ModelData.GroupData[arg2];
            console.PrintInfo(group.ToString(), Color.Black);
        }

        private void Page_ChangedGroupNameEvent(object arg1, string arg2, string arg3)
        {
            var page = arg1 as ToolStripPage;
            var navigator = page.BasePage.NavigatorControl;

            var gr = project.ModelData.GroupData.Find(arg2);
            if (gr != null)
            {
                gr.Name = arg3;
                page.BasePage.PresentGroupDataOnTree(project.ModelData.GroupData);
                if (arg1 is TaskPage taskPage)
                    taskPage.PresentTaskDataOnTree(project.GeneralData, project.TaskData);
            }
        }

        private void Page_DeleteSelectedObjectsEvent(object arg1, string arg2)
        {
            var page = arg1 as ToolStripPage;
            var navigator = page.BasePage.NavigatorControl;

            //var nodes = new List<TreeNode>();
            //if (navigator.TrySearchNode("объекты", nodes))
            //    foreach (TreeNode item in nodes.First().Nodes)
            //        item.Nodes.Clear();

            var selObjs = ObjectsProvider.SelectorProvider(project.ModelData.ObjectData, arg2).
      Where(x => x.Color == settingsConfig.SelectObjectColor);

            foreach (var item in selObjs)
                item.ExistState = false;

            project.ModelData.ObjectData.ClearNotExisted();
            project.ModelData.ObjectData.ClearEmpty();
            project.ModelData.GroupData.ClearNotExisted();
            project.TaskData.ClearNotExisted(project.ModelData.GroupData);

            page.BasePage.PresentObjectsDataOnTree(project.ModelData.ObjectData);
            page.BasePage.PresentGroupDataOnTree(project.ModelData.GroupData);

            if (arg1 is TaskPage taskPage)
                taskPage.PresentTaskDataOnTree(project.GeneralData, project.TaskData);

            page.BasePage.ScenePage.PresentModelObjectsOnScene(project.ModelData, arg2);
        }

        private void Page_CreatedMeshGroupEvent(object obj,string objTypeStr)
        {
            var page = obj as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;
            var consoleControl = page.BasePage.ConsoleControl;
            var navigator = page.BasePage.NavigatorControl;

            var selObjs = ObjectsProvider.SelectorProvider(project.ModelData.ObjectData, objTypeStr).
                Where(x => x.Color == settingsConfig.SelectObjectColor);

            if (selObjs.Count() > 0)
            {
                var objType = objTypeStr.ToObjType();
                var grps = project.ModelData.GroupData.FindMany(objType);

                var counter = 1;
                var name = $"{objTypeStr}_{grps.Count() + counter}";

                while (true)
                {
                    if (project.ModelData.GroupData.Find(name) != null)
                    {
                        counter++;
                        name = $"{objTypeStr}_{grps.Count() + counter}";
                    }
                    else break;
                }

                var group = project.ModelData.GroupData.Create(name, objType);

                group.AddRange(selObjs);
                project.ModelData.GroupData.Add(group);

                consoleControl.PrintInfo(string.Format("Создана новая группа {0}", group.Name), Color.Black);

                var text = $"{group.Name}";
                var nodeType = Converters.ConvertToNavigatorNodeType(objType);

                var imgIndex = navigator.GetObjectImageIndex(nodeType);

                var child = new TreeNode(text, imgIndex, imgIndex)
                {
                    Tag = "5.1",
                    Name = objType.ToString()
                };
                navigator.TreeView.Nodes["группыОбъектов"].Nodes.Add(child);
                navigator.SetContextMenu(child);
            }
        }

        private void Page_HideSelectedObjectsEvent(object obj, string objTypeStr)
        {
            var page = obj as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;

            var selObjs = ObjectsProvider.SelectorProvider(project.ModelData.ObjectData, objTypeStr).
    Where(x => x.Color == settingsConfig.SelectObjectColor);

            foreach (var selObj in selObjs)
                selObj.ViewState = false;

            scenePage.PresentModelObjectsOnScene(project.ModelData, objTypeStr);
            scenePage.SceneControl.DisplayObjects();
        }

        private void Page_SetBackColorToAllObjectsEvent(object obj)
        {
            var page = obj as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;

            foreach (ObjType type in Enum.GetValues(typeof(ObjType)))
            {
                project.ModelData.ObjectData.SetBackColor(type);
                var pres = scenePage.CreateObjectsPresentor(project.ModelData, type);
                scenePage.SetObjectsSceneAttribute(pres, type.ToString(), "цвет");
            }
                
            scenePage.SceneControl.DisplayObjects();
        }

        private void Page_SelectGroupEvent(object arg1, string arg2)
        {
            var page = arg1 as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;

            var group = project.ModelData.GroupData.Find(arg2);

            project.ModelData.ObjectData.SetBackColor(group.ObjType);
            var pres = scenePage.CreateObjectsPresentor(project.ModelData, group.ObjType);

            scenePage.SetObjectsSceneAttribute(pres, group.ObjType.ToString(), "цвет");

            foreach (var iobj in group)
                iobj.Color = settingsConfig.SelectGroupColor;

            pres = scenePage.CreateObjectsPresentor(project.ModelData, group.ObjType);
            scenePage.SetObjectsSceneAttribute(pres,group.ObjType.ToString(), "цвет");

            scenePage.SceneControl.DisplayObjects();

            page.BasePage.PanelProvider.ShowPropertiesPanel(group);
            
        }

        private async void Page_EditGroupEvent(object arg1, int arg2)
        {
            var page = arg1 as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;

            var group = project.ModelData.GroupData[arg2];
            //scenePage.SelectedObjects = group.ObjType.ToString();

            foreach (var iobj in group)
                iobj.Color = scenePage.SceneControl.SelectionColor;

            var pres = scenePage.CreateObjectsPresentor(project.ModelData, group.ObjType);
            scenePage.SetObjectsSceneAttribute(pres,group.ObjType.ToString(), "цвет");

            scenePage.SceneControl.DisplayObjects();

            await page.BasePage.EditGroupAsync(group);
        }

        private void Page_ChangeSetViewStateEvent(object arg1, ObjType arg2, string arg3, bool arg4)
        {
            var page = arg1 as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;

            foreach (var modelObject in project.ModelData.ObjectData.GetObjects(arg2, arg3))
                modelObject.ViewState = arg4;

            scenePage.SceneControl.DeleteVBObjects(arg2.ToString());
            var pres = scenePage.CreateObjectsPresentor(project.ModelData, arg2);
            scenePage.CreateObjectsOnScene(arg2.ToString(), pres);
            scenePage.SceneControl.DisplayObjects();
        }

        private void Page_ShowGroupEvent(object arg1, int arg2, bool arg3)
        {
            var page = arg1 as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;
            try
            {
                var group = project.ModelData.GroupData[arg2];

                foreach (var iobj in group)
                    iobj.ViewState = arg3;

                var vbobj = scenePage.SceneControl.FindVBObj(group.ObjType.ToString());
                if (vbobj == null)
                    throw new Exception($"Объект {group.ObjType} не загружен на сцену!");
                var viewMode = vbobj.ViewMode;

                scenePage.SceneControl.DeleteVBObjects(group.ObjType.ToString());
                var pres = scenePage.CreateObjectsPresentor(project.ModelData, group.ObjType);
                scenePage.CreateObjectsOnScene(group.ObjType.ToString(), pres);
                scenePage.SceneControl.ChangeViewModeVBObjects(group.ObjType.ToString(), viewMode);

                scenePage.SceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                page.BasePage.ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void Page_FindFreeNodesEvent(object obj)
        {
            var freeNodes = modelController.FreeNodesFinder.Find(project.ModelData.ObjectData);
            var page = obj as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;
            Invoke(new Action(() =>
            {
                page.BasePage.ConsoleControl.PrintInfo($"Найдено {freeNodes.Count()} свободных узлов", Color.Black);

                scenePage.SceneControl.DeleteAllVBObjects();

                foreach (var freeNode in freeNodes)
                    project.ModelData.ObjectData.Find(ObjType.Узел, freeNode).ViewState = true;

                var objsTypeStr = ObjType.Узел.ToString();
                scenePage.SceneControl.DeleteVBObjects(objsTypeStr);
                scenePage.CreateObjectsOnScene(objsTypeStr,
                scenePage.CreateObjectsPresentor(project.ModelData,ObjType.Узел));

                scenePage.SceneControl.DisplayObjects();
            }));
        }

        private void Page_ShowMeshNormalsEvent(object obj)
        {
            var page = obj as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;

            var surfElems = project.ModelData.ObjectData.GetAllElements().Where(x => x is ISurfaceElement);
            if (surfElems.Count() > 0)
            {
                var elemsNormals = modelController.NormalCalculator.CalcElemsNormals(surfElems.Select(x => x as ISurfaceElement));

                var linePresenter = scenePage.PresentersCreator.CreateLineObjectsPresenter(elemsNormals);

                scenePage.CreateObjectsOnScene("Normals", linePresenter);
                scenePage.SceneControl.DisplayObjects();
            }
            else
                throw new Exception("Для отображения нормалей модели не заданы объекты типа \"Элемент\"," +
                    "возможно вы пользуетесь модулем Геометрии");
        }

        private void Page_ShowMeshCountorsEvent(object obj)
        {
            try
            {
                var page = obj as ToolStripPage;
                var scenePage = page.BasePage.ScenePage;

                var surfElems = project.ModelData.ObjectData.GetAllElements().Where(x => x is ISurfaceElement).
        Select(x => (ISurfaceElement)x);
                var linesNodes = modelController.BoundaryEdgesFinder.Find(surfElems);
                var edges = modelController.BoundaryEdgesFinder.CreateBoundaryEdges(linesNodes, project.ModelData);
                var linePresenter = scenePage.PresentersCreator.CreateLineObjectsPresenter(edges);

                scenePage.CreateObjectsOnScene("Boundary", linePresenter);
                scenePage.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {

            }

        }

        private void Page_MakeScreenShotEvent(object obj)
        {
            var page = obj as ToolStripPage;
            var generalData = project.GeneralData;
            page.BasePage.CreateScreenShot(generalData.Path + "\\screenShot.bmp");
            page.BasePage.ConsoleControl.PrintInfo($"Сделан снимок экрана {generalData.Path}\\screenShot.bmp", Color.Black);
        }

        private void Page_CreateSectionSurfacesFromNodesEvent(object obj)
        {
            var page = obj as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;

            var objs = project.ModelData.ObjectData.GetObjects(ObjType.Узел);
            var selObjs = objs.Where(x => x.Color == scenePage.SceneControl.SelectionColor).ToArray();
            if (selObjs.Length < 3)
            {
                page.BasePage.ConsoleControl.PrintInfo("Ошибка, выбрано неверное количество узлов", Color.Red);
                return;
            }

            var mP0 = selObjs[0].CalcCentr();
            var mP1 = selObjs[1].CalcCentr();
            var mP2 = selObjs[2].CalcCentr();

            var p0 = new Vector3(mP0._x, mP0._y, mP0._z);
            var p1 = new Vector3(mP1._x, mP1._y, mP1._z);
            var p2 = new Vector3(mP2._x, mP2._y, mP2._z);

            var elems3D = project.ModelData.ObjectData.E3DCollection.GetObjects();

            var plane = page.CreateSectionPlane(p0, p1, p2);

            var surface = modelController.CrossSectionMaker.GetSectionSurfaces(elems3D, plane);
            var presenter = scenePage.PresentersCreator.CreateSurfaceObjectsPresenter(new List<SurfaceFigure>() { surface });
            scenePage.PresentCrossSection(presenter);
        }

        private void Page_SelectInDirectionEvent(object arg1, ObjType arg2, float angle, bool reverse)
        {
            var page = arg1 as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;

            var selObjs = project.ModelData.ObjectData.GetObjects(arg2).
    Where(x => x.Color == scenePage.SceneControl.SelectionColor).ToArray();
            if (selObjs?.Count() > 1)
            {
                if (!reverse)
                {
                    modelController.SelectionHelper.SelectNodeInDirection(project.ModelData.ObjectData,
                        angle, selObjs.Skip(1).First().Number, selObjs.First().Number, scenePage.SceneControl.SelectionColor);
                }

                else
                {
                    modelController.SelectionHelper.SelectNodeInDirection(project.ModelData.ObjectData,
                        angle, selObjs.First().Number, selObjs.Skip(1).First().Number, scenePage.SceneControl.SelectionColor);
                }

                var pres = scenePage.CreateObjectsPresentor(project.ModelData, arg2);
                scenePage.SetObjectsSceneAttribute(pres, arg2.ToString(), "цвет");

                scenePage.SceneControl.DisplayObjects();
            }
            else
                page.BasePage.ConsoleControl.PrintInfo("Выбранных объектов должно быть больше двух", Color.Red);
        }

        private void Page_SelectE2DInPlaneEvent(object obj,float angle)
        {
            var page = obj as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;

            var selObjs = project.ModelData.ObjectData.GetObjects(ObjType.Элемент2D).

    Where(x => x.Color == scenePage.SceneControl.SelectionColor).ToArray();

            if (selObjs?.Count() > 0)
            {
                var element = selObjs.Last();
                modelController.SelectionHelper.SelectE2DInPlane(project.ModelData.ObjectData,
                    angle, element.Number, scenePage.SceneControl.SelectionColor);
                var pres = scenePage.CreateObjectsPresentor(project.ModelData, ObjType.Элемент2D);
                scenePage.SetObjectsSceneAttribute(pres, ObjType.Элемент2D.ToString(), "цвет");
            }
            else page.BasePage.ConsoleControl.PrintInfo("Выберите хотя бы один элемент", Color.Red);
        }

        private void Page_SelectNodeInPlaneEvent(object obj)
        {
            var page = obj as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;

            var selObjs = project.ModelData.ObjectData.GetObjects(ObjType.Узел).

    Where(x => x.Color == scenePage.SceneControl.SelectionColor).ToArray();
            if (selObjs?.Count() > 2)
            {
                var n1 = (Node)selObjs.First();
                var n2 = (Node)selObjs.Skip(1).First();
                var n3 = (Node)selObjs.Skip(2).First();

                var plane = new Geometry.Plane(n1.Position, n2.Position, n3.Position);
                modelController.SelectionHelper.SelectNodeInPlane(project.ModelData.ObjectData,
                    plane, scenePage.SceneControl.SelectionColor);

                var pres = scenePage.CreateObjectsPresentor(project.ModelData, ObjType.Узел);
                scenePage.SetObjectsSceneAttribute(pres,ObjType.Узел.ToString(), "цвет");
            }
            else page.BasePage.ConsoleControl.PrintInfo("Не выбрано три узла", Color.Red);
        }

        private void Page_CalcVolumeEvent(object arg1, string arg2)
        {
            var page = arg1 as ToolStripPage;

            var objs = project.ModelData.ObjectData.GetObjects(arg2.ToObjType());
            var selObjs = objs.Where(x => x.Color == page.BasePage.ScenePage.SceneControl.SelectionColor);

            var vol = 0.0f;
            foreach (var obj in selObjs)
            {
                var e3DObj = (IElement3D)obj;
                vol += (float)e3DObj.CalcVolume();
            }
            page.BasePage.ConsoleControl.PrintInfo(string.Format("Объем : {0}", vol), Color.Black);
        }

        private void Page_CalcSquareEvent(object arg1, string arg2)
        {
            var page = arg1 as ToolStripPage;

            var objs = project.ModelData.ObjectData.GetObjects(arg2.ToObjType());

            var selObjs = objs.Where(x => x.Color == page.BasePage.ScenePage.SceneControl.SelectionColor);
            var square = 0.0;
            foreach (var obj in selObjs)
            {
                var sObj = (ISquare)obj;
                square += sObj.CalcSquare();
            }
            page.BasePage.ConsoleControl.PrintInfo($"Площадь : {square}", Color.Black);
        }

        private async void Page_CreatePathAsyncEvent(object obj)
        {
            var page = obj as ToolStripPage;
            await page.BasePage.CreatePathAsync(project.ModelData);
        }

        private async void Page_DistancePointToPlaneEvent(object arg1, string arg2)
        {
            var page = arg1 as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;

            var objType = arg2.ToObjType();
            var plane = page.BasePage.CreateSurfaceAsync(project.ModelData, objType);
            await plane;

            project.ModelData.ObjectData.SetBackColor(objType);

            var pres = scenePage.CreateObjectsPresentor(project.ModelData, objType);

            scenePage.SetObjectsSceneAttribute(pres, arg2.ToString(), "цвет");
            scenePage.SceneControl.DisplayObjects();

            var res = page.BasePage.SelectObjectAsync(project.ModelData, objType);
            await res;

            if (res.Result is IPoint point)
            {
                var proj = point.Position.GetPointProectionOnPlane(plane.Result);
                var line = new Segment3D(point.Position, proj);
                page.BasePage.ConsoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);
                scenePage.SceneControl.DisplayDistance(line);
                scenePage.SceneControl.DisplayObjects();
            }
        }

        private void Page_DistancePointToPointEvent(object obj,string objTypeStr)
        {
            var page = obj as ToolStripPage;
            var scenePage = page.BasePage.ScenePage;

            var objType = objTypeStr.ToObjType();
            var objs = project.ModelData.ObjectData.GetObjects(objType);
            var color = page.BasePage.ScenePage.SceneControl.SelectionColor;
            var selObjs = objs.Where(x => x.Color == color).ToList();

            if (selObjs.Count() > 1)
            {
                var nodes = selObjs.Select(x => (IPoint)x);
                var p0 = nodes.First();
                var p1 = nodes.Last();
                var line = new Segment3D(p0.Position, p1.Position);

                page.BasePage.ConsoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);

                scenePage.SceneControl.DisplayDistance(line);
                scenePage.SceneControl.DisplayObjects();
            }
            else page.BasePage.ConsoleControl.PrintInfo($"{objTypeStr} не выбраны", Color.Red);
        }

        private void Page_CreateSectionSurfacesFromCoordsEvent(object obj, CreatePlaneFromTextArgs arg)
        {
            var page = obj as ToolStripPage;

            var elems3D = project.ModelData.ObjectData.E3DCollection.GetObjects();
            var plane = page.CreateSectionPlane(arg.point1, arg.point2, arg.point3);

            var surface = modelController.CrossSectionMaker.GetSectionSurfaces(elems3D, plane);
            
            var scenePage = page.BasePage.ScenePage;

            var presenter = scenePage.PresentersCreator.CreateSurfaceObjectsPresenter(new List<SurfaceFigure>() { surface });
            scenePage.PresentCrossSection(presenter);
        }

        private void Page_ChangeViewModeObjectsEvent(object arg1, Model.Interfaces.ObjectsCollections.ViewMode arg2)
        {
            var page = arg1 as ToolStripPage;

            foreach (var item in project.ModelData.ObjectData.GetSetsInfo(ObjType.Поверхность))
                item.SetViewMode(ViewMode.LineSurface);
            foreach (var item in project.ModelData.ObjectData.GetSetsInfo(ObjType.Элемент2D))
                item.SetViewMode(ViewMode.LineSurface);
            foreach (var item in project.ModelData.ObjectData.GetSetsInfo(ObjType.Элемент3D))
                item.SetViewMode(ViewMode.LineSurface);

            var vbobjs = page.BasePage.ScenePage.SceneControl.GetVBObjs().Where(x => x.GL_ObjType == GLObjType.triangle);

            foreach (var obj in vbobjs)
                if(arg2 == ViewMode.Line)
                    obj.ViewMode = Scene.Interfaces.ObjView.Lines;
                else if(arg2 == ViewMode.LineSurface)
                    obj.ViewMode = Scene.Interfaces.ObjView.LinesSurface;
                else obj.ViewMode = Scene.Interfaces.ObjView.Surface;

            page.BasePage.ScenePage.SceneControl.DisplayObjects();
        }

        private void Page_HideInsideObjectsEvent(object obj)
        {
            var page = obj as ToolStripPage;
            var objs = project.ModelData.ObjectData.E3DCollection.GetObjects();

            page.BasePage.ScenePage.ChangeInsideSurface.HideInsideSurfaces(objs);

            var scenePage = page.BasePage.ScenePage;
            var presenter = scenePage.PresentersCreator.CreateSurfaceObjectsPresenter(objs);

            page.PresentObjectsOnScene(presenter, ObjType.Элемент3D.ToString());
            page.BasePage.ConsoleControl.PrintInfo("Скрыты внутренние объекты", Color.Black);
        }

        private void Page_ShowInsideObjectsEvent(object obj)
        {
            var page = obj as ToolStripPage;
            var objs = project.ModelData.ObjectData.E3DCollection.GetObjects();

            page.BasePage.ScenePage.ChangeInsideSurface.ShowInsideSurfaces(objs);

            var scenePage = page.BasePage.ScenePage;
            var presenter = scenePage.PresentersCreator.CreateSurfaceObjectsPresenter(objs);

            page.PresentObjectsOnScene(presenter, ObjType.Элемент3D.ToString());
            page.BasePage.ConsoleControl.PrintInfo("Показаны все объекты", Color.Black);
        }

        private void Page_SelectObjectsEvent(object arg1, Scene.Events.SelectObjectsEventArgs arg2, string arg3)
        {
            var page = arg1 as ToolStripPage;
            var objects = ObjectsProvider.SelectorProvider(project.ModelData.ObjectData, arg3);
            var selections = page.BasePage.ScenePage.SearchObjects(objects, arg2.SelectionBox, arg2.IsSorted);

            if (selections.Count > 0)
            {
                foreach (var obj in selections)
                {
                    var set = project.ModelData.ObjectData.GetSetInfo(obj.ObjType, obj.Number);
                    if (arg2.IsSelected)
                        obj.Color = settingsConfig.SelectObjectColor;//  page.BasePage.ScenePage.SceneControl.SelectionColor;
                    else
                        obj.Color = set.Color;
                }  

                page.BasePage.ScenePage.ColorObjects(project.ModelData, arg3);
            }
        }

        private void Page_DeleteGroupEvent(object arg1, int arg2)
        {
            var group = project.ModelData.GroupData[arg2];
            project.DeleteMeshGroup(group.Name);

            var page = arg1 as ToolStripPage;

            page.BasePage.PresentGroupDataOnTree(project.ModelData.GroupData);

            if (arg1 is TaskPage taskPage)
                taskPage.PresentTaskDataOnTree(project.GeneralData, project.TaskData);
        }

        private void Page_DeleteAllGroupsEvent(object arg1)
        {
            project.ModelData.GroupData.Clear();
            project.TaskData.Clear();
            
            var page = arg1 as ToolStripPage;
            page.BasePage.PresentGroupDataOnTree(project.ModelData.GroupData);

            if (arg1 is TaskPage taskPage)
                taskPage.PresentTaskDataOnTree(project.GeneralData,project.TaskData);
        }

        private void Page_ShowAllGroupsEvent(object arg1,bool arg2)
        {
            var page = arg1 as ToolStripPage;
            foreach (var group in project.ModelData.GroupData)
            {
                foreach (var iobj in group)
                {
                    iobj.ViewState = arg2;
                }
            }
            page.BasePage.ScenePage.SceneControl.DeleteAllVBObjects();
            page.BasePage.ScenePage.PresentAllModelObjectsToScene(project.ModelData);

            page.BasePage.ScenePage.SceneControl.DisplayObjects();
        }

        private void Page_DeleteObjectsEvent(object arg1, ObjType arg2, string arg3)
        {
            var page = arg1 as ToolStripPage;
            if (arg2 == ObjType.Точка | arg2 == ObjType.Узел)
                project.ClearMeshCollection(arg2);

            else
                project.DeleteMeshSet(arg2, arg3);

            project.ModelData.ObjectData.ClearEmpty();

            page.BasePage.PresentObjectsDataOnTree(project.ModelData.ObjectData);
            page.BasePage.PresentGroupDataOnTree(project.ModelData.GroupData);

            if (arg1 is TaskPage taskPage)
                taskPage.PresentTaskDataOnTree(project.GeneralData, project.TaskData);

            page.BasePage.ScenePage.ClearAllDataOnScene();
            page.BasePage.ScenePage.PresentAllModelObjectsToScene(project.ModelData);
            page.BasePage.ScenePage.SceneControl.DisplayObjects();
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
            que.Enqueue((int)(Screen.PrimaryScreen.Bounds.Width * 0.2f)); // ширина навигатора
            que.Enqueue((int)(Screen.PrimaryScreen.Bounds.Height * 0.5f)); // высота панели свойств
            que.Enqueue((int)(Screen.PrimaryScreen.Bounds.Height * 0.65f)); // высота консоли


            basePage.SetSplitters(que);

            basePage.ScenePage.TransparencyValue = (int)(255 * settingsConfig.TransparencyValue / 100.0f);
    
            basePage.ScenePage.SceneControl.BackGroundColor = settingsConfig.BackGroudColor;
            basePage.ScenePage.SceneControl.IsBlending = settingsConfig.Transparency;
            basePage.ScenePage.SceneControl.IsLighting = settingsConfig.Lighting;

            basePage.ScenePage.SceneControl.SelectionColor = Color.FromArgb(basePage.ScenePage.TransparencyValue, settingsConfig.SelectObjectColor);
            basePage.SelectionGroupColor = Color.FromArgb(basePage.ScenePage.TransparencyValue, settingsConfig.SelectGroupColor);
            //basePage.ScenePage.NodeColor = settingsConfig.NodeColor;
            //basePage.ScenePage.E2DColor = settingsConfig.Elem2DColor;
            //basePage.ScenePage.E3DColor = settingsConfig.Elem3DColor;

            basePage.ScenePage.SceneControl.Projection = settingsConfig.Projection
                ? ViewProjection.Parallel : ViewProjection.Perspective;
            basePage.ScenePage.SceneControl.UpdateProjection();

            var objs = project.ModelData.ObjectData.GetAllObjects();

            foreach (var obj in objs)
            {
                var preColor = obj.Color;
                var newColor = Color.FromArgb(basePage.ScenePage.TransparencyValue, preColor);
                obj.Color = newColor;
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
                if(ex is Newtonsoft.Json.JsonReaderException)
                    MessageBox.Show("Ошибка запроса информации о лицензии");
                else
                    MessageBox.Show(ex.Message);
            }

            form.Controls.Add(control);
            form.ShowDialog();
        }

        private void StartLisenceForm()
        {
            var form = new Form() { Name = "checkForm", Text = "Лицензирование", ShowIcon = false };
            var control = new ClientControl() { Dock = DockStyle.Fill };

            control.LicenseActionEvent += (ar1,ar2) => 
            {
                serverConnection = new ClientController(ar1, ar2);
                if (ModulePage != null)
                {

                    serverConnection.RequestServer(ModulePage.Name + " Взять");

                    if (serverConnection.Answer == "можно")
                    {
                        control.LabelAnswer = "Лицензирование проведено";
                        UnBlockGeneralMenuInterface(ModulePage.Name, true);
                        StartLicensing(ModulePage);
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

                var scenePage = ModulePage?.BasePage?.ScenePage;
                var location = scenePage == null ? new Point() :  scenePage.PointToScreen(Point.Empty);
                form.Location = location;
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
                //scenePage.NodeColor = ar;
                var pres = scenePage.CreateObjectsPresentor(project.ModelData, ObjType.Узел);
                scenePage.SetObjectsSceneAttribute(pres, ObjType.Узел.ToString(),"цвет");
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
                scenePage.PresentAllModelObjectsToScene(project.ModelData);
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
                    var preColor = obj.Color;
                    var newColor = Color.FromArgb(settingsConfig.TransparencyValue, preColor);
                    obj.Color = newColor;
                } 
                
                scenePage.ClearAllDataOnScene();
                scenePage.PresentAllModelObjectsToScene(project.ModelData);
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
            StartLisenceForm();
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
                modelController = new ModelController.ModelController();
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

                    gmshController?.Gmsh.Clear();

                    модулиMenuItem.Enabled = true;
                    modelController = new ModelController.ModelController();
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

                gmshController?.Gmsh.Clear();

                модулиMenuItem.Enabled = true;
                //modelController = new ModelController.ModelController();
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

            module?.PresentGeneralDataOnTree(project.GeneralData);
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
                    //modelController = new ModelController.ModelController();
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
            module.BasePage.ScenePage.PresentAllModelObjectsToScene(project.ModelData);
            module.BasePage.PresentObjectsDataOnTree(project.ModelData.ObjectData);
            module.BasePage.PresentGroupDataOnTree(project.ModelData.GroupData);

            (module as TaskPage)?.PresentTaskDataOnTree(project.GeneralData,project.TaskData);

            ModulePage.PresentModelOnSelectToolStrip(project.ModelData.ObjectData);
        }

        private void OnClosingForm(object sender, FormClosingEventArgs e)
        {
                gmshController?.Gmsh.finalize();
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
            module.CreateSurfaceElements(project.GeneralData,project.ModelData, ObjType.Элемент2D);
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
                    module.SetGMSHController(project.ModelData, gmshController);
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

            //module.ConfigAdvisor(WeldingKind.ARC);

            if (arcWeldingMenuItem.Checked)
                module.EmbeddedSplitContainer.Panel2Collapsed = false;
            else module.EmbeddedSplitContainer.Panel2Collapsed = true;
        }

        private void материалыMenuItem_Click(object sender, EventArgs e)
        {
            var module = (TaskPage)ModulePage;
            module.OpenMaterialsDB(project.GeneralData);
        }

        private void функцииMenuItem_Click(object sender, EventArgs e)
        {
            var module = (TaskPage)ModulePage;
            module.OpenFunctionsDB(project.GeneralData);
        }

        private void lazerWeldingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (WeldingPage)ModulePage;

            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if (currentItem.Name != item.Name)
                    item.Checked = false;

            //module.ConfigAdvisor(WeldingKind.Lazer);

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

            //module.ConfigAdvisor(WeldingKind.FrictionStearing);

            if (fsWeldingMenuItem.Checked)
                module.EmbeddedSplitContainer.Panel2Collapsed = false;
            else module.EmbeddedSplitContainer.Panel2Collapsed = true;
        }

        private void loadResultsMenuItem_Click(object sender, EventArgs e)
        {
            var fileName = dataController.OpenResults();

            project.ResultDB = fileName;

            var module = (ResultsPage)ModulePage;
            module.PresentResultsInfo(project.ResultDB);
        }

        private void showNodeValueMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;

            if (showNodeValueMenuItem.Checked)
                module.ShowNodeResultsValue = true;
            else
            {
                module.ShowNodeResultsValue = false;
                module.BasePage.ScenePage.SceneControl.HideDisplayText3D();
                module.BasePage.ScenePage.SceneControl.DisplayObjects();
            }
        }

        private void createFieldMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;

            if (createFieldMenuItem.Checked)
                module.ShowResultsField = true;
            else
            {
                module.ShowResultsField = false;
            }
        }

        private void createPlotMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;
            module.CreateGraph(project.ModelData);
        }

        private void scaleSettingsMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;
            module.ShowScalePage();
        }

        private void exportResultsMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;
            module.ShowExportResultsPage(project.ModelData,project.GeneralData);
        }

        private void heatingMenuItem_Click(object sender, EventArgs e)
        {
            var module = (HeatTreatmentPage)ModulePage;

            var currentItem = sender as ToolStripMenuItem;

            foreach (ToolStripMenuItem item in tasksMenuItem.DropDownItems)
                if(currentItem.Name != item.Name)
                    item.Checked = false;

           // module.ConfigAdvisor(ProcessType.Tempering);

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

            //module.ConfigAdvisor(ProcessType.Tempering);

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

            //module.ConfigAdvisor(ProcessType.Quenching);

            if (quenchingMenuItem.Checked)
                module.EmbeddedSplitContainer.Panel2Collapsed = false;
            else module.EmbeddedSplitContainer.Panel2Collapsed = true;
        }

        private void создать1DПо2DЭлементамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ModelPage)ModulePage;
            module.CreateSurfaceElements(project.GeneralData, project.ModelData, ObjType.Элемент1D);
        }

        private async void экспортСеткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var res = await dataController.ExportMesh(project.ModelData);

                if (res == null)
                    return;

                var console = ModulePage.BasePage.ConsoleControl;
                console.PrintInfo(res, Color.Green);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} Стек: {ex.StackTrace}", "Ошибка");
            }
        }

        private void показатьЗначенияВЭлементахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;

            if (показатьЗначенияВЭлементахToolStripMenuItem.Checked)
                module.ShowElementsResultsValue = true;
            else
            {
                module.ShowElementsResultsValue = false;
                module.BasePage.ScenePage.SceneControl.HideDisplayText3D();
                module.BasePage.ScenePage.SceneControl.DisplayObjects();
            }
        }

        private void усреднитьРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;

            if (усреднитьРезультатыToolStripMenuItem.Checked)
                module.MergeResultsValue = true;
            else
            {
                module.MergeResultsValue = false;
            }
        }

        private void показатьВремяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var module = (ResultsPage)ModulePage;

            if (module.EmbeddedSplitContainer.Panel2Collapsed == true)
                module.ShowAnimation();
        }

        private async void добавитьСеткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(project != null)
                {
                    await dataController.AppendModel(project.ModelData);

                    lblStatus.Text = $"{project.GeneralData.Path}\\{project.GeneralData.Name}";

                    gmshController?.Gmsh.Clear();

                    модулиMenuItem.Enabled = true;
                    modelController = new ModelController.ModelController();
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
    }

}
