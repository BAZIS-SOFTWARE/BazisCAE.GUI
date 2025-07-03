
using System;
using Tao.OpenGl;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;

namespace BazisGUI.Scene
{
    /// <summary>
    /// Режим отсечения, устанавливаемый при отрисовке модели
    /// </summary>
    public enum ClipMode
    {
        /// <summary>
        /// Отключено
        /// </summary>
        None,
        /// <summary>
        /// По умолчанию, с разрезанием элемента
        /// </summary>
        Default,
        /// <summary>
        /// Послойное, сохраняет элементы только в месте сечения
        /// </summary>
        Layered,
        /// <summary>
        /// Полное отображение 3д элементов в месте сечения и в положительной полуплоскости сечения
        /// </summary>
        KeepElement
    }


    /// <summary>
    /// Класс для улучшенного сокрытия 3д элементов, работает только с элементами типа тетраэдр !
    /// </summary>
    public class Advanced3DClipper : IDisposable, IActiveDrawingObject
    {
        private int leftUpBuffer;//Идентификатор буффера левых верхних углов (BoundingBox) элементов
        private int rightDownBuffer;//Идентификатор буффера правых нижних углов (BoundingBox) элементов

        /// <summary>
        /// Программа, для полного отображения 3д элементов в месте сечения и в положительной полуплоскости сечения
        /// </summary>
        public ShaderProgramCreator KeepElementSurfaceRenderer { get; private set; }

        /// <summary>
        /// Программа, для полного отображения каркаса в месте сечения и в положительной полуплоскости сечения
        /// </summary>
        public ShaderProgramCreator KeepElementWireframeRenderer { get; private set; }

        /// <summary>
        /// Программа, для полного отображения точек в месте сечения и в положительной полуплоскости сечения в режиме прозрачности
        /// </summary>
        public ShaderProgramCreator KeepElementPointsRenderer { get; private set; }


        /// <summary>
        /// Программа, для послойного отображения 3д элементов, сохраняет элементы только в месте сечения
        /// </summary>
        public ShaderProgramCreator LayerSurfaceRenderer { get; private set; }

        /// <summary>
        /// Программа, для послойного отображения каркаса, сохраняет элементы только в месте сечения
        /// </summary>
        public ShaderProgramCreator LayerWireframeRenderer { get; private set; }

        /// <summary>
        /// Программа, для послойного отображения точек, сохраняет элементы только в месте сечения
        /// </summary>
        public ShaderProgramCreator LayerPointsRenderer { get; private set; }

        /// <summary>
        /// Режим отсечения
        /// </summary>
        public ClipMode ClipMode { get; set; }

        /// <summary>
        /// Установка матрицы отсечения
        /// </summary>
        public float[] ClipEquat { get; set; } 
        /// <summary>
        /// Матрица в простанстве плоскости отсечения, нужна для включения отсечения для конкретного объекта, а не пространства
        /// </summary>
        public float[] ClipMatrix { get; set; }
        /// <summary>
        /// Флаг улучшенного сечения
        /// </summary>
        public bool IsEnable {  get; set; }

        /// <summary>
        /// Установить толщину слоя
        /// </summary>
        public float LayerThickness { get; set; } = 1f;

