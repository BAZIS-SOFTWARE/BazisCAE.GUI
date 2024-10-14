using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultModule
{
    public class CopyResultDBEventArgs : EventArgs
    {
        string TasksResults { get; set; }
        float Time { get; set; }

        public CopyResultDBEventArgs(string tasksResults, float time)
        {
            TasksResults = tasksResults;
            Time = time;
        }
    }
}
