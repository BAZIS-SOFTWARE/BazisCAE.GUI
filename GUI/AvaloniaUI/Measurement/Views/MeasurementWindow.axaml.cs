using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace BazisGUI.AvaloniaUI.Measurement.Views
{
    /// <summary>
    /// Окно измерений. Содержит только поведение окна (перетаскивание и закрытие);
    /// вся логика вынесена в <see cref="ViewModels.MeasurementViewModel"/>.
    /// </summary>
    public partial class MeasurementWindow : Window
    {
        public MeasurementWindow()
        {
            InitializeComponent();
        }

        private void OnTitleBarPointerPressed(object sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
                BeginMoveDrag(e);
        }

        private void OnCloseClick(object sender, RoutedEventArgs e) => Close();
    }
}