        /// <summary>
        /// Коэффициент масштабирования, полученный от камеры
        /// </summary>
        public float ScaleFactor { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        public Advanced3DClipper()
        {
            ClipEquat = new float[4];
            ClipMatrix = new float[16];

            var vertexOld_1 = ShaderCollections.baseVertex[1];
            var vertexOld_2 = ShaderCollections.baseVertex[2];
            var geometryOld_1 = ShaderCollections.keepElementsGeometry[1];
            var geometryOld_2 = ShaderCollections.keepElementsGeometry[2];
            var fragmentOld_1 = ShaderCollections.baseFragment[1];

            CreateKeepElementSurfaceRenderer();
            CreateKeepElementWireframeRenderer();
            CreateKeepElementPointsRenderer();
            //Восстановление старых настроек
            ChangeCompilationCondition(1, ShaderCollections.baseVertex, vertexOld_1);
            ChangeCompilationCondition(2, ShaderCollections.baseVertex, vertexOld_2);
            ChangeCompilationCondition(1, ShaderCollections.keepElementsGeometry, geometryOld_1);
            ChangeCompilationCondition(2, ShaderCollections.keepElementsGeometry, geometryOld_2);
            ChangeCompilationCondition(1, ShaderCollections.baseFragment, fragmentOld_1);

            CreateLayerSurfaceRenderer();
            CreateLayerWireframeRenderer();
            CreateLayerPointsRenderer();
            //Восстановление старых настроек
            ChangeCompilationCondition(1, ShaderCollections.baseVertex, vertexOld_1);
            ChangeCompilationCondition(2, ShaderCollections.baseVertex, vertexOld_2);
            ChangeCompilationCondition(1, ShaderCollections.keepElementsGeometry, geometryOld_1);
            ChangeCompilationCondition(2, ShaderCollections.keepElementsGeometry, geometryOld_2);
            ChangeCompilationCondition(1, ShaderCollections.baseFragment, fragmentOld_1);
        }

        /// <summary>
        /// Создать ограничивающие параллелепипеды для 3д элементов, вызывать только для vbo типа 3D SurfaceObjects
        /// </summary>
        /// <param name="vbo">[In]3D SurfaceObjects</param>
        public void Create3DBoundingBoxes(SurfaceObjects vbo)
        {
            if (leftUpBuffer == 0 && rightDownBuffer == 0 && IsShowInsideEnabled(vbo))
            {
                var points = vbo.PointsCoords;
                var separators = vbo.Separators;
                float[] leftUp, rightDown;
                BuildBoundingBoxes(points, separators, out leftUp, out rightDown);
                VBO.VBO.VertexDataInit(ref leftUpBuffer, leftUp, sizeof(float));
                VBO.VBO.VertexDataInit(ref rightDownBuffer, rightDown, sizeof(float));
            }
        }

        /// <summary>
        /// Выполнить действия перед вызовом glDrawElements
        /// </summary>
        /// <param name="vbo">[In]Вбо-объект, который вызывает отрисовку</param>
        /// <param name="elements">[In]Элемент отрисовки</param>
        public void DoActionsBeforeDrawing(VBObject vbo, DrawElements elements)
        {
            if (elements != DrawElements.Surfaces && elements != DrawElements.Wireframe)
                return;

            ApplyMatrixSettings();
            if (ClipMode != ClipMode.Default)
            {
                ShaderProgramCreator program = null;
                if (elements == DrawElements.Surfaces)
                {
                    if (!IsShowInsideEnabled((SurfaceObjects)vbo))
                        return;
                    program = ClipMode == ClipMode.KeepElement ? KeepElementSurfaceRenderer : LayerSurfaceRenderer;
                    program.Bind();
                }
                else if (elements == DrawElements.Wireframe)
                {
                    if (!IsShowInsideEnabled((SurfaceObjects)vbo))
                        return;
                    program = ClipMode == ClipMode.KeepElement ? KeepElementWireframeRenderer : LayerWireframeRenderer;
                    program.Bind();
                    program.SetCustomAttributes(((SurfaceObjects)vbo).EdgeBuffer, "wire", 1, Gl.GL_UNSIGNED_BYTE);
                }

                var lighting = Gl.glIsEnabled(Gl.GL_LIGHTING);
                program.SetUniform("isLighting", new float[] { lighting });
                program.SetUniform("clipEquat", ClipEquat);

                if (ClipMode == ClipMode.Layered)
                {
                    program.SetUniform("layerThickness", new float[] { LayerThickness });
                    program.SetUniform("scaleFactor", new float[] { ScaleFactor });
                }

                program.SetCustomAttributes(leftUpBuffer, "inLeftUp");
                program.SetCustomAttributes(rightDownBuffer, "inRightDown");
            }
        }

        /// <summary>
        /// Выполнить действия после вызова glDrawElements
        /// </summary>
        /// <param name="vbo">[In]Вбо-объект, который заканчивает отрисовку</param>
        /// <param name="elements">[In]Элемент отрисовки</param>
        public void DoActionsAfterDrawing(VBObject vbo, DrawElements elements)
        {
            Gl.glDisable(Gl.GL_CLIP_PLANE0);
            if (elements != DrawElements.Surfaces && elements != DrawElements.Wireframe)
                return;

            ShaderProgramCreator program = null;
            if (elements == DrawElements.Surfaces)
                program = ClipMode == ClipMode.KeepElement ? KeepElementSurfaceRenderer : LayerSurfaceRenderer;
            else if (elements == DrawElements.Wireframe)
                program = ClipMode == ClipMode.KeepElement ? KeepElementWireframeRenderer : LayerWireframeRenderer;


            program.UnsetCustomAttributes("inLeftUp");
            program.UnsetCustomAttributes("inRightDown");

            if (elements == DrawElements.Wireframe)
                program.UnsetCustomAttributes("wire");

            program.Unbind();
        }

        /// <summary>
        /// Освобождает неуправляемые ресурсы
        /// </summary>
        public void Dispose()
        {
            Gl.glDeleteBuffers(1, ref leftUpBuffer);
            Gl.glDeleteBuffers(1, ref rightDownBuffer);

            leftUpBuffer = 0;
            rightDownBuffer = 0;

            KeepElementSurfaceRenderer?.Dispose();
            LayerSurfaceRenderer?.Dispose();
            KeepElementWireframeRenderer?.Dispose();
            LayerWireframeRenderer?.Dispose();
            KeepElementPointsRenderer?.Dispose();
            LayerPointsRenderer?.Dispose();

            KeepElementSurfaceRenderer = null;
            LayerSurfaceRenderer = null;
            KeepElementWireframeRenderer = null;
            LayerWireframeRenderer = null;
            KeepElementPointsRenderer = null;
            LayerPointsRenderer = null;
        }

        private void ApplyMatrixSettings()
        {
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glLoadMatrixf(ClipMatrix);

            Gl.glClipPlane(Gl.GL_CLIP_PLANE0, new double[] { 0, 0, -1, 0 });
            Gl.glEnable(Gl.GL_CLIP_PLANE0);

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, new float[] { 0, 0, -1, 0 });
            Gl.glGetLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, ClipEquat);
            var dot = -(ClipMatrix[12] * ClipEquat[0] + ClipMatrix[13] * ClipEquat[1] + ClipMatrix[14] * ClipEquat[2]);
            ClipEquat[3] = dot;

