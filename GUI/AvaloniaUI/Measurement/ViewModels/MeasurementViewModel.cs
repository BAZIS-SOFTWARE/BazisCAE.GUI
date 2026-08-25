using BazisGUI.AvaloniaUI.Measurement.Models;
using BazisGUI.AvaloniaUI.Measurement.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace BazisGUI.AvaloniaUI.Measurement.ViewModels
{
    /// <summary>
    /// ViewModel окна измерений.
    /// </summary>
    /// <remarks>
    /// Поведение повторяет WinForms-контрол <see cref="BazisGUI.Measurement.MeasuringSet"/>:
    /// переключатели задают вид измерения и сразу готовят сцену к выбору объектов,
    /// а для режима «Расстояние» доступен комбобокс с подвидом измерения.
    /// </remarks>
    public partial class MeasurementViewModel : ObservableObject
    {
        private readonly IMeasurementOperationService operationService;

        /// <summary>
        /// Событие запроса закрытия окна (подписывается окном через сервис).
        /// </summary>
        public event EventHandler CloseRequested;

        public MeasurementViewModel(IMeasurementOperationService operationService)
        {
            this.operationService = operationService
                ?? throw new ArgumentNullException(nameof(operationService));
        }

        /// <summary>
        /// Выбранный вид измерения с учётом подвида из комбобокса для режима «Расстояние».
        /// </summary>
        [ObservableProperty]
        private MeasureKind selectedKind = MeasureKind.DistancePointToPoint;

        /// <summary>
        /// Выбран ли переключатель «Расстояние».
        /// </summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsDistanceMode))]
        private bool isDistanceSelected = true;

        /// <summary>
        /// Выбран ли переключатель «Путь».
        /// </summary>
        [ObservableProperty]
        private bool isPathSelected;

        /// <summary>
        /// Выбран ли переключатель «Площадь».
        /// </summary>
        [ObservableProperty]
        private bool isAreaSelected;

        /// <summary>
        /// Выбран ли переключатель «Объём».
        /// </summary>
        [ObservableProperty]
        private bool isVolumeSelected;

        /// <summary>
        /// Индекс выбранного элемента комбобокса для режима «Расстояние»:
        /// 0 — между двумя точками, 1 — между точкой и плоскостью.
        /// </summary>
        [ObservableProperty]
        private int distanceKindIndex;

        /// <summary>
        /// Доступен ли комбобокс подвидов (только для режима «Расстояние»).
        /// </summary>
        public bool IsDistanceMode => IsDistanceSelected;

        partial void OnIsDistanceSelectedChanged(bool value)
        {
            if (value)
            {
                DistanceKindIndex = 0;
                SelectedKind = MeasureKind.DistancePointToPoint;
                operationService.PrepareObjects(SelectedKind);
            }
        }

        partial void OnIsPathSelectedChanged(bool value)
        {
            if (value)
            {
                SelectedKind = MeasureKind.Path;
                operationService.PrepareObjects(SelectedKind);
            }
        }

        partial void OnIsAreaSelectedChanged(bool value)
        {
            if (value)
            {
                SelectedKind = MeasureKind.Square;
                operationService.PrepareObjects(SelectedKind);
            }
        }

        partial void OnIsVolumeSelectedChanged(bool value)
        {
            if (value)
            {
                SelectedKind = MeasureKind.Volume;
                operationService.PrepareObjects(SelectedKind);
            }
        }

        partial void OnDistanceKindIndexChanged(int value)
        {
            // Подвид расстояния учитывается только пока активен режим «Расстояние».
            if (!IsDistanceSelected)
                return;

            SelectedKind = value == 0
                ? MeasureKind.DistancePointToPoint
                : MeasureKind.DistancePointToPlane;
        }

        /// <summary>
        /// Команда кнопки «Измерить»: выполняет измерение выбранного вида.
        /// Окно при этом не закрывается, как и в WinForms-версии.
        /// </summary>
        [RelayCommand]
        private void Measure()
        {
            operationService.Measure(SelectedKind);
        }
    }
}
