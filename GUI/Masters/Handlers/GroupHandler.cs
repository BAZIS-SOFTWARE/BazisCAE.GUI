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
    public class MasterGroupHandler<T> : IMasterInterfaceHandler<T> where T : IGroupHandling
    {
        public Action<GroupType, int, string> CreateGroup;
        public Action<GroupType, int, string> RenameGroup;
        public Action<GroupType, int> DeleteGroup;
        public Action<Dictionary<GroupType, Dictionary<int, string>>> InitialGroupFilling;
        public Action DeleteAllGroups;

        public MasterGroupHandler(Action<Dictionary<GroupType, Dictionary<int, string>>> initialGroupFilling,
            Action<GroupType, int, string> createGroup,
            Action<GroupType, int, string> renameGroup,
            Action<GroupType, int> deleteGroup,
            Action deleteAllGroups)
        {
            CreateGroup = createGroup;
            RenameGroup = renameGroup;
            DeleteGroup = deleteGroup;
            InitialGroupFilling = initialGroupFilling;
            DeleteAllGroups = deleteAllGroups;
        }

        public void Handle(T instance)
        {
            CreateGroup += instance.AddGroup;
            RenameGroup += instance.RenameGroup;
            DeleteGroup += instance.DeleteGroup;
            DeleteAllGroups += instance.DeleteAllGroups;
            InitialGroupFilling += instance.InitialGroupFilling;
        }
    }
}
