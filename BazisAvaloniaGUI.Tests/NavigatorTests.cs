using Avalonia.Controls;
using Avalonia.Threading;
using BazisAvaloniaGUI.Navigator;
using NUnit.Framework;

namespace BazisAvaloniaGUI.Tests;

public partial class AvaloniaTests
{
    private (Window Window, NavigatorControl Navigator) ShowNavigator()
    {
        var navigator = new NavigatorControl();
        var window = new Window { Width = 300, Height = 400, Content = navigator };
        window.Show();
        Dispatcher.UIThread.RunJobs();
        return (window, navigator);
    }

    [Test]
    public void NavigatorCreatesProjectRootAndFindsNodesByName()
    {
        var (window, navigator) = ShowNavigator();
        try
        {
            Assert.That(navigator.TrySearchNodes(NodeName.Project, out var roots), Is.True);
            var geometry = navigator.CreateRealNode(NodeName.Geometry);
            roots[0].Nodes.Add(geometry);

            Assert.That(navigator.TrySearchNodes(NodeName.Geometry, out var found), Is.True);
            Assert.That(found.Single(), Is.SameAs(geometry));
            Assert.That(geometry.Level, Is.EqualTo(1));
            Assert.That(geometry.Index, Is.EqualTo(0));
            Assert.That(geometry.Parent, Is.SameAs(roots[0]));

            geometry.Remove();
            Assert.That(navigator.TrySearchNodes(NodeName.Geometry, out _), Is.False);
        }
        finally { window.Close(); }
    }

    [Test]
    public void ExpandingVirtualNodeRequestsSetsLikeBeforeExpand()
    {
        var (window, navigator) = ShowNavigator();
        try
        {
            navigator.TrySearchNodes(NodeName.Project, out var roots);
            var mesh = navigator.CreateRealNode(NodeName.Mesh);
            mesh.Nodes.Add(navigator.CreateVirtualNode());
            roots[0].Nodes.Add(mesh);

            TreeNode requested = null!;
            navigator.GetSetsInfoEvent += node =>
            {
                requested = node;
                node.Nodes.Add(navigator.CreateRealNode(NodeName.Sets, "Узел Узел 4"));
            };
            mesh.Expand();
            Dispatcher.UIThread.RunJobs();

            Assert.That(requested, Is.SameAs(mesh));
            Assert.That(mesh.Nodes.Count, Is.EqualTo(1));
            Assert.That(mesh.Nodes[0].Text, Is.EqualTo("Узел Узел 4"));
            Assert.That(mesh.ImageIndex, Is.EqualTo(navigator.ExpandIndex));
        }
        finally { window.Close(); }
    }

    [Test]
    public void SelectingNodesDispatchesEventsByLevelLikeAfterSelect()
    {
        var (window, navigator) = ShowNavigator();
        try
        {
            navigator.TrySearchNodes(NodeName.Project, out var roots);
            var task = navigator.CreateRealNode(NodeName.Task);
            roots[0].Nodes.Add(task);
            task.Nodes.Add(navigator.CreateRealNode(NodeName.Material, "Материал : 1"));
            task.Nodes.Add(navigator.CreateRealNode(NodeName.Heat, "Нагрев : 2"));

            var events = new List<string>();
            navigator.SelectTaskEvent += () => events.Add("task");
            navigator.SelectCondEvent += index => events.Add($"cond {index}");
            navigator.SelectGeneralInfoEvent += () => events.Add("project");

            navigator.SelectNode(task);
            navigator.SelectNode(task.Nodes[1]);
            navigator.SelectNode(roots[0]);

            Assert.That(events, Is.EqualTo(new[] { "task", "cond 1", "project" }));
            Assert.That(navigator.SelectedNode, Is.SameAs(roots[0]));
        }
        finally { window.Close(); }
    }

    [Test]
    public void ActionMenuMapsIconPositionsToEvents()
    {
        var (window, navigator) = ShowNavigator();
        try
        {
            var events = new List<string>();
            navigator.ChangeAllGeoViewStateEvent += state => events.Add($"geo {state}");
            navigator.DelAllGeoEvent += () => events.Add("geo delete");
            navigator.InfoGroupEvent += () => events.Add("group info");
            navigator.DelGroupEvent += () => events.Add("group delete");
            navigator.DelCondEvent += () => events.Add("cond delete");

            navigator.ActionMenu(navigator.CreateRealNode(NodeName.Geometry), 1);
            navigator.ActionMenu(navigator.CreateRealNode(NodeName.Geometry), 2);
            navigator.ActionMenu(navigator.CreateRealNode(NodeName.NodesGroup, "g 1"), 0);
            navigator.ActionMenu(navigator.CreateRealNode(NodeName.ElementsGroup, "g 2"), 4);
            navigator.ActionMenu(navigator.CreateRealNode(NodeName.Clamp, "c"), 0);

            Assert.That(events, Is.EqualTo(new[] { "geo False", "geo delete", "group info", "group delete", "cond delete" }));
        }
        finally { window.Close(); }
    }
}
