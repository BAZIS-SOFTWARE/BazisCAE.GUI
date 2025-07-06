using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void DisplayText3D(string str, Color color, Point3D coord)
        {
            var met = new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                Gl.glPushMatrix();
                Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);
                Gl.glColor3b(color.R, color.G, color.B);
                Gl.glRasterPos3f(coord._x, coord._y, coord._z);
                Gl.glPushAttrib(Gl.GL_LIST_BASE);//Избегаем пересечений списков, сохраняем старую базу
                Gl.glListBase(fontBase);//Устанавливаем базу на fontBase
                Gl.glCallLists(str.Length, Gl.GL_UNSIGNED_SHORT, str);
                Gl.glPopAttrib();//Возвращаем старую базу
                Gl.glPopMatrix();
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });

            DisplayText3DEvent += met;
        }
        /// <inheritdoc/>

        public void DisplayText2D(string str, Color color, Point2D coord)
        {
            var met = new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glPushMatrix();
                Gl.glLoadIdentity();

                Gl.glOrtho(0, camera.Width, 0, camera.Height, 0.1, 200);

                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glPushMatrix();
                Gl.glLoadIdentity();


                Gl.glPushMatrix();

                Gl.glColor3b(color.R, color.G, color.B);
                Gl.glRasterPos3f(coord._x, coord._y, -5);
                Gl.glPushAttrib(Gl.GL_LIST_BASE);//Избегаем пересечений списков, сохраняем старую базу
                Gl.glListBase(fontBase);//Устанавливаем базу на fontBase
                Gl.glCallLists(str.Length, Gl.GL_UNSIGNED_SHORT, str);
                Gl.glPopAttrib();//Возвращаем старую базу
                Gl.glPopMatrix();

                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glPopMatrix();
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glPopMatrix();
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });
            DisplayText2DEvent += met;
        }
    }
}
