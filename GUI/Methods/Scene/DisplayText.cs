using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;
using System.Reflection;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        event Action DisplayText3DEvent;
        event Action DisplayText2DEvent;
        /// <summary>
        /// Метод шаблон. Использовать везде с оберткой для вывода текста
        /// </summary>
        /// <param name="str"></param>
        /// <param name="color"></param>
        /// <param name="coord"></param>
        public void DisplayText3DTemplate(string str, Color color, Point3D coord)
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(-Position._x, -Position._y, -Position._z);
            Gl.glColor3b(color.R, color.G, color.B);
            Gl.glRasterPos3f(coord._x, coord._y, coord._z);
            Gl.glPushAttrib(Gl.GL_LIST_BASE);//Избегаем пересечений списков, сохраняем старую базу
            Gl.glListBase(FontBase);//Устанавливаем базу на fontBase
            Gl.glCallLists(str.Length, Gl.GL_UNSIGNED_SHORT, str);
            Gl.glPopAttrib();//Возвращаем старую базу
            Gl.glPopMatrix();
        }


        public void HideText3D(string searchMethod)
        {
            //var list = PlugDisplayObjectEvent?.GetInvocationList();
            for (int i = 0; i < DisplayText3DEvent?.GetInvocationList().Count(); i++)
            {
                var del = DisplayText3DEvent.GetInvocationList()[i];
                if (del.Method.Name.Contains(searchMethod))
                {
                    DisplayText3DEvent -= (Action)del;
                    i--;
                }
            }
        }

        public void DisplayText3D(string str, Color color, Point3D coord)
        {
            var met = new Action(() =>
            {
                //if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                //    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                DisplayText3DTemplate(str, color, coord);
                //if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                //    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);

            });
            
            DisplayText3DEvent += met;
        }
        /// <inheritdoc/>

        public void DisplayText2D(string str, Color color, Point2D coord)
        {
            var met = new Action(() =>
            {
                if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glPushMatrix();
                Gl.glLoadIdentity();

                Gl.glOrtho(0, scene.Width, 0, scene.Height, 0.1, 200);

                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glPushMatrix();
                Gl.glLoadIdentity();


                Gl.glPushMatrix();

                Gl.glColor3b(color.R, color.G, color.B);
                Gl.glRasterPos3d(coord._x, coord._y, -5);
                Gl.glPushAttrib(Gl.GL_LIST_BASE);//Избегаем пересечений списков, сохраняем старую базу
                Gl.glListBase(FontBase);//Устанавливаем базу на fontBase
                Gl.glCallLists(str.Length, Gl.GL_UNSIGNED_SHORT, str);
                Gl.glPopAttrib();//Возвращаем старую базу
                Gl.glPopMatrix();

                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glPopMatrix();
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glPopMatrix();
                if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });
            DisplayText2DEvent += met;
        }
    }
}
