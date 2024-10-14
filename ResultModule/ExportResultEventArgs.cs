using ModelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultModule
{
    public class ExportResultEventArgs : EventArgs
    {
        public float Time { get; set; }
        public string ResName { get; set; }
        public string TaskKind{ get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }

        public ExportResultEventArgs(float time, string taskKind, string resName, string path, string extension)
        {
            Time = time;
            TaskKind = taskKind;
            ResName = resName;
            Path = path;
            Extension = extension;
        }
    }
}
