using BazisGUI.AvaloniaUI.SettingsControl.Models;
using BazisGUI.AvaloniaUI.SettingsControl.Services;
using BazisGUI.Scene.Interfaces;
using BazisGUI.SettingsControls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace BazisGUI.AvaloniaUI.SettingsControl.ViewModels
{
    /// <summary>
    /// ViewModel окна настроек.
    /// </summary>
    /// <remarks>
    /// Поведение повторяет WinForms-контрол <see cref="BazisGUI.SettingsControls.SettingsControl"/>:
    /// четыре вкладки (Сцена, Объекты, Решатель, Язык), выбор цветов, освещение,
    /// прозрачность, проекция и язык. Изменения применяются к сцене через
    /// <see cref="ISettingsOperationService"/>.
    /// </remarks>
    public partial class SettingsViewModel : ObservableObject
    {
        private readonly ISettingsOperationService operationService;

        // При загрузке начальных значений из конфигурации вызовы сервиса подавляются,
        // чтобы при открытии окна не записывалась конфигурация и не перерисовывалась сцена.
        private bool isApplyingConfig;

        /// <summary>Доступные языки интерфейса.</summary>
        public IReadOnlyList<LanguageOption> Languages { get; } = LanguageOption.All;

        public SettingsViewModel(ISettingsOperationService operationService, SettingsConfig? config)
        {
            this.operationService = operationService
                ?? throw new ArgumentNullException(nameof(operationService));

            if (config != null)
                ApplyConfig(config);
        }

        /// <summary>Цвет заднего фона сцены.</summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(BackgroundColorBrush))]
        private Color backgroundColor;

        /// <summary>Цвет выделения объектов.</summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SelectionObjectColorBrush))]
        private Color selectionObjectColor;

        /// <summary>Цвет выделения групп.</summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SelectionGroupColorBrush))]
        private Color selectionGroupColor;

        /// <summary>Цвет узлов.</summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NodeColorBrush))]
        private Color nodeColor;

        /// <summary>Цвет 3D-элементов (визуально, в конфигурацию не сохраняется).</summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Color3DElementBrush))]
        private Color color3DElement;

        /// <summary>Цвет 2D-элементов (визуально, в конфигурацию не сохраняется).</summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Color2DElementBrush))]
        private Color color2DElement;

        /// <summary>Путь до решателя.</summary>
        [ObservableProperty]
        private string solverPath = "?";

        /// <summary>Включено ли освещение.</summary>
        [ObservableProperty]
        private bool isLighting;

        /// <summary>Интенсивность освещения (0..100).</summary>
        [ObservableProperty]
        private int lightingIntensity;

        /// <summary>Положение источника света (в координатах контрола выбора света).</summary>
        [ObservableProperty]
        private Avalonia.Point lighterPosition;

        /// <summary>Включена ли прозрачность.</summary>
        [ObservableProperty]
        private bool isTransparency;

        /// <summary>Значение прозрачности (0..100).</summary>
        [ObservableProperty]
        private int transparencyValue;

        /// <summary>Показывать ли внутренние рёбра элементов.</summary>
        [ObservableProperty]
        private bool isBackRibbers;

        /// <summary>Включена ли ортографическая проекция.</summary>
        [ObservableProperty]
        private bool isOrtoProjection;

        /// <summary>Выбранный язык интерфейса.</summary>
        [ObservableProperty]
        private LanguageOption selectedLanguage = LanguageOption.English;

        /// <summary>Кисть цвета фона для привязки.</summary>
        public SolidColorBrush BackgroundColorBrush => new(BackgroundColor);

        /// <summary>Кисть цвета выделения объектов для привязки.</summary>
        public SolidColorBrush SelectionObjectColorBrush => new(SelectionObjectColor);

        /// <summary>Кисть цвета выделения групп для привязки.</summary>
        public SolidColorBrush SelectionGroupColorBrush => new(SelectionGroupColor);

        /// <summary>Кисть цвета узлов для привязки.</summary>
        public SolidColorBrush NodeColorBrush => new(NodeColor);

        /// <summary>Кисть цвета 3D-элементов для привязки.</summary>
        public SolidColorBrush Color3DElementBrush => new(Color3DElement);

        /// <summary>Кисть цвета 2D-элементов для привязки.</summary>
        public SolidColorBrush Color2DElementBrush => new(Color2DElement);

        partial void OnBackgroundColorChanged(Color value)
        {
            if (isApplyingConfig)
                return;
            operationService.SetBackgroundColor(ToDrawing(value));
        }

        partial void OnSelectionObjectColorChanged(Color value)
        {
            if (isApplyingConfig)
                return;
            operationService.SetSelectionObjectColor(ToDrawing(value));
        }

        partial void OnSelectionGroupColorChanged(Color value)
        {
            if (isApplyingConfig)
                return;
            operationService.SetSelectionGroupColor(ToDrawing(value));
        }

        partial void OnNodeColorChanged(Color value)
        {
            if (isApplyingConfig)
                return;
            operationService.SetNodeColor(ToDrawing(value));
        }

        // Цвета 3D/2D-элементов в WinForms-версии не применялись к сцене — оставляем визуальными.

        partial void OnSolverPathChanged(string value)
        {
            if (isApplyingConfig)
                return;
            operationService.SetSolverPath(value);
        }

        partial void OnIsLightingChanged(bool value)
        {
            if (isApplyingConfig)
                return;
            operationService.SetLighting(value);
        }

        partial void OnLightingIntensityChanged(int value)
        {
            if (isApplyingConfig)
                return;
            operationService.SetLightingIntensity(value);
        }

        // Положение источника света меняется только при отпускании шарика (см. CommitLighterPosition).

        partial void OnIsTransparencyChanged(bool value)
        {
            if (isApplyingConfig)
                return;
            operationService.SetTransparency(value);
        }

        partial void OnTransparencyValueChanged(int value)
        {
            if (isApplyingConfig)
                return;
            operationService.SetTransparencyValue(value);
        }

        // «Внутренние рёбра» в WinForms-версии не имели реализации — оставляем без действия.

        partial void OnIsOrtoProjectionChanged(bool value)
        {
            if (isApplyingConfig)
                return;
            operationService.SetOrtoProjection(value);
        }

        partial void OnSelectedLanguageChanged(LanguageOption value)
        {
            if (isApplyingConfig)
                return;
            operationService.SetLanguage(value?.Code ?? "en");
        }

        /// <summary>
        /// Фиксация положения источника света после отпускания шарика в контроле выбора света.
        /// </summary>
        /// <param name="x">Координата X шарика в координатах контрола.</param>
        /// <param name="y">Координата Y шарика в координатах контрола.</param>
        /// <param name="controlWidth">Ширина контрола выбора света.</param>
        /// <param name="controlHeight">Высота контрола выбора света.</param>
        public void CommitLighterPosition(double x, double y, double controlWidth, double controlHeight)
            => operationService.SetLighterPosition(x, y, controlWidth, controlHeight);

        private void ApplyConfig(SettingsConfig config)
        {
            isApplyingConfig = true;
            try
            {
                BackgroundColor = ToAvalonia(config.BackGroundColor);
                SelectionObjectColor = ToAvalonia(config.SelectObjectColor);
                SelectionGroupColor = ToAvalonia(config.SelectGroupColor);
                NodeColor = ToAvalonia(config.NodeColor);
                Color3DElement = ToAvalonia(config.SelectObjectColor);
                Color2DElement = ToAvalonia(config.SelectObjectColor);
                SolverPath = string.IsNullOrEmpty(config.SolverPath) ? "?" : config.SolverPath;
                IsLighting = config.Lighting;
                LightingIntensity = config.LightingIntensity;
                // Положение шарика на холсте всегда стартует из центра: в конфиге
                // LighterPosition хранится в масштабе сцены и непригодно для холста 230×233.
                LighterPosition = new Avalonia.Point(0, 0);
                IsTransparency = config.Transparency;
                TransparencyValue = config.TransparencyValue * 100 / 255;
                IsBackRibbers = config.BackRibbers;
                IsOrtoProjection = config.Projection == ViewProjection.Parallel;
                SelectedLanguage = config.Language == "ru" ? LanguageOption.Russian : LanguageOption.English;
            }
            finally
            {
                isApplyingConfig = false;
            }
        }

        private static Color ToAvalonia(System.Drawing.Color c)
            => Color.FromArgb(c.A, c.R, c.G, c.B);

        private static System.Drawing.Color ToDrawing(Color c)
            => System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);
    }
}
