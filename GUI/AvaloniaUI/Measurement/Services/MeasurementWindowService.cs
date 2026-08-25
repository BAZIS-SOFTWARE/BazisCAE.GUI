using BazisGUI.AvaloniaUI.Hosting;
using BazisGUI.AvaloniaUI.Measurement.ViewModels;
using BazisGUI.AvaloniaUI.Measurement.Views;
using System;

namespace BazisGUI.AvaloniaUI.Measurement.Services
{
    /// <summary>
    /// Composition root модуля измерений: создаёт <see cref="MeasurementWindow"/>
    /// с <see cref="MeasurementViewModel"/> и показывает его в UI-потоке Avalonia.
    /// </summary>
    /// <remarks>
    /// Окно открывается в потоке Avalonia через <see cref="AvaloniaHost.Post"/>,
    /// что гарантирует работу с UI только из его потока. Операции измерения
    /// выполняются через <see cref="IMeasurementOperationService"/> в UI-потоке WinForms.
    /// Если окно уже открыто, повторный вызов просто активирует его.
    /// </remarks>
    internal static class MeasurementWindowService
    {
        /// <summary>
        /// Ссылка на открытое окно измерений, либо <c>null</c>, если окно не отображается.
        /// </summary>
        private static MeasurementWindow? currentWindow;

        /// <summary>
        /// Открывает окно измерений.
        /// </summary>
        /// <param name="operationService">
        /// Сервис операций измерения, выполняющий работу со сценой в UI-потоке WinForms.
        /// Не может быть <c>null</c>.
        /// </param>
        /// <param name="closed">
        /// Необязательный обратный вызов после закрытия окна (например, сброс флажка меню).
        /// Вызывается в UI-потоке Avalonia, поэтому для работы с WinForms UI
        /// нужно переключать контекст на стороне вызывающего кода.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Возникает, если аргумент <paramref name="operationService"/> равен <c>null</c>.
        /// </exception>
        public static void Show(IMeasurementOperationService operationService, Action? closed = null)
        {
            if (operationService == null)
                throw new ArgumentNullException(nameof(operationService));

            AvaloniaHost.Post(() =>
            {
                // Если окно уже открыто — просто активируем его.
                if (currentWindow != null)
                {
                    currentWindow.Activate();
                    return;
                }

                var viewModel = new MeasurementViewModel(operationService);
                var window = new MeasurementWindow
                {
                    DataContext = viewModel
                };
                currentWindow = window;
                viewModel.CloseRequested += (_, _) => window.Close();

                window.Closed += (_, _) =>
                {
                    // Сбрасываем ссылку только если закрылось именно это окно.
                    if (ReferenceEquals(currentWindow, window))
                        currentWindow = null;

                    operationService.Reset();
                    closed?.Invoke();
                };

                window.Show();
            });
        }

        /// <summary>
        /// Закрывает окно измерений, если оно открыто.
        /// </summary>
        public static void Close()
        {
            AvaloniaHost.Post(() =>
            {
                currentWindow?.Close();
            });
        }
    }
}
