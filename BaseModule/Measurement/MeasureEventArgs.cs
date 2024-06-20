using System;

namespace BaseModule
{

    public enum MeasureKind
    {
        DistancePointToPoint,
        DistancePointToPlane,
        Path,
        Square,
        Volume,
        None
    }
    public class MeasureEventArgs : EventArgs
    {

        public MeasureEventArgs(MeasureKind kind)
        {

            Kind = kind;
        }

        public MeasureKind Kind { get; }
    }
}
