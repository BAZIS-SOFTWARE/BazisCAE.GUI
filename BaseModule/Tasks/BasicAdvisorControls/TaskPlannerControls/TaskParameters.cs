using System;

namespace BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls
{
    [Serializable]
    public class TaskParameters
    {
        public TimeParameters TimeParam;
        public TaskKind TaskKind;
        public int TaskIndex;

        public TaskParameters(TaskKind taskKind, int taskIndex, TimeParameters timeParam)
        {
            TimeParam = timeParam;
            TaskKind = taskKind;
            TaskIndex = taskIndex;
        }
    }
}