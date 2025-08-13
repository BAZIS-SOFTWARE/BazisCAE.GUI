using BaseModule.Mesh.SettingsControls;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.MeshObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectObjectEvent(NodeName nodeName, string setName, int number)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeName);
                //var setName = arg2.Split(' ')[0]; // Деление по пробелу перед :


                // TO DO
                var rows = new List<RowProperty>();
                if (objType == ObjType.Точка)
                {
                    var dimTags = new int[] { 0, number };
                    var meshSize = gmshController.Gmsh.Model.Mesh.GetSizes(dimTags);

                    var row = new RowProperty("Размер элементов", meshSize[0]);
                    rows.Add(row);
                }

                else if(objType == ObjType.Узел)
                {
                    var node = (Node)project.GetModelObject(objType, number);
                    var coord = node.GetCoordinates();
                    var listNumbers = string.Join(";", node.GetElements().Select(element => element.Number).ToList());

                    rows.Add(new RowProperty("Номер", node.Number, true));
                    rows.Add(new RowProperty("Координата X", node.Position._x));
                    rows.Add(new RowProperty("Координата Y", node.Position._y));
                    rows.Add(new RowProperty("Координата Z", node.Position._z));
                    rows.Add(new RowProperty("Связанные элементы", listNumbers, true));
                }

                else if(objType == ObjType.Кривая)
                {
                    rows.AddRange(GetCurveProperties(number));
                }
                //var _converter = new ModelObjectConverter(item);
                propertiesPanel.DrawTable(rows);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        

        private void GetPointSize(object arg1, int arg2)
        {
            try
            {
                var dimTags = new int[] { 0, arg2 };
                var meshSize = gmshController.Gmsh.Model.Mesh.GetSizes(dimTags);
                var pointControl = arg1 as GMSHPointSettingsControl;
                pointControl.SetPointSize(meshSize[0]);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
