using Avalonia;
using Avalonia.Themes.Fluent;

namespace BazisGUI.AvaloniaUI.Chamfer
{
    internal static class ChamferAvaloniaHost
    {
        private static bool isInitialized;

        public static void Initialize()
        {
            if (isInitialized)
                return;

            AppBuilder.Configure<ChamferAvaloniaApplication>()
                .UsePlatformDetect()
                .SetupWithoutStarting();

            isInitialized = true;
        }

        private sealed class ChamferAvaloniaApplication : Application
        {
            public override void Initialize()
            {
                Styles.Add(new FluentTheme());
            }
        }
    }
}
