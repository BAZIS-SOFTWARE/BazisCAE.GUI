using Avalonia;
using Avalonia.Automation;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Styling;
using BazisAvaloniaGUI.Console;
using BazisAvaloniaGUI.Localization;
using BazisAvaloniaGUI.Navigator;
using BazisAvaloniaGUI.Properties;
using BazisAvaloniaGUI.Scene;
using System;
using System.Resources;

namespace BazisAvaloniaGUI.Shell
{
    internal partial class MainWindow
    {
        // Аналог ComponentResourceManager(typeof(BaseForm)): тексты перенесены из BaseForm.resx.
        private static readonly ResourceManager resources = new("BazisAvaloniaGUI.Shell.MainWindow", typeof(MainWindow).Assembly);

        private Menu menuStrip;
        private MenuItem файлToolStripMenuItem;
        private MenuItem создатьToolStripMenuItem;
        private MenuItem открытьToolStripMenuItem;
        private MenuItem добавитьToolStripMenuItem;
        private MenuItem сохранитьToolStripMenuItem;
        private MenuItem сохранитькакToolStripMenuItem;
        private MenuItem выходToolStripMenuItem;
        private MenuItem viewMenuItem;
        private MenuItem toolStripMenuItem2;
        private MenuItem toolStripMenuItem3;
        private MenuItem геометрияToolStripMenuItem;
        private MenuItem создатьТочкуToolStripMenuItem;
        private MenuItem создатьЛиниюToolStripMenuItem;
        private MenuItem создатьПлоскостьToolStripMenuItem;
        private MenuItem создатьОбъемToolStripMenuItem;
        private MenuItem addChamferToolStripMenuItem;
        private MenuItem сеткаToolStripMenuItem;
        private MenuItem загрузитьgeoToolStripMenuItem;
        private MenuItem сформироватьgeoToolStripMenuItem;
        private MenuItem dToolStripMenuItem;
        private MenuItem наToolStripMenuItem;
        private MenuItem dToolStripMenuItem1;
        private MenuItem уплотнитьToolStripMenuItem;
        private MenuItem наПоверхности3DToolStripMenuItem;
        private MenuItem наПоверхностиГеометрииToolStripMenuItem;
        private MenuItem квадратизацияСуществующейToolStripMenuItem;
        private MenuItem dToolStripMenuItem2;
        private MenuItem dataBasesMenuItem;
        private MenuItem материалыMenuItem;
        private MenuItem функцииMenuItem;
        private MenuItem tasksMenuItem;
        private MenuItem создатьToolStripMenuItem1;
        private MenuItem мастерToolStripMenuItem;
        private MenuItem загрузитьМастерToolStripMenuItem;
        private MenuItem показатьНаДиаграммеToolStripMenuItem;
        private MenuItem расчетыToolStripMenuItem;
        private MenuItem результатыMenuItem;
        private MenuItem инструментыToolStripMenuItem;
        private MenuItem настройкиToolStripMenuItem;
        private MenuItem справкаToolStripMenuItem;
        private MenuItem содержаниеToolStripMenuItem;
        private MenuItem опрограммеToolStripMenuItem;
        private MenuItem лицензияToolStripMenuItem;
        private MenuItem сведенияMenuItem;

        private SceneView scene;
        private NavigatorControl navigator;
        private PropertiesPanelControl propertiesPanel;
        private ConsoleControl console;
        private TextBlock lblStatus;
        private TextBlock lblVersion;

        private Grid splitContainer3;
        private Grid splitContainer3Panel1;
        private Grid cntrНавигатор;
        private GridSplitter splitContainer3Splitter;
        private Grid splitContainer2;
        private GridSplitter splitContainer2Splitter;
        private GridLength panel1Width;
        private GridLength panel2Height;

        /// <summary>Аналог splitContainer3.Panel1Collapsed (навигатор и свойства).</summary>
        private bool Panel1Collapsed
        {
            get => !splitContainer3Panel1.IsVisible;
            set
            {
                if (value == Panel1Collapsed) return;
                if (value) panel1Width = splitContainer3.ColumnDefinitions[0].Width;
                splitContainer3Panel1.IsVisible = splitContainer3Splitter.IsVisible = !value;
                splitContainer3.ColumnDefinitions[0].Width = value ? new GridLength(0) : panel1Width;
                splitContainer3.ColumnDefinitions[1].Width = new GridLength(value ? 0 : 8);
            }
        }

