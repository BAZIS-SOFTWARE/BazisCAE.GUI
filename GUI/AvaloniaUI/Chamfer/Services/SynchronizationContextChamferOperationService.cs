using System;
using System.Threading;

namespace BazisGUI.AvaloniaUI.Chamfer.Services
{
    /// <summary>
    /// Сервис выполнения операций создания фаски, гарантирующий выполнение действий в указанном
    /// <see cref="SynchronizationContext"/> (обычно UI-поток).
    /// </summary>
    internal sealed class SynchronizationContextChamferOperationService : IChamferOperationService
    {
        private readonly SynchronizationContext synchronizationContext;
        private readonly Action<double, double> addByAngle;
        private readonly Action<double, double> addByLengths;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="SynchronizationContextChamferOperationService"/>.
        /// </summary>
        /// <param name="synchronizationContext">
        /// Контекст синхронизации, в котором должны выполняться переданные операции (обычно контекст UI).
        /// </param>
        /// <param name="addByAngle">
        /// Делегат, реализующий добавление фаски по длине и углу. Вызывается в контексте <paramref name="synchronizationContext"/>.
        /// </param>
        /// <param name="addByLengths">
        /// Делегат, реализующий добавление фаски по двум длинам. Вызывается в контексте <paramref name="synchronizationContext"/>.
        /// </param>
        public SynchronizationContextChamferOperationService(SynchronizationContext synchronizationContext, Action<double, double> addByAngle, Action<double, double> addByLengths)
        {
            this.synchronizationContext = synchronizationContext
                ?? throw new ArgumentNullException(nameof(synchronizationContext));
            this.addByAngle = addByAngle ?? throw new ArgumentNullException(nameof(addByAngle));
            this.addByLengths = addByLengths ?? throw new ArgumentNullException(nameof(addByLengths));
        }

        /// <summary>
        /// Запрашивает выполнение операции добавления фаски по длине и углу в контексте синхронизации.
        /// </summary>
        /// <param name="length">Длина фаски. Единицы измерения определяются вызывающим кодом.</param>
        /// <param name="angle">Угол фаски. Формат (градусы/радианы) определяется вызывающим кодом.</param>
        public void AddByAngle(double length, double angle) => synchronizationContext.Post(_ => addByAngle(length, angle), null);

        /// <summary>
        /// Запрашивает выполнение операции добавления фаски по двум длинам в контексте синхронизации.
        /// </summary>
        /// <param name="length1">Первая длина фаски. Единицы измерения определяются вызывающим кодом.</param>
        /// <param name="length2">Вторая длина фаски. Единицы измерения определяются вызывающим кодом.</param>
        public void AddByLengths(double length1, double length2) => synchronizationContext.Post(_ => addByLengths(length1, length2), null);
    }
}
