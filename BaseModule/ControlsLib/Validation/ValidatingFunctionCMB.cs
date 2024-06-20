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
    public partial class ValidatingFunctionCMB : ComboBox, IValidatingControl
    {
        public ValidatingFunctionCMB() { InitializeComponent(); }

        public ValidatingFunctionCMB(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool IsValueValid(ErrorProvider EP)
        {
            var errorMessage = string.Empty;
            if (float.TryParse(Text, out float temp) || Items.Contains(Text)
                || (Text.Equals(string.Empty) && Enabled == false))
            {
                EP.SetError(this, errorMessage);
                return true;
            }

            errorMessage = "Переданное значение не является числом и не содержится в наборе доступных функций." +
                "Вероятно, допущена ошибка при выборе функции или при вводе числа";
            EP.SetError(this, errorMessage);
            return false;
        }
    }
}
