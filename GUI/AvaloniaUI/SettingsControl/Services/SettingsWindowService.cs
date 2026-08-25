using BazisGUI.AvaloniaUI.Hosting;
using BazisGUI.AvaloniaUI.SettingsControl.ViewModels;
using BazisGUI.AvaloniaUI.SettingsControl.Views;
using BazisGUI.SettingsControls;
using System;

namespace BazisGUI.AvaloniaUI.SettingsControl.Services
{
    /// <summary>
    /// Composition root модуля настроек: создаёт <see cref="SettingsWindow"/>
    /// с <see cref="SettingsViewModel"/> и показывает его в UI-потоке Avalonia.
    /// </summary>
    /// <remarks>
    /// Окно открывается в потоке Avalonia через <see cref="AvaloniaHost.Post"/>.
    /// Применение настроек выполняется через <see cref="ISettingsOperationService"/>
    /// в UI-потоке WinForms. При закрытии окна конфигурация сохраняется.
    /// </remarks>
    internal static class SettingsWindowService
    {
        /// <summary>
        /// Ссылка на открытое окно настроек, либо <c>null</c>, если окно не отображается.
        /// </summary>
        private static SettingsWindow? currentWindow;

        /// <summary>
        /// Открывает окно настроек.
        /// </summary>
        /// <param name="operationService">
        /// Сервис операций, применяющий настройки в UI-потоке WinForms. Не может быть <c>null</c>.
        /// </param>
        /// <param name="config">
        /// Текущая конфигурация приложения, из которой окно берёт начальные значения.
        /// </param>
        /// <param name="closed">
        /// Необязательный обратный вызов после закрытия окна. Вызывается в UI-потоке Avalonia,
        /// поэтому для работы с WinForms UI нужно переключать контекст на стороне вызывающего кода.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Возникает, если аргумент <paramref name="operationService"/> равен <c>null</c>.
        /// </exception>
        public static void Show(ISettingsOperationService operationService, SettingsConfig config, Action? closed = null)
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

                var viewModel = new SettingsViewModel(operationService, config);
                var window = new SettingsWindow
                {
                    DataContext = viewModel
                };
                currentWindow = window;

                window.Closed += (_, _) =>
                {
                    // Сбрасываем ссылку только если закрылось именно это окно.
                    if (ReferenceEquals(currentWindow, window))
                        currentWindow = null;

                    operationService.Save();
                    closed?.Invoke();
                };

                window.Show();
            });
        }

        /// <summary>
        /// Закрывает окно настроек, если оно открыто.
        /// </summary>
        public static void Close()
        {
            AvaloniaHost.Post(() => currentWindow?.Close());
        }
    }
}
