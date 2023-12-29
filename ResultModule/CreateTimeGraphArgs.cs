using ModelInterfaces;
using System;

namespace ResultModule
{
    public class CreateTimeGraphArgs : EventArgs
    {
        public CreateTimeGraphArgs(ObjType objsType)
        {
            ObjsType = objsType;

        }
        public ObjType ObjsType { get; }
    }
}
