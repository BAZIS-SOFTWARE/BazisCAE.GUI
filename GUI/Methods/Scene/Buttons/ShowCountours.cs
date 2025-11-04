using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using BaseModule;
using System.Windows.Forms;
using Model.Interfaces;
using System.Linq;
using Model.Interfaces.MeshObjects;

namespace BazisGUI
{
    public partial class BaseForm
    {

        private void btnBorder_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                if (!bool.Parse(btn.Tag.ToString()))
                {
                    btn.Tag = true;
                    var surfElems = project.ModelData.ObjectData.GetAllElements().Where(x => x is ISurfaceElement).
            Select(x => (ISurfaceElement)x);
                    var linesNodes = project.FindBoundaryEdges();
                    var edges = project.CreateBoundaryEdges(linesNodes);
                    var linePresenter = presentersCreator.CreateLineObjectsPresenter(edges);
                    linePresenter.Name = "Boundary";
                    var vbo = CreateVBObject(linePresenter);
                    VBOController.AddVbo(vbo);
                }
                else
                {
                    btn.Tag = false;
                    VBOController.DeleteVBObjects("Boundary");
                }
                    
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
