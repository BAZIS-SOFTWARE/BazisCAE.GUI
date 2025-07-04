using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;

namespace BazisGUI.SettingsControls
{
    public partial class SettingsControl : UserControl
    {
        public event Action<SettingsConfig> SaveSettingsEvent;
        public event Action<Color> SetSelectionObjectColorEvent;
        public event Action<Color> SetSelectionGroupColorEvent;
        public event Action<Color> SetBackGroundColorEvent;

        public event Action<Color> Set3DElemColorEvent;
        public event Action<Color> Set2DElemColorEvent;
        public event Action<Color> SetNodeColorEvent;

        public event Action<string> SetSolverPathEvent;
        public event Action<bool> SetLightingEvent;
        public Action<int> SetLightingIntensityEvent;
        public Action<Point> SetLighterPositionEvent;
        public Action<bool> SetTransparencyEvent;
        public Action<int> SetTransparencyValueEvent;

        public Action<bool> SetOrtoProjectionEvent;
        public SettingsControl()
        {
            InitializeComponent();

            lightingControl.SetBallPositionEvent += (ar) =>
            {
                SetLighterPositionEvent?.Invoke(ar);
            };
        }

        public void SetSettings(SettingsConfig settingsConfig)
        {
            panelBackGroundColor.BackColor = settingsConfig.BackGroudColor;
            pnlSelectionObjsColor.BackColor = settingsConfig.SelectObjectColor;
            pnlSelectionGroupColor.BackColor = settingsConfig.SelectGroupColor;
            lblSolverPath.Text = settingsConfig.SolverPath;
            chbLighting.Checked = settingsConfig.Lighting;
            chbBackRibbers.Checked = settingsConfig.BackRibbers;
            lightingControl.BallPosition = settingsConfig.LighterPosition;
            clslLigthingIntensity.Value = settingsConfig.LightingIntensity;
            chbTransparency.Checked = settingsConfig.Transparency;
            pnlNodeColor.BackColor = settingsConfig.NodeColor;
            chbOrtoProjection.Checked = settingsConfig.Projection;
            clslTransparency.Value = settingsConfig.TransparencyValue;

            chbOrtoProjection.Checked = settingsConfig.Projection;
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {

            var config = new SettingsConfig()
            {
                BackGroudColor = panelBackGroundColor.BackColor,
                SelectObjectColor = pnlSelectionObjsColor.BackColor,
                SelectGroupColor = pnlSelectionGroupColor.BackColor,

                SolverPath = lblSolverPath.Text,
                Lighting = chbLighting.Checked,
                LighterPosition = lightingControl.BallPosition,
                LightingIntensity = clslLigthingIntensity.Value,
                Transparency = chbTransparency.Checked,
                BackRibbers = chbBackRibbers.Checked,
                Projection = chbOrtoProjection.Checked,

                TransparencyValue = clslTransparency.Value,
                NodeColor = pnlNodeColor.BackColor
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

        private void btnSelectObjectColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            pnlSelectionObjsColor.BackColor = dialog.Color;

            SetSelectionObjectColorEvent?.Invoke(pnlSelectionObjsColor.BackColor);
        }

        private void btnSelectGroupColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            pnlSelectionGroupColor.BackColor = dialog.Color;

            SetSelectionGroupColorEvent?.Invoke(pnlSelectionGroupColor.BackColor);
        }

        private void btnBackGroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            panelBackGroundColor.BackColor = dialog.Color;

            SetBackGroundColorEvent?.Invoke(panelBackGroundColor.BackColor);
        }

        private void btnSetSolverPath_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            lblSolverPath.Text = dialog.SelectedPath;

            SetSolverPathEvent?.Invoke(lblSolverPath.Text);
        }

        private void chbLighting_Click(object sender, EventArgs e)
        {
            SetLightingEvent?.Invoke(chbLighting.Checked);
        }

        private void chbTransparency_Click(object sender, EventArgs e)
        {
            SetTransparencyEvent?.Invoke(chbTransparency.Checked);
        }

        private void chbBackRibbers_Click(object sender, EventArgs e)
        {

        }

        private void clslLigthingIntensity_Scroll(object sender, ScrollEventArgs e)
        {
            SetLightingIntensityEvent?.Invoke(e.NewValue);
        }

        private void clslTransparency_Scroll(object sender, ScrollEventArgs e)
        {
            SetTransparencyValueEvent?.Invoke(e.NewValue);
        }

        private void btnSelect3DElemColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            pnl3DElemColor.BackColor = dialog.Color;

            Set3DElemColorEvent?.Invoke(pnl3DElemColor.BackColor);
        }

        private void btnSelect2DElemColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            pnl2DElemColor.BackColor = dialog.Color;

            Set2DElemColorEvent?.Invoke(pnl2DElemColor.BackColor);
        }

        private void btnSelectNodeColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            pnlNodeColor.BackColor = dialog.Color;

            SetNodeColorEvent?.Invoke(pnlNodeColor.BackColor);
        }

        private void chbOrtoProjection_Click(object sender, EventArgs e)
        {
            if (chbOrtoProjection.Checked)
                SetOrtoProjectionEvent?.Invoke(true);
            else
                SetOrtoProjectionEvent?.Invoke(false);
        }
    }
}
