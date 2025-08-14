using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectObjectEvent(NodeName nodeName, string setName, int number)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeName);

                var rows = new List<RowProperty>();
                if (objType == ObjType.Точка)
                {
                    rows.Add(GetPointProperty(number));
                }

                else if(objType == ObjType.Узел)
                {
                    rows.AddRange(GetNodeProperty(objType, number));
                }

                else if(objType == ObjType.Элемент1D | objType == ObjType.Элемент2D | objType == ObjType.Элемент3D)
                {
                    rows.AddRange(GetElementProperty(objType, number));
                }

                else if(objType == ObjType.Кривая)
                {
                    rows.AddRange(GetCurveProperties(number));
                }
                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
