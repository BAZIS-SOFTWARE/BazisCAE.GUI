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

namespace BazisGUI
{
    public partial class BaseForm
    {
        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void наПоверхностиГеометрииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteGMSHMeshObjects(ObjType.Узел);
                project.ClearModelCollection(ObjType.Узел);
                project.GenerateMesh(2, GmshController);

                //gmshController.Gmsh.Model.Mesh.Generate(3);
                //var nds = gmshController.GetNodes();

                var error = GmshController.Gmsh.Logger.GetLastError();
                if (!string.IsNullOrEmpty(error))
                    console.PrintInfo(error, Color.Red);

                DeleteVBObjsByObjsType(ObjType.Узел);
                CreateVBObjsByObjsType(ObjType.Узел);
                DeleteVBObjects("Элементы");
                CreateVBObjects("Элементы");
                PresentMeshData();
                PresentModelObjectsForSelection();
                FitObjectsToScreen();
                DisplayObjects();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
                return;
            }
        }
    }
}
