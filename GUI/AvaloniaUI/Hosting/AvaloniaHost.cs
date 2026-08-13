using Avalonia;
using Avalonia.Themes.Fluent;
using Avalonia.Threading;
using System;
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

        public static void Post(Action action)
        {
            if (!isInitialized)
                throw new InvalidOperationException("Avalonia is not initialized.");

            Dispatcher.UIThread.Post(action);
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
