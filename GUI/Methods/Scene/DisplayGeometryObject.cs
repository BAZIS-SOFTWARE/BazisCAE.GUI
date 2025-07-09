using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;
using BazisGUI.Scene;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        event Action DisplayGeometryObjectEvent;
        public void DisplayLocalFrame(Frame frame)
        {
            DisplayGeometryObjectEvent += new Action(() =>
            {
                Gl.glPushMatrix();
                Gl.glTranslatef(-Position._x, -Position._y, -Position._z);

                Gl.glLineWidth(1.5f);
                Gl.glBegin(Gl.GL_LINES);

                // draw "Z"
                var axis_z = frame.Centre.Sum(frame.Dir_Z);

                Gl.glColor3f(0, 0, 1);
                Gl.glVertex3f(frame.Centre._x, frame.Centre._y, frame.Centre._z);
                Gl.glVertex3f(axis_z._x, axis_z._y, axis_z._z);


                // draw "Y"
                var axis_y = frame.Centre.Sum(frame.Dir_Y);
                Gl.glColor3f(0, 1, 0);
                Gl.glVertex3f(frame.Centre._x, frame.Centre._y, frame.Centre._z);
                Gl.glVertex3f(axis_y._x, axis_y._y, axis_y._z);


                // draw "X"
                var axis_x = frame.Centre.Sum(frame.Dir_X);
                Gl.glColor3f(1, 0.5f, 0);
                Gl.glVertex3f(frame.Centre._x, frame.Centre._y, frame.Centre._z);
                Gl.glVertex3f(axis_x._x, axis_x._y, axis_x._z);

                Gl.glEnd();
                Gl.glPopMatrix();
            });
        }

        public void DisplayDistance(Segment3D line)
        {
            var met = new Action(() =>
            {
                Gl.glPushMatrix();
                Gl.glTranslatef(-Position._x, -Position._y, -Position._z);
                Gl.glColor3f(1, 0, 0);
                Gl.glLineWidth(5.0f);
                Gl.glBegin(Gl.GL_LINES);

                Gl.glVertex3f(line.P0._x, line.P0._y, line.P0._z);
                Gl.glVertex3f(line.P1._x, line.P1._y, line.P1._z);
                Gl.glEnd();
                Gl.glPopMatrix();

                var p0 = GetSceenCoord(line.P0);
                var p1 = GetSceenCoord(line.P1);

                var p0_2D = GetScreenCoord(p0);
                var p1_2D = GetScreenCoord(p1);
            });

            DisplayGeometryObjectEvent += met;

            var coord = line.P0.Sum(line.P1).Div(2);

            DisplayText3D(line.GetLength().ToString(), Color.FromArgb(0, 0, 0), coord);
        }

        public void DisplayPath(Point3D[] points)
        {
            Action met;
            if (points.Length > 1)
            {
                var path = new ScenePath(points);
                var quantity = path.PointsQuantity;
                met = new Action(() =>
                {
                    path.Display(Position);
                    var p0 = path[quantity - 2];
                    var p1 = path[quantity - 1];
                    DisplayText3D(path.Length.ToString(), Color.FromArgb(0, 0, 0),
                    new Point3D((p0._x + p1._x) / 2, (p0._y + p1._y) / 2, (p0._z + p1._z) / 2));
                });

                DisplayGeometryObjectEvent += met;
            }
        }

        public void DisplayVector(Point3D length, Point3D posit, Color objColor)
        {
            DisplayGeometryObjectEvent += new Action(() =>
            {
                Gl.glPushMatrix();
    
                Gl.glTranslatef(-Position._x, -Position._y, -Position._z);
                Gl.glTranslatef(posit._x, posit._y, posit._z);
                Gl.glScalef(1 / ScaleFactor, 1 / ScaleFactor, 1 / ScaleFactor);     

                Gl.glColor3ub(objColor.R, objColor.G, objColor.B);
                Gl.glLineWidth(5.0f);
                Gl.glBegin(Gl.GL_LINES);

                Gl.glVertex3f(0, 0, 0);
                Gl.glVertex3f(length._x, length._y, length._z);
                Gl.glEnd();
               
                Gl.glPopMatrix();
            });
        }

        public void DisplaySceneScale(ISceneScale scale)
        {
            DisplayGeometryObjectEvent += new Action(() =>
            {
                scale.Display(scene.Width, scene.Height, CreateGraphics(), Font);
            });
        }
        public void DisplaySpiral(Point3D p0, Point3D p1, Color objColor)
        {
            DisplayGeometryObjectEvent += new Action(() =>
            {
                Gl.glPushMatrix();
                Gl.glTranslatef(-Position._x, -Position._y, -Position._z);
                Gl.glColor3ub(objColor.R, objColor.G, objColor.B);
                Gl.glLineWidth(5.0f);
                Gl.glBegin(Gl.GL_LINES);

                Gl.glVertex3f(p0._x, p0._y, p0._z);
                Gl.glVertex3f(p1._x, p1._y, p1._z);
                Gl.glEnd();
                Gl.glPopMatrix();
            });
        }
        /// <inheritdoc/>


        public void DisplayConus(float UpperDiam, float BottomDiam, float length, Frame frame)
        {
            var upeer_rad = UpperDiam / 2;
            var lover_rad = BottomDiam / 2;

            DisplayGeometryObjectEvent += new Action(() =>
            {
                var quadObj = Glu.gluNewQuadric(); // создаем новый объект
                                                   // для создания сфер и цилиндров
                                                   //Glu.gluQuadricOrientation(quadObj, Glu.GLU_OUTSIDE);
                Gl.glPushMatrix();
                Gl.glColor3d(1, 0, 0);
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);

                Gl.glTranslatef(-Position._x, -Position._y, -Position._z);

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
                //averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });
        }
        /// <inheritdoc/>

        public void DisplaySphere(float width, Frame frame)
        {
            DisplayGeometryObjectEvent += new Action(() =>
            {
                //if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                //    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                var quadObj = Glu.gluNewQuadric(); // создаем новый объект
                                                   // для создания сфер и цилиндров
                                                   //Glu.gluQuadricOrientation(quadObj, Glu.GLU_OUTSIDE);
                Gl.glPushMatrix();
                Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
                Gl.glColor3d(1, 0, 0);
                Gl.glTranslatef(-Position._x, -Position._y, -Position._z);

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
                //averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });
        }

        public void HideGeometryObj(string searchMethod)
        {
            //var list = PlugDisplayObjectEvent?.GetInvocationList();
            for (int i = 0; i < DisplayGeometryObjectEvent?.GetInvocationList().Count(); i++)
            {
                var del = DisplayGeometryObjectEvent.GetInvocationList()[i];
                if (del.Method.Name.Contains(searchMethod))
                {
                    DisplayGeometryObjectEvent -= (Action)del;
                    i--;
                }
            }
        }

        public bool FindGeometryObj(string searchMethod)
        {
            //var list = PlugDisplayObjectEvent?.GetInvocationList();
            for (int i = 0; i < DisplayGeometryObjectEvent?.GetInvocationList().Count(); i++)
            {
                var del = DisplayGeometryObjectEvent.GetInvocationList()[i];
                if (del.Method.Name.Contains(searchMethod))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
