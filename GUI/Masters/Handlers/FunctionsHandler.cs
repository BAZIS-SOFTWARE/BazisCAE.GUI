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
    public class FunctionsHandler : MasterHandlerBase<IFunctionsHandling> 
    {
        private FunctionAction action;

        public override IHandlerAction GetHandlerAction() => action;

        public override void SetHandlerAction(IHandlerAction act)
        {
            if (act is FunctionAction a)
                action = a;
            else throw new ArgumentException($"Передананное действие не соответствует обработчику. Вместо GroupAction, получено {action?.GetType()}");
        }

        public override bool CanHandle(Type interfaceType) =>
            typeof(IFunctionsHandling).IsAssignableFrom(interfaceType);

        public override void Handle(IFunctionsHandling instance)
        {
            if (action == null)
                throw new NullReferenceException($"Не определено действие обработчика FunctionsHandler<{typeof(FunctionAction)}>");

            action.FunctionsAction += (s, e) => container(() => instance.SetFunctions(e.Functions), e);
        }
    }
}
