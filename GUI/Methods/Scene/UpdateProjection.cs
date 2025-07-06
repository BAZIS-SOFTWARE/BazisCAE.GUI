using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void UpdateProjection()
        {
            var aspectRatio = (double)scene.Width / scene.Height;
            var angleDeg = 2.5;
            if (settingsConfig.Projection == ViewProjection.Parallel)
            {
                float[] view = new float[16];
                Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, view);//Не могу вызывать Camera.GetViewMatrix() - т.к Camera = null
                var worldPos = new Point3D(-view[12], -view[13], -view[14]);
                var distance = Vector.GetVectorLenght(worldPos);
                if (Math.Abs(distance) < 1e-4)
                    distance = 1;
                var radAngle = angleDeg * Math.PI / 180;
                var height = Math.Tan(radAngle / 2) * distance * 2;
                var width = height * aspectRatio;
                var sizeX = width / 2;
                var sizeY = height / 2;
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();
                Gl.glOrtho(-sizeX, sizeX, -sizeY, sizeY, -distance * 2, distance * 2);
            }
            else
            {
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();
                Glu.gluPerspective(angleDeg, aspectRatio, 1, 2000);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);//Возврашаем на ModelView, иначе начинаются проблемы с рисованием
        }      
    }
}
