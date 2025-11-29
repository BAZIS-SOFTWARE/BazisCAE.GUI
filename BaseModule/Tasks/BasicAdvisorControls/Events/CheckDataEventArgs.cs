using System;

namespace BazisGUI.Tasks.BasicAdvisorControls.Events
{
    public class CheckDataEventArgs : EventArgs
    {
        public CheckDataEventArgs(string dataName, float time)
        {
            DataName = dataName;
            Time = time;
        }

        public string DataName { get; }
        public float Time { get; }
    }
}