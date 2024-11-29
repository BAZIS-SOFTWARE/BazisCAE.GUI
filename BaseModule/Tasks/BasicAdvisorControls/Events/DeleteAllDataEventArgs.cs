using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule.BasicAdvisorControls.Events
{
    public class DeleteAllDataEventArgs : EventArgs
    {
        public DeleteAllDataEventArgs(string dataName)
        {
            DataName = dataName;
        }

        public string DataName { get; }
    }
}
