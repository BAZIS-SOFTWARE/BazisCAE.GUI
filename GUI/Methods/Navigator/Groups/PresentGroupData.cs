using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls;
using BazisGUI.Utilities;
using GmshApi;
using Model.GeometryObjects;
using Model.Interfaces;
using Model.Interfaces.ObjectsFinders;
using Model.MeshObjects;
using OperationalController.GmshController;
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
        public void PresentGroupDataOnTree()
        {
            List<TreeNode> nodes;
            var search = navigator.TrySearchNodes(NodeName.группы, out nodes);

            if (project.GetAllModelGroups().Count() != 0)
                if (search)
                {
                    PresentGroups(nodes.First());
                }
                else
                {
                    var rn = navigator.CreateRealNode(NodeName.группы, "Группы");
                    navigator.SetContextMenu(rn);
                    PresentGroups(rn);
                    navigator.TrySearchNodes(NodeName.проект, out List<TreeNode> prNodes);
                    prNodes[0].Nodes.Add(rn);
                }
            else
            {
                if (search)
                    nodes.First().Remove();
            }
        }

        private void PresentGroups(TreeNode grNode)
        {
            navigator.BeginUpdate();
            grNode.Nodes.Clear();

            foreach (var item in project.GetAllModelGroups())
            {
                var r = navigator.CreateRealNode(item.ObjType.ToString(), $"{item.Name} {item.Count}");

                grNode.Nodes.Add(r);
                navigator.SetContextMenu(r);
            }

            navigator.EndUpdate();
            grNode.Expand();
        }
    }
}
