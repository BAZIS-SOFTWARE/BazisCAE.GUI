using System;
using System.Collections.Generic;
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
            if (float.TryParse(income, out float number))
            {
                var pattern = @"^(|-)(\d{1})([.,])\d{0, " + numbersAfterPoint + @"}([Ee])([+-])(\d+)";
                if (Regex.IsMatch(income, pattern))
                    return income.Replace(',', '.').Replace('e', 'E');

                var parts = income.Split('.', ',');
                return ExtractBuilder(parts).ToString();
            }

            else
                throw new ArgumentException("Введенную строку нельзя перевести в float");
        }

        private static StringBuilder ExtractBuilder(string[] parts)
        {
            if (parts.Length == 1)
                return ConvertIntToStandart(parts);

            if (parts[0].Length <= 2 && Math.Abs(int.Parse(parts[0])) < 1 && parts[1][0] == '0')
                return ConvertDoubleWithoutAbsPartToStandart(parts);

            if (parts[0].Length >= 2 && Math.Abs(int.Parse(parts[0])) >= 1)
                return ConvertDoubleWithAbsPartToStandart(parts);

            else
                return DefaultConvertDoubleToStandart(parts);
        }

        private static StringBuilder ConvertIntToStandart(string[] parts)
        {
            var builder = new StringBuilder();
            var start = parts[0][0] == '-' ? parts[0].Substring(0, 2) : parts[0][0].ToString();

            builder.Append($"{start}.{parts[0].Substring(start.Length)}E+{parts[0].Length - start.Length}");
            return builder;
        }

        private static StringBuilder ConvertDoubleWithAbsPartToStandart(string[] parts)
        {
            var builder = new StringBuilder();
            var start = parts[0][0] == '-' ? parts[0].Substring(0, 2) : parts[0][0].ToString();

            builder.Append($"{start}.{parts[0].Substring(start.Length)}{parts[1]}E+{parts[0].Length - start.Length}");
            return builder;
        }

        private static StringBuilder ConvertDoubleWithoutAbsPartToStandart(string[] parts)
        {
            var builder = new StringBuilder();
            var moveLeft = 0;
            for (var i = 0; i < parts[1].Length; i++)
            {
                if (parts[1][i] != '0')
                    break;
                moveLeft++;
            }

            var start = parts[0].StartsWith("-") ? $"-{parts[1][moveLeft]}" : $"{parts[1][moveLeft]}";
            moveLeft++;

            builder.Append($"{start}.{parts[1].Substring(moveLeft)}E-{moveLeft}");
            return builder;
        }

        private static StringBuilder DefaultConvertDoubleToStandart(string[] parts)
        {
            var builder = new StringBuilder();
            var start = parts[0][0] == '-' ? parts[0].Substring(0, 2) : parts[0][0].ToString();

            builder.Append($"{start}.{parts[1]}E+0");
            return builder;
        }
    }
}
