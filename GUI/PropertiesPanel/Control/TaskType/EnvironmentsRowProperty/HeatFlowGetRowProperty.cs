using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using Project.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI.PropertiesPanel.Control.TaskType.EnvironmentsRowProperty
{
    //  Index: 0             1     2                           3             4            5  
    //   Name: Группа узлов        Функция, F(t), °С - сек.    Старт, сек.   Стоп, сек.
    //GetInfo: Узлы_8        *     Дюриксол.В72                0             1500         *
    public class HeatFlowGetRowProperty : EnvironmentTaskConverter
    {
        private List<string> _func;
        public HeatFlowGetRowProperty(IData obj, List<string> func, List<IGroup> groupElement)
        {
            _func = func;
            var value = obj.GetInfo.Split(' ');
            dataGroupElement = groupElement;
            selectObj = obj;
            data = new Dictionary<string, string>()
            {
                { "Группа узлов", value[0] },
                { "Коэф. теплоотдачи (default)", value[1] },
                { "Функция, F(t), °С - сек.", value[2] },
                { "Старт, сек.", value[3] },
                { "Стоп, сек.", value[4] },
                { "Траектория(default)", value[5] }
            };
        }

        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                new RowProperty("Имя", NodeType.Среда.ToString(),
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
                    comboBoxCell.Items.AddRange(dataGroupElement.Select(x => x.Name).ToArray());
                    comboBoxCell.Value = data["Группа узлов"];
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Функция, F(t), °С - сек.", data["Функция, F(t), °С - сек."],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(_func.ToArray());
                    comboBoxCell.Value = data["Функция, F(t), °С - сек."];
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
