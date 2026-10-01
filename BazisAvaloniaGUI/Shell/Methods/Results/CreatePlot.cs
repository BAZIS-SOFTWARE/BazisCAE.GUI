using Avalonia.Input;
using Avalonia.Threading;
using BazisAvaloniaGUI.Localization;
using Geometry;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace BazisAvaloniaGUI.Shell
{
    // Из GUI/Methods/Results/CreatePlot.cs перенесён только SelectContainerAsync (нужен команде "Move node");
    // построение графиков результатов в Avalonia ещё не перенесено.
    internal partial class MainWindow
    {
        public async Task SelectContainerAsync(string message)
        {
            PressedKey = Key.None;

            DisplayText2D(message, Color.Black, new Point2D(10, 10));
            RequestRedraw();
            await System.Threading.Tasks.Task.Run(() =>
            {
                while (true)
                {
                    if (PressedKey == Key.E)
                        break;
                    if (PressedKey == Key.Escape)
                    {
                        Dispatcher.UIThread.Invoke(new Action(() => console.PrintInfo(Resources.CreatePlot_SelectContainerAsync_CancelOperation_Message, Color.Black)));
                        break;
                    }
                }
            });
            DisplayText2DEvent = null;
            RequestRedraw();
            PressedKey = Key.None;
        }
    }
}
