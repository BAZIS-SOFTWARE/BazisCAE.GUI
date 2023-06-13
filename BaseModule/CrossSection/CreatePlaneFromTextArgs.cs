using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModule.CrossSection
{
    public class CreatePlaneFromTextArgs
    {
        public Point3D point1 { get; }
        public Point3D point2 { get; }
        public Point3D point3 { get; }

        public bool ShowModel { get; }

        public CreatePlaneFromTextArgs(Point3D point1, Point3D point2, Point3D point3, bool showModel)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;

            ShowModel = showModel;
        }
    }
}
