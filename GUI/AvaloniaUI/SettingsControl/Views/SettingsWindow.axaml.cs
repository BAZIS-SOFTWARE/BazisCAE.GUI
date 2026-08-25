using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Platform.Storage;
using BazisGUI.AvaloniaUI.SettingsControl.ViewModels;
using System;
using System.Threading.Tasks;

namespace BazisGUI.AvaloniaUI.SettingsControl.Views
{
    /// <summary>
    /// Окно настроек. Содержит только поведение окна: перетаскивание, закрытие,
    /// открытие диалога выбора цвета и выбора файла решателя; вся логика — в
    /// <see cref="SettingsViewModel"/>.
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private bool isLightingCommittedSubscribed;

        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void OnTitleBarPointerPressed(object sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
                BeginMoveDrag(e);
        }

        private void OnCloseClick(object sender, RoutedEventArgs e) => Close();

        protected override void OnDataContextChanged(EventArgs e)
        {
            base.OnDataContextChanged(e);

            // Подписываемся один раз: фиксация положения источника света по отпусканию шарика.
            if (!isLightingCommittedSubscribed && DataContext is SettingsViewModel viewModel)
            {
                isLightingCommittedSubscribed = true;
                LightingBallControl.BallPositionCommitted += pos => viewModel.CommitLighterPosition(
                    pos.X, pos.Y, LightingBallControl.Bounds.Width, LightingBallControl.Bounds.Height);
            }
        }

        /// <summary>
        /// Открывает окно выбора цвета и возвращает выбранный цвет либо <c>null</c>, если выбор отменён.
        /// </summary>
        private async Task<Color?> ShowColorPicker(Color initialColor)
        {
            var dialog = new ColorPickerWindow(initialColor);
            await dialog.ShowDialog(this);
            return dialog.IsConfirmed ? dialog.SelectedColor : (Color?)null;
        }

        private async void OnPickBackgroundColorClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not SettingsViewModel viewModel)
                return;
            var color = await ShowColorPicker(viewModel.BackgroundColor);
            if (color.HasValue)
                viewModel.BackgroundColor = color.Value;
        }

        private async void OnPickSelectionObjectColorClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not SettingsViewModel viewModel)
                return;
            var color = await ShowColorPicker(viewModel.SelectionObjectColor);
            if (color.HasValue)
                viewModel.SelectionObjectColor = color.Value;
        }

        private async void OnPickSelectionGroupColorClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not SettingsViewModel viewModel)
                return;
            var color = await ShowColorPicker(viewModel.SelectionGroupColor);
            if (color.HasValue)
                viewModel.SelectionGroupColor = color.Value;
        }

        private async void OnPick3DElementColorClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not SettingsViewModel viewModel)
                return;
            var color = await ShowColorPicker(viewModel.Color3DElement);
            if (color.HasValue)
                viewModel.Color3DElement = color.Value;
        }

        private async void OnPick2DElementColorClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not SettingsViewModel viewModel)
                return;
            var color = await ShowColorPicker(viewModel.Color2DElement);
            if (color.HasValue)
                viewModel.Color2DElement = color.Value;
        }

        private async void OnPickNodeColorClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not SettingsViewModel viewModel)
                return;
            var color = await ShowColorPicker(viewModel.NodeColor);
            if (color.HasValue)
                viewModel.NodeColor = color.Value;
        }

        private async void OnBrowseSolverClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not SettingsViewModel viewModel)
                return;

            var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                AllowMultiple = false,
                FileTypeFilter = new[]
                {
                    new FilePickerFileType("Executable") { Patterns = new[] { "*.exe" } },
                    FilePickerFileTypes.All
                }
            });

            if (files.Count > 0)
                viewModel.SolverPath = files[0].TryGetLocalPath() ?? viewModel.SolverPath;
        }
    }
}
