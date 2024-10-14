using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultModule
{
    public class CopyResultDBEventArgs : EventArgs
    {
        public string TaskKInd { get; set; }
        public float Time { get; set; }

        public CopyResultDBEventArgs(string taskKind, float time)
        {
            TaskKInd = taskKind;
            Time = time;
        }
    }
}
