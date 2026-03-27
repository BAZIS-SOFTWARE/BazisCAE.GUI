using Model.Interfaces;
using System;

namespace BazisGUI.AdvanceSelection
{
    public class SelectInPlainConfig : EventArgs
    {
        public ObjType Objects { get; }
        public float Angle { get; }

        public SelectInPlainConfig(ObjType objects, float angle)
        {
            Objects = objects;
            Angle = angle;
        }
    }
}