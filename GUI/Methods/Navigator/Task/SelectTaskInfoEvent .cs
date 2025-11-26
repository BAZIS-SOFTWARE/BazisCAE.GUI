using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Project.Interfaces.Tasks;
using PropertiesCalculator.FunctionData;
using PropertiesCalculator.MaterialData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectTaskEvent()
        {
            try
            {
                if (project == null)
                    return;

                List<RowProperty> rows = new List<RowProperty>();

                rows.Add(new RowProperty("Вид",new DropDownPropertyValue(project.ProjectType,
           Converters.GetEnumNames<TaskType>())));

                var kinds = Converters.GetEnumNames<TaskKind>();
                var term_mech = (TaskKind.термическая | TaskKind.механическая).ToString();
                kinds.Add(term_mech);
                rows.Add(new RowProperty("Тип", new DropDownPropertyValue(project.ProjectKind, kinds)));

                if(project.MaterialsDB != null)
                    rows.Add(new RowProperty("Материалы", project.MaterialsDB.Name,true));
                if (project.FunctionsDB != null)
                    rows.Add(new RowProperty("Функции", project.FunctionsDB.Name,true));


                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
