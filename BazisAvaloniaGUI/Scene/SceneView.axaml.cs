using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Threading;
using BazisGUI.Scene.Interfaces;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using OperationalController;

namespace BazisAvaloniaGUI;

/// <summary>Пункт выпадающего списка наборов: подпись набора.</summary>
internal sealed record SetButton(string Title);

/// <summary>
/// Представление сцены: разметка — SceneView.axaml, содержимое — SceneSurface.
/// Своей логики нет; работа со сценой идёт через <see cref="Surface"/>.
/// Пункты выпадающего списка наборов строятся по данным проекта.
/// </summary>
internal partial class SceneView : UserControl
{
    /// <summary>Подпись пункта «фильтр не задан» — показывает все объекты.</summary>
    private const string AllObjectsTitle = "Все объекты";

    private readonly ObservableCollection<SetButton> setButtons = new();

    /// <summary>Признак перестройки списка: чтобы программная смена выбора не трогала сцену.</summary>
    private bool isUpdatingSets;

    /// <summary>Текущий режим вращения мышью; XYZ — свободный поворот (значение по умолчанию в SceneInputController).</summary>
    private ViewAxis rotationMode = ViewAxis.XYZ;

    public SceneView()
    {
        InitializeComponent();

        // Пункты выпадающего списка строятся по коллекции: сколько наборов вернёт проект — столько пунктов и будет.
        SetsCombo.ItemsSource = setButtons;
        SetsCombo.SelectionChanged += OnSetSelectionChanged;

        // Список кнопок видов раскрывается обычным оверлеем внутри Panel (не Popup).
        // Присваивание вручную, т.к. у ToggleButton.IsChecked тип bool?, а у IsVisible — bool.
        ViewToggle.IsCheckedChanged += (_, _) =>
            ViewButtonsPanel.IsVisible = ViewToggle.IsChecked == true;

        Surface.ProjectShown += UpdateSets;
    }

    public SceneSurface Surface { get => surface; }

    /// <summary>Перечитывает наборы проекта и перестраивает пункты выпадающего списка.</summary>
    private void UpdateSets(ProjectController project)
    {
        // Пока список перестраивается, программная смена выбора не должна трогать сцену.
        isUpdatingSets = true;
        try
        {
            setButtons.Clear();
            setButtons.Add(new SetButton(AllObjectsTitle));
            foreach (var set in project.GetAllModelSetsInfo()
                                        .Where(v => v.NumberOfObjects > 0)
                                        .Select(v => v.ObjType)
                                        .Distinct())
                setButtons.Add(new SetButton(set.ToString()));

            // Выбор по умолчанию — «Все объекты».
            SetsCombo.SelectedIndex = 0;
        }
        finally
        {
            isUpdatingSets = false;
        }

        // Новая модель — прошлый набор может быть неактуален, показываем все объекты.
        Surface.SelectedObjectType = null;
    }

    /// <summary>Выбор пункта списка: набор фильтрует сцену, «Все объекты» снимает фильтр.</summary>
    private void OnSetSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (isUpdatingSets || SetsCombo.SelectedItem is not SetButton item)
            return;

        if (item.Title == AllObjectsTitle)
        {
            Surface.SelectedObjectType = null;
            return;
        }

        Surface.SelectedObjectType = (ObjType)Enum.Parse(typeof(ObjType), item.Title);
    }

    private void OnViewChangeClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            return;

        // Имена кнопок повторяют парные оси в порядке экранных осей (ZX/ZY), а ViewPlane — в порядке имён осей (XZ/YZ).
        var plane = button.Name switch
        {
            "btnXY" => ViewPlane.XY,
            "btnZX" => ViewPlane.XZ,
            "btnZY" => ViewPlane.YZ,
            _ => (ViewPlane?)null
        };

        if (plane is { } viewPlane)
            Surface.SetPlane(viewPlane);
    }

    /// <summary>Клик по кнопке режима поворота: вращение вокруг оси X/Y/Z, повторный клик — свободный поворот (XYZ).</summary>
    private void OnRotateChangeModeClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not ToggleButton button || AxisOf(button.Name) is not { } axis)
            return;

        // Повторный клик по активной оси снимает режим — возвращаем свободный поворот.
        rotationMode = rotationMode == axis ? ViewAxis.XYZ : axis;
        Surface.SetRotationAxis(rotationMode);

        // Обводка показывает активный режим. Синхронизация отложена, чтобы не зависеть от того,
        // успел ли ToggleButton переключить IsChecked до события Click.
        Dispatcher.UIThread.Post(() =>
        {
            foreach (var toggle in ViewButtonsPanel.Children.OfType<ToggleButton>())
                if (AxisOf(toggle.Name) is { } toggleAxis)
                    toggle.IsChecked = toggleAxis == rotationMode;
        });
    }

    /// <summary>Клик по кнопке разового поворота: горизонтальная — вокруг Y, вертикальная — вокруг X, угол 90°.</summary>
    private void OnRotateByRightAngle(object? sender, RoutedEventArgs e)
    {
        if (sender is not Control control || RightAngleOf(control.Name) is not { } rotation)
            return;

        Surface.RotateBy(rotation.Axis, rotation.Angle);

        // Кнопка — разовое действие, а не режим: рамку-обводку не фиксируем.
        if (control is ToggleButton toggle)
            Dispatcher.UIThread.Post(() => toggle.IsChecked = false);
    }

    /// <summary>Ось поворота по имени кнопки режима (null — кнопка не про режим поворота).</summary>
    private static ViewAxis? AxisOf(string? buttonName) => buttonName switch
    {
        "btnRotX" => ViewAxis.X,
        "btnRotY" => ViewAxis.Y,
        "btnRotZ" => ViewAxis.Z,
        _ => null
    };

    /// <summary>
    /// Ось и угол разового поворота по имени кнопки. Соответствие как в WinForms
    /// (btnRotHor90 → ViewAxis.Y, btnRotVert90 → ViewAxis.X), угол всегда 90°.
    /// Варианты написания: btnRotHor/btnRotHor90 и btnRotVer/btnRotVert/btnRotVert90.
    /// </summary>
    private static (ViewAxis Axis, float Angle)? RightAngleOf(string? buttonName) => buttonName switch
    {
        "btnRotHor" => (ViewAxis.Y, 90f),
        "btnRotVer" => (ViewAxis.X, 90f),
        _ => null
    };
}
