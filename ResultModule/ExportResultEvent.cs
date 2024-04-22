using ModelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultModule
{
    public class ExportResultEvent : EventArgs
    {
        public float Time { get; set; }
        public ObjType ObjType { get; set; }
        public string ResName { get; set; }

        public ExportResultEvent(float time, ObjType objType, string resName)
        {
            Time = time;
            ObjType = objType;
            ResName = resName;
        }
    }
}
