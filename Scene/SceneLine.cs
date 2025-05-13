
using Geometry;
using System.Drawing;
using Tao.OpenGl;

namespace Scene
{
    public class SceneLine
    {
        public Color Color { get; }
        Segment3D line;

        public float Length { get { return line.GetLength(); } }

        public Point3D P0 { get { return line.P0; } }
        public Point3D P1 { get { return line.P1; } }

        public Point2D Centre { get; internal set; }

        Point3D cameraPosition;

        public SceneLine(Point3D p0, Point3D p1, Color color, Point3D cameraPosition)
        {
            line = new Segment3D(p0, p1);
            Color = color;
            this.cameraPosition = cameraPosition;
        }

        public SceneLine(Segment3D line, Color color, Point3D cameraPosition)
        {
            this.line = new Segment3D(line.P0,line.P1);
            Color = color;
            this.cameraPosition = cameraPosition;
        }

        public void Display()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(-cameraPosition._x, -cameraPosition._y, -cameraPosition._z);
            Gl.glColor3b(Color.R, Color.G, Color.B);
            Gl.glLineWidth(5.0f);
            Gl.glBegin(Gl.GL_LINES);
            
            Gl.glVertex3f(line.P0._x, line.P0._y, line.P0._z);
            Gl.glVertex3f(line.P1._x, line.P1._y, line.P1._z);
            Gl.glEnd();
            Gl.glPopMatrix();
        }
    }
}
