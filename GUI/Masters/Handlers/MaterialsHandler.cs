using BazisGUI.Masters.Actions;
using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;

namespace BazisGUI.Masters.Handlers
{
    public class MaterialsHandler : MasterHandlerBase<IMaterialsHandling, MaterialAction>
    {
        private MaterialAction action;

        public override MaterialAction GetHandlerAction() => action;

        public override void SetHandlerAction(MaterialAction act) => action = act;

        public override bool CanHandle(Type interfaceType) =>
            typeof(IMaterialsHandling).IsAssignableFrom(interfaceType);

        public override void Handle(IMaterialsHandling instance)
        {
            if (action == null)
                throw new NullReferenceException($"Не определено действие обработчика MaterialHandler<{typeof(MaterialAction)}>");

            action.MaterialsAction += (s, e) => container(() => instance.SetMaterials(e.Materials), e);
        }
    }
}
