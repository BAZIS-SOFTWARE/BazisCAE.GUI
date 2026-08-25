using BazisGUI.AvaloniaUI.Clip.Models;
using BazisGUI.AvaloniaUI.Clip.Services;
using BazisGUI.Scene;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Globalization;

namespace BazisGUI.AvaloniaUI.Clip.ViewModels
{
    /// <summary>
    /// ViewModel окна «Скрыть плоскостью».
    /// </summary>
    /// <remarks>
    /// Поведение повторяет WinForms-контрол <see cref="BazisGUI.Clip.ClipControl"/>:
    /// пресеты плоскости, компоненты нормали (A/B/C), смещение D, режимы отсечения,
    /// толщина слоя и drag-изменение значений по горизонтальному перетаскиванию.
    /// Все GL-операции выполняются через <see cref="IClipOperationService"/>.
    /// </remarks>
    public partial class ClipViewModel : ObservableObject
    {
        private readonly IClipOperationService operationService;
        private bool isUpdatingPlane;

        private static readonly double[] DeltaDSteps = { 1.0, 0.1, 0.01, 0.001 };

        /// <summary>Событие запроса закрытия окна.</summary>
        public event EventHandler CloseRequested;

        public ClipViewModel(IClipOperationService operationService)
        {
            this.operationService = operationService
                ?? throw new ArgumentNullException(nameof(operationService));
        }

        /// <summary>Включено ли отсечение (чекбокс «Включить»).</summary>
        [ObservableProperty]
        private bool isEnabled;

        /// <summary>Компонента X нормали плоскости (−1..1).</summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(AxisXText))]
        private double axisX;

        /// <summary>Компонента Y нормали плоскости (−1..1).</summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(AxisYText))]
        private double axisY;

        /// <summary>Компонента Z нормали плоскости (−1..1). По умолчанию −1.</summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(AxisZText))]
        private double axisZ = -1.0;

        /// <summary>Смещение плоскости D.</summary>
        [ObservableProperty]
        private double offsetD;

        /// <summary>Режим отсечения 3D-элементов.</summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsThicknessEnabled))]
        [NotifyPropertyChangedFor(nameof(CanCapture))]
        private ClipMode mode = ClipMode.Default;

        /// <summary>Толщина слоя для режима «Слой 3D».</summary>
        [ObservableProperty]
        private double layerThickness = 1.0;

        /// <summary>Индекс шага «Дельта D» (0: 1, 1: 0.1, 2: 0.01, 3: 0.001).</summary>
        [ObservableProperty]
        private int deltaDIndex = 2;

        /// <summary>Выбранный пресет плоскости.</summary>
        [ObservableProperty]
        private PlanePreset selectedPreset = PlanePreset.YX;

        public string AxisXText => "A: " + FormatValue(AxisX);
        public string AxisYText => "B: " + FormatValue(AxisY);
        public string AxisZText => "C: " + FormatValue(AxisZ);

        /// <summary>Поле толщины слоя доступно только в режиме «Слой 3D» при включённом отсечении.</summary>
        public bool IsThicknessEnabled => IsEnabled && Mode == ClipMode.Layered;

        /// <summary>Кнопка «Захват» доступна при включённом отсечении вне режима «Обычное».</summary>
        public bool CanCapture => IsEnabled && Mode != ClipMode.Default;

        /// <summary>Шаг изменения значений при перетаскивании.</summary>
        public double DeltaD => DeltaDSteps[Math.Clamp(DeltaDIndex, 0, DeltaDSteps.Length - 1)];

        partial void OnIsEnabledChanged(bool value)
        {
            operationService.SwitchOnOff(value, Mode);
            OnPropertyChanged(nameof(IsThicknessEnabled));
            OnPropertyChanged(nameof(CanCapture));
            if (value)
                PushPlane();
        }

        partial void OnAxisXChanged(double value)
        {
            OnPropertyChanged(nameof(AxisXText));
            OnPlaneValueChanged();
        }

        partial void OnAxisYChanged(double value)
        {
            OnPropertyChanged(nameof(AxisYText));
            OnPlaneValueChanged();
        }

        partial void OnAxisZChanged(double value)
        {
            OnPropertyChanged(nameof(AxisZText));
            OnPlaneValueChanged();
        }

        partial void OnOffsetDChanged(double value) => OnPlaneValueChanged();

        partial void OnModeChanged(ClipMode value)
        {
            operationService.ChangeClipMode(value);
            operationService.Redraw();
        }

        partial void OnLayerThicknessChanged(double value)
        {
            operationService.SetLayerThickness(value);
            operationService.Redraw();
        }

        partial void OnDeltaDIndexChanged(int value) => OnPropertyChanged(nameof(DeltaD));

        private void OnPlaneValueChanged()
        {
            if (isUpdatingPlane)
                return;
            PushPlane();
        }

        private void PushPlane()
        {
            operationService.SetPlane(AxisX, AxisY, AxisZ, OffsetD);
            operationService.Redraw();
        }

        /// <summary>Выбор пресета плоскости.</summary>
        [RelayCommand]
        private void SelectPreset(PlanePreset preset)
        {
            if (SelectedPreset == preset)
                return;

            SelectedPreset = preset;
            var (x, y, z) = GetPresetValues(preset);
            isUpdatingPlane = true;
            try
            {
                AxisX = x;
                AxisY = y;
                AxisZ = z;
            }
            finally
            {
                isUpdatingPlane = false;
            }
            PushPlane();
        }

        /// <summary>Смена режима отображения 3D-элементов.</summary>
        [RelayCommand]
        private void SelectMode(ClipMode mode) => Mode = mode;

        /// <summary>Сброс смещения D в ноль.</summary>
        [RelayCommand]
        private void ResetOffset() => OffsetD = 0;

        /// <summary>Захват данных (GL TransformFeedback).</summary>
        [RelayCommand]
        private void Capture() => operationService.Capture();

        /// <summary>
        /// Изменение смещения плоскости D при перетаскивании поля (вызывается из кода окна).
        /// </summary>
        public void AdjustOffset(double delta) => OffsetD += delta;

        /// <summary>
        /// Изменение толщины слоя при перетаскивании поля (вызывается из кода окна).
        /// </summary>
        public void AdjustThickness(double delta)
        {
            var value = LayerThickness + delta;
            if (value < 0.01)
                return;
            LayerThickness = value;
        }

        private static (double X, double Y, double Z) GetPresetValues(PlanePreset preset) => preset switch
        {
            PlanePreset.YZ => (1, 0, 0),
            PlanePreset.ZY => (-1, 0, 0),
            PlanePreset.ZX => (0, 1, 0),
            PlanePreset.XZ => (0, -1, 0),
            PlanePreset.XY => (0, 0, 1),
            PlanePreset.YX => (0, 0, -1),
            _ => (0, 0, -1)
        };

        private static string FormatValue(double value) => value.ToString("0.##", CultureInfo.InvariantCulture);
    }
}
