namespace ProjectConverter
{
    public class Converter()
    {
        private string FilePath { get; set; }

        public void ReadProject(string filePatch)
        {
            FilePath = filePatch;

            var textLines = File.ReadLines(filePatch).First();
            var ver = string.Empty;
            if (textLines.Contains("Версия"))
                ver = textLines.Split(' ')[1];
            else
                ver = textLines;

            if (IsActualVersion(ver))
            {
                string tempFile = FilePath + ".tmp";
                using (var reader = new StreamReader(FilePath))
                using (var writer = new StreamWriter(tempFile))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();                        
                        var newLine = ParseLine(line);
                        writer.WriteLine(newLine);
                    }
                }
            }
        }

        private string ParseLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return line;

            var token = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            switch (token[0])
            {
                case "Материал":
                    return $"{token[0]} : 1 * {token[6]} None {token[2]} {token[4]} {token[5]} {token[3]}";
                case "Среда":
                    return $"{token[0]} : 1 * {token[7]} None ";
                case "Нагрузка":
                    return GetLoadString(token);
                case "Нагрев":
                    return GetHeatString(token);
                case "Закрепление":
                    return GetClampString(token);
                default:
                    return line;
            }
        }

        private string GetClampString(string[] data) 
        {
            var value = data[5];
            var direction = data[4];
            var group = data[2];
            var start = data[7];
            var stop = data[8];
            var type = data[3];
            return $"{data[0]} : {value} * * {direction} {group} {start} {stop} {type}";
            return string.Empty;
        }
        private string GetLoadString(string[] data)
        {
            var value = data[5];
            var direction = data[4];
            var group = data[2];
            var start = data[7];
            var stop = data[8];
            var type = data[3];
            return $"{data[0]} : {value} * * {direction} {group} {start} {stop} {type}";
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
                var transform = funcData[indexReferenceFrame + 3];
                referenceFrame += $"({trajectory},{speed},{transform})";
            }
            else if (referenceFrame == "SRF") 
            {
                var trajectory = funcData[indexReferenceFrame + 1];
                var transform = funcData[indexReferenceFrame + 2];
                referenceFrame += $"({trajectory},{transform})";
            }
            var group = data[5];
            var start = data[6];
            var stop = data[7];

            return $"{data[0]} : {value} {func} {referenceFrame} None {group} {start} {stop}";
        }

        private int GetIndexCoordinatSystem(string[] data, out string reference)
        {
            var indexCoordinatSystem = 0;
            reference = string.Empty;
            foreach (var frameFunc in data)
            {
                if (frameFunc == "SRF" || frameFunc == "MRF")
                {
                    reference = frameFunc;
                    break;
                }
                    
                indexCoordinatSystem++;
            }
            return indexCoordinatSystem;
        }
        /// <summary>
        /// Метод для проверки версии проекта
        /// </summary>
        /// <param name="ver">Текущая версия проекта</param>
        /// <returns></returns>
        private bool IsActualVersion(string ver) 
        {
            var version = Version.Parse(ver);

            var minimalVersion = new Version(4, 9, 2 ,0);
            return version <= minimalVersion;
        }
    }
}
