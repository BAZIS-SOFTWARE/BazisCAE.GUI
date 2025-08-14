using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectGeneralInfoEvent(NodeName arg1, string arg2)
        {
            try
            {
                if (project == null)
                    return;

                
                List<RowProperty> rows = new List<RowProperty>();
                if (arg1 == NodeName.вид)
                {
                    /* TO DO  
                    1. Преобразовать arg2 в нужный enum (TaskKind)
                    2. Сформировать RowProperty со списком перечислителей
                    3. Добавить RowProperty в rows
                    */
                    var selectedTaskKind = project.ProjectKind;
                    rows = GetTaskKindProperty(selectedTaskKind);

                }
                else if (arg1 == NodeName.тип)
                {
                    /* TO DO
                    1. Преобразовать arg2 в нужный enum (TaskType)
                    2. Сформировать RowProperty со списком перечислителей
                    3. Добавить RowProperty в rows
                    */
                    var selectedTaskType = project.ProjectType;
                    rows = GetTaskTypeProperty(selectedTaskType);
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
