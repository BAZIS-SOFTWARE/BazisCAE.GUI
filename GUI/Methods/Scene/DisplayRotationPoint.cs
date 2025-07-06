using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;
using BazisGUI.Scene;

namespace BazisGUI
{
    public partial class BaseForm
    {
        event Action DisplayRotationPointEvent;
        private Action CreateRotationPoint()
        {
            return new Action(() =>
            {
                Gl.glPushMatrix();
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
                Gl.glColor3f(1, 0.75f, 0);

                var quadObj = Glu.gluNewQuadric();

                Gl.glScalef(1 / scaleFactor, 1 / scaleFactor, 1 / scaleFactor);
                Glu.gluSphere(quadObj, 0.003, 10, 10); // рисуем сферу
                Gl.glPopMatrix();
                Glu.gluDeleteQuadric(quadObj);
            });
        }
    }
}
