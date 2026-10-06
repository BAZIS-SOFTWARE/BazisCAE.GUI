using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using Avalonia.VisualTree;
using BazisAvaloniaGUI.Scene;
using NUnit.Framework;

namespace BazisAvaloniaGUI.Tests;

public partial class AvaloniaTests
{
    [Test]
    public void SceneViewDropdownUsesTheSameGapAsItsButtons()
    {
        var scene = new SceneView();
        var window = new Window { Content = scene, Width = 800, Height = 600 };
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            var view = Find<ToggleButton>(scene, button => button.Name == "ViewToggle");
            view.IsChecked = true;
            window.UpdateLayout();
            Dispatcher.UIThread.RunJobs();
            var xy = Find<Button>(scene, button => button.Name == "btnXY");
            var zx = Find<Button>(scene, button => button.Name == "btnZX");
            var viewBottom = view.TranslatePoint(new Point(0, view.Bounds.Height), scene)!.Value.Y;
            var xyTop = xy.TranslatePoint(new Point(), scene)!.Value.Y;
            var xyBottom = xy.TranslatePoint(new Point(0, xy.Bounds.Height), scene)!.Value.Y;
            var zxTop = zx.TranslatePoint(new Point(), scene)!.Value.Y;
            Assert.That(xyTop - viewBottom, Is.EqualTo(3).Within(0.1));
            Assert.That(xyTop - viewBottom, Is.EqualTo(zxTop - xyBottom).Within(0.1));
        }
        finally { window.Close(); }
    }

    [Test]
    public void SceneDropdownAndContextMenuHaveSquareCorners()
    {
        var scene = new SceneView();
        var window = new Window { Content = scene, Width = 800, Height = 600 };
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            var combo = Find<ComboBox>(scene);
            combo.IsDropDownOpen = true;
            Dispatcher.UIThread.RunJobs();
            var popup = Find<Popup>(combo);
            Assert.That(popup.IsOpen, Is.True);
            Assert.That(((Border)popup.Child!).CornerRadius, Is.EqualTo(new CornerRadius(0)));
            combo.IsDropDownOpen = false;

            var surface = Find<SceneSurface>(scene);
            var menu = surface.ContextMenu!;
            menu.Open(surface);
            Dispatcher.UIThread.RunJobs();
            Assert.That(menu.IsOpen, Is.True);
            var borders = menu.GetVisualDescendants().OfType<Border>().ToList();
            Assert.That(borders, Is.Not.Empty);
            Assert.That(borders.All(border => border.CornerRadius == new CornerRadius(0)), Is.True);
            menu.Close();
        }
        finally { window.Close(); }
    }
}
