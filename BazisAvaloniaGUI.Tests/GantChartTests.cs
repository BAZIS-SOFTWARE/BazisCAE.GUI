using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using BazisAvaloniaGUI.GantChart;
using Model.Interfaces;
using NUnit.Framework;
using Project.Interfaces.Tasks;
using Project.Tasks.Functions;
using Project.Tasks.LocalFrames;

namespace BazisAvaloniaGUI.Tests;

public partial class AvaloniaTests
{
    /// <summary>Условие с текстовым представлением в формате "Вид : ...", как у условий проекта.</summary>
    private sealed class FakeCondition(DataKind kind, string text, float start, float stop) : ICondData
    {
        public double Value { get; set; }
        public Direction Direction => default;
        public Function Function { get; set; }
        public LocalFrame LocalFrame { get; set; }
        public DataKind Kind => kind;
        public IGroup Group { get; set; }
        public float StartTime { get; set; } = start;
        public float StopTime { get; set; } = stop;
        public void TrySetDirection(string direction) { }
        public void TrySetValue(string value) { }
        public override string ToString() => $"{kind} : {text}";
    }

    internal static ICondData[] GanttConditions() => new ICondData[]
    {
        new FakeCondition(DataKind.Нагрев, "group 1 value 10 time 5 stop", 2, 8),
        new FakeCondition(DataKind.Материал, "group 2 value 1 time 1 stop", 0, 10)
    };

    [Test]
    public void GanttChartListsConditionsAndSortsByTimeColumn()
    {
        var gantt = new cntrГант();
        gantt.AddConds(GanttConditions());
        var window = new Window { Width = 385, Height = 200, Content = gantt };
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            IEnumerable<string> Names() => Avalonia.VisualTree.VisualExtensions.GetVisualDescendants(gantt)
                .OfType<TextBlock>().Where(text => text.Text?.Contains(" : ") == true).Select(text => text.Text!);

            Assert.That(Names().Select(name => name.Split(" : ")[1]), Is.EqualTo(new[] { "group 1 value 10 time 5 stop", "group 2 value 1 time 1 stop" }));

            // Колонка CondTime сортируется по шестому слову описания условия (dataGridView_SortCompare).
            Find<Button>(gantt, button => button.Name == "CondTime").RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            Dispatcher.UIThread.RunJobs();
            Assert.That(Names().Select(name => name.Split(" : ")[1]), Is.EqualTo(new[] { "group 2 value 1 time 1 stop", "group 1 value 10 time 5 stop" }));
        }
        finally { window.Close(); }
    }
}
