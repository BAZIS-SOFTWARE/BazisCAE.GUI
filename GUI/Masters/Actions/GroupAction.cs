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
        public EventHandler<GroupCreationEventArgs> GroupCreationAction { get; set; }
        public EventHandler<GroupRenameEventArgs> GroupRenameAction { get; set; }
        public EventHandler<GroupDeleteEventArgs> GroupDeleteAction { get; set; }
        public EventHandler<GroupDeleteAllEventArgs> GroupDeleteAllAction { get; set; }
        public EventHandler<GroupInitializeEventArgs> GroupInitializeAction { get; set; }
        public EventHandler<EventArgs> OnGroupsFillingRequested { get; set; }
    }
}
