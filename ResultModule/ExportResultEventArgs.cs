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
        public ObjType ObjType { get; set; }
        public string ResName { get; set; }
        public string Path { get; set; }

        public ExportResultEventArgs(float time, ObjType objType, string resName, string path)
        {
            Time = time;
            ObjType = objType;
            ResName = resName;
            Path = path;
        }
    }
}
