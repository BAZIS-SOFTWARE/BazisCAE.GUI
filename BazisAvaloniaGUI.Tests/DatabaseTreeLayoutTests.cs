using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Threading;
using BazisAvaloniaGUI.Databases;
using NUnit.Framework;

namespace BazisAvaloniaGUI.Tests;

public partial class AvaloniaTests
{
    [Test]
    public void DatabaseNodeHeaderDoesNotMoveWhenExpanded()
    {
        var tree = new DatabaseTree();
        var steel = new TreeNode("Steel") { IsExpanded = true };
        var thermal = new TreeNode("Thermal properties");
        thermal.Nodes.Add(new TreeNode("Thermal conductivity along X, W / (m K)"));
        steel.Nodes.Add(thermal);
        tree.Nodes.Add(steel);
        var window = new Window { Content = tree, Width = 260, Height = 300 };
        window.Styles.Add(new StyleInclude(new Uri("avares://BazisAvaloniaGUI/"))
        {
            Source = new Uri("avares://BazisAvaloniaGUI/Databases/DatabaseStyles.axaml")
        });
        window.Show();
        Dispatcher.UIThread.RunJobs();
        try
        {
            var text = Find<TextBlock>(thermal, block => block.Text == thermal.Text);
            var before = text.TranslatePoint(new Point(), tree)!.Value.X;
            thermal.IsExpanded = true;
            window.UpdateLayout();
            Dispatcher.UIThread.RunJobs();
            var after = text.TranslatePoint(new Point(), tree)!.Value.X;
            Assert.That(after, Is.EqualTo(before).Within(0.1));
        }
        finally { window.Close(); }
    }
}
