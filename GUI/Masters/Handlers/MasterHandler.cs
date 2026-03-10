using BazisGUI.Masters.Actions;
using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;

namespace BazisGUI.Masters.Handlers
{
    public class MasterHandler : MasterHandlerBase<IBaseMasterInterface, MasterAction>
    {
        private MasterAction action;
        
        public override MasterAction GetHandlerAction() => action;

        public override void SetHandlerAction(MasterAction act) => action = act;

        public override bool CanHandle(Type interfaceType) =>
            typeof(IBaseMasterInterface).IsAssignableFrom(interfaceType);

        public override void Handle(IBaseMasterInterface instance)
        {
            if (action == null)
                throw new NullReferenceException($"Не определено действие обработчика GroupHandler<{typeof(MasterAction)}>");

            instance.GenerateConditionsEvent += (s, e) => container(() => action.GenerateConditionsAction(s, e), e);
            instance.PrintInfoEvent += (s, e) => container(() => action.PrintInfoAction(s, e), e);
            instance.UpdateSceneEvent += (s, e) => container(() => action.UpdateSceneAction(s, e), e);
            instance.OnMasterLoaded += (s, e) => container(() => action.OnMasterLoaded(s, e), e);
        }
    }
}
