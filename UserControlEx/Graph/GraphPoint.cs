using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlsEx.Graph
{
    public class GraphPoint
    {
        public float X { get; }
        public float Y { get; }

        public GraphPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            var x = X.ToString("0.00");
            var y = Y.ToString("0.00");
            return string.Format("{0};{1}", x, y);
        }
    }
}
