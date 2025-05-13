using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene.VBO
{
    /// <summary>
    /// Структура для хранения точки при переборе VBO-массивов
    /// </summary>
    public struct VBOPoint
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z {  get; set; }

        public VBOPoint(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override bool Equals(object o)
        {
            var second = (VBOPoint)o;
            var isXEqual = Math.Abs(X - second.X) < 1e-4;
            var isYEqual = Math.Abs(Y - second.Y) < 1e-4;
            var isZEqual = Math.Abs(Z - second.Z) < 1e-4;
            return isXEqual && isYEqual && isZEqual;
        }

        public override int GetHashCode()
        {
            return (int)(X + Y + Z);
        }
    }
}
