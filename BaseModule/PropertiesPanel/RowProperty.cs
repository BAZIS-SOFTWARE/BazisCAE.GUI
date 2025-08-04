using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    public class RowProperty //: DataGridViewRow // Свойства строки
    {
        public string Header { get; } // Заголовок
        public object Value { get; set; } // Значение
        //public DataGridViewCell Initialization { get; } //Возврашает тип ячейки (textbox, combobox)
        //public Func<DataGridViewCell, object> Update { get; } // Логика обновления значения
        public SequenceType Sequence { get; } //before, after
        public ValidationType ValidationType { get; set; }
        public List<string> AvailableValues { get; }
        //public Type CellType { get; }
        public bool IsReadOnly { get; }
        public bool IsDropDown { get; }

        public RowProperty(string header, object value, SequenceType sequence, ValidationType validationType = ValidationType.None, bool isReadOnly = false, bool isDropDown = false, List<string> availableValues = null)
        {
            Header = header;
            Value = value;
            //Initialization = initialization;
            //Update = update;
            Sequence = sequence;
            ValidationType = validationType;
            //CellType = initialization.GetType();
            IsReadOnly = isReadOnly;
            IsDropDown = isDropDown;
            AvailableValues = availableValues ?? new List<string>();
        }
    }
}
