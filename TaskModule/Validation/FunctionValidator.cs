using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule.Validation
{
    public class FunctionValidator : ValidationAttribute
    {
        public List<string> AvailableFunctions { get; set; }

        public FunctionValidator(List<string> functions) 
        {
            AvailableFunctions = functions;
        }

        public override bool IsValid(object value)
        {
            if (value is string str)
            {
                if (AvailableFunctions.Contains(str) || float.TryParse(str, out float e))
                    return true;
            }
            ErrorMessage = "Ввыбранная функция была изменена, или числовое значение задано с ошибкой";
            return false;
        }
    }
}
