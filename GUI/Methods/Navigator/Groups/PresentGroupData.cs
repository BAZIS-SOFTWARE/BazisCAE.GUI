using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
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
            navigator.BeginUpdate();

            navigator.TrySearchNodes(NodeName.группы, out List<TreeNode> nodes);

            nodes[0].Nodes.Clear();

            foreach (var item in project.GetAllModelGroups())
            {
                var r = navigator.CreateRealNode(item.ObjType.ToString(), $"{item.Name} {item.Count}");

                nodes[0].Nodes.Add(r);
                navigator.SetContextMenu(r);
            }

            navigator.EndUpdate();
        }
    }
}
