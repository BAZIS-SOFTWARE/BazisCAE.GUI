using System;

namespace BazisGUI.Tasks.BasicAdvisorControls.Events
{
    public class ChangeTaskTypeEventArgs : EventArgs
    {
        public ChangeTaskTypeEventArgs(int index)
        {
            Index = index;
        }

        public int Index { get; }
    }
}