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

            navigator.TrySearchNodes("объекты", out List<TreeNode> nodes);
            foreach (TreeNode item in nodes[0].Nodes)
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
            if (gmshController.Gmsh.Model.GetDimension() > 2)
            {
                var dimTags = gmshController.Gmsh.Model.GetEntities(3);
                navigator.TrySearchNodes(NodeName.Объемы, out List<TreeNode> nodes);
                for (var i = 0; i < dimTags.Length; i += 2)
                {
                    var dim = dimTags[i];
                    var tag = dimTags[i + 1];
                    var data = gmshController.Gmsh.Model.GetAdjacencies(dim, tag);
                    var downward = data.Item2;
                   
                    var surfNumbers = string.Join(" ", downward);

                    var name = gmshController.Gmsh.Model.GetEntityName(dim, tag);
                    if (name == "" | name == null)
                        name = $"Объем_{tag}";
                    else
                        name = name.Replace("Shapes/", "");

                    var text = $"{tag} {name}: {surfNumbers}";
                    var r_node = navigator.CreateRealNode(NodeName.Объем, text);
                    nodes[0].Nodes.Add(r_node);
                }
            }
        }
    }
}
