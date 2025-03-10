using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule.PropertiesPanel
{
    public class PropertyUpdateEventArgs : EventArgs
    {
        public object TargetObject { get; }
        public string PropertyName { get; }
        public object OldValue { get; }
        public object NewValue { get; }

        public PropertyUpdateEventArgs(object targetObject, string propertyName, object oldValue, object newValue)
        {
            TargetObject = targetObject;
            PropertyName = propertyName;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
