using BazisGUI.Scene.Interfaces;
using Geometry;
using MathNet.Numerics.LinearAlgebra;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public Point3D Position { get; set; } = new Point3D();

        public void SetPositionBack()
        {
            var matrix = ViewMatrix;
            matrix[0, 3] = 0; matrix[1, 3] = 0;
            var tempViewMatrixAr = matrix.AsColumnMajorArray();

            GL.LoadMatrix(tempViewMatrixAr);
        }

        public void MoveCamera(Point new_mousePosition, Point mousePosition, float ScaleFactor)
        {
            var dx = new_mousePosition.X - mousePosition.X;
            var dy = new_mousePosition.Y - mousePosition.Y;

            var pos = new Point2D(-dx, -dy);

            var crd = GetSceenCoord(pos, -5, ScaleFactor);

            GL.Translate(crd._x, crd._y, crd._z);
        }

        public void RotateCamera(ViewAxis axis, float angle)
        {
            switch (axis)
            {
                case ViewAxis.X:
                    var crdx = GetSceneCoordOfScreenVector(-1, 0);
                    GL.Rotate(angle, crdx._x, crdx._y, crdx._z);
                    break;
                case ViewAxis.Y:
                    var crdy = GetSceneCoordOfScreenVector(0, -1);
                    GL.Rotate(angle, crdy._x, crdy._y, crdy._z);
                    break;
                case ViewAxis.Z:

                    float[] point = new float[4] { 0, 0, 1, 0 };

                    var matrix = ViewMatrix.Transpose();
                    var vectorZ = Vector<float>.Build.DenseOfArray(point);

                    matrix.Multiply(vectorZ, vectorZ);
                    GL.Rotate(angle, vectorZ[0], vectorZ[1], vectorZ[2]);
                    break;
            }
        }
        /// <inheritdoc/>
        public void RotateCamera(float vector_dx, float vector_dy, ViewAxis axis, float angle)
        {
            switch (axis)
            {
                case ViewAxis.X:
                    if (vector_dx == 0)
                        if (vector_dy > 0)
                        {
                            var crdx = GetSceneCoordOfScreenVector(1, 0);
                            GL.Rotate(angle, crdx._x, crdx._y, crdx._z);
                        }
                        else
                        {
                            var crdx = GetSceneCoordOfScreenVector(-1, 0);
                            GL.Rotate(angle, crdx._x, crdx._y, crdx._z);
                        }
                    break;
                case ViewAxis.Y:
                    if (vector_dy == 0)
                        if (vector_dx > 0)
                        {
                            var crdy = GetSceneCoordOfScreenVector(0, 1);
                            GL.Rotate(angle, crdy._x, crdy._y, crdy._z);
                        }
                        else
                        {
                            var crdy = GetSceneCoordOfScreenVector(0, -1);
                            GL.Rotate(angle, crdy._x, crdy._y, crdy._z);
                        }
                    break;
                case ViewAxis.Z:
                    if (vector_dy == 0)
                        if (vector_dx > 0)
                        {
                            float[] point = new float[4] { 0, 0, 1, 0 };

                            var matrix = ViewMatrix.Transpose();
                            var vectorZ = Vector<float>.Build.DenseOfArray(point);

                            matrix.Multiply(vectorZ, vectorZ);
                            GL.Rotate(angle, vectorZ[0], vectorZ[1], vectorZ[2]);
                        }
                        else
                        {
                            float[] point = new float[4] { 0, 0, -1, 0 };

                            var matrix = ViewMatrix.Transpose();
                            var vectorZ = Vector<float>.Build.DenseOfArray(point);

                            matrix.Multiply(vectorZ, vectorZ);
                            GL.Rotate(angle, vectorZ[0], vectorZ[1], vectorZ[2]);
                        }
                    break;
                case ViewAxis.XYZ:
                    var crdxyz = GetSceneCoordOfScreenVector(-vector_dy, vector_dx);
                    GL.Rotate(angle, crdxyz._x, crdxyz._y, crdxyz._z);
                    break;
            }
        }
        /// <inheritdoc/>
        public void SetOnPlane(ViewPlane plane, float ScaleFactor)
        {
            var matrix = ViewMatrix;
            var x = matrix[0, 3];
            var y = matrix[1, 3];
            var z = matrix[2, 3];

            var tempViewMatrix = new float[4, 4];

            tempViewMatrix[0, 0] = ScaleFactor;
            tempViewMatrix[1, 1] = ScaleFactor;
            tempViewMatrix[2, 2] = ScaleFactor;
            tempViewMatrix[0, 3] = x;
            tempViewMatrix[1, 3] = y;
            tempViewMatrix[2, 3] = z;
            tempViewMatrix[3, 3] = 1;
            var tempViewMatrixAr = Matrix<float>.Build.DenseOfArray(tempViewMatrix).AsColumnMajorArray();

            GL.LoadMatrix(tempViewMatrixAr);
            switch (plane)
            {
                case ViewPlane.XY:
                    break;
                case ViewPlane.XZ:
                    //Translation_dx = 1; Translation_dy = 0;
                    RotateCamera(ViewAxis.X, -90);
                    break;
                case ViewPlane.YZ:
                    //Translation_dx = 0; Translation_dy = 1;
                    RotateCamera(ViewAxis.Y, 90);
                    break;
            }
        }
    }
}
