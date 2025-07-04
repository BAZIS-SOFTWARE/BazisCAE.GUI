using BaseModule.Navigator;
using BaseModule.Utilities;
using BazisGUI.Scene.Interfaces;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Project.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        [Category("General")]
        [Description("Кнопка на клавиатуре")]
        public Keys PressedKey { get; set; }

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
                var selObjs = pointObjs.Where(x => x.Color == SelectionColor).ToArray();

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
                DisplayText2D(cmdMessage, Color.Black, new Point2D(10, 10));
                DisplayObjects();
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

            HideDisplayText2D();
            DisplayObjects();

            PressedKey = Keys.None;
            return resObject;
        }        

        public async Task EditGroupAsync(IGroup group)
        {
            var actConfirm = new Func<Tuple<bool, object>>(() =>
            {
                var selObj = group.Where(x => x.Color == SelectionColor);

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
                    ChangeViewModeVBObjects(objType.ToString(), ObjView.Lines);
                    foreach (var item in modelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.Line);
                    break;
                case ViewRegime.surfaces:
                    ChangeViewModeVBObjects(objType.ToString(), ObjView.Surface);
                    foreach (var item in modelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.Surface);
                    break;
                case ViewRegime.ribbersSurfaces:
                    ChangeViewModeVBObjects(objType.ToString(), ObjView.LinesSurface);
                    foreach (var item in modelData.ObjectData.GetSetsInfo(objType))
                        item.SetViewMode(ViewMode.LineSurface);
                    break;
                default:
                    break;
            }
            DisplayObjects();
        }          
    }
}
