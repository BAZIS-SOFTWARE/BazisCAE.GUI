
using Geometry;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace BazisGUI.Console
{
    public class CreateMesh2DPoligonEventArgs
    {
        public Point2D p1;
        public Point2D p2;
        public Point2D p3;
        public Point2D p4;
        public int NumberOfElems;

        public CreateMesh2DPoligonEventArgs(string v1, string v2, string v3, string v4,string numberOfElems)
        {
            var c1 = v1.Split(',').Select(x => float.Parse(x)).ToArray();
            p1 = new Point2D(c1[0], c1[1]);

            var c2 = v2.Split(',').Select(x => float.Parse(x)).ToArray();
            p2 = new Point2D(c2[0], c2[1]);

            var c3 = v3.Split(',').Select(x => float.Parse(x)).ToArray();
            p3 = new Point2D(c3[0], c3[1]);

            var c4 = v4.Split(',').Select(x => float.Parse(x)).ToArray();
            p4 = new Point2D(c4[0], c4[1]);

            NumberOfElems = int.Parse(numberOfElems);
        }
    }
}