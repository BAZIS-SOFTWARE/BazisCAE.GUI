using Avalonia;
using Avalonia.Themes.Fluent;
using Avalonia.Threading;
using System;
using System.Globalization;
using System.Threading;

namespace BazisGUI.AvaloniaUI.Hosting
{
    internal static class AvaloniaHost
    {
        private static readonly ManualResetEventSlim initializedEvent = new(false);
        private static bool isInitialized;
        private static Exception initializationException;

        public static void Initialize()
        {
            if (isInitialized)
                return;

            var uiThread = new Thread(RunAvalonia)
            {
                IsBackground = true,
                Name = "BazisGUI Avalonia UI"
            };
            uiThread.SetApartmentState(ApartmentState.STA);
            uiThread.Start();

            initializedEvent.Wait();
            if (initializationException != null)
                throw new InvalidOperationException("Avalonia initialization failed.", initializationException);

            isInitialized = true;
        }

        /// <summary>
        /// Выполнить действие в UI-потоке Avalonia.
        /// </summary>
        /// <remarks>
        /// Avalonia работает в отдельном потоке, а языковая культура задаётся для потока,
        /// поэтому текущая языковая культура вызывающего потока переносится в UI-поток Avalonia.
        /// Благодаря этому окна Avalonia отображаются на языке, выбранном в настройках приложения.
        /// </remarks>
        /// <param name="action">Действие, выполняемое в UI-потоке Avalonia.</param>
        public static void Post(Action action)
        {
            if (!isInitialized)
                throw new InvalidOperationException("Avalonia is not initialized.");

            var uiCulture = CultureInfo.CurrentUICulture;

            Dispatcher.UIThread.Post(() =>
            {
                Thread.CurrentThread.CurrentUICulture = uiCulture;
                action();
            });
        }

        private static void RunAvalonia()
        {
            try
            {
                AppBuilder.Configure<BazisAvaloniaApplication>()
                    .UsePlatformDetect()
                    .SetupWithoutStarting();
            }
            catch (Exception ex)
            {
                initializationException = ex;
            }
            finally
            {
                initializedEvent.Set();
            }

            if (initializationException == null)
                Dispatcher.UIThread.MainLoop(CancellationToken.None);
        }

        private sealed class BazisAvaloniaApplication : Application
        {
            public override void Initialize()
            {
                Styles.Add(new FluentTheme());
            }
        }
    }
}
