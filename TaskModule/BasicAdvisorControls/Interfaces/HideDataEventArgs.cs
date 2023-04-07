using System;

namespace BasicAdvisorControls.Interfaces
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