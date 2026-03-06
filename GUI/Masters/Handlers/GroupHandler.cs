using BazisGUI.Masters.Actions;
using BazisGUI.Masters.Interfaces;
using MasterInterface;
using MasterInterface.Interfaces;
using OperationalController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Masters.Handlers
{
    public class GroupHandler : MasterHandlerBase<IGroupHandling>
    {
        private GroupAction action;

        public override IHandlerAction GetHandlerAction() => action;

        public override void SetHandlerAction(IHandlerAction act)
        {
            if (act is GroupAction ga)
                action = ga;
            else throw new ArgumentException($"Передананное действие не соответствует обработчику. Вместо GroupAction, получено {action?.GetType()}");
        }

        public override bool CanHandle(Type interfaceType) =>
            typeof(IGroupHandling).IsAssignableFrom(interfaceType);

        public override void Handle(IGroupHandling instance)
        {
            if (action == null)
                throw new NullReferenceException($"Не определено действие обработчика GroupHandler<{typeof(GroupAction)}>");

            action.GroupCreationAction += (s, e) => container(() => instance.AddGroup(Converter.GetGroupTypeFromString(e.Type.ToString()), e.Index, e.Name), e);
            action.GroupRenameAction += (s, e) => container(() => instance.RenameGroup(Converter.GetGroupTypeFromString(e.Type.ToString()), e.Index, e.Name), e);
            action.GroupDeleteAction += (s, e) => container(() => instance.DeleteGroup(Converter.GetGroupTypeFromString(e.Type.ToString()), e.Index), e);
            action.GroupDeleteAllAction += (s, e) => container(() => instance.DeleteAllGroups(), e);
            action.GroupInitializeAction += (s, e) =>
            {
                container(() =>
                {
                    var dict = new Dictionary<GroupType, Dictionary<int, string>>();
                    foreach (var objType in e.Groups.Keys)
                    {
                        var groupType = Converter.GetGroupTypeFromString(objType.ToString());
                        dict[groupType] = e.Groups[objType];
                    }
                    instance.InitialGroupFilling(dict);
                }, e);
            };
        }
    }
}
