using System;
using static BazisGUI.Interfaces.GeneralParams;

namespace BazisGUI
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