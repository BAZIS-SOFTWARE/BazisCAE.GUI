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
        public static string ExponentConvertion(string income, int numbersAfterPoint = 6)
        {
            income = income.Trim();

            if (float.TryParse(income, out float number))
                return number.ToString($"E{numbersAfterPoint}", CultureInfo.CreateSpecificCulture("en-US"));

            if (income.Contains("^") && income.Contains("*"))
                return TranslateUnCommonUserInput(income);

            else
                throw new ArgumentException("Введенную строку нельзя перевести в float");
        }

        private static string TranslateUnCommonUserInput(string income)
        {
            var rawParts = income.Split('*');
            var expParts = rawParts[1].Split('^');

            var powIndex = HandlePowerIndexPart(expParts[1].Trim('(', ')'));
            return $"{rawParts[0]}E{powIndex}";
        }

        private static string HandlePowerIndexPart(string powerIndex)
        {
            if (powerIndex.Contains('/'))
            {
                var fraction = powerIndex.Split('/');
                return (double.Parse(fraction[0]) / double.Parse(fraction[1])).ToString();
            }

            return double.Parse(powerIndex).ToString();
        }
    }
}
