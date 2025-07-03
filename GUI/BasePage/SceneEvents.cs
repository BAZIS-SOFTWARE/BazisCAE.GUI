using BaseModule.Extensions;
using BazisGUI.Scene.EventsArgs;
using BazisGUI.Utilities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void scene_MeshGroupCreatedEvent(object obj)
        {
            try
            {
                if (spbSelectObject.ToolTipText == "Объекты" |
spbSelectObject.ToolTipText == "Фигуры" |
spbSelectObject.ToolTipText == "Элементы")
                {

                    console.PrintInfo($"Нельзя создать группу {spbSelectObject.ToolTipText}", Color.Orange);
                }
                else
                {
                    //CreatedMeshGroupEvent?.Invoke(this, spbSelectObject.ToolTipText);
                    var objTypeStr = spbSelectObject.ToolTipText;
                    var selObjs = ObjectsProvider.SelectorProvider(project.ModelData.ObjectData, objTypeStr).
                        Where(x => x.Color == settingsConfig.SelectObjectColor);

                    if (selObjs.Count() > 0)
                    {
                        var objType = objTypeStr.ToEnum<ObjType>();
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

                        console.PrintInfo(string.Format("Создана новая группа {0}", group.Name), Color.Black);

                        var text = $"{group.Name} {selObjs.Count()}";
                        var node = navigator.CreateRealNode(objType.ToString(), text);

                        navigator.TrySearchNodes("группыОбъектов", out List<TreeNode> nodes);
                        nodes.First().Nodes.Add(node);
                        navigator.SetContextMenu(node);
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
           
        }

        private void scene_SceneInfoEvent(object arg1, string arg2, Color arg3)
        {
            console.PrintInfo(arg2, arg3);
        }

        private void scene_ShowAllObjectsEvent(object sender, EventArgs args)
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

        private void scene_SelectionDeletedEvent(object obj)
        {
            try
            {
                var selObjs = ObjectsProvider.SelectorProvider(project.ModelData.ObjectData, spbSelectObject.ToolTipText).
Where(x => x.Color == settingsConfig.SelectObjectColor);

                foreach (var item in selObjs)
                    item.ExistState = false;

                project.ModelData.ObjectData.ClearNotExisted();
                project.ModelData.ObjectData.ClearEmptySet();
                project.ModelData.GroupData.ClearNotExisted();
                project.TaskData.ClearNotExisted(project.ModelData.GroupData);

                PresentObjectsDataOnTree(project.ModelData.ObjectData);
                PresentGroupDataOnTree(project.ModelData.GroupData);

                //if (arg1 is TaskPage taskPage)
                PresentCondDataOnTree(project.GeneralData, project.TaskData);

                scene.PresentModelObjectsOnScene(project.ModelData, spbSelectObject.ToolTipText);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }


        private void scene_SetBackColorToAllObjectsEvent(object obj)
        {
            scene.SetBackColorToAllObjects(project.ModelData);
        }

        private void scene_HideSelectedObjects(object obj)
        {
            try
            {
                var objTypeStr = spbSelectObject.ToolTipText;
                var selObjs = ObjectsProvider.SelectorProvider(project.ModelData.ObjectData, objTypeStr).
        Where(x => x.Color == settingsConfig.SelectObjectColor);

                foreach (var selObj in selObjs)
                    selObj.ViewState = false;

                scene.PresentModelObjectsOnScene(project.ModelData, objTypeStr);
                scene.SceneControl.DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
            
        }

        private void scene_SelectObjectsEvent(object arg1, SelectObjectsEventArgs arg2)
        {
            try
            {
                var objects = ObjectsProvider.SelectorProvider(project.ModelData.ObjectData, spbSelectObject.ToolTipText);
                var selections = scene.SearchObjects(objects, arg2.SelectionBox, arg2.IsSorted);

                if (selections.Count > 0)
                {
                    foreach (var obj in selections)
                    {
                        var set = project.ModelData.ObjectData.GetSetInfo(obj.ObjType, obj.Number);
                        if (arg2.IsSelected)
                            obj.Color = settingsConfig.SelectObjectColor;//  page.ScenePage.SceneControl.SelectionColor;
                        else
                            obj.Color = set.Color;
                    }

                    scene.ColorObjects(project.ModelData, spbSelectObject.ToolTipText);
                }

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void scene_SceneExpandEvent()
        {
            embeddedSplitContainer.Panel1Collapsed = true;
            embeddedSplitContainer.Panel2Collapsed = true;
        }

        private void scene_SceneFoldEvent()
        {
            embeddedSplitContainer.Panel1Collapsed = false;
            embeddedSplitContainer.Panel2Collapsed = false;
        }
    }
}
