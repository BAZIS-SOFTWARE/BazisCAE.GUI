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
    public partial class ValidatingNumericTextBox : TextBox, IValidatingControl<TextBox>
    {
        public ValidatingNumericTextBox() { InitializeComponent(); }

        public ValidatingNumericTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public ErrorProvider EP { get; set; } = new ErrorProvider();

        public bool IsValueValid(out string errorMessage)
        {
            if (Text.Equals(string.Empty))
            {
                errorMessage = "Поле оставлено пустым";
                return false;
            }

            if (Text.Contains(","))
            {
                errorMessage = "В качестве разделителя целой и дробной части используйте точку";
                return false;
            }

            if (Regex.IsMatch(Text, "^([-]?)(([1-9](\\d{1,}))|(\\d{1}))([.](\\d{1,}))?$")
                || Regex.IsMatch(Text, "^([-]?)(\\d{1})(([.])(\\d{1,}))?([e,E])([+]|[-])(\\d|[1-9]\\d{1,})$"))
            {
                errorMessage = string.Empty;
                return true;
            }

            errorMessage = "Введенное значение строки не соответствует культуре записи числа в обычном или экспоненциальном виде";
            return false;
        }

        void IValidatingControl<TextBox>.Validating(object sender, CancelEventArgs e)
        {
            var errorMessage = string.Empty;
            if (!IsValueValid(out errorMessage))
                e.Cancel = true;

            EP.SetError(this, errorMessage);
        }
    }
}
