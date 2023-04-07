using System;

namespace BaseModule
{

    public enum MeasureKind
    {
        DistanceNodeToNode,
        DistanceNodeToPlane,
        Path,
        Square,
        Volume
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
