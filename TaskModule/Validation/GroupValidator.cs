using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskModule.Validation
{
    public class GroupValidator
    {
        public static bool IsGroupValueValid(ComboBox cmb, out string errorMessage)
        {
            var groups = cmb.Items;
            var value = cmb.Text;

            if (groups.Contains(value))
            {
                errorMessage = string.Empty;
                return true;
            }
            errorMessage = "Выбранная группа не доступна. Вероятно, допущена ошибка при выборе группы";
            return false;
        }
        public static void cmbGroup_Validating(object sender, ValidationEventArgs e)
        {
            string errorMessage = string.Empty;
            if (!IsGroupValueValid(e.component as ComboBox, out errorMessage))
                e.Cancel = true;

            e.EP.SetError(e.component as ComboBox, errorMessage);
        }
    }
}
