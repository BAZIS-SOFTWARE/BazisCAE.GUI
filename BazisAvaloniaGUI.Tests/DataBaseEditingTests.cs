using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Avalonia.Media;
using Ellipse = Avalonia.Controls.Shapes.Ellipse;
using BazisAvaloniaGUI.Databases;
using BazisAvaloniaGUI.Databases.MechanicalGUI;
using BazisAvaloniaGUI.Databases.MetallurgyGUI;
using BazisAvaloniaGUI.Console;
using BazisAvaloniaGUI.Shell;
using MaterialDB.MaterialData;
using NUnit.Framework;
using OperationalController;
using System.Data;
using System.Globalization;

namespace BazisAvaloniaGUI.Tests;

public partial class AvaloniaTests
{
    private sealed class DatabaseCulture : IDisposable
    {
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;
        public DatabaseCulture() { CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; }
        public void Dispose() { CultureInfo.CurrentCulture = culture; }
    }

    private static MaterialsDataBasePage DraftMaterials()
    {
        var page = new MaterialsDataBasePage();
        page.Load(RepositoryFile("GUI", "DataBases", "Materials", "materials_draft.txt"), false);
        return page;
    }

    private static TreeNode SelectProperty(MaterialsDataBasePage page, string category, string property)
    {
        var node = page.TreeView.Nodes[0].Nodes[category].Nodes.First(n => n.Name!.Split(',')[0] == property);
        page.TreeView.SelectedNode = node;
        page.TreeView_AfterSelect(page.TreeView, new TreeViewEventArgs(node));
        return node;
    }

    [Test]
    public void FunctionsEditorCommitsUserInputSortsCopiesAndRoundTripsJson()
    {
        using var culture = new DatabaseCulture();
        var page = new FunctionDataBasePage();
        page.Load(RepositoryFile("GUI", "DataBases", "Functions", "functions_draft.txt"), false);
        var window = new Window { Width = 850, Height = 600, Content = page };
        window.Show();
        try
        {
            foreach (var name in new[] { "OpenFileDB", "AddDB", "SaveDB", "AddBranch", "DeleteBranch", "CreateCopy", "AddRow", "ClearRows", "SortRows" })
            {
                var toolbarButton = Find<Button>(page, b => b.Name == name);
                Assert.That(toolbarButton.Content, Is.TypeOf<Image>());
                Assert.That(((Image)toolbarButton.Content!).Source, Is.Not.Null);
                Assert.That(ToolTip.GetTip(toolbarButton), Is.Not.Null.And.Not.Empty);
            }
            var node = page.TreeView.Nodes[0];
            page.TreeView.SelectedNode = node;
            page.TreeView_AfterSelect(page.TreeView, new TreeViewEventArgs(node));
            Dispatcher.UIThread.RunJobs();
            var function = page.Functions.Values.Single();
            Assert.That(page.DataGridView.DataSource, Is.SameAs(function.DataTable));
            Assert.That(page.GraphContainer.CurrentData.Count, Is.EqualTo(1));

            var input = Find<TextBox>(page.DataGridView);
            input.Text = "12.5";
            input.RaiseEvent(new KeyEventArgs { RoutedEvent = InputElement.KeyDownEvent, Key = Key.Enter });
            Assert.That(Convert.ToSingle(function.DataTable.Rows[0][0]), Is.EqualTo(12.5f));
            Dispatcher.UIThread.RunJobs();
            input = Find<TextBox>(page.DataGridView);
            input.Text = "7.5";
            input.RaiseEvent(new FocusChangedEventArgs(InputElement.LostFocusEvent));
            Assert.That(Convert.ToSingle(function.DataTable.Rows[0][0]), Is.EqualTo(7.5f));

            page.AddNewRowButton_Click(page, EventArgs.Empty);
            page.Resort_Click(page, EventArgs.Empty);
            Assert.That(function.DataTable.Rows.Cast<DataRow>().Select(row => Convert.ToSingle(row[0])), Is.EqualTo(new[] { 0f, 7.5f }));
            Assert.That(page.GraphContainer.CurrentData.Single().Points.Select(p => p.X), Is.EqualTo(new[] { 0f, 7.5f }));
            page.DelAllRowsButton_Click(page, EventArgs.Empty);
            Assert.That(function.DataTable.Rows.Count, Is.EqualTo(2), "Functions.Clear is the source no-op.");

            var mutations = 0;
            page.OnMutationEvent += () => mutations++;
            page.CreateCopy_Click(page, EventArgs.Empty);
            Assert.That(page.Functions.Count, Is.EqualTo(2));
            var copy = page.Functions.Values.Last();
            Assert.That(copy.DataTable, Is.Not.SameAs(function.DataTable));
            copy.DataTable.Rows[0][1] = 123f;
            Assert.That(Convert.ToSingle(function.DataTable.Rows[0][1]), Is.Zero);
            page.RenameNode(node, "renamed,s-m");
            Assert.That(page.Functions["renamed"], Is.SameAs(function));
            Assert.That(node.Name, Is.EqualTo("renamed,s-m"));
            page.TreeView.SelectedNode = page.TreeView.Nodes.Last();
            page.DelBrachButton_Click(page, EventArgs.Empty);
            Assert.That(mutations, Is.EqualTo(2));

            var saved = Path.Combine(directory, "functions.jsf");
            page.SafeDBEventHandler(saved);
            var reopened = new FunctionDataBasePage();
            reopened.Load(saved, false);
            Assert.That(reopened.Functions.Keys, Is.EquivalentTo(page.Functions.Keys));
            Assert.That(Convert.ToSingle(reopened.Functions["renamed"].DataTable.Rows[1][0]), Is.EqualTo(7.5f));
        }
        finally { window.Close(); }
    }

