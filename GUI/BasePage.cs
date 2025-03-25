using BaseModule.Console;
using BaseModule.Console.Events;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BaseModule.Utilities;
using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using Model.Interfaces.ObjectsCollections;
using Model.MeshObjects;
using ModelControllerInterfaces;
using Project;
using Project.Interfaces;
using Project.Interfaces.Tasks;
using Scene.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx;

namespace BazisGUI
{
    public partial class BasePage : UserControl
    {

        [Category("General")]
        [Description("Задать цвет выбора групп объектов")]
        public Color SelectionGroupColor { get; set; }

        [Category("General")]
        [Description("NavigatorControl")]
        public NavigatorControl NavigatorControl
        {
            get
            {
                return navigator;
            }
        }
        [Category("General")]
        [Description("ScenePage")]
        public ScenePage ScenePage
        {
            get
            {
                return scenePage;
            }
        }
        [Category("General")]
        [Description("ConsoleControl")]
        public ConsoleControl ConsoleControl
        {
            get
            {
                return consoleControl;
            }
        }
        [Category("General")]
        [Description("Ширина разделителей")]
        public int SplitterWidthEx { get; set; } = 5;

        [Category("General")]
        [Description("Кнопка на клавиатуре")]
        public Keys PressedKey { get; set; }

        SplittersController SplittersController;

        IGeneralData generalData;

        public void SetGeneralData( IGeneralData generalData)
        {
            this.generalData = generalData;
        }

        public IGeneralData GetGeneralData()
        {
            return generalData;
        }

        public event Action DeleteGroupEvent;
        public event Action DeleteAllGroupsEvent;
        public event Action DeleteObjectsEvent;
        public event Action DeleteSelectedObjectsEvent;
        public event Action CreatedMeshGroupEvent;
        public event Action ChangedGroupNameEvent;

        public event Action<TreeNode, SelectionType> OnValuableDataSelectedEvent;
        IModelController ModelController { get { return scenePage.GetModelController(); } }

        IModelData ModelData { get { return ModelController.ModelData; } }

        public PropertyPanelProvider panelProvider;
        public BasePage()
        {
            InitializeComponent();

            panelProvider = new PropertyPanelProvider();
            panelProvider.Out += propertiesPanelControl1.DrawTable;
            propertiesPanelControl1.ValidateValue += panelProvider.ValidationData;
            propertiesPanelControl1.OnPropertyUpdate += panelProvider.UpdateObjectValue;
            SplittersController = new SplittersController();

            panelProvider.OnUpdateNavigator += PresentProjectOnTree;
            
        }

        public Queue<int> GetSplitters()
        {
            var splitters = new Queue<int>();

            SplittersController.PassBySplittersReq(splitters, this.Controls, true);

            return splitters;
        }

        public void SetSplitters(Queue<int> splitters)
        {
            SplittersController.PassBySplittersReq(splitters, this.Controls, false);
        }

        public void SceneInitialization()
        {
            scenePage.SceneControl.Initialization();
            scenePage.ClearAllDataOnScene();
        }

