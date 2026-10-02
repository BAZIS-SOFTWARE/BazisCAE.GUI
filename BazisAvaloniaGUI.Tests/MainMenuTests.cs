using Avalonia;
using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Threading;
using BazisAvaloniaGUI.Console;
using BazisAvaloniaGUI.Navigator;
using BazisAvaloniaGUI.SettingsControls;
using BazisAvaloniaGUI.Shell;
using NUnit.Framework;
using OperationalController;
using System.Reflection;

namespace BazisAvaloniaGUI.Tests;

/// <summary>Пункты верхнего меню, перенесённые из BaseForm.</summary>
public partial class AvaloniaTests
{
    private MainWindow ShowWindowWithProject()
    {
        var source = Path.Combine(directory, "menu.bpf2");
        var created = new ProjectController();
        created.CreateProject(Path.GetFileName(source));
        created.CreateTask();
        created.Save(source);

        var window = new MainWindow();
        window.Show();
        Dispatcher.UIThread.RunJobs();
        var open = (Task)typeof(MainWindow).GetMethod("OpenProject", BindingFlags.Instance | BindingFlags.NonPublic)!.Invoke(window, new object[] { source })!;
        Pump(() => open.IsCompleted);
        return window;
    }

    private static MenuItem MenuItemByName(Window window, string name)
    {
        var menu = Find<Menu>(window);
        IEnumerable<MenuItem> Flatten(IEnumerable<object> items) =>
            items.OfType<MenuItem>().SelectMany(item => new[] { item }.Concat(Flatten(item.ItemsSource?.Cast<object>() ?? Array.Empty<object>())));
        return Flatten(menu.ItemsSource!.Cast<object>()).Single(item => item.Name == name);
    }

    [Test]
    public void ProjectLoadingUnblocksMenusLikeBaseForm()
    {
        var window = ShowWindowWithProject();
        try
        {
            foreach (var name in new[] { "расчетыToolStripMenuItem", "результатыMenuItem", "инструментыToolStripMenuItem" })
                Assert.That(MenuItemByName(window, name).IsEnabled, Is.True, name);

            // В BaseForm.resx эти пункты отключены всегда.
            foreach (var name in new[] { "объединитьToolStripMenuItem", "экспортироватьРезультатыToolStripMenuItem", "рассечьПлоскостьюToolStripMenuItem" })
                Assert.That(MenuItemByName(window, name).IsEnabled, Is.False, name);
        }
        finally { window.Close(); }
    }

