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
    public partial class TextBoxValidating : TextBox, IValidatingControl
    {
        private static readonly char[] IligalSymbols = new[] { ' ' };

        public TextBoxValidating() { InitializeComponent(); }

        public TextBoxValidating(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            EP = InitializaErrorProvider();
        }

        public bool IsValidating { get; set; }

        public TXTBoxInputType InputType { get; set; }

        public ErrorProvider EP { get; }

        private ErrorProvider InitializaErrorProvider()
        {
            var eP = new ErrorProvider();
            eP.SetIconAlignment(this, ErrorIconAlignment.MiddleRight);
            eP.SetIconPadding(this, 2);
            eP.BlinkRate = 1000;
            eP.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            return eP;
        }

        public bool IsValueValid()
        {
            var errorMessage = string.Empty;
            if (Text.Equals(string.Empty) && Text.Any(x => IligalSymbols.Contains(x)) && Enabled == true)
            {
                errorMessage = "Переданная строка пуста или содержит неподдерживаемые символы.";
                EP.SetError(this, errorMessage);
                return false;
            }
            EP.SetError(this, errorMessage);
            return true;
        }
    }
}
