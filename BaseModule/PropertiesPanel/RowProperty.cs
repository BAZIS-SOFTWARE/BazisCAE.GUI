using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    public class RowProperty //: DataGridViewRow // Свойства строки
    {
        public string Header { get; } // Заголовок
        public object Value { get; set; } // Значение
        public Func<DataGridViewCell> Initialization { get; } //Возврашает тип ячейки (textbox, combobox)
        public Func<DataGridViewCell, object> Update { get; } // Логика обновления значения
        public SequenceType Sequence { get; } //before, after
        public ValidationType ValidationType { get; set; }
        public List<string> AvailableValues { get; }
        public Type CellType { get; }
        public bool IsReadOnly { get; }
        public bool IsDropDown { get; }

        public RowProperty(string header, object value, Func<DataGridViewCell> initialization, Func<DataGridViewCell, object> update, SequenceType sequence, ValidationType validationType = ValidationType.None, bool isReadOnly = false, bool isDropDown = false, List<string> availableValues = null)
        {
            Header = header;
            Value = value;
            Initialization = initialization;
            Update = update;
            Sequence = sequence;
            ValidationType = validationType;
            CellType = initialization().GetType();
            IsReadOnly = isReadOnly;
            IsDropDown = isDropDown;
            AvailableValues = availableValues ?? new List<string>();
        }

        /// <summary>
        /// Метод реализующий создание ячейки TextBox 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="value"></param>
        /// <param name="isReadOnly">По умолчанию ячейка доступна для редактирования</param>
        public static RowProperty CreateTextBox(string header, string value, ValidationType validationType = ValidationType.None, bool isReadOnly = false)
        {
            return new RowProperty(header, value, () => new DataGridViewTextBoxCell(),
            (cell) =>
            {
                return cell.Value.ToString();
            },
            SequenceType.After, validationType, isReadOnly);
        }

        public static RowProperty CreateComboBox(string header, string value, List<string> availableValues, bool isDropDown = false, ValidationType validationType = ValidationType.None)
        {
            return new RowProperty(header, value,
            () => 
            {
                var comboBoxCell = new DataGridViewComboBoxCell();
                comboBoxCell.Items.AddRange(availableValues.ToArray());
                comboBoxCell.Value = value;
                return comboBoxCell;
            },
            (cell) => cell.Value?.ToString(), SequenceType.After, validationType, false, isDropDown, availableValues);
        }
    }
}
