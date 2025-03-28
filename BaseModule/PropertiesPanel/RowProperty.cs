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
        public bool IsReadOnly { get; }

        public RowProperty(
            string header,
            object value,
            Func<DataGridViewCell> initialization,
            Func<DataGridViewCell, object> update,
            SequenceType sequence,
            bool isReadOnly = false)
        {
            Header = header;
            Value = value;
            Initialization = initialization;
            Update = update;
            Sequence = sequence;
            IsReadOnly = isReadOnly;
        }

        /// <summary>
        /// Метод реализующий создание ячейки TextBox 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="value"></param>
        /// <param name="isReadOnly">По умолчанию ячейка доступна для редактирования</param>
        public static RowProperty CreateTextBox(string header, string value, bool isReadOnly = false)
        {
            return new RowProperty(header, value, () => new DataGridViewTextBoxCell(),
            (cell) =>
            {
                return cell.Value.ToString();
            },
            SequenceType.After, isReadOnly);
        }

        public static RowProperty CreateComboBox(string header, string value, List<string> availableValues)
        {
            return new RowProperty(header, value,
            () =>
            {
                var comboBoxCell = new DataGridViewComboBoxCell();
                comboBoxCell.Items.AddRange(availableValues.ToArray());
                comboBoxCell.Value = value;
                return comboBoxCell;
            },
            (cell) =>
            {
                return cell.Value.ToString();
            },
            SequenceType.After);
        }
    }

    /// <summary>
    /// Последовательность выполнения метода (до, после)
    /// </summary>
    public enum SequenceType
    {
        Before,
        After
    }
}
