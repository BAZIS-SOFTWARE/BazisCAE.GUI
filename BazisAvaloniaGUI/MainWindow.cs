using Avalonia;
using Avalonia.Automation;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Platform.Storage;
using Avalonia.Styling;

namespace BazisAvaloniaGUI;

internal sealed class MainWindow : Window
{
    private readonly MainWindowState state = new();
    private readonly SceneView scene = new();
    private readonly TextBlock status = new() { VerticalAlignment = VerticalAlignment.Center, TextTrimming = TextTrimming.CharacterEllipsis };
    private readonly StackPanel sidebarTabs = new();
    private readonly ContentControl sidebarPage = new();
    private readonly List<(Button Tab, Control Page)> sidebarPages = [];

    // Attachment points for future migration stages.
    internal ContentControl NavigatorHost { get; } = new();
    internal ContentControl PropertiesHost { get; } = new();
    internal ContentControl ConsoleHost { get; } = new();

    public MainWindow()
    {
        Title = "BazisCAE";
        Width = 1100;
        Height = 750;
        MinWidth = 640;
        MinHeight = 420;
        Background = Brushes.White;
        RequestedThemeVariant = ThemeVariant.Light;
        FontFamily = new FontFamily("Arial");
        FontSize = 16; // 12 pt at 96 DPI

        var root = new Grid { RowDefinitions = new RowDefinitions("Auto,*,Auto") };
        var horizontal = new Grid { ColumnDefinitions = new ColumnDefinitions("304,8,*"), MinHeight = 0, Margin = new Thickness(5) };
        Grid.SetRow(horizontal, 1);
        root.Children.Add(horizontal);

        var sidebar = new Grid { ColumnDefinitions = new ColumnDefinitions("33,*"), MinWidth = 150 };
        sidebar.Children.Add(sidebarTabs);
        Grid.SetColumn(sidebarPage, 1);
        sidebar.Children.Add(sidebarPage);
        var navigatorPage = new Grid { RowDefinitions = new RowDefinitions("*,8,*") };
        navigatorPage.Children.Add(NavigatorHost);
        var sidebarSplitter = new GridSplitter { Height = 8, ResizeDirection = GridResizeDirection.Rows, Background = Brushes.Gainsboro };
        Grid.SetRow(sidebarSplitter, 1);
        navigatorPage.Children.Add(sidebarSplitter);
        Grid.SetRow(PropertiesHost, 2);
        navigatorPage.Children.Add(PropertiesHost);
        AddSidebarPage("Навигатор", navigatorPage);
        horizontal.Children.Add(sidebar);

        var sideSplitter = new GridSplitter { Width = 8, ResizeDirection = GridResizeDirection.Columns, Background = Brushes.Gainsboro };
        Grid.SetColumn(sideSplitter, 1);
        horizontal.Children.Add(sideSplitter);
        var main = new Grid { RowDefinitions = new RowDefinitions("*,8,200"), MinWidth = 0 };
        Grid.SetColumn(main, 2);
        horizontal.Children.Add(main);

        main.Children.Add(scene);
        var consoleSplitter = new GridSplitter { Height = 8, ResizeDirection = GridResizeDirection.Rows, Background = Brushes.Gainsboro };
        Grid.SetRow(consoleSplitter, 1);
        main.Children.Add(consoleSplitter);
        Grid.SetRow(ConsoleHost, 2);
        main.Children.Add(ConsoleHost);

        var statusBorder = new Border { Background = Brushes.Gainsboro, Padding = new Thickness(5, 3), Child = status };
        Grid.SetRow(statusBorder, 2);
        root.Children.Add(statusBorder);
        var sidebarVisible = true;
        var consoleVisible = true;
        var sidebarWidth = horizontal.ColumnDefinitions[0].Width;
        var consoleHeight = main.RowDefinitions[2].Height;
        root.Children.Add(BuildMenu(
            () =>
            {
                if (sidebarVisible) sidebarWidth = horizontal.ColumnDefinitions[0].Width;
                sidebarVisible = !sidebarVisible;
                sidebar.IsVisible = sideSplitter.IsVisible = sidebarVisible;
                horizontal.ColumnDefinitions[0].Width = sidebarVisible ? sidebarWidth : new GridLength(0);
                horizontal.ColumnDefinitions[1].Width = new GridLength(sidebarVisible ? 8 : 0);
            },
            () =>
            {
                if (consoleVisible) consoleHeight = main.RowDefinitions[2].Height;
                consoleVisible = !consoleVisible;
                ConsoleHost.IsVisible = consoleSplitter.IsVisible = consoleVisible;
                main.RowDefinitions[1].Height = new GridLength(consoleVisible ? 8 : 0);
                main.RowDefinitions[2].Height = consoleVisible ? consoleHeight : new GridLength(0);
            }));
        Content = root;
        AddHandler(InputElement.KeyDownEvent, OnWindowKeyDown, RoutingStrategies.Tunnel);

        state.Changed += UpdateWindowState;
        state.ProjectChanged += project => scene.ShowProject(project);
        state.Error += ShowError;
        scene.ProjectDisplayFailed += (_, error) => ShowError(error.Message);
        scene.SelectionApplied += (count, selected) => state.SetStatus(selected ? $"Выбрано объектов: {count}" : $"Снято выделение: {count}");
        UpdateWindowState();
    }

