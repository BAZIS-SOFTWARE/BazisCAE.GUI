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
    public class SceneCamera
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

        //public Point3D GetSceneCoordOfScreenVector(float x, float y)
        //{
        //    float[] point = new float[4] { x, y, 0, 0 };

        //    Matrix<float> matrix = ViewMatrix.Transpose();
        //    Vector<float> vector = Vector<float>.Build.DenseOfArray(point);

        //    matrix.Multiply(vector, vector);

        //    return new Point3D(vector[0], vector[1], vector[2]);
        //}

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
        

        /// <inheritdoc/>
        //public Point3D GetSceenCoord(float x, float y, float z)
        //{
        //    float[] point = new float[4] 
        //    { 
        //        x - Position._x,
        //        y - Position._y,
        //        z - Position._z,
        //        1 
        //    }; // первоначальные видовые координаты искомой точки точки

        //    var viewMatrix = GetViewMatrix();

        //    //Matrix<float> operate = Matrix<float>.Build.DenseOfArray(viewMatrix);
        //    Vector<float> vector = Vector<float>.Build.DenseOfArray(point); // видовые координаты искомой точки точки после преобразования

        //    viewMatrix.Multiply(vector, vector);

        //    return new Point3D(vector[0], vector[1], vector[2]);
        //}
        ///// <inheritdoc/>
        //public Point3D GetSceenCoord(Point3D point)
        //{
        //    var shift = point.Sub(Position);
        //    float[] pointV = new float[4] { shift._x, shift._y, shift._z, 1 }; // первоначальные видовые координаты искомой точки точки

        //    var viewMatrix = GetViewMatrix();
        //    var vector = Vector<float>.Build.DenseOfArray(pointV); // видовые координаты искомой точки точки после преобразования

        //    viewMatrix.Multiply(vector, vector);

        //    return new Point3D(vector[0], vector[1], vector[2]);
        //}
        ///// <inheritdoc/>
        //public Point3D GetSceenCoord(Point2D point2D, float depth, float scaleFactor)
        //{
        //    var view_port_koeff = ((float)Height / Width);
        //    var tan = (float)Math.Tan(AngleOfProjection * 3.14f / 180);
        //    var xs = point2D._x * tan * depth / view_port_koeff / Width; //вычисление экранной Хэ координат искомой точки узлов (2, 4)
        //    var ys = point2D._y * tan * depth / Height; //вычисление экранной Уэ координат искомой точки

        //    xs = xs / scaleFactor / scaleFactor;
        //    ys = ys / scaleFactor / scaleFactor;

        //    var scnc = GetSceneCoordOfScreenVector(xs, ys);

        //    return new Point3D(scnc._x, scnc._y, scnc._z);
        //}
        ///// <inheritdoc/>
        //public Point2D GetScreenCoord(Point3D coord)
        //{
        //    var zn = coord._z;
        //    var xn = -(coord._x / coord._z);
        //    var yn = -(coord._y / coord._z);
        //    var view_port_koeff = ((float)Height / Width);
        //    var tan = (float)Math.Tan(AngleOfProjection * 3.14f / 180);
        //    var x_scr = xn * view_port_koeff * (Width / tan); //вычисление экранной Хэ координат искомой точки узлов (2, 4)
        //    var y_scr = yn * (Height / tan); //вычисление экранной Уэ координат искомой точки

        //    return new Point2D(x_scr, y_scr);
        //}
        /// <inheritdoc/>
        
    }
}
