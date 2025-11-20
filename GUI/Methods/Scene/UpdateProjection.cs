using BazisGUI.Scene.Interfaces;
using System;
//using Tao.OpenGl;
using Geometry;
using OpenTK.Graphics.OpenGL;
using static BazisGUI.Methods.PlatformSpecific.PlatformSpecific;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void UpdateProjection()
        {
            var viewport = new int[4];
            GL.GetInteger(GetPName.Viewport, viewport);

            var aspectRatio = (float)viewport[2] / viewport[3];
            var angleDeg = 2.5f;
            if (settingsConfig.Projection == ViewProjection.Parallel)
            {
                float[] view = new float[16];
                GL.GetFloat(GetPName.ModelviewMatrix, view);//Не могу вызывать Camera.GetViewMatrix() - т.к Camera = null
                var worldPos = new Point3D(-view[12], -view[13], -view[14]);
                var distance = Vector.GetVectorLenght(worldPos);
                if (Math.Abs(distance) < 1e-4)
                    distance = 1;
                var radAngle = angleDeg * Math.PI / 180;
                var height = Math.Tan(radAngle / 2) * distance * 2;
                var width = height * aspectRatio;
                var sizeX = width / 2;
                var sizeY = height / 2;
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.Ortho(-sizeX, sizeX, -sizeY, sizeY, -distance * 2, distance * 2);
            }
            else
            {
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                gluPerspective(angleDeg, aspectRatio, 1, 2000);
            }
            GL.MatrixMode(MatrixMode.Modelview);//Возврашаем на ModelView, иначе начинаются проблемы с рисованием
        }      
    }
}
