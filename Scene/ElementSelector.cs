using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using Scene.Interfaces;
using Scene.VBO;
using Tao.OpenGl;

namespace Scene
{
    /// <summary>
    /// 
    /// </summary>
    public class ElementSelector : IDisposable
    {
        private const int pointsCount = 400;
        private const int dataPointsCount = pointsCount * 4;
        private const int sizeOfDataPoints = dataPointsCount * sizeof(float);

        private int pointBuffer;
        private int queryBuffer;

        private ShaderProgramCreator lCoordinateSolver = new ShaderProgramCreator();
        /// <summary>
        /// Координаты клика мыши
        /// </summary>
        public Point MouseClick { get; set; }
        /// <summary>
        /// Параметры выделенного элемента (индекс в массиве):
        /// 0 - параметр t (коэффициент удаления от камеры до точки клика)
        /// 1 - параметр u (Барицентрическая координата первой точки треугольника)
        /// 2 - параметр v (Барицентрическая координата второй точки треугольника)
        /// 3 - параметр offset (Смещение выбранного треугольника относительно начала массива glCoords)
        /// </summary>
        public float[] SelectionParams { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public ElementSelector()
        {
            lCoordinateSolver.CreateShaderFromString(Gl.GL_VERTEX_SHADER, ShaderCollections.vertexLcoordinatesSolver);
            lCoordinateSolver.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.geometryLcoordinatesSolver);

            var tfNames = new string[] { "pointData" };
            lCoordinateSolver.Link(tfNames);

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

            lCoordinateSolver.Dispose();
        }

        private void CalculateRay(VBObject vbo, Point mouse, out Vector<float> camPos, out Vector<float> rayDir)
        {
            var mv = new double[16];
            var proj = new double[16];
            var viewport = new int[4];

            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);
            Gl.glGetDoublev(Gl.GL_PROJECTION_MATRIX, proj);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glMultMatrixf(vbo.ModelMatrix);
            Gl.glGetDoublev(Gl.GL_MODELVIEW_MATRIX, mv);
            Gl.glPopMatrix();

            double nearX, nearY, nearZ;
            double farX, farY, farZ;
            Glu.gluUnProject(mouse.X, viewport[3] - mouse.Y, 0, mv, proj, viewport, out nearX, out nearY, out nearZ);

            var winZ = new float[1];
            Gl.glReadPixels(mouse.X, viewport[3] - mouse.Y, 1, 1, Gl.GL_DEPTH_COMPONENT, Gl.GL_FLOAT, winZ);
            Glu.gluUnProject(mouse.X, viewport[3] - mouse.Y, winZ[0], mv, proj, viewport, out farX, out farY, out farZ);

            camPos = Vector<float>.Build.Dense(new float[] { (float)nearX, (float)nearY, (float)nearZ });
            rayDir = Vector<float>.Build.Dense(new float[] { (float)farX, (float)farY, (float)farZ });
            rayDir = rayDir - camPos;
        }

        private Tuple<float, float, float, float> SolveBarycentric(Vector<float> eye, Vector<float> dir, Vector<float> a, Vector<float> b, Vector<float> c)
        {
            var mat = Matrix<float>.Build.Dense(3, 3);
            var edgeA = a - c;
            var edgeB = b - c;
            mat.SetColumn(0, -dir);
            mat.SetColumn(1, edgeA);
            mat.SetColumn(2, edgeB);
            var free = eye - c;
            var det = mat.Determinant();
            if (Math.Abs(det) < 1e-4)
               return Tuple.Create(-1.0f, -1.0f, -1.0f, -1.0f);
            mat.SetColumn(1, free);
            var u = mat.Determinant() / det;
            if (u < 0.0f || u > 1.0f)
                return Tuple.Create(-1.0f, -1.0f, -1.0f, -1.0f);
            mat.SetColumn(1, edgeA);
            mat.SetColumn(2, free);
            var v = mat.Determinant() / det;
            if (v < 0.0f || v > 1.0f)
                return Tuple.Create(-1.0f, -1.0f, -1.0f, -1.0f);
            var w = 1 - u - v;
            if (w < 0.0f || w > 1.0f)
                return Tuple.Create(-1.0f, -1.0f, -1.0f, -1.0f);
            var sum = u + v + w;
            if (Math.Abs(sum - 1) > 1e-4)
                return Tuple.Create(-1.0f, -1.0f, -1.0f, -1.0f);
            mat.SetColumn(0, free);
            mat.SetColumn(2, edgeB);
            var t = mat.Determinant() / det;
            return Tuple.Create(t, u, v, w);
        }

