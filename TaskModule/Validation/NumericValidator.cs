using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskModule.Validation
{
    public class NumericValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string str)
            {
                if (str == null || str.Equals(string.Empty))
                {
                    ErrorMessage = "Поле не заполнено";
                    return false;
                }
                    

                if (Regex.IsMatch(str, "^([-]?)(([1-9]{1,})|([0-9]{1}))([.](\\d{1,}))?$")
                    || Regex.IsMatch(str, "^([-]?)([0-9]{1})(([.])([0-9]{1,}))?([e])([+]|[-])([0]|[1-9]{1,})$"))
                    return true;

            }
            ErrorMessage = "Введенное значение строки не соответствует записи числа в обычном или экспоненциальном виде";
            return false;
        }
    }
}
