using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule.Results.Export
{
    public class CopyResultDBEventArgs : EventArgs
    {
        public string TaskKind { get; }
        public float Time { get; }
        public string DirPath { get; }

        public CopyResultDBEventArgs(string taskKind, float time, string dirPath)
        {
            TaskKind = taskKind;
            Time = time;
            DirPath = dirPath;
        }
    }
}
