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
        public ObjType ObjType { get; } = ObjType.Узел;
        public string ResName { get; set; }
        public string Path { get; set; }

        public ExportResultEventArgs(float time, string resName, string path)
        {
            Time = time;
            ResName = resName;
            Path = path;
        }
    }
}
