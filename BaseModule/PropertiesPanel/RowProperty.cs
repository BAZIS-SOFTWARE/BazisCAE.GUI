using System;
using System.Runtime.CompilerServices;
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
