using BazisGUI.Scene;
using System;
using System.Threading;

namespace BazisGUI.AvaloniaUI.Clip.Services
{
    /// <summary>
    /// Сервис операций отсечения, гарантирующий выполнение действий в указанном
    /// <see cref="SynchronizationContext"/> (обычно UI-поток WinForms).
    /// </summary>
    /// <remarks>
    /// Avalonia работает в отдельном STA-потоке, а вся работа со сценой и OpenGL
    /// выполняется в UI-потоке WinForms. Этот адаптер переносит запросы из окна
    /// отсечения обратно в WinForms-поток через переданные делегаты.
    /// </remarks>
    internal sealed class SynchronizationContextClipOperationService : IClipOperationService
    {
        private readonly SynchronizationContext synchronizationContext;
        private readonly Action<bool, ClipMode> switchOnOff;
        private readonly Action<ClipMode> changeClipMode;
        private readonly Action<double, double, double, double> setPlane;
        private readonly Action redraw;
        private readonly Action<double> setLayerThickness;
        private readonly Action capture;
        private readonly Action reset;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="SynchronizationContextClipOperationService"/>.
        /// </summary>
        /// <param name="synchronizationContext">
        /// Контекст синхронизации, в котором должны выполняться переданные операции (обычно контекст UI WinForms).
        /// </param>
        /// <param name="switchOnOff">Делегат включения/выключения отсечения плоскостью.</param>
        /// <param name="changeClipMode">Делегат смены режима отсечения 3D-элементов.</param>
        /// <param name="setPlane">Делегат задания плоскости отсечения на сцене.</param>
        /// <param name="redraw">Делегат перерисовки сцены.</param>
        /// <param name="setLayerThickness">Делегат задания толщины слоя.</param>
        /// <param name="capture">Делегат захвата данных (GL TransformFeedback).</param>
        /// <param name="reset">Делегат сброса состояния сцены при закрытии окна.</param>
        public SynchronizationContextClipOperationService(
            SynchronizationContext synchronizationContext,
            Action<bool, ClipMode> switchOnOff,
            Action<ClipMode> changeClipMode,
            Action<double, double, double, double> setPlane,
            Action redraw,
            Action<double> setLayerThickness,
            Action capture,
            Action reset)
        {
            this.synchronizationContext = synchronizationContext
                ?? throw new ArgumentNullException(nameof(synchronizationContext));
            this.switchOnOff = switchOnOff
                ?? throw new ArgumentNullException(nameof(switchOnOff));
            this.changeClipMode = changeClipMode
                ?? throw new ArgumentNullException(nameof(changeClipMode));
            this.setPlane = setPlane
                ?? throw new ArgumentNullException(nameof(setPlane));
            this.redraw = redraw
                ?? throw new ArgumentNullException(nameof(redraw));
            this.setLayerThickness = setLayerThickness
                ?? throw new ArgumentNullException(nameof(setLayerThickness));
            this.capture = capture
                ?? throw new ArgumentNullException(nameof(capture));
            this.reset = reset
                ?? throw new ArgumentNullException(nameof(reset));
        }

        /// <summary>
        /// Запрашивает включение/выключение отсечения в контексте синхронизации.
        /// </summary>
        public void SwitchOnOff(bool enabled, ClipMode mode) => synchronizationContext.Post(_ => switchOnOff(enabled, mode), null);

        /// <summary>
        /// Запрашивает смену режима отсечения в контексте синхронизации.
        /// </summary>
        public void ChangeClipMode(ClipMode mode) => synchronizationContext.Post(_ => changeClipMode(mode), null);

        /// <summary>
        /// Запрашивает задание плоскости отсечения в контексте синхронизации.
        /// </summary>
        public void SetPlane(double x, double y, double z, double d) => synchronizationContext.Post(_ => setPlane(x, y, z, d), null);

        /// <summary>
        /// Запрашивает перерисовку сцены в контексте синхронизации.
        /// </summary>
        public void Redraw() => synchronizationContext.Post(_ => redraw(), null);

        /// <summary>
        /// Запрашивает задание толщины слоя в контексте синхронизации.
        /// </summary>
        public void SetLayerThickness(double thickness) => synchronizationContext.Post(_ => setLayerThickness(thickness), null);

        /// <summary>
        /// Запрашивает захват данных (GL TransformFeedback) в контексте синхронизации.
        /// </summary>
        public void Capture() => synchronizationContext.Post(_ => capture(), null);

        /// <summary>
        /// Запрашивает сброс состояния сцены в контексте синхронизации.
        /// </summary>
        public void Reset() => synchronizationContext.Post(_ => reset(), null);
    }
}
