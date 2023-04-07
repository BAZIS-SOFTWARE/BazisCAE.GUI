using System;

namespace BasicAdvisorControls.Interfaces
{
    public class ChangeDataEventArgs : EventArgs
    {
        public ChangeDataEventArgs(string dataName, int index, string dataInfo)
        {
            DataName = dataName;
            Index = index;
            DataInfo = dataInfo;
        }

        public string DataName { get; }
        public int Index { get; }
        public string DataInfo { get; }
    }
}