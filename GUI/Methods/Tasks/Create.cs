using BaseModule.Extensions;
using BazisGUI.Navigator;
using BaseModule.PropertiesPanel;
using BaseModule.Tasks.BasicAdvisorControls.Events;
using BazisGUI.Utilities;
using Geometry;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using PropertiesCalculator.MaterialData;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void создатьЗадачуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<TreeNode> tasks;
                var search = navigator.TrySearchNodes(NodeName.задача, out tasks);

                if (project == null)
                    throw new Exception("Создайте или загрузите проект или сетку");

                if (!search)
                {
                    var rn = navigator.CreateRealNode(NodeName.задача, "Задача");
                    rn.ImageIndex = 14;
                    rn.SelectedImageIndex = 14;

                    //navigator.SetContextMenu(rn);

                    navigator.TrySearchNodes(NodeName.проект, out List<TreeNode> prNodes);
                    prNodes[0].Nodes.Add(rn);
                }

            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
