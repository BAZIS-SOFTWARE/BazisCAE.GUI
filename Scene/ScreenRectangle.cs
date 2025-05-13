using Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace Scene
{
    public class ScreenRectangle
    {
        public Point winScrenePosit;
        public Point winScreneCoord;

        public float Red { get; set; }
        public float Green { get; set; } = 0.75f;
        public float Blue { get; set; }

        public ScreenRectangle()
        {
            winScrenePosit = new Point(0, 0);
        }

        public void Remove()
        {
            winScreneCoord.X = 0; winScreneCoord.Y = 0;
            winScrenePosit.X = 0; winScrenePosit.Y = 0;
        }

        private void Initialize_GUI_Plane(int width, int height)
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glOrtho(0, width, 0, height, 0.1, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
        }

        private void Finish_GUI_Plane()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPopMatrix();
        }
        public void Display(int width, int height)
        {
            Initialize_GUI_Plane(width, height);
            {
                Gl.glTranslatef(0, 0, -0.1f);
                Gl.glPushMatrix();
                Gl.glColor3f(Red, Green, Blue);
                Gl.glLineWidth(1.5f);
                Gl.glBegin(Gl.GL_LINE_LOOP);

                Gl.glVertex2f(winScrenePosit.X, winScrenePosit.Y);
                Gl.glVertex2f(winScreneCoord.X, winScrenePosit.Y);
                Gl.glVertex2f(winScreneCoord.X, winScreneCoord.Y);
                Gl.glVertex2f(winScrenePosit.X, winScreneCoord.Y);

                Gl.glEnd();
                Gl.glPopMatrix();
            }

            Finish_GUI_Plane();
        }
    }
}
