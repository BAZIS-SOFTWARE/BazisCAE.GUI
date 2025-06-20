using BaseModule.Console;
using BaseModule.Console.Events;
using BaseModule.Navigator;
using BaseModule.Utilities;
using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using Geometry;
using Model;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using Model.Interfaces.ObjectsCollections;
using ModelControllerInterfaces;
using Project.Interfaces;
using Scene;
using Scene.Events;
using Scene.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        public event Action<object,int> DeleteGroupEvent;
        public event Action<object> DeleteAllGroupsEvent;
        public event Action<object,ObjType, string> DeleteSetEvent;
        public event Action<object,bool> ChangeAllGroupsViewEvent;
        public event Action<object, int, bool> ChangeGroupViewEvent;
        public event Action<object, ObjType, string> SelectSetEvent;
        public event Action<object, string> SelectGroupEvent;
        public event Action<object, SelectObjectsEventArgs> SelectObjectsEvent;
        public event Action<object> DeleteSelectedObjectsEvent;
        public event Action<object,bool> ChangeAllObjsViewStateEvent;
        public event Action<object> CreatedMeshGroupEvent;
        public event Action<object,string,string> ChangedGroupNameEvent;
        public event Action<object> FindFreeNodesEvent;
        public event Action<TreeNode> SelectPhysicalDataEvent;
        public event Action<object,ObjType,string,bool> ChangeSetViewStateEvent;
        public event Action<object, int> EditGroupEvent;
        public event Action<object> SetBackColorToAllObjectsEvent;
        public event Action<object> HideSelectedObjectsEvent;
        public event Action<object, int> InfoGroupEvent;
        public event Action<object, int> ShowGroupWithNodesEvent;
        public event Action<object> DelAllObjectsEvent;
        public event Action<object> UpdateNavigatorEvent;
        public event Action<object,string,string> GetObjectsInfoEvent;
        public event Action<object, string> GetSetsInfoEvent;
        //IModelController ModelController { get { return scenePage.GetModelController(); } }

        //IModelData ModelData { get { return ModelController.ModelData; } }

        PropertyPanelProvider panelProvider;

        public PropertyPanelProvider PanelProvider { get { return panelProvider; } }

        public BasePage()
        {
            InitializeComponent();

            panelProvider = new PropertyPanelProvider();
            panelProvider.Out += propertiesPanelControl1.DrawTable;
            propertiesPanelControl1.ValidateValue += panelProvider.ValidationData;
            propertiesPanelControl1.OnPropertyUpdate += PropertiesPanelControl1_OnPropertyUpdate; 
            SplittersController = new SplittersController();

            panelProvider.OnUpdateNavigator += PanelProvider_OnUpdateNavigator; ;
            
        }

        private void PanelProvider_OnUpdateNavigator()
        {
            UpdateNavigatorEvent?.Invoke(this);
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

        public void PresentObjectsDataOnTree(IObjectsData objectsData)
        {
            navigator.TreeView.BeginUpdate();
            foreach (TreeNode item in navigator.TreeView.Nodes["объекты"].Nodes)
                item.Nodes.Clear();

            foreach (ObjType objType in Enum.GetValues(typeof(ObjType)))
                foreach (var item in objectsData.GetSetsInfo(objType))
                {
                    if (item.NumberOfObjects > 0)
                    {
                        var root = Converters.ConvertToNavigatorNodeType(item.ObjType);
                        navigator.TryCreateNode(root.ToString(), item.Name, $"{item.Name} {item.NumberOfObjects}", NodeKind.virt);
                    }
                }
            navigator.TreeView.EndUpdate();
        }

        public void PresentGroupDataOnTree(IGroupData groupData)
        {
            navigator.TreeView.BeginUpdate();
            var root = navigator.TreeView.Nodes["группыОбъектов"];

            root.Nodes.Clear();

            foreach (var item in groupData)
            {
                var r = navigator.CreateRealNode(item.ObjType.ToString(), $"{item.Name} {item.Count}");
                root.Nodes.Add(r);
            }
                
            navigator.TreeView.EndUpdate();
        }

        public void PresentGeneralDataOnTree(IGeneralData generalData)
        {
            var nodes = new List<TreeNode>();
            navigator.TrySearchNode(NodeType.названиеПроекта.ToString(), nodes);
            nodes.First().Text = "Название : " + generalData.Name;
            nodes.Clear();
            navigator.TrySearchNode(NodeType.путь.ToString(), nodes);
            nodes.First().Text = "Путь : " + generalData.Path;
            nodes.Clear();
            navigator.TrySearchNode(NodeType.путь.ToString(), nodes);
            nodes.First().Text = "Сведения : " + generalData.Comments;
            nodes.Clear();
            navigator.TrySearchNode(NodeType.вид.ToString(), nodes);
            nodes.First().Text = "Вид : " + generalData.TaskType;
            nodes.Clear();
        }

        public async void WaitProcessAsync(Process process, Action<object, EventArgs> action)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                process.WaitForExit();
            });
            action.Invoke(process, new EventArgs());
        }

        public async Task<Plane> CreateSurfaceAsync(IModelData modelData, ObjType objType)
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
                var pointObjs = modelData.ObjectData.GetObjects(objType);
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

        public async Task<List<IPoint>> CreatePathAsync(IModelData modelData)
        {
            var nodes = new List<IPoint>();

            var message = @"Начните строить путь нажав на клавишу ""E"" для подтверждения или клавишу ""ESC"" для отмены";
            consoleControl.PrintInfo(message, Color.Black);

            while (true)
            {
                //var objType = Converters.ConvertToObjsType(scenePage.SelectedObjects);
                var res = SelectObjectAsync(modelData,ObjType.Узел);
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

        public async Task<object> SelectObjectsAsync(IModelData modelData, ObjType objType)
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
                var objs = modelData.ObjectData.GetObjects(objType);

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

        public async Task<object> SelectObjectAsync(IModelData modelData, ObjType objType)
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
                var objs = modelData.ObjectData.GetObjects(objType);

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
            //try
            //{ 
            //    if (arg2 is FindObjectEventArgs findObjectEventArgs)
            //    {
            //        Invoke(new Action(() =>
            //        {
            //            var objsType = Converters.ConvertToObjsType(findObjectEventArgs.ObjsType);
            //            var obj = ModelData.ObjectData.Find(objsType, (int)findObjectEventArgs.Number);

            //            if (obj != null)
            //            {
            //                foreach (var item in ObjectsProvider.SelectorProvider(ModelData.ObjectData, scenePage.SelectedObjects))
            //                    item.ViewState = false;
            //                obj.ViewState = true;
            //                scenePage.ClearAllDataOnScene();
            //                //scenePage.PresentAllModelObjectsToScene();
            //                scenePage.SceneControl.DisplayObjects();
            //            }
            //        }));
            //    }
            //    else if (arg2 is ModelFindCoincidentsNodesEventArgs coincidentNodesEventArgs)
            //    {
            //        Invoke(new Action(() => { consoleControl.PrintInfo("Выполняется поиск совпадающих узлов сетки...", Color.Black); }));

            //        ModelController.CoincidentObjectsFinder.ProgressEvent += (ar1, ar2) =>
            //        {
            //            Invoke(new Action(() => { consoleControl.PrintInfo(string.Format("{0:00}%", ar2 * 100), Color.Black); }));
            //        };

            //        var nodes = ModelData.ObjectData.NodesSet;
            //        var coincidentNodes = ModelController.CoincidentObjectsFinder.Find(
            //            nodes.Values.ToList(), 0.001f);

            //        Invoke(new Action(() => { consoleControl.PrintInfo($"Найдено {coincidentNodes.Count()} совпадений", Color.Black); }));
            //        Invoke(new Action(() =>
            //        {
            //            scenePage.ClearAllDataOnScene();
            //            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            //                scenePage.CreateObjectsOnScene(item.ToString(), scenePage.CreateObjectsPresentor(item));
            //            scenePage.SceneControl.DisplayObjects();
            //        }));
            //        var actConfirm = new Func<Tuple<bool, object>>(() =>
            //        {
            //            ModelController.ObjectsMerger.Merge(coincidentNodes, nodes);

            //            Invoke(new Action(() =>       
            //            {
            //                var set = ModelData.ObjectData.GetSetsInfo(ObjType.Узел).First();

            //                navigator.TreeView.Nodes["объекты"].Nodes[0].Nodes[0].Text = $"{set.Name} : {set.NumberOfObjects}";
            //                consoleControl.PrintInfo("Узлы слиты", Color.Green);

            //            }));
            //            return new Tuple<bool, object>(true, new object());
            //        });

            //        var actBreak = new Action(() =>
            //        {
            //            Invoke(new Action(() =>
            //            {
            //                consoleControl.PrintInfo("Операция отменена", Color.Black);
            //            }));
            //        });
            //        await AsyncMethodContainer(actConfirm, actBreak, $"Нажмите {"E"} для слияния, {"Esc"} для отмены");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Invoke(new Action(() => { consoleControl.PrintInfo(ex.Message, Color.Red); }));
            //}
        }

        private void navigator_DelGroupEvent(int grIndex)
        {
            DeleteGroupEvent?.Invoke(this, grIndex);
        }

        private void navigator_DelAllGroupsEvent()
        {           
            DeleteAllGroupsEvent?.Invoke(this);
        }

        private void navigator_DelSetEvent(NodeType nodeType, string setName)
        {
            var objType = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);         
            DeleteSetEvent?.Invoke(this,objType, setName);
        }

        private void navigator_EditGroupEvent(int obj)
        {
            EditGroupEvent?.Invoke(this, obj);
        }

        public async Task EditGroupAsync(IGroup group)
        {
            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var selObj = group.Where(x => x.Color == scenePage.SceneControl.SelectionColor);

                if (selObj.Count() == 0)
                {
                    Invoke(new Action(() =>
                    {
                        ConsoleControl.PrintInfo("Не выбран ни один объект!", Color.Black);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    group.Clear();

                    group.AddRange(selObj);

                    Invoke(new Action(() =>
                    {
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
            ChangeAllGroupsViewEvent?.Invoke(this,false);
        }

        private void navigator_HideAllObjectsEvent()
        {
            ChangeAllObjsViewStateEvent?.Invoke(this,false);
        }

        private void navigator_ShowGroupEvent(int obj)
        {
            ChangeGroupViewEvent?.Invoke(this, obj, true);
        }

        private void navigator_HideGroupEvent(int obj)
        {
            ChangeGroupViewEvent?.Invoke(this, obj, false);
        }

        private void navigator_HideSetEvent(NodeType nodeType, string setName)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);
                ChangeSetViewStateEvent?.Invoke(this, objType, setName, false);

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowAllObjectsEvent()
        {
            ChangeAllObjsViewStateEvent?.Invoke(this, true);
        }

        private void navigator_ShowSetEvent(NodeType nodeType, string setName)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);
                ChangeSetViewStateEvent?.Invoke(this, objType, setName, true);

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_InfoGroupEvent(int obj)
        {
            InfoGroupEvent?.Invoke(this, obj);
        }

        private void navigator_RenameGroup(string newName, string oldName)
        {
            ChangedGroupNameEvent?.Invoke(this, oldName, newName);
        }

        private void navigator_SelectGroupEvent(string obj)
        {
            try
            {
                SelectGroupEvent?.Invoke(this, obj);

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowAllGroupsEvent()
        {
            ChangeAllGroupsViewEvent?.Invoke(this, true);
        }

        private void navigator_ChangeSetViewEventHandler(string objs, ViewRegime viewRegime)
        {
            
        }

        public void ChangeViewMode(IModelData modelData, ObjType objType, ViewRegime viewRegime)
        {
            switch (viewRegime)
            {
                case ViewRegime.ribbers:
                    scenePage.SceneControl.ChangeViewModeVBObjects(objType.ToString(), ObjView.Lines);
                    foreach (var item in modelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.Line);
                    break;
                case ViewRegime.surfaces:
                    scenePage.SceneControl.ChangeViewModeVBObjects(objType.ToString(), ObjView.Surface);
                    foreach (var item in modelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.Surface);
                    break;
                case ViewRegime.ribbersSurfaces:
                    scenePage.SceneControl.ChangeViewModeVBObjects(objType.ToString(), ObjView.LinesSurface);
                    foreach (var item in modelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.LineSurface);
                    break;
                default:
                    break;
            }
            scenePage.SceneControl.DisplayObjects();
        }

        private void navigator_ShowGroupWithNodesEvent(int obj)
        {
            ShowGroupWithNodesEvent?.Invoke(this, obj);      
        }

        public void ShowGroupWithNodes(IModelData modelData, int groupInd)
        {
            var group = modelData.GroupData[groupInd];
            foreach (var iobj in group)
            {
                var elem = (IElement)iobj;
                elem.ViewState = true;

                foreach (var node in elem.GetVertexes())
                    node.ViewState = true;

            }

            scenePage.SceneControl.DeleteVBObjects(ObjType.Узел.ToString());
            var ndPres = scenePage.CreateObjectsPresentor(modelData, ObjType.Узел);
            scenePage.CreateObjectsOnScene(ObjType.Узел.ToString(), ndPres);

            var strObjType = group.ObjType.ToString();
            scenePage.SceneControl.DeleteVBObjects(strObjType);
            var objPres = scenePage.CreateObjectsPresentor(modelData, group.ObjType);
            scenePage.CreateObjectsOnScene(strObjType, objPres);

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
            ChangeAllObjsViewStateEvent?.Invoke(this, true);
        }

        private void scenePage_SelectionDeletedEvent(object obj)
        {
            DeleteSelectedObjectsEvent?.Invoke(this);
        }

        public virtual void scenePage_CreateMeshGroupEvent(object sender)
        {
            CreatedMeshGroupEvent?.Invoke(this);
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
            FindFreeNodesEvent?.Invoke(this);
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
            //ModelController.ObjectsRenumber.Renumber(ModelData.ObjectData, Converters.ConvertToObjsType(arg2.ObjsType));
        }

        private void ConsoleControl_ModelShiftCoordinateEvent(object arg1, ModelShiftCoordinateEventArgs arg2)
        {
            //ModelData.ObjectData.Move(ObjType.Узел, new Point3D(arg2.X, arg2.Y, arg2.Z));

            //ScenePage.SceneControl.HideAllGeometryObjs();
            //ScenePage.SceneControl.HideDisplayText2D();
            //ScenePage.SceneControl.HideDisplayText3D();

            //foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            //    ScenePage.SetObjectsSceneAttribute(item, "координаты");
            
            //ScenePage.SceneControl.DisplayObjects();
        }

        private void ConsoleControl_ModelRotateEvent(object arg1, ModelRotateEventArgs arg2)
        {
            //var axis = new Point3D(arg2.Axis.X, arg2.Axis.Y, arg2.Axis.Z);
            //ModelData.ObjectData.Rotate(ObjType.Узел, axis,arg2.Angle);

            //ScenePage.SceneControl.HideAllGeometryObjs();
            //ScenePage.SceneControl.HideDisplayText2D();
            //ScenePage.SceneControl.HideDisplayText3D();

            //foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            //    ScenePage.SetObjectsSceneAttribute(item, "координаты");

            //ScenePage.SceneControl.DisplayObjects();
        }

        private void navigator_DelAllObjectsEvent()
        {
            DelAllObjectsEvent?.Invoke(this);
        }

        private void navigator_AfterSelectEvent(TreeNode node, SelectionType select)
        {
            if (select == SelectionType.Object)
            {
                var setName = node.Text.Split(' ')[0]; // Деление по пробелу перед :
                Enum.TryParse(node.Parent.Text, out NodeType nodeType);
                var type = Converters.ConvertNavigatorNodeTypeToObjType(nodeType);
                SelectSetEvent?.Invoke(this, type, setName);
            }

            else if (select == SelectionType.Group)
            {
                var grName = node.Text.Split(' ')[0];
                SelectGroupEvent?.Invoke(this, grName);
            }

            else if (select == SelectionType.PhysicalData)
            {
                SelectPhysicalDataEvent?.Invoke(node);
            }
        }
        private void PropertiesPanelControl1_OnPropertyUpdate(BaseModule.PropertiesPanel.PropertyChangedEventArgs obj)
        {
            panelProvider.UpdateObjectValue(obj.Header, obj.NewValue.ToString(), obj.OldValue.ToString());
        }

        private void scenePage_SetBackColorToAllObjectsEvent(object obj)
        {
            SetBackColorToAllObjectsEvent?.Invoke(this);
        }

        private void scenePage_HideSelectedObjects(object obj)
        {
            HideSelectedObjectsEvent?.Invoke(this);
        }

        private void scenePage_SelectObjectsEvent(object arg1, SelectObjectsEventArgs arg2)
        {
            SelectObjectsEvent?.Invoke(this, arg2);
        }

        private void navigator_GetObjectsInfoEvent(string obj,string set)
        {
            GetObjectsInfoEvent?.Invoke(this, obj,set);
        }

        private void navigator_GetSetsInfoEvent(string obj)
        {
            GetSetsInfoEvent?.Invoke(this, obj);
        }
    }
}
