using Avalonia;
using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Input;
using Avalonia.Threading;
using BazisAvaloniaGUI.SettingsControls;
using NUnit.Framework;
using DrawingPoint = System.Drawing.Point;

namespace BazisAvaloniaGUI.Tests;

public partial class AvaloniaTests
{
    [Test]
    public void SettingsPageForwardsDraggedLightPosition()
    {
        var settings = new SettingsControl();
        var changes = new List<DrawingPoint>();
        settings.SetLighterPositionEvent += changes.Add;
        var window = new Window { Width = 400, Height = 600, Content = settings };
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            var lighting = Find<LightingControl>(settings);
            var panel = ((Grid)lighting.Content!).Children[0];
            var center = panel.TranslatePoint(new Point(panel.Bounds.Width / 2, panel.Bounds.Height / 2), window)!.Value;
            var to = center + new Vector(20, -15);
            window.MouseDown(center, MouseButton.Left);
            window.MouseMove(to, RawInputModifiers.LeftMouseButton);
            window.MouseUp(to, MouseButton.Left);
            Assert.That(changes, Has.Count.EqualTo(1));
            Assert.That(changes[0].X, Is.EqualTo(20).Within(1));
            Assert.That(changes[0].Y, Is.EqualTo(15).Within(1));
        }
        finally { window.Close(); }
    }

    [TestCase(0, 0)]
    [TestCase(20, 15)]
    public void LightPointCanBeDraggedFromItsVisiblePosition(int x, int y)
    {
        var lighting = new LightingControl { BallPosition = new DrawingPoint(x, y) };
        var window = new Window { Width = 200, Height = 220, Content = lighting };
        var changes = new List<DrawingPoint>();
        lighting.SetBallPositionEvent += changes.Add;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            Assert.That(lighting.BallPosition, Is.EqualTo(new DrawingPoint(x, y)));
            var panel = ((Grid)lighting.Content!).Children[0];
            var origin = panel.TranslatePoint(new Point(), window)!.Value;
            var center = origin + new Vector(panel.Bounds.Width / 2, panel.Bounds.Height / 2);
            var from = center + new Vector(x, -y);
            var to = center + new Vector(30, -25);
            window.MouseDown(from, MouseButton.Left);
            window.MouseMove(to, RawInputModifiers.LeftMouseButton);
            Assert.That(lighting.BallPosition, Is.EqualTo(new DrawingPoint(30, 25)));
            Assert.That(changes, Is.Empty);
            window.MouseUp(to, MouseButton.Left);
            Assert.That(changes, Is.EqualTo(new[] { new DrawingPoint(30, 25) }));
        }
        finally { window.Close(); }
    }

    [Test]
    public void LightDragSurvivesLeavingPanelAndStopsOnReleaseOutside()
    {
        var lighting = new LightingControl();
        var window = new Window { Width = 200, Height = 220, Content = lighting };
        var changes = new List<DrawingPoint>();
        lighting.SetBallPositionEvent += changes.Add;
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            var panel = ((Grid)lighting.Content!).Children[0];
            var center = panel.TranslatePoint(new Point(panel.Bounds.Width / 2, panel.Bounds.Height / 2), window)!.Value;
            var outside = new Point(210, 100);
            var to = center + new Vector(30, -25);
            window.MouseDown(center, MouseButton.Left);
            window.MouseMove(outside, RawInputModifiers.LeftMouseButton);
            Assert.That(lighting.BallPosition, Is.EqualTo(new DrawingPoint()));
            window.MouseMove(to, RawInputModifiers.LeftMouseButton);
            Assert.That(lighting.BallPosition, Is.EqualTo(new DrawingPoint(30, 25)));
            window.MouseMove(outside, RawInputModifiers.LeftMouseButton);
            window.MouseUp(outside, MouseButton.Left);
            window.MouseMove(center);
            Assert.That(lighting.BallPosition, Is.EqualTo(new DrawingPoint(30, 25)));
            Assert.That(changes, Has.Count.EqualTo(1));

            window.MouseDown(center, MouseButton.Left);
            window.MouseMove(to, RawInputModifiers.LeftMouseButton);
            window.MouseUp(to, MouseButton.Left);
            Assert.That(changes, Has.Count.EqualTo(1), "Нажатие вне точки не должно менять свет.");
        }
        finally { window.Close(); }
    }
}
