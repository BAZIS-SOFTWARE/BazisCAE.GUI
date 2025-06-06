using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Geometry;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;
using Scene.Interfaces;
using Scene.VBO;
using Tao.OpenGl;

namespace Scene
{
    /// <summary>
    /// Выделение элементов по клику
    /// </summary>
    public class ElementSelector : IDisposable
    {
        private const int pointsCount = 400;
        private const int dataPointsCount = pointsCount * 4;
        private const int sizeOfDataPoints = dataPointsCount * sizeof(double);

        private int pointBuffer;
        private int queryBuffer;

        private ShaderProgramCreator barycentricSolver = new ShaderProgramCreator();
        /// <summary>
        /// Координаты клика мыши
        /// </summary>
        public Point MouseClick { get; set; }
        /// <summary>
        /// Выделение элементов по клику
        /// </summary>
        public ElementSelector()
        {
            barycentricSolver.CreateShaderFromString(Gl.GL_VERTEX_SHADER, ShaderCollections.vertexBarycentricSolver);
            barycentricSolver.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.geometryBarycentricSolver);

            var tfNames = new string[] { "pointData" };
            barycentricSolver.Link(tfNames);

            CreateBuffers();
        }
        /// <summary>
        /// Очистка неуправляемых ресурсов
        /// </summary>
        public void Dispose()
        {
            Gl.glDeleteBuffers(1, ref pointBuffer);
            Gl.glDeleteQueries(1, ref queryBuffer);

            pointBuffer = 0;
            queryBuffer = 0;

            barycentricSolver.Dispose();
        }

        /// <summary>
        /// Находит барицентрические координаты позиции клика относительно треугольника
        /// </summary>
        /// <param name="a">Экранные координаты точки a</param>
        /// <param name="b">Экранные координаты точки b</param>
        /// <param name="c">Экранные координаты точки c</param>
        /// <returns>Параметры u,v,w, экранная z клика, индекс треугольника</returns>
        public double[] SolveBarycentric(double[] a, double[] b, double[] c)
        {
            var mouse = new double[] { 1, MouseClick.X, MouseClick.Y };
            var matrix = Matrix<double>.Build.Dense(3, 3);

            matrix.SetRow(0, new double[] { 1, 1, 1 });

            matrix[1, 0] = a[0];
            matrix[1, 1] = b[0];
            matrix[1, 2] = c[0];

            matrix[2, 0] = a[1];
            matrix[2, 1] = b[1];
            matrix[2, 2] = c[1];

            var detBase = matrix.Determinant();
            if (Math.Abs(detBase) < 1e-4)
                return null;

            var lambda = new double[3];
            for(var i = 0; i < 3; ++i)
            {
                var keep = matrix.Column(i);
                matrix.SetColumn(i, mouse);
                lambda[i] = matrix.Determinant() / detBase;
                matrix.SetColumn(i, keep);
            }

            var vecA = Vector<double>.Build.Dense(a);
            var vecB = Vector<double>.Build.Dense(b);
            var vecC = Vector<double>.Build.Dense(c);

            var result = lambda[0] * vecA + lambda[1] * vecB + lambda[2] * vecC;

            return new double[] { lambda[0], lambda[1], lambda[2], result[2], 0 };
        }

        /// <summary>
        /// Выбрать элемент по клику (вариант на CPU, для тестов)
        /// </summary>
        /// <param name="obj">Объект для выбора</param>
        /// <param name="selectionColor">Цвет выделения</param>
        public void SelectElementSlow(SurfaceObjects obj, Color selectionColor)
        {
            var viewport = new int[4];
            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);

            var matrices = GetMatrices(obj);

