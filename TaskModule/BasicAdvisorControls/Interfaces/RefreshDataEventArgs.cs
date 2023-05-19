using System;

namespace BasicAdvisorControls
{
    public class RefreshDataEventArgs : EventArgs
    {
        public RefreshDataEventArgs(bool state)
        {
            State = state; 
        }

        public bool State { get; }
    }
}