using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Threading;
using Avalonia.VisualTree;
using BazisAvaloniaGUI.Scene;
using BazisAvaloniaGUI.Shell;
using Model.Interfaces;
using OperationalController;
using System.Reflection;
using NUnit.Framework;

namespace BazisAvaloniaGUI.Tests;

public partial class AvaloniaTests
{
    [TestCase(false)]
    [TestCase(true)]
    public void EscapeResetsSceneOnceWithoutChangingFocus(bool focusScene)
    {
        var window = new MainWindow();
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            var scene = Find<SceneView>(window);
            var target = focusScene ? (InputElement)scene.Surface : Find<TextBox>(window);
            target.Focus();
            var focused = window.FocusManager!.GetFocusedElement();
            var resets = 0;
            scene.Surface.SelectionReset += () => resets++;
            scene.Surface.SelectedObjectType = ObjType.Элемент2D;
            var key = new KeyEventArgs { RoutedEvent = InputElement.KeyDownEvent, Key = Key.Escape };
            target.RaiseEvent(key);

            Assert.That(resets, Is.EqualTo(1));
            Assert.That(scene.Surface.SelectedObjectType, Is.Null);
            Assert.That(window.PressedKey, Is.EqualTo(Key.Escape));
            Assert.That(key.Handled, Is.True);
            Assert.That(window.FocusManager.GetFocusedElement(), Is.SameAs(focused));
        }
        finally { window.Close(); }
    }

    [Test]
    public void LocallyHandledEscapeDoesNotResetSceneOrCancelSceneOperation()
    {
        var window = new MainWindow();
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            var scene = Find<SceneView>(window);
            var editor = Find<TextBox>(window);
            editor.Focus();
            editor.KeyDown += (_, e) =>
            {
                if (e.Key == Key.Escape)
                    e.Handled = true;
            };
            var resets = 0;
            scene.Surface.SelectionReset += () => resets++;
            scene.Surface.SelectedObjectType = ObjType.Элемент2D;
            window.PressedKey = Key.None;
            editor.RaiseEvent(new KeyEventArgs { RoutedEvent = InputElement.KeyDownEvent, Key = Key.Escape });

            Assert.That(resets, Is.Zero);
            Assert.That(scene.Surface.SelectedObjectType, Is.EqualTo(ObjType.Элемент2D));
            Assert.That(window.PressedKey, Is.EqualTo(Key.None));
        }
        finally { window.Close(); }
    }

    [Test]
    public void SceneSelectionTypesRefreshAfterMeshChanges()
    {
        var meshPath = Path.Combine(directory, "triangle.stl");
        File.WriteAllText(meshPath, """
            solid triangle
            facet normal 0 0 1
            outer loop
            vertex 0 0 0
            vertex 1 0 0
            vertex 0 1 0
            endloop
            endfacet
            endsolid triangle
            """);
        var project = new ProjectController();
        project.CreateProject("selection.bpf2");
        var window = new MainWindow();
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            typeof(MainWindow).GetField("project", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(window, project);
            var scene = Find<SceneView>(window);
            var combo = Find<ComboBox>(scene);
            window.PresentModelObjectsForSelection();
            Assert.That(combo.ItemsSource!.Cast<SetButton>().Select(item => item.Type), Is.EqualTo(new ObjType?[] { null }));

            project.Open(meshPath, new Progress<int>());
            window.PresentModelObjectsForSelection();
            var items = combo.ItemsSource!.Cast<SetButton>().ToList();
            Assert.That(items.Select(item => item.Type), Does.Contain(ObjType.Узел).And.Contain(ObjType.Элемент2D));

            combo.SelectedItem = items.Single(item => item.Type == ObjType.Элемент2D);
            window.PresentModelObjectsForSelection();
            Assert.That(((SetButton)combo.SelectedItem!).Type, Is.EqualTo(ObjType.Элемент2D));
            Assert.That(scene.Surface.SelectedObjectType, Is.EqualTo(ObjType.Элемент2D));

            project.ClearModelCollection(ObjType.Элемент2D);
            window.PresentModelObjectsForSelection();
            Assert.That(combo.ItemsSource!.Cast<SetButton>().Select(item => item.Type), Does.Not.Contain(ObjType.Элемент2D));
            Assert.That(((SetButton)combo.SelectedItem!).Type, Is.Null);
            Assert.That(scene.Surface.SelectedObjectType, Is.Null);
        }
        finally { window.Close(); }
    }

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
