using Avalonia;
using Avalonia.Automation;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using BazisAvaloniaGUI.Localization;
using BazisAvaloniaGUI.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

namespace BazisAvaloniaGUI.Console
{
    /// <summary>Строка вывода консоли (аналог фрагмента текста RichTextBox с цветом).</summary>
    internal sealed record ConsoleMessage(string Text, Color Color);

    internal sealed class ConsoleControl : UserControl
    {
        // Avalonia: перекрывает StyledElement.Resources, чтобы Resources.X ссылался на строковые ресурсы.
        private new class Resources : Localization.Resources { }

        public bool CheckPrintElemsInfo { get; set; }
        public bool CheckPrintNodesInfo { get; set; }
        public bool ShowTaskInfo { get; private set; }
        public int SessionNumber { get; set; }
        public string GetSessionLogPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                     SessionNumber.ToString() + "bazis.session.txt");
            }
        }

        public event Func<string, Task<string>> ConsoleCommandEnteredEvent;
        public event Action CommandsListRequestedEvent;

        // Avalonia: вместо RichTextBox — цветные строки вывода и отдельная строка ввода команды.
        internal ObservableCollection<ConsoleMessage> Messages { get; } = new();
        private readonly TextBox rtxbInput = new() { AcceptsReturn = false, MinHeight = 20, Padding = new Thickness(3, 0) };
        private readonly ScrollViewer tlscOut;
        private readonly Grid rtxbField;
        private readonly Button link;

        public ConsoleControl()
        {
            InitializeComponent(out tlscOut, out rtxbField, out link);

            var path = $" > {Resources.CurrentSession} ";

            Messages.Add(new ConsoleMessage(path, Color.Green));
            Loaded += ConsoleControl_Load;
        }

        public void PrintInfo(string str, Color color)
        {
            if (!Dispatcher.UIThread.CheckAccess())
            {
                Dispatcher.UIThread.Post(() => PrintInfo(str, color));
                return;
            }

            Messages.Add(new ConsoleMessage($" > {str}", color));

            var path = GetSessionLogPath;
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                sw.Write(str);

            rtxbInput.Focus();
            Dispatcher.UIThread.Post(() => tlscOut.ScrollToEnd());
        }

        public void PrintHistory(string str)
        {
            rtxbInput.Text = str;
            rtxbInput.CaretIndex = str.Length;
        }

        private async void Link_LinkClicked(object sender, RoutedEventArgs e)
        {
            var launcher = TopLevel.GetTopLevel(this)?.Launcher;
            if (launcher != null)
                await launcher.LaunchUriAsync(new Uri(GetSessionLogPath));
        }

        private void btnDictionary_Click(object sender, RoutedEventArgs e) => CommandsListRequestedEvent.Invoke();

        private void ConsoleControl_Load(object sender, RoutedEventArgs e)
        {
            var rnd = new Random();
            SessionNumber = rnd.Next(0, 10000);

            link.Content = new TextBlock { Text = GetSessionLogPath, TextTrimming = TextTrimming.CharacterEllipsis };
            ToolTip.SetTip(link, GetSessionLogPath);
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            var sessionPath = Messages[0];
            Messages.Clear();
            Messages.Add(sessionPath);
        }

        private async void btnBackGroundInfo_Click(object sender, RoutedEventArgs e)
        {
            if (TopLevel.GetTopLevel(this) is not Window owner)
                return;

            var current = rtxbField.Background is SolidColorBrush brush
                ? Color.FromArgb(brush.Color.A, brush.Color.R, brush.Color.G, brush.Color.B) : Color.White;
            var colorDialog = await new ColorSelectionDialog(current).ShowDialog<Color?>(owner);

            if (colorDialog == null)
                return;

            rtxbField.Background = PropertiesPanelControl.ColorBrush(colorDialog.Value);
        }

        private async Task ExecuteCmdFile(string cmdFileName)
        {
            if (System.IO.File.Exists(cmdFileName))
            {
                var variables = new Dictionary<string, string>();
                var cmdLines = File.ReadAllLines(cmdFileName);
                foreach (var line in cmdLines)
                {
                    if (line.StartsWith("//"))
                        continue;
                    var matches = Regex.Matches(line, @"\$(\w+)");
                    if (matches.Count > 0)
                    {
                        foreach (System.Text.RegularExpressions.Match match in matches)
                        {
                            var name = match.Groups[1].Value;

                            if (!variables.ContainsKey(name))
                                variables[name] = "default";
                        }
                        try
                        {
                            await ProcessCommandLine(line, variables);
                        }
                        catch (Exception ex)
                        {
                            PrintInfo($"{ex.Message} in line: {line}", Color.Red);
                            break;
                        }

                    }
                    else
                    {
                        try
                        {
                            await ConsoleCommandEnteredEvent(line);
                        }
                        catch (Exception ex)
                        {
                            PrintInfo($"{ex.Message} in line: {line}", Color.Red);
                            break;
                        }
                    }
                }
            }
            else throw new Exception($"\n > {Resources.ExecuteCMDFileMissing}");
        }

        private async Task ProcessCommandLine(string line, Dictionary<string, string> variables)
        {
            var variableName = string.Empty;
            var newLine = string.Empty;

            var parts = line.Split('=', 2);

            if (parts.Length == 2)
            {
                variableName = parts[0].Trim().TrimStart('$');
                newLine = parts[1].Trim();
            }
            else newLine = line;

            //Заменяем переменные в строке вида "$name" значением из словаря
            foreach (var pair in variables)
                newLine = newLine.Replace("$" + pair.Key, pair.Value.ToString());

            var returnValue = await ConsoleCommandEnteredEvent(newLine);
            //Записываем результат "number" в Value словаря с ключом variableName
            SetValue(returnValue, variableName, variables);
        }

        private void SetValue(string returnValue, string variableName, Dictionary<string, string> variables)
        {
            if (variableName != string.Empty)
                variables[variableName] = returnValue;
        }

        private async void btnStartMacro_Click(object sender, RoutedEventArgs e)
        {
            var top = TopLevel.GetTopLevel(this);
            var files = await top.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                AllowMultiple = false,
                FileTypeFilter = [new FilePickerFileType("Bazis command file(*.tcf)") { Patterns = ["*.tcf"] }, FilePickerFileTypes.All]
            });

            if (files.Count == 0)
                return;

            var t = ExecuteCmdFile(files[0].TryGetLocalPath());
            await t;
            if (t.Exception != null)
                PrintInfo(t.Exception.InnerException.Message, Color.Red);
        }

        private async void KeyDownEventHadler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Avalonia: команда вводится в отдельной строке, после ввода она остаётся в выводе,
                // как последняя строка RichTextBox в WinForms.
                e.Handled = true;
                var cmds = rtxbInput.Text ?? string.Empty;
                rtxbInput.Text = string.Empty;
                Messages.Add(new ConsoleMessage(cmds, Color.Black));
                try
                {
                    await ConsoleCommandEnteredEvent(cmds);
                }
                catch (Exception ex)
                {
                    PrintInfo($"{ex.Message} in line: {cmds}", Color.Red);
                }
            }
            else if (e.Key == Key.Up)
            {
                e.Handled = true;
                PrintHistory(ConsoleHistory.GetPreviousCommand());
            }
            else if (e.Key == Key.Down)
            {
                e.Handled = true;
                PrintHistory(ConsoleHistory.GetNextCommand());
            }
        }

        // ---- Avalonia: визуальное дерево (аналог InitializeComponent из ConsoleControl.Designer.cs) ----

        private void InitializeComponent(out ScrollViewer output, out Grid field, out Button logLink)
        {
            FontFamily = new FontFamily("Microsoft Sans Serif");
            FontSize = 11;
            var root = new Grid { RowDefinitions = new RowDefinitions("20,*"), ColumnDefinitions = new ColumnDefinitions("*,26") };
            var title = new Border
            {
                Background = Brushes.Gainsboro,
                Padding = new Thickness(3, 0),
                Child = new TextBlock { Text = Resources.ConsoleControl_headerName_text, VerticalAlignment = VerticalAlignment.Center }
            };
            Grid.SetColumnSpan(title, 2);
            root.Children.Add(title);

            field = new Grid { RowDefinitions = new RowDefinitions("Auto,*,Auto"), Background = Brush.Parse("#F0F0F0") };
            Grid.SetRow(field, 1);
            root.Children.Add(field);

            logLink = new Button
            {
                Classes = { "console-log" },
                HorizontalAlignment = HorizontalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Left,
                Padding = new Thickness(3, 0),
                MinHeight = 20
            };
            logLink.Click += Link_LinkClicked;
            field.Children.Add(logLink);

            var messages = new ItemsControl
            {
                ItemsSource = Messages,
                ItemTemplate = new FuncDataTemplate<ConsoleMessage>((message, _) => new SelectableTextBlock
                {
                    Text = message?.Text,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = message == null ? Brushes.Black : PropertiesPanelControl.ColorBrush(message.Color)
                })
            };
            output = new ScrollViewer { Content = messages, HorizontalScrollBarVisibility = Avalonia.Controls.Primitives.ScrollBarVisibility.Disabled };
            Grid.SetRow(output, 1);
            field.Children.Add(output);

            rtxbInput.Classes.Add("console-input");
            AutomationProperties.SetName(rtxbInput, "Команда консоли");
            Grid.SetRow(rtxbInput, 2);
            field.Children.Add(rtxbInput);
            rtxbInput.KeyDown += KeyDownEventHadler;

            var actions = new StackPanel { Background = Brushes.Gainsboro };
            actions.Children.Add(ActionButton("?", "btnDictionary", btnDictionary_Click));
            actions.Children.Add(ActionButton("×", "ClearAll", ClearAll_Click));
            actions.Children.Add(ActionButton("◐", "btnBackGroundInfo", btnBackGroundInfo_Click));
            actions.Children.Add(ActionButton("▶", "btnStartMacro", btnStartMacro_Click));
            Grid.SetRow(actions, 1);
            Grid.SetColumn(actions, 1);
            root.Children.Add(actions);
            Content = new Border { BorderBrush = Brushes.DarkGray, BorderThickness = new Thickness(1), Child = root };
        }

        private static Button ActionButton(string symbol, string name, EventHandler<RoutedEventArgs> handler)
        {
            var button = new Button { Content = symbol, Width = 24, Height = 24, Padding = new Thickness(2), Classes = { "console-action" } };
            AutomationProperties.SetName(button, name);
            ToolTip.SetTip(button, name);
            button.Click += handler;
            return button;
        }
    }
}
