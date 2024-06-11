using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.Validation
{
    public class NumericValidator
    {
        public static bool IsNumericValueValid(TextBox txtBox, out string errorMessage)
        {
            var value = txtBox.Text;
            errorMessage = string.Empty;

            if (value == null || value.Equals(string.Empty))
            {
                errorMessage = "Поле оставлено пустым";
                return false;
            }

            if (value.Contains(","))
            {
                errorMessage = "В качестве разделителя целой и дробной части используйте точку";
                return false;
            }

            if (Regex.IsMatch(value, "^([-]?)(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                || Regex.IsMatch(value, "^([-]?)(\\d{1})(([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,})$"))
            {
                errorMessage = string.Empty;
                return true;
            }

            errorMessage = "Введенное значение строки не соответствует культуре записи числа в обычном или экспоненциальном виде";
            return false;
        }

        public static void Validating(object sender, ValidationEventArgs e)
        {
            string errorMessage = string.Empty;
            if (!IsNumericValueValid(e.component as TextBox, out errorMessage))
                e.Cancel = true;

            e.EP.SetError(e.component as TextBox, errorMessage);
        }
    }
}
