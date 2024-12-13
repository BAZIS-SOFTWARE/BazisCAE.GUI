using System;

namespace BaseModule.Tasks.BasicAdvisorControls.Events
{
    public class HideDataEventArgs : EventArgs
    {
        public HideDataEventArgs(string dataName)
        {
            DataName = dataName;
        }

        public string DataName { get; }
    }
}