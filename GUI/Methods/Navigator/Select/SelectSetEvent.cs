using BaseModule.Navigator;
using BazisGUI.Utilities;
using System;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectSetEvent(NodeName arg1, string arg2)
        {
            try
            {
                var setName = arg2.Split(' ')[0]; // Деление по пробелу перед :

                var objType = Converters.ConvertNavigatorNodeNameToObjType(arg1);
                var set = project.GetModelSetInfo(objType, setName);

                var rows = GetSetProperty(set);
                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
