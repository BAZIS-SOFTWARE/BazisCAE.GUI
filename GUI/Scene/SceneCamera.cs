using BazisGUI.Scene.Interfaces;
using Geometry;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Drawing;
using Tao.OpenGl;

namespace BazisGUI.Scene
{
    /// <summary>
    /// SceneCamera
    /// </summary>
    public class SceneCamera : ISceneCamera
    {
        /// <inheritdoc/>
        public int Width { get; set; }
        /// <inheritdoc/>
        public int Height { get; set; }
        /// <inheritdoc/>

        //public float ScaleFactor { get; set; } = 1;
/// <inheritdoc/>

        public float AngleOfProjection { get; set; }

        Point3D position = new Point3D();
        /// <inheritdoc/>
        public Point3D Position
        {
            get { return position; }
            set 
            {
                position = value;
                var matrix = GetViewMatrix();
                matrix[0, 3] = 0; matrix[1, 3] = 0;
                var tempViewMatrixAr = matrix.AsColumnMajorArray();

                Gl.glLoadMatrixf(tempViewMatrixAr);
            }
        }
        /// <inheritdoc/>
        public void SetViewMatrix(Matrix<float> matrix)
        {
            var tempViewMatrixAr = matrix.AsColumnMajorArray();
            Gl.glLoadMatrixf(tempViewMatrixAr);
        }
/// <inheritdoc/>

        public Matrix<float> GetViewMatrix()
        {
            float[] vector = new float[16];
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, vector);
            //float[,] multiMassView = new float[4, 4];

            var matrix = Matrix<float>.Build.Dense(4,4);

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    matrix[j, i] = vector[(i * 4) + j];
                }
            }

            return matrix;
        }
