using BazisGUI.Masters.Actions;
using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BazisGUI.Masters.Handlers
{
    public class FunctionsHandler<T, U> : IMasterInterfaceHandler<T, U> 
        where T : IFunctionsHandling
        where U : FunctionAction
    {
        private U action;

        public U GetHandlerAction() => action;
        public void SetHandlerAction(U act) => action = act;

        public void Handle(T instance)
        {
            if (action == null)
                throw new NullReferenceException($"Не определено действие обработчика FunctionsHandler<{typeof(U)}>");

            if (instance == null)
                throw new ArgumentNullException($"Объект класса {typeof(T)} не определен до обработки");

            action.FunctionsAct += (arg1) => instance.SetFunctions(arg1.Functions);
        }
    }
}
