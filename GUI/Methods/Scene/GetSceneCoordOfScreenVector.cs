using Geometry;
using MathNet.Numerics.LinearAlgebra;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public Point3D GetSceneCoordOfScreenVector(float x, float y)
        {
            float[] point = new float[4] { x, y, 0, 0 };

            Matrix<float> matrix = ViewMatrix.Transpose();
            Vector<float> vector = Vector<float>.Build.DenseOfArray(point);

            matrix.Multiply(vector, vector);

            return new Point3D(vector[0], vector[1], vector[2]);
        }
    }
}
