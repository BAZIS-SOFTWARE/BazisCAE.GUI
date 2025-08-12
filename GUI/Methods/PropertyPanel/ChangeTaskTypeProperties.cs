using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using Project.Interfaces.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeTaskTypeProperties(PropertyChangedEventArgs obj)
        {
            /*
             TO DO
            обратиться к выбранному узлу дерева navigator.SelectedNode.Text
             */
            project.ProjectType = obj.NewValue.ToEnum<TaskType>();
        }

        private void ChangeTaskKindProperties(PropertyChangedEventArgs obj)
        {
            project.ProjectKind = obj.NewValue.ToEnum<TaskKind>();
        }
    }
}
