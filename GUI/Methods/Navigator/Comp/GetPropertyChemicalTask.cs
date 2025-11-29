using BazisGUI.PropertiesPanel;
using Project.TaskParameters;
using System;
using System.Collections.Generic;

namespace BazisGUI
{
    public partial class BaseForm
    {
        [Obsolete ("Не протестированно, так как химическая задача не реализована")]
        private List<RowProperty> GetPropertyChemicalTask(ChemicalParameters chemical)
        {
            var rows = new List<RowProperty>();
            rows.Add(new RowProperty("Макс.концентр. (dCt max), %", chemical.ChemicalConvergence.Is_Switched_Cm));
            if (chemical.ChemicalConvergence.Is_Switched_Cm)
                rows.Add(new RowProperty("Значение макс.концентр.", chemical.ChemicalConvergence.Cm.ToString()));

            rows.Add(new RowProperty("Начальная концентрация, %", chemical.InitConcentration.ToString()));
            return rows;
        }
    }
}
