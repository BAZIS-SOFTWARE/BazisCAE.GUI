using System;

namespace BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls
{
    [Serializable]
    public class ComputationToken
    {
        public TimeParameters TimeParam;
        public TasksSet TasksSet;
        public int TaskIndex;
        public bool FurtherComputation;
        public string PreviouseComputationDB = "";

        public ComputationToken(TasksSet tasksSet, int taskIndex, TimeParameters timeParam)
        {
            TimeParam = timeParam;
            TasksSet = tasksSet;
            TaskIndex = taskIndex;
        }
    }
}