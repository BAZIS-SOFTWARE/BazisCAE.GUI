using MasterInterface.Interfaces;

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
