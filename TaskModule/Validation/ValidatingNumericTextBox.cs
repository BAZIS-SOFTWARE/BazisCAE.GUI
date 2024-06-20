using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.Validation
{
    public partial class ValidatingNumericTextBox : TextBox, IValidatingControl
    {
        public ValidatingNumericTextBox() { InitializeComponent(); }

        public ValidatingNumericTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool IsValueValid(ErrorProvider EP)
        {
            var errorMessage = string.Empty;
            if (Text.Equals(string.Empty))
            {
                errorMessage = "Поле оставлено пустым";
                EP.SetError(this, errorMessage);
                return false;
            }

            if (Text.Contains(","))
            {
                errorMessage = "В качестве разделителя целой и дробной части используйте точку";
                EP.SetError(this, errorMessage);
                return false;
            }

            if (Regex.IsMatch(Text, "^([-]?)(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                || Regex.IsMatch(Text, "^([-]?)(\\d{1})(([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,})$"))
            {
                errorMessage = string.Empty;
                return true;
            }

            errorMessage = "Введенное значение строки не соответствует культуре записи числа в обычном или экспоненциальном виде";
            EP.SetError(this, errorMessage);
            return false;
        }
    }
}
