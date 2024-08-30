using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Geometry;
using ModelInterfaces;
using System.Diagnostics;
using BaseModule.Console;
using BaseModule.CrossSection;
using BaseModule.Console.Events;
using BaseModule.Navigator;
using ModelControllerInterfaces;
using System.Threading;
using ModelInterfaces.MeshObjects;
using ModelInterfaces.GeometryObjects;
using System.ComponentModel;
using ProjectInterfaces;
using BaseModule.Utilities;
using Scene.Interfaces;
using UserControlsEx;

namespace BaseModule
{
    public partial class BasePage : UserControl
    {
        public Action ChangeGroupNameEvent;
        public Action CreateProjectDataEvent;

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

        public IGeneralData GeneralData { get; set; }

        public event Action DeleteGroupEvent;
        public event Action DeleteAllGroupsEvent;
        public event Action DeleteObjectsEvent;
        public event Action DeleteSelectedObjectsEvent;

        public BasePage()
        {
            InitializeComponent();

            SplittersController = new SplittersController();
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
            navigator.SetProjectTitleInfo("названиеПроекта", "Название : " + GeneralData.Name);
            navigator.SetProjectTitleInfo("путь", "Путь : " + GeneralData.Path);
            navigator.SetProjectTitleInfo("сведения", "Сведения : " + GeneralData.Comments);
            navigator.SetProjectTitleInfo("вид", "Вид: " + GeneralData.TaskType);

            navigator.TreeView.BeginUpdate();

            navigator.TreeView.Nodes["объекты"].Expand();
            navigator.TreeView.Nodes["объекты"].Nodes.Clear();

            foreach (var objType in scenePage.ModelData.ObjectData.ObjsTypes)
            {
                var objs = scenePage.ModelData.ObjectData.GetObjects(objType);
                navigator.CreateChildNode("объекты", objType.ToString(), $"{objType} : {objs.Count()}", "4.1");
                navigator.ShowObjectsNode(objType.ToString());
            }

            navigator.TreeView.Nodes["группыОбъектов"].Expand();
            navigator.TreeView.Nodes["группыОбъектов"].Nodes.Clear();

            foreach (var group in scenePage.ModelData.GroupData)
            {
                navigator.CreateChildNode("группыОбъектов", group.ObjType.ToString(), group.GroupName, "5.1");
            }

            navigator.TreeView.EndUpdate();
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
                var pointObjs = scenePage.ModelData.ObjectData.GetObjects(objType);
                var selObjs = pointObjs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor).ToArray();

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
                var res = SelectObjectAsync(scenePage.SelectedObjects);
                await res;

                if (res.Result is IPoint node)
                {
                    nodes.Add(node);
                    node.SetBackColor();
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
                var objs = scenePage.ModelData.ObjectData.GetObjects(objType);

                var selObjs = objs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor);

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
            scenePage.SceneControl.SceneControlExpandEvent += () =>
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer2.Panel2Collapsed = true;
            };

            scenePage.SceneControl.SceneControlFoldEvent += () =>
            {
                splitContainer1.Panel1Collapsed = false;
                splitContainer2.Panel2Collapsed = false;
            };

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
                        var obj = scenePage.ModelData.ObjectData.Find(findObjectEventArgs.ObjsType, (int)findObjectEventArgs.Number);

