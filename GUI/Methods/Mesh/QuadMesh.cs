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
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
