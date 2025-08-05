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
        public List<RowProperty> GetLoadProperty(LoadData obj, List<string> func, List<IGroup> groupElement)
        {
            return new List<RowProperty>
            {
                //RowProperty.new RowProperty("Имя", NodeType.Нагрузка.ToString(), ValidationType.None, true),
                new RowProperty("Вид", obj.Kind, Converters.GetEnumNames<LoadKind>()),
                new RowProperty("Направление", obj.Direction,Converters.GetEnumNames<Direction>()),
                new RowProperty("Группа объектов", obj.Group.Name,groupElement.Select(x => x.Name).ToList()),
                new RowProperty("Величина, Н", obj.Value),
                new RowProperty("Функция, F(t), Н - сек.", obj.TimeFunction,func),
                new RowProperty("Старт, сек.", obj.StartTime),
                new RowProperty("Стоп, сек.", obj.StopTime)
            };
        }
    }
}
