using Avalonia;
using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Threading;
using Avalonia.VisualTree;
using NUnit.Framework;
using System.Diagnostics;

namespace BazisAvaloniaGUI.Tests;

/// <summary>Общая инициализация Avalonia Headless для всех тестов (платформу можно поднять один раз за процесс).</summary>
[TestFixture]
public partial class AvaloniaTests
{
    private string directory = null!;

    [OneTimeSetUp]
    public void SetupAvalonia()
    {
        AppBuilder.Configure<App>().UseSkia().UseHeadless(new AvaloniaHeadlessPlatformOptions { UseHeadlessDrawing = false, ShouldRenderOnUIThread = true }).SetupWithoutStarting();
        SynchronizationContext.SetSynchronizationContext(new AvaloniaSynchronizationContext());
    }

    [SetUp]
    public void Setup()
    {
        directory = Path.Combine(Path.GetTempPath(), "BazisAvaloniaTests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
    }

    [TearDown]
    public void Cleanup()
    {
        if (Directory.Exists(directory))
            Directory.Delete(directory, true);
    }

    /// <summary>Прокачивает очередь диспетчера, пока не выполнится условие (асинхронные обработчики UI).</summary>
    private static void Pump(Func<bool> done, int timeoutMs = 60000)
    {
        var watch = Stopwatch.StartNew();
        while (!done())
        {
            Dispatcher.UIThread.RunJobs();
            if (watch.ElapsedMilliseconds > timeoutMs)
                Assert.Fail("Операция не завершилась за отведённое время.");
            Thread.Sleep(10);
        }
        Dispatcher.UIThread.RunJobs();
    }

    private static T Find<T>(Visual root, Func<T, bool>? predicate = null) where T : Visual =>
        root.GetVisualDescendants().OfType<T>().First(item => predicate?.Invoke(item) ?? true);

    private static string RepositoryFile(params string[] parts)
    {
        var current = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
        while (current != null && !File.Exists(Path.Combine(current.FullName, "BazisGUISolution.sln")))
            current = current.Parent;
        if (current == null) throw new DirectoryNotFoundException("Не найден корень репозитория.");
        return Path.Combine([current.FullName, .. parts]);
    }
}
