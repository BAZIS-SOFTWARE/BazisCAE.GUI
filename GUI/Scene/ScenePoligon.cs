
using Geometry;
using System.Drawing;
using Tao.OpenGl;

namespace Scene
{
    public class ScenePoligon
    {
        public Color Color { get; }
        public Point3D [] Pnts { get; }

        Point3D cameraPosition;

        public ScenePoligon(Point3D [] pnts, Color color, Point3D cameraPosition)
        {
            Pnts = pnts;
            Color = color;
            this.cameraPosition = cameraPosition;
        }

        public void Display()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(-cameraPosition._x, -cameraPosition._y, -cameraPosition._z);
            Gl.glColor3b(Color.R, Color.G, Color.B);
            Gl.glLineWidth(5.0f);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            for (int i = 0; i < Pnts.Length; i++)
            {
                Gl.glVertex3f(Pnts[i]._x, Pnts[i]._y, Pnts[i]._z); // Top Left
            }
            Gl.glEnd();
            Gl.glPopMatrix();
        }
    }
}
