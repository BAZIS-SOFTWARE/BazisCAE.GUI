using BaseModule.Navigator;
using BaseModule.PropertiesPanel;
using BazisGUI.Utilities;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using Project;
using Project.Interfaces.Tasks;
using Project.Tasks;
using PropertiesCalculator.MaterialData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI.PropertiesPanel.Control.TaskType
{
    public class MatTaskControl : DataControl
    {
        //  Index: 0                   1            2            3           4
        //   Name: Группа элементов    Материал     Старт, сек.  Стоп, сек.
        //GetInfo: Элементы3D_3        Сталь_20ХМ   0            1500        *,

        private readonly List<string> _mat;
        private readonly List<IGroup> _dataObjectType;

        public MatTaskControl(IData obj, List<string> mat, List<IGroup> groupElement)
        {
            _dataObjectType = groupElement;
            _mat = mat;
            var value = obj.GetInfo.Split(' ');
            dataGroupElement = groupElement;
            selectObj = obj;
            data = new Dictionary<string, string>()
            {
                { "Группа элементов", value[0] },
                { "Материал", value[1]},
                { "Старт, сек.", value[2]},
                { "Стоп, сек.", value[3]},
            };
        }
        public override List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>
            {
                new RowProperty("Имя", NodeType.Материал.ToString(),
                () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After, true),

                new RowProperty("Группа элементов", data["Группа элементов"],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(_dataObjectType.Select(x => x.Name).ToArray());
                    comboBoxCell.Value = data["Группа элементов"];
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Материал", data["Материал"],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(_mat.ToArray());
                    comboBoxCell.Value = data["Материал"];
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
