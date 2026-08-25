using BazisGUI.Scene;

namespace BazisGUI.AvaloniaUI.Clip.Services
{
    /// <summary>
    /// Граница между ViewModel окна «Скрыть плоскостью» и прикладной логикой приложения.
    /// </summary>
    /// <remarks>
    /// Реализации гарантируют выполнение операций в UI-потоке WinForms через
    /// <see cref="System.Threading.SynchronizationContext"/> (см.
    /// <see cref="SynchronizationContextClipOperationService"/>), поэтому вся GL-логика
    /// (клип-плоскость, режимы отсечения, захват данных) остаётся на стороне WinForms
    /// и вызывается из Avalonia-модуля без прямых GL-зависимостей.
    /// </remarks>
    public interface IClipOperationService
    {
        /// <summary>Включить/выключить отсечение плоскостью (создание/удаление плоскости и смена режима).</summary>
        void SwitchOnOff(bool enabled, ClipMode mode);

        /// <summary>Сменить режим отсечения 3D-элементов.</summary>
        void ChangeClipMode(ClipMode mode);

        /// <summary>Задать плоскость отсечения на сцене.</summary>
        void SetPlane(double x, double y, double z, double d);

        /// <summary>Перерисовать сцену (применить плоскость отсечения).</summary>
        void Redraw();

        /// <summary>Сменить толщину слоя для режима «Слой 3D».</summary>
        void SetLayerThickness(double thickness);

        /// <summary>Выполнить захват данных (GL TransformFeedback).</summary>
        void Capture();

        /// <summary>Сбросить состояние сцены при закрытии окна.</summary>
        void Reset();
    }
}
