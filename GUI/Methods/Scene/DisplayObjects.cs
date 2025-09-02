using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using BazisGUI.Scene;
using System.Linq;
using Tao.OpenGl;
using System.Drawing;

namespace BazisGUI
{
    public partial class BaseForm
    {
        /// <summary>
        /// DisplayObjects. Главный метод рисования. 
        /// Важно! Сначала рисуются объемные и самы дальние объекты, 
        /// а потом те, что ближе к экрану
        /// </summary>
        public void DisplayObjects()
        {
            Gl.glClearColor(settingsConfig.BackGroundColor.R / 255.0f, 
                settingsConfig.BackGroundColor.G / 255.0f, 
                settingsConfig.BackGroundColor.B / 255.0f, 0);
            // очистка буфера цвета и буфера глубины в заданный цвет 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                averageColorRenderer.ClearColors();
            if (settingsConfig.DisplayBasis)
            {
                if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);

                DisplayBasisEvent?.Invoke();
                //basis.Display(ScaleFactor);

                DisplayRotationPointEvent?.Invoke();
                if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            }

            //----
            Gl.glPushMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            var matrix = ViewMatrix;
            var viewMatrixAr = matrix.AsColumnMajorArray();

            Gl.glLoadMatrixf(viewMatrixAr);
            Gl.glPopMatrix();

            //----
            // вызов всех подключенных методов   
            if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
            DisplayGeometryObjectEvent?.Invoke();
            if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);


            if (settingsConfig.IsCutting)
            {
                Gl.glEnable(Gl.GL_CULL_FACE);
                Gl.glCullFace(Gl.GL_BACK);
                Gl.glFrontFace(Gl.GL_CCW);
            }
            //if (IsLighting)//Перенес в другое место
            //Gl.glEnable(Gl.GL_LIGHTING);
            //if(settingsConfig.Transparency) //Не нужно
            //Gl.glEnable(Gl.GL_BLEND);

            DisplayModelObjects();

            if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                averageColorRenderer.BlendFramebuffers();

            DisplayCompassEvent?.Invoke();
            //compass.Display(camera, ScaleFactor);              

            if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
            DisplayText3DEvent?.Invoke();
            if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);

            DisplayText2DEvent?.Invoke();

            DisplayControlStatus();

            selectionRectangle.Display(scene.Width, scene.Height);

            //Gl.glFlush();
            //scene.Invalidate();
            Gl.glFinish(); // Обработка драйвером буффера команд. См Khronos
            scene.SwapBuffers(); // Поменять местами буфферы кадров.
        }

        private void DisplayControlStatus()
        {
            var cornerRect = new ScreenRectangle() { Red = 0, Green = 0, Blue = 0 };

            cornerRect.winScrenePosit = new Point(scene.Width - 18, scene.Height - 9);
            cornerRect.winScreneCoord.X = cornerRect.winScrenePosit.X + 8;
            cornerRect.winScreneCoord.Y = cornerRect.winScrenePosit.Y - 8;
            cornerRect.Display(scene.Width, scene.Height);

            if (IsSceneExpand)
            {
                cornerRect.winScrenePosit = new Point(scene.Width - 21, scene.Height - 12);
                cornerRect.winScreneCoord.X = cornerRect.winScrenePosit.X + 8;
                cornerRect.winScreneCoord.Y = cornerRect.winScrenePosit.Y - 8;
                cornerRect.Display(scene.Width, scene.Height);
            }
        }

        private void DisplayModelObjects()
        {
            Gl.glPushMatrix();//У каждого VBObject теперь свои трансформации
            Gl.glTranslatef(-Position._x, -Position._y, -Position._z);

            Gl.glEnable(Gl.GL_NORMALIZE); //делам нормали одинаковой величины во избежание артефактов
            Gl.glEnable(Gl.GL_LIGHT0);

            //Установим вектор перемещения для источника света GL_LIGHT0
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glTranslatef(settingsConfig.LighterPosition.X, settingsConfig.LighterPosition.Y, 0);
            var pos = new float[] { 0.0f, 0.0f, 1.0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, pos);
            Gl.glPopMatrix();

            Gl.glBlendFuncSeparate(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA, Gl.GL_ONE, Gl.GL_ONE);

            //Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);//Перенес по месту вызова Draw конкретного объекта, может помочь
            //Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);
            //Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);
            //Gl.glEnableClientState(Gl.GL_EDGE_FLAG_ARRAY);
            DisplayReflectionPlaneEvent?.Invoke();

            DisplayClipPlaneEvent?.Invoke();
            
            if (settingsConfig.Lighting)
                Gl.glEnable(Gl.GL_LIGHTING);
            float[] global_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1 };
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            float[] diffuse = new float[] { 1, 1, 1, 1 };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, diffuse);
            //float[] light_position = new float[] { 1, 1, 1, 1 };
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_position);
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);

            //Gl.glColorMaterial(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT_AND_DIFFUSE); // have to be before loadinng objects you want to light
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            Gl.glLineWidth(1.5f);


            foreach (var sObj in VBOController.GetVBObjs().Where(x => x.GL_ObjType == GLObjType.triangle))
            {
                Gl.glPushMatrix();
                Gl.glMultMatrixf(sObj.ModelMatrix);
                //Поправка: Возможное решение проблемы с отсутсвием картинки в режиме ребер на радеоне! (работает на NVidia)
                //Gl.glEnableClientState(Gl.GL_EDGE_FLAG_ARRAY);
                sObj.Load();
                //Gl.glDisableClientState(Gl.GL_EDGE_FLAG_ARRAY);
                Gl.glPopMatrix();
            }
            Gl.glDisable(Gl.GL_LIGHTING);

            foreach (var lObj in VBOController.GetVBObjs().Where(x => x.GL_ObjType == GLObjType.line))
            {
                Gl.glPushMatrix();
                Gl.glMultMatrixf(lObj.ModelMatrix);
                lObj.Load();
                Gl.glPopMatrix();
            }
            foreach (var pObj in VBOController.GetVBObjs().Where(x => x.GL_ObjType == GLObjType.point))
            {
                Gl.glPushMatrix();
                Gl.glMultMatrixf(pObj.ModelMatrix);
                pObj.Load();
                Gl.glPopMatrix();
            }

            Gl.glDisable(Gl.GL_BLEND);
            Gl.glDisable(Gl.GL_CULL_FACE);
            Gl.glDisable(Gl.GL_COLOR_MATERIAL);
            //Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            //Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);

            //Gl.glDisableClientState(Gl.GL_NORMAL_ARRAY);
            //Gl.glDisableClientState(Gl.GL_EDGE_FLAG_ARRAY);
            Gl.glPopMatrix();
        }
    }
}
