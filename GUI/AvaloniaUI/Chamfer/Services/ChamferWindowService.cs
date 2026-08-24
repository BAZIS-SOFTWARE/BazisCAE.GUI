using BazisGUI.AvaloniaUI.Chamfer.ViewModels;
using BazisGUI.AvaloniaUI.Chamfer.Views;
using BazisGUI.AvaloniaUI.Hosting;
using System;

namespace BazisGUI.AvaloniaUI.Chamfer.Services
{
    /// <summary>
    /// ¬спомогательный сервис дл€ управлени€ окном построени€ фасок.
    /// </summary>
    /// <remarks>
    /// —ервис отвечает за создание и отображение <see cref="ChamferWindow"/> с соответствующим
    /// <see cref="ChamferViewModel"/>. ¬се обращени€ к UI выполн€ютс€ через хост-обработчик
    /// <see cref="AvaloniaHost.Post"/>, чтобы гарантировать выполнение на UI-потоке.
    /// ѕри закрытии окна сервис очищает превью операции через переданный <see cref="IChamferOperationService"/>.
    /// </remarks>
    internal static class ChamferWindowService
    {
        /// <summary>
        /// “екущий открытый экземпл€р окна фаски или <c>null</c>, если окно не отображаетс€.
        /// </summary>
        private static ChamferWindow? currentWindow;

        /// <summary>
        /// ќтобразить окно построени€ фаски.
        /// </summary>
        /// <param name="operationService">
        /// —ервис операции фаски, предоставл€ющий логику построени€ и методы управлени€ превью.
        /// Ќе может быть <c>null</c>.
        /// </param>
        /// <param name="closed">Ќеоб€зательное действие, вызываемое после закрыти€ окна.</param>
        /// <exception cref="ArgumentNullException">
        /// Ѕросаетс€, если параметр <paramref name="operationService"/> равен <c>null</c>.
        /// </exception>
        public static void Show(IChamferOperationService operationService, Action? closed = null)
        {
            if (operationService == null)
                throw new System.ArgumentNullException(nameof(operationService));

            AvaloniaHost.Post(() =>
            {
                var viewModel = new ChamferViewModel(operationService);
                var window = new ChamferWindow
                {
                    DataContext = viewModel
                };
                currentWindow = window;
                viewModel.CloseRequested += (_, _) => window.Close();

                window.Closed += (_, _) =>
                {
                    operationService.ClearPreview();
                    closed?.Invoke();
                };

                window.Show();
            });
        }

        /// <summary>
        /// «акрыть текущее окно фаски, если оно открыто.
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
