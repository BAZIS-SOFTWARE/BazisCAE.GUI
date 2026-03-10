using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;

namespace BazisGUI.Masters.Handlers
{
    /// <summary>
    /// Абстракция для определения обработчика интерфейса мастера
    /// </summary>
    /// <typeparam name="T">Интерфейс мастера, который будет обрабатываться обработчиком</typeparam>
    public abstract class MasterHandlerBase<T, U> : IMasterInterfaceHandler
        where T : IMasterInterface
        where U : IHandlerAction
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
        /// Базовый метод установки действия обработчика
        /// </summary>
        /// <param name="action">Действие обработчика</param>
        /// <exception cref="ArgumentException">Ошибка при передаче объекта неверного типа</exception>
        public void SetAction(object action)
        {
            if (action is U typed)
                SetHandlerAction(typed);
            else throw new ArgumentException($"Обрабатываемые объект не реализует интерфейс {typeof(U)}");
        }

        /// <summary>
        /// Базовый метод получения действия обработчика
        /// </summary>
        /// <returns>Экземпляр класса действия обработчика приведенного к типу object</returns>
        public object GetAction() => GetHandlerAction();

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
        public abstract U GetHandlerAction();

        /// <summary>
        /// Установка действия обработчика.
        /// принимаемое действие обработчика проверяется на соответствие типу обработчика
        /// </summary>
        /// <param name="action">Экземпляр абстракного действия обработчика</param>
        public abstract void SetHandlerAction(U action);
    }
}
