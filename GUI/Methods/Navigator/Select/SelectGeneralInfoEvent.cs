using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void navigator_SelectGeneralInfoEvent()
        {
            try
            {
                if (project == null)
                    return;

                
                List<RowProperty> rows = new List<RowProperty>();

                    rows.Add(new RowProperty("Имя", project.Name,true));
                    rows.Add(new RowProperty("Тип", project.Path, true));
                    // TO DO добавить комментарии
                

                propertiesPanel.DrawTable(rows);             
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
