using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultControl
{
    public class CreateTimeGraphArgs : EventArgs
    {
        public CreateTimeGraphArgs(string objsType, string resName)
        {
            ObjsType = objsType;

            var descr = resName.Split('_');
            ResultKind = descr[0];
        }
        public string ObjsType { get; }
        public string ResultKind { get; }
    }
}
