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

            instance.GenerateConditionsEvent += (condStrirngs) => container(() => action.GenerateConditionsAction(this, new GenerateConditionsEventArgs(condStrirngs)), new EventArgs());
            instance.PrintInfoEvent += (mes, col) => container(() => action.PrintInfoAction(this, new PrintInfoEventArgs(mes, col)), new EventArgs());
            instance.UpdateSceneEvent += () => container(() => action.UpdateSceneAction(this, new EventArgs()), new EventArgs());
        }
    }
}
