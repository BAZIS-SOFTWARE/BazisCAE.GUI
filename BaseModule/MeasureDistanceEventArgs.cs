using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseControl
{
    public class MeasureDistanceEventArgs : MeasureEventArgs
    {
        public ObjType FirstObj { get; }
        public ObjType SecondObj { get; }
        public MeasureDistanceEventArgs(ObjType firstObj, ObjType secondObj, MeasureCmd measureCmd) : base(measureCmd)
        {
            FirstObj = firstObj;
            SecondObj = secondObj;
        }
    }
}
