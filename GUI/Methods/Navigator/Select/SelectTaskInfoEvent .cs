using BaseModule.Navigator;
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

                rows.Add(new RowProperty("Вид", project.ProjectType,
           Converters.GetEnumNames<TaskType>()));
                rows.Add(new RowProperty("Тип", project.ProjectKind,
Converters.GetEnumNames<TaskKind>()));

                rows.Add(new RowProperty("Материалы", project.MaterialsDB.Name,true));
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
