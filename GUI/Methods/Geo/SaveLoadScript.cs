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
        private void загрузитьgeoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var file = GmshController.Gmsh.Model.GetFileName();

                var changed = Path.ChangeExtension(file, "gscript");

                project.LoadSMF(changed);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }

        private void сформироватьgeoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var file = GmshController.Gmsh.Model.GetFileName();

                var changed = Path.ChangeExtension(file, "gscript");
                
                project.SaveSMF(changed);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
