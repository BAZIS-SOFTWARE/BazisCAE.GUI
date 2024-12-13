

using BaseModule.Tasks.BasicAdvisorControls.Events;

namespace BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls
{
    public class GenerateTSFEventArgs : AddDataEventArgs
    {
        public TaskParameters TaskParameters { get; }

        public GenerateTSFEventArgs(TaskParameters taskParameters, string dataName, string dataInfo):
            base(dataName, dataInfo)
        {
            TaskParameters = taskParameters;
        }
    }
}