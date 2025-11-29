using System;

namespace BazisGUI.PropertiesPanel
{
    public class PropertyChangedEventArgs : EventArgs
    {
        public string Header { get; set; }
        public string NewValue { get; set; }
        public string OldValue { get; }
        public string ObjInfo { get; internal set; }
        public int Tag { get; internal set; }

        public PropertyChangedEventArgs(string header, string newValue, string oldValue)
        {
            Header = header;
            NewValue = newValue;
            OldValue = oldValue;
        }
    }
}
