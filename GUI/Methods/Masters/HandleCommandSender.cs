using MasterInterface.Interfaces;
using System;
using System.Threading.Tasks;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void HandleCommandSenderMaster(ICommandSender commandSender)
        {
            commandSender.SetCommandExecutor(ExecuteCommand);
        }
    }
}
