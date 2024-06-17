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
    public partial class ValidatingFunctionCMB : ComboBox, IValidatingControl<ComboBox>
    {
        public ValidatingFunctionCMB() { InitializeComponent(); }

        public ValidatingFunctionCMB(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public ErrorProvider EP { get; set; } = new ErrorProvider();

        public bool IsValueValid(out string errorMessage)
        {
            if (!float.TryParse(Text, out float temp))
            {
                if (Items.Contains(Text))
                {
                    errorMessage = string.Empty;
                    return true;
                }
                errorMessage = "Переданное значение не является числом и не содержится в наборе доступных функций." +
                    "Вероятно, допущена ошибка при выборе функции или при вводе числа";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        void IValidatingControl<ComboBox>.Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;
            if (!IsValueValid(out errorMessage))
                e.Cancel = true;

            EP.SetError(this, errorMessage);
        }
    }
}