/// <inheritdoc/>

        public Point3D GetSceneCoordOfScreenVector(float x, float y)
        {
            float[] point = new float[4] { x, y, 0, 0 };

            Matrix<float> matrix = GetViewMatrix().Transpose();
            Vector<float> vector = Vector<float>.Build.DenseOfArray(point);

            matrix.Multiply(vector, vector);

            return new Point3D(vector[0], vector[1], vector[2]);
        }

        /// <summary>
        /// SceneCamera
        /// </summary>
        /// <param name="moveX"></param>
        /// <param name="moveY"></param>
        /// <param name="moveZ"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="angleOfProjection"></param>
        public SceneCamera(float moveX, float moveY, float moveZ, int width, int height, float angleOfProjection)
        {
            //SelectedObjsDict = new Dictionary<ObjType, List<int>>();
            Width = width;
            Height = height;
            //ScaleFactor = 1;
            AngleOfProjection = angleOfProjection;
            // подклюение функции проверки буфера глубины 
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            // задать цвет очистки экрана
            Gl.glClearColor(1, 1, 1, 0);

            // выполнение очистки буфера цвета и буфера глубины в заданный цвет glClearColor(1, 1, 1, 0) 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, width, height);

            // настройка матрицы проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            //Gl.glOrtho(0, baseScene.Width, 0, baseScene.Height, 0.1, 2000);
            Glu.gluPerspective(angleOfProjection, (double)width / height, 1, 2000);

            // настройка матрицы видовых преобразований  
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glTranslatef(moveX, moveY, moveZ);
        }
        /// <inheritdoc/>
        public void Move(Point new_mousePosition, Point mousePosition, float scaleFactor)
        {
            var dx = new_mousePosition.X - mousePosition.X;
            var dy = new_mousePosition.Y - mousePosition.Y;

            var pos = new Point2D(-dx, -dy);

            var crd = GetSceenCoord(pos, -5, scaleFactor);

            Gl.glTranslatef(crd._x, crd._y, crd._z);
        }

        /// <inheritdoc/>
        public Point3D GetSceenCoord(float x, float y, float z)
        {
            float[] point = new float[4] 
            { 
                x - Position._x,
                y - Position._y,
                z - Position._z,
                1 
            }; // первоначальные видовые координаты искомой точки точки

            var viewMatrix = GetViewMatrix();

            //Matrix<float> operate = Matrix<float>.Build.DenseOfArray(viewMatrix);
            Vector<float> vector = Vector<float>.Build.DenseOfArray(point); // видовые координаты искомой точки точки после преобразования

            viewMatrix.Multiply(vector, vector);

            return new Point3D(vector[0], vector[1], vector[2]);
        }
        /// <inheritdoc/>
        public Point3D GetSceenCoord(Point3D point)
        {
            var shift = point.Sub(Position);
            float[] pointV = new float[4] { shift._x, shift._y, shift._z, 1 }; // первоначальные видовые координаты искомой точки точки

            var viewMatrix = GetViewMatrix();
            var vector = Vector<float>.Build.DenseOfArray(pointV); // видовые координаты искомой точки точки после преобразования

            viewMatrix.Multiply(vector, vector);

            return new Point3D(vector[0], vector[1], vector[2]);
        }
        /// <inheritdoc/>
        public Point3D GetSceenCoord(Point2D point2D, float depth, float scaleFactor)
        {
            var view_port_koeff = ((float)Height / Width);
            var tan = (float)Math.Tan(AngleOfProjection * 3.14f / 180);
            var xs = point2D._x * tan * depth / view_port_koeff / Width; //вычисление экранной Хэ координат искомой точки узлов (2, 4)
            var ys = point2D._y * tan * depth / Height; //вычисление экранной Уэ координат искомой точки

            xs = xs / scaleFactor / scaleFactor;
            ys = ys / scaleFactor / scaleFactor;

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
            var tan = (float)Math.Tan(AngleOfProjection * 3.14f / 180);
            var x_scr = xn * view_port_koeff * (Width / tan); //вычисление экранной Хэ координат искомой точки узлов (2, 4)
            var y_scr = yn * (Height / tan); //вычисление экранной Уэ координат искомой точки

            return new Point2D(x_scr, y_scr);
        }
        /// <inheritdoc/>
        public void Rotate(ViewAxis axis, float angle)
        {
            switch (axis)
            {
                case ViewAxis.X:
                    var crdx = GetSceneCoordOfScreenVector(-1, 0);
                    Gl.glRotatef(angle, crdx._x, crdx._y, crdx._z);
                    break;
                case ViewAxis.Y:
                    var crdy = GetSceneCoordOfScreenVector(0, -1);
                    Gl.glRotatef(angle, crdy._x, crdy._y, crdy._z);
                    break;
                case ViewAxis.Z:

                    float[] point = new float[4] { 0, 0, 1, 0 };

                    var matrix = GetViewMatrix().Transpose();
                    var vectorZ = Vector<float>.Build.DenseOfArray(point);

                    matrix.Multiply(vectorZ, vectorZ);
                    Gl.glRotatef(angle, vectorZ[0], vectorZ[1], vectorZ[2]);
                    break;
            }
        }
        /// <inheritdoc/>
        public void Rotate(float vector_dx, float vector_dy, ViewAxis axis, float angle)
        {
            switch (axis)
            {
                case ViewAxis.X:
                    if (vector_dx == 0)
                        if (vector_dy > 0)
                        {
                            var crdx = GetSceneCoordOfScreenVector(1, 0);
                            Gl.glRotatef(angle, crdx._x, crdx._y, crdx._z);
                        }
                        else
                        {
                            var crdx = GetSceneCoordOfScreenVector(-1, 0);
                            Gl.glRotatef(angle, crdx._x, crdx._y, crdx._z);
                        }
                    break;
                case ViewAxis.Y:
                    if (vector_dy == 0)
                        if (vector_dx > 0)
                        {
                            var crdy = GetSceneCoordOfScreenVector(0, 1);
                            Gl.glRotatef(angle, crdy._x, crdy._y, crdy._z);
                        }
                        else
                        {
                            var crdy = GetSceneCoordOfScreenVector(0, -1);
                            Gl.glRotatef(angle, crdy._x, crdy._y, crdy._z);
                        }
                    break;
                case ViewAxis.Z:
                    if (vector_dy == 0)
                        if (vector_dx > 0)
                        {
                            float[] point = new float[4] { 0, 0, 1, 0 };

                            var matrix = GetViewMatrix().Transpose();
                            var vectorZ = Vector<float>.Build.DenseOfArray(point);

                            matrix.Multiply(vectorZ, vectorZ);
                            Gl.glRotatef(angle, vectorZ[0], vectorZ[1], vectorZ[2]);
                        }
                        else
                        {
                            float[] point = new float[4] { 0, 0, -1, 0 };

                            var matrix = GetViewMatrix().Transpose();
                            var vectorZ = Vector<float>.Build.DenseOfArray(point);

                            matrix.Multiply(vectorZ, vectorZ);
                            Gl.glRotatef(angle, vectorZ[0], vectorZ[1], vectorZ[2]);
                        }
                    break;
                case ViewAxis.XYZ:
                    var crdxyz = GetSceneCoordOfScreenVector(-vector_dy, vector_dx);
                    Gl.glRotatef(angle, crdxyz._x, crdxyz._y, crdxyz._z);
                    break;
            }
        }
        /// <inheritdoc/>
        public void SetOnPlane(ViewPlane plane, float scaleFactor)
        {
            var matrix = GetViewMatrix();
            var x = matrix[0, 3];
            var y = matrix[1, 3];
            var z = matrix[2, 3];

            var tempViewMatrix = new float[4, 4];

            tempViewMatrix[0, 0] = scaleFactor;
            tempViewMatrix[1, 1] = scaleFactor;
            tempViewMatrix[2, 2] = scaleFactor;
            tempViewMatrix[0, 3] = x;
            tempViewMatrix[1, 3] = y;
            tempViewMatrix[2, 3] = z;
            tempViewMatrix[3, 3] = 1;
            var tempViewMatrixAr = Matrix<float>.Build.DenseOfArray(tempViewMatrix).AsColumnMajorArray();

            Gl.glLoadMatrixf(tempViewMatrixAr);
            switch (plane)
            {
                case ViewPlane.XY:
                    break;
                case ViewPlane.XZ:
                    //Translation_dx = 1; Translation_dy = 0;
                    Rotate(ViewAxis.X, -90);
                    break;
                case ViewPlane.YZ:
                    //Translation_dx = 0; Translation_dy = 1;
                    Rotate(ViewAxis.Y, 90);
                    break;
            }
        }

        /// <inheritdoc/>
        public static float[] GetReflectionMatrix(Plane plane)
        {
            var reflection = new float[16];
            var x = -plane.Normal._x;
            var y = -plane.Normal._y;
            var z = -plane.Normal._z;
            var d = plane.Shifting;
            reflection[0] = 1 - 2 * x * x;
            reflection[1] = -2 * x * y;
            reflection[2] = -2 * x * z;
            reflection[3] = 0.0f;
            reflection[4] = -2 * x * y;
            reflection[5] = 1 - 2 * y * y;
            reflection[6] = -2 * y * z;
            reflection[7] = 0.0f;
            reflection[8] = -2 * x * z;
            reflection[9] = -2 * y * z;
            reflection[10] = 1 - 2 * z * z;
            reflection[11] = 0.0f;
            reflection[12] = -2 * x * d;
            reflection[13] = -2 * y * d;
            reflection[14] = -2 * z * d;
            reflection[15] = 1.0f;
            return reflection;
        }
    }
}
