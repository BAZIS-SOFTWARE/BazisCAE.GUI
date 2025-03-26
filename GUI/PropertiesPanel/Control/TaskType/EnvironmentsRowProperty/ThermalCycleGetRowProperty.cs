using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using Model.Interfaces;
using Project.Interfaces.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI.PropertiesPanel.Control.TaskType.EnvironmentsRowProperty
{
    public  class ThermalCycleGetRowProperty : EnvironmentTaskControl
    {
        //  Index: 0                   1                         2                  3            4            5
        //   Name: Группа элементов    Коэф. теплоотдачи, Вт/мм2 Температура среды, Старт, сек.  Стоп, сек.
        //GetInfo: air                 Коэф.теплоотдачи.воздух   20                 0            1500         *
        private List<string> _func;
        public ThermalCycleGetRowProperty(IData obj, List<string> func, List<IGroup> groupElement) 
        {
            _func = func;
            var value = obj.GetInfo.Split(' ');
            dataGroupElement = groupElement;
            selectObj = obj;
            data = new Dictionary<string, string>()
            {
                { "Группа элементов", value[0] },
                { "Коэф. теплоотдачи, Вт/мм2", value[1] },
                { "Температура среды", value[2] },
                { "Старт, сек.", value[3] },
                { "Стоп, сек.", value[4] },
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
                SequenceType.After),

                new RowProperty("Группа элементов", data["Группа элементов"],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(dataGroupElement.Select(x => x.Name).ToArray());
                    comboBoxCell.Value = data["Группа элементов"];
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Коэф. теплоотдачи, Вт/мм2", data["Коэф. теплоотдачи, Вт/мм2"],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(_func.ToArray());
                    comboBoxCell.Value = data["Коэф. теплоотдачи, Вт/мм2"];
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Температура среды", data["Температура среды"], () => new DataGridViewTextBoxCell(),
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
