using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace BazisGUI.SettingsControl
{
    public partial class SettingsControl : UserControl
    {
        public event Action<SettingsConfig> SaveSettingsEvent;



        public SettingsControl()
        {
            InitializeComponent();
        }

        public void SetSettings(SettingsConfig settingsConfig)
        {
            panelBackGroundColor.BackColor = settingsConfig.BackGroudColor;
            panelSelectionColor.BackColor = settingsConfig.SelectionColor;
            lblSolverPath.Text = settingsConfig.SolverPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var config = new SettingsConfig()
            {
                BackGroudColor = panelBackGroundColor.BackColor,
                SelectionColor = panelSelectionColor.BackColor,
                SolverPath = lblSolverPath.Text
            };

            
            SaveSettingsEvent(config);

            var settingsSerializer = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            var configString = JsonConvert.SerializeObject(config, settingsSerializer);

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            File.WriteAllText($@"{folder}\settingsConfig.json", configString);

            MessageBox.Show($@"Конфигурация сохранена в {folder}\settingsConfig.json");          
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            panelSelectionColor.BackColor = dialog.Color;
        }

        private void btnBackGroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            panelBackGroundColor.BackColor = dialog.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            lblSolverPath.Text = dialog.SelectedPath;
        }
    }
}
