using BaseModule.Utilities;
using Newtonsoft.Json;
using Project.Interfaces;
using PropertiesCalculator.MaterialData;
using PropertiesDataBases.DataBases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public T GetDataBase<T>(string dbName, string dbPath)
        {
            var filePath = FindFileByPath(dbPath, dbName);
            if (filePath == null)
            {
                console.PrintInfo($"Не найдена база {dbName} в папке {dbPath}", Color.Orange);
                return default;
            }

            else
            {
                var settingsSerializer = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented,
                };

                return JsonConvert.DeserializeObject<T>
    (File.ReadAllText($@"{dbPath}\{dbName}"), settingsSerializer);
            }
        }
    }
}
