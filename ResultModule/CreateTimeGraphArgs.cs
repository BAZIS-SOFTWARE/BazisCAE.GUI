using ModelInterfaces;
using System;

namespace ResultModule
{
    public class CreateTimeGraphArgs : EventArgs
    {
        public CreateTimeGraphArgs(ObjType objsType, string resKind)
        {
            ObjsType = objsType;
            ResultKind = resKind;
        }
        public ObjType ObjsType { get; }

        public string ResultKind { get; }
    }
}
