using System;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    public class RowProperty //: DataGridViewRow // Свойства строки
    {
        public string Header { get; set; } // Заголовок
        public object Value { get; set; } // Значение
        public Func<DataGridViewRow> Initialization { get; set; } //Возврашает тип ячейки (textbox, combobox)
        public Action Update { get; set; }
        public SequenceType Sequence { get; } //before, after
        public RowProperty(string header, object value, Func<DataGridViewRow> initialization, Action update, SequenceType sequence)
        {
            Header = header;
            Value = value;
            Initialization = initialization;
            Update = update;
            Sequence = sequence;
        }
    }

    public enum SequenceType //Последовательность (до, после)
    {
        Before,
        After
    }
}
