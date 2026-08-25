using BazisGUI.AvaloniaUI.Clip.ViewModels;
using BazisGUI.AvaloniaUI.Clip.Views;
using BazisGUI.AvaloniaUI.Hosting;
using System;

namespace BazisGUI.AvaloniaUI.Clip.Services
{
    /// <summary>
    /// Composition root модуля «Скрыть плоскостью»: создаёт <see cref="ClipWindow"/>
    /// с <see cref="ClipViewModel"/> и показывает его в UI-потоке Avalonia.
    /// </summary>
    /// <remarks>
    /// Окно открывается в потоке Avalonia через <see cref="AvaloniaHost.Post"/>.
    /// Операции отсечения выполняются через <see cref="IClipOperationService"/>
    /// в UI-потоке WinForms. Если окно уже открыто, повторный вызов просто активирует его.
    /// </remarks>
    internal static class ClipWindowService
    {
        /// <summary>
        /// Ссылка на открытое окно отсечения, либо <c>null</c>, если окно не отображается.
        /// </summary>
        private static ClipWindow? currentWindow;

        /// <summary>
        /// Открывает окно отсечения плоскостью.
        /// </summary>
        /// <param name="operationService">
        /// Сервис операций, выполняющий работу со сценой (GL) в UI-потоке WinForms.
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
        public static void Show(IClipOperationService operationService, Action? closed = null)
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

                var viewModel = new ClipViewModel(operationService);
                var window = new ClipWindow
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
        /// Закрывает окно отсечения, если оно открыто.
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
