using BazisGUI.Extensions;
using BazisGUI.Navigator;
using BazisGUI.Properties;
using BazisGUI.PropertiesPanel;
using BazisGUI.Utilities;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                        var taskKind = Converters.GetTaskKind(obj.LocalizedHeader.TrimStart());
                        if (obj.NewValue == "True")
                            project.ProjectKind |= taskKind;
                        else
                            project.ProjectKind &= ~taskKind;
                        clearFlag = true;
                        break;

                    case TaskPropertyKeys.CheckCondValues:
                        settingsConfig.CheckCondValue = bool.Parse(obj.NewValue);
                        break;
                }

                if (clearFlag)
                    if (navigator.TrySearchNodes(NodeName.Task, out List<TreeNode> tasks) && tasks.Count > 0)
                        tasks[0].Nodes.Clear();
            }
        }
    }
}
