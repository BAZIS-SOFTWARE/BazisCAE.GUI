using BaseModule.Extensions;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using GmshApi;
using Model.Interfaces;
using OperationalController;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
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
