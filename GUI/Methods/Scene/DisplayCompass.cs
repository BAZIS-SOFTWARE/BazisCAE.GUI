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
        event Action DisplayCompassEvent;

        public void DisplayCompass()
        {
            var viewMatrix = new float[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            var met = new Action(() =>
            {
                Gl.glDisable(Gl.GL_DEPTH);
                Array.Copy(ViewMatrix.ToArray(), viewMatrix, 16);

                Initialize_GUI_Plane(scene.Width, scene.Height);

                float[] matrix = Matrix<float>.Build.DenseOfArray(viewMatrix).AsColumnMajorArray();

                matrix[14] = -60;
                matrix[12] = 70;
                matrix[13] = 70;

                Gl.glLoadMatrixf(matrix);

                Gl.glScalef(1 / ScaleFactor, 1 / ScaleFactor, 1 / ScaleFactor);

                Gl.glPushMatrix();

                Gl.glLineWidth(3.0f);
                Gl.glBegin(Gl.GL_LINES);

                // draw "Z"
                Gl.glColor3f(0, 0, 1);
                Gl.glVertex3f(0.0f, 0.0f, 0.0f);
                Gl.glVertex3f(0.0f, 0.0f, 50.0f);


                // draw "Y"
                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(0.0f, 0.0f, 0.0f);
                Gl.glVertex3f(0.0f, 50.0f, 0.0f);


                // draw "X"
                Gl.glColor3f(1, 0.5f, 0);
                Gl.glVertex3f(0.0f, 0.0f, 0.0f);
                Gl.glVertex3f(50.0f, 0.0f, 0.0f);

                Gl.glEnd();
                Gl.glPopMatrix();

                var quadObj = Glu.gluNewQuadric();
                //draw "X tip"
                Gl.glPushMatrix();
                Gl.glColor3d(1, 0.5f, 0);
                Gl.glTranslatef(40, 0, 0);
                Gl.glRotatef(90, 0, 1, 0);
                Glu.gluCylinder(quadObj, 4, 0, 10, 10, 10); // рисуем цилиндр
                Gl.glPopMatrix();

                //draw "Y tip"
                Gl.glPushMatrix();
                Gl.glColor3d(0, 1, 0);
                Gl.glTranslatef(0, 40, 0);
                Gl.glRotatef(-90, 1, 0, 0);
                Glu.gluCylinder(quadObj, 4, 0, 10, 10, 10); // рисуем цилиндр
                Gl.glPopMatrix();

                //draw "Z tip"
                Gl.glPushMatrix();
                Gl.glColor3d(0, 0, 1);
                Gl.glTranslatef(0, 0, 40);
                Glu.gluCylinder(quadObj, 4, 0, 10, 10, 10); // рисуем цилиндр

                Glu.gluDeleteQuadric(quadObj);

                Gl.glPopMatrix();

                DisplayText("X", Color.FromArgb(0, 0, 0), new Point3D(60, 0, 0));
                DisplayText("Y", Color.FromArgb(0, 0, 0), new Point3D(0, 60, 0));
                DisplayText("Z", Color.FromArgb(0, 0, 0), new Point3D(0, 0, 60));

                Finish_GUI_Plane();
                Gl.glEnable(Gl.GL_DEPTH);
            });

            DisplayCompassEvent += met;
        }

        public void DisplayText(string str, Color color, Point3D coord)
        {
            Gl.glPushMatrix();
            Gl.glColor3b(color.R, color.G, color.B);
            Gl.glRasterPos3f(coord._x, coord._y, coord._z);
            Gl.glPushAttrib(Gl.GL_LIST_BASE);//Избегаем пересечений списков, сохраняем старую базу
            Gl.glListBase(FontBase);//Устанавливаем базу на FontBase
            Gl.glCallLists(str.Length, Gl.GL_UNSIGNED_SHORT, str);
            Gl.glPopAttrib();//Возвращаем старую базу
            Gl.glPopMatrix();
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
    }
}
