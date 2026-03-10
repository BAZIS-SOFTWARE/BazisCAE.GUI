using BazisGUI.Masters.Actions;
using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;

namespace BazisGUI.Masters.Handlers
{
    public class FunctionsHandler : MasterHandlerBase<IFunctionsHandling, FunctionAction> 
    {
        private FunctionAction action;

        public override FunctionAction GetHandlerAction() => action;

        public override void SetHandlerAction(FunctionAction act) => action = act;

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
