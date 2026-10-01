using Avalonia.Automation;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Threading;
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
            Find<Button>(console, button => AutomationProperties.GetName(button) == "ClearAll")
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
}
