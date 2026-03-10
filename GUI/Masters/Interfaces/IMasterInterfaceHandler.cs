using MasterInterface.Interfaces;
using System;

namespace BazisGUI.Masters.Interfaces
{
    /// <summary>
    /// Интерфейс для обработчика интерфейсов MasterInterface
    /// </summary>
    public interface IMasterInterfaceHandler
    {
        /// <summary>
        /// Установка контейнера выполнения
        /// </summary>
        /// <param name="tryCatchContainer">Контейнер выполнения</param>
        void SetExecuteContainer(Action<Action, EventArgs> tryCatchContainer);

        /// <summary>
        /// Проверка, может ли interfaceType быть обработан данным обработчиком
        /// </summary>
        /// <param name="interfaceType">Проверяемый тип</param>
        /// <returns>true, если interfaceType может быть обработан обработчиком, в противном случае - false</returns>
        bool CanHandle(Type interfaceType);

        /// <summary>
        /// Установка действия для обработчика.
        /// Выполняется в момент вызова метода Handle.
        /// Внутри проводится проверка соответствия реализации IHandlerAction обработчику
        /// </summary>
        /// <param name="action">Назначаемое действие обработчику</param>
        void SetAction(object action);

        /// <summary>
        /// Получение действия обработчика
        /// </summary>
        /// <returns>Обобщенное действие обработчика в виде IHandlerAction</returns>
        object GetAction();

        /// <summary>
        /// Базовый метод обработки мастера.
        /// Необходим для переопределения и типизации обработчика
        /// </summary>
        /// <param name="instance">Объект для обработки</param>
        void Handle(object instance);
    }
}
