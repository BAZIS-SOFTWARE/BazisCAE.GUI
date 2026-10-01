using Avalonia;
using Avalonia.Automation;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using MaterialDB.Interfaces;
using System;
using Color = System.Drawing.Color;

namespace BazisAvaloniaGUI.Databases
{
    /// <summary>
    /// Avalonia-аналог DataBasePage. Перенесены загрузка/добавление базы и событие LoadEvent;
    /// редактор таблиц, графики, переименование и сохранение базы ещё не перенесены.
    /// </summary>
    internal class DataBasePage : UserControl
    {
        // Avalonia: перекрывает StyledElement.Resources, чтобы Resources.X ссылался на строковые ресурсы.
        protected new class Resources : Localization.Resources { }

        public event Action LoadEvent;

        public string DataExtension { get; set; }

        public ILoader Loader;

        public ISaver Saver;

        public Color HeadColor { get; set; } = Color.Silver;

        // Avalonia: вместо TreeView со свойствами — список записей базы.
        internal ListBox TreeView { get; } = new() { Background = Brush.Parse("#F0F0F0") };

        public DataBasePage()
        {
            var openButton = new Button { Content = "Открыть", Margin = new Thickness(0, 0, 4, 0) };
            var addButton = new Button { Content = "Добавить" };
            AutomationProperties.SetName(openButton, "OpenFileDB");
            AutomationProperties.SetName(addButton, "AddDB");
            openButton.Click += OpenFileDB_Click;
            addButton.Click += AddDB_Click;

            var toolbar = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(4) };
            toolbar.Children.Add(openButton);
            toolbar.Children.Add(addButton);

            var layout = new Grid { RowDefinitions = new RowDefinitions("Auto,*") };
            layout.Children.Add(toolbar);
            Grid.SetRow(TreeView, 1);
            layout.Children.Add(TreeView);
            Content = new Border
            {
                BorderBrush = Brush.Parse("#7A7A7A"),
                BorderThickness = new Thickness(1),
                Background = Brush.Parse("#F0F0F0"),
                Child = layout
            };
        }

        public virtual void OpenFileDB_Click(object sender, RoutedEventArgs e)
        {
            LoadEvent?.Invoke();
        }

        public virtual void AddDB_Click(object sender, RoutedEventArgs e)
        {
            LoadEvent?.Invoke();
        }
    }
}
