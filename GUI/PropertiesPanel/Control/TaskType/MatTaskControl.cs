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
        //Name return - Материал
        private string[] _data;
        private readonly string _dataRow;
        private readonly List<string> _mat;
        private readonly List<IGroup> _dataObjectType;
        private IData _selectObj;
        public MatTaskControl(IData obj, List<string> mat, List<IGroup> groupElement)
        {
            _dataObjectType = groupElement;
            _dataRow = obj.GetInfo;
            _selectObj = obj;
            _mat = mat;
            _data = _dataRow.Split(' ');
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
                SequenceType.After),

                new RowProperty("Группа элементов", _data[0],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(_dataObjectType.Select(x => x.Name).ToArray());
                    comboBoxCell.Value = _data[0];
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Материал", _data[1],
                () =>
                {
                    var comboBoxCell = new DataGridViewComboBoxCell();
                    comboBoxCell.Items.AddRange(_mat.ToArray());
                    comboBoxCell.Value = _data[1];
                    return comboBoxCell;
                },
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Старт, сек.", _data[2], () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),

                new RowProperty("Стоп, сек.", _data[3], () => new DataGridViewTextBoxCell(),
                (cell) =>
                {
                    return cell.Value;
                },
                SequenceType.After),
            };
        }

        public override void UpdateObject(PropertyChangedEventArgs e)
        {
            if (e.Header == "Группа элементов") SetSelectedValue(e, 0);
            else if (e.Header == "Материал") SetSelectedValue(e, 1);
            else if (e.Header == "Старт, сек.") SetSelectedValue(e, 2);
            else if (e.Header == "Стоп, сек.") SetSelectedValue(e, 3);
        }

        private void SetSelectedValue(PropertyChangedEventArgs e,int count)
        {
            _data[count] = e.NewValue.ToString();
            var set = string.Join(" ", _data);
            if (count == 0)
            {
                var k = _selectObj as IValuableData;
                var group = _dataObjectType.Find(x => x.Name == e.NewValue.ToString());
                k.Group = group;
            }
            _selectObj.SetInfo(set);
        }
    }
}
