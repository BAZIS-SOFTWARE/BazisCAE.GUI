using System;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    public class RowProperty //: DataGridViewRow // Свойства строки
    {
        public string Header { get; set; } // Заголовок
        public object Value { get; set; } // Значение
        public Func<DataGridViewCell> Initialization { get; set; } //Возврашает тип ячейки (textbox, combobox)
        public Func<DataGridViewCell,object> Update { get; set; } // Логика обновления значения
        public SequenceType Sequence { get; } //before, after

        public RowProperty(string header, object value, Func<DataGridViewCell> initialization, Func<DataGridViewCell, object> update, SequenceType sequence)
        {
            Header = header;
            Value = value;
            Initialization = initialization;
            Update = update;
            Sequence = sequence;
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

    //public Func<object, bool> Validate { get; set; } // Валидация значения
}
