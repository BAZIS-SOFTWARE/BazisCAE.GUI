using BazisGUI.Masters.Actions;
using BazisGUI.Masters.Interfaces;
using MasterInterface.Interfaces;
using System;

namespace BazisGUI.Masters.Handlers
{
    public class MaterialsHandler : MasterHandlerBase<IMaterialsHandling>
    {
        private MaterialAction action;

        public override IHandlerAction GetHandlerAction() => action;

        public override void SetHandlerAction(IHandlerAction act)
        {
            if (act is MaterialAction ma)
                action = ma;
            else throw new ArgumentException("Передан некорректный параметр действия для обработчика");
        }

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