                        if (obj != null)
                        {
                            foreach (var item in scenePage.ModelData.ObjectData.GetObjects(ObjType.Объект))
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

                    scenePage.ModelController.CoincidentObjectsFinder.ProgressEvent += (ar1, ar2) =>
                    {
                        Invoke(new Action(() => { consoleControl.PrintInfo(string.Format("{0:00}%", ar2 * 100), Color.Black); }));
                    };

                    var nodes = scenePage.ModelData.ObjectData.NodeCollection;
                    var coincidentNodes = scenePage.ModelController.CoincidentObjectsFinder.Find(
                        nodes.ToList(), 0.001f);

                    Invoke(new Action(() => { consoleControl.PrintInfo($"Найдено {coincidentNodes.Where(x => x.Count > 2).Count()} совпадений", Color.Black); }));
                    Invoke(new Action(() =>
                    {
                        foreach (var objType in scenePage.ModelData.ObjectData.ObjsTypes)
                            scenePage.CreateObjectsOnScene(objType.ToString(), scenePage.CreateObjectsPresentor(objType));
                        scenePage.SceneControl.DisplayObjects();
                    }));
                    var actConfirm = new Func<Tuple<bool, object>>(() =>
                    {
                        var mergedNodes = scenePage.ModelController.ObjectsMerger.Merge(coincidentNodes, nodes.ToList());

                        scenePage.ModelData.ObjectData.NodeCollection.Clear();
                        scenePage.ModelData.ObjectData.NodeCollection.AddRange(mergedNodes);

                        Invoke(new Action(() =>
                        {
                            PresentProjectOnTree();
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
    

        private void navigator_DelGroupEvent(int obj)
        {
            var group = scenePage.ModelData.GroupData[obj];
            scenePage.ModelData.GroupData.Remove(group);

            PresentProjectOnTree();

            DeleteGroupEvent?.Invoke();
        }

        private void navigator_DelAllGroupsEvent()
        {
            scenePage.ModelData.GroupData.Clear();

            PresentProjectOnTree();

            DeleteAllGroupsEvent?.Invoke();
        }

        private void navigator_DelObjectsEvent(string objs)
        {
            ObjType objType;
            Enum.TryParse(objs, out objType);
 
            scenePage.ModelData.ObjectData.Clear(objType);
            scenePage.ModelData.GroupData.ClearNotExisted();

            PresentProjectOnTree();

            scenePage.ClearAllDataOnScene();
            scenePage.PresentAllModelObjectsToScene();
            scenePage.SceneControl.DisplayObjects();

            DeleteObjectsEvent?.Invoke();
        }

        private async void navigator_EditGroupEvent(int obj)
        {
            var group = scenePage.ModelData.GroupData[obj];
            scenePage.SelectedObjects = group.ObjType;

            foreach (var iobj in group)
                iobj.MasterColor = scenePage.SceneControl.SelectionColor;

            scenePage.SetObjectsSceneColor(scenePage.SelectedObjects);

            scenePage.SceneControl.DisplayObjects();

            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var objs = scenePage.ModelData.ObjectData.GetObjects(scenePage.SelectedObjects);
                var selObj = objs.Where(x => x.MasterColor == scenePage.SceneControl.SelectionColor);

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
            foreach (var group in scenePage.ModelData.GroupData)
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
                foreach (var item in scenePage.ModelData.ObjectData.ObjsTypes)
                {
                    foreach (var modelObject in scenePage.ModelData.ObjectData.GetObjects(item))
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
                var group = scenePage.ModelData.GroupData[obj];

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

        private void navigator_HideObjectsEvent(string obj)
        {
            try
            {
                ObjType objType;
                Enum.TryParse(obj, out objType);

                foreach (var modelObject in scenePage.ModelData.ObjectData.GetObjects(objType))
                    modelObject.ViewState = false;

                scenePage.SceneControl.DeleteVBObjects(obj);

                scenePage.CreateObjectsOnScene(obj, scenePage.CreateObjectsPresentor(objType));
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

        private void navigator_ShowObjectsEvent(string obj)
        {
            try
            {
                ObjType objType;
                Enum.TryParse(obj, out objType);

                foreach (var modelObject in scenePage.ModelData.ObjectData.GetObjects(objType))
                    modelObject.ViewState = true;

                scenePage.SceneControl.DeleteVBObjects(obj);

                scenePage.CreateObjectsOnScene(obj, scenePage.CreateObjectsPresentor(objType));

                scenePage.SceneControl.DisplayObjects();

            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_InfoGroupEvent(int obj)
        {
            var group = scenePage.ModelData.GroupData[obj];
            consoleControl.PrintInfo(group.ToString(), Color.Black);
        }

        private void navigator_RenameGroup(string newName, string oldName)
        {
            var gr = scenePage.ModelData.GroupData.Find(oldName);
            if (gr != null)
            {
                gr.GroupName = newName;

                ChangeGroupNameEvent?.Invoke();
                Thread.Sleep(100);
                //PresentProjectOnTree();
            }
        }

        private void navigator_SelectGroupEvent(string obj)
        {
            try
            {
                scenePage.SetBackColorToAllObjects();

                var group = scenePage.ModelData.GroupData.Find(obj);

                foreach (var iobj in group)
                    iobj.MasterColor = SelectionGroupColor;

                scenePage.SetObjectsSceneColor(group.ObjType);

                scenePage.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                ConsoleControl.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowAllGroupsEvent()
        {
            foreach (var group in scenePage.ModelData.GroupData)
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
            var group = scenePage.ModelData.GroupData[obj];

            foreach (var iobj in group)
                iobj.ViewState = true;

            var strObjType = group.ObjType.ToString();
            scenePage.SceneControl.DeleteVBObjects(strObjType);
            scenePage.CreateObjectsOnScene(strObjType, scenePage.CreateObjectsPresentor(group.ObjType));
            scenePage.SceneControl.DisplayObjects();
        }

        private void navigator_ChangeViewModeEventHandler(string objs, ViewRegime viewRegime)
        {
  
            switch (viewRegime)
            {
                case ViewRegime.ribbers:
                    scenePage.SceneControl.ChangeViewModeVBObjects(objs, ObjView.Lines);
                    scenePage.PresentersCreator.SetView(objs, PresenterView.Line);
                    break;
                case ViewRegime.surfaces:
                    scenePage.SceneControl.ChangeViewModeVBObjects(objs, ObjView.Surface);
                    scenePage.PresentersCreator.SetView(objs, PresenterView.Surface);
                    break;
                case ViewRegime.ribbersSurfaces:
                    scenePage.SceneControl.ChangeViewModeVBObjects(objs, ObjView.LinesSurface);
                    scenePage.PresentersCreator.SetView(objs, PresenterView.LineSurface);
                    break;
                default:
                    break;
            }

            scenePage.SceneControl.DisplayObjects();
        }

        private void navigator_ShowGroupWithNodesEvent(int obj)
        {
            var group = scenePage.ModelData.GroupData[obj];

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
            foreach (var item in scenePage.ModelData.ObjectData.ObjsTypes)
                navigator.ShowObjectsNode(item.ToString());
        }

        private void scenePage_SelectionDeletedEvent(object obj)
        {
            DeleteSelectedObjectsEvent?.Invoke();
            PresentProjectOnTree();
        }

        public virtual void scenePage_CreateMeshGroupEvent(object sender, string arg)
        {
            consoleControl.PrintInfo(string.Format("Создана новая группа {0}", arg), Color.Black);

            navigator.CreateChildNode("группыОбъектов", scenePage.SelectedObjects.ToString(), arg, "5.1");

            ChangeGroupNameEvent?.Invoke();

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
            var freeNodes = scenePage.ModelController.FreeNodesFinder.Find(scenePage.ModelData.ObjectData);

            Invoke(new Action(() =>
            {
                consoleControl.PrintInfo($"Найдено {freeNodes.Count()} свободных узлов", Color.Black);

                HideAllObjects();

                foreach (var freeNode in freeNodes)
                    scenePage.ModelData.ObjectData.Find(ObjType.Узел, freeNode).ViewState = true;

                var objsTypeStr = ObjType.Узел.ToString();
                scenePage.SceneControl.DeleteVBObjects(objsTypeStr);
                scenePage.CreateObjectsOnScene(objsTypeStr, scenePage.CreateObjectsPresentor(ObjType.Узел));

                scenePage.SceneControl.DisplayObjects();
            }));
        }
    }
}
