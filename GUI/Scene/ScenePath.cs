
using Geometry;
using Tao.OpenGl;

namespace BazisGUI.Scene
{
    public class ScenePath
    {
        public float Length { get; }

        Point3D [] coords { get; }

        public Point3D this[int ind]
        { get { return coords[ind]; } }

        public int PointsQuantity { get { return coords.Length; } }

        public ScenePath(Point3D[] Coords)
        {
            var path = 0.0f;
            coords = new Point3D[Coords.Length];
            for (int i = 0; i < Coords.Length - 1; i++)
            {
                coords[i] = Coords[i];
                coords[i + 1] = Coords[i + 1];
                var p0 = Coords[i];
                var p1 = Coords[i + 1];

                path = path + new Segment3D(p0, p1).GetLength();
            }
            Length = path;
        }
        public void Display(Point3D position)
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(-position._x, -position._y, -position._z);

            Gl.glLineWidth(5.0f);
            Gl.glBegin(Gl.GL_LINES);

            for (int i = 0; i < coords.Length - 1; i++)
            {
                var p0 = coords[i];
                var p1 = coords[i + 1];


                Gl.glColor3f(1, 0, 0);
                Gl.glVertex3f(p0._x, p0._y, p0._z);
                Gl.glVertex3f(p1._x, p1._y, p1._z);
            }
            Gl.glEnd();

            Gl.glPointSize(12.5f);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex3f(coords[0]._x, coords[0]._y, coords[0]._z);
            Gl.glVertex3f(coords[coords.Length - 1]._x, coords[coords.Length - 1]._y, coords[coords.Length - 1]._z);
            Gl.glEnd();
            Gl.glPopMatrix();
        }
    }
}
