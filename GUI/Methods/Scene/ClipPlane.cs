using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using System;
using Geometry;
using System.Linq;
using BazisGUI.Scene;
using OpenTK.Graphics.OpenGL;

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

                var data = ClipPlane.CreateBoundingBoxPlanes(bbox);
                var vboObj = new ClipPlane("ClipPlane", data.Item1, data.Item2, data.Item3);

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
                var objBox = VBOController.FindVBObj("ClipPlane") as ClipPlane;
                if (objBox != null)
                {
                    advanced3DClipper.ScaleFactor = ScaleFactor;

                    var model = GetModelMatrix(plane, objBox.BoundingBox);
                    objBox.ModelMatrix = model;

                    GL.PushMatrix();
                    GL.MultMatrix(model);
                    GL.GetFloat(GetPName.ModelviewMatrix, advanced3DClipper.ClipMatrix);
                    GL.PopMatrix();

                    GL.GetFloat(GetPName.ModelviewMatrix, objBox.ViewMatrix);
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

            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();
            var origin = plane.Normal.Mult(plane.Shifting);

            var sX = Math.Sign(plane.Normal._x);
            var sY = Math.Sign(plane.Normal._y);
            var sZ = Math.Sign(plane.Normal._z);

            var center = bbox.RightDownFar.Sum(bbox.LeftUpNear).Mult(0.5f);
            GL.Translate(center._x, center._y, center._z);
            GL.Translate(sX * origin._x, sY * origin._y, sZ * origin._z);
            var angle = Vector.GetCosAngleVectors(new Point3D(0, 0, -1), plane.Normal);
            angle = (float)(Math.Acos(angle) * 180 / Math.PI);
            var axis = Vector.CrossProd(new Point3D(0, 0, -1), plane.Normal);
            GL.Rotate(angle, axis._x, axis._y, axis._z);

            GL.GetFloat(GetPName.ModelviewMatrix, modelMatrix);
            GL.PopMatrix();

            return modelMatrix;
        }
    }
}
