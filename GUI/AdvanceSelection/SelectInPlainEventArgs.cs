using Model.Interfaces;
using System;
using System.Collections.Generic;

namespace BazisGUI.AdvanceSelection
{
    public class SelectInPlainEventArgs : EventArgs
    {
        public ObjType Objects { get; }
        public float Angle { get; }

        public int? FirstNodeForPlane { get; set; }

        public int? SecondNodeForPlane { get; set; }

        public int? ThirdNodeForPlane { get; set; }

        public List<int> SelectedNumbers { get; set; }
        public SelectInPlainEventArgs(ObjType objects, float angle)
        {
            Objects = objects;
            Angle = angle;
        }
    }
}