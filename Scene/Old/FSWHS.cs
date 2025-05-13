using PrFunctionLib;
using PrGeometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace PrScene
{
    public class FSWHS : IHeatSource
    {
        public void Display(HeatSource heatSource, Point3D camera, Frame frame)
        {
            var fswhs = heatSource as FSWHeatSource;

            var sholder_rad = fswhs.ShoulderDiam/ 2;
            var upeer_rad = fswhs.PinUpperDiam / 2;
            var lover_rad = fswhs.PinBottomDiam / 2;

            var zh = heatSource.Shifting._z; // tool depth

            var sFrame = frame.Shift(heatSource.Shifting);
            var axis = sFrame.AxisY.Sub(sFrame.Centre);
            axis = Vector.GetVectorNorm(axis);
            var rFrame = sFrame.Rotate(axis, heatSource.Rotation);
            var dirZ = rFrame.AxisZ.Sub(rFrame.Centre);
            var angle = Vector.GetAngleVectors(new Point3D(0, 0, 1), dirZ);
            angle = (float)(Math.Acos(angle) * 180 / Math.PI);

            axis = Vector.GetVectorsProd(new Point3D(0, 0, 1), dirZ);

            var quadObj = Glu.gluNewQuadric(); // создаем новый объект
                                               // рисуем пин
                                               //Glu.gluQuadricOrientation(quadObj, Glu.GLU_OUTSIDE);
            Gl.glPushMatrix();
            Gl.glColor3d(1, 0, 0);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
            Gl.glTranslatef(-camera._x, -camera._y, -camera._z);
            Gl.glTranslatef(sFrame.Centre._x, sFrame.Centre._y, sFrame.Centre._z);
            Gl.glRotatef(angle, axis._x, axis._y, axis._z);
            Gl.glTranslatef(0, 0, -fswhs.PinLenght);

            Glu.gluCylinder(quadObj, lover_rad, upeer_rad, fswhs.PinLenght, 10, 10); // рисуем цилиндр

            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3d(1, 0, 0);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
            Gl.glTranslatef(-camera._x, -camera._y, -camera._z);
            Gl.glTranslatef(sFrame.Centre._x, sFrame.Centre._y, sFrame.Centre._z);
            Gl.glRotatef(angle, axis._x, axis._y, axis._z);
            //Gl.glTranslatef(0, 0,zh);

            if(zh >= 0)
                Glu.gluCylinder(quadObj, sholder_rad, sholder_rad, 1, 10, 10); // рисуем цилиндр
            else Glu.gluCylinder(quadObj, sholder_rad, sholder_rad, -zh, 10, 10); // рисуем цилиндр

            Gl.glPopMatrix();
            Glu.gluDeleteQuadric(quadObj);
        }
    }
}
