using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BaseModule.PropertiesPanel
{
    [ComVisible(false)]
    public abstract class PanelConverter
    {
        public virtual List<RowProperty> GetRowProperty()
        {
            return new List<RowProperty>();
        }

        public virtual void UpdateObject(string header, string newValue)
        {
            throw new NotImplementedException("Тип конвертера не определен");
        }
    }
}
