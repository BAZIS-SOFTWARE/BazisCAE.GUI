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
        public void PresentObjectsDataOnTree()
        {
            navigator.BeginUpdate();

            navigator.TrySearchNodes(NodeName.геометрия, out List<TreeNode> geo);
            foreach (TreeNode item in geo[0].Nodes)
                item.Nodes.Clear();

            navigator.TrySearchNodes(NodeName.сетка, out List<TreeNode> mesh);
            foreach (TreeNode item in mesh[0].Nodes)
                item.Nodes.Clear();

            foreach (ObjType objType in Enum.GetValues(typeof(ObjType)))
                foreach (var item in project.GetModelSetsInfo(objType))
                {
                    if (item.NumberOfObjects > 0)
                    {
                        //if(item.ObjType == ObjType.Узел)
                        //    nodes[0].Nodes[NodeType.Узлы.ToString()]
                        var root = Converters.ConvertToNavigatorNodeType(item.ObjType);
                        navigator.TryCreateNode(root.ToString(), root.ToString(), $"{root} {item.NumberOfObjects}", NodeKind.virt);
                    }
                }

            PresentVolumeInfo();

            navigator.EndUpdate();
        }
        private void PresentVolumeInfo()
        {
            navigator.TrySearchNodes(NodeName.Объемы, out List<TreeNode> nodes);
            foreach (var item in project.GetModelVolumes())
            {
                var r_node = navigator.CreateRealNode(NodeName.Объем, $"{item.Name} {item.NumberOfSides}");
                nodes[0].Nodes.Add(r_node);
            }      
        }
    }
}
