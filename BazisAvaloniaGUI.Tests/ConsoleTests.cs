using Avalonia;
using Avalonia.Automation;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Headless;
using Avalonia.Threading;
using Avalonia.VisualTree;
using BazisAvaloniaGUI.Console;
using NUnit.Framework;
using System.Drawing;
using System.Reflection;

namespace BazisAvaloniaGUI.Tests;

public partial class AvaloniaTests
{
    private (Window Window, ConsoleControl Console) ShowConsole()
    {
        var console = new ConsoleControl();
        var window = new Window { Width = 400, Height = 200, Content = console };
        window.Show();
        Dispatcher.UIThread.RunJobs();
        // Номер сессии вне диапазона Random.Next(0, 10000), чтобы не задеть журналы приложения.
        console.SessionNumber = 100000 + Random.Shared.Next(100000);
        return (window, console);
    }

    [Test]
    public void PrintInfoKeepsColorAndAppendsMessageToSessionLog()
    {
        var (window, console) = ShowConsole();
        try
        {
            console.PrintInfo("message", Color.Black);
            console.PrintInfo("error", Color.Red);
            Assert.That(console.Messages.Last(), Is.EqualTo(new ConsoleMessage(" > error", Color.Red)));
            Assert.That(File.ReadAllText(console.GetSessionLogPath), Is.EqualTo("messageerror"));
        }
        finally
        {
            window.Close();
            File.Delete(console.GetSessionLogPath);
        }
    }

    [Test]
    public void ClearAllKeepsSessionHeader()
    {
        var (window, console) = ShowConsole();
        try
        {
            console.Messages.Add(new ConsoleMessage("line", Color.Black));
            Find<Button>(console, button => button.Name == "toolStripButton2")
                .RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            Assert.That(console.Messages, Has.Count.EqualTo(1));
            Assert.That(console.Messages[0].Color, Is.EqualTo(Color.Green));
        }
        finally { window.Close(); }
    }

    [Test]
    public void ConsoleHistoryReturnsCommandsLikeWinForms()
    {
        ConsoleHistory.AddComand("history-1");
        ConsoleHistory.AddComand("history-2");
        ConsoleHistory.AddComand("history-2");
        Assert.That(ConsoleHistory.GetPreviousCommand(), Is.EqualTo("history-2"));
        Assert.That(ConsoleHistory.GetPreviousCommand(), Is.EqualTo("history-1"));
        Assert.That(ConsoleHistory.GetNextCommand(), Is.EqualTo("history-2"));
        Assert.That(ConsoleHistory.GetNextCommand(), Is.Empty);
    }

    [Test]
    public void MacroUsesVariablesAndStopsOnFirstError()
    {
        var (window, console) = ShowConsole();
        try
        {
            var calls = new List<string>();
            console.ConsoleCommandEnteredEvent += line =>
            {
                calls.Add(line);
                if (line == "fail") throw new InvalidOperationException("failure");
                return Task.FromResult(line == "one" ? "1" : "");
            };
            var path = Path.Combine(directory, "commands.tcf");
            File.WriteAllLines(path, ["// comment", "$a = one", "use $a", "fail", "never"]);

            var execute = typeof(ConsoleControl).GetMethod("ExecuteCmdFile", BindingFlags.Instance | BindingFlags.NonPublic)!;
            var task = (Task)execute.Invoke(console, [path])!;
            Pump(() => task.IsCompleted);

            Assert.That(calls, Is.EqualTo(new[] { "one", "use 1", "fail" }));
            Assert.That(console.Messages.Last().Text, Does.Contain("failure in line: fail"));
        }
        finally
        {
            window.Close();
            File.Delete(console.GetSessionLogPath);
        }
    }

    [Test]
    public void EnterSendsCommandAndKeepsItInOutput()
    {
        var (window, console) = ShowConsole();
        try
        {
            var input = Find<TextBox>(console);
            string? executed = null;
            console.ConsoleCommandEnteredEvent += line => { executed = line; ConsoleHistory.AddComand(line); return Task.FromResult(""); };
            input.Text = "\"Create task\"";
            input.RaiseEvent(new KeyEventArgs { RoutedEvent = InputElement.KeyDownEvent, Key = Key.Enter });
            Dispatcher.UIThread.RunJobs();

            Assert.That(executed, Is.EqualTo("\"Create task\""));
            Assert.That(input.Text, Is.Empty);
            Assert.That(console.Messages.Last().Text, Is.EqualTo("\"Create task\""));

            input.RaiseEvent(new KeyEventArgs { RoutedEvent = InputElement.KeyDownEvent, Key = Key.Up });
            Assert.That(input.Text, Is.EqualTo("\"Create task\""));
        }
        finally { window.Close(); }
    }

