using System;
using System.CodeDom;
using System.Collections.Generic;

namespace BaseModule.PropertiesPanel
{
    public class RowProperty //: DataGridViewRow // Свойства строки
    {
        public string Header { get; } // Заголовок
        public object Value { get; set; } // Значение
        //public DataGridViewCell Initialization { get; } //Возврашает тип ячейки (textbox, combobox)
        //public Func<DataGridViewCell, object> Update { get; } // Логика обновления значения
        public ValidationType ValidationType { get; set; }
        public List<string> AvailableValues { get; }
        //public Type CellType { get; }
        public bool IsReadOnly
        {
            get { return AvailableValues == null ? false : true; }
        }
        public bool IsDropDown 
        {
            get { return AvailableValues == null ? false : true; }
        }

        public RowProperty(string header, object value, List<string> availableValues = null)
        {
            Header = header;
            Value = value;

            if (value is string)
                ValidationType = ValidationType.Text;
            else if(value is float)
                ValidationType = ValidationType.Float;
            else if (value is Enum)
                ValidationType = ValidationType.Enum;
            else
                ValidationType = ValidationType.Color;
            //Initialization = initialization;
            //Update = update;

            //CellType = initialization.GetType();
            AvailableValues = availableValues ?? new List<string>();
        }
    }
}
