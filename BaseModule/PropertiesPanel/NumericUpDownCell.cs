using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.PropertiesPanel
{
    internal class NumericUpDownCell : DataGridViewCell
    {
        /*
         * Примерная стратегия
         * Create a Custom DataGridViewCell:
Derive a new class from DataGridViewTextBoxCell (or DataGridViewCell), for example, NumericUpDownCell.
Override the InitializeEditingControl method to set up the NumericUpDown control's properties (like Minimum, Maximum, DecimalPlaces, and Value) when the cell enters edit mode.
Override the EditType property to return the type of your custom editing control (created in the next step).
Override the ValueType property to specify the data type the cell will hold (e.g., typeof(Decimal)).
         */
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
        }
    }
}
