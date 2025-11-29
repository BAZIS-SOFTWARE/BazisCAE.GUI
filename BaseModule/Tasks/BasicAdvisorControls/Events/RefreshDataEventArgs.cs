using System;

namespace BazisGUI.Tasks.BasicAdvisorControls.Events
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