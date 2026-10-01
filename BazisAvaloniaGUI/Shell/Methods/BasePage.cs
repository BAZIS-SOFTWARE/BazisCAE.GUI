using Avalonia.Input;
using Avalonia.Threading;
using Geometry;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace BazisAvaloniaGUI.Shell
{
    internal partial class MainWindow
    {
        /// <summary>Кнопка на клавиатуре</summary>
        public Key PressedKey { get; set; }

        public async Task<object> AsyncMethodContainer(Func<Tuple<bool, object>> actConfirm, Action actBreak, string cmdMessage)
        {
            object resObject = null;
            PressedKey = Key.None;
            Dispatcher.UIThread.Invoke(new Action(() =>
            {

                var color = GetTextColor();

                DisplayText2D(cmdMessage, color, new Point2D(10, 10));
                RequestRedraw();
            }));
            await System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (PressedKey == Key.E)
                    {
                        var resAction = actConfirm.Invoke();
                        if (resAction.Item1)
                        {
                            resObject = resAction.Item2;
                            break;
                        }
                        PressedKey = Key.None;
                    }
                    if (PressedKey == Key.Escape)
                    {
                        actBreak.Invoke();
                        break;
                    }
                }
            });

            DisplayText2DEvent = null;
            RequestRedraw();

            PressedKey = Key.None;
            return resObject;
        }

        private Color GetTextColor()
        {
            var backgroundBrightness = 0.299 * settingsConfig.BackGroundColor.R + 0.587 *
                settingsConfig.BackGroundColor.G + 0.114 *
                settingsConfig.BackGroundColor.B;

            if (backgroundBrightness > 125) // Или другое пороговое значение
            {
                return Color.Black; // Светлый фон -> черный шрифт
            }
            else
            {
                return Color.White; // Темный фон -> белый шрифт
            }
        }
    }
}
