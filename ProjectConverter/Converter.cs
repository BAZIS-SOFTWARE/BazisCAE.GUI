using System.Globalization;

namespace ProjectConverter
{
    public class Converter()
    {
        public event Action<string, Color> ConvertProcessInfo;
        public void ReadProject(string filePath)
        {
            //string tempFile = filePath + ".tmp";
            //temp
            var fileName = filePath.Split('.')[0] + "13";
            string tempFile = $"{fileName}.{filePath.Split('.')[1]}";
            //temp
            using (var reader = new StreamReader(filePath))
            using (var writer = new StreamWriter(tempFile))

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var newLine = ParseLine(line);
                writer.WriteLine(newLine);
            }

            ConvertProcessInfo("Конвертация завершена", Color.Green);
            //File.Replace(tempFile, filePath, null);
        }

        private string ParseLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return line;

            var token = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return token[0] switch
            {
                "Материал" => $"{token[0]} : 1 * {token[6]} None {token[2]} {token[4]} {token[5]} {token[3]}",
                "Среда" => GetMediaString(token),
                "Нагрузка" => GetCondString(token),
                "Нагрев" => GetHeatString(token),
                "Закрепление" => GetCondString(token),
                _ => line
            };
        }

        private string GetCondString(string[] data) 
        {
            var value = data[5];
            var direction = data[4];
            var group = data[2];
            var start = data[7];
            var stop = data[8];
            var type = data[3];
            return $"{data[0]} : {value} * * {direction} {group} {start} {stop} {type}";
        }

        private string GetMediaString(string[] data)
        {
            string tempInfo;
            if (float.TryParse(data[4], out float temp))
                tempInfo = $"TEMPM={temp}";
            else
                tempInfo = $"TEMPM=Table({data[4]};TIME)";

            string hexInfo;
            if (float.TryParse(data[3], NumberStyles.Float, CultureInfo.InvariantCulture, out var hex))
                hexInfo = $"HEX={hex}";
            else if (data[3] == "*")
                hexInfo = "HEX=2.5E-05";
            else
                hexInfo = $"HEX=Table({data[3]};TEMPS)";

            var group = data[2];
            var start = data[5];
            var stop = data[6];

            return $"{data[0]} : 1 FHEX,TIME=VAR,{tempInfo},{hexInfo} * None {group} {start} {stop} ConstantTemp";
        }

        private string GetHeatString(string[] data)
        {
            var value = data[2];
            var func = string.Empty;
            var funcData = data[4].Split(';');
            if (funcData[0] == "SPH")
                func = $"{funcData[0]},X=VAR,Y=VAR,Z=VAR,Width={funcData[1]}";
            else if (funcData[0] == "*")
                func = "*";
            else if (funcData[0] == "CIL")
                func = $"{funcData[0]},X=VAR,Y=VAR,Z=VAR,Length={funcData[1]},UpperDiam={funcData[2]},BottomDiam={funcData[3]}";

            var indexReferenceFrame = GetIndexCoordinatSystem(funcData, out var referenceFrame);

            if(referenceFrame == "MRF")
            {
                var trajectory = funcData[indexReferenceFrame + 1];
                var speed = funcData[indexReferenceFrame + 2];
                var transform = ValidationTransformString(funcData[indexReferenceFrame + 3]);
                referenceFrame += $"({trajectory},{speed},{transform})";
            }
            else if (referenceFrame == "SRF") 
            {
                var trajectory = funcData[indexReferenceFrame + 1];
                var transform = ValidationTransformString(funcData[indexReferenceFrame + 2]);
                referenceFrame += $"({trajectory},{transform})";
            }
            var group = data[5];
            var start = data[6];
            var stop = data[7];

            return $"{data[0]} : {value} {func} {referenceFrame} None {group} {start} {stop}";
        }

        private int GetIndexCoordinatSystem(string[] data, out string reference)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == "SRF" || data[i] == "MRF")
                {
                    reference = data[i];
                    return i;
                }
            }
            reference = string.Empty;
            return -1;
        }

        private string ValidationTransformString(string transform)
        {
            var transformList = transform.Split('|');
            if ( transformList.Count() != 6) 
            {
                var newLine = $"{transformList[0]}|{transformList[1]}|{transformList[2]}|0|0|0";
                ConvertProcessInfo?.Invoke($"Конвертация {transform} вернуло {newLine}", Color.Orange);
                return newLine;
            }  
            else
                return transform; 
        }
    }
}
