using BazisGUI.Masters.Actions;
using BazisGUI.Masters.Args;
using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;

namespace BazisGUI.Masters.Handlers
{
    public class MasterHandler : MasterHandlerBase<IBaseMasterInterface>
    {
        private MasterAction action;
        
        public override IHandlerAction GetHandlerAction() => action;

        public override void SetHandlerAction(IHandlerAction act)
        {
            if (act is MasterAction ma)
                action = ma;
            else throw new ArgumentException("Передан некорректный параметр действия для обработчика");
        }

        public override bool CanHandle(Type interfaceType) =>
            typeof(IBaseMasterInterface).IsAssignableFrom(interfaceType);

        public override void Handle(IBaseMasterInterface instance)
        {
            if (action == null)
                throw new NullReferenceException($"Не определено действие обработчика GroupHandler<{typeof(MasterAction)}>");

            instance.GenerateConditionsEvent += (s, e) => container(() => action.GenerateConditionsAction(s, e), new EventArgs());
            instance.PrintInfoEvent += (s, e) => container(() => action.PrintInfoAction(s, e), new EventArgs());
            instance.UpdateSceneEvent += (s, e) => container(() => action.UpdateSceneAction(s, e), new EventArgs());
        }
    }
}
