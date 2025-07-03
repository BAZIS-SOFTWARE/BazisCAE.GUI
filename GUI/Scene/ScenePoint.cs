using Geometry;
using System.Drawing;
using Tao.OpenGl;

namespace Scene
{
    public class ScenePoint
    {
        Point3D cameraPosition;
        public Color Color { get; }
        public Point3D P0 { get; set; }

        public float Size { get; set; }

        public ScenePoint(Point3D p0, float size, Color color, Point3D cameraPosition)
        {
            P0 = p0;
            Size = size;
            Color = color;
            this.cameraPosition = cameraPosition;
        }

        public void Display()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(-cameraPosition._x, -cameraPosition._y, -cameraPosition._z);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glPointSize(Size);
            Gl.glColor3b(Color.R, Color.G, Color.B);
            Gl.glVertex3f(P0._x, P0._y, P0._z);
            Gl.glEnd();
            Gl.glPopMatrix();
        }
    }
}