    [Test]
    public void MaterialStructureEditsMaintainColumnsAndReactionKeys()
    {
        using var culture = new DatabaseCulture();
        var page = DraftMaterials();
        var window = new Window { Width = 850, Height = 600, Content = page };
        window.Show();
        try
        {
            var material = page.Materials.Values.Single();
            SelectProperty(page, "Общие сведения", "Структура");
            var structure = page.DataGridView.DataSource;
            var properties = material["Тепловые свойства"].PropertyData.Values.Concat(material["Механические свойства"].PropertyData.Values).ToArray();
            page.AddNewRowButton_Click(page, EventArgs.Empty);
            Assert.That(structure.Rows[1][0], Is.EqualTo("newPhase2"));
            Assert.That(properties.All(p => p.DataTable.Columns.Contains("newPhase2")), Is.True);

            var reactionTable = new DataTable();
            reactionTable.Columns.Add("Температура", typeof(float));
            reactionTable.Columns.Add("Масс.Доли", typeof(float));
            var reaction = new Property("Охлаждение F-newPhase2", "°C", "Масс.Доли", "Масс.Доли-°C", reactionTable);
            material["Металлургия"].PropertyData.Add(reaction.Name, reaction);
            page.PresentMaterials();
            SelectProperty(page, "Общие сведения", "Структура");
            page.DataGridView.EditValue(1, 0, "Phase_2");
            Assert.That(properties.All(p => p.DataTable.Columns.Contains("Phase_2") && !p.DataTable.Columns.Contains("newPhase2")), Is.True);
            Assert.That(material["Металлургия"].PropertyData["Охлаждение F-Phase_2"], Is.SameAs(reaction));
            Assert.That(page.TreeView.Nodes[0].Nodes["Металлургия"].Nodes.Single().Name, Does.StartWith("Охлаждение F-Phase_2,"));

            page.DataGridView.EditValue(1, 0, "invalid phase");
            Assert.That(structure.Rows[1][0], Is.EqualTo("Phase_2"));
            Assert.That(properties.All(p => p.DataTable.Columns.Contains("Phase_2")), Is.True);
            foreach (var dialog in window.OwnedWindows.ToArray()) dialog.Close();
            page.DataGridView.DeleteRow(1);
            Assert.That(structure.Rows.Count, Is.EqualTo(1));
            Assert.That(properties.All(p => !p.DataTable.Columns.Contains("Phase_2")), Is.True);
            Assert.That(material["Металлургия"].PropertyData, Is.Empty);
            page.AddNewRowButton_Click(page, EventArgs.Empty);
            page.DelAllRowsButton_Click(page, EventArgs.Empty);
            Assert.That(structure.Rows.Count, Is.Zero);
            Assert.That(properties.All(p => p.DataTable.Columns.Count == 1), Is.True);
        }
        finally { window.Close(); }
    }

