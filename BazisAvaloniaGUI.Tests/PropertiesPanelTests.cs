using Avalonia;
using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Input;
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

    private static void ClickAt(Window window, Point point)
    {
        window.MouseDown(point, MouseButton.Left);
        window.MouseUp(point, MouseButton.Left);
        Dispatcher.UIThread.RunJobs();
    }

    /// <summary>Центр ячейки значения строки rowIndex (строки по 25 px, колонка значений справа).</summary>
    private static Point ValueCell(int rowIndex) => new(300, rowIndex * 25 + 12);

    private static string Updates(List<PropertyChangedEventArgs> updates)
    {
        var text = string.Join("; ", updates.Select(u => $"{u.Key}:{u.OldValue}->{u.NewValue}"));
        updates.Clear();
        return text;
    }

    [Test]
    public void TextCellCommitsReplacedTextWithItsOwnOldValue()
    {
        var panel = new PropertiesPanelControl();
        var window = new Window { Width = 400, Height = 300, Content = panel };
        window.Show();
        try
        {
            var updates = new List<PropertyChangedEventArgs>();
            panel.PropertyUpdateEvent += updates.Add;
            panel.DrawTable(
            [
                new RowProperty("Text", "Текст", "abc"),
                new RowProperty("StartTime", "Старт", 1f),
                new RowProperty("StopTime", "Стоп", 7f)
            ]);
            Dispatcher.UIThread.RunJobs();

            // EditOnEnter: весь текст ячейки выделен, ввод заменяет его, Enter фиксирует.
            ClickAt(window, ValueCell(0));
            window.KeyTextInput("xyz");
            window.KeyPress(Key.Enter, RawInputModifiers.None, PhysicalKey.Enter, "\r");
            Dispatcher.UIThread.RunJobs();
            Assert.That(Updates(updates), Is.EqualTo("Text:abc->xyz"));

            // Уход на другую строку: OldValue — значение изменённой ячейки, а не той, куда кликнули.
            ClickAt(window, ValueCell(1));
            window.KeyTextInput("3");
            ClickAt(window, ValueCell(2));
            Assert.That(Updates(updates), Is.EqualTo("StartTime:1->3"));
        }
        finally { window.Close(); }
    }

    [Test]
    public void TextEditIsNotAppliedToRedrawnTable()
    {
        var panel = new PropertiesPanelControl();
        var window = new Window { Width = 400, Height = 300, Content = panel };
        window.Show();
        try
        {
            var updates = new List<PropertyChangedEventArgs>();
            panel.PropertyUpdateEvent += updates.Add;
            panel.DrawTable([new RowProperty("Name", "Имя", "first")]);
            Dispatcher.UIThread.RunJobs();

            ClickAt(window, ValueCell(0));
            window.KeyTextInput("edited");
            // Навигатор выбрал другой объект и перерисовал панель, пока правка не завершена.
            panel.DrawTable([new RowProperty("Name", "Имя", "second")]);
            Dispatcher.UIThread.RunJobs();

            Assert.That(updates, Is.Empty);
        }
        finally { window.Close(); }
    }

    [Test]
    public void NumericCellCommitsOnEndEditLikeDataGridViewNumericUpDownCell()
    {
        var panel = new PropertiesPanelControl();
        var window = new Window { Width = 400, Height = 300, Content = panel };
        window.Show();
        try
        {
            var updates = new List<PropertyChangedEventArgs>();
            panel.PropertyUpdateEvent += updates.Add;
            panel.DrawTable(
            [
                new RowProperty("Count", "Количество", new NumericUpDownValue(5, 0, 100, 0, 1)),
                new RowProperty("Name", "Имя", "abc")
            ]);
            Dispatcher.UIThread.RunJobs();

            ClickAt(window, ValueCell(0));
            window.KeyPress(Key.A, RawInputModifiers.Control, PhysicalKey.A, "a");
            window.KeyPress(Key.Back, RawInputModifiers.None, PhysicalKey.Backspace, "");
            window.KeyTextInput("1");
            window.KeyTextInput("2");
            Dispatcher.UIThread.RunJobs();
            Assert.That(updates, Is.Empty, "Значение не должно уходить в обработчик на каждый символ.");

            window.KeyPress(Key.Enter, RawInputModifiers.None, PhysicalKey.Enter, "\r");
            Dispatcher.UIThread.RunJobs();
            Assert.That(Updates(updates), Is.EqualTo("Count:5->12"));

            // Пустое поле не отправляется, при уходе фокуса восстанавливается прежнее значение.
            window.KeyPress(Key.A, RawInputModifiers.Control, PhysicalKey.A, "a");
            window.KeyPress(Key.Back, RawInputModifiers.None, PhysicalKey.Backspace, "");
            ClickAt(window, ValueCell(1));
            Assert.That(updates, Is.Empty);
            Assert.That(Find<NumericUpDown>(panel).Value, Is.EqualTo(12m));
        }
        finally { window.Close(); }
    }
}
