using Model.Interfaces;
using System;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void квадратизацияСуществующейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var cntr = (GMSHGeneralMeshControl)obj;
            //var filename = GmshController.Gmsh.Model.GetFileName();
            //var ext = Path.GetExtension(filename);
            //if (ext.Contains("igs") || ext.Contains("iges"))
            //{
                GmshController.Gmsh.Model.Mesh.Recombine();
                var error = GmshController.Gmsh.Logger.GetLastError();
                if (!string.IsNullOrEmpty(error))
                    console.PrintInfo(error, Color.Red);
                //cntr.ShowHideTabControls(3, false);
                //cntr.ClearTreeView(3);


                //TODO довнедрить!
                var objs = GmshController.GetMeshObjects();

                project.ClearModelCollection(ObjType.Узел);
            //}
        }
    }
}
