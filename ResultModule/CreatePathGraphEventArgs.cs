using ModelInterfaces;
using System;

namespace ResultModule
{
    public class CreatePathGraphEventArgs : EventArgs
    {
        public CreatePathGraphEventArgs(ObjType objsType, string resName, float time )
        {
            var descr = resName.Split('_');
            ResultKind = descr[0];

            ObjsType = objsType;
            Time = time;
        }

        public string ResultKind { get; }
        public ObjType ObjsType { get; }
        public float Time { get; private set; }
    }
}