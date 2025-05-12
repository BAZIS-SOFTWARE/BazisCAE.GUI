using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class ClampTaskConverter : DataConverter
    {
        private ClampData _clamp;
        public ClampTaskConverter(IPhysicalData obj, List<IGroup> groupElement)
        {
            _clamp = obj as ClampData;
            selectObj = obj;
            dataGroupElement = groupElement;
            
            data = new Dictionary<string, string>()
            {
                { "Группа узлов", _clamp.Group.Name.ToString() },
                { "Вид", _clamp.ClampKind.ToString()},
                { "Направление", _clamp.Direction.ToString()},
                { "Функция, F(u) , Н.мм - у.ед.(default)", _clamp.ClampFunction},
                { "Старт, сек.", _clamp.StartTime.ToString()},
                { "Стоп, сек.", _clamp.StopTime.ToString()},
                { "Траектория(default)", "default"}
            };
        }
        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                RowProperty.CreateTextBox("Имя", NodeType.Закрепление.ToString(), ValidationType.Text),
                RowProperty.CreateComboBox("Группа узлов", data["Группа узлов"], dataGroupElement.Select(x => x.Name).ToList()),
                RowProperty.CreateComboBox("Вид", data["Вид"], Converters.GetEnumNames<ClampKind>().ToList()),
                RowProperty.CreateComboBox("Направление", data["Направление"], Converters.GetEnumNames<Direction>().ToList()),
                RowProperty.CreateTextBox("Старт, сек.", data["Старт, сек."], ValidationType.FloatPositive),
                RowProperty.CreateTextBox("Стоп, сек.", data["Стоп, сек."], ValidationType.FloatPositive)
            };
        }

        public override void UpdateObject(string header, string newValue)
        {
            base.UpdateObject(header, newValue);

            if(header == "Направление")
            {
                _clamp.Direction = Converters.StringToEnum<Direction>(newValue);
            }
            //if (header == "Вид") _clamp.ClampKind = Converters.StringToEnum<ClampKind>(newValue);
            //selectObj = _clamp;
        }
    }
}
