using IronPython.Compiler.Ast;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using UserControlsEx;

namespace BazisGUI.PropertiesPanel
{
    public partial class OverlayComboBox : ComboBox
    {
        public void SetItems(DropDownPropertyValue value)
        {
            Items.Clear();
            Items.AddRange(value.AvailableValues.ToArray());

            DropDownStyle = value.IsEditable
                ? ComboBoxStyle.DropDown
                : ComboBoxStyle.DropDownList;
        }
    }
}
