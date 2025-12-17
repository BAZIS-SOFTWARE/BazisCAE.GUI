using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using Project.Interfaces.Tasks;
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

                var type = Converters.GetEnumNames<TaskType>();
                type.RemoveRange(0, 2); // пока уберем линейную и плоскую задачи (они не реализованы)

                rows.Add(new RowProperty("Вид",new DropDownPropertyValue(project.ProjectType, type)));

                var kinds = Converters.GetEnumNames<TaskKind>();
                kinds.RemoveRange(0, 1);// пока уберем химическую задачу (она не реализована)
                var term_mech = (TaskKind.термическая | TaskKind.механическая).ToString();
                kinds.Add(term_mech);
                rows.Add(new RowProperty("Тип",new DropDownPropertyValue(project.ProjectKind, kinds)));

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
