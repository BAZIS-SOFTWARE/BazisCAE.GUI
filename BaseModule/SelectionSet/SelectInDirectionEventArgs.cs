using System;
using static BaseModule.Interfaces.GeneralParams;

namespace BaseModule
{
    public class SelectInDirectionEventArgs : EventArgs
    {
        public Objects Objects { get; }

        public bool Reverse { get; }

        public float Angle { get; }

        public SelectInDirectionEventArgs(Objects objects, bool reverse, float angle)
        {
            Objects = objects;
            Reverse = reverse;
            Angle = angle;
        }
    }
}