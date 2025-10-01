using BaseModule.Extensions;
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
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace BazisGUI
{
    public partial class BaseForm
    {
       
        private void PresentObjects(TreeNode objNode, List<ObjType> types)
        {
            navigator.BeginUpdate();
            objNode.Nodes.Clear();

            foreach (ObjType objType in types)
                foreach (var item in project.GetModelSetsInfo(objType))
                {
                    if (item.NumberOfObjects > 0)
                    {
                        //var r_node = navigator.CreateRealNode(NodeName.Объем, $"{item.Name} {item.NumberOfSides}");
                        var root = Converters.ConvertToNavigatorNodeType(item.ObjType);
                        var text = $"{root} {item.Name} {item.NumberOfObjects}";
                        var node = navigator.CreateRealNode(root, text);
                        objNode.Nodes.Add(node);
                    }
                }

            navigator.EndUpdate();
            objNode.Expand();
        }       
    }
}
