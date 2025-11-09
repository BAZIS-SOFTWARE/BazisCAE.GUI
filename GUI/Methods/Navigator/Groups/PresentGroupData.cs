using BazisGUI.Navigator;
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
using System.Xml.Linq;

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
                    //navigator.SetContextMenu(rn);
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
                //var nodeName = Converters.ConvertToNavigatorNodeType(item.ObjType);
                NodeName nodeName;

                if (item.ObjType == ObjType.Узел)
                    nodeName = NodeName.группаУзлов;
                else
                    nodeName = NodeName.группаЭлементов;

                var r = navigator.CreateRealNode(nodeName, $"{item.Name} {item.Count}");
                //var ind = navigator.GetObjectImageIndex(nodeName);
                //r.ImageIndex = ind;
                //r.SelectedImageIndex = ind;

                grNode.Nodes.Add(r);
                //navigator.SetContextMenu(r);
            }

            navigator.EndUpdate();
            grNode.Expand();
        }
    }
}
