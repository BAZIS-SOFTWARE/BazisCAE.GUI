using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultModule
{
    public class CreateTimeGraphArgs : EventArgs
    {
        public CreateTimeGraphArgs(string objsType)
        {
            ObjsType = objsType;

        }
        public string ObjsType { get; }
    }
}
