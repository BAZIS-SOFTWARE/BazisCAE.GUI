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
    public partial class ValidatingTextBox : TextBox, IValidatingControl
    {
        private static readonly char[] IligalSymbols = new[] { ' ' };

        public ValidatingTextBox() { InitializeComponent(); }

        public ValidatingTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool IsValueValid(ErrorProvider EP)
        {
            var errorMessage = string.Empty;
            if (Text.Equals(string.Empty) && Text.Any(x => IligalSymbols.Contains(x)))
            {
                errorMessage = "Переданная строка пуста или содержит неподдерживаемые символы.";
                EP.SetError(this, errorMessage);
                return false;
            }
            return true;
        }
    }
}
