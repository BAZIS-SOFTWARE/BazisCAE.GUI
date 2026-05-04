using BazisGUI.PropertiesPanel;
using Project.TaskParameters;
using System;
using System.Collections.Generic;

namespace BazisGUI
{
    public partial class BaseForm
    {
        enum ChemicalTaskPropertyKeys { MaxConсentration, MaxConсentrationValue, InitialConcentration }
        [Obsolete ("Не протестированно, так как химическая задача не реализована")]
        private List<RowProperty> GetPropertyChemicalTask(ChemicalParameters chemical)
        {
            var rows = new List<RowProperty>();
            rows.Add(new RowProperty(ChemicalTaskPropertyKeys.MaxConсentration.ToString(), Properties.Resources.МаксКонцентрDCtMax, chemical.ChemicalConvergence.Is_Switched_Cm));
            if (chemical.ChemicalConvergence.Is_Switched_Cm)
                rows.Add(new RowProperty(ChemicalTaskPropertyKeys.MaxConсentrationValue.ToString(), Properties.Resources.ЗначениеМаксКонцентр, chemical.ChemicalConvergence.Cm.ToString()));

            rows.Add(new RowProperty(ChemicalTaskPropertyKeys.InitialConcentration.ToString(), BazisGUI.Properties.Resources.НачальнаяКонцентрация, chemical.InitConcentration.ToString()));
            return rows;
        }
    }
}
