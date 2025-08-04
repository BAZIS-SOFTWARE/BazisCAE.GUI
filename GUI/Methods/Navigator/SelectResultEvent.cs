using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Scene;
using BazisGUI.Scene.VBO;
using BazisGUI.SettingsControls;
using BazisGUI.Utilities;
using GmshApi;
using Model.GeometryObjects;
using Model.Interfaces;
using Model.Interfaces.ObjectsFinders;
using Model.MeshObjects;
using OperationalController.GmshController;
using Project.Interfaces.Tasks;
using Project.Results;
using Project.Results.IO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectResultEvent(BaseModule.Navigator.NodeName arg1, string arg2)
        {
            try
            {
                var loader = new LoadResultsFileDB();
                var times = loader.GetValues($@"{ResultDbPath}", "nodes", "Time");
                checkPlayerControl.StartValue = 0;
                checkPlayerControl.StopValue = times.Count() - 1;
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }

        }
    }
}