            if (obj.GL_ObjType == GLObjType.triangle)
            {
                var vertices = obj.PointsCoords;
                var resultList = new List<double[]>();

                for (int i = 0, j = 0; i < vertices.Length; i += 9, ++j)
                {
                    var a = new double[3];
                    var b = new double[3];
                    var c = new double[3];

                    Glu.gluProject(vertices[i], vertices[i + 1], vertices[i + 2], matrices.Item1, matrices.Item2, 
                                   viewport, out a[0], out a[1], out a[2]);
                    Glu.gluProject(vertices[i + 3], vertices[i + 4], vertices[i + 5], matrices.Item1, matrices.Item2, 
                                   viewport, out b[0], out b[1], out b[2]);
                    Glu.gluProject(vertices[i + 6], vertices[i + 7], vertices[i + 8], matrices.Item1, matrices.Item2, 
                                   viewport, out c[0], out c[1], out c[2]);

                    var result = SolveBarycentric(a, b, c);
                    if(IsInside(result))
                    {
                        result[4] = j;
                        resultList.Add(result);
                    }
                }
                if (resultList.Count > 0)
                {
                    var selection = resultList.OrderBy(v => v[3]).First();
                    SelectElement(obj, selectionColor, (int)selection[4]);
                }
            } 
        }

        /// <summary>
        /// Выбор элемента, шейдерный вариант
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="selectionColor">Цвет подсвечивания элемента</param>
        /// <returns>Индекс элемента в ModelData</returns>
        public int SelectElement(SurfaceObjects obj, Color selectionColor)
        {
            var index = -1;
            if (obj != null)
            {
                BindSettings(obj);
                var data = GetTransformFeedbackData(obj);
                UnbindSettings(obj);
                if (data.Count > 0)
                {
                    var selection = data.OrderBy(v => v[2]).First();
                    index = SelectElement(obj, selectionColor, (int)selection[3]);
                }
            }
            return index;
        }

        private bool IsInside(double[] data)
        {
            if (data == null)
                return false;
            if (data[0] < 0 || data[0] > 1)
                return false;
            if (data[1] < 0 || data[1] > 1)
                return false;
            if (data[2] < 0 || data[2] > 1)
                return false;
            var lambdaSum = data[0] + data[1] + data[2];
            if (Math.Abs(lambdaSum - 1) > 1e-4)
                return false;
            return true;
        }

        private Tuple<double[], double[]> GetMatrices(VBObject obj)
        {
            var modelView = new double[16];
            var projection = new double[16];

            Gl.glGetDoublev(Gl.GL_PROJECTION_MATRIX, projection);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glMultMatrixf(obj.ModelMatrix);
            Gl.glGetDoublev(Gl.GL_MODELVIEW_MATRIX, modelView);
            Gl.glPopMatrix();

            return Tuple.Create(modelView, projection);
        }

        private void BindSettings(VBObject obj)
        {
            Gl.glEnable(Gl.GL_RASTERIZER_DISCARD_NV);

            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);

            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, obj.PointersBuffer);
            Gle.glBindBufferBase(Gl.GL_TRANSFORM_FEEDBACK_BUFFER_NV, 0, (uint)pointBuffer);

            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, obj.CoordsBuffer);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, IntPtr.Zero);

            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, obj.NormalsBuffer);
            Gl.glNormalPointer(Gl.GL_FLOAT, 0, IntPtr.Zero);
        }

        private List<double[]> GetTransformFeedbackData(VBObject obj)
        {
            barycentricSolver.Bind();

            Gl.glBeginQuery(Gl.GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_NV, queryBuffer);
            Gle.glBeginTransformFeedback(Gl.GL_POINTS);

            var data = ExtractDataForShader();
            barycentricSolver.SetUniform("mouseCoord", data.Item1);
            barycentricSolver.SetUniform("viewport", data.Item2);

            Gl.glDrawElements(Gl.GL_TRIANGLES, obj.PtrLength, Gl.GL_UNSIGNED_INT, IntPtr.Zero);

            Gle.glEndTransformFeedback();
            Gl.glEndQuery(Gl.GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_NV);
            Gl.glFlush();
            barycentricSolver.Unbind();

            var tfData = new double[dataPointsCount];
            Gl.glGetBufferSubData(Gl.GL_TRANSFORM_FEEDBACK_BUFFER_NV, IntPtr.Zero, (IntPtr)(sizeOfDataPoints), tfData);

            var primitiveProcessed = 0;
            Gl.glGetQueryObjectiv((uint)queryBuffer, Gl.GL_QUERY_RESULT, out primitiveProcessed);

            var result = new List<double[]>();
            for(var i = 0; i < primitiveProcessed; ++i)
            {
                var attributes = new double[4];
                var stride = i * 4;

                for (var j = 0; j < 4; ++j)
                    attributes[j] = tfData[stride + j];

                result.Add(attributes);
            }
            return result;
        }

        private void UnbindSettings(VBObject obj)
        {
            Gle.glBindBufferBase(Gl.GL_TRANSFORM_FEEDBACK_BUFFER_NV, 0, 0);
            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, 0);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);

            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glDisableClientState(Gl.GL_NORMAL_ARRAY);

            Gl.glDisable(Gl.GL_RASTERIZER_DISCARD_NV);
        }

        private Tuple<float[], float[]> ExtractDataForShader()
        {
            var viewport = new int[4];
            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);

            var viewportData = new float[2] { viewport[2], viewport[3] };
            var mouseCoords = new float[2] { MouseClick.X, MouseClick.Y};

            return Tuple.Create(mouseCoords, viewportData);
        }

        private int SelectElement(SurfaceObjects obj, Color selectionColor, int selection)
        {
            var separators = obj.Separators;
            var index = IndexSearch(separators, selection);

            if (index != -1)
            {
                var start = separators[index];
                var end = separators[index + 1];
                var triangles = end - start;

                var r = selectionColor.R / 255f;
                var g = selectionColor.G / 255f;
                var b = selectionColor.B / 255f;
                var a = selectionColor.A / 255f;

                var colorData = new float[triangles * 12];
                for (var i = 0; i < colorData.Length; i += 4)
                {
                    colorData[i] = r;
                    colorData[i + 1] = g;
                    colorData[i + 2] = b;
                    colorData[i + 3] = a;
                }

                VBO.VBO.SetSubData(obj.ColorsBuffer, start * 12 * sizeof(float), triangles * 12 * sizeof(float), colorData);
            }
            return index;
        }

        private int IndexSearch(int[] separators, int triangleOffset)
        {
            for (var i = 1; i < separators.Length; ++i)
                if (triangleOffset  >= separators[i - 1] && triangleOffset < separators[i])
                    return i - 1;
            return -1;
        }

        private void CreateBuffers()
        {
            Gl.glGenBuffers(1, out pointBuffer);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, pointBuffer);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)sizeOfDataPoints, IntPtr.Zero, Gl.GL_STATIC_READ);

            Gl.glGenQueries(1, out queryBuffer);
        } 
    }
}
