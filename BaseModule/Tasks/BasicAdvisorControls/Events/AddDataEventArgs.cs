using System;
using System.Collections.Generic;

namespace BaseModule.Tasks.BasicAdvisorControls.Events
{
    public class AddDataEventArgs : EventArgs
    {
        public AddDataEventArgs(string dataName, string dataInfo, List<string> movedFrame = null)
        {
            DataInfo = dataInfo;
            DataName = dataName;
            MovedFrame = movedFrame;
        }

        public string DataInfo { get; }
        public string DataName { get; }
        public List<string> MovedFrame { get; }
    }
}