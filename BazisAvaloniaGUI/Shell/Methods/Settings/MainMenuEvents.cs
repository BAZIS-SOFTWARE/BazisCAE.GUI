using Avalonia.Controls;
using Avalonia.VisualTree;
using BazisAvaloniaGUI.Localization;
using BazisAvaloniaGUI.SettingsControls;
using BazisGUI.Scene.Interfaces;
using Model.Interfaces;
using System;
using System.Linq;

namespace BazisAvaloniaGUI.Shell
{
    internal partial class MainWindow
    {
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var btn = sender as MenuItem;
            var name = Resources.BaseForm_настройкиToolStripMenuItem_Click_Settings;
            // CheckOnClick: MenuItem с ToggleType = CheckBox переключает IsChecked до события Click.
            if (btn.IsChecked)
            {
                var settings = new SettingsControl();
                SubscribeLeave(settings, Settings_Leave);
                settings.SetSettings(settingsConfig);
                SetSettingsToConfig(settings);
                TabButtonsService.AddControl(name, settings);
            }
            else
                TabButtonsService.RemoveControl(name);
        }

        private void Settings_Leave(object sender, EventArgs e)
        {
            SaveConfig(settingsConfig);
        }

        /// <summary>
        /// Аналог события Control.Leave: фокус перешёл с элемента внутри <paramref name="control"/>
        /// на другой элемент этого же окна.
        /// </summary>
        /// <remarks>
        /// Потеря фокуса клавиатуры при активации другого окна (сообщения, диалога выбора цвета) событием
        /// Leave в WinForms не является. Если реагировать на неё, окно сообщения SaveConfig само снимает
        /// фокус со страницы и вызывает новое сохранение — сообщения появляются бесконечно.
        /// </remarks>
        private void SubscribeLeave(Control control, EventHandler leave)
        {
            var focusInside = false;
            control.GotFocus += (_, _) => focusInside = true;

            void OnWindowGotFocus(object sender, Avalonia.Interactivity.RoutedEventArgs e)
            {
                if (!focusInside || e.Source is not Avalonia.Visual focused || control.IsVisualAncestorOf(focused))
                    return;

                focusInside = false;
                leave(control, EventArgs.Empty);
            }

            AddHandler(GotFocusEvent, OnWindowGotFocus, Avalonia.Interactivity.RoutingStrategies.Bubble, handledEventsToo: true);
            control.DetachedFromVisualTree += (_, _) => RemoveHandler(GotFocusEvent, OnWindowGotFocus);
        }

        // Цвет фона, освещение, проекция, прозрачность отрисовки и положение источника света в BaseForm
        // передаются sceneController/averageColorRenderer. Настройка рендера — реализация SceneView, поэтому
        // здесь значения только сохраняются в settingsConfig (как и в SetGeneralSettings).
        private void SetSettingsToConfig(SettingsControl settings)
        {

            settings.SetSelectionGroupColorEvent += (ar) =>

            {
                settingsConfig.SelectGroupColor = ar;
            };
            settings.SetSelectionObjectColorEvent += (ar) =>
            {
                settingsConfig.SelectObjectColor = ar;
                ApplySelectionColor();
            };

            settings.SetNodeColorEvent += (ar) =>
            {
                settingsConfig.NodeColor = ar;
                var setInfo = project.GetModelSetsInfo(ObjType.Узел).FirstOrDefault();
                if (setInfo != null)
                    project.ModelView.SetColor(setInfo, ar);
            };

            settings.SetSolverPathEvent += (ar) =>
            {
                settingsConfig.SolverPath = ar;
            };
            settings.SetBackGroundColorEvent += (ar) =>
            {
                settingsConfig.BackGroundColor = ar;
                RequestRedraw();
            };


            settings.SetLightingEvent += (ar) =>
            {
                settingsConfig.Lighting = ar;
                RequestRedraw();
            };

            settings.SetTransparencyEvent += (ar) =>
            {
                settingsConfig.Transparency = ar;
                ClearAllDataOnScene();
                if (project != null)
                    CreateVBObjects("Объекты");
                RequestRedraw();
            };

            settings.SetOrtoProjectionEvent += (ar) =>
            {
                settingsConfig.Projection = ar ? ViewProjection.Parallel : ViewProjection.Perspective;
                RequestRedraw();
            };

            settings.SetTransparencyValueEvent += (ar1) =>
            {
                settingsConfig.TransparencyValue = ar1;
                if (project != null)
                    project.ModelView.Transparency = GetModelViewTransparency();
            };

            settings.SetLightingIntensityEvent += (ar) =>
            {
                settingsConfig.LightingIntensity = ar;
                RequestRedraw();
            };


            settings.SetLighterPositionEvent += (ar) =>
            {
                var kx = (float)(Bounds.Width / settings.Bounds.Width);
                var ky = (float)(Bounds.Height / settings.Bounds.Height);

                var x = ar.X * kx;
                var y = ar.Y * ky;

                settingsConfig.LighterPosition.X = (int)x;
                settingsConfig.LighterPosition.Y = (int)y;

                RequestRedraw();
            };

            settings.SetLanguageEvent += (ar) =>
            {
                if (settingsConfig.Language != ar)
                {
                    MessageBox.Show(this, Resources.MainMenuEvents_ChangeLanguage_Message, Localization.Localization.GetAttentionCaption());
                    settingsConfig.Language = ar;
                }
            };
        }
    }
}
