using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.Validation
{
    public class CmbValidator
    {
        public static bool IsCmbValueValid(ComboBox cmb, out string errorMessage)
        {
            var groups = cmb.Items;
            var value = cmb.Text;

            if (value.Equals(string.Empty) || value == null)
            {
                errorMessage = "Поле оставлено пустым";
                return false;
            }

            if (groups.Contains(value))
            {
                errorMessage = string.Empty;
                return true;
            }
            errorMessage = "Выбранный вариант не доступен. Вероятно, допущена ошибка при выборе значения";
            return false;
        }

        public static void Validating(object sender, ValidationEventArgs e)
        {
            string errorMessage = string.Empty;
            if (!IsCmbValueValid(e.component as ComboBox, out errorMessage))
                e.Cancel = true;

            e.EP.SetError(e.component as ComboBox, errorMessage);
        }
    }
}
