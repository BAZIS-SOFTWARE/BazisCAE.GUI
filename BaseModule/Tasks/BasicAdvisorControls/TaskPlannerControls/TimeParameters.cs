using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls
{
    [Serializable]
    public class TimeParameters
    {
        public float StartTime;
        public float StopTime;
        public float InitTimeStep;
        public float MinTimeStep;
        public float MaxTimeStep;

        public TimeParameters(float startTime, float stopTime, float maxTimeStep, float minTimeStep, float iniTimeStep)
        {
            StartTime = startTime;
            StopTime = stopTime;
            MinTimeStep = maxTimeStep;
            MaxTimeStep = minTimeStep;
            InitTimeStep = iniTimeStep;
        }
    }
}
