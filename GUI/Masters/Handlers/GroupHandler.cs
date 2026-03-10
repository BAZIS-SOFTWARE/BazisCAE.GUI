using BazisGUI.Masters.Actions;
using BazisGUI.Masters.Interfaces;
using MasterInterface;
using MasterInterface.Interfaces;
using System;
using System.Collections.Generic;

namespace BazisGUI.Masters.Handlers
{
    public class GroupHandler : MasterHandlerBase<IGroupHandling, GroupAction>
    {
        private GroupAction action;

        public override GroupAction GetHandlerAction() => action;

        public override void SetHandlerAction(GroupAction act) => action = act;

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
