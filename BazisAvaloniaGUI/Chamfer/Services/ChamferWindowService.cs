using BazisAvaloniaGUI.Chamfer.ViewModels;
using BazisAvaloniaGUI.Chamfer.Views;
using Avalonia.Threading;
using System;

namespace BazisAvaloniaGUI.Chamfer.Services
{
    /// <summary>
    /// Вспомогательный сервис для управления окном построения фасок.
    /// </summary>
    /// <remarks>
    /// Сервис отвечает за создание и отображение <see cref="ChamferWindow"/> с соответствующим
    /// <see cref="ChamferViewModel"/>. Все обращения к UI выполняются через хост-обработчик
    /// <see cref="Dispatcher.UIThread"/>, чтобы гарантировать выполнение на UI-потоке
    /// (в BazisGUI окно размещается во встроенном хосте и использует AvaloniaHost.Post).
    /// При закрытии окна сервис очищает превью операции через переданный <see cref="IChamferOperationService"/>
    /// и уведомляет вызывающую сторону через переданное действие, что позволяет ей синхронизировать
    /// собственное состояние с фактическим состоянием окна.
    /// </remarks>
    internal static class ChamferWindowService
    {
        /// <summary>
        /// Текущий открытый экземпляр окна фаски или <c>null</c>, если окно не отображается.
        /// </summary>
        private static ChamferWindow currentWindow;

        /// <summary>
        /// Отобразить окно построения фаски.
        /// </summary>
        /// <param name="operationService">
        /// Сервис операции фаски, предоставляющий логику построения и методы управления превью.
        /// Не может быть <c>null</c>.
        /// </param>
        /// <param name="closed">
        /// Необязательное действие, вызываемое после закрытия окна любым способом,
        /// в том числе системной кнопкой закрытия. Вызывается в UI-потоке Avalonia,
        /// поэтому вызывающая сторона отвечает за переход в собственный UI-поток.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Бросается, если параметр <paramref name="operationService"/> равен <c>null</c>.
        /// </exception>
        public static void Show(IChamferOperationService operationService, Action closed = null)
        {
            if (operationService == null)
                throw new System.ArgumentNullException(nameof(operationService));

            Dispatcher.UIThread.Post(() =>
            {
                // Одновременно допускается только одно окно построения фаски.
                if (currentWindow != null)
                {
                    currentWindow.Activate();
                    return;
                }

                var viewModel = new ChamferViewModel(operationService);
                var window = new ChamferWindow
                {
                    DataContext = viewModel
                };
                currentWindow = window;
                viewModel.CloseRequested += (_, _) => window.Close();

                window.Closed += (_, _) =>
                {
                    // Ссылка очищается до уведомления, чтобы окно можно было открыть повторно.
                    if (ReferenceEquals(currentWindow, window))
                        currentWindow = null;

                    operationService.ClearPreview();
                    closed?.Invoke();
                };

                window.Show();
            });
        }

        /// <summary>
        /// Закрыть текущее окно фаски, если оно открыто.
        /// </summary>
        public static void Close()
        {
            Dispatcher.UIThread.Post(() =>
            {
                currentWindow?.Close();
            });
        }
    }
}
