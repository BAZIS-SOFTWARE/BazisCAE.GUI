using BazisAvaloniaGUI.Extensions;
using BazisAvaloniaGUI.Navigator;
using BazisAvaloniaGUI.Properties;
using Model.Interfaces;
using Project.Tasks;
using Project.Tasks.Materials;
using System;
using System.Drawing;
using System.Linq;

namespace BazisAvaloniaGUI.Shell
{
    internal partial class MainWindow
    {
        private void PropertiesPanel_OnPropertyUpdate(PropertyChangedEventArgs obj)
        {
            try
            {
                if (obj.Tag == 1) // выбор со сцены
                {
                    SceneSelection(obj);
                }
                else // через навигатор
                {
                    // В зависимости от свойства данных проекта (modelData, TaskData etc
                    // вызывать нужный метод в controller

                    NavigatorSelection(obj);
                }


            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void NavigatorSelection(PropertyChangedEventArgs obj)
        {
            if (navigator.SelectedNode.Level == 1)
            {
                var nodeName = navigator.SelectedNode.Name.ToEnum<NodeName>();
                if (nodeName == NodeName.Task)
                    ChangeTaskProperties(obj);
                else if (nodeName == NodeName.Geometry)
                    ChangeGeoProperties(obj);
                // NodeName.Calculations, NodeName.Results — расчёты и результаты в Avalonia ещё не перенесены.

            }

            if (navigator.SelectedNode.Level == 2)
            {
                var index = navigator.SelectedNode.Index;
                var parentName = navigator.SelectedNode.Parent.Name.ToEnum<NodeName>();
                var nodeName = navigator.SelectedNode.Name.ToEnum<NodeName>();
                if (parentName == NodeName.Groups)
                {
                    if (nodeName == NodeName.ElementsGroup |
                        nodeName == NodeName.NodesGroup
                        )
                    {
                        ChangeMeshGroupProperties(obj, index);
                        PresentGroupDataOnTree();
                        PresentCondDataOnTree();
                    }
                }
                else if (parentName == NodeName.Mesh)
                {
                    var objType = navigator.SelectedNode.Text.Split(' ')[0].ToEnum<ObjType>();
                    if (nodeName == NodeName.Sets & objType == ObjType.Элемент3D)
                        ChangeMeshSetProperties(obj, 3);
                    else if (nodeName == NodeName.Sets & objType == ObjType.Элемент2D)
                        ChangeMeshSetProperties(obj, 2);
                    else
                        ChangeMeshSetProperties(obj, 1);
                }
                else if (parentName == NodeName.Task)
                {
                    var flag = false;
                    var _funcs = project.FunctionsDB.Keys.ToList();
                    _funcs.Add("*");
                    var _mats = project.MaterialsDB.Keys.ToList();
                    var groups = project.GetAllModelGroups();
                    var cond = project.GetCondData(index);
                    if (nodeName == NodeName.Material)
                    {
                        ChangeMatProperties(obj, (MatData)cond, ref flag);

                        if (flag)
                        {
                            var rows = GetMatProperty((MatData)cond, _mats, groups, _funcs);
                            propertiesPanel.DrawTable(rows);
                        }
                    }
                    else if (nodeName == NodeName.Heat)
                    {
                        ChangeHeatProperties(obj, (HeatData)cond, ref flag);

                        if (flag)
                        {
                            var rows = GetCondProperty((HeatData)cond, groups, _funcs);
                            propertiesPanel.DrawTable(rows);
                        }
                    }
                    else if (nodeName == NodeName.Load)
                    {
                        ChangeLoadProperties(obj, (LoadData)cond, ref flag);

                        if (flag)
                        {
                            var rows = GetLoadProperty((LoadData)cond, _funcs, groups);
                            propertiesPanel.DrawTable(rows);
                        }
                    }
                    else if (nodeName == NodeName.Media)
                    {
                        ChangeMediaProperties(obj, (MediaData)cond, ref flag);

                        if (flag)
                        {
                            var rows = GetMediaProperty((MediaData)cond, groups, _funcs);
                            propertiesPanel.DrawTable(rows);
                        }

                    }
                    else if (nodeName == NodeName.Clamp)
                    {
                        ChangeClampProperties(obj, (ClampData)cond, ref flag);

                        if (flag)
                        {
                            var rows = GetClampProperty((ClampData)cond, groups, _funcs);
                            propertiesPanel.DrawTable(rows);
                        }
                    }

                    // кажется что костыль, но работает с ним без мерцаний в левом углу
                    navigator.DrawNodeFrozen = true;
                    navigator.BeginUpdate();

                    var parts = cond.ToString().Split(" : ");
                    navigator.SelectedNode.Text = $"{Localization.Localization.GetNavigatorNodeNameLocalization(nodeName)} : {parts[1]}";

                    navigator.EndUpdate();
                    navigator.DrawNodeFrozen = false;

                }

            }

            if (navigator.SelectedNode.Level == 3)
            {
                var number = int.Parse(navigator.SelectedNode.Text.Split(' ')[0]);
                var objInfo = navigator.SelectedNode.Text.Split(' ')[1];

                ObjType objType;
                if (objInfo.TryToEnum(out objType))
                {
                    if (objType == ObjType.Узел)
                        ChangeNodeProperty(obj, number);
                    else if (objType == ObjType.Элемент1D)
                        ChangeElementProperty(obj, objType, number);
                    else if (objType == ObjType.Элемент2D)
                        ChangeElementProperty(obj, objType, number);
                    else if (objType == ObjType.Элемент3D)
                        ChangeElementProperty(obj, objType, number);
                    else if (objType == ObjType.Точка)
                        ChangePointProperty(obj, number);
                    else if (objType == ObjType.Кривая)
                        ChangeCurveProperty(obj, number);
                    else if (objType == ObjType.Поверхность)
                    {
                        var flag = false;
                        ChangeSurfaceProperty(obj, number, ref flag);
                        if (flag)
                        {
                            var rows = GetSurfaceProperties(number);
                            propertiesPanel.DrawTable(rows);
                        }
                    }
                }
                else
                {
                    var flag = false;
                    ChangeVolProperty(obj, number, ref flag);
                    if (flag)
                    {
                        var rows = GetVolProperties(number);
                        propertiesPanel.DrawTable(rows);
                    }
                }
            }
        }

        private void SceneSelection(PropertyChangedEventArgs obj)
        {
            var number = int.Parse(obj.ObjInfo.Split(' ')[0]);
            var objType = obj.ObjInfo.Split(' ')[1].ToEnum<ObjType>();
            if (objType == ObjType.Узел)
                ChangeNodeProperty(obj, number);
            else if (objType == ObjType.Элемент1D)
                ChangeElementProperty(obj, ObjType.Элемент1D, number);
            else if (objType == ObjType.Элемент2D)
                ChangeElementProperty(obj, ObjType.Элемент2D, number);
            else if (objType == ObjType.Элемент3D)
                ChangeElementProperty(obj, ObjType.Элемент3D, number);
            else if (objType == ObjType.Точка)
                ChangePointProperty(obj, number);
            else if (objType == ObjType.Кривая)
                ChangeCurveProperty(obj, number);
            else if (objType == ObjType.Поверхность)
            {
                var flag = false;
                ChangeSurfaceProperty(obj, number, ref flag);
                if (flag)
                {
                    var rows = GetSurfaceProperties(number);
                    propertiesPanel.DrawTable(rows, obj.ObjInfo, obj.Tag);
                }
            }
        }

        // ChangeResultsProperty и связанные HandleMin/MaxValueParameter, HandleShowResultsScale —
        // результаты в Avalonia ещё не перенесены.
    }
}
