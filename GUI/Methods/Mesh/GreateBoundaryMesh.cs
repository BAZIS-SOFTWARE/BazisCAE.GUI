using BaseModule.Extensions;
using BaseModule.Mesh;
using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BazisGUI.Utilities;
using Model;
using Model.Interfaces;
using Model.MeshObjects;
using OperationalController.GmshController;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void наПоверхности2DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CreateBoundaryMesh(1);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        private void наПоверхности3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CreateBoundaryMesh(2);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
        public void CreateBoundaryMesh(int dim)
        {
            ObjType objType;
            if (dim == 2)
                objType = ObjType.Элемент3D;
            else if (dim == 1)
                objType = ObjType.Элемент2D;
            else
                return;
            var els = project.GetModelObjects(objType);
            if (els.Count() == 0)
                console.PrintInfo($"Модель не содержит {dim + 1}D элементов!", Color.Red);
            else
            {
                if (dim == 2)
                    objType = ObjType.Элемент2D;
                else
                    objType = ObjType.Элемент1D;

                bool resFlag;
                if (dim == 2)
                    resFlag = project.Create2DForm3D();
                else
                    resFlag = project.Create1DFrom2D();

                if (resFlag)
                {
                    var set = project.GetModelSetsInfo(objType).LastOrDefault();

                    if (set != null)
                    {
                        var nodeName = Converters.ConvertToNavigatorNodeType(set.ObjType);
                        var v = navigator.CreateVirtualNode(nodeName);
                        navigator.TrySearchNodes(nodeName, out List<TreeNode> nodes);
                        nodes.First().Nodes.Add(v);
                    }

                    var pre = project.CreateModelObjectsPresentor(set);
                    var vbo = CreateVBObject(pre);
                    VBOController.AddVbo(vbo);

                    DisplayObjects();
                }

            }
        }
    }
}
