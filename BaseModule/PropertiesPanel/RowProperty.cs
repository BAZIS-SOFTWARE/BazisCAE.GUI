using System;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    public class RowProperty : DataGridViewRow
    {
        public string Header { get; set; } 
        public object Value { get; set; } 
        public Action UpdateValue { get; set; } //Уведомить что значение свойства поменялось

        public RowProperty(string header, object value, Action updateValue)
        {
            Header = header;
            Value = value;
            UpdateValue = updateValue;
        }
    }
}
