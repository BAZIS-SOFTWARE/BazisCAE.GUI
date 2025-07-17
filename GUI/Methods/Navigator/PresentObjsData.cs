using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
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
        public void PresentObjectsDataOnTree(IObjectsData objectsData)
        {
            navigator.BeginUpdate();

            navigator.TrySearchNodes("объекты", out List<TreeNode> nodes);
            foreach (TreeNode item in nodes[0].Nodes)
                item.Nodes.Clear();

            foreach (ObjType objType in Enum.GetValues(typeof(ObjType)))
                foreach (var item in objectsData.GetSetsInfo(objType))
                {
                    if (item.NumberOfObjects > 0)
                    {
                        //if(item.ObjType == ObjType.Узел)
                        //    nodes[0].Nodes[NodeType.Узлы.ToString()]
                        var root = Converters.ConvertToNavigatorNodeType(item.ObjType);
                        navigator.TryCreateNode(root.ToString(), item.Name, $"{item.Name} {item.NumberOfObjects}", NodeKind.virt);
                    }
                }
            navigator.EndUpdate();
        }
    }
}
