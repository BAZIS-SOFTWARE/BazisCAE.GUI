using BazisGUI.AvaloniaUI.Measurement.Models;
using System;
using System.Threading;

namespace BazisGUI.AvaloniaUI.Measurement.Services
{
    /// <summary>
    /// Сервис выполнения операций измерения, гарантирующий выполнение действий
    /// в указанном <see cref="SynchronizationContext"/> (обычно UI-поток WinForms).
    /// </summary>
    /// <remarks>
    /// Avalonia работает в отдельном STA-потоке, а вся работа со сценой и выбором
    /// выполняется в UI-потоке WinForms. Этот адаптер переносит запросы из окна
    /// измерений обратно в WinForms-поток через переданные делегаты.
    /// </remarks>
    internal sealed class SynchronizationContextMeasurementOperationService : IMeasurementOperationService
    {
        private readonly SynchronizationContext synchronizationContext;
        private readonly Action<MeasureKind> prepareObjects;
        private readonly Action<MeasureKind> measure;
        private readonly Action reset;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="SynchronizationContextMeasurementOperationService"/>.
        /// </summary>
        /// <param name="synchronizationContext">
        /// Контекст синхронизации, в котором должны выполняться переданные операции (обычно контекст UI WinForms).
        /// </param>
        /// <param name="prepareObjects">
        /// Делегат, реализующий подготовку сцены к выбору объектов измерения.
        /// </param>
        /// <param name="measure">
        /// Делегат, реализующий само измерение.
        /// </param>
        /// <param name="reset">
        /// Делегат, реализующий сброс состояния сцены при закрытии окна.
        /// </param>
        public SynchronizationContextMeasurementOperationService(
            SynchronizationContext synchronizationContext,
            Action<MeasureKind> prepareObjects,
            Action<MeasureKind> measure,
            Action reset)
        {
            this.synchronizationContext = synchronizationContext
                ?? throw new ArgumentNullException(nameof(synchronizationContext));
            this.prepareObjects = prepareObjects
                ?? throw new ArgumentNullException(nameof(prepareObjects));
            this.measure = measure
                ?? throw new ArgumentNullException(nameof(measure));
            this.reset = reset
                ?? throw new ArgumentNullException(nameof(reset));
        }

        /// <summary>
        /// Запрашивает подготовку сцены к выбору объектов в контексте синхронизации.
        /// </summary>
        /// <param name="kind">Выбранный вид измерения.</param>
        public void PrepareObjects(MeasureKind kind) => synchronizationContext.Post(_ => prepareObjects(kind), null);

        /// <summary>
        /// Запрашивает выполнение измерения в контексте синхронизации.
        /// </summary>
        /// <param name="kind">Вид измерения.</param>
        public void Measure(MeasureKind kind) => synchronizationContext.Post(_ => measure(kind), null);

        /// <summary>
        /// Запрашивает сброс состояния сцены в контексте синхронизации.
        /// </summary>
        public void Reset() => synchronizationContext.Post(_ => reset(), null);
    }
}
