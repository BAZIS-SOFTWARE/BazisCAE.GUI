using System;
using System.Data;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    public class RowProperty : DataGridViewRow
    {
        public string Header { get; set; } 
        public object Value { get; set; } 
        public Func<DataGridViewCell ,object> UpdateValue { get; set; }

        public RowProperty(string header, object value, Func<DataGridViewCell, object> updateValue)
        {
            Header = header;
            Value = value;
            UpdateValue = updateValue;
        }
    }
}
