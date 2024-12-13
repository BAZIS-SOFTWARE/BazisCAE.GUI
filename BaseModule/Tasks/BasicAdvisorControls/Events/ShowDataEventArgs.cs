using System;
using System.Collections.Generic;

namespace BaseModule.Tasks.BasicAdvisorControls.Events
{
    public class ShowDataEventArgs : EventArgs
    {
        public ShowDataEventArgs(string dataName, List<int> indexes)
        {
            this.indexes = indexes;
            DataName = dataName;
        }

        List<int> indexes;
        public string DataName { get; }

        public IEnumerable<int> GetDataInfo()
        {
            foreach (var index in indexes)
            {
                yield return index;
            }
        }
    }
}