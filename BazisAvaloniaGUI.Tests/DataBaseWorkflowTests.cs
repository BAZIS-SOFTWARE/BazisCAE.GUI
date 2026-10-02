using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Presenters;
using Avalonia.Headless;
using Avalonia.Input;
using Avalonia.Input.Platform;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using Avalonia.VisualTree;
using BazisAvaloniaGUI.Console;
using BazisAvaloniaGUI.Databases;
using BazisAvaloniaGUI.Shell;
using NUnit.Framework;
using OperationalController;
using System.Data;
using System.Reflection;

namespace BazisAvaloniaGUI.Tests;

public partial class AvaloniaTests
{
    // Avalonia 12 disallows client implementations of its storage interfaces; DispatchProxy mocks only the used API.
    public class DatabasePicker : DispatchProxy
    {
        public IReadOnlyList<IStorageFile> Files { get; set; } = [];
        public IStorageFile? SaveFile { get; set; }
        public Exception? Error { get; set; }
        public int Opens { get; private set; }
        public IStorageProvider Provider => (IStorageProvider)(object)this;
        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            switch (targetMethod!.Name)
            {
                case "get_CanOpen": case "get_CanSave": return true;
                case "get_CanPickFolder": return false;
                case "OpenFilePickerAsync":
                    Opens++; return Error == null ? Task.FromResult(Files) : Task.FromException<IReadOnlyList<IStorageFile>>(Error);
                case "SaveFilePickerAsync": return Task.FromResult(SaveFile);
                default: throw new NotSupportedException(targetMethod.Name);
            }
        }
    }
    private static DatabasePicker CreatePicker() => (DatabasePicker)(object)DispatchProxy.Create<IStorageProvider, DatabasePicker>();
    public class DatabaseFileProxy : DispatchProxy
    {
        public Uri Path { get; set; } = null!;
        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args) => targetMethod!.Name switch
        {
            "get_Path" => Path,
            "get_Name" => System.IO.Path.GetFileName(Path.LocalPath),
            "Dispose" => null,
            _ => throw new NotSupportedException(targetMethod.Name)
        };
    }
    private static IStorageFile DatabaseFile(Uri path)
    {
        var file = DispatchProxy.Create<IStorageFile, DatabaseFileProxy>();
        ((DatabaseFileProxy)(object)file).Path = path; return file;
    }

    private static void Click(Control control, Point? localPoint = null)
    {
        Dispatcher.UIThread.RunJobs();
        var top = TopLevel.GetTopLevel(control)!;
        using var frame = top.CaptureRenderedFrame();
        Assert.That(control.IsEffectivelyVisible && control.Bounds.Width > 0 && control.Bounds.Height > 0, Is.True, $"{control.Name} must be rendered before clicking.");
        var visible = new Rect(control.TranslatePoint(new Point(), top)!.Value, control.Bounds.Size);
        foreach (var ancestor in control.GetVisualAncestors().OfType<Control>().Where(item => item.ClipToBounds || item is ScrollViewer))
            visible = visible.Intersect(new Rect(ancestor.TranslatePoint(new Point(), top)!.Value, ancestor.Bounds.Size));
        Assert.That(visible.Width > 0 && visible.Height > 0, Is.True, $"{control.Name} must be inside the visible viewport.");
        var point = localPoint.HasValue ? control.TranslatePoint(localPoint.Value, top)!.Value : visible.Center;
        var hit = top.InputHitTest(point);
        Assert.That(ReferenceEquals(hit, control) || hit is Visual visual && visual.GetVisualAncestors().Contains(control), Is.True,
            $"Click {control.GetType().Name} {control.Name} at {point} hit {hit?.GetType().Name} {(hit as Control)?.Name} instead.");
        top.MouseMove(point); top.MouseDown(point, MouseButton.Left); top.MouseUp(point, MouseButton.Left);
        Dispatcher.UIThread.RunJobs();
    }

    private static void ClickTool(Control page, string name)
    {
        Dispatcher.UIThread.RunJobs();
        using var frame = TopLevel.GetTopLevel(page)!.CaptureRenderedFrame();
        var button = Find<Button>(page, item => item.Name == name);
        if (button.IsEffectivelyVisible) Click(button);
        else
        {
            var toolbar = button.GetVisualAncestors().OfType<DatabaseToolbar>().First();
            var overflow = Find<Button>(toolbar, item => item.Name == "ToolbarOverflow");
            Click(overflow);
            Click(overflow.ContextMenu!.Items.Cast<MenuItem>().First(item => Equals(item.Header, ToolTip.GetTip(button))));
        }
    }

    [Test]
    public void GraphToolbarCommandsWorkThroughMouseClicksAndNarrowOverflow()
    {
        using var culture = new DatabaseCulture();
        var graph = new GraphContainer();
        var series = new GraphData("Series", System.Drawing.Color.Orange, "C", "W", [new GraphPoint(0, 2), new GraphPoint(10, 4)]) { ValueFlag = true };
        graph.CreateGraphData("Property", [series], new AxisFormat(), new AxisFormat());
        var owner = new Window { Width = 700, Height = 500, Content = graph }; owner.Show();
        try
        {
            ClickTool(graph, "dashButton"); Assert.That(graph.DashPaintFlag, Is.True);
            ClickTool(graph, "lineButton"); Assert.That(graph.LinePaintFlag, Is.False);
            ClickTool(graph, "btnValue"); Assert.That(graph.ValueFlag, Is.True);
            ClickTool(graph, "btnTitle"); Assert.That(series.IsTitleShown, Is.False);
            var split = Find<Button>(graph, item => item.Name == "btnPathThick");
            Assert.That(split.Bounds.Width, Is.EqualTo(45));
            Assert.That(Find<Avalonia.Controls.Shapes.Path>(split, item => item.Name == "GraphDropdownArrow").Bounds.Width, Is.EqualTo(6));
            Click(split); Assert.That(split.ContextMenu!.IsOpen, Is.False, "The split button's main part keeps the source no-op.");
            Click(split, new Point(40, 13));
            Click(split.ContextMenu.Items.Cast<MenuItem>().Single(item => item.Name == "PathThickness5"));
            Assert.That(series.Thickness, Is.EqualTo(5));
            var xmax = Find<TextBox>(graph, item => item.Name == "txb_X_Max");
            Click(xmax); xmax.Text = "20"; owner.KeyPress(Key.Enter, RawInputModifiers.None, default, null);
            Assert.That(graph.X_max, Is.EqualTo(20));
            ClickTool(graph, "btnFitGraph"); Assert.That(graph.X_max, Is.EqualTo(10));
            var canvas = graph.GetVisualDescendants().OfType<Control>().Single(item => item.Name == "graphControl");
            var position = canvas.TranslatePoint(new Point(100, 100), owner)!.Value;
            owner.MouseWheel(position, new Vector(0, 1));
            Assert.That(graph.X_max, Is.EqualTo(9)); Assert.That(graph.Y_max, Is.EqualTo(3.6f).Within(.0001));
            owner.MouseDown(position, MouseButton.Right); owner.MouseMove(position + new Vector(20, 10), RawInputModifiers.RightMouseButton);
            owner.MouseUp(position + new Vector(20, 10), MouseButton.Right);
            Assert.That(graph.X_min, Is.LessThan(0)); Assert.That(graph.Y_min, Is.GreaterThan(2));
            ClickTool(graph, "btnFitGraph");
            ClickTool(graph, "btnValueToTable");
            var clipboard = owner.Clipboard!.TryGetTextAsync(); Pump(() => clipboard.IsCompleted);
            Assert.That(clipboard.GetAwaiter().GetResult(), Does.Contain("\"0.00 2.00\"").And.Contain("\"10.00 4.00\""));

            owner.Width = 130; Dispatcher.UIThread.RunJobs();
            var toolbar = Find<DatabaseToolbar>(graph);
            var overflow = Find<Button>(toolbar, item => item.Name == "ToolbarOverflow");
            Click(overflow);
            var thickness = overflow.ContextMenu!.Items.Cast<MenuItem>().Single(item => Equals(item.Header, "Толщина линии"));
            Click(thickness);
            Click(thickness.Items.Cast<MenuItem>().Single(item => item.Name == "PathThickness3"));
            Assert.That(series.Thickness, Is.EqualTo(3));
            Click(overflow);
            var show = overflow.ContextMenu!.Items.Cast<MenuItem>().Single(item => Equals(item.Header, "Показать графики"));
            Click(show); Click(show.Items.Cast<MenuItem>().Single());
            Assert.That(series.IsShown, Is.False);
            overflow.ContextMenu.Close();
            ClickTool(graph, "btnFitGraph"); Assert.That(graph.X_max, Is.EqualTo(10));
        }
        finally { foreach (var dialog in owner.OwnedWindows.ToArray()) dialog.Close(); owner.Close(); }
    }

    [Test]
    public void TableKeyboardDeletesSelectedRowsButEditsCellTextWithoutDeletingTheRow()
    {
        var table = new DataTable(); table.Columns.Add("X", typeof(float)); table.Columns.Add("Y", typeof(float));
        table.Rows.Add(1f, 2f); table.Rows.Add(3f, 4f);
        var editor = new DataTableEditor { DataSource = table };
        var owner = new Window { Width = 420, Height = 250, Content = editor }; owner.Show();
        var deletes = 0; editor.UserDeletingRow += (_, _) => deletes++;
        try
        {
            var cell = Find<TextBox>(editor); Click(cell); owner.KeyPress(Key.Delete, RawInputModifiers.None, default, null); Dispatcher.UIThread.RunJobs();
            Assert.That(table.Rows.Count, Is.EqualTo(1)); Assert.That(deletes, Is.EqualTo(1));
            cell = Find<TextBox>(editor); Click(cell); owner.KeyPress(Key.F2, RawInputModifiers.None, default, null);
            Assert.That(cell.IsReadOnly, Is.False);
            owner.KeyTextInput("13"); owner.KeyPress(Key.Delete, RawInputModifiers.None, default, null);
            Assert.That(table.Rows.Count, Is.EqualTo(1)); Assert.That(deletes, Is.EqualTo(1));
            owner.KeyPress(Key.Enter, RawInputModifiers.None, default, null); Dispatcher.UIThread.RunJobs();
            Assert.That(Convert.ToSingle(table.Rows[0][0]), Is.EqualTo(13f));
        }
        finally { owner.Close(); }
    }

    [Test]
    public void TableColumnHeaderDragChangesDisplayOrderWithoutChangingDataTableOrdinals()
    {
        var table = new DataTable(); table.Columns.Add("X", typeof(float)); table.Columns.Add("Y", typeof(float));
        table.Rows.Add(1f, 2f);
        var editor = new DataTableEditor { DataSource = table };
        var owner = new Window { Width = 420, Height = 250, Content = editor }; owner.Show();
        try
        {
            Dispatcher.UIThread.RunJobs(); using var frame = owner.CaptureRenderedFrame();
            var headers = editor.GetVisualDescendants().OfType<Button>().Where(item => item.Name == "ColumnHeader").ToArray();
            var from = headers[0].TranslatePoint(new Point(headers[0].Bounds.Width / 2, 10), owner)!.Value;
            var to = headers[1].TranslatePoint(new Point(headers[1].Bounds.Width / 2, 10), owner)!.Value;
            owner.MouseDown(from, MouseButton.Left); owner.MouseMove(to, RawInputModifiers.LeftMouseButton); owner.MouseUp(to, MouseButton.Left);
            Dispatcher.UIThread.RunJobs();
            Assert.That(editor.GetVisualDescendants().OfType<Button>().Where(item => item.Name == "ColumnHeader").Select(item => item.Content), Is.EqualTo(new[] { "Y", "X" }));
            Assert.That(table.Columns[0].ColumnName, Is.EqualTo("X"));
            var cell = Find<TextBox>(editor); Click(cell); owner.KeyPress(Key.F2, RawInputModifiers.None, default, null);
            owner.KeyTextInput("7"); owner.KeyPress(Key.Enter, RawInputModifiers.None, default, null); Dispatcher.UIThread.RunJobs();
            Assert.That(Convert.ToSingle(table.Rows[0][1]), Is.EqualTo(7f));
            Assert.That(Convert.ToSingle(table.Rows[0][0]), Is.EqualTo(1f));
        }
        finally { owner.Close(); }
    }

    [Test]
    public void EmptyProjectDatabaseToolbarClicksPublishVisibleBranchesAndSaveBothDatabases()
    {
        using var culture = new DatabaseCulture();
        var source = Path.Combine(directory, "empty.bpf2");
        var created = new ProjectController();
        created.CreateProject(Path.GetFileName(source)); created.CreateTask(); created.Save(source);
        var window = new MainWindow(); window.Show();
        try
        {
            var input = Find<TextBox>(Find<ConsoleControl>(window));
            void Enter(string command)
            {
                input.Text = command;
                input.RaiseEvent(new KeyEventArgs { RoutedEvent = InputElement.KeyDownEvent, Key = Key.Enter });
            }
            Enter($"\"Load project\" \"{source}\""); Pump(() => window.OwnedWindows.Count == 0);
            window.OpenMaterialsDB("Materials"); Dispatcher.UIThread.RunJobs();
            var materials = Find<MaterialsDataBasePage>(window);
            var materialEvents = 0; window.OnChangeMaterials += (_, _) => materialEvents++;
            ClickTool(materials, "AddBranch");
            Assert.That(materialEvents, Is.EqualTo(1));
            Assert.That(materials.Materials.Count, Is.EqualTo(1));
            var materialNode = materials.TreeView.Nodes.Single();
            Assert.That(materialNode.Template, Is.Not.Null);
            Assert.That(materialNode.Bounds.Height, Is.GreaterThan(0));
            Assert.That(Find<Border>(materialNode, item => item.Name == "DatabaseNodeHeader").Bounds.Height, Is.EqualTo(18));
            var matPath = Path.Combine(directory, materials.Materials.Name);
            var materialPicker = CreatePicker(); materialPicker.SaveFile = DatabaseFile(new Uri(matPath));
            materials.StorageProvider = materialPicker.Provider;
            ClickTool(materials, "SaveDB"); Pump(() => File.Exists(matPath));
            window.OpenFunctionsDB("Functions"); Dispatcher.UIThread.RunJobs();
            var functions = Find<FunctionDataBasePage>(window);
            var functionEvents = 0; window.OnChangeFunctions += (_, _) => functionEvents++;
            ClickTool(functions, "AddBranch");
            Assert.That(functionEvents, Is.EqualTo(1));
            Assert.That(functions.Functions.Count, Is.EqualTo(1));
            var functionNode = functions.TreeView.Nodes.Single();
            Click(Find<Border>(functionNode, item => item.Name == "DatabaseNodeHeader"));
            Assert.That(functions.DataGridView.DataSource, Is.SameAs(functions.Functions.Values.Single().DataTable));
            Assert.That(Find<TextBox>(functions.DataGridView).Bounds.Width, Is.GreaterThan(0));
            Assert.That(functions.GraphContainer.CurrentData, Is.Not.Empty);
            var funPath = Path.Combine(directory, functions.Functions.Name);
            var functionPicker = CreatePicker(); functionPicker.SaveFile = DatabaseFile(new Uri(funPath));
            functions.StorageProvider = functionPicker.Provider;
            ClickTool(functions, "SaveDB"); Pump(() => File.Exists(funPath));
            var saved = Path.Combine(directory, "with-databases.bpf2");
            Enter($"\"Save project\" \"{saved}\""); Pump(() => File.Exists(saved));
            var reopened = new ProjectController(); reopened.Load(saved);
            Assert.That(reopened.MaterialsDB.Keys, Is.EquivalentTo(materials.Materials.Keys));
            Assert.That(reopened.FunctionsDB.Keys, Is.EquivalentTo(functions.Functions.Keys));
        }
        finally { foreach (var dialog in window.OwnedWindows.ToArray()) dialog.Close(); window.Close(); }
    }

    [TestCase(false)]
    [TestCase(true)]
    public void ActualPickerToolbarDoesNotPublishCanceledCorruptNonlocalOrFailedLoads(bool materialPage)
    {
        using var culture = new DatabaseCulture();
        DataBasePage page = materialPage ? new MaterialsDataBasePage() : new FunctionDataBasePage();
        var picker = CreatePicker(); page.StorageProvider = picker.Provider;
        var owner = new Window { Width = 850, Height = 600, Content = page }; owner.Show();
        var loads = 0; page.LoadEvent += () => loads++;
        var mutations = 0;
        if (page is MaterialsDataBasePage materials) materials.OnMutationEvent += () => mutations++;
        else ((FunctionDataBasePage)page).OnMutationEvent += () => mutations++;
        try
        {
            var good = materialPage ? RepositoryFile("GUI", "DataBases", "Materials", "Materials_v4.jsf") : RepositoryFile("GUI", "DataBases", "Functions", "functions_draft.txt");
            picker.Files = [DatabaseFile(new Uri(good))];
            ClickTool(page, "OpenFileDB");
            Assert.That(loads, Is.EqualTo(1)); Assert.That(page.TreeView.Nodes, Is.Not.Empty);
            var initialNodes = page.TreeView.Nodes.ToArray();
            var initialData = materialPage ? (object)((MaterialsDataBasePage)page).Materials : ((FunctionDataBasePage)page).Functions;
            var corrupt = Path.Combine(directory, "corrupt.jsf"); File.WriteAllText(corrupt, "{ invalid json");
            var invalidEntry = Path.Combine(directory, "invalid-entry.jsf");
            var serialized = Newtonsoft.Json.Linq.JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(initialData, new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto }));
            serialized.Add("invalid-last-entry", null); File.WriteAllText(invalidEntry, serialized.ToString());
            foreach (var command in new[] { "OpenFileDB", "AddDB" })
                foreach (var result in new IReadOnlyList<IStorageFile>[] { [], [DatabaseFile(new Uri(corrupt))], [DatabaseFile(new Uri("https://example.test/database.jsf"))], [DatabaseFile(new Uri(invalidEntry))] })
                {
                    picker.Files = result; ClickTool(page, command);
                    Assert.That(loads, Is.EqualTo(1)); Assert.That(mutations, Is.Zero);
                    Assert.That(page.TreeView.Nodes, Is.EqualTo(initialNodes));
                    Assert.That(materialPage ? (object)((MaterialsDataBasePage)page).Materials : ((FunctionDataBasePage)page).Functions, Is.SameAs(initialData));
                    if (result.Count > 0)
                    {
                        Assert.That(owner.OwnedWindows, Has.Count.EqualTo(1));
                        Assert.That(Find<SelectableTextBlock>(owner.OwnedWindows.Single()).Text, Does.Contain(result[0].Path.IsFile ? result[0].Path.LocalPath : result[0].Path.ToString()));
                    }
                    foreach (var error in owner.OwnedWindows.ToArray()) error.Close(); Dispatcher.UIThread.RunJobs();
                }
            picker.Error = new IOException("Picker failed");
            ClickTool(page, "AddDB");
            Assert.That(loads, Is.EqualTo(1)); Assert.That(mutations, Is.Zero);
            Assert.That(Find<SelectableTextBlock>(owner.OwnedWindows.Single()).Text, Does.Contain("Picker failed"));
        }
        finally { foreach (var dialog in owner.OwnedWindows.ToArray()) dialog.Close(); owner.Close(); }
    }

    [TestCase(1d, 420d)]
    [TestCase(1.25d, 420d)]
    [TestCase(1d, 850d)]
    public void MaterialPickerRendersSourceHierarchyTableGraphAndToolbarAtNarrowWidth(double scale, double width)
    {
        using var culture = new DatabaseCulture();
        var page = new MaterialsDataBasePage { HeadColor = System.Drawing.Color.Gainsboro };
        var picker = CreatePicker(); picker.Files = [DatabaseFile(new Uri(RepositoryFile("GUI", "DataBases", "Materials", "Materials_v4.jsf")))];
        page.StorageProvider = picker.Provider;
        var owner = new Window { Width = width, Height = 950, FontSize = 11, Content = page };
        owner.Show(); owner.SetRenderScaling(scale);
        try
        {
            ClickTool(page, "AddDB");
            var material = page.TreeView.Nodes[0];
            Click(Find<ToggleButton>(material, item => item.Name == "PART_ExpandCollapseChevron"));
            var category = material.Nodes["Тепловые свойства"];
            Click(Find<ToggleButton>(category, item => item.Name == "PART_ExpandCollapseChevron"));
            Assert.That(category.IsExpanded, Is.True, "The visible category expansion button must work at narrow width.");
            var property = category.Nodes.First(node => node.Name.StartsWith("Теплопроводность,"));
            Click(Find<Border>(property, item => item.Name == "DatabaseNodeHeader"));
            Assert.That(page.DataGridView.DataSource.Rows.Count, Is.GreaterThan(0));
            Assert.That(page.GraphContainer.CurrentData, Is.Not.Empty);
            var scroll = Find<ScrollViewer>(page.TreeView);
            Assert.That(scroll.Offset.X, Is.Zero);
            if (width < 500)
            {
                Assert.That(scroll.Extent.Width, Is.GreaterThan(scroll.Viewport.Width));
                Assert.That(page.TreeView.GetVisualDescendants().OfType<ScrollBar>().Any(item => item.Orientation == Avalonia.Layout.Orientation.Horizontal && item.IsVisible), Is.True);
            }
            Assert.That(page.TreeView.Bounds.Width / page.Bounds.Width, Is.EqualTo(.29).Within(.02));
            Assert.That(page.GraphContainer.Bounds.Height, Is.GreaterThan(page.DataGridView.Bounds.Height));
            Assert.That(Find<TextBox>(page.DataGridView).Bounds.Width, Is.GreaterThan(60));
            Assert.That(Find<Button>(page.GraphContainer, item => item.Name == "dashButton").IsEffectivelyVisible, Is.True);
            Assert.That(Find<Button>(page.GraphContainer, item => item.Name == "lineButton").Content, Is.TypeOf<Image>());
            using var frame = owner.CaptureRenderedFrame();
            Assert.That(frame, Is.Not.Null);
            var snapshots = Environment.GetEnvironmentVariable("BAZIS_DATABASE_SNAPSHOT_DIR");
            if (!string.IsNullOrEmpty(snapshots))
            {
                Directory.CreateDirectory(snapshots);
                frame!.Save(Path.Combine(snapshots, $"materials-{width}-{scale}.png"), new Avalonia.Media.Imaging.PngBitmapEncoderOptions());
            }
        }
        finally { foreach (var dialog in owner.OwnedWindows.ToArray()) dialog.Close(); owner.Close(); }
    }
}