    [Test]
    public void NewDatabaseBranchesUseShippedTemplatesAndPreserveCopyRenameMutation()
    {
        using var culture = new DatabaseCulture();
        var page = new MaterialsDataBasePage();
        var mutations = 0;
        page.OnMutationEvent += () => mutations++;
        page.AddBranchButton_Click(page, EventArgs.Empty);
        Assert.That(page.Materials.Count, Is.EqualTo(1));
        var node = page.TreeView.Nodes[0];
        page.TreeView.SelectedNode = node;
        page.CreateCopy_Click(page, EventArgs.Empty);
        Assert.That(page.Materials.Count, Is.EqualTo(2));
        Assert.That(mutations, Is.EqualTo(2));
        var material = page.Materials[node.Name!];
        var copy = page.Materials.Values.Last();
        Assert.That(copy["Общие сведения"]["Структура"].DataTable, Is.Not.SameAs(material["Общие сведения"]["Структура"].DataTable));
        page.RenameNode(node, "RenamedMaterial");
        Assert.That(page.Materials["RenamedMaterial"], Is.SameAs(material));
        Assert.That(node.Text, Is.EqualTo("RenamedMaterial"));
        var saved = Path.Combine(directory, "material.jsf");
        page.SafeDBEventHandler(saved);
        var reopened = new MaterialsDataBasePage();
        reopened.Load(saved, false);
        Assert.That(reopened.Materials.Keys, Is.EquivalentTo(page.Materials.Keys));

        var functions = new FunctionDataBasePage();
        functions.AddBranchButton_Click(functions, EventArgs.Empty);
        Assert.That(functions.Functions.Count, Is.EqualTo(1));
        Assert.That(functions.TreeView.Nodes.Count, Is.EqualTo(1));
    }

