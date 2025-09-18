using BaseModule.PropertiesPanel;
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
            var rows = new List<RowProperty>
            {
                new RowProperty("Макс.концентр. (dCt max), %", chemical.ChemicalConvergence.Is_Switched_Cm),
                new RowProperty(string.Empty, chemical.ChemicalConvergence.Cm.ToString()),
                new RowProperty("Начальная концентрация, %", chemical.InitConcentration.ToString())
            };
            return rows;
        }
    }
}
