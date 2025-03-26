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
    public class HeatFlowGetRowProperty : EnvironmentTaskControl
    {
        public HeatFlowGetRowProperty(IData obj, List<string> func, List<IGroup> groupElement)
        {
            var value = obj.GetInfo.Split(' ');
            dataGroupElement = groupElement;
            selectObj = obj;
            data = new Dictionary<string, string>()
            {
                { "Группа элементов", value[0] },
                { "Функция, F(t), °С", value[2] },
                { "Старт, сек.", value[3] },
                { "Стоп, сек.", value[4] },
            };
        }
        public static List<RowProperty> GetRow(string[] data, List<string> func, List<IGroup> groupElement)
        {
            return new List<RowProperty>
            {
                new RowProperty("Имя", NodeType.Среда.ToString(),
                () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),
                
                new RowProperty("Группа узлов", data[0],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(groupElement.Select(x => x.Name).ToArray());
                    comboBoxCell.Value = data[0];
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Функция, F(t), °С - сек.", data[2],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(func.ToArray());
                    comboBoxCell.Value = data[1];
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Старт, сек.", data[3], () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Стоп, сек.", data[4], () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),
            };
        }
    }
}