    [Test]
    public void SettingsMenuClickTogglesSettingsPageOnce()
    {
        var window = new MainWindow();
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            var item = MenuItemByName(window, "настройкиToolStripMenuItem");
            var center = item.TranslatePoint(new Point(item.Bounds.Width / 2, item.Bounds.Height / 2), window)!.Value;
            var name = Localization.Resources.BaseForm_настройкиToolStripMenuItem_Click_Settings;

            window.MouseDown(center, MouseButton.Left);
            window.MouseUp(center, MouseButton.Left);
            Dispatcher.UIThread.RunJobs();
            Assert.That(item.IsChecked, Is.True);
            Assert.That(window.TabButtonsService.GetNames(), Does.Contain(name));
            Assert.That(window.TabButtonsService.GetControl(name), Is.TypeOf<SettingsControl>());

            window.MouseDown(center, MouseButton.Left);
            window.MouseUp(center, MouseButton.Left);
            Dispatcher.UIThread.RunJobs();
            Assert.That(item.IsChecked, Is.False);
            Assert.That(window.TabButtonsService.GetNames(), Does.Not.Contain(name));
        }
        finally { window.Close(); }
    }

    [Test]
    public void SettingsLeaveFiresOnceForFocusMoveInsideWindowAndNotForOtherWindow()
    {
        var window = new MainWindow();
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            var inside = new TextBox();
            var page = new Border { Child = inside };
            var outside = new TextBox();
            var panel = new StackPanel { Children = { page, outside } };
            window.TabButtonsService.AddControl("LeaveTest", panel);
            Dispatcher.UIThread.RunJobs();

            var leaves = 0;
            typeof(MainWindow).GetMethod("SubscribeLeave", BindingFlags.Instance | BindingFlags.NonPublic)!
                .Invoke(window, new object[] { page, new EventHandler((_, _) => leaves++) });

            inside.Focus();
            Dispatcher.UIThread.RunJobs();
            // Окно сообщения (как в SaveConfig) забирает активацию, но фокус в главном окне не переходит.
            var message = new Window { Content = new TextBox() };
            message.Show();
            Dispatcher.UIThread.RunJobs();
            message.Close();
            Dispatcher.UIThread.RunJobs();
            Assert.That(leaves, Is.EqualTo(0));

            outside.Focus();
            Dispatcher.UIThread.RunJobs();
            Assert.That(leaves, Is.EqualTo(1));

            outside.Focus();
            inside.Focus();
            Dispatcher.UIThread.RunJobs();
            Assert.That(leaves, Is.EqualTo(1));
        }
        finally { window.Close(); }
    }

    [Test]
    public void SplittersStopAtPanelMinSizesAndPanelsStillCollapse()
    {
        var window = new MainWindow { WindowState = WindowState.Normal, Width = 942, Height = 625 };
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            double MinSize(string name) => (double)typeof(MainWindow).GetField(name, BindingFlags.Static | BindingFlags.NonPublic)!.GetValue(null)!;
            var navigatorMin = MinSize("NavigatorPanelMinWidth");
            var consoleMin = MinSize("ConsolePanelMinHeight");
            var panelMin = MinSize("PanelMinSize");
            var splitters = Avalonia.VisualTree.VisualExtensions.GetVisualDescendants(window).OfType<GridSplitter>().ToList();
            var splitter = splitters.Single(item => item.ResizeDirection == GridResizeDirection.Columns);
            var grid = (Grid)splitter.Parent!;
            // Разделитель сцены и консоли: строки "сцена, разделитель, консоль" в одной сетке с колонкой сцены.
            var consoleSplitter = splitters.Single(item => item.ResizeDirection == GridResizeDirection.Rows && ((Grid)item.Parent!).RowDefinitions[2].MinHeight == consoleMin);
            var consoleGrid = (Grid)consoleSplitter.Parent!;

            void Drag(GridSplitter target, Point to)
            {
                var from = target.TranslatePoint(new Point(target.Bounds.Width / 2, target.Bounds.Height / 2), window)!.Value;
                window.MouseDown(from, MouseButton.Left);
                window.MouseMove(to, RawInputModifiers.LeftMouseButton);
                window.MouseUp(to, MouseButton.Left);
                Dispatcher.UIThread.RunJobs();
            }

            Drag(splitter, new Point(-500, 300));
            Assert.That(grid.ColumnDefinitions[0].ActualWidth, Is.EqualTo(navigatorMin).Within(0.5));
            Drag(splitter, new Point(window.Bounds.Width + 500, 300));
            Assert.That(grid.ColumnDefinitions[2].ActualWidth, Is.EqualTo(panelMin).Within(0.5));
            Drag(splitter, new Point(500, 300));

            Drag(consoleSplitter, new Point(700, window.Bounds.Height + 500));
            Assert.That(consoleGrid.RowDefinitions[2].ActualHeight, Is.EqualTo(consoleMin).Within(0.5));
            Drag(consoleSplitter, new Point(700, -500));
            Assert.That(consoleGrid.RowDefinitions[0].ActualHeight, Is.EqualTo(panelMin).Within(0.5));

            // "Вид → Навигатор" скрывает панель полностью, несмотря на минимум.
            // Флажок пункта показывает, видна ли панель.
            var view = MenuItemByName(window, "toolStripMenuItem2");
            Assert.That(view.IsChecked, Is.True);
            view.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
            Dispatcher.UIThread.RunJobs();
            Assert.That(grid.ColumnDefinitions[0].ActualWidth, Is.EqualTo(0));
            Assert.That(view.IsChecked, Is.False);
            view.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
            Dispatcher.UIThread.RunJobs();
            Assert.That(grid.ColumnDefinitions[0].ActualWidth, Is.GreaterThanOrEqualTo(navigatorMin));
            Assert.That(view.IsChecked, Is.True);

            var consoleView = MenuItemByName(window, "toolStripMenuItem3");
            Assert.That(consoleView.IsChecked, Is.True);
            consoleView.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
            Dispatcher.UIThread.RunJobs();
            Assert.That(consoleGrid.RowDefinitions[2].ActualHeight, Is.EqualTo(0));
            Assert.That(consoleView.IsChecked, Is.False);
            consoleView.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
            Dispatcher.UIThread.RunJobs();
            Assert.That(consoleGrid.RowDefinitions[2].ActualHeight, Is.GreaterThanOrEqualTo(consoleMin));
            Assert.That(consoleView.IsChecked, Is.True);
        }
        finally { window.Close(); }
    }

    [Test]
    public void ComputationInstructionsArePresentedUnderCalculationsNode()
    {
        var window = ShowWindowWithProject();
        try
        {
            var navigator = Find<NavigatorControl>(window);
            window.PresentCompDataOnTree(new List<string> { "first.tsf", "second.tsf" });

            Assert.That(navigator.TrySearchNodes(NodeName.Calculations, out var nodes), Is.True);
            Assert.That(nodes.Single().Nodes.Cast<TreeNode>().Select(node => node.Text), Is.EqualTo(new[] { "first.tsf", "second.tsf" }));
            Assert.That(nodes.Single().Parent.Name, Is.EqualTo(NodeName.Project.ToString()));

            window.PresentCompDataOnTree(new List<string>());
            Assert.That(navigator.TrySearchNodes(NodeName.Calculations, out _), Is.False);
        }
        finally { window.Close(); }
    }

    [Test]
    public void StartComputationWritesCommandFileWithCalculations()
    {
        var window = ShowWindowWithProject();
        try
        {
            window.PresentCompDataOnTree(new List<string> { "0 heat.tsf" });
            MenuItemByName(window, "запуститьToolStripMenuItem").RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
            Dispatcher.UIThread.RunJobs();

            var lines = File.ReadAllLines(Path.Combine(directory, "ComputationData", "computation.tcf"));
            Assert.That(lines, Is.EqualTo(new[]
            {
                @"\\загрузка сетки и данных",
                $"загрузить проект {Path.Combine(directory, "menu.bpf2")}",
                @"\\расчет",
                "расчет 0 heat.tsf"
            }));
        }
        finally { window.Close(); }
    }

    [Test]
    public void MeasureMenuOpensMeasuringWindowAndUnchecksWhenClosed()
    {
        var window = ShowWindowWithProject();
        try
        {
            var measure = MenuItemByName(window, "измеритьToolStripMenuItem");
            measure.IsChecked = true;
            measure.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
            Dispatcher.UIThread.RunJobs();

            var form = window.OwnedWindows.Single(owned => owned.Name == "measureForm");
            Assert.That(form.Content, Is.TypeOf<Measurement.MeasuringSet>());

            form.Close();
            Dispatcher.UIThread.RunJobs();
            Assert.That(measure.IsChecked, Is.False);
            Assert.That(window.OwnedWindows, Is.Empty);
        }
        finally { window.Close(); }
    }

    [Test]
    public void ChamferMenuOpensChamferWindowForCurvesAndUnchecksWhenClosed()
    {
        var window = ShowWindowWithProject();
        try
        {
            var chamfer = MenuItemByName(window, "addChamferToolStripMenuItem");
            chamfer.IsChecked = true;
            chamfer.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
            Dispatcher.UIThread.RunJobs();

            // Окно фаски открывается без владельца (как в BazisGUI); текущее окно хранит ChamferWindowService.
            var chamferWindow = (Chamfer.Views.ChamferWindow)typeof(Chamfer.Services.ChamferWindowService)
                .GetField("currentWindow", BindingFlags.Static | BindingFlags.NonPublic)!.GetValue(null)!;
            Assert.That(chamferWindow.IsVisible, Is.True);
            Assert.That(window.SelectedObjects, Is.EqualTo(SelectionType.Curves));

            chamferWindow.Close();
            Dispatcher.UIThread.RunJobs();
            Assert.That(chamfer.IsChecked, Is.False);
        }
        finally { window.Close(); }
    }

    [Test]
    public void GanttMenuWithoutConditionsReportsErrorAndKeepsPagesUnchanged()
    {
        var window = ShowWindowWithProject();
        try
        {
            var console = Find<ConsoleControl>(window);
            var before = window.TabButtonsService.GetNames().ToList();
            // RaiseEvent не переключает IsChecked (это делает щелчок, см. SettingsMenuClickTogglesSettingsPageOnce).
            var gantt = MenuItemByName(window, "показатьНаДиаграммеToolStripMenuItem");
            gantt.IsChecked = true;
            gantt.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
            Dispatcher.UIThread.RunJobs();

            // Как в BaseForm: AddConds вызывает Max по пустому списку условий, ошибка выводится в консоль.
            Assert.That(console.Messages.Last().Color, Is.EqualTo(System.Drawing.Color.Red));
            Assert.That(window.TabButtonsService.GetNames(), Is.EqualTo(before));
        }
        finally { window.Close(); }
    }
}
