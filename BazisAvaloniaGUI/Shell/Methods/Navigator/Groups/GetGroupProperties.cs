using BazisAvaloniaGUI.Localization;
using BazisAvaloniaGUI.Properties;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace BazisAvaloniaGUI.Shell
{
    internal partial class MainWindow
    {
        enum GroupPropertyKeys { Name, Sort, Direction, ElementsNodes, CreateCond }
        enum CreateCondByGroup { Heat, Material, Media, Clamp, Load }
        public List<RowProperty> GetGroupProperty(IGroup obj)
        {
            var rows = new List<RowProperty>();

            rows.Add(new RowProperty(GroupPropertyKeys.Name.ToString(),
                Resources.Header_groups_name,
                obj.Name));

            if (obj.ObjType == ObjType.Узел)
            {
                rows.Add(new RowProperty(GroupPropertyKeys.Sort.ToString(),
                    Resources.Header_groups_sort,
                    new ButtonPropertyValue(Resources.Отсортировать,
                    new Action(obj.SortByDistance))));

                rows.Add(new RowProperty(GroupPropertyKeys.Direction.ToString(),
                    Resources.Header_groups_direction,
                    new ButtonPropertyValue(Resources.Показать,
                    new Action(async () => await NewMethod2(obj)))));

                rows.Add(new RowProperty(GroupPropertyKeys.Direction.ToString(),
                    Resources.Header_groups_direction,
                    new ButtonPropertyValue(Resources.Реверс,
                    new Action(obj.Reverse))));
            }
            else
            {
                rows.Add(new RowProperty(GroupPropertyKeys.ElementsNodes.ToString(),
                    Resources.Header_groups_elementsNodes,
                    new ButtonPropertyValue(Resources.Header_group_show,
                    new Action(() => ShowGroupWithNodes(obj)))));
            }

            // показываем возможные условия
            if (obj.ObjType != ObjType.Узел)
                CreateElementsConditionsProperties(obj, rows);
            else
                CreateNodesConditionsProperties(obj, rows);

            return rows;
        }

        private Task NewMethod2(IGroup obj)
        {
            // Avalonia: в BaseForm направление рисуется сферами gluSphere (glu32.dll, только Windows)
            // через DisplayGeometryObjectEvent; кроссплатформенной замены в SceneCore пока нет.
            console.PrintInfo("Показ направления группы в Avalonia-версии ещё не перенесён (требует gluSphere).", Color.Orange);
            return Task.CompletedTask;
        }

        private void CreateNodesConditionsProperties(IGroup obj, List<RowProperty> rows)
        {
            if (project.TaskKind == TaskKind.термическая)
            {
                rows.Add(new RowProperty(GroupPropertyKeys.CreateCond.ToString(),
                    Resources.Header_groups_createCond,
                    new DropDownPropertyValue("*",
                    new List<string>()
                    {
                        CreateCondByGroup.Heat.ToString(),
                        CreateCondByGroup.Media.ToString()
                    })));
            }

            else
            {
                rows.Add(new RowProperty(GroupPropertyKeys.CreateCond.ToString(),
                    Resources.Header_groups_createCond,
                    new DropDownPropertyValue("*",
                    new List<string>()
                    {
                        CreateCondByGroup.Clamp.ToString(),
                        CreateCondByGroup.Load.ToString()
                    })));
            }
        }

        private void CreateElementsConditionsProperties(IGroup obj, List<RowProperty> rows)
        {
            if (project.TaskType == TaskType.Volume)
            {
                if (obj.ObjType == ObjType.Элемент3D)
                {
                    if (project.TaskKind == TaskKind.термическая |
                        project.TaskKind == (TaskKind.термическая | TaskKind.механическая))
                        rows.Add(new RowProperty(GroupPropertyKeys.CreateCond.ToString(),
                            Resources.Header_groups_createCond,
                            new DropDownPropertyValue("*",
                            new List<string>()
                            {
                                CreateCondByGroup.Material.ToString(),
                                CreateCondByGroup.Heat.ToString(),
                            })));

                    else if (project.TaskKind == TaskKind.механическая)
                        rows.Add(new RowProperty(GroupPropertyKeys.CreateCond.ToString(),
                            Resources.Header_groups_createCond,
                            new DropDownPropertyValue("*",
                            new List<string>()
                            {
                                CreateCondByGroup.Material.ToString()
                            })));
                }

                else if (obj.ObjType == ObjType.Элемент2D)
                    if (project.TaskKind == TaskKind.термическая |
                        project.TaskKind == (TaskKind.термическая | TaskKind.механическая))
                        rows.Add(new RowProperty(GroupPropertyKeys.CreateCond.ToString(),
                            Resources.Header_groups_createCond,
                            new DropDownPropertyValue("*",
                            new List<string>()
                            {
                                CreateCondByGroup.Media.ToString()
                            })));
            }

            else if (project.TaskType == TaskType.AxiPlain | project.TaskType == TaskType.Plain)
            {
                if (obj.ObjType == ObjType.Элемент2D)
                    rows.Add(new RowProperty(GroupPropertyKeys.CreateCond.ToString(),
                        Resources.Header_groups_createCond,
                        new DropDownPropertyValue("*",
                        new List<string>()
                        {
                            CreateCondByGroup.Material.ToString()
                        })));

                else if (obj.ObjType == ObjType.Элемент1D)
                {
                    if (project.TaskKind == TaskKind.термическая |
                        project.TaskKind == (TaskKind.термическая | TaskKind.механическая))
                        rows.Add(new RowProperty(GroupPropertyKeys.CreateCond.ToString(),
                            Resources.Header_groups_createCond,
                            new DropDownPropertyValue("*",
                            new List<string>()
                            {
                                CreateCondByGroup.Material.ToString(),
                                CreateCondByGroup.Media.ToString()
                            })));

                    else if (project.TaskKind == TaskKind.механическая)
                        rows.Add(new RowProperty(GroupPropertyKeys.CreateCond.ToString(),
                            Resources.Header_groups_createCond,
                            new DropDownPropertyValue("*",
                            new List<string>()
                            {
                                CreateCondByGroup.Material.ToString()
                            })));
                }
            }

            else if (project.TaskType == TaskType.Linear)
            {
                if (obj.ObjType == ObjType.Элемент1D)
                    rows.Add(new RowProperty(GroupPropertyKeys.CreateCond.ToString(),
                        Resources.Header_groups_createCond,
                        new DropDownPropertyValue("*",
                        new List<string>()
                        {
                            CreateCondByGroup.Material.ToString()
                        })));
            }

            else
            {
                if (obj.ObjType == ObjType.Элемент1D)
                    rows.Add(new RowProperty(GroupPropertyKeys.CreateCond.ToString(),
                        Resources.Header_groups_createCond,
                        new DropDownPropertyValue("*",
                        new List<string>()
                        {
                            CreateCondByGroup.Material.ToString()
                        })));

                else if (obj.ObjType == ObjType.Элемент2D)
                    rows.Add(new RowProperty(GroupPropertyKeys.CreateCond.ToString(),
                        Resources.Header_groups_createCond,
                        new DropDownPropertyValue("*",
                        new List<string>()
                        {
                            CreateCondByGroup.Material.ToString(),
                            CreateCondByGroup.Media.ToString()
                        })));

                else if (obj.ObjType == ObjType.Элемент3D)
                    rows.Add(new RowProperty(GroupPropertyKeys.CreateCond.ToString(),
                        Resources.Header_groups_createCond,
                        new DropDownPropertyValue("*",
                        new List<string>()
                        {
                            CreateCondByGroup.Material.ToString()
                        })));
            }
        }
    }
}
