using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using ModelInterfaces;

namespace BazisGUI.SettingsControls
{
    public partial class SettingsControl : UserControl
    {
        public event Action<SettingsConfig> SaveSettingsEvent;
        public event Action<Color> SetSelectionObjectColorEvent;
        public event Action<Color> SetSelectionGroupColorEvent;
        public event Action<Color> SetBackGroundColorEvent;
        public event Action<string> SetSolverPathEvent;
        public event Action<bool> SetLightingEvent;
        public Action<int> SetLightingIntensityEvent;
        public Action<Point> SetLighterPositionEvent;
        public Action<bool> SetTransparencyEvent;
        public Action<ObjType,int> SetTransparencyValueEvent;
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
            panelSelectionObjsColor.BackColor = settingsConfig.SelectObjectColor;
            panelSelectionGroupColor.BackColor = settingsConfig.SelectGroupColor;
            lblSolverPath.Text = settingsConfig.SolverPath;
            chbLighting.Checked = settingsConfig.Lighting;
            chbBackRibbers.Checked = settingsConfig.BackRibbers;
            lightingControl.BallPosition = settingsConfig.LighterPosition;
            colorSlider.Value = settingsConfig.LightingIntensity;
            chbTransparency.Checked = settingsConfig.Transparency;

            clslNodes.Value = settingsConfig.NodeTransparency;
            cls1D.Value = settingsConfig.E1DTransparency;
            cls2D.Value = settingsConfig.E2DTransparency;
            cls3D.Value = settingsConfig.E3DTransparency;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var config = new SettingsConfig()
            {
                BackGroudColor = panelBackGroundColor.BackColor,
                SelectObjectColor = panelSelectionObjsColor.BackColor,
                SelectGroupColor = panelSelectionGroupColor.BackColor,

                SolverPath = lblSolverPath.Text,
                Lighting = chbLighting.Checked,
                LighterPosition = lightingControl.BallPosition,
                LightingIntensity = colorSlider.Value,
                Transparency = chbTransparency.Checked,
                BackRibbers = chbBackRibbers.Checked,

                NodeTransparency = clslNodes.Value,
                E1DTransparency = cls1D.Value,
                E2DTransparency = cls2D.Value,
                E3DTransparency = cls3D.Value
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

            panelSelectionObjsColor.BackColor = dialog.Color;

            SetSelectionObjectColorEvent?.Invoke(panelSelectionObjsColor.BackColor);
        }

        private void btnSelectGroupColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            panelSelectionGroupColor.BackColor = dialog.Color;

            SetSelectionGroupColorEvent?.Invoke(panelSelectionGroupColor.BackColor);
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

        private void colorSlider_Scroll(object sender, ScrollEventArgs e)
        {
            SetLightingIntensityEvent?.Invoke(e.NewValue);
        }

        private void chbTransparency_Click(object sender, EventArgs e)
        {
            SetTransparencyEvent?.Invoke(chbTransparency.Checked);
        }

        private void chbBackRibbers_Click(object sender, EventArgs e)
        {

        }

        private void clslNodes_ValueChanged(object sender, EventArgs e)
        {
            SetTransparencyValueEvent?.Invoke(ObjType.Узел, clslNodes.Value);
        }

        private void cls1D_ValueChanged(object sender, EventArgs e)
        {
            SetTransparencyValueEvent?.Invoke(ObjType.Элемент1D, cls1D.Value);
        }

        private void cls2D_ValueChanged(object sender, EventArgs e)
        {
            SetTransparencyValueEvent?.Invoke(ObjType.Элемент2D, cls2D.Value);
        }

        private void cls3D_ValueChanged(object sender, EventArgs e)
        {
            SetTransparencyValueEvent?.Invoke(ObjType.Элемент3D, cls3D.Value);
        }
    }
}
