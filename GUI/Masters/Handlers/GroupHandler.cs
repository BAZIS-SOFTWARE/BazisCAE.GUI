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
    public class GroupHandler<T, U> : IMasterInterfaceHandler<T, U> 
        where T : IGroupHandling
        where U : GroupAction
    {
        private U action;

        public void SetHandlerAction(U act) => action = act;
        public U GetHandlerAction() => action;

        public void Handle(T instance)
        {
            if (action == null)
                throw new NullReferenceException($"Не определено действие обработчика GroupHandler<{typeof(U)}>");

            if (instance == null)
                throw new ArgumentNullException($"Объект класса {typeof(T)} не определен до обработки");

            action.GroupCreationAction += (sender, args) => instance.AddGroup(Converter.GetGroupTypeFromString(args.Type.ToString()), args.Index, args.Name);
            action.GroupRenameAction += (sender,args) => instance.RenameGroup(Converter.GetGroupTypeFromString(args.Type.ToString()), args.Index, args.Name);
            action.GroupDeleteAction += (sender,args) => instance.DeleteGroup(Converter.GetGroupTypeFromString(args.Type.ToString()), args.Index);
            action.GroupDeleteAllAction += (sender, args) => instance.DeleteAllGroups();
            action.GroupInitializeAction += (sender, args) =>
            {
                var dict = new Dictionary<GroupType, Dictionary<int, string>>();
                foreach (var objType in args.Groups.Keys)
                {
                    var groupType = Converter.GetGroupTypeFromString(objType.ToString());
                    dict[groupType] = args.Groups[objType];
                }
                instance.InitialGroupFilling(dict);
            };
        }
    }
}
