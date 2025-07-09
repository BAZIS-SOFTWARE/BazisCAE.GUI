using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using System;
using Tao.OpenGl;
using Geometry;
using System.Linq;
using BazisGUI.Scene;

namespace BazisGUI
{
    public partial class BaseForm
    {
        event Action DisplayClipPlaneEvent;

        public void CreateClipPlane()
        {
            if (VBOController.GetVBObjs().Count() > 0)
            {
                var bbox = VBOController.GetVBObjs().OrderByDescending(v => v.BoundingBox.GetDiagonalLength()).First().BoundingBox;

                var data = BoundingBoxVBO.CreateBoundingBoxPlanes(bbox);
                var vboObj = new BoundingBoxVBO(data.Item1, data.Item2, data.Item3, "ClipPlane");

                vboObj.Renderer = clipPlaneRenderer;

                VBOController.AddVbo(vboObj);
            } 
        }

        public void DeleteClipPlane() => VBOController.DeleteVBObjects("ClipPlane");

        public void DisplayClipPlane(Plane plane)
        {
            DisplayClipPlaneEvent = null;
            DisplayClipPlaneEvent += new Action(() =>
            {
                var objBox = VBOController.FindVBObj("ClipPlane") as BoundingBoxVBO;
                if (objBox != null)
                {
                    advanced3DClipper.ScaleFactor = ScaleFactor;

                    var model = GetModelMatrix(plane, objBox.BoundingBox);
                    objBox.ModelMatrix = model;

                    Gl.glPushMatrix();
                    Gl.glMultMatrixf(model);
                    Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, advanced3DClipper.ClipMatrix);
                    Gl.glPopMatrix();

                    Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, objBox.ViewMatrix);
                }
            });
        }

        /// <summary>
        /// Вернуть матрицу собственных преобразований
        /// </summary>
        /// <param name="plane">Плоскоть</param>
        /// <param name="bbox">Ограничивающий бокс для подгонки плоскости</param>
        public float[] GetModelMatrix(Plane plane, BoundingBox bbox)
        {
            var modelMatrix = new float[16];

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            var origin = plane.Normal.Mult(plane.Shifting);

            var sX = Math.Sign(plane.Normal._x);
            var sY = Math.Sign(plane.Normal._y);
            var sZ = Math.Sign(plane.Normal._z);

            var center = bbox.RightDownFar.Sum(bbox.LeftUpNear).Mult(0.5f);
            Gl.glTranslatef(center._x, center._y, center._z);
            Gl.glTranslatef(sX * origin._x, sY * origin._y, sZ * origin._z);
            var angle = Vector.GetCosAngleVectors(new Point3D(0, 0, -1), plane.Normal);
            angle = (float)(Math.Acos(angle) * 180 / Math.PI);
            var axis = Vector.CrossProd(new Point3D(0, 0, -1), plane.Normal);
            Gl.glRotatef(angle, axis._x, axis._y, axis._z);

            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, modelMatrix);
            Gl.glPopMatrix();

            return modelMatrix;
        }
    }
}
