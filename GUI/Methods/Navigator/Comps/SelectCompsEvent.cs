using BazisGUI.Navigator;
using BaseModule.PropertiesPanel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void Navigator_SelectCompsEvent()
        {
            try
            {
                var tasks = new List<string>();
                navigator.TrySearchNodes(NodeName.расчеты, out List<TreeNode> task);
                foreach (TreeNode item in task[0].Nodes)
                    tasks.Add(item.Text);

                var taskType = new List<string> { "все", "термическая", "механическая", "химическая" };

                if (selectInstruction == string.Empty)
                    selectInstruction = taskType[0];

                List<RowProperty> rows = new List<RowProperty>();
                rows.Add(new RowProperty("Тип", new DropDownPropertyValue(selectInstruction, taskType)));

                foreach (var taskName in tasks)
                {
                    bool isExe;
                    if (taskName.Split(' ')[2] == "выполнить")
                        isExe = true;
                    else
                        isExe = false;
                    if (selectInstruction == "все")
                    {
                        var name = Path.GetFileName(taskName.Split(' ')[1]);
                        rows.Add(new RowProperty($"Выполнять {name}", isExe));
                    }
                    else
                    {
                        if (taskName.Contains(selectInstruction))
                        {
                            var name = Path.GetFileName(taskName.Split(' ')[1]);
                            rows.Add(new RowProperty($"Выполнять {name}", isExe));
                        }
                    }
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
