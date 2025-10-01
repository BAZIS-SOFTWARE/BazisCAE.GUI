using BaseModule.Extensions;
using BaseModule.Mesh;
using BaseModule.Mesh.SettingsControls;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BaseModule.PropertiesPanel.DataGridViewNumericUpDown;
using BazisGUI.Utilities;
using GmshApi;
using Project.Interfaces.Tasks;
using Project.Tasks;
using PropertiesCalculator.FunctionData;
using PropertiesCalculator.MaterialData;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void propertiesPanel_OnPropertyUpdate(PropertyChangedEventArgs obj)
        {
            try
            {
                // В зависимости от свойства данных проекта (modelData, TaskData etc
                // вызывать нужный метод в controller
                var nodeName = navigator.SelectedNode.Name.ToEnum<NodeName>();

                if (navigator.SelectedNode.Level == 3)
                {
                    var number = int.Parse(navigator.SelectedNode.Text.Split(' ')[0]);
                    if (nodeName == NodeName.Элемент3D |
                        nodeName == NodeName.Элемент2D |
                        nodeName == NodeName.Элемент1D |
                        nodeName == NodeName.Узел) 
                    {
                        ChangeModelObjectProperty(obj, nodeName);
                    }
                    else if (nodeName == NodeName.Точка)
                    {
                        // Тут задаем настройки сетки в контрольных узлах геометрии
                        //SetPointSize();
                        //SetMinMaxSizes()
                    }
                    else if (nodeName == NodeName.Кривая)
                    {
                        var attributes = gmshController.Gmsh.Model.GetAttribute($"transfinite {number}");

 
                        if (obj.Header == "Алгоритм")    
                            attributes[1] = obj.NewValue;         
                        else if(obj.Header == "Колличество точек")
                            attributes[0] = obj.NewValue;
                        else
                            attributes[2] = obj.NewValue;

                        gmshController.Gmsh.Model.SetAttribute($"transfinite curve {number}", attributes);
                        //if (!string.IsNullOrEmpty(arg2.Attributes[0]) && !string.IsNullOrEmpty(arg2.Attributes[2]))
                        //{
                        if(attributes[0] != "0")
                        {
                            var points = int.Parse(attributes[0]);
                            var meshType = attributes[1].ToEnum<MeshType>();
                            var coeff = double.Parse(attributes[2]);
                            gmshController.Gmsh.Model.Mesh.SetTransfiniteCurve(number, points, meshType, coeff);
                        }
                           
                        //}
                    }
                    else if (nodeName == NodeName.Объем)
                    {
                        // Тут задаем настройки сетки в объемах геометрии
                        //SetMeshGradientSettings(MeshGradientSettingsEventArgs arg2)
                    }
                }
                if (navigator.SelectedNode.Level == 2)
                {
                    var index = navigator.SelectedNode.Index;
                    var parentName = navigator.SelectedNode.Parent.Name.ToEnum<NodeName>();
                    if (parentName == NodeName.группы)
                    {
                        if (nodeName == NodeName.Элементы3D |
        nodeName == NodeName.Элементы2D |
        nodeName == NodeName.Элементы1D |
        nodeName == NodeName.Узлы
        )
                        {
                            ChangeMeshGroupProperties(obj, index);
                            PresentGroupDataOnTree();
                            PresentCondDataOnTree();
                        }
                    }
                    else if (parentName == NodeName.сетка)
                    {
                        if (nodeName == NodeName.Элементы3D)
                            ChangeMeshSetProperties(obj, 3);
                        else if (nodeName == NodeName.Элементы2D)
                            ChangeMeshSetProperties(obj, 2);
                        else
                            ChangeMeshSetProperties(obj, 1);
                    }    
                    else if (parentName == NodeName.задача)
                    {
                        var _funcs = project.FunctionsDB.Keys.ToList();
                        var _mats =project.MaterialsDB.Keys.ToList();
                        var groups = project.GetAllModelGroups();
                        var cond = project.TaskData[index];
                        if (nodeName == NodeName.Материал)
                        {
                            ChangeMatProperties(obj, (MatData)cond);
                            var rows = GetMatProperty((MatData)cond, _mats, groups);
                            propertiesPanel.DrawTable(rows);
                        }
                        else if (nodeName == NodeName.Нагрев)
                        {
                            ChangeHeatProperties(obj, (HeatData)cond);
                            var rows = GetHeatProperty((HeatData)cond, groups, _funcs);
                            propertiesPanel.DrawTable(rows);
                        }
                        else if (nodeName == NodeName.Закрепление |
                            nodeName == NodeName.Нагрев |
                            nodeName == NodeName.Нагрузка |
                            nodeName == NodeName.Среда
                            )
                        {
                            ChangeGeneralProperties(obj, cond);
                            //PresentCondDataOnTree();
                        }
                        navigator.SelectedNode.Text = cond.ToString();

                    }
                    else if(parentName == NodeName.расчеты)
                    {
                        var s = navigator.SelectedNode.Text;
                        ChangeCompProperties(obj, s);
                    }

                }

                else if (navigator.SelectedNode.Level == 1)
                {
                    if (nodeName == NodeName.задача)
                        ChangeTaskProperties(obj);
                    else if (nodeName == NodeName.геометрия)
                        ChangeGeoProperties(obj);
                    else if (nodeName == NodeName.расчеты)
                        ChangeCompProperties(obj);
                }
                    else if (nodeName == NodeName.результаты)
                    {         
                        if (obj.Header == "Масштаб")
                            settingsConfig.Scale_scale = int.Parse(obj.NewValue);
                        else if (obj.Header == "Показывать шкалу")
                        {
                            /* TO DO
                             
                             * При активации создать и показать дополнительные строки с настройками
                             * При деактивации - убрать строки
                            
                            - Точность (взять из settingsConfig.Scale_Precision)
                            - Положение шкалы по Х (взять из settingsConfig.Scale_X_Coord)
                            - Положение шкалы по Y (взять из settingsConfig.Scale_Y_Coord)
                            
                            */
                            settingsConfig.ShowResultsScale = bool.Parse(obj.NewValue);

                            if(!settingsConfig.ShowResultsScale)
                                HideGeometryObj("DisplaySceneScale");
                        }
                        else if (obj.Header == "Уточнить значения")
                        {

                            //resultsController.FillRange(ar2.Min, ar2.Max, ar2.Range, ar2.Precision);
                            settingsConfig.IsScaleMaxMinManual = bool.Parse(obj.NewValue);

                            // TO DO
                            //
                            // При активации создать и показать еще две строки
                            // При деактивации -убрать строки
                            /*
                            - Макс. значение; (settingsConfig.Scale_MaxValue)
                            - Мин. значение; (settingsConfig.Scale_MinValue)
                             */

                        }

                        else if (obj.Header == "Показывать поле")
                            settingsConfig.ShowResultsField = bool.Parse(obj.NewValue);
                        else if (obj.Header == "Показать значения в узлах")
                            settingsConfig.ShowNodeResultsValue = bool.Parse(obj.NewValue);
                        else if (obj.Header == "Показать значения в элементах")
                            settingsConfig.ShowElementsResultsValue = bool.Parse(obj.NewValue);
                        else if (obj.Header == "Усреднять результаты")
                            settingsConfig.MergeResultsValue = bool.Parse(obj.NewValue);
                        else if (obj.Header == "Точность")
                            settingsConfig.Scale_Precision = int.Parse(obj.NewValue);
                        else if (obj.Header == "Интервалы")
                            settingsConfig.Scale_Intervals = int.Parse(obj.NewValue);
                        else if (obj.Header == "Положение шкалы по Х")
                            settingsConfig.Scale_X_Coord = int.Parse(obj.NewValue);
                        else if (obj.Header == "Положение шкалы по Y")
                            settingsConfig.Scale_Y_Coord = int.Parse(obj.NewValue);
                    }
                

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        //public void SetCurveAttributes(string[] attributes)
        //{
        //    if (attributes.Length == 0)
        //        ResetTransfinition();
        //    else
        //    {
        //        var law = attributes[1];
        //        if (rbtnBump.Text.Contains(law))
        //            rbtnBump.Checked = true;
        //        else if (rbtnBeta.Text.Contains(law))
        //            rbtnBeta.Checked = true;
        //        else
        //            rbtnProgressive.Checked = true;

        //        txbAlgoNPoints.Text = attributes[0];
        //        txbAlgoCoef.Text = attributes[2].Length == 0 ? "1.0" : attributes[2];
        //    }
        //}


        private void SetPointSize(int pointNumber, double[] pointSize)
        {
            // задаем значения парами размерность - номер
            var dimTags = new int[] { 0, pointNumber };
            gmshController.Gmsh.Model.Mesh.SetSize(dimTags, pointSize[0]);
        }
        //задаем во всех контр. узлах диапазон
        private void SetMinMaxSizes(double[] sizes)
        {
            gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeMin", sizes[0]);
            gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeMax", sizes[1]);
        }

        private void SetMeshGradientSettings(MeshGradientSettingsEventArgs arg2)
        {
            gmshController.Gmsh.Model.Mesh.Field.Add(FieldType.Extend);

            var list = gmshController.Gmsh.Model.Mesh.Field.List();
            if (list.Length != 0)
            {
                var field = list.First();
                var points = gmshController.Gmsh.Model.GetEntities(0);
                var curves = gmshController.Gmsh.Model.GetEntities(1);
                var surfaces = gmshController.Gmsh.Model.GetEntities(2);
                var curveTags = curves.Where((v, i) => (i & 1) != 0)
                                      .Select(v => (double)v).ToArray();
                var surfTags = surfaces.Where((v, i) => (i & 1) != 0)
                                       .Select(v => (double)v).ToArray();
                gmshController.Gmsh.Model.Mesh.SetSize(points, arg2.surfaceMeshSize);
                gmshController.Gmsh.Model.Mesh.Field.SetNumbers(field, ExtendOptions.CurvesList.ToString(), curveTags);
                gmshController.Gmsh.Model.Mesh.Field.SetNumbers(field, ExtendOptions.SurfacesList.ToString(), surfTags);
                gmshController.Gmsh.Model.Mesh.Field.SetNumber(field, ExtendOptions.Power.ToString(), arg2.gradientMeshPower);
                gmshController.Gmsh.Model.Mesh.Field.SetNumber(field, ExtendOptions.DistMax.ToString(), arg2.layerThickness);
                gmshController.Gmsh.Model.Mesh.Field.SetNumber(field, ExtendOptions.SizeMax.ToString(), arg2.coreMeshSize);
                gmshController.Gmsh.Model.Mesh.Field.SetAsBackgroundMesh(field);
                gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeExtendFromBoundary", -2);
            }
        }

        private void CurveAttribDelete(int obj)
        {
            var dimTags = new int[] { 1, obj };
            gmshController.Gmsh.Model.RemoveAttribute($"transfinite {obj}");
            gmshController.Gmsh.Model.Mesh.RemoveConstraints(dimTags);
        }

        private void GetCurveAttrib(object arg1, int arg2)
        {
            try
            {
                var attributes = gmshController.Gmsh.Model.GetAttribute($"transfinite {arg2}");
                var curveControl = arg1 as GMSHCurveSettingsControl;
                curveControl.SetCurveAttributes(attributes);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void PointAttribDelete(int obj)
        {
            var dimTags = new int[] { 0, obj };
            gmshController.Gmsh.Model.Mesh.RemoveConstraints(dimTags);
        }

        private void DelMeshGradient(object arg1)
        {
            var list = gmshController.Gmsh.Model.Mesh.Field.List();
            gmshController.Gmsh.Model.Mesh.Field.Remove(list.First());
            var points = gmshController.Gmsh.Model.GetEntities(0);
            gmshController.Gmsh.Model.Mesh.RemoveConstraints(points);
            gmshController.Gmsh.Option.SetNumber("Mesh.MeshSizeExtendFromBoundary", 1);
        }
    }
}
