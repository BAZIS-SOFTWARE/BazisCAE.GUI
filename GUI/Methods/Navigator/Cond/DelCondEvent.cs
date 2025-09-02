using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Model.Utilities;
using Project.Tasks;
using PropertiesCalculator.FunctionData;
using PropertiesCalculator.MaterialData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_DelCondEvent()
        {
			try
			{
                var node = navigator.SelectedNode;

                if (project.DeleteCond(node.Level))
                    navigator.SelectedNode.Remove();
            }
			catch (Exception ex)
			{
                console.PrintInfo(ex.Message, Color.Red);
			}


        }
    }
}
