using BaseModule.Tasks.BasicAdvisorControls.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls
{
    public class ChangeTSFEventArgs : ChangeDataEventArgs
    {
        public ComputationToken ComputationToken { get; }
        public ChangeTSFEventArgs(ComputationToken computationToken,string dataName, int index, string dataInfo) 
            : base(dataName, index, dataInfo)
        {
            ComputationToken = computationToken;
        }
    }
}
