using BazisGUI.Scripting;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void HandleScriptLoadRequested(string path)
        {
            var scriptExecuter = new ScriptExecutor();
            scriptExecuter.CommandEnteredEvent += ExecuteCommand;
            scriptExecuter.ReadFileScript(path);
        }
    }
}
