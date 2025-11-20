using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.Interfaces;
using System;
using Geometry;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using OpenTK.Graphics.OpenGL;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public Matrix<float> ViewMatrix
        {
            get
            {
                float[] vector = new float[16];
                
                GL.GetFloat(GetPName.ModelviewMatrix, vector);
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
                GL.LoadMatrix(tempViewMatrixAr);
            }
        }
    }
}
