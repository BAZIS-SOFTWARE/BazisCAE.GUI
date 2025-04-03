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
    public class LoadTaskConverter : DataConverter
    {
        private List<IGroup> _dataObjectType;
        private List<string> _func;

        public LoadTaskConverter(IData obj, List<string> func, List<IGroup> groupElement)
        {
            _func = func;
            _dataObjectType = groupElement;
            var value = obj.GetInfo.Split(' ');
            dataGroupElement = groupElement;
            selectObj = obj;
            data = new Dictionary<string, string>()
            {
                { "Группа объектов", value[0] }, //combo box
                { "Вид", value[1] }, // combo box  LoadKind
                { "Направление", value[2] }, //combo box  Direction
                { "Величина, Н", value[3]}, //text box 
                { "Функция, F(t), Н - сек.", value[4]}, //combo box
                { "Старт, сек.", value[5]},
                { "Стоп, сек.", value[6]},
                { "TrajectoryInfo(default)", value[7]},
            };
        }

        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                RowProperty.CreateTextBox("Имя", NodeType.Нагрузка.ToString(), true),
                RowProperty.CreateComboBox("Вид", data["Вид"], Converters.GetEnumNames<LoadKind>().ToList()),
                RowProperty.CreateComboBox("Направление", data["Направление"],Converters.GetEnumNames<Direction>().ToList()),
                RowProperty.CreateComboBox("Группа объектов", data["Группа объектов"],_dataObjectType.Select(x => x.Name).ToList()),
                RowProperty.CreateTextBox("Величина, Н", data["Величина, Н"]),
                RowProperty.CreateComboBox("Функция, F(t), Н - сек.", data["Функция, F(t), Н - сек."],_func),
                RowProperty.CreateTextBox("Старт, сек.", data["Старт, сек."]),
                RowProperty.CreateTextBox("Стоп, сек.", data["Стоп, сек."])
            };
        }
    }
}
