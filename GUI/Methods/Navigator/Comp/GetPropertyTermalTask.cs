using BaseModule.PropertiesPanel;
using Project.TaskParameters;
using System.Collections.Generic;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private List<RowProperty> GetPropertyTermalTask(TermalParameters thermal)
        {
            var rows = new List<RowProperty>();
            rows.Add(new RowProperty("Макс. темп. (dTt max), C°", thermal.TermalConvergence.Is_Switched_Tm));
            if (thermal.TermalConvergence.Is_Switched_Tm)
                rows.Add(new RowProperty("Значение макс. темп.", thermal.TermalConvergence.Tm.ToString()));
            return rows;
        }
    }
}
