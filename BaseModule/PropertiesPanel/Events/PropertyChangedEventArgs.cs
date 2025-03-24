using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule.PropertiesPanel
{
    public class PropertyChangedEventArgs : EventArgs
    {
        public string Header { get; set; }
        public object NewValue { get; set; }
        public object OldValue { get; }

        public PropertyChangedEventArgs(string header, object newValue, object oldValue)
        {
            Header = header;
            NewValue = newValue;
            OldValue = oldValue;
        }
    }
}
