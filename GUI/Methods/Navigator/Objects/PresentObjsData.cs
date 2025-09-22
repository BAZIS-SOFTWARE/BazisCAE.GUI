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
        public void PresentGeoData()
        {
            try
            {
                //navigator.BeginUpdate();

                var searchGeo = navigator.TrySearchNodes(NodeName.геометрия, out List<TreeNode> geo);

                var points = project.GetModelObjects(ObjType.Точка);

                if (points.Count() != 0)
                {
                    //var types = new List<ObjType>() { ObjType.Точка, ObjType.Кривая, ObjType.Поверхность };
                    if (searchGeo)
                    {
                        var v_node = navigator.CreateVirtualNode();
                        geo[0].Nodes.Clear();
                        geo[0].Nodes.Add(v_node);
                    }
                        //PresentObjects(geo.First(), types);
                    else
                    {
                        var rn = navigator.CreateRealNode(NodeName.геометрия, "Геометрия");
                        navigator.SetContextMenu(rn);

                        var imgIndex = navigator.GetObjectImageIndex(NodeName.геометрия);

                        rn.ImageIndex = imgIndex;
                        rn.SelectedImageIndex = imgIndex;

                        var v_node = navigator.CreateVirtualNode();
                        rn.Nodes.Add(v_node);
                        //PresentObjects(rn, types);
                        navigator.TrySearchNodes(NodeName.проект, out List<TreeNode> prNodes);
                        prNodes[0].Nodes.Add(rn);
                    }
                    //PresentVolumeInfo();
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

        public void PresentMeshData()
        {
            try
            {
                //navigator.BeginUpdate();

                var searchMesh = navigator.TrySearchNodes(NodeName.сетка, out List<TreeNode> mesh);

                var nodes = project.GetModelObjects(ObjType.Узел);

                //var types = new List<ObjType>() 
                //{ 
                //    ObjType.Узел, 
                //    ObjType.Элемент1D, 
                //    ObjType.Элемент2D, 
                //    ObjType.Элемент3D 
                //};

                if (nodes.Count() != 0)
                    if (searchMesh)
                    {
                        var v_node = navigator.CreateVirtualNode();
                        mesh[0].Nodes.Clear();
                        mesh[0].Nodes.Add(v_node);
                        //PresentObjects(mesh.First(),types);
                    }
                    else
                    {
                        var rn = navigator.CreateRealNode(NodeName.сетка, "Сетка");
                        navigator.SetContextMenu(rn);

                        var imgIndex = navigator.GetObjectImageIndex(NodeName.сетка);

                        rn.ImageIndex = imgIndex;
                        rn.SelectedImageIndex = imgIndex;

                        var v_node = navigator.CreateVirtualNode();
                        rn.Nodes.Add(v_node);

                        // Наборы будет виртуальные

                        //PresentObjects(rn,types);
                        navigator.TrySearchNodes(NodeName.проект, out List<TreeNode> prNodes);
                        prNodes[0].Nodes.Add(rn);
                    }
                else
                {
                    if (searchMesh)
                        mesh.First().Remove();
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
