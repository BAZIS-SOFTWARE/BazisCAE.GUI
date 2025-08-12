using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces.ObjectsCollections;
using Project.Interfaces.Tasks;
using System.Collections.Generic;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetTaskKindProperty(TaskKind type)
        {
            return new List<RowProperty>
            {
               new RowProperty("Вид", type,
               Converters.GetEnumNames<TaskKind>())
            };
        }

        public List<RowProperty> GetTaskTypeProperty(TaskType type)
        {
            return new List<RowProperty>
            {
               new RowProperty("Тип",type,
               Converters.GetEnumNames<TaskType>())
            };
        }
    }
}
