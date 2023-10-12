using Geometry;

namespace BaseModule.CrossSection
{
    public class CreatePlaneFromTextArgs
    {
        public Point3D point1 { get; }
        public Point3D point2 { get; }
        public Point3D point3 { get; }

        public CreatePlaneFromTextArgs(Point3D point1, Point3D point2, Point3D point3)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }
    }
}
