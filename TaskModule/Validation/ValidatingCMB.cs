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
    public partial class ValidatingCMB : ComboBox, IValidatingControl
    {
        public ValidatingCMB() { InitializeComponent(); }

        public ValidatingCMB(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool IsValueValid(ErrorProvider EP)
        {
            string errorMessage = string.Empty;
            if (Text.Equals(string.Empty))
            {
                errorMessage = "Поле оставлено пустым";
                EP.SetError(this, errorMessage);
                return false;
            }

            if (Items.Contains(Text))
                return true;

            errorMessage = "Выбранный вариант не доступен. Вероятно, допущена ошибка при выборе значения";
            EP.SetError(this, errorMessage);
            return false;
        }
    }
}
