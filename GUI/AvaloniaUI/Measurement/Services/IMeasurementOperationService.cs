using BazisGUI.AvaloniaUI.Measurement.Models;

namespace BazisGUI.AvaloniaUI.Measurement.Services
{
    /// <summary>
    /// Граница между ViewModel окна измерений и прикладной логикой приложения.
    /// </summary>
    /// <remarks>
    /// Реализации гарантируют выполнение операций в UI-потоке WinForms через
    /// <see cref="System.Threading.SynchronizationContext"/> (см.
    /// <see cref="SynchronizationContextMeasurementOperationService"/>), поэтому
    /// Avalonia-модуль не зависит от <see cref="BazisGUI.BaseForm"/>.
    /// </remarks>
    public interface IMeasurementOperationService
    {
        /// <summary>
        /// Готовит сцену к выбору объектов для указанного вида измерения:
        /// устанавливает тип выбираемых объектов и перерисовывает сцену.
        /// </summary>
        /// <param name="kind">Выбранный вид измерения.</param>
        void PrepareObjects(MeasureKind kind);

        /// <summary>
        /// Выполняет измерение выбранного вида.
        /// </summary>
        /// <param name="kind">Вид измерения.</param>
        void Measure(MeasureKind kind);

        /// <summary>
        /// Сбрасывает состояние сцены при закрытии окна измерений.
        /// </summary>
        void Reset();
    }
}