        /// <summary>Аналог splitContainer2.Panel2Collapsed (консоль).</summary>
        private bool Panel2Collapsed
        {
            get => !console.IsVisible;
            set
            {
                if (value == Panel2Collapsed) return;
                if (value) panel2Height = splitContainer2.RowDefinitions[2].Height;
                console.IsVisible = splitContainer2Splitter.IsVisible = !value;
                splitContainer2.RowDefinitions[1].Height = new GridLength(value ? 0 : 8);
                splitContainer2.RowDefinitions[2].Height = value ? new GridLength(0) : panel2Height;
            }
        }

        private void InitializeComponent()
        {
            scene = new SceneView();
            navigator = new NavigatorControl();
            propertiesPanel = new PropertiesPanelControl();
            console = new ConsoleControl();

            Width = 942;
            Height = 625;
            MinWidth = 415;
            MinHeight = 320;
            WindowState = WindowState.Maximized;
            Background = Brushes.White;
            RequestedThemeVariant = ThemeVariant.Light;
            FontFamily = new FontFamily("Microsoft Sans Serif");
            FontSize = 11; // BaseForm: 8.25 pt at 96 DPI
            Foreground = Brushes.Black;
            Title = resources.GetString("$this.Text");

            // menuStrip
            создатьToolStripMenuItem = Item("создатьToolStripMenuItem", создатьToolStripMenuItem_Click);
            открытьToolStripMenuItem = Item("открытьToolStripMenuItem", открытьToolStripMenuItem_Click);
            добавитьToolStripMenuItem = Item("добавитьToolStripMenuItem", добавитьСеткуToolStripMenuItem_Click);
            сохранитьToolStripMenuItem = Item("сохранитьToolStripMenuItem", сохранитьToolStripMenuItem_Click);
            сохранитькакToolStripMenuItem = Item("сохранитькакToolStripMenuItem", сохранитькакToolStripMenuItem_Click);
            выходToolStripMenuItem = Item("выходToolStripMenuItem", выходToolStripMenuItem_Click);
            создатьToolStripMenuItem.InputGesture = new KeyGesture(Key.N, KeyModifiers.Control);
            открытьToolStripMenuItem.InputGesture = new KeyGesture(Key.O, KeyModifiers.Control);
            сохранитьToolStripMenuItem.InputGesture = new KeyGesture(Key.S, KeyModifiers.Control);
            файлToolStripMenuItem = Item("файлToolStripMenuItem", null, создатьToolStripMenuItem, открытьToolStripMenuItem,
                добавитьToolStripMenuItem, new Separator(), сохранитьToolStripMenuItem, сохранитькакToolStripMenuItem,
                new Separator(), new Separator(), выходToolStripMenuItem);

            toolStripMenuItem2 = Item("toolStripMenuItem2", toolStripMenuItem2_Click);
            toolStripMenuItem3 = Item("toolStripMenuItem3", toolStripMenuItem3_Click);
            viewMenuItem = Item("viewMenuItem", null, toolStripMenuItem2, toolStripMenuItem3);

            // В WinForms у пунктов создания геометрии обработчики не назначены.
            создатьТочкуToolStripMenuItem = Item("создатьТочкуToolStripMenuItem", null);
            создатьЛиниюToolStripMenuItem = Item("создатьЛиниюToolStripMenuItem", null);
            создатьПлоскостьToolStripMenuItem = Item("создатьПлоскостьToolStripMenuItem", null);
            создатьОбъемToolStripMenuItem = Item("создатьОбъемToolStripMenuItem", null);
            addChamferToolStripMenuItem = Item("addChamferToolStripMenuItem", null);
            addChamferToolStripMenuItem.IsEnabled = false; // фаска в Avalonia-оболочке ещё не перенесена
            геометрияToolStripMenuItem = Item("геометрияToolStripMenuItem", null, создатьТочкуToolStripMenuItem,
                создатьЛиниюToolStripMenuItem, создатьПлоскостьToolStripMenuItem, создатьОбъемToolStripMenuItem,
                addChamferToolStripMenuItem);
            геометрияToolStripMenuItem.IsEnabled = false;

            загрузитьgeoToolStripMenuItem = Item("загрузитьgeoToolStripMenuItem", загрузитьgeoToolStripMenuItem_Click);
            сформироватьgeoToolStripMenuItem = Item("сформироватьgeoToolStripMenuItem", сформироватьgeoToolStripMenuItem_Click);
            наToolStripMenuItem = Item("наToolStripMenuItem", наПоверхности2DToolStripMenuItem_Click);
            dToolStripMenuItem = Item("dToolStripMenuItem", null, наToolStripMenuItem);
            уплотнитьToolStripMenuItem = Item("уплотнитьToolStripMenuItem", уплотнитьToolStripMenuItem_Click);
            уплотнитьToolStripMenuItem.IsEnabled = false;
            наПоверхности3DToolStripMenuItem = Item("наПоверхности3DToolStripMenuItem", наПоверхности3DToolStripMenuItem_Click);
            наПоверхностиГеометрииToolStripMenuItem = Item("наПоверхностиГеометрииToolStripMenuItem", наПоверхностиГеометрииToolStripMenuItem_Click);
            квадратизацияСуществующейToolStripMenuItem = Item("квадратизацияСуществующейToolStripMenuItem", квадратизацияСуществующейToolStripMenuItem_Click);
            квадратизацияСуществующейToolStripMenuItem.IsEnabled = false;
            dToolStripMenuItem1 = Item("dToolStripMenuItem1", null, уплотнитьToolStripMenuItem, наПоверхности3DToolStripMenuItem,
                наПоверхностиГеометрииToolStripMenuItem, квадратизацияСуществующейToolStripMenuItem);
            dToolStripMenuItem2 = Item("dToolStripMenuItem2", создать3DСеткуToolStripMenuItem_Click);
            сеткаToolStripMenuItem = Item("сеткаToolStripMenuItem", null, загрузитьgeoToolStripMenuItem, сформироватьgeoToolStripMenuItem,
                dToolStripMenuItem, dToolStripMenuItem1, dToolStripMenuItem2);
            сеткаToolStripMenuItem.IsEnabled = false;

            материалыMenuItem = Item("материалыMenuItem", материалыMenuItem_Click);
            функцииMenuItem = Item("функцииMenuItem", функцииMenuItem_Click);
            dataBasesMenuItem = Item("dataBasesMenuItem", null, материалыMenuItem, функцииMenuItem);
            dataBasesMenuItem.IsEnabled = false;

            создатьToolStripMenuItem1 = Item("создатьToolStripMenuItem1", создатьЗадачуToolStripMenuItem_Click);
            загрузитьМастерToolStripMenuItem = Item("загрузитьМастерToolStripMenuItem", null);
            загрузитьМастерToolStripMenuItem.IsEnabled = false; // мастера в Avalonia-оболочке ещё не перенесены
            мастерToolStripMenuItem = Item("мастерToolStripMenuItem", null, new Separator(), загрузитьМастерToolStripMenuItem, new Separator());
            показатьНаДиаграммеToolStripMenuItem = Item("показатьНаДиаграммеToolStripMenuItem", null);
            показатьНаДиаграммеToolStripMenuItem.IsEnabled = false; // диаграмма Ганта ещё не перенесена
            tasksMenuItem = Item("tasksMenuItem", null, создатьToolStripMenuItem1, мастерToolStripMenuItem, показатьНаДиаграммеToolStripMenuItem);
            tasksMenuItem.IsEnabled = false;

            // Расчёты, результаты, инструменты, настройки и лицензия в Avalonia ещё не перенесены.
            расчетыToolStripMenuItem = Item("расчетыToolStripMenuItem", null,
                Item("открытьИнструкцииToolStripMenuItem", null), Item("сформироватьИнструкцииToolStripMenuItem", null),
                Item("запуститьToolStripMenuItem", null), Item("остановитьToolStripMenuItem", null));
            расчетыToolStripMenuItem.IsEnabled = false;
            результатыMenuItem = Item("результатыMenuItem", null,
                Item("открытьToolStripMenuItem1", null), Item("объединитьToolStripMenuItem", null),
                Item("построитьГрафикToolStripMenuItem", null), Item("построитьДиаграммуToolStripMenuItem", null),
                Item("создатьАнимациюToolStripMenuItem", null), Item("экспортироватьРезультатыToolStripMenuItem", null),
                Item("toolStripMenuItem4", null));
            результатыMenuItem.IsEnabled = false;
            инструментыToolStripMenuItem = Item("инструментыToolStripMenuItem", null,
                Item("измеритьToolStripMenuItem", null), Item("скрытьПлоскостьюToolStripMenuItem", null),
                Item("рассечьПлоскостьюToolStripMenuItem", null));
            инструментыToolStripMenuItem.IsEnabled = false;
            настройкиToolStripMenuItem = Item("настройкиToolStripMenuItem", null);
            настройкиToolStripMenuItem.IsEnabled = false;

            содержаниеToolStripMenuItem = Item("содержаниеToolStripMenuItem", содержаниеToolStripMenuItem_Click);
            опрограммеToolStripMenuItem = Item("опрограммеToolStripMenuItem", опрограммеToolStripMenuItem_Click);
            справкаToolStripMenuItem = Item("справкаToolStripMenuItem", null, содержаниеToolStripMenuItem, опрограммеToolStripMenuItem);
            сведенияMenuItem = Item("сведенияMenuItem", null);
            сведенияMenuItem.IsEnabled = false;
            лицензияToolStripMenuItem = Item("лицензияToolStripMenuItem", null, сведенияMenuItem);

            menuStrip = new Menu
            {
                Background = Brushes.Gainsboro,
                Height = 24,
                FontFamily = new FontFamily("Segoe UI"),
                FontSize = 11,
                ItemsSource = new[]
                {
                    файлToolStripMenuItem, viewMenuItem, геометрияToolStripMenuItem, сеткаToolStripMenuItem, dataBasesMenuItem,
                    tasksMenuItem, расчетыToolStripMenuItem, результатыMenuItem, инструментыToolStripMenuItem,
                    настройкиToolStripMenuItem, справкаToolStripMenuItem, лицензияToolStripMenuItem
                }
            };

            // Компоновка: splitContainer3 (навигатор | сцена+консоль), splitContainer2 (сцена / консоль).
            var root = new Grid { RowDefinitions = new RowDefinitions("Auto,*,Auto") };
            root.Children.Add(menuStrip);

            splitContainer3 = new Grid { ColumnDefinitions = new ColumnDefinitions("304,8,*"), MinHeight = 0, Margin = new Thickness(5) };
            Grid.SetRow(splitContainer3, 1);
            root.Children.Add(splitContainer3);

            cntrНавигатор = new Grid { RowDefinitions = new RowDefinitions("298*,8,253*") };
            cntrНавигатор.Children.Add(CreatePinnedPage(Resources.NavigatorControl_headerName_text, navigator));
            var navigatorSplitter = new GridSplitter { Height = 8, ResizeDirection = GridResizeDirection.Rows, Background = Brushes.Gainsboro };
            Grid.SetRow(navigatorSplitter, 1);
            cntrНавигатор.Children.Add(navigatorSplitter);
            var propertiesPage = CreatePinnedPage(Resources.PropertiesPanelControl_headerName_text, propertiesPanel);
            Grid.SetRow(propertiesPage, 2);
            cntrНавигатор.Children.Add(propertiesPage);
            splitContainer3Panel1 = new Grid { MinWidth = 150 };
            splitContainer3.Children.Add(splitContainer3Panel1);

            splitContainer3Splitter = new GridSplitter { Width = 8, ResizeDirection = GridResizeDirection.Columns, Background = Brushes.Gainsboro };
            Grid.SetColumn(splitContainer3Splitter, 1);
            splitContainer3.Children.Add(splitContainer3Splitter);

            splitContainer2 = new Grid { RowDefinitions = new RowDefinitions("*,8,140"), MinWidth = 0 };
            Grid.SetColumn(splitContainer2, 2);
            splitContainer3.Children.Add(splitContainer2);

            // splitContainer2.Panel1: место сцены. Сама сцена и её кнопки (btnSelect, виды, вписывание и т.д.) — SceneView.
            splitContainer2.Children.Add(scene);

            splitContainer2Splitter = new GridSplitter { Height = 8, ResizeDirection = GridResizeDirection.Rows, Background = Brushes.Gainsboro };
            Grid.SetRow(splitContainer2Splitter, 1);
            splitContainer2.Children.Add(splitContainer2Splitter);
            Grid.SetRow(console, 2);
            splitContainer2.Children.Add(console);

            lblStatus = new TextBlock { Text = resources.GetString("lblStatus.Text"), VerticalAlignment = VerticalAlignment.Center, TextTrimming = TextTrimming.CharacterEllipsis };
            lblVersion = new TextBlock { VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(12, 0, 0, 0) };
            var statusStrip = new DockPanel { LastChildFill = true };
            DockPanel.SetDock(lblVersion, Dock.Right);
            statusStrip.Children.Add(lblVersion);
            statusStrip.Children.Add(lblStatus);
            var statusBorder = new Border { Background = Brushes.Gainsboro, Height = 32, Padding = new Thickness(5, 3), Child = statusStrip };
            Grid.SetRow(statusBorder, 2);
            root.Children.Add(statusBorder);
            Content = root;

            console.ConsoleCommandEnteredEvent += ExecuteCommand;
            console.CommandsListRequestedEvent += PrintAllCommands;

            navigator.RemoveAllConditionsEvent += navigator_RemoveAllConditionsEvent;
            navigator.DelAllGroupsEvent += navigator_DelAllGroupsEvent;
            navigator.ShowAllGroupsEvent += navigator_ShowAllGroupsEvent;
            navigator.HideAllGroupsEvent += navigator_HideAllGroupsEvent;
            navigator.ChangeAllGeoViewStateEvent += navigator_ChangeAllObjectsViewStateEvent;
            navigator.DelAllGeoEvent += navigator_DelAllObjectsEvent;
            navigator.DelAllMeshEvent += navigator_DelAllObjectsEvent;
            navigator.ChangeAllMeshViewStateEvent += navigator_ChangeAllObjectsViewStateEvent;
            navigator.ShowSetEvent += navigator_ShowSetEvent;
            navigator.HideSetEvent += navigator_HideSetEvent;
            navigator.DelSetEvent += navigator_DelSetEvent;
            navigator.SelectSetEvent += navigator_SelectSetEvent;
            navigator.GetSetsInfoEvent += navigator_GetSetsInfoEvent;
            navigator.SelectGroupEvent += navigator_SelectGroupEvent;
            navigator.DelGroupEvent += navigator_DelGroupEvent;
            navigator.HideGroupEvent += navigator_HideGroupEvent;
            navigator.ShowGroupEvent += navigator_ShowGroupEvent;
            navigator.EditGroupEvent += EditGroup;
            navigator.InfoGroupEvent += navigator_InfoGroupEvent;
            navigator.GetObjectsInfoEvent += navigator_GetObjectsInfoEvent;
            navigator.SelectObjectEvent += navigator_SelectObjectEvent;
            navigator.DelObjectEvent += navigator_DelObjectEvent;
            navigator.ShowObjectEvent += navigator_ShowObjectEvent;
            navigator.HideObjectEvent += navigator_HideObjectEvent;
            navigator.SelectCondEvent += Navigator_SelectCondEvent;
            navigator.SelectTaskEvent += navigator_SelectTaskEvent;
            navigator.SelectGeoEvent += navigator_SelectGeoEvent;
            navigator.SelectMeshEvent += navigator_SelectMeshEvent;
            navigator.SelectGeneralInfoEvent += navigator_SelectGeneralInfoEvent;
            navigator.DelCondEvent += navigator_DelCondEvent;
            // HideResults/RemoveResults/SelectResults/SelectComp(s)/SelectTime/SelectResult/GetResultInfo —
            // результаты и расчёты в Avalonia ещё не перенесены.

            propertiesPanel.PropertyUpdateEvent += PropertiesPanel_OnPropertyUpdate;

            scene.SelectionApplied += scene_SelectionApplied;
            scene.ProjectDisplayFailed += (sender, ex) => console.PrintInfo(ex.Message, System.Drawing.Color.Red);

            Opened += BaseForm_Load;
            Closing += OnClosingForm;
            AddHandler(KeyDownEvent, (sender, e) => BaseForm_KeyDown(sender, e), RoutingStrategies.Tunnel);
        }

