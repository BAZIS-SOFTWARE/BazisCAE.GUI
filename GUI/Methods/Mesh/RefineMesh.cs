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
        private void уплотнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO довнедрить
            GmshController.Gmsh.Model.Mesh.Refine();

            project.ClearModelCollection(ObjType.Узел);//Удаляем только элементы сетки, геометрию не трогаем

            FitObjectsToScreen();
            DisplayObjects();
        }
    }
}
