using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public List<RowProperty> GetClampProperty(ClampData obj, List<IGroup> groupElement)
        {
            return new List<RowProperty>
            {
                new RowProperty("Группа узлов", obj.Group.Name,groupElement.Select(x => x.Name).ToList()),
                new RowProperty("Вид", obj.Kind, Converters.GetEnumNames<ClampKind>()),
                new RowProperty("Направление", obj.Direction,  Converters.GetEnumNames<Direction>()),
                new RowProperty("Старт, сек.", obj.StartTime),
                new RowProperty("Стоп, сек.", obj.StopTime)
            };
        }
    }
}
