using System;

namespace BaseModule.PropertiesPanel
{
    public class PropertyChangedEventArgs : EventArgs
    {
        public string Header { get; set; }
        public string NewValue { get; set; }
        public string OldValue { get; }

        public PropertyChangedEventArgs(string header, string newValue, string oldValue)
        {
            Header = header;
            NewValue = newValue;
            OldValue = oldValue;
        }
    }
}
