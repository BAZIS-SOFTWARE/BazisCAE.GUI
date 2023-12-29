using ModelInterfaces;
using System;

namespace BaseModule
{
    public class SelectInPlainEventArgs : EventArgs
    {
        public ObjType ObjsType { get; }
        public float Angle { get; }

        public SelectInPlainEventArgs(ObjType objsType, float angle)
        {
            ObjsType = objsType;
            Angle = angle;
        }
    }
}