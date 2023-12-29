using ModelInterfaces;
using System;

namespace BaseModule.ToolStrips
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