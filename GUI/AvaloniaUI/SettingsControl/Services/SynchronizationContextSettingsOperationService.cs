using System;
using System.Drawing;
using System.Threading;

namespace BazisGUI.AvaloniaUI.SettingsControl.Services
{
    /// <summary>
    /// Сервис операций настроек, гарантирующий выполнение действий в указанном
    /// <see cref="SynchronizationContext"/> (обычно UI-поток WinForms).
    /// </summary>
    /// <remarks>
    /// Avalonia работает в отдельном STA-потоке, а работа с рендерером, сценой и
    /// конфигурацией выполняется в UI-потоке WinForms. Этот адаптер переносит запросы
    /// из окна настроек обратно в WinForms-поток через переданные делегаты.
    /// </remarks>
    internal sealed class SynchronizationContextSettingsOperationService : ISettingsOperationService
    {
        private readonly SynchronizationContext synchronizationContext;
        private readonly Action<Color> setBackgroundColor;
        private readonly Action<Color> setSelectionObjectColor;
        private readonly Action<Color> setSelectionGroupColor;
        private readonly Action<Color> setNodeColor;
        private readonly Action<string> setSolverPath;
        private readonly Action<bool> setLighting;
        private readonly Action<int> setLightingIntensity;
        private readonly Action<double, double, double, double> setLighterPosition;
        private readonly Action<bool> setTransparency;
        private readonly Action<int> setTransparencyValue;
        private readonly Action<bool> setOrtoProjection;
        private readonly Action<string> setLanguage;
        private readonly Action save;

        public SynchronizationContextSettingsOperationService(
            SynchronizationContext synchronizationContext,
            Action<Color> setBackgroundColor,
            Action<Color> setSelectionObjectColor,
            Action<Color> setSelectionGroupColor,
            Action<Color> setNodeColor,
            Action<string> setSolverPath,
            Action<bool> setLighting,
            Action<int> setLightingIntensity,
            Action<double, double, double, double> setLighterPosition,
            Action<bool> setTransparency,
            Action<int> setTransparencyValue,
            Action<bool> setOrtoProjection,
            Action<string> setLanguage,
            Action save)
        {
            this.synchronizationContext = synchronizationContext
                ?? throw new ArgumentNullException(nameof(synchronizationContext));
            this.setBackgroundColor = setBackgroundColor ?? throw new ArgumentNullException(nameof(setBackgroundColor));
            this.setSelectionObjectColor = setSelectionObjectColor ?? throw new ArgumentNullException(nameof(setSelectionObjectColor));
            this.setSelectionGroupColor = setSelectionGroupColor ?? throw new ArgumentNullException(nameof(setSelectionGroupColor));
            this.setNodeColor = setNodeColor ?? throw new ArgumentNullException(nameof(setNodeColor));
            this.setSolverPath = setSolverPath ?? throw new ArgumentNullException(nameof(setSolverPath));
            this.setLighting = setLighting ?? throw new ArgumentNullException(nameof(setLighting));
            this.setLightingIntensity = setLightingIntensity ?? throw new ArgumentNullException(nameof(setLightingIntensity));
            this.setLighterPosition = setLighterPosition ?? throw new ArgumentNullException(nameof(setLighterPosition));
            this.setTransparency = setTransparency ?? throw new ArgumentNullException(nameof(setTransparency));
            this.setTransparencyValue = setTransparencyValue ?? throw new ArgumentNullException(nameof(setTransparencyValue));
            this.setOrtoProjection = setOrtoProjection ?? throw new ArgumentNullException(nameof(setOrtoProjection));
            this.setLanguage = setLanguage ?? throw new ArgumentNullException(nameof(setLanguage));
            this.save = save ?? throw new ArgumentNullException(nameof(save));
        }

        public void SetBackgroundColor(Color color) => synchronizationContext.Post(_ => setBackgroundColor(color), null);

        public void SetSelectionObjectColor(Color color) => synchronizationContext.Post(_ => setSelectionObjectColor(color), null);

        public void SetSelectionGroupColor(Color color) => synchronizationContext.Post(_ => setSelectionGroupColor(color), null);

        public void SetNodeColor(Color color) => synchronizationContext.Post(_ => setNodeColor(color), null);

        public void SetSolverPath(string path) => synchronizationContext.Post(_ => setSolverPath(path), null);

        public void SetLighting(bool enabled) => synchronizationContext.Post(_ => setLighting(enabled), null);

        public void SetLightingIntensity(int intensity) => synchronizationContext.Post(_ => setLightingIntensity(intensity), null);

        public void SetLighterPosition(double x, double y, double controlWidth, double controlHeight)
            => synchronizationContext.Post(_ => setLighterPosition(x, y, controlWidth, controlHeight), null);

        public void SetTransparency(bool enabled) => synchronizationContext.Post(_ => setTransparency(enabled), null);

        public void SetTransparencyValue(int value) => synchronizationContext.Post(_ => setTransparencyValue(value), null);

        public void SetOrtoProjection(bool enabled) => synchronizationContext.Post(_ => setOrtoProjection(enabled), null);

        public void SetLanguage(string language) => synchronizationContext.Post(_ => setLanguage(language), null);

        public void Save() => synchronizationContext.Post(_ => save(), null);
    }
}
