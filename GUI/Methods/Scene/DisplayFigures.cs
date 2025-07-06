using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void DisplaySpiral(Point3D p0, Point3D p1, Color objColor)
        {
            Action met;

            met = new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                Gl.glPushMatrix();
                Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);
                Gl.glColor3ub(objColor.R, objColor.G, objColor.B);
                Gl.glLineWidth(5.0f);
                Gl.glBegin(Gl.GL_LINES);

                Gl.glVertex3f(p0._x, p0._y, p0._z);
                Gl.glVertex3f(p1._x, p1._y, p1._z);
                Gl.glEnd();
                Gl.glPopMatrix();
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });

            DisplayGeometryObjectEvent += met;
        }
        /// <inheritdoc/>


        public void DisplayConus(float UpperDiam, float BottomDiam, float length, Frame frame)
        {
            var upeer_rad = UpperDiam / 2;
            var lover_rad = BottomDiam / 2;

            DisplayGeometryObjectEvent += new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                var quadObj = Glu.gluNewQuadric(); // создаем новый объект
                                                   // для создания сфер и цилиндров
                                                   //Glu.gluQuadricOrientation(quadObj, Glu.GLU_OUTSIDE);
                Gl.glPushMatrix();
                Gl.glColor3d(1, 0, 0);
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);

                Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);

                //shifting
                Gl.glTranslatef(frame.Centre._x, frame.Centre._y, frame.Centre._z);

                //rotation z' and z global
                //var dirZ = frame.Z.Sub(frame.Centre);
                //var dirZnorm = Vector.GetVectorNorm(frame);
                var angleZ = Vector.GetCosAngleVectors(new Point3D(0, 0, 1), frame.Dir_Z);
                angleZ = (float)(Math.Acos(angleZ) * 180 / Math.PI);

                var axisZ = Vector.CrossProd(new Point3D(0, 0, 1), frame.Dir_Z);
                Gl.glRotatef(angleZ, axisZ._x, axisZ._y, axisZ._z);

                Gl.glTranslatef(0, 0, -length);

                Glu.gluCylinder(quadObj, lover_rad, upeer_rad, length, 10, 10); // рисуем конус

                Gl.glPopMatrix();
                Glu.gluDeleteQuadric(quadObj);
                averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });
        }
        /// <inheritdoc/>

        public void DisplaySphere(float width, Frame frame)
        {
            Action met;

            met = new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                var quadObj = Glu.gluNewQuadric(); // создаем новый объект
                                                   // для создания сфер и цилиндров
                                                   //Glu.gluQuadricOrientation(quadObj, Glu.GLU_OUTSIDE);
                Gl.glPushMatrix();
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
                Gl.glColor3d(1, 0, 0);
                Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);

                Gl.glTranslatef(frame.Centre._x, frame.Centre._y, frame.Centre._z);

                //var dirZ = frame.Z.Sub(frame.Centre);
                var axis = Vector.CrossProd(new Point3D(0, 0, 1), frame.Dir_Z);
                var angle = Vector.GetCosAngleVectors(new Point3D(0, 0, 1), frame.Dir_Z);
                angle = (float)(Math.Acos(angle) * 180 / Math.PI);

                Gl.glRotatef(angle, axis._x, axis._y, axis._z);
                //Glu.gluQuadricDrawStyle(quadObj, Glu.GLU_FILL); // устанавливаем
                Glu.gluSphere(quadObj, width / 2, 10, 10); // рисуем сферу
                                                           // радиусом 0.5
                Gl.glPopMatrix();
                Glu.gluDeleteQuadric(quadObj);
                averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });

            DisplayGeometryObjectEvent += met;
        }
    }
}
