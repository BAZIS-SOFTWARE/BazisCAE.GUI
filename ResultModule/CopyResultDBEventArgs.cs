using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultModule
{
    public class CopyResultDBEventArgs : EventArgs
    {
        public string TaskKind { get; set; }
        public float Time { get; set; }

        public CopyResultDBEventArgs(string taskKind, float time)
        {
            TaskKind = taskKind;
            Time = time;
        }
    }
}
