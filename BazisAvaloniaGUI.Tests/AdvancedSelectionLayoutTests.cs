using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using Avalonia.Headless;
using Avalonia.VisualTree;
using Avalonia.Controls.Shapes;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;
using BazisAvaloniaGUI.AdvanceSelection;
using BazisAvaloniaGUI.Shell;
using NUnit.Framework;
using System.Globalization;

namespace BazisAvaloniaGUI.Tests;

public partial class AvaloniaTests
{
    [TestCase(true, false)]
    [TestCase(true, true)]
    [TestCase(false, false)]
    public void AdvancedSelectionIndicatorsFollowDesignStates(bool mesh, bool checkbox)
    {
        var window = new Window
        {
            Content = mesh ? new MeshSelect(SelectionType.Nodes) : new GeomSelect(SelectionType.Points),
            FontSize = 11,
            SizeToContent = SizeToContent.WidthAndHeight
        };
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            var toggle = checkbox ? (ToggleButton)Find<CheckBox>(window) : Find<RadioButton>(window);
            toggle.IsChecked = false;
            var indicator = Find<Control>(toggle, c => c.Name == "Indicator");
            var glyph = Find<Control>(toggle, c => c.Name == "CheckGlyph");
            void CheckState(string fill, string stroke, double thickness)
            {
                Assert.That(indicator.Bounds.Size, Is.EqualTo(new Size(16, 16)));
                var background = indicator is Border border ? border.Background : ((Ellipse)indicator).Fill;
                var outline = indicator is Border box ? box.BorderBrush : ((Ellipse)indicator).Stroke;
                Assert.That(((ISolidColorBrush)background!).Color, Is.EqualTo(Color.Parse(fill)));
                Assert.That(((ISolidColorBrush)outline!).Color, Is.EqualTo(Color.Parse(stroke)));
                if (indicator is Border square)
                {
                    Assert.That(square.CornerRadius, Is.EqualTo(new CornerRadius(0)));
                    Assert.That(square.BorderThickness, Is.EqualTo(new Thickness(thickness)));
                }
                else
                    Assert.That(((Ellipse)indicator).StrokeThickness, Is.EqualTo(thickness));
            }
            CheckState("#FFFFFF", "#000000", 1);
            Assert.That(glyph.IsVisible, Is.False);
            var center = indicator.TranslatePoint(new Point(8, 8), window)!.Value;
            window.MouseMove(center);
            CheckState("#FFFFFF", "#000000", 2);
            window.MouseDown(center, MouseButton.Left);
            CheckState("#E5E5E5", "#000000", 3);
            window.MouseUp(center, MouseButton.Left);
            Assert.That(toggle.IsChecked, Is.True);
            Assert.That(glyph.IsVisible, Is.True);
            window.MouseMove(new Point(224, 149));
            CheckState("#FFFFFF", "#000000", 1);
            toggle.IsEnabled = false;
            CheckState("#F8F8F8", "#CACACA", 1);
        }
        finally { window.Close(); }
    }

    [Test]
    public void AdvancedSelectionAngleFieldFollowsDesignStates()
    {
        var window = new Window { Content = new MeshSelect(SelectionType.Nodes), FontSize = 11, SizeToContent = SizeToContent.WidthAndHeight };
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            var angle = Find<TextBox>(window);
            var border = Find<Border>(angle, b => b.Name == "PART_BorderElement");
            void CheckState(string background, string outline, double thickness)
            {
                Assert.That(angle.Bounds.Height, Is.EqualTo(20));
                Assert.That(border.CornerRadius, Is.EqualTo(new CornerRadius(0)));
                Assert.That(((ISolidColorBrush)border.Background!).Color, Is.EqualTo(Color.Parse(background)));
                Assert.That(((ISolidColorBrush)border.BorderBrush!).Color, Is.EqualTo(Color.Parse(outline)));
                Assert.That(border.BorderThickness, Is.EqualTo(new Thickness(thickness)));
            }
            CheckState("#FFFFFF", "#7A7A7A", 1);
            window.MouseMove(angle.TranslatePoint(new Point(10, 10), window)!.Value);
            CheckState("#FFFFFF", "#7A7A7A", 2);
            angle.Focus();
            CheckState("#FFFFFF", "#7A7A7A", 2);
            window.MouseMove(new Point(224, 149));
            angle.IsEnabled = false;
            CheckState("#F8F8F8", "#CACACA", 1);
        }
        finally { window.Close(); }
    }

    [TestCase(true, "ru", 150)]
    [TestCase(true, "en", 150)]
    [TestCase(false, "ru", 90)]
    [TestCase(false, "en", 90)]
    public void AdvancedSelectionKeepsOriginalClientLayout(bool mesh, string language, double height)
    {
        var previousCulture = CultureInfo.CurrentUICulture;
        CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(language);
        var window = new Window { FontSize = 11, SizeToContent = SizeToContent.WidthAndHeight };
        try
        {
            window.Content = mesh
                ? new MeshSelect(SelectionType.Nodes)
                : new GeomSelect(SelectionType.Points);
            window.Show();
            Dispatcher.UIThread.RunJobs();
            window.UpdateLayout();

            var panel = Find<Grid>(window, grid => grid.Name == "generalPanel");
            Assert.That(panel.Bounds.Width, Is.EqualTo(225).Within(0.1));
            Assert.That(panel.Bounds.Height, Is.EqualTo(height).Within(0.1));
            var radios = panel.Children.OfType<RadioButton>().ToArray();
            for (var row = 0; row < radios.Length; row++)
            {
                var bounds = radios[row].Bounds;
                Assert.That(bounds.X, Is.EqualTo(8).Within(0.1));
                Assert.That(bounds.Center.Y, Is.EqualTo(row * 30 + 15).Within(0.1));
                Assert.That(bounds.Bottom, Is.LessThanOrEqualTo((row + 1) * 30));
            }

            if (mesh)
            {
                var angle = Find<TextBox>(panel, box => box.Name == "txbAngle");
                Assert.That(angle.Bounds.X, Is.EqualTo(67.5).Within(0.5));
                Assert.That(angle.Bounds.Width, Is.EqualTo(137.5).Within(0.5));
                Assert.That(angle.Bounds.Height, Is.EqualTo(20).Within(0.1));
                Assert.That(angle.Bounds.Center.Y, Is.EqualTo(105).Within(0.1));
                var reverse = Find<CheckBox>(panel);
                Assert.That(reverse.Bounds.Center.Y, Is.EqualTo(135).Within(0.1));
                Assert.That(reverse.Bounds.Right, Is.LessThanOrEqualTo(panel.Bounds.Width));
            }
        }
        finally
        {
            window.Close();
            CultureInfo.CurrentUICulture = previousCulture;
        }
    }
}
