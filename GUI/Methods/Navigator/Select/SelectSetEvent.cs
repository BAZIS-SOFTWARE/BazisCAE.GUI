using BaseModule.Navigator;
using BazisGUI.Utilities;
using System;
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
                var setName = arg2.Split(' ')[0];
                if (arg1 == NodeName.Объем | arg1 == NodeName.Поверхности)
                {
                    var ar = arg2.Split(' ');
                    setName = string.Join(" ", ar, 0, ar.Length - 1);
                }

                if(arg1 != NodeName.Объем)
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
