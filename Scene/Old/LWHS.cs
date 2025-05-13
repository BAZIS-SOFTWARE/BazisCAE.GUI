using PrFunctionLib;
using PrGeometry;
using PrProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace PrScene
{
    public class LWHS : IHeatSource
    {         
        public void Display(HeatSource heatSource, Point3D camera, Frame frame)
        {
            var lhs = heatSource as LazerHeatSource;

            var upeer_rad = lhs.UpperDiam / 2;
            var lover_rad = lhs.BottomDiam / 2;
            var length = lhs.Lenght;

            var quadObj = Glu.gluNewQuadric(); // создаем новый объект
                                               // для создания сфер и цилиндров
                                               //Glu.gluQuadricOrientation(quadObj, Glu.GLU_OUTSIDE);
            Gl.glPushMatrix();
            Gl.glColor3d(1, 0, 0);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);

            Gl.glTranslatef(-camera._x, -camera._y, -camera._z);

            var sFrame = frame.Shift(heatSource.Shifting);

            Gl.glTranslatef(sFrame.Centre._x, sFrame.Centre._y, sFrame.Centre._z);

            var axis = sFrame.AxisY.Sub(sFrame.Centre);
            axis = Vector.GetVectorNorm(axis);
            var rFrame = sFrame.Rotate(axis, heatSource.Rotation);
            var dirZ = rFrame.AxisZ.Sub(rFrame.Centre);
            var angle = Vector.GetAngleVectors(new Point3D(0, 0, 1), dirZ);
            angle = (float)(Math.Acos(angle) * 180 / Math.PI);

            axis = Vector.GetVectorsProd(new Point3D(0, 0, 1), dirZ);
            
            Gl.glRotatef(angle, axis._x, axis._y, axis._z);
            Gl.glTranslatef(0, 0, -length);

            Glu.gluCylinder(quadObj, lover_rad, upeer_rad, length, 10, 10); // рисуем конус

            Gl.glPopMatrix();
            Glu.gluDeleteQuadric(quadObj);
        }
    }
}
