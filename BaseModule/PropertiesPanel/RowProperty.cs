using System;
using System.CodeDom;
using System.Collections.Generic;

namespace BaseModule.PropertiesPanel
{
    public class RowProperty //: DataGridViewRow // Свойства строки
    {
        public override string ToString()
        {
            return $"{Header} {Value}";
        }
        public string Header { get; } // Заголовок
        public object Value { get; set; } // Значение
        //public DataGridViewCell Initialization { get; } //Возврашает тип ячейки (textbox, combobox)
        //public Func<DataGridViewCell, object> Update { get; } // Логика обновления значения
        public ValidationType ValidationType { get; set; }
        public List<string> AvailableValues { get; } = new List<string>();

        //public Type CellType { get; }
        //public bool IsReadOnly
        //{
        //    get { return AvailableValues == null ? false : true; }
        //}
        public bool IsReadOnly { get; set; }
        public bool IsDropDown 
        {
            get { return AvailableValues == null ? false : true; }
        }

        public RowProperty(string header, object value,List<string> availableValues) :
            this(header, value)
        {
            AvailableValues = availableValues;
        }

        public RowProperty(string header, object value, bool isReadOnly = false)
        {
            Header = header;
            Value = value;
            IsReadOnly = isReadOnly;

            if (value is string)
                ValidationType = ValidationType.Text;
            else if (value is float)
                ValidationType = ValidationType.Float;
            else if (value is Enum)
                ValidationType = ValidationType.Enum;
            else
                ValidationType = ValidationType.Color;
            IsReadOnly = isReadOnly;
        }
    }
}
