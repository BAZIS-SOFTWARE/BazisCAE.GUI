using BaseModule.Console;
using BaseModule.Console.Events;
using BaseModule.Navigator;
using BaseModule.SceenControls;
using BaseModule.Utilities;
using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.MeshObjects;
using Model.Interfaces.ObjectsCollections;
using Project.Interfaces;
using Scene.Events;
using Scene.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx;

namespace BazisGUI
{
    public partial class BaseForm
    {
        [Category("General")]
        [Description("Задать цвет выбора групп объектов")]
        public Color SelectionGroupColor { get; set; }

        [Category("General")]
        [Description("Кнопка на клавиатуре")]
        public Keys PressedKey { get; set; }

        public event Action<object, bool> ChangeAllObjsViewStateEvent;
        public event Action<object, ObjType, string> DeleteSetEvent;
        public event Action<object> FindFreeNodesEvent;

        public event Action<object, string, string> ChangedGroupNameEvent;
        public event Action<object, string> CreatedMeshGroupEvent;
        public event Action<object> DeleteAllGroupsEvent;
        public event Action<object, int> DeleteGroupEvent;
        public event Action<object, ObjType, string> DeleteObjectsEvent;
        public event Action<object, SelectObjectsEventArgs, string> SelectObjectsEvent;
        public event Action<object, bool> ChangeAllGroupsViewEvent;
        public event Action<object, bool> ChangeAllObjsViewEvent;
        public event Action<object> ShowInsideObjectsEvent;
        public event Action<object> HideInsideObjectsEvent;
        public event Action<object, ViewMode> ChangeViewModeObjectsEvent;
        public event Action<object, CreatePlaneFromTextArgs> CreateSectionSurfacesFromCoordsEvent;
        public event Action<object> CreateSectionSurfacesFromNodesEvent;
        public event Action<object, string> DistancePointToPointEvent;
        public event Action<object, string> DistancePointToPlaneEvent;
        public event Action<object> CreatePathAsyncEvent;
        public event Action<object, string> CalcSquareEvent;
        public event Action<object, string> CalcVolumeEvent;
        public event Action<object> SelectNodeInPlaneEvent;
        public event Action<object> MakeScreenShotEvent;
        public event Action<object> ShowMeshCountorsEvent;
        public event Action<object> ShowMeshNormalsEvent;
        public event Action<object, float> SelectE2DInPlaneEvent;
        public event Action<object, ObjType, float, bool> SelectInDirectionEvent;

        public event Action<object, int, bool> ChangeGroupViewEvent;
        public event Action<object, ObjType, string, bool> ChangeSetViewStateEvent;
        public event Action<object, int> EditGroupEvent;
        public event Action<object, string> DeleteSelectedObjectsEvent;
        public event Action<object, string> SelectGroupEvent;
        public event Action<object> SetBackColorToAllObjectsEvent;
        public event Action<object, string> HideSelectedObjectsEvent;
        public event Action<object, int> InfoGroupEvent;
        public event Action<object, int> ShowGroupWithNodesEvent;
        public event Action<object> DelAllObjectsEvent;
        public event Action<object, ObjType, string> SelectSetEvent;
        public event Action<object> UpdateNavigatorEvent;
        public event Action<object, NodeType, string> GetObjectsInfoEvent;
        public event Action<object, NodeType> GetSetsInfoEvent;
        public event Action<object, string> GetResultsInfoEvent;


        SplittersController SplittersController;

        public string SelectedObjects
        {
            get { return spbSelectObject.ToolTipText; }
            set { spbSelectObject.ToolTipText = value; }
        }

        public void PresentModelOnSelectToolStrip(IObjectsData objectsData)
        {
            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
                AddObjectsType(item.ToString());

            AddObjectsType("Объекты");
            AddObjectsType("Фигуры");
            AddObjectsType("Элементы");

            spbSelectObject.ToolTipText = "Объекты";
        }

        public void AddObjectsType(string objsType)
        {
            if (!spbSelectObject.DropDownItems.ContainsKey(objsType))
            {
                var newItem = new ToolStripMenuItem(objsType) { Name = objsType };
                spbSelectObject.DropDownItems.Add(newItem);
            }

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
            scene.SceneControl.Initialization();
            scene.ClearAllDataOnScene();
        }

  

        public void PresentGroupDataOnTree(IGroupData groupData)
        {
            navigator.BeginUpdate();

            navigator.TrySearchNodes("группыОбъектов", out List<TreeNode> nodes);

            nodes[0].Nodes.Clear();

            foreach (var item in groupData)
            {
                var r = navigator.CreateRealNode(item.ObjType.ToString(), $"{item.Name} {item.Count}");

                nodes[0].Nodes.Add(r);
                navigator.SetContextMenu(r);
            }

            navigator.EndUpdate();
        }

