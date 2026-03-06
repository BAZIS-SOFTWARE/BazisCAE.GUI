using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;

namespace BazisGUI.Masters.Handlers
{
    public abstract class MasterHandlerBase<T> : IMasterInterfaceHandler
        where T : IMasterInterface
    {
        protected Action<Action, EventArgs> container;
        public void Handle(object instance)
        {
            if (instance is T typed)
                Handle(typed);
            else throw new ArgumentException($"Обрабатываемые объект не реализует интерфейс {typeof(T)}");
        }

        public void SetExecuteContainer(Action<Action, EventArgs> tryCatchContainer) =>
            container = tryCatchContainer;

        public abstract void Handle(T instance);
        public abstract bool CanHandle(Type interfaceType);
        public abstract IHandlerAction GetHandlerAction();
        public abstract void SetHandlerAction(IHandlerAction action);
    }
}
