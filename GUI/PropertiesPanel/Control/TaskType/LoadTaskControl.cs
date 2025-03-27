using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class LoadTaskControl : DataControl
    {
        private List<IGroup> _dataObjectType;
        private List<string> _func;

        public LoadTaskControl(IData obj, List<string> func, List<IGroup> groupElement)
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
                new RowProperty("Имя", NodeType.Нагрузка.ToString(),
                () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After, true),

                new RowProperty("Вид", data["Вид"],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(Converters.GetEnumNames<LoadKind>().ToArray());
                    comboBoxCell.Value = data["Вид"];
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Направление", data["Направление"],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(Converters.GetEnumNames<Direction>().ToArray());
                    comboBoxCell.Value = data["Направление"];
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Группа объектов", data["Группа объектов"],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(_dataObjectType.Select(x => x.Name).ToArray());
                    comboBoxCell.Value = data["Группа объектов"];
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Величина, Н", data["Величина, Н"], () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Функция, F(t), Н - сек.", data["Функция, F(t), Н - сек."],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(_func.ToArray());
                    comboBoxCell.Value = data["Функция, F(t), Н - сек."];
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Старт, сек.", data["Старт, сек."], () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Стоп, сек.", data["Стоп, сек."], () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),
            };
        }
    }
}
