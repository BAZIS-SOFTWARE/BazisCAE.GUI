using PrFunctionLib;
using PrGeometry;
using PrModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace PrScene
{
    public class ArcHS : SceneHeatSource
    {
        public float Width { get; }
        public Point3D Shifting { get; }
        public ArcHS(float width)
        {
            Width = width;
        }

        public override void Display(Point3D camera, Frame frame)
        {
            //var ahs = heatSource as ArcHeatSource;
            //var weldPoolSize = Width;
            //var quadObj = Glu.gluNewQuadric(); // создаем новый объект
            //                                   // для создания сфер и цилиндров
            //                                   //Glu.gluQuadricOrientation(quadObj, Glu.GLU_OUTSIDE);
            //Gl.glPushMatrix();
            //Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK,Gl.GL_LINE);
            //Gl.glColor3d(1, 0, 0);
            //Gl.glTranslatef(-camera._x, -camera._y, -camera._z);

            //var sFrame = frame.Shift(heatSource.Shifting);
            //Gl.glTranslatef(sFrame.Centre._x, sFrame.Centre._y, sFrame.Centre._z);

            //var dirZ = sFrame.AxisZ.Sub(sFrame.Centre);
            //var axis = Vector.GetVectorsProd(new Point3D(0, 0, 1), dirZ);
            //var angle = Vector.GetAngleVectors(new Point3D(0, 0, 1), dirZ);
            //angle = (float)(Math.Acos(angle) * 180 / Math.PI);

            //Gl.glRotatef(angle, axis._x, axis._y, axis._z);
            ////Glu.gluQuadricDrawStyle(quadObj, Glu.GLU_FILL); // устанавливаем
            //Glu.gluSphere(quadObj, weldPoolSize / 2, 10, 10); // рисуем сферу
            //                                                  // радиусом 0.5
            //Gl.glPopMatrix();
            //Glu.gluDeleteQuadric(quadObj);
        }
    }
}
