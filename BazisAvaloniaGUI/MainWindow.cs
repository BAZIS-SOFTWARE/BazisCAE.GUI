using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Platform.Storage;
using Model.Interfaces;
using OperationalController;

namespace BazisAvaloniaGUI;

internal class MainWindow : Window
{
    private readonly SceneView scene = new();
    private readonly Button loadButton = new() { Content = "Загрузить", HorizontalAlignment = HorizontalAlignment.Left };
    private readonly Button insideButton = new() { Content = "Скрыть внутренние поверхности", IsEnabled = false };
    private readonly ComboBox objectSelector = new() { Width = 170, IsEnabled = false };
    private readonly ObjType[] selectionTypes = Enum.GetValues<ObjType>();
    private readonly TextBlock status = new() { VerticalAlignment = VerticalAlignment.Center };

    public MainWindow()
    {
        Title = "BazisAvaloniaGUI — 3D сцена";
        Width = 1100;
        Height = 750;

        var layout = new Grid { RowDefinitions = new RowDefinitions("Auto,*") };
        var header = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 12, Margin = new Avalonia.Thickness(8) };
        header.Children.Add(loadButton);
        header.Children.Add(insideButton);
        header.Children.Add(objectSelector);
        header.Children.Add(status);
        layout.Children.Add(header);
        Grid.SetRow(scene, 1);
        layout.Children.Add(scene);
        Content = layout;

        objectSelector.Items.Add("Все объекты");
        foreach (var type in selectionTypes)
            objectSelector.Items.Add(type.ToString());
        objectSelector.SelectedIndex = 0;

        loadButton.Click += async (_, _) => await LoadProject();
        insideButton.Click += (_, _) =>
        {
            scene.HideInsideSurfaces = !scene.HideInsideSurfaces;
            insideButton.Content = scene.HideInsideSurfaces ? "Показать внутренние поверхности" : "Скрыть внутренние поверхности";
        };
        objectSelector.SelectionChanged += (_, _) =>
        {
            var index = objectSelector.SelectedIndex;
            scene.SelectedObjectType = index > 0 ? selectionTypes[index - 1] : null;
        };
        scene.ProjectDisplayFailed += (_, error) => status.Text = error.Message;
        scene.SelectionApplied += (count, selected) => status.Text = selected ? $"Выбрано объектов: {count}" : $"Снято выделение: {count}";
    }

    /// <summary>Открывает файл проекта и передаёт модель сцене для создания GL-объектов.</summary>
    private async Task LoadProject()
    {
        var options = new FilePickerOpenOptions
        {
            Title = "Загрузить проект BPF2",
            AllowMultiple = false,
            FileTypeFilter = [new FilePickerFileType("Bazis project") { Patterns = ["*.bpf2"] }]
        };
        var files = await StorageProvider.OpenFilePickerAsync(options);
        if (files.Count == 0)
            return;

        var path = files[0].TryGetLocalPath();
        if (path == null)
        {
            status.Text = "Only local BPF2 files are supported.";
            return;
        }

        loadButton.IsEnabled = false;
        status.Text = "Загрузка...";
        try
        {
            var project = await Task.Run(() =>
            {
                var result = new ProjectController();
                result.Load(path);
                return result;
            });
            scene.ShowProject(project);
            insideButton.IsEnabled = true;
            objectSelector.IsEnabled = true;
            insideButton.Content = scene.HideInsideSurfaces ? "Показать внутренние поверхности" : "Скрыть внутренние поверхности";
            status.Text = System.IO.Path.GetFileName(path);
        }
        catch (Exception error)
        {
            status.Text = error.Message;
        }
        finally
        {
            loadButton.IsEnabled = true;
        }
    }
}
