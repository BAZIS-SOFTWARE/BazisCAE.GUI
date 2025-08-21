using BaseModule.Extensions;
using BaseModule.PropertiesPanel;
using Project.Interfaces.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void ChangeTaskProperties(PropertyChangedEventArgs obj)
        {
            if(obj.Header == "Вид")
                project.ProjectType = obj.NewValue.ToEnum<TaskType>();
            else if(obj.Header == "Тип")
                project.ProjectKind = obj.NewValue.ToEnum<TaskKind>();
            else if(obj.Header == "Материалы")
                project.MaterialsDB = obj.NewValue;
            else if (obj.Header == "Функции")
                project.FunctionsDB = obj.NewValue;
        }
    }
}
