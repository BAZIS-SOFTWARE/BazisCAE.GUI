using BazisAvaloniaGUI.Databases;
using NUnit.Framework;
using System.Globalization;

namespace BazisAvaloniaGUI.Tests;

public partial class AvaloniaTests
{
    [Test]
    public void MaterialsPageLoadsJsfAndKeepsFileName()
    {
        var page = new MaterialsDataBasePage();
        page.Load(RepositoryFile("GUI", "DataBases", "Materials", "Materials_v7.jsf"), false);

        Assert.That(page.Materials.Count, Is.GreaterThan(0));
        Assert.That(page.Materials.Name, Is.EqualTo("Materials_v7.jsf"));
        Assert.That(page.DataExtension, Is.EqualTo(".jsf"));
    }

    [Test]
    public void TextDatabasesAreConvertedAndAddedLikeWinForms()
    {
        // Текстовый загрузчик PropertiesCalculator разбирает числа в текущей культуре (одинаково в WinForms и Avalonia).
        var previous = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        try
        {
            var materials = new MaterialsDataBasePage();
            materials.Load(RepositoryFile("GUI", "DataBases", "Materials", "Materials_v7.jsf"), false);
            var before = materials.Materials.Count;
            var mutations = 0;
            materials.OnMutationEvent += () => mutations++;
            materials.Load(RepositoryFile("GUI", "DataBases", "Materials", "materials_draft.txt"), true);
            Assert.That(materials.Materials.Count, Is.GreaterThanOrEqualTo(before));
            Assert.That(mutations, Is.EqualTo(1));

            var functions = new FunctionDataBasePage();
            functions.Load(RepositoryFile("GUI", "DataBases", "Functions", "functions_draft.txt"), false);
            Assert.That(functions.Functions.Count, Is.GreaterThan(0));
            Assert.That(functions.Functions.Name, Is.EqualTo("functions_draft.txt"));
        }
        finally { CultureInfo.CurrentCulture = previous; }
    }
}
