using System;
using System.Collections.Generic;

namespace BazisGUI.PropertiesPanel
{
    public class DrowPropertyOnPanelEventArgs : EventArgs
    {
        public IEnumerable<RowProperty> Properties;

        public DrowPropertyOnPanelEventArgs(IEnumerable<RowProperty> properties)
        {
            Properties = properties;
        }
    }
}
