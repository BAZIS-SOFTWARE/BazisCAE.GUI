using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using BazisGUI.AvaloniaUI.SettingsControl.ViewModels;

namespace BazisGUI.AvaloniaUI.SettingsControl.Views
{
    /// <summary>
    /// Окно выбора цвета: готовые цвета + компоненты RGB.
    /// </summary>
    /// <remarks>
    /// Заменяет стандартный диалог выбора цвета WinForms (<c>ColorDialog</c>),
    /// которого нет в Avalonia. Результат читается через <see cref="SelectedColor"/>,
    /// а признак подтверждения — через <see cref="IsConfirmed"/>.
    /// </remarks>
    public partial class ColorPickerWindow : Window
    {
        private readonly ColorPickerViewModel viewModel;

        /// <summary>
        /// Текущий выбранный цвет.
        /// </summary>
        public static readonly StyledProperty<Color> SelectedColorProperty =
            AvaloniaProperty.Register<ColorPickerWindow, Color>(nameof(SelectedColor));

        /// <summary>
        /// Выбранный цвет (заполняется при подтверждении).
        /// </summary>
        public Color SelectedColor
        {
            get => GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }

        /// <summary>
        /// Признак того, что пользователь подтвердил выбор (нажал OK).
        /// </summary>
        public bool IsConfirmed { get; private set; }

        public ColorPickerWindow(Color initialColor)
        {
            InitializeComponent();

            viewModel = new ColorPickerViewModel();
            viewModel.SetColor(initialColor);
            DataContext = viewModel;
            SelectedColor = initialColor;
        }

        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            SelectedColor = viewModel.SelectedColor;
            IsConfirmed = true;
            Close();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e) => Close();
    }
}
