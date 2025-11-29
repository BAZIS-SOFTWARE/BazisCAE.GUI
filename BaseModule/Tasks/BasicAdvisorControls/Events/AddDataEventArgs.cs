using System;

namespace BazisGUI.Tasks.BasicAdvisorControls.Events
{
    public class AddDataEventArgs : EventArgs
    {
        public AddDataEventArgs(string dataName, string dataInfo)
        {
            DataInfo = dataInfo;
            DataName = dataName;
        }

        public string DataInfo { get; }
        public string DataName { get; }
    }
}