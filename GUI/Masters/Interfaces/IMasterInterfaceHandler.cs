using MasterInterface.Interfaces;
using System;

namespace BazisGUI.Masters.Interfaces
{
    public interface IMasterInterfaceHandler
    {
        void SetExecuteContainer(Action<Action, EventArgs> tryCatchContainer);
        bool CanHandle(Type interfaceType);
        void SetHandlerAction(IHandlerAction action);
        IHandlerAction GetHandlerAction();
        void Handle(object instance);
    }

    public interface IMasterInterfaceHandler<in T> : IMasterInterfaceHandler
        where T : IMasterInterface
    {
        void Handle(T instance);
    }
}
