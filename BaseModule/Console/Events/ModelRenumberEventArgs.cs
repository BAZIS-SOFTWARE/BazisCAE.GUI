using System;

namespace BaseModule.Console.Events
{
    public class ModelRenumberEventArgs : EventArgs
    {
        private string Cmd { get; }

        public ModelRenumberEventArgs(string cmd)
        {
            Cmd = cmd;
        }
    }
}