using BazisGUI.Extensions;
using BazisGUI.PropertiesPanel;
using BazisGUI.Navigator;
using Project.Interfaces.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using BazisGUI.Utilities;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeTaskProperties(PropertyChangedEventArgs obj)
        {
            var clearFlag = false;
            if (Enum.TryParse(obj.Key, out TaskPropertyKeys key))
            {
                switch (key)
                {
                    case TaskPropertyKeys.Type:
                        project.ProjectType = obj.NewValue.ToEnum<TaskType>();
                        clearFlag = true;
                        break;

                    case TaskPropertyKeys.Kind:
                        project.ProjectKind = Converters.ConvertTaskKindPropertyKeysToTaskKind(obj.NewValue.ToEnum<TaskKindPropertyKeys>());
                        clearFlag = true;
                        break;

                    case TaskPropertyKeys.CheckCondValues:
                        settingsConfig.CheckCondValue = bool.Parse(obj.NewValue);
                        break;
                }

                if (clearFlag)
                {
                    List<TreeNode> tasks;
                    var search = navigator.TrySearchNodes(NodeName.Task, out tasks);
                    tasks[0].Nodes.Clear();
                }
            }
        }
    }
}
