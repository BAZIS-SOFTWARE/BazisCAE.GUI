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
                List<TreeNode> tasks;
                var search = navigator.TrySearchNodes(NodeName.задача, out tasks);

                if (project.GetAllCondData().Count() != 0)
                    if (search)
                    {
                        PresentConds(tasks.First());
                    }
                    else
                    {
                        var rn = navigator.CreateRealNode(NodeName.задача, "Задача");
                        navigator.SetContextMenu(rn);
                        PresentConds(rn);
                        navigator.TrySearchNodes(NodeName.проект, out List<TreeNode> prNodes);
                        prNodes[0].Nodes.Add(rn);
                    }
                else
                {
                    if (search)
                        tasks.First().Remove();
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void PresentConds(TreeNode taskNode)
        {
            navigator.BeginUpdate();
            taskNode.Nodes.Clear();

            foreach (var data in project.GetAllCondData())
            {
                var nodeType = data.Kind.ToString().ToEnum<NodeName>();
                var imgIndex = navigator.GetObjectImageIndex(nodeType);

                var child = navigator.CreateRealNode(nodeType, $"{data}");
                child.ImageIndex = imgIndex;
                child.SelectedImageIndex = imgIndex;

                //navigator.TrySearchNodes(NodeName.условия.ToString(), out List<TreeNode> nodes);
                taskNode.Nodes.Add(child);
                navigator.SetContextMenu(child);
            }

            navigator.EndUpdate();
            taskNode.Expand();
        }
    }
}
