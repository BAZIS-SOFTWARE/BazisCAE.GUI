using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void PresentCompDataOnTree(List<string> compData)
        {
            try
            {
                navigator.BeginUpdate();
                navigator.TrySearchNodes(NodeName.расчет, out List<TreeNode> comp);

                comp[0].Nodes.Clear();

                foreach (var item in compData)
                {
                    var nodeName = item.Split(' ')[0].ToEnum<NodeName>();
                    var r = navigator.CreateRealNode(nodeName, item);

                    comp[0].Nodes.Add(r);
                }

                navigator.EndUpdate();
                comp[0].Expand();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
