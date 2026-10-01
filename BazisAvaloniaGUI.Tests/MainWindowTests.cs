using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Threading;
using BazisAvaloniaGUI.Console;
using BazisAvaloniaGUI.Shell;
using NUnit.Framework;
using OperationalController;

namespace BazisAvaloniaGUI.Tests;

public partial class AvaloniaTests
{
    [Test]
    public void MainMenuFollowsBaseFormStructureAndInitialState()
    {
        var window = new MainWindow();
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            var menu = Find<Menu>(window);
            var top = menu.ItemsSource!.Cast<MenuItem>().ToList();
            Assert.That(top.Select(item => item.Name), Is.EqualTo(new[]
            {
                "файлToolStripMenuItem", "viewMenuItem", "геометрияToolStripMenuItem", "сеткаToolStripMenuItem",
                "dataBasesMenuItem", "tasksMenuItem", "расчетыToolStripMenuItem", "результатыMenuItem",
                "инструментыToolStripMenuItem", "настройкиToolStripMenuItem", "справкаToolStripMenuItem", "лицензияToolStripMenuItem"
            }));
            var disabled = top.Where(item => !item.IsEnabled).Select(item => item.Name).ToList();
            Assert.That(disabled, Is.EquivalentTo(new[]
            {
                "геометрияToolStripMenuItem", "сеткаToolStripMenuItem", "dataBasesMenuItem", "tasksMenuItem",
                "расчетыToolStripMenuItem", "результатыMenuItem", "инструментыToolStripMenuItem", "настройкиToolStripMenuItem"
            }));
            Assert.That(top.All(item => item.Header is string header && !header.Contains('&')), Is.True);
        }
        finally { window.Close(); }
    }

    [Test]
    public void ConsoleCommandsLoadProjectChangeTaskTypeAndSave()
    {
        var source = Path.Combine(directory, "source.bpf2");
        var created = new ProjectController();
        created.CreateProject(Path.GetFileName(source));
        created.CreateTask();
        created.Save(source);

        var window = new MainWindow();
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            var console = Find<ConsoleControl>(window);
            var input = Find<TextBox>(console);
            void Enter(string command)
            {
                input.Text = command;
                input.RaiseEvent(new KeyEventArgs { RoutedEvent = InputElement.KeyDownEvent, Key = Key.Enter });
            }

            Enter("\"Unknown command\"");
            Pump(() => console.Messages.Last().Text.Contains("in line: \"Unknown command\""));

            // Окно "Загрузка" открывается синхронно и закрывается в продолжении после Task.Run(Load).
            Enter($"\"Load project\" \"{source}\"");
            Assert.That(window.OwnedWindows.Single().Name, Is.EqualTo("Загрузка"));
            Pump(() => window.OwnedWindows.Count == 0);

            Enter("\"Change task type\" \"Plain\"");
            var saved = Path.Combine(directory, "saved.bpf2");
            Enter($"\"Save project\" \"{saved}\"");
            Pump(() => File.Exists(saved));

            var reloaded = new ProjectController();
            reloaded.Load(saved);
            Assert.That(reloaded.TaskType.ToString(), Is.EqualTo("Plain"));
        }
        finally { window.Close(); }
    }
}
