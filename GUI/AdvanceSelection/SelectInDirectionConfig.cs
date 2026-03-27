using Model.Interfaces;
using System;

namespace BazisGUI.AdvanceSelection
{
    public class SelectInDirectionConfig : EventArgs
    {
        public ObjType Objects { get; }

        public bool Reverse { get; set; }

        public float Angle { get; }

        public int? FirstNodeDirection { get; set; }

        public int? SecondNodeDirection { get; set; }

        public SelectInDirectionConfig(ObjType objects, bool reverse, float angle, int? first = null, int? second = null)
        {
            Objects = objects;
            Reverse = reverse;
            Angle = angle;
            FirstNodeDirection = first;
            SecondNodeDirection = second;
        }
    }
}