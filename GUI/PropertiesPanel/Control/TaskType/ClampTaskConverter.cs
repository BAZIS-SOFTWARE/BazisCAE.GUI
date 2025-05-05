using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class ClampTaskConverter : DataConverter
    {
        private readonly List<IGroup> _dataObjectType;

        public ClampTaskConverter(IPhysicalData obj, List<IGroup> groupElement)
        {
            _dataObjectType = groupElement;
            var value = obj.ToString().Split(':')[1].Split(' ');
            dataGroupElement = groupElement;
            selectObj = obj;
            data = new Dictionary<string, string>()
            {
                { "Группа узлов", value[0] },
                { "Вид", value[1]},
                { "Направление", value[2]},
                { "Функция, F(u) , Н.мм - у.ед.(default)", value[3]},
                { "Старт, сек.", value[4]},
                { "Стоп, сек.", value[5]},
                { "Траектория(default)", value[6]}
            };
        }
        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                RowProperty.CreateTextBox("Имя", NodeType.Закрепление.ToString(), ValidationType.Text),
                RowProperty.CreateComboBox("Группа узлов", data["Группа узлов"], _dataObjectType.Select(x => x.Name).ToList()),
                RowProperty.CreateComboBox("Вид", data["Вид"], Converters.GetEnumNames<ClampKind>().ToList()),
                RowProperty.CreateComboBox("Направление", data["Направление"], Converters.GetEnumNames<Direction>().ToList()),
                RowProperty.CreateTextBox("Старт, сек.", data["Старт, сек."], ValidationType.FloatPositive),
                RowProperty.CreateTextBox("Стоп, сек.", data["Стоп, сек."], ValidationType.FloatPositive)
            };
        }

    }
}
