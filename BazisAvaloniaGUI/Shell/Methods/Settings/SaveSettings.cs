using BazisAvaloniaGUI.SettingsControls;
using Newtonsoft.Json;
using System;
using System.IO;

namespace BazisAvaloniaGUI.Shell
{
    internal partial class MainWindow
    {
        public void SaveConfig(SettingsConfig config)
        {
            try
            {
                var settingsSerializer = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented
                };

                var configString = JsonConvert.SerializeObject(config, settingsSerializer);

                var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                File.WriteAllText(Path.Combine(folder, "settingsConfig.json"), configString);

                MessageBox.Show(this, $@"Конфигурация сохранена в {Path.Combine(folder, "settingsConfig.json")}");
            }
            catch (Exception)
            {
                MessageBox.Show(this, $@"Ошибка сохранения конфигурации");
            }
        }
    }
}