        public void CreateScreenShot(string fileName)
        {
            this.BringToFront();
            var bmpPicture = new Bitmap(scenePage.Width, scenePage.Height);
            var gr = Graphics.FromImage(bmpPicture);
            var pos = scenePage.PointToScreen(Point.Empty);
            var size = new Size(scenePage.Size.Width - 5, scenePage.Size.Height - 20);
            gr.CopyFromScreen(pos, Point.Empty, size);

            bmpPicture.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        public void PresentProjectOnTree()
        {
            var genInfo = Converters.ConvertToNavigatorGeneralInfo(generalData);
            navigator.PresentGeneralInfo(genInfo);
            var modelInfo = Converters.ConvertToNavigatorModelInfo(ModelController.ModelData);
            navigator.PresentModelInfo(modelInfo);
        }       

        public async void WaitProcessAsync(Process process, Action<object, EventArgs> action)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                process.WaitForExit();
            });
            action.Invoke(process, new EventArgs());
        }

        public async Task<Plane> CreateSurfaceAsync(ObjType objType)
        {
            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    consoleControl.PrintInfo("Операция отменена", Color.Black);
                }));
            });
            var message = @"Задайте поверхность, выбрав три узла, и нажмите на клавишу ""E"" или нажмите кнопку ""ESC""";
            var actSurfaceConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var pointObjs = ModelData.ObjectData.GetObjects(objType);
                var selObjs = pointObjs.Where(x => x.Color == scenePage.SceneControl.SelectionColor).ToArray();

                if (selObjs.Length < 3)
                {
                    Invoke(new Action(() =>
                    {
                        consoleControl.PrintInfo("Выберите три узла или точки!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else if (objType != ObjType.Узел & objType != ObjType.Точка)
                {
                    Invoke(new Action(() =>
                    {
                        consoleControl.PrintInfo("Выберите или узлы или точки!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    var p0 = selObjs[0];
                    var p1 = selObjs[1];
                    var p2 = selObjs[2];

                    var plane = new Plane(p0.CalcCentr(), p1.CalcCentr(), p2.CalcCentr());
                    Invoke(new Action(() =>
                    {
                        consoleControl.PrintInfo("Задана плоскость", Color.Green);
                    }));
                    return new Tuple<bool, object>(true, plane);
                }
            });
            var surfaceAwait = AsyncMethodContainer(actSurfaceConfirm, actBreak, message);
            await surfaceAwait;
            return (Plane)surfaceAwait.Result;
        }

        public async Task<List<IPoint>> CreatePathAsync()
        {
            var nodes = new List<IPoint>();

            var message = @"Начните строить путь нажав на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";
            consoleControl.PrintInfo(message, Color.Black);

            while (true)
            {
                //var objType = Converters.ConvertToObjsType(scenePage.SelectedObjects);
                var res = SelectObjectAsync(ObjType.Узел);
                await res;

                if (res.Result is IPoint node)
                {
                    nodes.Add(node);
                    //node.SetBackColor();
                }
                else break;

                if (nodes.Count > 1)
                {
                    var line = new Segment3D(nodes[nodes.Count - 1].Position, nodes[nodes.Count - 2].Position);
                    consoleControl.PrintInfo($"Расстояние : {line.GetLength()}", Color.Black);
                    scenePage.SceneControl.DisplayDistance(line);
                    scenePage.SceneControl.DisplayObjects();
                }
            }
            return nodes;
        }

        public async Task<object> SelectObjectsAsync(ObjType objType)
        {
            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    consoleControl.PrintInfo("Операция отменена", Color.Black);
                }));
            });

            var message = $@"Выберите {objType} и нажмите на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";

            var actPointConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var objs = ModelData.ObjectData.GetObjects(objType);

                var selObjs = objs.Where(x => x.Color == scenePage.SceneControl.SelectionColor);

                if (selObjs.Count() == 0)
                {
                    Invoke(new Action(() =>
                    {
                        consoleControl.PrintInfo($"Не выбран ни один {objType}!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        consoleControl.PrintInfo($"Выбраны {selObjs.Count()} {objType}", Color.Green);
                    }));
                    return new Tuple<bool, object>(true, selObjs);
                }
            });

            var awaitResult = AsyncMethodContainer(actPointConfirm, actBreak, message);
            await awaitResult;
            return awaitResult.Result;
        }

        public async Task<object> SelectObjectAsync(ObjType objType)
        {
            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    consoleControl.PrintInfo("Операция отменена", Color.Black);
                }));
            });

            var message = $@"Выберите {objType} и нажмите на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";

            var actPointConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var objs = ModelData.ObjectData.GetObjects(objType);

                var selObjs = objs.Where(x => x.Color == scenePage.SceneControl.SelectionColor);

                if (selObjs.Count() == 0)
                {
                    Invoke(new Action(() =>
                    {
                        consoleControl.PrintInfo($"Не выбран ни один {objType}!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else if (selObjs.Count() > 1)
                {
                    Invoke(new Action(() =>
                    {
                        consoleControl.PrintInfo($"Выберите один {objType}!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    var node = selObjs.First();
                    Invoke(new Action(() =>
                    {
                        consoleControl.PrintInfo($"Выбран {objType} с номером {node.Number}", Color.Green);
                    }));
                    return new Tuple<bool, object>(true, node);
                }
            });

            var pointAwait = AsyncMethodContainer(actPointConfirm, actBreak, message);
            await pointAwait;
            return pointAwait.Result;
        }

        public async Task<object> AsyncMethodContainer(Func<Tuple<bool,object>> actConfirm, Action actBreak, string cmdMessage)
        {
            var resObject = new object();
            PressedKey = Keys.None;
            Invoke(new Action(() => 
            {
                scenePage.SceneControl.DisplayText2D(cmdMessage, Color.Black, new Point2D(10, 10));
                scenePage.SceneControl.DisplayObjects();
            }));
            await System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (PressedKey == Keys.E)
                    {
                        var resAction = actConfirm.Invoke();
                        if (resAction.Item1)
                        {
                            resObject = resAction.Item2;
                            break;
                        }
                        PressedKey = Keys.None;
                    }
                    if (PressedKey == Keys.Escape)
                    {
                        actBreak.Invoke();
                        break;
                    }
                }             
            });

            scenePage.SceneControl.HideDisplayText2D();
            scenePage.SceneControl.DisplayObjects();

            PressedKey = Keys.None;
            return resObject;
        }       

        private void BasePage_Load(object sender, EventArgs e)
        {
            var cntrs = new List<SplitContainerEx>();
            RecursiveSearchControls.AllTypedControls(this, cntrs);

            cntrs.ForEach(x => x.SplitterWidth = SplitterWidthEx);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            navigator.Invalidate();
        }

        public async void ConsoleControl_InEvent(object arg1, EventArgs arg2)
        {
            try
            { 
                if (arg2 is FindObjectEventArgs findObjectEventArgs)
                {
                    Invoke(new Action(() =>
                    {
                        var objsType = Converters.ConvertToObjsType(findObjectEventArgs.ObjsType);
                        var obj = ModelData.ObjectData.Find(objsType, (int)findObjectEventArgs.Number);

                        if (obj != null)
                        {
                            foreach (var item in ObjectsProvider.SelectorProvider(ModelData.ObjectData, scenePage.SelectedObjects))
                                item.ViewState = false;
                            obj.ViewState = true;
                            scenePage.ClearAllDataOnScene();
                            scenePage.PresentAllModelObjectsToScene();
                            scenePage.SceneControl.DisplayObjects();
                        }
                    }));
                }
                else if (arg2 is ModelFindCoincidentsNodesEventArgs coincidentNodesEventArgs)
                {
                    Invoke(new Action(() => { consoleControl.PrintInfo("Выполняется поиск совпадающих узлов сетки...", Color.Black); }));

                    ModelController.CoincidentObjectsFinder.ProgressEvent += (ar1, ar2) =>
                    {
                        Invoke(new Action(() => { consoleControl.PrintInfo(string.Format("{0:00}%", ar2 * 100), Color.Black); }));
                    };

                    var nodes = ModelData.ObjectData.NodesSet;
                    var coincidentNodes = ModelController.CoincidentObjectsFinder.Find(
                        nodes.Values.ToList(), 0.001f);

                    Invoke(new Action(() => { consoleControl.PrintInfo($"Найдено {coincidentNodes.Count()} совпадений", Color.Black); }));
                    Invoke(new Action(() =>
                    {
                        scenePage.ClearAllDataOnScene();
                        foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                            scenePage.CreateObjectsOnScene(item.ToString(), scenePage.CreateObjectsPresentor(item));
                        scenePage.SceneControl.DisplayObjects();
                    }));
                    var actConfirm = new Func<Tuple<bool, object>>(() =>
                    {
                        ModelController.ObjectsMerger.Merge(coincidentNodes, nodes);

                        Invoke(new Action(() =>       
                        {
                            var set = ModelData.ObjectData.GetSetsInfo(ObjType.Узел).First();

                            navigator.TreeView.Nodes["объекты"].Nodes[0].Nodes[0].Text = $"{set.Name} : {set.NumberOfObjects}";
                            consoleControl.PrintInfo("Узлы слиты", Color.Green);

                        }));
                        return new Tuple<bool, object>(true, new object());
                    });

                    var actBreak = new Action(() =>
                    {
                        Invoke(new Action(() =>
                        {
                            consoleControl.PrintInfo("Операция отменена", Color.Black);
                        }));
                    });
                    await AsyncMethodContainer(actConfirm, actBreak, $"Нажмите {"E"} для слияния, {"Esc"} для отмены");
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => { consoleControl.PrintInfo(ex.Message, Color.Red); }));
            }
        }

        private void navigator_DelGroupEvent(TreeNode treeNode)
        {
            var group = ModelData.GroupData[treeNode.Index];

            if (ModelData.GroupData.Remove(group))
            {
                treeNode.Remove();
                DeleteGroupEvent?.Invoke();
            }
        }

        private void navigator_DelAllGroupsEvent()
        {
            ModelData.GroupData.Clear();
            DeleteAllGroupsEvent?.Invoke();
        }

        private void navigator_DelObjectsEvent(TreeNode treeNode)
        {
            NodeType nodeType;
            Enum.TryParse(treeNode.Name, out nodeType);

            var objType = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);

            var setName = treeNode.Text.Split(':')[0].Replace(" ", "");

            if (objType == ObjType.Точка | objType == ObjType.Узел)
                ModelData.ObjectData.Clear(objType);
                
            else
                ModelData.ObjectData.Remove(objType, setName);
            
            ModelData.ObjectData.ClearEmpty();
            ModelData.GroupData.ClearNotExisted();

            var modelInfo = Converters.ConvertToNavigatorModelInfo(ModelController.ModelData);
            navigator.PresentModelInfo(modelInfo);

            scenePage.ClearAllDataOnScene();
            scenePage.PresentAllModelObjectsToScene();
            scenePage.SceneControl.DisplayObjects();

            DeleteObjectsEvent?.Invoke();
        }

        private async void navigator_EditGroupEvent(int obj)
        {
            var group = ModelData.GroupData[obj];
            scenePage.SelectedObjects = group.ObjType.ToString();

            foreach (var iobj in group)
                iobj.Color = scenePage.SceneControl.SelectionColor;

            scenePage.SetObjectsSceneAttribute(group.ObjType, "цвет");

            scenePage.SceneControl.DisplayObjects();

            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var objs = ModelData.ObjectData.GetObjects(group.ObjType);
                var selObj = objs.Where(x => x.Color == scenePage.SceneControl.SelectionColor);

                if (selObj.Count() == 0)
                {
                    Invoke(new Action(() => {
                        ConsoleControl.PrintInfo("Не выбран ни один объект!", Color.Black);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    group.Clear();
          
                    group.AddRange(selObj);
    
                    Invoke(new Action(() => {
                        consoleControl.PrintInfo("Группа изменена успешно", Color.Green);
                    }));
                    return new Tuple<bool, object>(true, new object());
                }
            });

            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    consoleControl.PrintInfo("Операция отменена", Color.Black);
                }));
            });

            var message = "Измените группу, добавив или удалив объекты, и нажмите на кнопку E или нажмите кнопку ESC";
 
            await AsyncMethodContainer(actConfirm, actBreak, message);
        }

        private void navigator_HideAllGroupsEvent()
        {
            foreach (var group in ModelData.GroupData)
            {
                foreach (var iobj in group)
                {
                    iobj.ViewState = false;
                }
            }
            scenePage.SceneControl.DeleteAllVBObjects();
            scenePage.PresentAllModelObjectsToScene();

            scenePage.SceneControl.DisplayObjects();
        }

        private void navigator_HideAllObjectsEvent()
        {
            HideAllObjects();

            scenePage.SceneControl.DisplayObjects();
        }

        private void HideAllObjects()
        {
            try
            {
                foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                {
                    foreach (var modelObject in ModelData.ObjectData.GetObjects(item))
                        modelObject.ViewState = false;
                }
                scenePage.SceneControl.DeleteAllVBObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_HideGroupEvent(int obj)
        {
            try
            {
                var group = ModelData.GroupData[obj];

                foreach (var iobj in group)
                    iobj.ViewState = false;

                var vbobj = scenePage.SceneControl.FindVBObj(group.ObjType.ToString());
                if (vbobj == null)
                    throw new Exception($"Объект {group.ObjType} не загружен на сцену!");
                var viewMode = vbobj.ViewMode;

                scenePage.SceneControl.DeleteVBObjects(group.ObjType.ToString());
                scenePage.CreateObjectsOnScene(group.ObjType.ToString(), scenePage.CreateObjectsPresentor(group.ObjType));
                scenePage.SceneControl.ChangeViewModeVBObjects(group.ObjType.ToString(), viewMode);

                scenePage.SceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_HideObjectsEvent(NodeType nodeType, string nodeText)
        {
            ChangeObjsViewState(nodeType, nodeText, false);
        }

        private void ChangeObjsViewState(NodeType nodeType, string objsText, bool objsState)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);

                var setName = objsText.Split(':')[0].Replace(" ", "");

                foreach (var modelObject in ModelData.ObjectData.GetObjects(objType, setName))
                    modelObject.ViewState = objsState;

                scenePage.SceneControl.DeleteVBObjects(objType.ToString());

                scenePage.CreateObjectsOnScene(objType.ToString(), scenePage.CreateObjectsPresentor(objType));
                scenePage.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowAllObjectsEvent()
        {
            scenePage.ShowAllObjects();
            scenePage.SceneControl.DisplayObjects();
        }

        private void navigator_ShowObjectsEvent(NodeType nodeName, string nodeText)
        {
            ChangeObjsViewState(nodeName, nodeText, true);
        }

        private void navigator_InfoGroupEvent(int obj)
        {
            var group = ModelData.GroupData[obj];
            consoleControl.PrintInfo(group.ToString(), Color.Black);
        }

        private void navigator_RenameGroup(string newName, string oldName)
        {
            var gr = ModelData.GroupData.Find(oldName);
            if (gr != null)
            {
                gr.Name = newName;

                ChangedGroupNameEvent?.Invoke();
                Thread.Sleep(100);
                //PresentProjectOnTree();
            }
        }

        private void navigator_SelectGroupEvent(string obj)
        {
            try
            {
                scenePage.SetBackColorToAllObjects();

                var group = ModelData.GroupData.Find(obj);

                foreach (var iobj in group)
                    iobj.Color = SelectionGroupColor;

                scenePage.SetObjectsSceneAttribute(group.ObjType, "цвет");

                scenePage.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowAllGroupsEvent()
        {
            foreach (var group in ModelData.GroupData)
            {
                foreach (var iobj in group)
                {
                    iobj.ViewState = true;
                }
            }

            scenePage.SceneControl.DeleteAllVBObjects();
            scenePage.PresentAllModelObjectsToScene();
            scenePage.SceneControl.DisplayObjects();
        }

        private void navigator_ShowGroupEvent(int obj)
        {
            var group = ModelData.GroupData[obj];

            foreach (var iobj in group)
                iobj.ViewState = true;

            var strObjType = group.ObjType.ToString();
            scenePage.SceneControl.DeleteVBObjects(strObjType);
            scenePage.CreateObjectsOnScene(strObjType, scenePage.CreateObjectsPresentor(group.ObjType));
            scenePage.SceneControl.DisplayObjects();
        }

        private void navigator_ChangeViewModeEventHandler(string objs, ViewRegime viewRegime)
        {
            var objType = Converters.ConvertToObjsType(objs);
            switch (viewRegime)
            {
                case ViewRegime.ribbers:
                    scenePage.SceneControl.ChangeViewModeVBObjects(objs, ObjView.Lines);
                    foreach (var item in ModelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.Line);
                    break;
                case ViewRegime.surfaces:
                    scenePage.SceneControl.ChangeViewModeVBObjects(objs, ObjView.Surface);
                    foreach (var item in ModelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.Surface);
                    break;
                case ViewRegime.ribbersSurfaces:
                    scenePage.SceneControl.ChangeViewModeVBObjects(objs, ObjView.LinesSurface);
                    foreach (var item in ModelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.LineSurface);
                    break;
                default:
                    break;
            }




            scenePage.SceneControl.DisplayObjects();
        }

        private void navigator_ShowGroupWithNodesEvent(int obj)
        {
            var group = ModelData.GroupData[obj];

            foreach (var iobj in group)
            {
                var elem = (IElement)iobj;
                elem.ViewState = true;

                foreach (var node in elem.GetVertexes())
                    node.ViewState = true;

            }          

            scenePage.SceneControl.DeleteVBObjects(ObjType.Узел.ToString());
            scenePage.CreateObjectsOnScene(ObjType.Узел.ToString(), scenePage.CreateObjectsPresentor(ObjType.Узел));

            var strObjType = group.ObjType.ToString();
            scenePage.SceneControl.DeleteVBObjects(strObjType);
            scenePage.CreateObjectsOnScene(strObjType, scenePage.CreateObjectsPresentor(group.ObjType));

            scenePage.SceneControl.DisplayObjects();
        }

        private void sceneControl_Load(object sender, EventArgs e)
        {
            SceneInitialization();
        }



        private void scenePage_SceneInfoEvent(object arg1, string arg2, Color arg3)
        {
            consoleControl.PrintInfo(arg2, arg3);
        }

        private void scenePage_ShowAllObjectsEvent(object obj)
        {
            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            {
                foreach (var setInfo in ModelData.ObjectData.GetSetsInfo(item))
                {
                    var nodeType = Converters.ConvertToNavigatorNodeType(setInfo.ObjType);

                    var imgIndex = navigator.GetObjectImageIndex(nodeType);
                    imgIndex = imgIndex == 3 ? 5 : 6;


                    var root = navigator.TreeView.Nodes["объекты"].Nodes[nodeType.ToString()];
                    var child = navigator.SearchChildNode(root, setInfo.ObjType.ToString());
                    child.ImageIndex = imgIndex;
                    child.SelectedImageIndex = imgIndex;
                }
            }
        }

        private void scenePage_SelectionDeletedEvent(object obj)
        {
            TreeNode searchNode;
            if (navigator.TrySearchNode("объекты", out searchNode))
                foreach (TreeNode item in searchNode.Nodes)
                    item.Nodes.Clear();

            DeleteSelectedObjectsEvent?.Invoke();

            var modelInfo = Converters.ConvertToNavigatorModelInfo(ModelController.ModelData);
            navigator.PresentModelInfo(modelInfo);
        }

        public virtual void scenePage_CreateMeshGroupEvent(object sender, string arg)
        {
            consoleControl.PrintInfo(string.Format("Создана новая группа {0}", arg), Color.Black);

            var text = $"{arg}";

            var objType = Converters.ConvertToObjsType(scenePage.SelectedObjects.ToString());
            var nodeType = Converters.ConvertToNavigatorNodeType(objType);

            var imgIndex = navigator.GetObjectImageIndex(nodeType);

            var child = new TreeNode(text, imgIndex, imgIndex)
            {
                Tag = "5.1",
                Name = objType.ToString()
            };
            navigator.SetContextMenu("группыОбъектов", child);
            navigator.TreeView.Nodes["группыОбъектов"].Nodes.Add(child);

            CreatedMeshGroupEvent?.Invoke();

        }

        private void navigator_NavigatorPanelCollapseEvent()
        {
            splitContainer1.Panel1Collapsed = true;
        }

        private void consoleControl_ConsolePanelCollapseEvent()
        {
            splitContainer2.Panel2Collapsed = true;
        }

        private void consoleControl_FindFreeNodesEvent()
        {
            var freeNodes = ModelController.FreeNodesFinder.Find(ModelData.ObjectData);

            Invoke(new Action(() =>
            {
                consoleControl.PrintInfo($"Найдено {freeNodes.Count()} свободных узлов", Color.Black);

                HideAllObjects();

                foreach (var freeNode in freeNodes)
                    ModelData.ObjectData.Find(ObjType.Узел, freeNode).ViewState = true;

                var objsTypeStr = ObjType.Узел.ToString();
                scenePage.SceneControl.DeleteVBObjects(objsTypeStr);
                scenePage.CreateObjectsOnScene(objsTypeStr, scenePage.CreateObjectsPresentor(ObjType.Узел));

                scenePage.SceneControl.DisplayObjects();
            }));
        }

        private void scenePage_SceneExpandEvent()
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer2.Panel2Collapsed = true;
        }

        private void scenePage_SceneFoldEvent()
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer2.Panel2Collapsed = false;
        }

        private void ConsoleControl_RenumberMeshEvent(object arg1, ModelRenumberEventArgs arg2)
        {
            ModelController.ObjectsRenumber.Renumber(ModelData.ObjectData, Converters.ConvertToObjsType(arg2.ObjsType));
        }

        private void ConsoleControl_ModelShiftCoordinateEvent(object arg1, ModelShiftCoordinateEventArgs arg2)
        {
            ModelData.ObjectData.Move(ObjType.Узел, new Point3D(arg2.X, arg2.Y, arg2.Z));

            ScenePage.SceneControl.HideAllGeometryObjs();
            ScenePage.SceneControl.HideDisplayText2D();
            ScenePage.SceneControl.HideDisplayText3D();

            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                ScenePage.SetObjectsSceneAttribute(item, "координаты");
            
            ScenePage.SceneControl.DisplayObjects();
        }

        private void ConsoleControl_ModelRotateEvent(object arg1, ModelRotateEventArgs arg2)
        {
            var axis = new Point3D(arg2.Axis.X, arg2.Axis.Y, arg2.Axis.Z);
            ModelData.ObjectData.Rotate(ObjType.Узел, axis,arg2.Angle);

            ScenePage.SceneControl.HideAllGeometryObjs();
            ScenePage.SceneControl.HideDisplayText2D();
            ScenePage.SceneControl.HideDisplayText3D();

            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                ScenePage.SetObjectsSceneAttribute(item, "координаты");

            ScenePage.SceneControl.DisplayObjects();
        }

        private void navigator_DelAllObjectsEvent()
        {
            ModelData.ObjectData.ClearAll();
            ModelData.GroupData.Clear();

            var modelInfo = Converters.ConvertToNavigatorModelInfo(ModelController.ModelData);
            navigator.PresentModelInfo(modelInfo);

            scenePage.ClearAllDataOnScene();

            scenePage.SceneControl.DisplayObjects();

            DeleteObjectsEvent?.Invoke();
        }

        private void navigator_AfterSelectEvent(TreeNode e, SelectionType select)
        {
            if(select == SelectionType.Object)
            {
                var setName = e.Text.Split(' ')[0]; // Деление по пробелу перед :
                Enum.TryParse(e.Parent.Text, out NodeType nodeType);
                var type = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);
                var sets = ModelData.ObjectData.GetSetsInfo(type);

                if (sets != null)
                {
                    var set = sets.First(x => x.Name == setName);
                    panelProvider.ShowPropertiesPanel(set, e);
                }
            }

            else if(select == SelectionType.Group)
            {
                var setName = e.Text.Split('_')[0];
                Enum.TryParse(e.Parent.Text, out NodeType nodeType);
                var groups = ModelData.GroupData.First(x => x.Name == e.Text);

                if (groups != null)
                {
                    panelProvider.ShowPropertiesPanel(groups, e);
                }
            }

            else if(select == SelectionType.ValuableData)
            {
                OnValuableDataSelectedEvent?.Invoke(e, select);
            }
        }

        //public void UpdateNavigator(ISetInfo obj, TreeNode nameNode)
        //{
        //    var secondPart = nameNode.Text.Split(' ')[1];
        //    var thirdPart = nameNode.Text.Split(' ')[2];
        //    nameNode.Name = obj.Name;
        //    nameNode.Text = obj.Name + " " + secondPart + " " + thirdPart;
        //}

        //private void UpdateNavigatorGroup(IGroup group, TreeNode nameNode)
        //{
        //    //var secondPart = nameNode.Text.Split('_')[1];
        //    nameNode.Name = group.Name;
        //    nameNode.Text = group.Name;
        //}
    }
}
