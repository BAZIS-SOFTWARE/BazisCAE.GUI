using BazisGUI.Properties;
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
        enum TaskPropertyKeys { Type, Kind, Materials, Functions, CheckCondValues }
        public enum TaskKindPropertyKeys { Chemical, Termal, Mechanical, Termo_mechanical }
        private void navigator_SelectTaskEvent()
        {
            try
            {
                if (project == null)
                    return;

                List<RowProperty> rows = new List<RowProperty>();

                var type = Converters.GetEnumNames<TaskType>();
                //type.RemoveRange(0, 2); // пока уберем линейную и плоскую задачи (они не реализованы)

                rows.Add(new RowProperty(TaskPropertyKeys.Type.ToString(),
                    Resources.Header_task_type,
                    new DropDownPropertyValue(project.ProjectType, type)));

                var kinds = Converters.GetEnumNames<TaskKindPropertyKeys>();
                //kinds.RemoveRange(0, 1);// пока уберем химическую задачу (она не реализована)
                //var term_mech = (TaskKind.термическая | TaskKind.механическая).ToString();
                //kinds.Add(term_mech);

                rows.Add(new RowProperty(TaskPropertyKeys.Kind.ToString(),
                    Resources.Headers_task_kind,
                    new DropDownPropertyValue(Converters.ConvertTaskKindToTaskKindPropertyKeys(project.ProjectKind), kinds)));

                if(project.MaterialsDB != null)
                    rows.Add(new RowProperty(TaskPropertyKeys.Materials.ToString(),
                        Resources.Header_task_materials,
                        project.MaterialsDB.Name,true));

                if (project.FunctionsDB != null)
                    rows.Add(new RowProperty(TaskPropertyKeys.Functions.ToString(),
                        Resources.Header_task_functions,
                        project.FunctionsDB.Name,true));

                rows.Add(new RowProperty(TaskPropertyKeys.CheckCondValues.ToString(),
                    Resources.Header_task_checkCondValues, settingsConfig.CheckCondValue));
                
                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
