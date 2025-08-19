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
                navigator.TrySearchNodes(NodeName.задача, out List<TreeNode> task);
                task[0].Nodes.Clear();

                foreach (var data in project.GetAllCondData())
                {
                    var nodeType = data.Kind.ToString().ToEnum<NodeName>();
                    var imgIndex = navigator.GetObjectImageIndex(nodeType);

                    var child = navigator.CreateRealNode(nodeType, $"{data}");
                    child.ImageIndex = imgIndex;
                    child.SelectedImageIndex = imgIndex;

                    //navigator.TrySearchNodes(NodeName.условия.ToString(), out List<TreeNode> nodes);
                    task.First().Nodes.Add(child);
                }

                navigator.EndUpdate();
                task[0].Expand();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
