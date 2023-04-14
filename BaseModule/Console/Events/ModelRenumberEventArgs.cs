using System;

namespace BaseModule.Console.Events
{
    internal class ModelRenumberEventArgs : EventArgs
    {
        private string Cmd { get; }

        public ModelRenumberEventArgs(string cmd)
        {
            Cmd = cmd;
        }
    }
}