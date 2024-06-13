using ModelInterfaces;
using System;

namespace BaseModule.ControlsLib
{
    public class SelectObjectEventArgs : EventArgs
    {
        public ObjType ObjsType {get;}
        public SelectObjectEventArgs(ObjType objsType)
        {
            ObjsType = objsType;
        }
    }
}