using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.PropertiesPanel
{
    public class DropDownPropertyValue
    {
        public object Value { get; set; }
        public List<string> AvailableValues { get; } = new List<string>();

        public bool IsEditable { get; set; }

        public DropDownPropertyValue(object value, List<string>  _availableValues, bool isEditable = false)
        {
            AvailableValues = _availableValues;

            Value = value;

            IsEditable = isEditable;
        }
    }
}
