using System;
using System.Collections.Generic;

namespace BaseModule.Tasks.BasicAdvisorControls.Events
{
    public class DeleteDataEventArgs : EventArgs
    {
        public DeleteDataEventArgs(string dataName, int index)
        {
            DataName = dataName;
            Index = index;
        }

        public string DataName { get; }
        public int Index { get; }
    }
}