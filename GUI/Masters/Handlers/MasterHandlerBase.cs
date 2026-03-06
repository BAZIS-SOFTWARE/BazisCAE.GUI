using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;

namespace BazisGUI.Masters.Handlers
{
    /// <summary>
    /// Абстракция для определения обработчика интерфейса мастера
    /// </summary>
    /// <typeparam name="T">Интерфейс мастера, который будет обрабатываться обработчиком</typeparam>
    public abstract class MasterHandlerBase<T> : IMasterInterfaceHandler
        where T : IMasterInterface
    {
        /// <summary>
        /// Контейнер внутри которого происходит запуск действий обработчика
        /// </summary>
        protected Action<Action, EventArgs> container;

        /// <summary>
        /// Базовый метод обработки.
        /// Переопределяется у классов наследников
        /// </summary>
        /// <param name="instance">Конкретный мастер, который реализует интерфейс, обрабатываемый обработчиком</param>
        /// <exception cref="ArgumentException">Переданный мастер не реализует необходимый для обработчика интерфейс</exception>
        public void Handle(object instance)
        {
            if (instance is T typed)
                Handle(typed);
            else throw new ArgumentException($"Обрабатываемые объект не реализует интерфейс {typeof(T)}");
        }

        /// <summary>
        /// Задание контейнера, внутри которого происходит обработка
        /// </summary>
        /// <param name="tryCatchContainer"></param>
        public void SetExecuteContainer(Action<Action, EventArgs> tryCatchContainer) =>
            container = tryCatchContainer;

        /// <summary>
        /// Метод обработки интерфейса.
        /// класс, который реализует обрабатываемый интерфейс
        /// </summary>
        /// <param name="instance">Экземпляр класса, который реализует интерфейс T</param>
        public abstract void Handle(T instance);

        /// <summary>
        /// Проверка, может ли приведенный мастер (его тип) обработаться обработчиком
        /// </summary>
        /// <param name="interfaceType">проверяемый тип</param>
        /// <returns>true, если interfaceType Обрабатывается данным обработчиком</returns>
        public abstract bool CanHandle(Type interfaceType);

        /// <summary>
        /// Получить действие обработчика
        /// </summary>
        /// <returns>Абстракция действия обработчика</returns>
        public abstract IHandlerAction GetHandlerAction();

        /// <summary>
        /// Установка действия обработчика.
        /// принимаемое действие обработчика проверяется на соответствие типу обработчика
        /// </summary>
        /// <param name="action">Экземпляр абстракного действия обработчика</param>
        public abstract void SetHandlerAction(IHandlerAction action);
    }
}
