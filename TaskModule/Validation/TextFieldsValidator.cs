using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.Validation
{
    public class TextFieldsValidator
    {
        private static readonly char[] IligalSymbols = new[] {' '};

        public static bool IsTextValueValid(TextBox txtBox, out string errorMessage)
        {
            var value = txtBox.Text;
            if (value == null && value.Any(x => IligalSymbols.Contains(x)))
            {
                errorMessage = "Переданная строка пуста или содержит неподдерживаемые символы.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        public static void Validating(object sender, ValidationEventArgs e)
        {
            string errorMessage = string.Empty;
            if (!IsTextValueValid(e.component as TextBox, out errorMessage))
                e.Cancel = true;

            e.EP.SetError(e.component as TextBox, errorMessage);
        }
    }
}
