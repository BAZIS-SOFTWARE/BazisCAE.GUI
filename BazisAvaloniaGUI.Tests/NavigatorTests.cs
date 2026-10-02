using Avalonia;
using Avalonia.VisualTree;
using System.Diagnostics;
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

public partial class AvaloniaTests
{
    private static TreeNode AddMeshSet(NavigatorControl navigator, int objectsCount)
    {
        navigator.TrySearchNodes(NodeName.Project, out var roots);
        var mesh = navigator.CreateRealNode(NodeName.Mesh);
        roots[0].Nodes.Add(mesh);
        var set = navigator.CreateRealNode(NodeName.Sets, $"Элемент2D append_0 {objectsCount}");
        set.Nodes.Add(navigator.CreateVirtualNode());
        mesh.Nodes.Add(set);
        navigator.GetObjectsInfoEvent += node =>
        {
            var texts = Enumerable.Range(0, objectsCount).Select(i => $"{i} Элемент2D Треугольник 1 : {i}");
            node.Nodes.AddRange(navigator.CreateRealNodes(NodeName.Objects, texts));
        };
        mesh.Expand();
        return set;
    }

    private static List<NavigatorRow> RealizedRows(NavigatorControl navigator) =>
        navigator.GetVisualDescendants().OfType<NavigatorRow>().Where(row => row.IsEffectivelyVisible).ToList();

    [Test]
    public void CollapsingParentHidesActionIconsAndMovesSelectionLikeWinForms()
    {
        var (window, navigator) = ShowNavigator();
        try
        {
            var set = AddMeshSet(navigator, 30);
            set.Expand();
            Dispatcher.UIThread.RunJobs();
            var objectNode = set.Nodes[17];
            navigator.SelectNode(objectNode);
            Dispatcher.UIThread.RunJobs();
            Assert.That(RealizedRows(navigator).Single(row => row.DataContext == objectNode).ActionIcons.All(icon => icon.IsEffectivelyVisible), Is.True);

            set.Collapse();
            Dispatcher.UIThread.RunJobs();

            Assert.That(navigator.SelectedNode, Is.SameAs(set));
            var visibleIcons = RealizedRows(navigator).Where(row => row.DataContext != set).SelectMany(row => row.ActionIcons).Where(icon => icon.IsEffectivelyVisible);
            Assert.That(visibleIcons, Is.Empty);
        }
        finally { window.Close(); }
    }

    [Test]
    public void ActionIconsFitInsideSelectedRow()
    {
        var (window, navigator) = ShowNavigator();
        try
        {
            var set = AddMeshSet(navigator, 5);
            navigator.SelectNode(set);
            Dispatcher.UIThread.RunJobs();

            var row = RealizedRows(navigator).Single(r => r.DataContext == set);
            var rowBounds = new Rect(row.Bounds.Size);
            foreach (var icon in row.ActionIcons)
            {
                var topLeft = icon.TranslatePoint(new Point(0, 0), row)!.Value;
                Assert.That(rowBounds.Contains(new Rect(topLeft, icon.Bounds.Size)), Is.True);
            }
            Assert.That(row.Bounds.Height, Is.EqualTo(NavigatorRow.RowHeight));
        }
        finally { window.Close(); }
    }

    [Test]
    public void LargeSetIsVirtualizedAndExpandsCollapsesQuickly()
    {
        var (window, navigator) = ShowNavigator();
        try
        {
            var set = AddMeshSet(navigator, 20000);
            var watch = Stopwatch.StartNew();
            set.Expand();
            Dispatcher.UIThread.RunJobs();
            Assert.That(RealizedRows(navigator).Count, Is.LessThan(100));
            set.Collapse();
            Dispatcher.UIThread.RunJobs();
            set.Expand();
            Dispatcher.UIThread.RunJobs();
            watch.Stop();

            Assert.That(set.Nodes.Count, Is.EqualTo(20000));
            Assert.That(watch.ElapsedMilliseconds, Is.LessThan(3000));
        }
        finally { window.Close(); }
    }

    [Test]
    public void ClearingExpandedNodeCollapsesItSoVirtualNodeReloads()
    {
        var (window, navigator) = ShowNavigator();
        try
        {
            var set = AddMeshSet(navigator, 3);
            set.Expand();
            set.Nodes.Clear();
            set.Nodes.Add(navigator.CreateVirtualNode());
            Assert.That(set.IsExpanded, Is.False);

            set.Expand();
            Dispatcher.UIThread.RunJobs();
            Assert.That(set.Nodes.Count, Is.EqualTo(3));
            Assert.That(RealizedRows(navigator).Count(row => ((TreeNode)row.DataContext!).Parent == set), Is.EqualTo(3));
        }
        finally { window.Close(); }
    }
}
