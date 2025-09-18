using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Project.TaskParameters;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private GeneralParameters parameters;
        private void navigator_SelectTaskEvent(NodeName arg1, string arg2)
        {
            EditTSFFile(arg2.Split(' ')[1]);
            try
            {
                parameters = ReadTaskParametersFromFile(arg2.Split(' ')[1]);
                List<RowProperty> rows = new List<RowProperty>();
                if (parameters is ChemicalParameters cmp) 
                    rows = GetPropertyChemicalTask(cmp);
                else if (parameters is MechanicalParameters mhp)
                    rows = GetPropertyMechanicalTask(mhp);

                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
