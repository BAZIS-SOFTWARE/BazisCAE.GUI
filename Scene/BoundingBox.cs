using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene
{
    /// <summary>
    /// Структура хранения координат ограничивающего параллелепипеда
    /// </summary>
    public struct BoundingBox : IComparable<BoundingBox>
    {
        /// <summary>
        /// Левая верхняя ближняя точка ограничивающего параллелепипеда
        /// </summary>
        public Point3D LeftUpNear { get; set; }
        /// <summary>
        /// Правая нижняя дальняя точка ограничивающего параллелепипеда
        /// </summary>
        public Point3D RightDownFar { get; set; }
        /// <summary>
        /// Конструктор BoundingBoxCoords
        /// </summary>
        /// <param name="leftUpNear">Левая верхняя ближняя точка</param>
        /// <param name="rightDownNear">Правая нижняя дальняя точка</param>
        public BoundingBox(Point3D leftUpNear, Point3D rightDownNear)
        {
            LeftUpNear = leftUpNear;
            RightDownFar = rightDownNear;
        }
        /// <summary>
        /// GetVolume
        /// </summary>
        /// <returns></returns>
        public float GetSqrCoordsSum()
        {
            var dx = LeftUpNear._x - RightDownFar._x;
            var dy = LeftUpNear._y - RightDownFar._y;
            var dz = LeftUpNear._z - RightDownFar._z;

            return dx * dx + dy * dy + dz * dz;
        }
/// <inheritdoc/>

        public int CompareTo(BoundingBox other)
        {
            if (GetSqrCoordsSum().CompareTo(other.GetSqrCoordsSum()) < 0)
                return -1;
            else if (GetSqrCoordsSum().CompareTo(other.GetSqrCoordsSum()) > 0)
                return 1;
            else
                return 0;
        }
        /// <summary>
        /// Возвращает диагональ параллелепипеда
        /// </summary>
        /// <returns>Диагональ параллелепипеда</returns>
        public float GetDiagonalLength()
        {
            var vec = LeftUpNear.Sub(RightDownFar);
            return Vector.GetVectorLenght(vec);
        }
    }
}
