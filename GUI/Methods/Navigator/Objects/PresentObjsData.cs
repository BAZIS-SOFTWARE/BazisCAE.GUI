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
        public void PresentGeoData()
        {
            try
            {
                navigator.BeginUpdate();

                var searchGeo = navigator.TrySearchNodes(NodeName.геометрия, out List<TreeNode> geo);

                var points = project.GetModelObjects(ObjType.Точка);

                if (points.Count() != 0)
                {
                    var types = new List<ObjType>() { ObjType.Точка, ObjType.Кривая, ObjType.Поверхность };
                    if (searchGeo)
                        PresentObjects(geo.First(), types);
                    else
                    {
                        var rn = navigator.CreateRealNode(NodeName.геометрия, "Геометрия");
                        navigator.SetContextMenu(rn);
                        PresentObjects(rn, types);
                        navigator.TrySearchNodes(NodeName.проект, out List<TreeNode> prNodes);
                        prNodes[0].Nodes.Add(rn);
                    }
                    PresentVolumeInfo();
                }

                else
                {
                    if (searchGeo)
                        geo.First().Remove();
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void PresentObjects(TreeNode geoNode, List<ObjType> types)
        {
            navigator.BeginUpdate();
            geoNode.Nodes.Clear();

            foreach (ObjType objType in types)
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

            navigator.EndUpdate();
            geoNode.Expand();
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


        public void PresentMeshData()
        {
            try
            {
                navigator.BeginUpdate();

                var searchGeo = navigator.TrySearchNodes(NodeName.сетка, out List<TreeNode> geo);

                var points = project.GetModelObjects(ObjType.Узел);

                var types = new List<ObjType>() 
                { 
                    ObjType.Узел, 
                    ObjType.Элемент1D, 
                    ObjType.Элемент2D, 
                    ObjType.Элемент3D 
                };

                if (points.Count() != 0)
                    if (searchGeo)
                    {
                        PresentObjects(geo.First(),types);
                    }
                    else
                    {
                        var rn = navigator.CreateRealNode(NodeName.сетка, "Сетка");
                        navigator.SetContextMenu(rn);
                        PresentObjects(rn,types);
                        navigator.TrySearchNodes(NodeName.проект, out List<TreeNode> prNodes);
                        prNodes[0].Nodes.Add(rn);
                    }
                else
                {
                    if (searchGeo)
                        geo.First().Remove();
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
