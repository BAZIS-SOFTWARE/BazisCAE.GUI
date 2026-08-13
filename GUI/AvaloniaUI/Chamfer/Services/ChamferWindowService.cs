using BazisGUI.AvaloniaUI.Chamfer.ViewModels;
using BazisGUI.AvaloniaUI.Chamfer.Views;
using BazisGUI.AvaloniaUI.Hosting;

namespace BazisGUI.AvaloniaUI.Chamfer.Services
{
    /// <summary>
    /// Сервис для отображения окна построения фасок.
    /// </summary>
    /// <remarks>
    /// Выполняет создание <see cref="ChamferViewModel"/> и <see cref="ChamferWindow"/>,
    /// привязывает контекст данных и отображает окно в UI-потоке через <see cref="AvaloniaHost.Post"/>.
    /// Подписывается на событие закрытия из ViewModel, чтобы корректно закрыть окно.
    /// </remarks>
    internal static class ChamferWindowService
    {
        /// <summary>
        /// Отобразить окно построения фасок, используя предоставленный сервис операций фаски.
        /// </summary>
        /// <param name="operationService">Сервис, реализующий операции построения фаски. Не может быть <c>null</c>.</param>
        /// <exception cref="System.ArgumentNullException">Если <paramref name="operationService"/> равен <c>null</c>.</exception>
        public static void Show(IChamferOperationService operationService)
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

                viewModel.CloseRequested += (_, _) => window.Close();

                window.Show();
            });
        }
    }
}
