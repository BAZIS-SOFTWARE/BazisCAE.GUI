using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using BazisGUI.Scene;
using Model.Interfaces.ObjectsCollections;
using ModelControllerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public void DisplayObjects()
        {
            Gl.glClearColor(BackGroundColor.R / 255.0f, BackGroundColor.G / 255.0f, BackGroundColor.B / 255.0f, 0);
            // очистка буфера цвета и буфера глубины в заданный цвет 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            if (IsBlending && !advanced3DClipper.IsEnable)
                averageColorRenderer.ClearColors();
            if (DisplayBasis)
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                basis.Display(camera, scaleFactor);
                if (displayRotatioPoint)
                    DisplayRotationPointEvent.Invoke();
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            }

            //----
            Gl.glPushMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            var matrix = camera.GetViewMatrix();
            var viewMatrixAr = matrix.AsColumnMajorArray();

            Gl.glLoadMatrixf(viewMatrixAr);
            Gl.glPopMatrix();
            //----
            // вызов всех подключенных методов   
            DisplayGeometryObjectEvent?.Invoke();

            if (IsCutting)
            {
                Gl.glEnable(Gl.GL_CULL_FACE);
                Gl.glCullFace(Gl.GL_BACK);
                Gl.glFrontFace(Gl.GL_CCW);
            }
            //if (IsLighting)//Перенес в другое место
            //Gl.glEnable(Gl.GL_LIGHTING);
            //if(IsBlending) //Не нужно
            //Gl.glEnable(Gl.GL_BLEND);

            DisplayModelObjects();
            if (IsBlending && !advanced3DClipper.IsEnable)
                averageColorRenderer.BlendFramebuffers();

            if (DisplayCompass)
            {
                Gl.glDisable(Gl.GL_DEPTH);
                compass.Display(camera, scaleFactor);
                Gl.glEnable(Gl.GL_DEPTH);
            }


            DisplayText3DEvent?.Invoke();
            DisplayText2DEvent?.Invoke();

            DisplayControlStatus();

            Gl.glFlush();
            scene.Invalidate();
        }

        private void DisplayModelObjects()
        {
            Gl.glPushMatrix();//У каждого VBObject теперь свои трансформации
            Gl.glTranslatef(-camera.Position._x, -camera.Position._y, -camera.Position._z);

            Gl.glEnable(Gl.GL_NORMALIZE); //делам нормали одинаковой величины во избежание артефактов
            Gl.glEnable(Gl.GL_LIGHT0);

            //Установим вектор перемещения для источника света GL_LIGHT0
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glTranslatef(LightTranslateX, LightTranslateY, LightTranslateZ);
            var pos = new float[] { 0.0f, 0.0f, 1.0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, pos);
            Gl.glPopMatrix();

            Gl.glBlendFuncSeparate(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA, Gl.GL_ONE, Gl.GL_ONE);

            //Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);//Перенес по месту вызова Draw конкретного объекта, может помочь
            //Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);
            //Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);
            //Gl.glEnableClientState(Gl.GL_EDGE_FLAG_ARRAY);
            DisplayReflectionPlaneEvent?.Invoke();
            if (displayClipPlane)
                DisplayClipPlaneEvent?.Invoke();
            if (IsLighting)
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
