using BazisGUI.Extensions;
using BazisGUI.PropertiesPanel;
using BazisGUI.Navigator;
using Project.Interfaces.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeTaskProperties(PropertyChangedEventArgs obj)
        {
            var clearFlag = false;
            if(obj.Header == "Вид")
            {
                project.ProjectType = obj.NewValue.ToEnum<TaskType>();
                clearFlag = true;
            }
                
            else if(obj.Header == "Тип")
            {
                project.ProjectKind = obj.NewValue.ToEnum<TaskKind>();
                clearFlag = true;
            }

            else if (obj.Header == "Проверка значений условий")
            {
                settingsConfig.CheckCondValue = bool.Parse(obj.NewValue);
            }

            if (clearFlag)
            {
                List<TreeNode> tasks;
                var search = navigator.TrySearchNodes(NodeName.задача, out tasks);
                tasks[0].Nodes.Clear();
            }

        }
    }
}
