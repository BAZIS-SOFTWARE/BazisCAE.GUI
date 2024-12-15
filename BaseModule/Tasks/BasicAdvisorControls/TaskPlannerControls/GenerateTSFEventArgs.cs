

using BaseModule.Tasks.BasicAdvisorControls.Events;

namespace BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls
{
    public class GenerateTSFEventArgs : AddDataEventArgs
    {
        public ComputationToken ComputationToken { get; }

        public GenerateTSFEventArgs(ComputationToken computationToken, string dataName, string dataInfo):
            base(dataName, dataInfo)
        {
            ComputationToken = computationToken;
        }
    }
}