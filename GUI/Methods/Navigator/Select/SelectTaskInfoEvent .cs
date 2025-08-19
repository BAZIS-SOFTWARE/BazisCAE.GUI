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
        private void navigator_SelectTaskInfoEvent(NodeName arg1, string arg2)
        {
            try
            {
                if (project == null)
                    return;

                
                List<RowProperty> rows = new List<RowProperty>();
                if (arg1 == NodeName.задача)
                {
                    rows.Add(new RowProperty("Вид", project.ProjectKind,
               Converters.GetEnumNames<TaskKind>()));
                    rows.Add(new RowProperty("Тип", project.ProjectType,
Converters.GetEnumNames<TaskType>()));

                    var _funcs =
                    GetDataBase<FunctionDBData>(project.FunctionsDB, project.Path).Keys.ToList();
                    var _mats =
GetDataBase<MaterialDBData>(project.MaterialsDB, project.Path).Keys.ToList();

                    rows.Add(new RowProperty("Материалы", project.MaterialsDB,_mats));
                    rows.Add(new RowProperty("Функции", project.FunctionsDB, _funcs));
                }

                propertiesPanel.DrawTable(rows);             
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