        private static MenuItem Item(string name, EventHandler<RoutedEventArgs> click, params object[] items)
        {
            // Avalonia использует "_" вместо "&" для клавиши доступа.
            var item = new MenuItem { Name = name, Header = (resources.GetString(name + ".Text") ?? name).Replace('&', '_') };
            if (items.Length > 0)
                item.ItemsSource = items;
            if (click != null)
                item.Click += click;
            return item;
        }

        private static Border CreatePinnedPage(string title, Control content)
        {
            var layout = new Grid { RowDefinitions = new RowDefinitions("20,*") };
            var header = new Border
            {
                Background = Brushes.Gainsboro,
                BorderBrush = Brush.Parse("#A0A0A0"),
                BorderThickness = new Thickness(0, 0, 0, 1),
                Child = new TextBlock
                {
                    Text = title,
                    Foreground = Brushes.Black,
                    Margin = new Thickness(14, 0, 0, 0),
                    VerticalAlignment = VerticalAlignment.Center
                }
            };
            layout.Children.Add(header);
            Grid.SetRow(content, 1);
            layout.Children.Add(content);
            return new Border
            {
                BorderBrush = Brush.Parse("#7A7A7A"),
                BorderThickness = new Thickness(1),
                Background = Brush.Parse("#F0F0F0"),
                Child = layout
            };
        }

    }
}
