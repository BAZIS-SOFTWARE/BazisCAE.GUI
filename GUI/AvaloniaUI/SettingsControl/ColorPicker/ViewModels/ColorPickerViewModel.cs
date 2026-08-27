using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;

namespace BazisGUI.AvaloniaUI.SettingsControl.ViewModels
{
    /// <summary>
    /// ViewModel окна выбора цвета: компоненты RGB и набор готовых цветов.
    /// </summary>
    public partial class ColorPickerViewModel : ObservableObject
    {
        /// <summary>Красная компонента (0..255).</summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SelectedColor))]
        [NotifyPropertyChangedFor(nameof(SelectedColorBrush))]
        private int red;

        /// <summary>Зелёная компонента (0..255).</summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SelectedColor))]
        [NotifyPropertyChangedFor(nameof(SelectedColorBrush))]
        private int green;

        /// <summary>Синяя компонента (0..255).</summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SelectedColor))]
        [NotifyPropertyChangedFor(nameof(SelectedColorBrush))]
        private int blue;

        /// <summary>Набор готовых цветов для быстрого выбора.</summary>
        public IReadOnlyList<SolidColorBrush> PresetColors { get; } = CreatePresetColors();

        /// <summary>Текущий выбранный цвет (для предпросмотра).</summary>
        public Color SelectedColor => Color.FromRgb(Clamp(Red), Clamp(Green), Clamp(Blue));

        /// <summary>Кисть текущего выбранного цвета для предпросмотра.</summary>
        public SolidColorBrush SelectedColorBrush => new(SelectedColor);

        /// <summary>
        /// Устанавливает текущий цвет.
        /// </summary>
        public void SetColor(Color color)
        {
            Red = color.R;
            Green = color.G;
            Blue = color.B;
        }

        /// <summary>
        /// Выбор готового цвета.
        /// </summary>
        [RelayCommand]
        private void SelectPreset(SolidColorBrush brush) => SetColor(brush.Color);

        private static byte Clamp(int value) => (byte)Math.Clamp(value, 0, 255);

        private static IReadOnlyList<SolidColorBrush> CreatePresetColors() => new[]
        {
            new SolidColorBrush(Colors.White), new SolidColorBrush(Colors.Silver), new SolidColorBrush(Colors.Gray), new SolidColorBrush(Colors.Black),
            new SolidColorBrush(Colors.Red), new SolidColorBrush(Colors.Orange), new SolidColorBrush(Colors.Yellow), new SolidColorBrush(Colors.Green),
            new SolidColorBrush(Colors.Cyan), new SolidColorBrush(Colors.Blue), new SolidColorBrush(Colors.Magenta), new SolidColorBrush(Colors.Purple),
            new SolidColorBrush(Colors.Maroon), new SolidColorBrush(Colors.Olive), new SolidColorBrush(Colors.Lime), new SolidColorBrush(Colors.Teal),
            new SolidColorBrush(Colors.Navy), new SolidColorBrush(Colors.Brown), new SolidColorBrush(Colors.Gold), new SolidColorBrush(Colors.Pink),
            new SolidColorBrush(Colors.LightGray), new SolidColorBrush(Colors.DarkGray), new SolidColorBrush(Colors.DarkRed), new SolidColorBrush(Colors.DarkGreen),
            new SolidColorBrush(Colors.DarkBlue), new SolidColorBrush(Colors.LightBlue), new SolidColorBrush(Colors.LightGreen), new SolidColorBrush(Colors.Khaki),
            new SolidColorBrush(Colors.Coral), new SolidColorBrush(Colors.Beige), new SolidColorBrush(Colors.Lavender), new SolidColorBrush(Colors.Salmon)
        };
    }
}
