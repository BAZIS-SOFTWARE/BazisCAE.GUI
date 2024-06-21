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
    public partial class CMBValidating : ComboBox, IValidatingControl
    {
        public CMBValidating() 
        { 
            InitializeComponent();
            EP = InitializaErrorProvider();
        }

        public CMBValidating(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            EP = InitializaErrorProvider();
        }

        private ErrorProvider InitializaErrorProvider()
        {
            var eP = new ErrorProvider();
            eP.SetIconAlignment(this, ErrorIconAlignment.MiddleRight);
            eP.SetIconPadding(this, 2);
            eP.BlinkRate = 1000;
            eP.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            return eP;
        }

        public ErrorProvider EP { get; }

        public ComboBoxInputType InputType { get; set; } = ComboBoxInputType.AllValues;

        public bool IsValidating { get; set; } = true;

        public bool IsValueValid()
        {
            string errorMessage = string.Empty;
            var isFlag = false;

            if (!IsValidating || Enabled == false)
                return true;

            if (bool.TryParse())
            if (Text.Equals(string.Empty) && Enabled == true)
            {
                errorMessage = "Поле оставлено пустым";
                EP.SetError(this, errorMessage);
                return false;
            }

            if (Items.Contains(Text)
                || (Text.Equals(string.Empty) && Enabled == false))
            {
                EP.SetError(this, errorMessage);
                return true;
            }

            errorMessage = "Выбранный вариант не доступен. Вероятно, допущена ошибка при выборе значения";
            EP.SetError(this, errorMessage);
            return false;
        }
    }
}