        /// <summary>
        /// Выбрать элемент по клику (вариант на CPU, временный)
        /// </summary>
        /// <param name="obj">Объект для выбора</param>
        /// <param name="selectionColor">Цвет выделения</param>
        public void SelectElementSlow(VBObject obj, Color selectionColor)
        {
            Vector<float> eye;
            Vector<float> dir;
            CalculateRay(obj, MouseClick, out eye, out dir);
            var resultList = new List<Tuple<float, int>>();
            if (obj.GL_ObjType == GLObjType.triangle)
            {
                var vertices = obj.PointsCoords;
                for (int i = 0, j = 0; i < vertices.Length; i += 9, ++j)
                {
                    var a = Vector<float>.Build.Dense(new float[] { vertices[i], vertices[i + 1], vertices[i + 2] });
                    var b = Vector<float>.Build.Dense(new float[] { vertices[i + 3], vertices[i + 4], vertices[i + 5] });
                    var c = Vector<float>.Build.Dense(new float[] { vertices[i + 6], vertices[i + 7], vertices[i + 8] });
                    var tData = SolveBarycentric(eye, dir, a, b, c);
                    if (tData.Item1 >= 0.99f)
                        resultList.Add(Tuple.Create(tData.Item1, j));
                }
            }
            if (resultList.Count > 0)
            {
                var selection = resultList.OrderBy(v => v.Item1).First();
                SelectElement((SurfaceObjects)obj, selectionColor, selection.Item2);
            }
        }

        /// <summary>
        /// Выбор элемента, шейдерный вариант
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="selectionColor">Цвет подсвечивания элемента</param>
        /// <returns>Индекс элемента в ModelData</returns>
        public int SelectElement(VBObject obj, Color selectionColor)
        {
            var index = -1;
            if (obj != null)
            {
                BindSettings(obj);
                var data = GetTransformFeedbackData(obj);
                UnbindSettings(obj);
                if (data.Count > 0)
                {
                    var selection = data.OrderBy(v => v[0]).First();
                    SelectionParams = selection;

                    index = SelectElement((SurfaceObjects)obj, selectionColor, (int)SelectionParams[3]);
                }
            }
            return index;
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

        private List<float[]> GetTransformFeedbackData(VBObject obj)
        {
            lCoordinateSolver.Bind();

            Gl.glBeginQuery(Gl.GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_NV, queryBuffer);
            Gle.glBeginTransformFeedback(Gl.GL_POINTS);

            var localData = GetLocalVectors(obj);
            lCoordinateSolver.SetUniform("localPos", localData.Item1);
            lCoordinateSolver.SetUniform("localDir", localData.Item2);

            Gl.glDrawElements(Gl.GL_TRIANGLES, obj.PtrLength, Gl.GL_UNSIGNED_INT, IntPtr.Zero);

            Gle.glEndTransformFeedback();
            Gl.glEndQuery(Gl.GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_NV);
            Gl.glFlush();
            lCoordinateSolver.Unbind();

            var result_available = Gl.GL_FALSE;
            while (result_available == Gl.GL_FALSE)
                Gl.glGetQueryObjectiv((uint)queryBuffer, Gl.GL_QUERY_RESULT_AVAILABLE, out result_available);
            var primitiveProcessed = 0;
            Gl.glGetQueryObjectiv((uint)queryBuffer, Gl.GL_QUERY_RESULT, out primitiveProcessed);

            var tfData = new float[dataPointsCount];
            Gl.glGetBufferSubData(Gl.GL_TRANSFORM_FEEDBACK_BUFFER_NV, IntPtr.Zero, (IntPtr)(sizeOfDataPoints), tfData);

            var result = new List<float[]>();
            for(var i = 0; i < primitiveProcessed; ++i)
            {
                var attributes = new float[4];
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

        private Tuple<float[], float[]> GetLocalVectors(VBObject obj)
        {
            var mv = new double[16];
            var proj = new double[16];
            var viewport = new int[4];

            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);
            Gl.glGetDoublev(Gl.GL_PROJECTION_MATRIX, proj);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glMultMatrixf(obj.ModelMatrix);
            Gl.glGetDoublev(Gl.GL_MODELVIEW_MATRIX, mv);
            Gl.glPopMatrix();

            double nearX, nearY, nearZ;
            double farX, farY, farZ;
            Glu.gluUnProject(MouseClick.X, viewport[3] - MouseClick.Y, 0, mv, proj, viewport, out nearX, out nearY, out nearZ);

            var winZ = new float[1];
            Gl.glReadPixels(MouseClick.X, viewport[3] - MouseClick.Y, 1, 1, Gl.GL_DEPTH_COMPONENT, Gl.GL_FLOAT, winZ);
            Glu.gluUnProject(MouseClick.X, viewport[3] - MouseClick.Y, winZ[0], mv, proj, viewport, out farX, out farY, out farZ);

            var camPos = Vector<float>.Build.Dense(new float[] { (float)nearX, (float)nearY, (float)nearZ });
            var rayDir = Vector<float>.Build.Dense(new float[] { (float)farX, (float)farY, (float)farZ });
            rayDir = rayDir - camPos;

            return Tuple.Create(camPos.ToArray(), rayDir.ToArray());
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
                if (triangleOffset  >= separators[i - 1] && triangleOffset <= separators[i])
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
