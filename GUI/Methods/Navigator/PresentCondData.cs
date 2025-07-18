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
        public void PresentCondDataOnTree()
        {
            try
            {
                navigator.BeginUpdate();
                navigator.TrySearchNodes(NodeName.условия, out List<TreeNode> cond);
                cond[0].Nodes.Clear();

                PresentMatAndFuncData();

                foreach (var data in project.GetAllCondData())
                {
                    var nodeType = data.Kind.ToString().ToEnum<NodeName>();
                    var imgIndex = navigator.GetObjectImageIndex(nodeType);

                    var child = navigator.CreateRealNode(nodeType, $"{data}");
                    child.ImageIndex = imgIndex;
                    child.SelectedImageIndex = imgIndex;

                    navigator.TrySearchNodes(NodeName.условия.ToString(), out List<TreeNode> nodes);
                    nodes.First().Nodes.Add(child);
                }

                navigator.EndUpdate();
                cond[0].Expand();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
