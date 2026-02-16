using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using BazisGUI.Scene;
using System.Linq;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using BazisGUI.SettingsControls;

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
            GL.ClearColor(settingsConfig.BackGroundColor.R / 255.0f,
                settingsConfig.BackGroundColor.G / 255.0f,
                settingsConfig.BackGroundColor.B / 255.0f, 0);
            // очистка буфера цвета и буфера глубины в заданный цвет 
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

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
            GL.PushMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            var matrix = ViewMatrix;
            var viewMatrixAr = matrix.AsColumnMajorArray();

            GL.LoadMatrix(viewMatrixAr);
            GL.PopMatrix();

            //----
            // вызов всех подключенных методов   
            if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
            DisplayGeometryObjectEvent?.Invoke();
            if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);


            if (settingsConfig.IsCutting)
            {
                GL.Enable(EnableCap.CullFace);
                GL.CullFace(TriangleFace.Back);
                GL.FrontFace(FrontFaceDirection.Ccw);
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
            GL.Finish(); // Обработка драйвером буффера команд. См Khronos
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
            GL.PushMatrix();//У каждого VBObject теперь свои трансформации
            GL.Translate(-Position._x, -Position._y, -Position._z);

            GL.Enable(EnableCap.Normalize); //делам нормали одинаковой величины во избежание артефактов
            GL.Enable(EnableCap.Light0);

            //Установим вектор перемещения для источника света GL_LIGHT0
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Translate(settingsConfig.LighterPosition.X, settingsConfig.LighterPosition.Y, 0);
            var pos = new float[] { 0.0f, 0.0f, 1.0f, 1.0f };
            GL.Light(LightName.Light0, LightParameter.Position, pos);
            GL.PopMatrix();

            GL.BlendFuncSeparate(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha, BlendingFactorSrc.One, BlendingFactorDest.One);

            //Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);//Перенес по месту вызова Draw конкретного объекта, может помочь
            //Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);
            //Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);
            //Gl.glEnableClientState(Gl.GL_EDGE_FLAG_ARRAY);
            //DisplayReflectionPlaneEvent?.Invoke();

            DisplayClipPlaneEvent?.Invoke();

            if (settingsConfig.Lighting)
                GL.Enable(EnableCap.Lighting);

            // рассеяное освещение
            float[] global_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1 };

            GL.LightModel(LightModelParameter.LightModelAmbient, global_ambient);

            // цвет источника
            float[] diffuse = new float[] { 1, 1, 1, 1 };
            GL.Light(LightName.Light0, LightParameter.Diffuse, diffuse);
            //float[] light_position = new float[] { 1, 1, 1, 1 };
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_position);
            GL.LightModel(LightModelParameter.LightModelTwoSide, 1);

            //Gl.glColorMaterial(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT_AND_DIFFUSE); // have to be before loadinng objects you want to light
            GL.Enable(EnableCap.ColorMaterial);

            GL.LineWidth(1.5f);


            foreach (var sObj in VBOController.GetVBObjs().Where(x => x.GL_ObjType == GLObjType.triangle))
            {
                GL.PushMatrix();
                GL.MultMatrix(sObj.ModelMatrix);
                //Поправка: Возможное решение проблемы с отсутсвием картинки в режиме ребер на радеоне! (работает на NVidia)
                //Gl.glEnableClientState(Gl.GL_EDGE_FLAG_ARRAY);
                sObj.Load();
                //Gl.glDisableClientState(Gl.GL_EDGE_FLAG_ARRAY);
                GL.PopMatrix();
            }
            GL.Disable(EnableCap.Lighting);

            foreach (var lObj in VBOController.GetVBObjs().Where(x => x.GL_ObjType == GLObjType.line))
            {
                GL.PushMatrix();
                GL.MultMatrix(lObj.ModelMatrix);
                lObj.Load();
                GL.PopMatrix();
            }
            foreach (var pObj in VBOController.GetVBObjs().Where(x => x.GL_ObjType == GLObjType.point))
            {
                GL.PushMatrix();
                GL.MultMatrix(pObj.ModelMatrix);
                pObj.Load();
                GL.PopMatrix();
            }

            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.CullFace);
            GL.Disable(EnableCap.ColorMaterial);
            //Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            //Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);

            //Gl.glDisableClientState(Gl.GL_NORMAL_ARRAY);
            //Gl.glDisableClientState(Gl.GL_EDGE_FLAG_ARRAY);
            GL.PopMatrix();
        }
    }
}
