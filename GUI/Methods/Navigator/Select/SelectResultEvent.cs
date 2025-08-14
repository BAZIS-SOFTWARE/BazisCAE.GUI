using Project.Results.IO;
using System;
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