    internal void AddSidebarPage(string title, Control page)
    {
        var tab = new Button
        {
            Width = 33, Height = 130, Padding = new Thickness(0),
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
            Content = new LayoutTransformControl
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                LayoutTransform = new RotateTransform(-90),
                Child = new TextBlock
                {
                    Text = title,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            }
        };
        AutomationProperties.SetName(tab, title);
        tab.Click += (_, _) => SelectSidebarPage(page);
        sidebarTabs.Children.Add(tab);
        sidebarPages.Add((tab, page));
        if (sidebarPages.Count == 1) SelectSidebarPage(page);
    }

    private void SelectSidebarPage(Control page)
    {
        sidebarPage.Content = page;
        foreach (var (tab, candidate) in sidebarPages)
            tab.BorderThickness = candidate == page ? new Thickness(2) : new Thickness(1);
    }

    private Menu BuildMenu(Action toggleSidebar, Action toggleConsole)
    {
        var create = new MenuItem { Header = "Создать", InputGesture = new KeyGesture(Key.N, KeyModifiers.Control) };
        create.Click += async (_, _) => await CreateProject();
        var open = new MenuItem { Header = "Открыть", InputGesture = new KeyGesture(Key.O, KeyModifiers.Control) };
        open.Click += async (_, _) => await OpenProject();
        var save = new MenuItem { Header = "Сохранить", IsEnabled = false, InputGesture = new KeyGesture(Key.S, KeyModifiers.Control) };
        save.Click += async (_, _) => await SaveProject(false);
        var saveAs = new MenuItem { Header = "Сохранить как", IsEnabled = false };
        saveAs.Click += async (_, _) => await SaveProject(true);
        var exit = new MenuItem { Header = "Выход" };
        exit.Click += (_, _) => Close();
        var file = new MenuItem { Header = "Файл", ItemsSource = new object[] { create, open, new Separator(), save, saveAs, new Separator(), exit } };
        var navigator = new MenuItem { Header = "Навигатор" };
        navigator.Click += (_, _) => toggleSidebar();
        var console = new MenuItem { Header = "Консоль" };
        console.Click += (_, _) => toggleConsole();
        var view = new MenuItem { Header = "Вид", ItemsSource = new[] { navigator, console } };
        // BaseForm.UnblockInterface enables exactly these seven sections after a project is ready.
        var projectMenus = new[] { "Геометрия", "Сетка", "Базы данных", "Задачи", "Расчёты", "Результаты", "Инструменты" }
            .Select(title => new MenuItem
            {
                Header = title,
                IsEnabled = false,
                ItemsSource = new[] { new MenuItem { Header = "Команды раздела ещё не перенесены", IsEnabled = false } }
            })
            .ToArray();
        var laterMenus = new[] { "Настройки", "Справка", "Лицензия" }
            .Select(title => new MenuItem
            {
                Header = title,
                ItemsSource = new[] { new MenuItem { Header = "Команды раздела ещё не перенесены", IsEnabled = false } }
            });
        state.Changed += () =>
        {
            create.IsEnabled = open.IsEnabled = !state.IsBusy;
            save.IsEnabled = saveAs.IsEnabled = state.HasProject && !state.IsBusy;
            foreach (var menu in projectMenus)
                menu.IsEnabled = state.HasProject && !state.IsBusy;
        };
        return new Menu { Background = Brushes.Gainsboro, ItemsSource = new[] { file, view }.Concat(projectMenus).Concat(laterMenus).ToArray() };
    }

