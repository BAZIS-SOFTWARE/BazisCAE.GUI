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

        public ErrorProvider EP { get; set; }

        public bool IsValueValid(out string errorMessage)
        {
            if (Text.Equals(string.Empty))
            {
                errorMessage = "Поле оставлено пустым";
                return false;
            }

            if (Items.Contains(Text))
            {
                errorMessage = string.Empty;
                return true;
            }
            errorMessage = "Выбранный вариант не доступен. Вероятно, допущена ошибка при выборе значения";
            return false;
        }

        public void OnValidating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;
            if (!IsValueValid(out errorMessage))
                e.Cancel = true;

            EP.SetError(this, errorMessage);
        }
    }
}
