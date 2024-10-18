using ProjectInterfaces;
using TaskModule.BasicAdvisorControls.Events;
using TasksParameters;

namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    internal class GenerateTSFEventArgs : AddDataEventArgs
    {
        public GeneralParameters Parameters { get; }

        public GenerateTSFEventArgs(GeneralParameters parameters, string dataName, string dataInfo) : 
            base(dataName, dataInfo)
        {
            Parameters = parameters;

        }
    }
}