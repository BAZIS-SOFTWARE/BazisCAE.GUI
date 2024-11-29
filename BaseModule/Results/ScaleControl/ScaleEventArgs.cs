using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule.Results.ScaleControl
{
    public class ScaleEventArgs : EventArgs
    {
        public float Max { get; }
        public float Min { get; }
        public int Precision { get; }
        public decimal Range { get; }
        public ScaleEventArgs(string max, string min, string precision, decimal range)
        {
            Max = float.Parse(max);
            Min = float.Parse(min);
            Precision = int.Parse(precision);
            Range = range;
        }       
    }
}
