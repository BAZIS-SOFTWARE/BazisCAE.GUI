using System;
using System.Collections.Generic;

namespace BaseModule.PropertiesPanel
{
    public class DrowPropertyOnPanelEventArgs: EventArgs
    {
        public List<RowProperty> List;

        public DrowPropertyOnPanelEventArgs(List<RowProperty> list)
        {
            List = list;
        }
    }
}
