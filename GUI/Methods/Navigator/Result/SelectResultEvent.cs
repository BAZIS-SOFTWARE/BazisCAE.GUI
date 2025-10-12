using BaseModule.PropertiesPanel;
using ResultDB.IO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectResultEvent(BaseModule.Navigator.NodeName arg1, string arg2)
        {
            try
            {
                var row = new RowProperty("Результат", arg2);
                propertiesPanel.DrawTable(new List<RowProperty>() { row });

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
