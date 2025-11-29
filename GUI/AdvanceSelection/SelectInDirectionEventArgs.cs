using Model.Interfaces;
using System;

namespace BazisGUI.AdvanceSelection
{
    public class SelectInDirectionEventArgs : EventArgs
    {
        public ObjType Objects { get; }

        public bool Reverse { get; }

        public float Angle { get; }

        public SelectInDirectionEventArgs(ObjType objects, bool reverse, float angle)
        {
            Objects = objects;
            Reverse = reverse;
            Angle = angle;
        }
    }
}