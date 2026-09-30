using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Model.Interfaces;
using OperationalController;

namespace BazisAvaloniaGUI;

/// <summary>
/// Главное окно: шапка с управлением сценой (кнопки и селектор относятся к окну)
/// и SceneView с OpenGL-поверхностью. Разметка — в MainWindow.axaml.
/// </summary>
internal partial class MainWindow : Window
{
    private readonly ObjType[] selectionTypes = Enum.GetValues<ObjType>();

    public MainWindow()
    {
        InitializeComponent();

        /*ObjectSelector.Items.Add("Все объекты");
        foreach (var type in selectionTypes)
            ObjectSelector.Items.Add(type.ToString());
        ObjectSelector.SelectedIndex = 0;*/

        LoadButton.Click += async (_, _) => await LoadProject();
        InsideButton.Click += (_, _) =>
        {
            scene.Surface.HideInsideSurfaces = !scene.Surface.HideInsideSurfaces;
            UpdateInsideButton();
        };
        /*ObjectSelector.SelectionChanged += (_, _) =>
        {
            var index = ObjectSelector.SelectedIndex;
            scene.Surface.SelectedObjectType = index > 0 ? selectionTypes[index - 1] : null;
            scene.Surface.Focus();   // возвращаем фокус сцене, чтобы работали её клавиши
        };*/

        scene.Surface.ProjectDisplayFailed += (_, error) => Status.Text = error.Message;
        scene.Surface.SelectionApplied += (count, selected) => Status.Text = selected ? $"Выбрано объектов: {count}" : $"Снято выделение: {count}";

        // ВРЕМЕННО: фактические размеры поверхности в заголовке окна (удалить вместе с бортиком).
        scene.Surface.PropertyChanged += (_, e) =>
        {
            if (e.Property == BoundsProperty)
                Title = $"BazisAvaloniaGUI — 3D сцена | surface {(int)scene.Surface.Bounds.Width}×{(int)scene.Surface.Bounds.Height}";
        };
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
            Status.Text = "Only local BPF2 files are supported.";
            return;
        }

        LoadButton.IsEnabled = false;
        Status.Text = "Загрузка...";
        try
        {
            var project = await Task.Run(() =>
            {
                var result = new ProjectController();
                result.Load(path);
                return result;
            });
            scene.Surface.ShowProject(project);
            InsideButton.IsEnabled = true;
            ObjectSelector.IsEnabled = true;
            UpdateInsideButton();
            Status.Text = System.IO.Path.GetFileName(path);
        }
        catch (Exception error)
        {
            Status.Text = error.Message;
        }
        finally
        {
            LoadButton.IsEnabled = true;
        }
    }

    /// <summary>Переключает подпись кнопки скрытия внутренних поверхностей.</summary>
    private void UpdateInsideButton() =>
        InsideButton.Content = scene.Surface.HideInsideSurfaces
            ? "Показать внутренние поверхности"
            : "Скрыть внутренние поверхности";
}
