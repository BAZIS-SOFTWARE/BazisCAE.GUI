using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;
using BazisGUI.Scene;
using MathNet.Numerics.LinearAlgebra;

namespace BazisGUI
{
    public partial class BaseForm
    {
        event Action DisplayBasisEvent;
        public void DisplayBasis()
        {
            var met = new Action(() =>
            {
                var quadObj = Glu.gluNewQuadric();

                // draw "Z line"
                Gl.glPushMatrix();
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); // см. выше
                Gl.glTranslatef(-Position._x, -Position._y, -Position._z);
                Gl.glScalef(1 / ScaleFactor, 1 / ScaleFactor, 1 / ScaleFactor);
                Gl.glColor3d(0, 0, 1);
                Glu.gluCylinder(quadObj, 0.0015, 0.0015, 0.025, 10, 10); // рисуем цилиндр
                Gl.glPopMatrix();

                //draw "Y line"
                Gl.glPushMatrix();
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); // см. выше
                Gl.glTranslatef(-Position._x, -Position._y, -Position._z);
                Gl.glScalef(1 / ScaleFactor, 1 / ScaleFactor, 1 / ScaleFactor);
                Gl.glColor3d(0, 1, 0);
                Gl.glRotatef(-90, 1, 0, 0);
                Glu.gluCylinder(quadObj, 0.0015, 0.0015, 0.025, 10, 10); // рисуем цилиндр
                Gl.glPopMatrix();


                // draw "X line"
                Gl.glPushMatrix();
                Gl.glTranslatef(-Position._x, -Position._y, -Position._z);
                Gl.glScalef(1 / ScaleFactor, 1 / ScaleFactor, 1 / ScaleFactor);
                Gl.glRotatef(90, 0, 1, 0);
                Gl.glColor3d(1, 0.5f, 0);
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); // см. выше
                Glu.gluCylinder(quadObj, 0.0015, 0.0015, 0.025, 10, 10); // рисуем цилиндр
                Gl.glPopMatrix();


                //draw "X tip"
                Gl.glPushMatrix();
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); // см. выше
                Gl.glTranslatef(-Position._x, -Position._y, -Position._z);
                Gl.glScalef(1 / ScaleFactor, 1 / ScaleFactor, 1 / ScaleFactor);
                Gl.glColor3d(1, 0.5f, 0);
                Gl.glTranslatef(0.025f, 0, 0);
                Gl.glRotatef(90, 0, 1, 0);
                Glu.gluCylinder(quadObj, 0.0025, 0, 0.01, 10, 10); // рисуем цилиндр
                Gl.glPopMatrix();

                //draw "Y tip"
                Gl.glPushMatrix();
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); // см. выше
                Gl.glTranslatef(-Position._x, -Position._y, -Position._z);
                Gl.glScalef(1 / ScaleFactor, 1 / ScaleFactor, 1 / ScaleFactor);
                Gl.glColor3d(0, 1, 0);
                Gl.glTranslatef(0, 0.025f, 0);
                Gl.glRotatef(-90, 1, 0, 0);
                Glu.gluCylinder(quadObj, 0.0025, 0, 0.01, 10, 10); // рисуем цилиндр
                Gl.glPopMatrix();

                //draw "Z tip"
                Gl.glPushMatrix();
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); // см. выше
                Gl.glTranslatef(-Position._x, -Position._y, -Position._z);
                Gl.glScalef(1 / ScaleFactor, 1 / ScaleFactor, 1 / ScaleFactor);
                Gl.glColor3d(0, 0, 1);
                Gl.glTranslatef(0, 0, 0.025f);
                Glu.gluCylinder(quadObj, 0.0025, 0, 0.01, 10, 10); // рисуем цилиндр
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
                Gl.glTranslatef(-Position._x, -Position._y, -Position._z);
                Gl.glColor3f(1, 1, 0);

                Gl.glScalef(1 / ScaleFactor, 1 / ScaleFactor, 1 / ScaleFactor);
                Glu.gluSphere(quadObj, 0.002, 10, 10); // рисуем сферу
                Gl.glPopMatrix();

                Glu.gluDeleteQuadric(quadObj);
            });
            DisplayBasisEvent += met;
        }
    }
}
