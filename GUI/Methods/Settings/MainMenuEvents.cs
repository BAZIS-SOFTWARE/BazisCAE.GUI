using BazisGUI.SettingsControls;
using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using System.Linq;
using System.Windows.Forms;
using Model.Interfaces;
using BazisGUI.DataBases;
using BazisGUI.Scene.Interfaces;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripMenuItem;

            if (btn.Checked)
                OpenSettings();
            else
            {
                HideTabButton("btnTabНастройки");
                splitContainer3.Panel1.Controls.RemoveByKey("cntrНастройки");
            }
        }

        private void OpenSettings()
        {
            var settings = new SettingsControl()
            {
                Dock = DockStyle.Fill,
                Name = "cntrНастройки",
                //BorderStyle = BorderStyle.FixedSingle
            };

            settings.Leave += Settings_Leave;

            settings.SetSettings(settingsConfig);

            ShowTabButton("btnTabНастройки");

            settings.Size = cntrНавигатор.Size;
            settings.Location = cntrНавигатор.Location;
            settings.Anchor = cntrНавигатор.Anchor;

            splitContainer3.Panel1.Controls.Add(settings);
            settings.BringToFront();

            SetSettingsToConfig(settings);
        }

        private void Settings_Leave(object sender, EventArgs e)
        {
            SaveConfig(settingsConfig);
        }

        private void SetSettingsToConfig(SettingsControl settings)
        {

            settings.SetSelectionGroupColorEvent += (ar) =>

            {
                settingsConfig.SelectGroupColor = ar;
            };
            settings.SetSelectionObjectColorEvent += (ar) =>
            { 
                settingsConfig.SelectObjectColor = ar;
            };

            settings.SetNodeColorEvent += (ar) =>
            {
                //NodeColor = ar;
                var pres = project.CreateModelObjectsPresentor(ObjType.Узел);
                SetVBObjectAttribute(pres, "цвет");
                DisplayObjects();
            };

            settings.SetSolverPathEvent += (ar) =>
            {
                settingsConfig.SolverPath = ar;
            };
            settings.SetBackGroundColorEvent += (ar) =>
            {
                settingsConfig.BackGroundColor = ar;
                averageColorRenderer.BackgroundColor = ar;
                DisplayObjects();
            };


            settings.SetLightingEvent += (ar) =>
            {
                settingsConfig.Lighting = ar;
                averageColorRenderer.IsLighting = ar;
                DisplayObjects();
            };

            settings.SetTransparencyEvent += (ar) =>
            {
                settingsConfig.Transparency = ar;
                averageColorRenderer.IsEnable = ar;
                ClearAllDataOnScene();
                if(project != null)
                    CreateVBObjects("Объекты");
                DisplayObjects();
            };

            settings.SetOrtoProjectionEvent += (ar) =>
            {
                settingsConfig.Projection = ar ? ViewProjection.Parallel : ViewProjection.Perspective;
                UpdateProjection();
                DisplayObjects();
            };

            settings.SetTransparencyValueEvent += (ar1) =>
            {
                settingsConfig.TransparencyValue = (int)(ar1 / 100.0f * 255);

                settingsConfig.SelectObjectColor = Color.FromArgb(settingsConfig.TransparencyValue, settingsConfig.SelectObjectColor);
                settingsConfig.SelectGroupColor = Color.FromArgb(settingsConfig.TransparencyValue, settingsConfig.SelectGroupColor);

                var objs = project.ModelData.ObjectData.GetAllObjects();

                foreach (var obj in objs)
                {
                    var preColor = obj.Color;
                    var newColor = Color.FromArgb(settingsConfig.TransparencyValue, preColor);
                    obj.Color = newColor;
                }

                ClearAllDataOnScene();
                CreateVBObjects("Объекты");
                DisplayObjects();
            };

            settings.SetLightingIntensityEvent += (ar) =>
            {
                settingsConfig.LightingIntensity = ar;
                var lightAttenuation = 1 - ar / 100.0f;
                GL.Light(LightName.Light0, LightParameter.LinearAttenuation, lightAttenuation);
                DisplayObjects();
            };


            settings.SetLighterPositionEvent += (ar) =>
            {
                var kx = (float)(Width / settings.Width);
                var ky = (float)(Height / settings.Height);

                var x = ar.X * kx;
                var y = ar.Y * ky;

                settingsConfig.LighterPosition.X = (int)x;
                settingsConfig.LighterPosition.Y = (int)y;

                DisplayObjects();
            };
        }
    }
}