    [Test]
    public void ToolbarMatchesWinFormsToolStrip()
    {
        var (window, console) = ShowConsole();
        try
        {
            var buttons = console.GetVisualDescendants().OfType<Button>().Where(button => button.Classes.Contains("console-action")).ToList();
            Assert.That(buttons.Select(button => button.Name), Is.EqualTo(new[] { "spbDictionary", "toolStripButton1", "toolStripButton2", "btnStartMacro" }));
            foreach (var button in buttons)
            {
                Assert.That(button.Content, Is.TypeOf<Image>());
                Assert.That(((Image)button.Content!).Source, Is.Not.Null);
                Assert.That(ToolTip.GetTip(button), Is.Not.Null.And.Not.EqualTo(button.Name));
            }

            var requested = false;
            console.CommandsListRequestedEvent += () => requested = true;
            buttons[0].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            Assert.That(requested, Is.True);
        }
        finally { window.Close(); }
    }

    [Test]
    public void SessionLinkIsOnFirstLineAndInputIsInsideField()
    {
        var (window, console) = ShowConsole();
        try
        {
            var header = Find<SelectableTextBlock>(console);
            var link = Find<Button>(console, button => button.Classes.Contains("console-log"));
            var linkText = (TextBlock)link.Content!;
            Assert.That(linkText.Text, Does.EndWith("bazis.session.txt"));
            Assert.That(linkText.TextDecorations, Is.EqualTo(Avalonia.Media.TextDecorations.Underline));

            var headerOrigin = header.TranslatePoint(new Avalonia.Point(), console)!.Value;
            var linkOrigin = link.TranslatePoint(new Avalonia.Point(), console)!.Value;
            Assert.That(linkOrigin.Y, Is.EqualTo(headerOrigin.Y).Within(1));
            Assert.That(linkOrigin.X, Is.GreaterThanOrEqualTo(headerOrigin.X + header.Bounds.Width - 1));

            // Ввод — последняя строка поля, без отдельной рамки.
            var input = Find<TextBox>(console);
            Assert.That(console.GetVisualDescendants().OfType<TextBox>().Count(), Is.EqualTo(1));
            Assert.That(input.BorderThickness, Is.EqualTo(new Avalonia.Thickness(0)));
            Assert.That(input.TranslatePoint(new Avalonia.Point(), console)!.Value.Y, Is.GreaterThan(headerOrigin.Y));

            var collapsed = false;
            console.ControlCollapseEvent += () => collapsed = true;
            Find<Button>(console, button => button.Name == "ControlCollapse").RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            Assert.That(collapsed, Is.True);

            console.PrintInfo("error", Color.Red);
            Dispatcher.UIThread.RunJobs();
            var line = console.GetVisualDescendants().OfType<SelectableTextBlock>().Last();
            var runs = line.Inlines!.OfType<Avalonia.Controls.Documents.Run>().ToList();
            Assert.That(runs.Select(run => run.Text), Is.EqualTo(new[] { " > ", "error" }));
            Assert.That(((Avalonia.Media.ISolidColorBrush)runs[1].Foreground!).Color, Is.EqualTo(Avalonia.Media.Colors.Red));

            using var frame = window.CaptureRenderedFrame();
            Assert.That(frame, Is.Not.Null);
            var snapshots = Environment.GetEnvironmentVariable("BAZIS_CONSOLE_SNAPSHOT_DIR");
            if (!string.IsNullOrEmpty(snapshots))
            {
                Directory.CreateDirectory(snapshots);
                frame!.Save(Path.Combine(snapshots, "console.png"), new Avalonia.Media.Imaging.PngBitmapEncoderOptions());
            }
        }
        finally
        {
            window.Close();
            File.Delete(console.GetSessionLogPath);
        }
    }
}
