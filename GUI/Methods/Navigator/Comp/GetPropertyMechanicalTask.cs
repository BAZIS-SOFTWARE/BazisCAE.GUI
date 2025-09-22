using BaseModule.PropertiesPanel;
using Project.TaskParameters;
using System.Collections.Generic;

namespace BazisGUI
{

    public partial class BaseForm
    {
        private List<RowProperty> GetPropertyMechanicalTask(MechanicalParameters mechanical) 
        {
            var rows = new List<RowProperty>
            {
                new RowProperty("Макс. разница dU, >0", mechanical.MechanicalConvergence.DUm.ToString()),
                new RowProperty("Макс. перемещения U, >0", mechanical.MechanicalConvergence.Is_Switched_Um)
            };
            if (mechanical.MechanicalConvergence.Is_Switched_Um)
                rows.Add(new RowProperty("Значение макс. перемещения U", mechanical.MechanicalConvergence.Um.ToString()));
            rows.Add(new RowProperty("Пласт. деформации Si/St, >1", mechanical.MechanicalConvergence.Is_Physically_NonLinear));
            if(mechanical.MechanicalConvergence.Is_Physically_NonLinear)
                rows.Add(new RowProperty("Значение пласт. деформации Si/St", mechanical.MechanicalConvergence.PlasticityCriterion.ToString()));
            return rows;
        }
    }
}
