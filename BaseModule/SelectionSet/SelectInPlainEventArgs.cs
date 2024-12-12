using System;
using static BaseModule.Interfaces.GeneralParams;

namespace BaseModule
{
    public class SelectInPlainEventArgs : EventArgs
    {
        public Objects Objects { get; }
        public float Angle { get; }

        public SelectInPlainEventArgs(Objects objects, float angle)
        {
            Objects = objects;
            Angle = angle;
        }
    }
}