            Gl.glPopMatrix();
        }

        private void CreateKeepElementSurfaceRenderer()
        {
            //Без прозрачности
            KeepElementSurfaceRenderer = new ShaderProgramCreator();
            ChangeCompilationCondition(1, ShaderCollections.baseFragment, "#define NO_TRANSPARENT\n");

            KeepElementSurfaceRenderer.CreateShaderFromString(Gl.GL_VERTEX_SHADER, ShaderCollections.baseVertex);
            KeepElementSurfaceRenderer.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.keepElementsGeometry);
            KeepElementSurfaceRenderer.CreateShaderFromString(Gl.GL_FRAGMENT_SHADER, ShaderCollections.baseFragment);
            KeepElementSurfaceRenderer.Link();
        }

        private void CreateKeepElementWireframeRenderer()
        {
            KeepElementWireframeRenderer = new ShaderProgramCreator();
            ChangeCompilationCondition(1, ShaderCollections.keepElementsGeometry, "#define WIREFRAME\n");

            KeepElementWireframeRenderer.Vertex = KeepElementSurfaceRenderer.Vertex;
            KeepElementWireframeRenderer.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.keepElementsGeometry);
            KeepElementWireframeRenderer.Fragment = KeepElementSurfaceRenderer.Fragment;
            KeepElementWireframeRenderer.Link();
        }

        private void CreateKeepElementPointsRenderer()
        {
            /*KeepElementPointsRenderer = new ShaderProgramCreator();
            ChangeCompilationCondition(2, ShaderCollections.baseVertex, "#define CLIP_3D_POINTS\n");
            ChangeCompilationCondition(1, ShaderCollections.keepElementsGeometry, "#define POINTS\n");

            KeepElementPointsRenderer.CreateShaderFromString(Gl.GL_VERTEX_SHADER, ShaderCollections.baseVertex);
            KeepElementPointsRenderer.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.keepElementsGeometry);
            KeepElementPointsRenderer.Fragment = KeepElementSurfaceRenderer.Fragment;
            KeepElementPointsRenderer.Link();*/
        }

        private void CreateLayerSurfaceRenderer()
        {
            LayerSurfaceRenderer = new ShaderProgramCreator();
            ChangeCompilationCondition(2, ShaderCollections.keepElementsGeometry, "#define LAYER\n");

            LayerSurfaceRenderer.Vertex = KeepElementSurfaceRenderer.Vertex;
            LayerSurfaceRenderer.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.keepElementsGeometry);
            LayerSurfaceRenderer.Fragment = KeepElementSurfaceRenderer.Fragment;
            LayerSurfaceRenderer.Link();
        }

        private void CreateLayerWireframeRenderer()
        {
            LayerWireframeRenderer = new ShaderProgramCreator();
            ChangeCompilationCondition(1, ShaderCollections.keepElementsGeometry, "#define WIREFRAME\n");

            LayerWireframeRenderer.Vertex = LayerSurfaceRenderer.Vertex;
            LayerWireframeRenderer.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.keepElementsGeometry);
            LayerWireframeRenderer.Fragment = LayerSurfaceRenderer.Fragment;
            LayerWireframeRenderer.Link();
        }

        private void CreateLayerPointsRenderer()
        {
            /*LayerPointsRenderer = new ShaderProgramCreator();
            ChangeCompilationCondition(1, ShaderCollections.keepElementsGeometry, "#define POINTS\n");

            LayerPointsRenderer.Vertex = KeepElementPointsRenderer.Vertex;
            LayerPointsRenderer.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.keepElementsGeometry);
            LayerPointsRenderer.Fragment = LayerSurfaceRenderer.Fragment;
            LayerPointsRenderer.Link();*/
        }

        private void ChangeCompilationCondition(int position, string[] source, string newCondition)
        {
            source[position] = newCondition;
        }

        private bool IsShowInsideEnabled(SurfaceObjects obj)
        {
            var lastElem = obj.SeparatorsLength - 1;
            var lastStride = new int[1];
            VBO.VBO.GetSubData(obj.SeparatorBuffer, lastElem * sizeof(int), sizeof(int), lastStride);
            lastStride[0] *= 9;
            return lastStride[0] == obj.CoordLength;
        }

        /// <summary>
        /// Строит ограничивающие боксы для всех 3д элементов
        /// </summary>
        /// <param name="points">[In]Исходные точки модели</param>
        /// <param name="separators">[In]Разметка элементов модели</param>
        /// <param name="leftUp">[In]Левый верхний угол</param>
        /// <param name="rightDown">[In]Правый нижний угол</param>
        private void BuildBoundingBoxes(float[] points, int[] separators, out float[] leftUp, out float[] rightDown)
        {
            leftUp = new float[points.Length];
            rightDown = new float[points.Length];

            for(var i = 1; i < separators.Length; ++i)
            {
                var minX = float.MaxValue;
                var maxX = float.MinValue;
                var minY = float.MaxValue;
                var maxY = float.MinValue;
                var minZ = float.MaxValue;
                var maxZ = float.MinValue;

                var begin = separators[i - 1];
                var triangles = separators[i] - separators[i - 1];
                for(var j = 0; j < triangles; ++j)
                {
                    var stride = begin * 9 + j * 9;//Смещение до первой координаты треугольника
                    for(var k = 0; k < 9; k += 3)
                    {
                        var pointStride = stride + k;
                        minX = Math.Min(minX, points[pointStride + 0]);
                        maxX = Math.Max(maxX, points[pointStride + 0]);

                        minY = Math.Min(minY, points[pointStride + 1]);
                        maxY = Math.Max(maxY, points[pointStride + 1]);

                        minZ = Math.Min(minZ, points[pointStride + 2]);
                        maxZ = Math.Max(maxZ, points[pointStride + 2]);
                    }
                }
                for (var j = 0; j < triangles; ++j)
                {
                    var stride = begin * 9 + j * 9;//Смещение до первой координаты треугольника
                    for (var k = 0; k < 9; k += 3)
                    {
                        var pointStride = stride + k;
                        leftUp[pointStride + 0] = minX;
                        leftUp[pointStride + 1] = maxY;
                        leftUp[pointStride + 2] = maxZ;

                        rightDown[pointStride + 0] = maxX;
                        rightDown[pointStride + 1] = minY;
                        rightDown[pointStride + 2] = minZ;
                    }
                }
            }
        }
    }
}
