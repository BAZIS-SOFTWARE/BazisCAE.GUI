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
        public float ScaleFactor { get; set; } = 1.0f;

        public void ScaleObjs(float ScaleFactor)
        {
            Gl.glScalef(ScaleFactor, ScaleFactor, ScaleFactor);
            var crd = GetSceneCoordOfScreenVector(0, 1);
            ScaleFactor = (float)Math.Sqrt(Math.Pow(crd._x, 2) + Math.Pow(crd._y, 2) + Math.Pow(crd._z, 2));
        }
    }
}
