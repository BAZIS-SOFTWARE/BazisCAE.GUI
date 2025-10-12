using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;
using Geometry;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;

namespace BazisGUI
{
    public partial class BaseForm
    {

        public Matrix<float> ProjectionMatrix
        {
            get
            {
                float[] vector = new float[16];

                Gl.glGetFloatv(Gl.GL_PROJECTION_MATRIX, vector);
                //float[,] multiMassView = new float[4, 4];

                var matrix = Matrix<float>.Build.Dense(4, 4);

                for (int i = 0; i < 4; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {
                        matrix[j, i] = vector[(i * 4) + j];
                    }
                }

                return matrix;
            }
            set
            {
                var tempViewMatrixAr = value.AsColumnMajorArray();
                Gl.glLoadMatrixf(tempViewMatrixAr);
            }
        }
    }
}
