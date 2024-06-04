using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule.Validation
{
    public class TextFieldsValidator : ValidationAttribute
    {
        private readonly char[] IligalSymbols = new[] {' '};

        public override bool IsValid(object value)
        {
            if (value is string str)
            {
                if (str != null && !str.All(x => IligalSymbols.Contains(x)))
                    return true;
            }
            ErrorMessage = "Переданная строка пуста или содержит неподдерживаемые символы.";
            return false;
        }
    }
}
