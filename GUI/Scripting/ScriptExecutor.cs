using BazisGUI.Properties;
using BazisGUI.Scripting.Variable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BazisGUI.Scripting
{
    public class ScriptExecutor
    {
        public event Func<string, Task<CmdReport>> CommandEnteredEvent;
        private Dictionary<string, ScriptValue> _variables = [];

        public void ReadFileScript(string path)
        {
            if (System.IO.File.Exists(path))
            {
                var cmdLines = File.ReadAllLines(path);
                foreach (var line in cmdLines)
                    ExecuteLine(line);
            }
            else throw new Exception($"\n > {Resources.ExecuteCMDFileMissing}");
        }

        private void ExecuteLine(string line) 
        {
            //Проверяем что это не комментарий и не пустая строка
            ReadOnlySpan<char> span = line.AsSpan().TrimStart();
            if (span.StartsWith("//"))
                return;
            if (span.IsEmpty)
                return;

            //Если длина parts = 2, значит строка имеет вид:
            // переменная = значение
            // переменная = команда
            var parts = line.Split('=', 2);
            if (parts.Length == 2)  //Данный блок проверяет случай "переменная = значение" и записывает в словарь
            {
                var variableName = parts[0].Trim().TrimStart('$');
                var expression = parts[1].Trim();

                //Проверяем что после равно указана переменная
                if (int.TryParse(expression, out int intValue)) 
                {
                    _variables[variableName] = new IntValue() { Value = intValue };
                    return;
                }
                else if (IsLiteralString(expression, out string stringValue))
                {
                    _variables[variableName] = new StringValue() { Value = stringValue };
                    return;
                } 
            }

            //Проверяем строку на наличие переменных
            var matches = Regex.Matches(line, @"\$(\w+)");
            if (matches.Count > 0) //если найдены переменные 
            {
                var replaceLine = line;
                foreach (Match match in matches)
                {
                    var variableName = match.Groups[1].Value;
                    //Если переменной нет в словаре добавляем иначе подсталяем значение 
                    if (!_variables.ContainsKey(variableName))
                        _variables[variableName] = new StringValue() { Value = "default"};
                    else 
                    {
                        var replacement = _variables[variableName].ToString();
                        replaceLine = replaceLine.Replace("$" + variableName, replacement);
                    }
                }
                line = replaceLine;
            }
            ParseCommandLine(line);
        }

        private void ParseCommandLine(string str)
        {
            var parts = str.Split('=', 2);
            if(parts.Length == 2)
            {
                var result = CommandEnteredEvent.Invoke(parts[1]);
                if (result == null || result.Exception != null)
                    return;

                _variables[parts[0].Trim().TrimStart('$')] = result.Result.Variable;
            }
            else
                CommandEnteredEvent.Invoke(str);
        }

        private bool IsLiteralString(string value, out string _result)
        {
            ReadOnlySpan<char> span = value.AsSpan();
            var r = ReadFirstQuoted(span);
            if (!CommandList.Exists(r))
            {
                _result = r;
                return true;
            }
            _result = value;
            return false;
        }

        private string ReadFirstQuoted(ReadOnlySpan<char> input)
        {
            int i = 0;

            // пропустить пробелы
            while (i < input.Length && char.IsWhiteSpace(input[i]))
                i++;

            // первая кавычка
            if (i >= input.Length || input[i] != '"')
                return string.Empty;

            i++; // после "

            int start = i;

            // ищем закрывающую кавычку
            while (i < input.Length)
            {
                if (input[i] == '"')
                    break;

                i++;
            }

            if (i >= input.Length)
                return string.Empty;

            return input.Slice(start, i - start).ToString();
        }
    }
}
