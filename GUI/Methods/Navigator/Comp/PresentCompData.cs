using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
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
                List<TreeNode> comp;
                var search = navigator.TrySearchNodes(NodeName.расчет, out comp);

                if (compData.Count() != 0)
                    if(search)
                    {
                        NewMethod(compData, comp.First());
                    }
                    else
                    {
                        var rn = navigator.CreateRealNode(NodeName.расчет, "Расчет");
                        navigator.SetContextMenu(rn);
                        NewMethod(compData, rn);
                        navigator.TrySearchNodes(NodeName.проект, out List<TreeNode> prNodes);
                        prNodes[0].Nodes.Add(rn);
                    }
                else
                {
                    if (search)
                        comp.First().Remove();
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void NewMethod(List<string> compData, TreeNode compNode)
        {
            navigator.BeginUpdate();
            compNode.Nodes.Clear();
            foreach (var item in compData)
            {
                var nodeName = item.Split(' ')[0].ToEnum<NodeName>();
                var r = navigator.CreateRealNode(nodeName, item);

                compNode.Nodes.Add(r);
            }

            navigator.EndUpdate();
            compNode.Expand();
        }
    }
}
