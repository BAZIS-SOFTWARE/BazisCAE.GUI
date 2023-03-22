using System;

namespace BaseControl
{
    public class SelectInPlainEventArgs : EventArgs
    {
        public string ObjsType { get; }
        public float Angle { get; }

        public SelectInPlainEventArgs(string objsType, float angle)
        {
            ObjsType = objsType;
            Angle = angle;
        }
    }
}