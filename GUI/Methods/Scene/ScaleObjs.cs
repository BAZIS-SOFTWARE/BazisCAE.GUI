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
        public float ScaleFactor { get; set; } = 1.0f;

        public void ScaleObjs(float scaleFactor)
        {
            GL.Scale(scaleFactor, scaleFactor, scaleFactor);
            var crd = GetSceneCoordOfScreenVector(0, 1);
            ScaleFactor = (float)Math.Sqrt(Math.Pow(crd._x, 2) + Math.Pow(crd._y, 2) + Math.Pow(crd._z, 2));
        }
    }
}
