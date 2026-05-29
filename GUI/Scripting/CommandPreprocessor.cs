using BazisGUI.Console.Enums;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BazisGUI.Scripting
{
    public class CommandPreprocessor
    {
        public event Func<string, Task<CmdReport>> CommandEnteredEvent;
        private Dictionary<string, string> _variables = []; //имя перемененой и ее значение
        private readonly Dictionary<string, GenCmd> commands = new Dictionary<string, GenCmd>()
        {
            { "Load project",GenCmd.LoadProject},
            { "Save project",GenCmd.SaveProject},
            { "Solve project",GenCmd.SolveProject},
            { "Renumber mesh",GenCmd.RenumberMesh},
            { "Move node",GenCmd.MoveNodes},
            { "Move mesh",GenCmd.MoveMesh},
            { "Rotate mesh",GenCmd.RotateMesh},
            { "Generate mesh",GenCmd.GenerateMesh},
            { "Find free nodes",GenCmd.FindFreeNodes},
            { "Find Coincident",GenCmd.FindCoincident},
            { "Find 3D elements",GenCmd.FindVolElems},
            { "Find object",GenCmd.FindObject},
            { "Connect with beams",GenCmd.BeamConnection},
            { "Set precision level",GenCmd.SetLevel },
            { "Merge elements sets",GenCmd.MergeElementSets },
            { "Build 2D mesh",GenCmd.CreateMesh2DPoligon },
            { "Create point",GenCmd.CreatePoint },
            { "Create point by vector", GenCmd.CreatePointByVector },
            { "Create point by projection onto curve", GenCmd.CreatePointProjectionOntoCurve },
            { "Create point by projection onto plane", GenCmd.CreatePointProjectionOntoPlane },
            { "Create curve",GenCmd.CreateCurve },
            { "Create surface",GenCmd.CreateSurface },
            { "Set mesh point", GenCmd.SetMeshPoint },
            { "Set mesh curve", GenCmd.SetMeshCurve },
            { "Set regular mesh surface", GenCmd.SetRegularSurface },
            { "Set embedded mesh surface", GenCmd.SetEmbeddedSurface },
            { "Set min size", GenCmd.SetMinSize },
            { "Set max size", GenCmd.SetMaxSize },
            { "Algo2D", GenCmd.Algo2D },
            { "Algo3D", GenCmd.Algo3D },
            { "Scale factor", GenCmd.ScaleFactor },
            { "Extrude along curve",GenCmd.ExtrudeCurve },
            { "Extrusion by rotation",GenCmd.ExtrudeRotate },
            { "Save STEP", GenCmd.SaveSTEP },
            { "Quit",GenCmd.Exit }
        };

        public void ReadCommands(List<string> cmds)
        {
            foreach (string cmd in cmds)
                ReadCommand(cmd);
        }
        public void ReadCommand(string cmd) => ExecuteLine(cmd);

        private void ExecuteLine(string line) 
        {
            //Проверяем что это не комментарий и не пустая строка
            ReadOnlySpan<char> span = line.AsSpan().TrimStart();
            if (span.StartsWith("//"))
                return;
            if (span.IsEmpty)
                return;

            //Проверяем строку на наличие переменных
            var matches = Regex.Matches(line, @"\$(\w+)");
            if (matches.Count > 0) //если найдены переменные 
            {
                var replaceLine = line;
                foreach (Match match in matches)
                {
                    var name = match.Groups[1].Value;
                    //Если переменной нет в словаре добавляем иначе подсталяем значение 
                    if (!_variables.ContainsKey(name))
                        _variables[name] = "default";
                    else
                    {
                        var replacement = _variables[name];
                        replaceLine = replaceLine.Replace("$" + name, replacement);
                    }
                }
                line = replaceLine;
            }
            //Если длина parts = 2, значит строка имеет вид:
            // переменная = значение
            // переменная = команда
            var parts = line.Split('=', 2);
            var variableName = string.Empty;
            var command = line;
            if (parts.Length == 2)  //Данный блок проверяет случай "переменная = значение" и записывает в словарь
            {
                variableName = parts[0].Trim().TrimStart('$');
                var expression = parts[1].Trim();

                //Проверяем что после равно указана переменная
                if (int.TryParse(expression, out int intValue)) 
                {
                    _variables[variableName] = intValue.ToString();
                    return;
                }
                else if (IsLiteralString(expression, out string stringValue))
                {
                    _variables[variableName] = stringValue;
                    return;
                }
                command = expression;
            }
            else
                variableName = string.Empty;
            ParseCommandLine(command, variableName);
        }

        private void ParseCommandLine(string command, string variableName)
        {
            if(variableName != string.Empty && variableName != "")
            {
                var result = CommandEnteredEvent.Invoke(command);
                if (result == null || result.Exception != null)
                    return;

                _variables[variableName] = result.Result.Variable;
            }
            else
                CommandEnteredEvent.Invoke(command);
        }

        private bool IsLiteralString(string value, out string _result)
        {
            ReadOnlySpan<char> span = value.AsSpan();
            var r = ReadFirstQuoted(span);
            if (!commands.ContainsKey(r))
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
