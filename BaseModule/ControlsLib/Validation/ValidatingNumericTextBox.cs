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

        public bool IsNegativeValueAvailable { get; set; } = false;

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

            if (!IsNegativeValueAvailable && Text.StartsWith("-"))
            {
                errorMessage = "Для данного поля отрицательные значения запрещены";
                EP.SetError(this, errorMessage);
                return false;
            }

            if ((IsNegativeValueAvailable && (Regex.IsMatch(Text, "^([-]?)(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                || Regex.IsMatch(Text, "^([-]?)(\\d{1})(([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,})$")))

                || (!IsNegativeValueAvailable && (Regex.IsMatch(Text, "^(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                || Regex.IsMatch(Text, "^(\\d{1})(([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,})$")))

                || (Text.Equals(string.Empty) && Enabled == false))
            {
                errorMessage = string.Empty;
                EP.SetError(this, errorMessage);
                return true;
            }

            errorMessage = "Введенное значение строки не соответствует культуре записи числа в обычном или экспоненциальном виде";
            EP.SetError(this, errorMessage);
            return false;
        }
    }
}
