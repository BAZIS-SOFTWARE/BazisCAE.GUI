using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using System;
using Geometry;
using OpenTK.Graphics.OpenGL;
using BazisGUI.SettingsControls;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public event Action DisplayReflectionPlaneEvent;

        public void DisplayReflectionPlane(string objName, float[] coeff)
        {
            var plane = new Plane(new Point3D(coeff[0], coeff[1], coeff[2]), coeff[3]);
            var original = VBOController.FindVBObj(objName);

            if (original == null)
                throw new Exception($"Объект с именем {original.ObjName} не существует");

            var met = new Action(() =>
            {
                if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsBeforeDrawing(null, DrawElements.GeometryObjects);
                var bb = original.BoundingBox;
                GL.PushMatrix();
                GL.MultMatrix(original.ModelMatrix);
                var normal = Vector.GetVectorNorm(plane.Normal);
                var origin = normal.Mult(plane.Shifting);
                GL.Translate(origin._x, origin._y, origin._z);
                var z = new Point3D(0, 0, -1);
                var angleY = Vector.GetCosAngleVectors(z, normal);
                angleY = (float)(Math.Acos(angleY) * 180 / Math.PI);
                var axisY = Vector.CrossProd(z, normal);
                GL.Rotate(angleY, axisY._x, axisY._y, axisY._z);

                var scale = 1f;
                var left = bb.LeftUpNear.Mult(scale);
                var right = bb.RightDownFar.Mult(scale);

                var zN = (float)Math.Min(right._x - left._x, left._y - right._y) * -Math.Sign(plane.Shifting) * 0.25f;
                normal = new Point3D(0, 0, zN);

                var center = new Point3D((right._x + left._x) / 2, (right._y + left._y) / 2, 0);
                var endNormal = center.Sum(normal);

                var arrow0 = new Point3D((left._x - center._x) * 0.5f, 0, 0);
                var arrow1 = arrow0.Mult(-1);

                arrow0 = arrow0.Sub(normal).Mult(0.15f);
                arrow1 = arrow1.Sub(normal).Mult(0.15f);

                arrow0 = endNormal.Sum(arrow0);
                arrow1 = endNormal.Sum(arrow1);

                //Рисование рамки
                GL.Begin(PrimitiveType.LineStrip);
                GL.Color3(0, 1f, 0);
                GL.Vertex3(left._x, right._y, 0);

                GL.Color3(0, 1f, 0);
                GL.Vertex3(right._x, right._y, 0);

                GL.Color3(0, 1f, 0);
                GL.Vertex3(right._x, left._y, 0);

                GL.Color3(0, 1f, 0);
                GL.Vertex3(left._x, left._y, 0);

                GL.Color3(0, 1f, 0);
                GL.Vertex3(left._x, right._y, 0);
                GL.End();
                //Рисование нормали (3 линии)
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(0, 1f, 0);
                GL.Vertex3(center._x, center._y, center._z);
                GL.Color3(0, 1f, 0);
                GL.Vertex3(endNormal._x, endNormal._y, endNormal._z);

                GL.Color3(0, 1f, 0);
                GL.Vertex3(endNormal._x, endNormal._y, endNormal._z);
                GL.Color3(0, 1f, 0);
                GL.Vertex3(arrow0._x, arrow0._y, arrow0._z);

                GL.Color3(0, 1f, 0);
                GL.Vertex3(endNormal._x, endNormal._y, endNormal._z);
                GL.Color3(0, 1f, 0);
                GL.Vertex3(arrow1._x, arrow1._y, arrow1._z);
                GL.End();
                GL.PopMatrix();
                if (settingsConfig.Transparency && !advanced3DClipper.IsEnable)
                    averageColorRenderer.DoActionsAfterDrawing(null, DrawElements.GeometryObjects);
            });

            DisplayReflectionPlaneEvent = met;
        }
    }
}
