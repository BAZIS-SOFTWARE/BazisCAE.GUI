using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.Validation
{
    public static class FunctionValidator
    {
        public static bool IsFunctionValueValid(ComboBox cmb, out string errorMessage)
        {
            var functions = cmb.Items;
            var value = cmb.Text;

            if (!float.TryParse(value, out float temp))
            {
                if (functions.Contains(value))
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
        public static void cmb_Validating(object sender, ValidationEventArgs e)
        {
            string errorMessage = string.Empty;
            if (!IsFunctionValueValid(e.component as ComboBox, out errorMessage))
                e.Cancel = true;

            e.EP.SetError(e.component as ComboBox, errorMessage);
        }
    }
}
