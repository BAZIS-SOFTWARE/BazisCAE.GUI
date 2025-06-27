using BaseModule.Console.Events;
using BaseModule.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BazisGUI.Utilities;
using Model.Interfaces;
using Geometry;
using System.Drawing;
using BaseModule.Navigator;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void console_ControlCollapseEvent()
        {

        }
        public async void console_InEvent(object arg1, EventArgs arg2)
        {
            try
            {
                if (arg2 is FindObjectEventArgs findObjectEventArgs)
                {
                    Invoke(new Action(() =>
                    {
                        var objsType = Converters.ConvertToObjsType(findObjectEventArgs.ObjsType);
                        var obj = project.ModelData.ObjectData.Find(objsType, (int)findObjectEventArgs.Number);

                        if (obj != null)
                        {
                            foreach (var item in project.ModelData.ObjectData.GetObjects(obj.ObjType))
                                item.ViewState = false;
                            obj.ViewState = true;
                            scene.ClearAllDataOnScene();

                            var pres = scene.CreateObjectsPresentor(project.ModelData, obj.ObjType);
                            scene.CreateObjectsOnScene(obj.ObjType.ToString(), pres);
                            scene.SceneControl.DisplayObjects();
                        }
                    }));
                }
                else if (arg2 is ModelFindCoincidentsNodesEventArgs coincidentNodesEventArgs)
                {
                    Invoke(new Action(() => { console.PrintInfo("Выполняется поиск совпадающих узлов сетки...", Color.Black); }));

                    modelController.CoincidentObjectsFinder.ProgressEvent += (ar1, ar2) =>
                    {
                        Invoke(new Action(() => { console.PrintInfo(string.Format("{0:00}%", ar2 * 100), Color.Black); }));
                    };

                    var nodes = project.ModelData.ObjectData.NodesSet;
                    var coincidentNodes = modelController.CoincidentObjectsFinder.Find(
                        nodes.Values.ToList(), 0.001f);

                    Invoke(new Action(() => { console.PrintInfo($"Найдено {coincidentNodes.Count()} совпадений", Color.Black); }));
                    Invoke(new Action(() =>
                    {
                        scene.ClearAllDataOnScene();
                        var pres = scene.CreateObjectsPresentor(project.ModelData, ObjType.Узел);
                        scene.CreateObjectsOnScene(ObjType.Узел.ToString(), pres);
                        scene.SceneControl.DisplayObjects();
                    }));
                    var actConfirm = new Func<Tuple<bool, object>>(() =>
                    {
                        modelController.ObjectsMerger.Merge(coincidentNodes, nodes);

                        Invoke(new Action(() =>
                        {
                            var set = project.ModelData.ObjectData.GetSetsInfo(ObjType.Узел).First();

                            navigator.TrySearchNodes(NodeType.объекты, out List<TreeNode> objects);
                            objects[0].Nodes[0].Nodes[0].Text = $"{set.Name} : {set.NumberOfObjects}";
                            console.PrintInfo("Узлы слиты", Color.Green);

                        }));
                        return new Tuple<bool, object>(true, new object());
                    });

                    var actBreak = new Action(() =>
                    {
                        Invoke(new Action(() =>
                        {
                            console.PrintInfo("Операция отменена", Color.Black);
                        }));
                    });
                    await AsyncMethodContainer(actConfirm, actBreak, $"Нажмите {"E"} для слияния, {"Esc"} для отмены");
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => { console.PrintInfo(ex.Message, Color.Red); }));
            }
        }

        private void console_FindFreeNodesEvent()
        {
            var freeNodes = modelController.FreeNodesFinder.Find(project.ModelData.ObjectData);

            Invoke(new Action(() =>
            {
                console.PrintInfo($"Найдено {freeNodes.Count()} свободных узлов", Color.Black);

                scene.SceneControl.DeleteAllVBObjects();

                foreach (var freeNode in freeNodes)
                    project.ModelData.ObjectData.Find(ObjType.Узел, freeNode).ViewState = true;

                var objsTypeStr = ObjType.Узел.ToString();
                scene.SceneControl.DeleteVBObjects(objsTypeStr);
                scene.CreateObjectsOnScene(objsTypeStr,
                scene.CreateObjectsPresentor(project.ModelData, ObjType.Узел));

                scene.SceneControl.DisplayObjects();
            }));
        }

        private void console_RenumberMeshEvent(object arg1, ModelRenumberEventArgs arg2)
        {
            modelController.ObjectsRenumber.Renumber(project.ModelData.ObjectData, Converters.ConvertToObjsType(arg2.ObjsType));
        }

        private void console_ModelShiftCoordinateEvent(object arg1, BaseModule.Console.Events.ModelShiftCoordinateEventArgs arg2)
        {
            project.ModelData.ObjectData.Move(ObjType.Узел, new Point3D(arg2.X, arg2.Y, arg2.Z));

            scene.SceneControl.HideAllGeometryObjs();
            scene.SceneControl.HideDisplayText2D();
            scene.SceneControl.HideDisplayText3D();

            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            {
                var pres = scene.CreateObjectsPresentor(project.ModelData, item);
                scene.SetObjectsSceneAttribute(pres,item.ToString(), "координаты");
            }

            scene.SceneControl.DisplayObjects();
        }

        private void console_ModelRotateEvent(object arg1, ModelRotateEventArgs arg2)
        {
            var axis = new Point3D(arg2.Axis.X, arg2.Axis.Y, arg2.Axis.Z);
            project.ModelData.ObjectData.Rotate(ObjType.Узел, axis, arg2.Angle);

            scene.SceneControl.HideAllGeometryObjs();
            scene.SceneControl.HideDisplayText2D();
            scene.SceneControl.HideDisplayText3D();

            foreach (ObjType item in Enum.GetValues(typeof(ObjType)))
            {
                var pres = scene.CreateObjectsPresentor(project.ModelData, item);
                scene.SetObjectsSceneAttribute(pres, item.ToString(), "координаты");
            }

            scene.SceneControl.DisplayObjects();
        }        
    }
}
