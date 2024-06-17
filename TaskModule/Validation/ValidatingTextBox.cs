using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.Validation
{
    public partial class ValidatingTextBox : TextBox, IValidatingControl<TextBox>
    {
        private static readonly char[] IligalSymbols = new[] { ' ' };

        public ValidatingTextBox() { InitializeComponent(); }

        public ValidatingTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public ErrorProvider EP { get; set; } = new ErrorProvider();

        public bool IsValueValid(out string errorMessage)
        {
            if (Text == null && Text.Any(x => IligalSymbols.Contains(x)))
            {
                errorMessage = "Переданная строка пуста или содержит неподдерживаемые символы.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        void IValidatingControl<TextBox>.Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;
            if (!IsValueValid(out errorMessage))
                e.Cancel = true;

            EP.SetError(this, errorMessage);
        }
    }
}
