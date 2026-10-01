using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using BazisAvaloniaGUI.Properties;
using NUnit.Framework;

namespace BazisAvaloniaGUI.Tests;

public partial class AvaloniaTests
{
    [Test]
    public void PropertyChangesRaisePropertyUpdateEventLikeDataGridView()
    {
        var panel = new PropertiesPanelControl();
        var window = new Window { Width = 300, Height = 300, Content = panel };
        window.Show();
        try
        {
            var clicked = false;
            var updates = new List<PropertyChangedEventArgs>();
            panel.PropertyUpdateEvent += updates.Add;
            panel.DrawTable(
            [
                new RowProperty("Type", "Тип", new DropDownPropertyValue("A", ["A", "B"])),
                new RowProperty("Flag", "Флаг", true),
                new RowProperty("Show", "", new ButtonPropertyValue("Показать", () => clicked = true)),
                new RowProperty("Number", "Номер", 5, true)
            ], "1 Узел", 1);
            Dispatcher.UIThread.RunJobs();

            Find<ComboBox>(panel).SelectedItem = "B";
            Find<CheckBox>(panel).IsChecked = false;
            Find<Button>(panel, button => Equals(button.Content, "Показать")).RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            Assert.That(updates.Select(u => (u.Key, u.LocalizedHeader, u.NewValue, u.OldValue)), Is.EqualTo(new[]
            {
                ("Type", "Тип", "B", "A"),
                ("Flag", "Флаг", "False", "True")
            }));
            Assert.That(updates.All(u => u.ObjInfo == "1 Узел" && u.Tag == 1), Is.True);
            Assert.That(clicked, Is.True);
        }
        finally { window.Close(); }
    }
}
