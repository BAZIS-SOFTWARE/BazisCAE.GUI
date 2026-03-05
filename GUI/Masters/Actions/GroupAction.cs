using BazisGUI.Args;
using BazisGUI.Masters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Masters.Actions
{
    public class GroupAction : IHandlerAction
    {
        public Action<GroupCreationEventArgs> GroupCreationAction { get; set; }
        public Action<GroupRenameEventArgs> GroupRenameAction { get; set; }
        public Action<GroupDeleteEventArgs> GroupDeleteAction { get; set; }
        public Action<GroupDeleteAllEventArgs> GroupDeleteAllAction { get; set; }
        public Action<GroupInitializeEventArgs> GroupInitializeAction { get; set; }
    }
}
