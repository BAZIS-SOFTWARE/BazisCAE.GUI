using Model.Interfaces;
using System;
using System.Collections.Generic;

namespace BazisGUI.AdvanceSelection
{
    public class SelectInDirectionEventArgs : EventArgs 
    {
        public ObjType Objects { get; }

        public bool Reverse { get; set; }

        public float Angle { get; }

        public int? FirstNodeDirection { get; set; }

        public int? SecondNodeDirection { get; set; }

        public List<int> SelectedNumbers { get; protected set; }

        public SelectInDirectionEventArgs(ObjType objects, bool reverse, float angle, int? first = null, int? second = null)
        {
            Objects = objects;
            Reverse = reverse;
            Angle = angle;
            FirstNodeDirection = first;
            SecondNodeDirection = second;
        }

        public void SetNumbers(List<int> numbers) 
        {
            SelectedNumbers = numbers;
        }
    }
}