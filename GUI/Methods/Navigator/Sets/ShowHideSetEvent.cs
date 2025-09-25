using BaseModule.Extensions;
using BaseModule.Navigator;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using System.Drawing;
using System;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_HideSetEvent(NodeName nodeType, string nodeText)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeType);

                var setName = nodeText.Split(' ')[1];
                if (nodeType == NodeName.Объемы | nodeType == NodeName.Поверхности)
                {
                    var ar = nodeText.Split(' ');
                    setName = string.Join(" ", ar, 1, ar.Length - 2);
                }

                ChangeSetViewState(setName, objType, false);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowSetEvent(NodeName nodeType, string nodeText)
        {
            try
            {
                var objType = Converters.ConvertNavigatorNodeNameToObjType(nodeType);

                var setName = nodeText.Split(' ')[1];
                if (nodeType == NodeName.Объемы | nodeType == NodeName.Поверхности)
                {
                    var ar = nodeText.Split(' ');
                    setName = string.Join(" ", ar, 1, ar.Length - 2);
                }

                ChangeSetViewState(setName, objType, true);

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
