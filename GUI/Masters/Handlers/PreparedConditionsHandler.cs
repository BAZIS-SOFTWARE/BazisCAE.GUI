using BazisGUI.Masters.Actions;
using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Masters.Handlers
{
    public class PreparedConditionsHandler : MasterHandlerBase<IPreparedDataLoader>
    {
        private PreparedConditionsAction action;

        public override IHandlerAction GetHandlerAction() => action;

        public override void SetHandlerAction(IHandlerAction act)
        {
            if (act is PreparedConditionsAction pca)
                action = pca;
            else throw new ArgumentException("Передан некорректный параметр действия для обработчика");
        }

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
