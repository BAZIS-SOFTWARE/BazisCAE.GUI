using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazisGUI.Scene
{
    /// <summary>
    /// Структура хранения координат ограничивающего параллелепипеда
    /// </summary>
    public class BoundingBox : IComparable<BoundingBox>
    {
        Point3D[] corners = new Point3D[8]; 
        /// <summary>
        /// Левая верхняя ближняя точка ограничивающего параллелепипеда
        /// </summary>
        public Point3D LeftUpNear { get; private set; }
        /// <summary>
        /// Правая нижняя дальняя точка ограничивающего параллелепипеда
        /// </summary>
        public Point3D RightDownFar { get; private set; }
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
        public BoundingBox(float[] coords)
        {
            if (coords.Length != 0)
            {
                var xMin = coords[0];
                var xMax = coords[0];
                var yMin = coords[1];
                var yMax = coords[1];
                var zMin = coords[2];
                var zMax = coords[2];
                for (var i = 0; i < coords.Length; i += 3)
                {
                    xMin = Math.Min(xMin, coords[i]);
                    xMax = Math.Max(xMax, coords[i]);
                    yMin = Math.Min(yMin, coords[i + 1]);
                    yMax = Math.Max(yMax, coords[i + 1]);
                    zMin = Math.Min(zMin, coords[i + 2]);
                    zMax = Math.Max(zMax, coords[i + 2]);
                }
                LeftUpNear = new Point3D(xMin, yMax, zMax);
                corners[0] = LeftUpNear;
                corners[1] = new Point3D(xMin, yMax, zMin);
                corners[2] = new Point3D(xMin, yMin, zMin);
                corners[3] = new Point3D(xMin, yMin, zMax);
                RightDownFar = new Point3D(xMax, yMin, zMin);
                corners[4] = RightDownFar;
                corners[5] = new Point3D(xMax, yMin, zMax);
                corners[6] = new Point3D(xMax, yMax, zMax);
                corners[7] = new Point3D(xMax, yMax, zMin);

                //BoundingBox = new BoundingBox(leftUpNear, rightDownFar);
            }
        }
        /// <summary>
        /// GetCornerPoints
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Point3D> GetCornerPoints()
        {
            foreach (var item in corners)
            {
                yield return item;
            }
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
            return Vector.GetVectorLength(vec);
        }
    }
}
