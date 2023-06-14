using System;

namespace TaskModule.WeldingModule.WeldingTypeControls
{
    public class WeldContainerCntrEventArgs : EventArgs
    {
        public WeldContainerCntrEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}