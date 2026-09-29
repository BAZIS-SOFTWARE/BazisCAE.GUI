using Avalonia;
using Avalonia.OpenGL;

namespace BazisAvaloniaGUI;

internal class Program
{
    // Точка входа .NET должна быть статической.
    private static void Main(string[] args)
    {
        var builder = AppBuilder.Configure<App>().UsePlatformDetect();
        var profiles = new[]
        {
            new GlVersion(GlProfileType.OpenGL, 4, 6, isCompatibilityProfile: true),
            new GlVersion(GlProfileType.OpenGL, 3, 3, isCompatibilityProfile: true)
        };

        if (OperatingSystem.IsWindows())
            builder = builder.With(new Win32PlatformOptions
            {
                RenderingMode = [Win32RenderingMode.Wgl],
                WglProfiles = profiles
            });
        else if (OperatingSystem.IsLinux())
            builder = builder.With(new X11PlatformOptions
            {
                RenderingMode = [X11RenderingMode.Glx],
                GlProfiles = profiles
            });

        builder.StartWithClassicDesktopLifetime(args);
    }
}
