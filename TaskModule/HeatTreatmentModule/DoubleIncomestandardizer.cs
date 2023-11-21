using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskModule.HeatTreatmentModule
{
    public static class DoubleIncomestandardizer
    {
        public static string ExponentConvertion(string income, int numbersAfterPoint)
        {
            var pattern = @"^(|-)(\d{1})([.,])\d{0, " + numbersAfterPoint + @"}([Ee])([+-])(\d+)";
            if (Regex.IsMatch(income, pattern))
                return income.Replace(',', '.').Replace('e', 'E');

            if (float.TryParse(income, out float number))
            {
                return number.ToString("E", CultureInfo.CreateSpecificCulture("en-US"));
            }
            else
                throw new ArgumentException("Введенную строку нельзя перевести в float");
        }
    }
}
