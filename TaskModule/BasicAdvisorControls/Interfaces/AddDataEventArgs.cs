using System;

namespace BasicAdvisorControls.Interfaces
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