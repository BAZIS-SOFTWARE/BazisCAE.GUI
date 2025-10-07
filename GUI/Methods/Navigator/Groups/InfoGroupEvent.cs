using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_InfoGroupEvent(int obj)
        {
            var group = project.GetModelGroup(obj);
            console.PrintInfo(group.ToString(), Color.Black);
        }
    }
}
