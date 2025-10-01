using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectSetEvent(NodeName arg1, string arg2)
        {
            try
            {
                var setName = arg2.Split(' ')[1];
                if (arg1 == NodeName.Объем | arg1 == NodeName.Поверхности)
                {
                    var ar = arg2.Split(' ');
                    setName = string.Join(" ", ar, 1, ar.Length - 2);
                }

                if(arg1 == NodeName.Узлы | arg1 == NodeName.Элементы1D
                    & arg1 == NodeName.Элементы2D | arg1 == NodeName.Элементы3D)
                {
                    var objType = Converters.ConvertNavigatorNodeNameToObjType(arg1);

                    var set = project.GetModelSetInfo(objType, setName);
                    var rows = GetSetProperty(set);


                    if (arg1 != NodeName.Узлы)
                        rows.Add(new RowProperty("Порядок точности", "", 
                            new List<string>() { "1", "2" }));

                    propertiesPanel.DrawTable(rows);
                }
                else if (arg1 == NodeName.Поверхности
                    | arg1 == NodeName.Кривые | arg1 == NodeName.Точки)
                {
                    var objType = Converters.ConvertNavigatorNodeNameToObjType(arg1);

                    var set = project.GetModelSetInfo(objType, setName);
                    var rows = GetSetProperty(set);
                    propertiesPanel.DrawTable(rows);
                }
                else
                {
                    var vol = project.GetModelVolumes().FirstOrDefault(x => x.Name == setName);
                    /*
                     * TO DO Реализовать для объема
                     */
                }


            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
