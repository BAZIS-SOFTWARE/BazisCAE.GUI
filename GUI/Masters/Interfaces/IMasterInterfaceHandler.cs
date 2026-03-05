using MasterInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Masters.Interfaces
{
    public interface IMasterInterfaceHandler<T, U> 
        where T : IMasterInterface
        where U : IHandlerAction
    {
        void SetHandlerAction(U action);
        U GetHandlerAction();
        void Handle(T instance);
    }
}