    private async void OnWindowKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyModifiers != KeyModifiers.Control || state.IsBusy) return;

        switch (e.Key)
        {
            case Key.N:
                e.Handled = true;
                await CreateProject();
                break;
            case Key.O:
                e.Handled = true;
                await OpenProject();
                break;
            case Key.S when state.HasProject:
                e.Handled = true;
                await SaveProject(false);
                break;
        }
    }

    private async Task CreateProject()
    {
        var file = await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Создать проект", SuggestedFileName = "newProject.bpf2", DefaultExtension = "bpf2",
            FileTypeChoices = [new FilePickerFileType("Bazis project") { Patterns = ["*.bpf2"] }]
        });
        if (file == null) return;
        var path = file.TryGetLocalPath();
        if (path == null) { ShowError("Поддерживаются только локальные файлы проекта."); return; }
        await state.CreateProject(path);
    }

    private async Task OpenProject()
    {
        var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Открыть проект", AllowMultiple = false,
            FileTypeFilter = [new FilePickerFileType("Bazis project") { Patterns = ["*.bpf2", "*.bpf"] }]
        });
        if (files.Count == 0) return;
        var path = files[0].TryGetLocalPath();
        if (path == null) { ShowError("Поддерживаются только локальные файлы проекта."); return; }
        await state.OpenProject(path);
    }

    private async Task SaveProject(bool saveAs)
    {
        string? path = null;
        if (saveAs || state.ProjectPath == null)
        {
            var file = await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
            {
                Title = "Сохранить проект",
                SuggestedFileName = state.ProjectPath == null ? "newProject.bpf2" : System.IO.Path.GetFileName(state.ProjectPath),
                DefaultExtension = "bpf2",
                FileTypeChoices = [new FilePickerFileType("Bazis project") { Patterns = ["*.bpf2"] }]
            });
            if (file == null) return;
            path = file.TryGetLocalPath();
            if (path == null) { ShowError("Поддерживаются только локальные файлы проекта."); return; }
        }
        await state.SaveProject(path);
    }

    private void UpdateWindowState()
    {
        Title = state.ProjectPath == null ? "BazisCAE" : $"BazisCAE — {System.IO.Path.GetFileName(state.ProjectPath)}";
        status.Text = state.Status;
    }

    private async void ShowError(string message)
    {
        state.SetStatus(message);
        var close = new Button { Content = "Закрыть", HorizontalAlignment = HorizontalAlignment.Right };
        var dialog = new Window
        {
            Title = "Ошибка", Width = 420, SizeToContent = SizeToContent.Height, MinHeight = 130,
            FontFamily = new FontFamily("Arial"), FontSize = 16,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new StackPanel { Margin = new Thickness(16), Spacing = 16,
                Children = { new TextBlock { Text = message, TextWrapping = TextWrapping.Wrap }, close } }
        };
        close.Click += (_, _) => dialog.Close();
        await dialog.ShowDialog(this);
    }
}
