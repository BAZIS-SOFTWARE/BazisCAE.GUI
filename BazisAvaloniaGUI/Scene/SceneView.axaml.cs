using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using OperationalController;

namespace BazisAvaloniaGUI;

/// <summary>Строка панели дополнительных кнопок: подпись и набор, с которым работает кнопка.</summary>
internal sealed record SetButton(string Title);

/// <summary>
/// Представление сцены: разметка — SceneView.axaml, содержимое — SceneSurface.
/// Своей логики нет; работа со сценой идёт через <see cref="Surface"/>.
/// Список кнопок-наборов строится по данным проекта.
/// </summary>
internal partial class SceneView : UserControl
{
    private readonly ObservableCollection<SetButton> setButtons = new();

    public SceneView()
    {
        InitializeComponent();

        // Кнопки панели строятся по коллекции: сколько наборов вернёт проект — столько кнопок и будет.
        SetsList.ItemsSource = setButtons;

        // Панель дополнительных кнопок — обычный оверлей внутри Panel (не Popup):
        // открывается/закрывается вместе с кнопкой-якорем.
        // Присваивание вручную, т.к. у ToggleButton.IsChecked тип bool?, а у IsVisible — bool.
        OverlayToggle.IsCheckedChanged += (_, _) =>
            ExtraButtonsPanel.IsVisible = OverlayToggle.IsChecked == true;

        Surface.ProjectShown += UpdateSets;
    }

    public SceneSurface Surface { get => surface; }

    /// <summary>Перечитывает наборы проекта и перестраивает кнопки панели.</summary>
    private void UpdateSets(ProjectController project)
    {
        setButtons.Clear();
        var objects = project.GetAllModelSetsInfo().Where(v => v.NumberOfObjects > 0);
        if(objects != null)
        {
            setButtons.Add(new SetButton("Все объекты"));
            foreach (var set in objects.Select(v => v.ObjType).Distinct())
                setButtons.Add(new SetButton(set.ToString()));
        }
    }

    /// <summary>Клик по кнопке набора. Действие над <see cref="SetButton.Set"/> добавить здесь.</summary>
    private void OnSetButtonClick(object? sender, RoutedEventArgs e)
    {
        if ((sender as Button)?.DataContext is SetButton item)
        {
            if(item.Title.Contains("Все объекты"))
            {
                Surface.SelectedObjectType = null;
                return;
            }
            Surface.SelectedObjectType = (ObjType)Enum.Parse(typeof(ObjType), item.Title);
        }
    }
}