    [Test]
    public void ReactionEditorIsOwnedModalAndKeepsTheSamePropertyAndTable()
    {
        using var culture = new DatabaseCulture();
        var page = DraftMaterials();
        var owner = new Window { Width = 850, Height = 600, Content = page };
        owner.Show();
        try
        {
            SelectProperty(page, "Общие сведения", "Структура");
            page.AddNewRowButton_Click(page, EventArgs.Empty);
            var material = page.Materials.Values.Single();
            page.TreeView.SelectedNode = page.TreeView.Nodes[0].Nodes["Металлургия"];
            page.AddReacItem_Click(page, EventArgs.Empty);
            var node = page.TreeView.Nodes[0].Nodes["Металлургия"].Nodes.Single();
            page.TreeView.SelectedNode = node;
            page.EditMenuItem_Click(page, EventArgs.Empty);
            var modal = owner.OwnedWindows.Single();
            Assert.That(modal.Name, Is.EqualTo("editForm"));
            Assert.That(modal.IsDialog, Is.True);
            var control = (ReactionControl)modal.Content!;
            var reaction = material["Металлургия"].PropertyData.Values.Single();
            Assert.That(control.DataGridView.DataSource, Is.SameAs(reaction.DataTable));
            Dispatcher.UIThread.RunJobs();
            var indicator = Find<Border>(control.TimeDependent, b => b.Name == "DatabaseIndicator");
            Assert.That((indicator.Bounds.Width, indicator.Bounds.Height), Is.EqualTo((16d, 16d)));
            Assert.That(indicator.Padding, Is.EqualTo(new Avalonia.Thickness(2, 3)));
            control.TimeDependent.IsEnabled = false;
            Assert.That(((ISolidColorBrush)indicator.Background!).Color, Is.EqualTo(Color.Parse("#F8F8F8")));
            Assert.That(((ISolidColorBrush)indicator.BorderBrush!).Color, Is.EqualTo(Color.Parse("#CACACA")));
            control.TimeDependent.IsEnabled = true;
            Assert.That(((ISolidColorBrush)indicator.Background!).Color, Is.EqualTo(Colors.White));
            Find<Button>(control, b => b.Name == "AddReactionRow").RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            Assert.That(reaction.DataTable.Rows.Count, Is.EqualTo(1));
            control.DataGridView.EditValue(0, 0, 800f);
            control.DataGridView.EditValue(0, 1, .2f);
            control.PhaseName.SelectedItem = "Охлаждение";
            control.InitialPhase.SelectedItem = "F";
            control.FinalPhase.SelectedItem = "newPhase2";
            Assert.That(material["Металлургия"]["Охлаждение F-newPhase2"], Is.SameAs(reaction));
            Assert.That(node.Name, Does.StartWith("Охлаждение F-newPhase2,"));

            control.TimeDependent.IsChecked = true;
            control.TimeDependent.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            var warning = modal.OwnedWindows.Single();
            Find<Button>(warning, b => Equals(b.Content, "Отмена")).RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            Dispatcher.UIThread.RunJobs();
            Assert.That(reaction.DataTable.Columns.Count, Is.EqualTo(2));
            Assert.That(Convert.ToSingle(reaction.DataTable.Rows[0][1]), Is.EqualTo(.2f));
            control.TimeDependent.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            modal.OwnedWindows.Single().Close();
            Dispatcher.UIThread.RunJobs();
            Assert.That(reaction.DataTable.Columns.Count, Is.EqualTo(2), "Closing the dialog does not approve deletion.");
            control.TimeDependent.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            Find<Button>(modal.OwnedWindows.Single(), b => Equals(b.Content, "OK")).RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            Dispatcher.UIThread.RunJobs();
            Assert.That(reaction.DataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName), Is.EqualTo(new[] { "Температура", "Масс.Доли_0.1", "Масс.Доли_1" }));
            control.PhaseValue.Text = "0.5";
            control.btnAddTime_Click(control, EventArgs.Empty);
            Assert.That(reaction.DataTable.Columns.Contains("Масс.Доли_0.5"), Is.True);
            control.DataGridView.SelectedColumn = 3;
            control.PhaseValue.Text = "0.7";
            control.btnChange_Click(control, EventArgs.Empty);
            Assert.That(reaction.DataTable.Columns.Contains("Масс.Доли_0.7"), Is.True);
            control.btnDelTime_Click(control, EventArgs.Empty);
            Assert.That(reaction.DataTable.Columns.Contains("Масс.Доли_0.7"), Is.False);
            modal.Close();
            Dispatcher.UIThread.RunJobs();
            Assert.That(owner.IsEnabled, Is.True);
            Assert.That(page.AuxiliaryWindows, Is.Empty);
        }
        finally { foreach (var window in page.AuxiliaryWindows.ToArray()) window.Close(); owner.Close(); }
    }

    [Test]
    public void CalculatorsRemainOwnedNonmodalAndUseMaterialProperties()
    {
        using var culture = new DatabaseCulture();
        var page = DraftMaterials();
        var owner = new Window { Width = 850, Height = 600, Content = page };
        owner.Show();
        try
        {
            var material = page.Materials.Values.Single();
            var mech = material["Механические свойства"].PropertyData;
            foreach (var name in new[] { "Предел текучести", "Предел прочности", "Коэффициент упрочнения" })
            {
                mech[name].DataTable.Rows.Clear();
                mech[name].DataTable.Rows.Add(0f, name == "Предел текучести" ? 100f : 200f);
                mech[name].DataTable.Rows.Add(100f, name == "Предел текучести" ? 120f : 220f);
            }
            page.TreeView.SelectedNode = page.TreeView.Nodes[0].Nodes["Механические свойства"];
            page.HardeningCalcItem_Click(page, EventArgs.Empty);
            var window = page.AuxiliaryWindows.Single();
            Assert.That(window.Name, Is.EqualTo("hardCalc"));
            Assert.That(window.IsDialog, Is.False);
            Assert.That(owner.IsEnabled, Is.True);
            var hardening = (HardeningControl)window.Content!;
            hardening.PhaseSelector.SelectedItem = "F";
            var graphs = hardening.CaclHardeningForTemps();
            Assert.That(graphs.Count, Is.EqualTo(2));
            Assert.That(graphs.Select(g => g.Points[0].Y), Is.EqualTo(new[] { 100f, 120f }));
            hardening.TemperatureInput.Text = "50";
            Assert.That(hardening.CaclHardeningForTemp().Single().Points[0].Y, Is.EqualTo(110f).Within(.001));
            window.Close();
            page.TreeView.SelectedNode = page.TreeView.Nodes[0].Nodes["Металлургия"];
            page.DiagramCalcItem_Click(page, EventArgs.Empty);
            window = page.AuxiliaryWindows.Single();
            Assert.That(window.Name, Is.EqualTo("diagCalc"));
            Assert.That(window.IsDialog, Is.False);
            Assert.That(window.Content, Is.TypeOf<DiagramControl>());
            Assert.That(owner.IsEnabled, Is.True);
            window.Close();
        }
        finally { foreach (var window in page.AuxiliaryWindows.ToArray()) window.Close(); owner.Close(); }
    }

    [Test]
    public void CctAndTttRunTheMetallurgicalPipelineAndSwitchPanels()
    {
        using var culture = new DatabaseCulture();
        var page = new MaterialsDataBasePage();
        page.Load(RepositoryFile("GUI", "DataBases", "Materials", "Materials_v7.jsf"), false);
        var material = page.Materials.Values.First(m => m["Металлургия"].PropertyData.Keys.Any(k => k.StartsWith("Охлаждение")));
        var structure = material["Общие сведения"]["Структура"].DataTable;
        var diagram = new DiagramControl(material.Name, material["Металлургия"].PropertyData, structure);
        var window = new Window { Width = 700, Height = 700, Content = diagram };
        window.Show();
        try
        {
            var initial = diagram.CctPanel.GetPhases().First();
            Assert.That(diagram.TttPanel.GetPhases(), Is.EquivalentTo(diagram.CctPanel.GetPhases()));
            diagram.CctPanel.PhaseSelector.SelectedItem = initial;
            diagram.CctPanel.MinimumVelocityInput.Text = "-10";
            diagram.CctPanel.MaximumVelocityInput.Text = "-20";
            diagram.CctPanel.VelocityQuantity.Value = 2;
            diagram.CctPanel.InitialTemperatureInput.Text = "800";
            diagram.CctPanel.FinalTemperatureInput.Text = "20";
            diagram.CalcCCTDiagram();
            Assert.That(diagram.Graph.Header, Is.EqualTo("CCT"));
            var velocities = diagram.Graph.CurrentData.Where(d => d.Name.StartsWith("Скорость")).ToArray();
            Assert.That(velocities.Length, Is.EqualTo(2));
            Assert.That(velocities[0].Points[0].X, Is.Zero);
            Assert.That(velocities[0].Points[1].Y, Is.EqualTo(790f));
            Assert.That(velocities[1].Points[1].Y, Is.EqualTo(770f), "Preserves the source accumulated cooling speed.");
            Find<RadioButton>(diagram, radio => Equals(radio.Content, "TTT")).IsChecked = true;
            Dispatcher.UIThread.RunJobs();
            Assert.That(Find<TTTControl>(diagram), Is.SameAs(diagram.TttPanel));
            var selectedRadio = Find<RadioButton>(diagram, radio => radio.IsChecked == true);
            var radioIndicator = Find<Border>(selectedRadio, b => b.Name == "DatabaseIndicator");
            Assert.That((radioIndicator.Bounds.Width, radioIndicator.Bounds.Height), Is.EqualTo((16d, 16d)));
            Assert.That(radioIndicator.Padding, Is.EqualTo(new Avalonia.Thickness(3)));
            Assert.That(Find<Ellipse>(selectedRadio, dot => dot.Name == "DatabaseDot").IsVisible, Is.True);
            diagram.TttPanel.PhaseSelector.SelectedItem = initial;
            diagram.TttPanel.InitialTemperatureInput.Text = "700";
            diagram.TttPanel.FinalTemperatureInput.Text = "500";
            diagram.TttPanel.MaximumTimeInput.Text = "400";
            diagram.CalcTTTDiagram();
            Assert.That(diagram.Graph.Header, Is.EqualTo("TTT"));
            Assert.That(diagram.Graph.CurrentData, Is.Not.Empty);
            Assert.That(diagram.Graph.CurrentData.SelectMany(d => d.Points).All(p => float.IsFinite(p.X) && float.IsFinite(p.Y)), Is.True);
        }
        finally { foreach (var dialog in window.OwnedWindows.ToArray()) dialog.Close(); window.Close(); }
    }

    [Test]
    public void DatabasesPagesPublishMutationsAndPersistTheLoadedProject()
    {
        using var culture = new DatabaseCulture();
        var source = Path.Combine(directory, "databases.bpf2");
        var created = new ProjectController();
        created.CreateProject(Path.GetFileName(source));
        created.CreateTask();
        var seed = DraftMaterials();
        seed.RenameNode(seed.TreeView.Nodes[0], "SeedMaterial");
        seed.Materials.Name = "materials.jsf";
        seed.SafeDBEventHandler(Path.Combine(directory, seed.Materials.Name));
        created.MaterialsDB = seed.Materials;
        var functions = new FunctionDataBasePage();
        functions.Load(RepositoryFile("GUI", "DataBases", "Functions", "functions_draft.txt"), false);
        functions.Functions.Name = "functions.jsf";
        functions.SafeDBEventHandler(Path.Combine(directory, functions.Functions.Name));
        created.FunctionsDB = functions.Functions;
        created.Save(source);
        var window = new MainWindow();
        window.Show();
        try
        {
            var input = Find<TextBox>(Find<ConsoleControl>(window));
            void Enter(string command)
            {
                input.Text = command;
                input.RaiseEvent(new KeyEventArgs { RoutedEvent = InputElement.KeyDownEvent, Key = Key.Enter });
            }
            Enter($"\"Load project\" \"{source}\"");
            Pump(() => window.OwnedWindows.All(dialog => dialog.Name != "Загрузка"));
            if (window.OwnedWindows.Count > 0)
                Assert.Fail(string.Join("\n", window.OwnedWindows.Select(dialog => Find<SelectableTextBlock>(dialog).Text)));
            window.OpenMaterialsDB("Materials");
            Dispatcher.UIThread.RunJobs();
            var materialsPage = Find<MaterialsDataBasePage>(window);
            var changes = 0;
            window.OnChangeMaterials += (_, _) => changes++;
            materialsPage.AddBranchButton_Click(materialsPage, EventArgs.Empty);
            Assert.That(changes, Is.EqualTo(1));
            Assert.That(materialsPage.Materials.Count, Is.EqualTo(2));
            window.OpenFunctionsDB("Functions");
            Dispatcher.UIThread.RunJobs();
            var functionsPage = Find<FunctionDataBasePage>(window);
            var functionChanges = 0;
            window.OnChangeFunctions += (_, _) => functionChanges++;
            functionsPage.AddBranchButton_Click(functionsPage, EventArgs.Empty);
            Assert.That(functionChanges, Is.EqualTo(1));
            // Project files refer to external databases by name in both UI implementations.
            materialsPage.SafeDBEventHandler(Path.Combine(directory, materialsPage.Materials.Name));
            functionsPage.SafeDBEventHandler(Path.Combine(directory, functionsPage.Functions.Name));
            var saved = Path.Combine(directory, "databases-saved.bpf2");
            Enter($"\"Save project\" \"{saved}\"");
            Pump(() => File.Exists(saved));
            var reopened = new ProjectController();
            reopened.Load(saved);
            Assert.That(reopened.MaterialsDB.Count, Is.EqualTo(2));
            Assert.That(reopened.FunctionsDB.Count, Is.EqualTo(2));
        }
        finally { window.Close(); }
    }
}
