using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class LoadTaskConverter : DataConverter
    {
        private List<string> _func;
        private LoadData _load; 
        public LoadTaskConverter(ICondData obj, List<string> func, List<IGroup> groupElement)
        {
            _load = obj as LoadData;
            _func = func;
            dataGroupElement = groupElement;
            selectObj = obj;
            data = new Dictionary<string, string>()
            {
                { "Группа объектов", _load.Group.Name }, //combo box
                { "Вид", _load.LoadKind.ToString() }, // combo box  LoadKind
                { "Направление", _load.Direction.ToString() }, //combo box  Direction
                { "Величина, Н", _load.Value.ToString()}, //text box 
                { "Функция, F(t), Н - сек.", _load.ValueFunction}, //combo box
                { "Старт, сек.", _load.StartTime.ToString()},
                { "Стоп, сек.", _load.StopTime.ToString()},
                { "TrajectoryInfo(default)", "*"},
            };
        }

        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                //RowProperty.CreateTextBox("Имя", NodeType.Нагрузка.ToString(), ValidationType.None, true),
                RowProperty.CreateComboBox("Вид", data["Вид"], Converters.GetEnumNames<LoadKind>().ToList()),
                RowProperty.CreateComboBox("Направление", data["Направление"],Converters.GetEnumNames<Direction>().ToList()),
                RowProperty.CreateComboBox("Группа объектов", data["Группа объектов"],dataGroupElement.Select(x => x.Name).ToList()),
                RowProperty.CreateTextBox("Величина, Н", data["Величина, Н"], ValidationType.FloatPositive),
                RowProperty.CreateComboBox("Функция, F(t), Н - сек.", data["Функция, F(t), Н - сек."],_func),
                RowProperty.CreateTextBox("Старт, сек.", data["Старт, сек."], ValidationType.FloatPositive),
                RowProperty.CreateTextBox("Стоп, сек.", data["Стоп, сек."], ValidationType.FloatPositive)
            };
        }

        public override void UpdateObject(string header, string newValue)
        {
            base.UpdateObject(header, newValue);
            if (header == "Вид") _load.TrySetKind(newValue);
            else if (header == "Направление") _load.TrySetDirection(newValue);
            else if (header == "Величина, Н") _load.TrySetValue(newValue);
            else if (header == "Функция, F(t), Н - сек.") _load.TrySetTimeFunction(newValue);
        }
    }
}
