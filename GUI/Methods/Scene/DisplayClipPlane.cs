using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using System;
using Tao.OpenGl;
using Geometry;

namespace BazisGUI
{
    public partial class BaseForm
    {
        event Action DisplayClipPlaneEvent;
        public void DisplayClipPlane(Plane plane)
        {
            DisplayClipPlaneEvent += new Action(() =>
            {
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                float[] modelMatrix = new float[16];
                Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, modelMatrix);//Запоминаем предыдущую матрицу в стеке
                Gl.glPushMatrix();
                var origin = plane.Normal.Mult(plane.Shifting);

                var sX = Math.Sign(plane.Normal._x);
                var sY = Math.Sign(plane.Normal._y);
                var sZ = Math.Sign(plane.Normal._z);

                var bbox = clipPlaneRenderer.BoundingBox;

                var diagonal = Geometry.Vector.GetVectorLenght(bbox.LeftUpNear.Sub(bbox.RightDownFar));
                var center = bbox.RightDownFar.Sum(bbox.LeftUpNear).Mult(0.5f);
                Gl.glTranslatef(center._x, center._y, center._z);
                Gl.glTranslatef(sX * origin._x, sY * origin._y, sZ * origin._z);
                var angle = Geometry.Vector.GetCosAngleVectors(new Point3D(0, 0, -1), plane.Normal);
                angle = (float)(Math.Acos(angle) * 180 / Math.PI);
                var axis = Geometry.Vector.CrossProd(new Point3D(0, 0, -1), plane.Normal);
                Gl.glRotatef(angle, axis._x, axis._y, axis._z);
                var normalSize = diagonal * 0.125f;

                Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, advanced3DClipper.ClipMatrix);
                advanced3DClipper.ScaleFactor = ScaleFactor;

                clipPlaneRenderer.Draw(modelMatrix, normalSize);

                Gl.glPopMatrix();
                if (IsBlending && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });
        }
    }
}
