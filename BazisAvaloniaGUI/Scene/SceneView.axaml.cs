using Avalonia.Controls;
using Model.GeometryObjects;

namespace BazisAvaloniaGUI;

/// <summary>
/// Представление сцены: разметка — SceneView.axaml, содержимое — SceneSurface.
/// Своей логики нет; работа со сценой идёт через <see cref="Surface"/>.
/// </summary>
internal partial class SceneView : UserControl
{
    public SceneView()
    {
        InitializeComponent();
    }

    public SceneSurface Surface { get => surface; }
}
