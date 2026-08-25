using BazisGUI.AvaloniaUI.SettingsControl.Services;
using BazisGUI.DataBases;
using BazisGUI.Properties;
using BazisGUI.Scene.Interfaces;
using BazisGUI.SettingsControls;
using Model.Interfaces;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (настройкиToolStripMenuItem.Checked)
                {
                    var synchronizationContext = SynchronizationContext.Current;
                    var operationService = new SynchronizationContextSettingsOperationService(
                        synchronizationContext,
                        RequestSetBackgroundColor,
                        RequestSetSelectionObjectColor,
                        RequestSetSelectionGroupColor,
                        RequestSetNodeColor,
                        RequestSetSolverPath,
                        RequestSetLighting,
                        RequestSetLightingIntensity,
                        RequestSetLighterPosition,
                        RequestSetTransparency,
                        RequestSetTransparencyValue,
                        RequestSetOrtoProjection,
                        RequestSetLanguage,
                        RequestSaveSettings);

                    SettingsWindowService.Show(operationService, settingsConfig, () => synchronizationContext.Post(_ => OnSettingsWindowClosed(), null));
                }
                else
                    SettingsWindowService.Close();
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }

        /// <summary>
        /// Применение цвета заднего фона. Вызывается в UI-потоке WinForms из окна Avalonia.
        /// </summary>
        private void RequestSetBackgroundColor(Color color)
        {
            settingsConfig.BackGroundColor = color;
            averageColorRenderer.BackgroundColor = color;
            DisplayObjects();
            SaveConfig(settingsConfig);
        }

        /// <summary>
        /// Применение цвета выделения объектов.
        /// </summary>
        private void RequestSetSelectionObjectColor(Color color)
        {
            settingsConfig.SelectObjectColor = color;
            SaveConfig(settingsConfig);
        }

        /// <summary>
        /// Применение цвета выделения групп.
        /// </summary>
        private void RequestSetSelectionGroupColor(Color color)
        {
            settingsConfig.SelectGroupColor = color;
            SaveConfig(settingsConfig);
        }

        /// <summary>
        /// Применение цвета узлов.
        /// </summary>
        private void RequestSetNodeColor(Color color)
        {
            settingsConfig.NodeColor = color;
            if (project != null)
            {
                var pres = project.CreateModelObjectsPresentor(ObjType.Узел);
                SetVBObjectAttribute(pres, "цвет");
                DisplayObjects();
            }
            SaveConfig(settingsConfig);
        }

        /// <summary>
        /// Применение пути до решателя.
        /// </summary>
        private void RequestSetSolverPath(string path) => settingsConfig.SolverPath = path;

        /// <summary>
        /// Включение/выключение освещения.
        /// </summary>
        private void RequestSetLighting(bool enabled)
        {
            settingsConfig.Lighting = enabled;
            averageColorRenderer.IsLighting = enabled;
            DisplayObjects();
        }

        /// <summary>
        /// Применение интенсивности освещения (0..100).
        /// </summary>
        private void RequestSetLightingIntensity(int intensity)
        {
            settingsConfig.LightingIntensity = intensity;
            var lightAttenuation = 1 - intensity / 100.0f;
            GL.Light(LightName.Light0, LightParameter.LinearAttenuation, lightAttenuation);
            DisplayObjects();
        }

        /// <summary>
        /// Применение положения источника света с масштабированием координат
        /// контрола выбора света к размерам сцены.
        /// </summary>
        private void RequestSetLighterPosition(double x, double y, double controlWidth, double controlHeight)
        {
            var kx = controlWidth > 0 ? (float)(Width / controlWidth) : 1f;
            var ky = controlHeight > 0 ? (float)(Height / controlHeight) : 1f;

            settingsConfig.LighterPosition.X = (int)(x * kx);
            settingsConfig.LighterPosition.Y = (int)(y * ky);

            DisplayObjects();
        }

        /// <summary>
        /// Включение/выключение прозрачности.
        /// </summary>
        private void RequestSetTransparency(bool enabled)
        {
            settingsConfig.Transparency = enabled;
            averageColorRenderer.IsEnable = enabled;
            ClearAllDataOnScene();
            if (project != null)
                CreateVBObjects("Объекты");
            DisplayObjects();
        }

        /// <summary>
        /// Применение значения прозрачности (0..100) ко всем объектам сцены.
        /// </summary>
        private void RequestSetTransparencyValue(int value)
        {
            settingsConfig.TransparencyValue = (int)(value / 100.0f * 255);

            settingsConfig.SelectObjectColor = Color.FromArgb(settingsConfig.TransparencyValue, settingsConfig.SelectObjectColor);
            settingsConfig.SelectGroupColor = Color.FromArgb(settingsConfig.TransparencyValue, settingsConfig.SelectGroupColor);

            var objs = project.GetAllModelObjects();
            foreach (var obj in objs)
            {
                var preColor = obj.Color;
                var newColor = Color.FromArgb(settingsConfig.TransparencyValue, preColor);
                obj.Color = newColor;
            }

            ClearAllDataOnScene();
            CreateVBObjects("Объекты");
            DisplayObjects();
        }

        /// <summary>
        /// Включение ортографической проекции.
        /// </summary>
        private void RequestSetOrtoProjection(bool enabled)
        {
            settingsConfig.Projection = enabled ? ViewProjection.Parallel : ViewProjection.Perspective;
            UpdateProjection();
            DisplayObjects();
        }

        /// <summary>
        /// Применение языка интерфейса (код «ru»/«en»).
        /// </summary>
        private void RequestSetLanguage(string language)
        {
            if (settingsConfig.Language != language)
            {
                MessageBox.Show(Resources.MainMenuEvents_ChangeLanguage_Message, Localization.Localization.GetAttentionCaption());
                settingsConfig.Language = language;
            }
        }

        /// <summary>
        /// Сохранение конфигурации настроек при закрытии окна.
        /// </summary>
        private void RequestSaveSettings() => SaveConfig(settingsConfig);

        /// <summary>
        /// Приводит состояние пункта меню в соответствие с фактическим состоянием окна.
        /// Программное снятие флажка не вызывает событие <see cref="ToolStripItem.Click"/>.
        /// Выполняется в UI-потоке WinForms.
        /// </summary>
        private void OnSettingsWindowClosed()
        {
            if (IsDisposed || Disposing)
                return;

            настройкиToolStripMenuItem.Checked = false;
        }
    }
}