        public void PresentGeneralDataOnTree(IGeneralData generalData)
        {
            //var nodes = new List<TreeNode>();

            navigator.TrySearchNodes(NodeType.названиеПроекта, out List<TreeNode> name);
            name.First().Text = "Название : " + generalData.Name;

            navigator.TrySearchNodes(NodeType.путь, out List<TreeNode> path);
            path.First().Text = "Путь : " + generalData.Path;

            navigator.TrySearchNodes(NodeType.сведения, out List<TreeNode> notes);
            notes.First().Text = "Сведения : " + generalData.Comments;

            navigator.TrySearchNodes(NodeType.вид, out List<TreeNode> kind);
            kind.First().Text = $"Вид : {generalData.TaskType}";

            navigator.TrySearchNodes(NodeType.тип, out List<TreeNode> type);
            type.First().Text = $"Тип : {generalData.TaskKind}";

        }

        public async void WaitProcessAsync(Process process, Action<object, EventArgs> action)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                process.WaitForExit();
            });
            action.Invoke(process, new EventArgs());
        }

        public async Task<Geometry.Plane> CreateSurfaceAsync(IModelData modelData, ObjType objType)
        {
            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    console.PrintInfo("Операция отменена", Color.Black);
                }));
            });
            var message = @"Задайте поверхность, выбрав три узла, и нажмите на клавишу ""E"" или нажмите кнопку ""ESC""";
            var actSurfaceConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var pointObjs = modelData.ObjectData.GetObjects(objType);
                var selObjs = pointObjs.Where(x => x.Color == scene.SceneControl.SelectionColor).ToArray();

                if (selObjs.Length < 3)
                {
                    Invoke(new Action(() =>
                    {
                        console.PrintInfo("Выберите три узла или точки!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else if (objType != ObjType.Узел & objType != ObjType.Точка)
                {
                    Invoke(new Action(() =>
                    {
                        console.PrintInfo("Выберите или узлы или точки!", Color.Orange);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    var p0 = selObjs[0];
                    var p1 = selObjs[1];
                    var p2 = selObjs[2];

                    var plane = new Geometry.Plane(p0.CalcCentr(), p1.CalcCentr(), p2.CalcCentr());
                    Invoke(new Action(() =>
                    {
                        console.PrintInfo("Задана плоскость", Color.Green);
                    }));
                    return new Tuple<bool, object>(true, plane);
                }
            });
            var surfaceAwait = AsyncMethodContainer(actSurfaceConfirm, actBreak, message);
            await surfaceAwait;
            return (Geometry.Plane)surfaceAwait.Result;
        }        

        public async Task<object> AsyncMethodContainer(Func<Tuple<bool,object>> actConfirm, Action actBreak, string cmdMessage)
        {
            var resObject = new object();
            PressedKey = Keys.None;
            Invoke(new Action(() => 
            {
                scene.SceneControl.DisplayText2D(cmdMessage, Color.Black, new Point2D(10, 10));
                scene.SceneControl.DisplayObjects();
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

            scene.SceneControl.HideDisplayText2D();
            scene.SceneControl.DisplayObjects();

            PressedKey = Keys.None;
            return resObject;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            navigator.Invalidate();
        }          

        public async Task EditGroupAsync(IGroup group)
        {
            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var selObj = group.Where(x => x.Color == scene.SceneControl.SelectionColor);

                if (selObj.Count() == 0)
                {
                    Invoke(new Action(() =>
                    {
                        console.PrintInfo("Не выбран ни один объект!", Color.Black);
                    }));
                    return new Tuple<bool, object>(false, new object());
                }
                else
                {
                    group.Clear();

                    group.AddRange(selObj);

                    Invoke(new Action(() =>
                    {
                        console.PrintInfo("Группа изменена успешно", Color.Green);
                    }));
                    return new Tuple<bool, object>(true, new object());
                }
            });

            var actBreak = new Action(() =>
            {
                Invoke(new Action(() =>
                {
                    console.PrintInfo("Операция отменена", Color.Black);
                }));
            });

            var message = "Измените группу, добавив или удалив объекты, и нажмите на кнопку E или нажмите кнопку ESC";

            await AsyncMethodContainer(actConfirm, actBreak, message);
        }

        

        public void ChangeViewMode(IModelData modelData, ObjType objType, ViewRegime viewRegime)
        {
            switch (viewRegime)
            {
                case ViewRegime.ribbers:
                    scene.SceneControl.ChangeViewModeVBObjects(objType.ToString(), ObjView.Lines);
                    foreach (var item in modelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.Line);
                    break;
                case ViewRegime.surfaces:
                    scene.SceneControl.ChangeViewModeVBObjects(objType.ToString(), ObjView.Surface);
                    foreach (var item in modelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.Surface);
                    break;
                case ViewRegime.ribbersSurfaces:
                    scene.SceneControl.ChangeViewModeVBObjects(objType.ToString(), ObjView.LinesSurface);
                    foreach (var item in modelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.LineSurface);
                    break;
                default:
                    break;
            }
            scene.SceneControl.DisplayObjects();
        }

        private void sceneControl_Load(object sender, EventArgs e)
        {
            SceneInitialization();
        }           
    }
}
