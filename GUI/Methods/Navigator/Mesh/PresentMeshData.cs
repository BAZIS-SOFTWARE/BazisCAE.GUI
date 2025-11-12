using BaseModule.Extensions;
using BazisGUI.Navigator;
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
                var searchMesh = navigator.TrySearchNodes(NodeName.сетка, out List<TreeNode> mesh);

                var nodes = project.GetModelObjects(ObjType.Узел);

                // Наборы будут виртуальные
                if (nodes.Count() != 0)
                    if (searchMesh)
                    {
                        var v_node = navigator.CreateVirtualNode();
                        mesh[0].Nodes.Clear();
                        mesh[0].Nodes.Add(v_node);
                    }
                    else
                    {
                        var rn = navigator.CreateRealNode(NodeName.сетка, "Сетка");

                        var v_node = navigator.CreateVirtualNode();
                        rn.Nodes.Add(v_node);

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
