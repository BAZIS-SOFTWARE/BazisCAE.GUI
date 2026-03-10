using BazisGUI.Masters.Actions;
using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;

namespace BazisGUI.Masters.Handlers
{
    public class PreparedConditionsHandler : MasterHandlerBase<IPreparedDataLoader, PreparedConditionsAction>
    {
        private PreparedConditionsAction action;

        public override PreparedConditionsAction GetHandlerAction() => action;

        public override void SetHandlerAction(PreparedConditionsAction act) => action = act;

        public override bool CanHandle(Type interfaceType) =>
            typeof(IPreparedDataLoader).IsAssignableFrom(interfaceType);

        public override void Handle(IPreparedDataLoader instance)
        {
            if (action == null)
                throw new NullReferenceException($"Не определено действие обработчика FunctionsHandler<{typeof(PreparedConditionsAction)}>");

            action.PreparedConditionsStringsAction += (s, e) => container(() => instance.SetDataFromConditionsStrings(e.ConditionStrings), e);
        }
    }
}
