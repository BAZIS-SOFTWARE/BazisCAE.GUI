using Geometry;
using MathNet.Numerics.LinearAlgebra;
using System;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public Point3D GetSceenCoord(float x, float y, float z)
        {
            float[] point = new float[4]
            {
                x - Position._x,
                y - Position._y,
                z - Position._z,
                1
            }; // первоначальные видовые координаты искомой точки точки

            //Matrix<float> operate = Matrix<float>.Build.DenseOfArray(viewMatrix);
            Vector<float> vector = Vector<float>.Build.DenseOfArray(point); // видовые координаты искомой точки точки после преобразования

            ViewMatrix.Multiply(vector, vector);

            return new Point3D(vector[0], vector[1], vector[2]);
        }
        /// <inheritdoc/>
        public Point3D GetSceenCoord(Point3D point)
        {
            var shift = point.Sub(Position);
            float[] pointV = new float[4] { shift._x, shift._y, shift._z, 1 }; // первоначальные видовые координаты искомой точки точки


            var vector = Vector<float>.Build.DenseOfArray(pointV); // видовые координаты искомой точки точки после преобразования

            ViewMatrix.Multiply(vector, vector);

            return new Point3D(vector[0], vector[1], vector[2]);
        }
        /// <inheritdoc/>
        public Point3D GetSceenCoord(Point2D point2D, float depth, float ScaleFactor)
        {
            var view_port_koeff = ((float)Height / Width);
            var tan = (float)Math.Tan(settingsConfig.AngleOfProjection * 3.14f / 180);
            var xs = point2D._x * tan * depth / view_port_koeff / Width; //вычисление экранной Хэ координат искомой точки узлов (2, 4)
            var ys = point2D._y * tan * depth / Height; //вычисление экранной Уэ координат искомой точки

            xs = xs / ScaleFactor / ScaleFactor;
            ys = ys / ScaleFactor / ScaleFactor;

            var scnc = GetSceneCoordOfScreenVector(xs, ys);

            return new Point3D(scnc._x, scnc._y, scnc._z);
        }
        /// <inheritdoc/>
        public Point2D GetScreenCoord(Point3D coord)
        {
            var zn = coord._z;
            var xn = -(coord._x / coord._z);
            var yn = -(coord._y / coord._z);
            var view_port_koeff = ((float)Height / Width);
            var tan = (float)Math.Tan(settingsConfig.AngleOfProjection * 3.14f / 180);
            var x_scr = xn * view_port_koeff * (Width / tan); //вычисление экранной Хэ координат искомой точки узлов (2, 4)
            var y_scr = yn * (Height / tan); //вычисление экранной Уэ координат искомой точки

            return new Point2D(x_scr, y_scr);
        }
    }
}
