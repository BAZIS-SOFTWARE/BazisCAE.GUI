using System;

namespace BaseModule
{
    public class SelectInDirectionEventArgs : EventArgs
    {
        public string ObjsType { get; }

        public bool Reverse { get; }

        public float Angle { get; }

        public SelectInDirectionEventArgs(string objsType, bool reverse, float angle)
        {
            ObjsType = objsType;
            Reverse = reverse;
            Angle = angle;
        }
    }
}