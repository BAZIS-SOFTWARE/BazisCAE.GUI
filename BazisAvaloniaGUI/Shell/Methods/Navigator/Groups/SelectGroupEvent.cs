using System;
using System.Drawing;
using System.Linq;

namespace BazisAvaloniaGUI.Shell
{
    internal partial class MainWindow
    {
        private void navigator_SelectGroupEvent(int grIndex)
        {
            try
            {
                var group = project.GetModelGroup(grIndex); // закраска объектов в выделяемой группе
                using (project.BeginViewUpdate())
                {
                    project.SetSelectionColor(settingsConfig.SelectGroupColor);
                    project.ClearSelection();
                    foreach (var objType in group.Select(x => x.ObjType).Distinct())
                    {
                        var numbers = group.Where(x => x.ObjType == objType).Select(x => x.Number);
                        project.Select(objType, numbers);
                    }
                }

                var rows = GetGroupProperty(group);
                propertiesPanel.DrawTable(rows);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
