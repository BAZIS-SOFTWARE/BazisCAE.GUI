using BaseModule.PropertiesPanel.DataGridViewNumericUpDown;
using System;
using System.Collections.Generic;

namespace BaseModule.PropertiesPanel
{

    //public abstract class RowProperty
    //{
    // может быть когда-нибудь понадобиться для обобщения
    //}
    public class RowProperty//<T> : RowProperty //where T : IComparable<T> //: DataGridViewRow // Свойства строки
    {
        public string Header { get; internal set; } // Заголовок
        public override string ToString()
        {
            return $"{Header} {Value}";
        }
        public object Value { get; set; } // Значение

        public ValidationType ValidationType { get; set; } = ValidationType.None;
        
        public bool IsReadOnly { get; set; }

        //public bool IsNumericUpDown { get; set; }

        //public bool IsCheckable { get; set; }
        //public bool IsDropDown 
        //{
        //    get { return AvailableValues.Count == 0 ? false : true; }
        //}

        //public RowProperty(string header, object value,List<string> availableValues) :
        //    this(header, value)
        //{
        //    AvailableValues = availableValues;
        //}

        public RowProperty(string header, object value, bool isReadOnly = false)
        {
            Header = header;
            Value = value;
            IsReadOnly = isReadOnly;

            if (value is string)
                ValidationType = ValidationType.Text;
            else if (value is float)
                ValidationType = ValidationType.Float;
        }
    }
}
