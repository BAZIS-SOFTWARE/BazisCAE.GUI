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
        private void navigator_HideSetEvent()
        {

            try
            {
                var node = navigator.SelectedNode;

                var nodeName = node.Name.ToEnum<NodeName>();
                var nodeText = node.Text;

                ChangeSetViewState(nodeName, nodeText, false);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void navigator_ShowSetEvent()
        {
            try
            {
                var node = navigator.SelectedNode;

                var nodeName = node.Name.ToEnum<NodeName>();
                var nodeText = node.Text;
                ChangeSetViewState(nodeName, nodeText, true);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
