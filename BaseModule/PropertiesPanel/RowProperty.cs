using BaseModule.PropertiesPanel.DataGridViewNumericUpDown;
using System;
using System.Collections.Generic;

namespace BaseModule.PropertiesPanel
{
    //public abstract class RowProperty
    //{
    // в случае если потребуется сравнивать RowProperties
    //}
    public class RowProperty//<T> : RowProperty where T : IComparable<T> //: DataGridViewRow // Свойства строки
    {
        public override string ToString()
        {
            return $"{Header} {Value}";
        }
        public string Header { get; } // Заголовок
        public object Value { get; set; } // Значение

        public ValidationType ValidationType { get; set; }
        public List<string> AvailableValues { get; } = new List<string>();

        public bool IsReadOnly { get; set; }

        public bool IsNumericUpDown { get; set; }

        public bool IsCheckable { get; set; }
        public bool IsDropDown 
        {
            get { return AvailableValues.Count == 0 ? false : true; }
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
                ValidationType = ValidationType.None;
            else if (value is NumericUpDownValue)
            {
                ValidationType = ValidationType.None;
                IsNumericUpDown = true;
            }
            else if (value is bool bval)
            {
                ValidationType = ValidationType.None;
                IsCheckable = true;
            }

            else
                ValidationType = ValidationType.None;
        }
    }
}
