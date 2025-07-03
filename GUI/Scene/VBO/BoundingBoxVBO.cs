using Geometry;
using System;
using Tao.OpenGl;

namespace BazisGUI.Scene.VBO
{
    public class BoundingBoxVBO : IDisposable
    {
        private int vertexId;//Идентификатор буффера
        /// <summary>
        /// Создает геометрию ограничивающего параллелепипеда (все 6 плоскостей)
        /// </summary>
        /// <param name="leftUp">Крайняя левая верхняя точка объекта IVBObject</param>
        /// <param name="rightDown">Крайняя правая нижняя точка объекта IVBObject</param>
        public BoundingBoxVBO(Point3D leftUp, Point3D rightDown)
        {
            var data = CreateBoundingBoxPlanes(leftUp, rightDown);
            CreateVBO(data);
        }

        public void Bind()
        {
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, vertexId);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, IntPtr.Zero);
        }

        /// <summary>
        /// Очищает буффер VBO
        /// </summary>
        public void Dispose()
        {
            Gl.glDeleteBuffers(1, ref vertexId);
            vertexId = 0;
        }
        /// <summary>
        /// Возвоащает координаты плоскостей ограничивающего параллелепипеда
        /// </summary>
        /// <param name="leftUp">Крайняя левая верхняя точка объекта IVBObject</param>
        /// <param name="rightDown">Крайняя правая нижняя точка объекта IVBObject</param>
        /// <returns>Массив float координат</returns>
        private float[] CreateBoundingBoxPlanes(Point3D leftUp, Point3D rightDown)
        {
            var points = new Point3D[18];
            var data = new float[54];
            //Left Plane
            points[0] = leftUp;//Left up near
            points[1] = new Point3D(leftUp._x, leftUp._y, rightDown._z);//Left up far
            points[2] = new Point3D(leftUp._x, rightDown._y, rightDown._z);//Left down far
            //Right Plane
            points[3] = new Point3D(rightDown._x, leftUp._y, rightDown._z);//Right up far
            points[4] = new Point3D(rightDown._x, leftUp._y, leftUp._z);//Right up near
            points[5] = new Point3D(rightDown._x, rightDown._y, leftUp._z);//Right down near
            //Back Plane
            points[6] = new Point3D(leftUp._x, leftUp._y, rightDown._z);//Back left up
            points[7] = new Point3D(rightDown._x, leftUp._y, rightDown._z);//Back right up
            points[8] = rightDown;//Back right down
            //Front Plane
            points[9] = new Point3D(rightDown._x, leftUp._y, leftUp._z);//Front right up
            points[10] = leftUp;//Front left up
            points[11] = new Point3D(leftUp._x, rightDown._y, leftUp._z);//Front left down
            //Down Plane
            points[12] = new Point3D(rightDown._x, rightDown._y, leftUp._z);//Down right near
            points[13] = new Point3D(leftUp._x, rightDown._y, leftUp._z);//Down left near
            points[14] = new Point3D(leftUp._x, rightDown._y, rightDown._z);//Down left far
            //Up Plane
            points[15] = leftUp;//Up left near
            points[16] = new Point3D(rightDown._x, leftUp._y, leftUp._z);//Up right near
            points[17] = new Point3D(rightDown._x, leftUp._y, rightDown._z);//Up right far
            for(var i = 0; i < points.Length; ++i)
            {
                data[i * 3] = points[i]._x;
                data[i * 3 + 1] = points[i]._y;
                data[i * 3 + 2] = points[i]._z;
            }
            return data;
        }
        /// <summary>
        /// Создает VBO буффер и отпраляет данные на видеокарту
        /// </summary>
        /// <param name="data">Массив координат</param>
        private void CreateVBO(float[] data)
        {
            Gl.glGenBuffers(1, out vertexId);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, vertexId);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(data.Length * sizeof(float)), data, Gl.GL_STREAM_DRAW);
        }
    }
}
