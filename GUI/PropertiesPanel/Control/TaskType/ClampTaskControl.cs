using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class ClampTaskControl : DataControl
    {
        private readonly List<IGroup> _dataObjectType;

        public ClampTaskControl(IData obj, List<IGroup> groupElement)
        {
            Debug.WriteLine(obj.GetInfo);
            _dataObjectType = groupElement;
            var value = obj.GetInfo.Split(' ');
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
                new RowProperty("Имя", NodeType.Закрепление.ToString(),
                () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After, true),

                new RowProperty("Группа узлов", data["Группа узлов"],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(_dataObjectType.Select(x => x.Name).ToArray());
                    comboBoxCell.Value = data["Группа узлов"];
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Вид", data["Вид"],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(Converters.GetEnumNames<ClampKind>().ToArray());
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
