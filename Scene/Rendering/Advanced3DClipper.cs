using Scene.VBO;
using System;
using Tao.OpenGl;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scene.Interfaces;
using System.Xml.Linq;
using System.IO;

namespace Scene
{
    /// <summary>
    /// Режим отсечения, устанавливаемый при отрисовке модели
    /// </summary>
    public enum ClipMode
    {
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
        private int leftUpBuffer;//Идентификатор буффера левых верхних углов элементов
        private int rightDownBuffer;//Идентификатор буффера правых нижних углов элементов
        /// <summary>
        /// Программа, для полного отображения 3д элементов в месте сечения и в положительной полуплоскости сечения
        /// </summary>
        public ShaderProgramCreator KeepElementSurfaceRenderer { get; private set; }
        /*/// <summary>
        /// Программа, для полного отображения 3д элементов в месте сечения и в положительной полуплоскости сечения в режиме прозрачности
        /// </summary>
        public ShaderProgramCreator KeepElementSurfaceTransparentRenderer { get; private set; }*/
        /// <summary>
        /// Программа, для полного отображения каркаса в месте сечения и в положительной полуплоскости сечения
        /// </summary>
        public ShaderProgramCreator KeepElementWireframeRenderer { get; private set; }
        /*/// <summary>
        /// Программа, для полного отображения каркаса в месте сечения и в положительной полуплоскости сечения в режиме прозрачности
        /// </summary>
        public ShaderProgramCreator KeepElementWireframeTransparentRenderer { get; private set; }*/
        /// <summary>
        /// Программа, для полного отображения точек в месте сечения и в положительной полуплоскости сечения в режиме прозрачности
        /// </summary>
        public ShaderProgramCreator KeepElementPointsRenderer { get; private set; }
        /*/// <summary>
        /// Программа, для полного отображения точек в месте сечения и в положительной полуплоскости сечения в режиме прозрачности
        /// </summary>
        public ShaderProgramCreator KeepElementPointsTransparentRenderer { get; private set; }*/
        /// <summary>
        /// Программа, для послойного отображения 3д элементов, сохраняет элементы только в месте сечения
        /// </summary>
        public ShaderProgramCreator LayerSurfaceRenderer { get; private set; }
        /*/// <summary>
        /// Программа, для послойного отображения 3д элементов, сохраняет элементы только в месте сечения в режиме прозрачности
        /// </summary>
        public ShaderProgramCreator LayerSurfaceTransparentRenderer { get; private set; }*/
        /// <summary>
        /// Программа, для послойного отображения каркаса, сохраняет элементы только в месте сечения
        /// </summary>
        public ShaderProgramCreator LayerWireframeRenderer { get; private set; }
        /*/// <summary>
        /// Программа, для послойного отображения каркаса, сохраняет элементы только в месте сечения в режиме прозрачности
        /// </summary>
        public ShaderProgramCreator LayerWireframeTransparentRenderer { get; private set; }*/
        /// <summary>
        /// Программа, для послойного отображения точек, сохраняет элементы только в месте сечения
        /// </summary>
        public ShaderProgramCreator LayerPointsRenderer { get; private set; }
        /*/// <summary>
        /// Программа, для послойного отображения точек, сохраняет элементы только в месте сечения в режиме прозрачности
        /// </summary>
        public ShaderProgramCreator LayerPointsTransparentRenderer { get; private set; }*/
        /// <summary>
        /// Режим отсечения
        /// </summary>
        public ClipMode ClipMode { get; set; }
        /// <summary>
        /// Установка матрицы отсечения
        /// </summary>
        public float[] ClipEquat { get; set; } 
        /// <summary>
        /// Объект из 3д элементов для сечений
        /// </summary>
        public VBObject ClipObject { get; set; }
        /// <summary>
        /// Цвет точек
        /// </summary>
        public float[] PointsColor { get; set; }
        /// <summary>
        /// Флаг улучшенного сечения
        /// </summary>
        public bool IsEnable {  get; set; }
        /// <summary>
        /// Установить толщину слоя
        /// </summary>
        public float LayerThickness { get; set; } = 1f;
        /// <summary>
        /// 
        /// </summary>
        public float ScaleFactor { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        public Advanced3DClipper()
        {
            ClipEquat = new float[4];

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

        private void CreateKeepElementSurfaceRenderer()
        {
            //Без прозрачности
            KeepElementSurfaceRenderer = new ShaderProgramCreator();
            ChangeCompilationCondition(1, ShaderCollections.baseFragment, "#define NO_TRANSPARENT\n");

            KeepElementSurfaceRenderer.CreateShaderFromString(Gl.GL_VERTEX_SHADER, ShaderCollections.baseVertex);
            KeepElementSurfaceRenderer.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.keepElementsGeometry);
            KeepElementSurfaceRenderer.CreateShaderFromString(Gl.GL_FRAGMENT_SHADER, ShaderCollections.baseFragment);
            KeepElementSurfaceRenderer.Link();

            //С прозрачностью. Вариант с прозрачностью пока выпилен, есть артефакты в рисовании
            /*
            KeepElementSurfaceTransparentRenderer = new ShaderProgramCreator();
            ChangeCompilationCondition(1, ShaderCollections.baseFragment, "#define TRANSPARENT_WITH_CLIP\n");

            KeepElementSurfaceTransparentRenderer.Vertex = KeepElementSurfaceRenderer.Vertex;
            KeepElementSurfaceTransparentRenderer.Geometry = KeepElementSurfaceRenderer.Geometry;
            KeepElementSurfaceTransparentRenderer.CreateShaderFromString(Gl.GL_FRAGMENT_SHADER, ShaderCollections.baseFragment);
            KeepElementSurfaceTransparentRenderer.Link();
            */
        }

        private void CreateKeepElementWireframeRenderer()
        {
            //Меняется компиляция только в геометрическом шейдере, остальное берется из KeepElementSurfaceRenderer и KeepElementSurfaceTransparentRenderer
            //Без прозрачности
            KeepElementWireframeRenderer = new ShaderProgramCreator();
            ChangeCompilationCondition(1, ShaderCollections.keepElementsGeometry, "#define WIREFRAME\n");

            KeepElementWireframeRenderer.Vertex = KeepElementSurfaceRenderer.Vertex;
            KeepElementWireframeRenderer.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.keepElementsGeometry);
            KeepElementWireframeRenderer.Fragment = KeepElementSurfaceRenderer.Fragment;
            KeepElementWireframeRenderer.Link();

            //С прозрачностью. Вариант с прозрачностью пока выпилен, есть артефакты в рисовании
            /*
            KeepElementWireframeTransparentRenderer = new ShaderProgramCreator();

            KeepElementWireframeTransparentRenderer.Vertex = KeepElementWireframeRenderer.Vertex;
            KeepElementWireframeTransparentRenderer.Geometry = KeepElementWireframeRenderer.Geometry;
            KeepElementWireframeTransparentRenderer.Fragment = KeepElementSurfaceTransparentRenderer.Fragment;
            KeepElementWireframeTransparentRenderer.Link();
            */
        }

        private void CreateKeepElementPointsRenderer()
        {
            //Меняем условие компиляции в вершинном шейдере и геометрическом шейдере фрагментный шейдер берем из KeepElementSurfaceRenderer
            //Без прозрачности
            KeepElementPointsRenderer = new ShaderProgramCreator();
            ChangeCompilationCondition(2, ShaderCollections.baseVertex, "#define CLIP_3D_POINTS\n");
            ChangeCompilationCondition(1, ShaderCollections.keepElementsGeometry, "#define POINTS\n");

            KeepElementPointsRenderer.CreateShaderFromString(Gl.GL_VERTEX_SHADER, ShaderCollections.baseVertex);
            KeepElementPointsRenderer.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.keepElementsGeometry);
            KeepElementPointsRenderer.Fragment = KeepElementSurfaceRenderer.Fragment;
            KeepElementPointsRenderer.Link();
            //С прозрачностью. Вариант с прозрачностью пока выпилен, есть артефакты в рисовании
            /*KeepElementPointsTransparentRenderer = new ShaderProgramCreator();

            KeepElementPointsTransparentRenderer.Vertex = KeepElementPointsRenderer.Vertex;
            KeepElementPointsTransparentRenderer.Geometry = KeepElementPointsRenderer.Geometry;
            KeepElementPointsTransparentRenderer.Fragment = KeepElementSurfaceTransparentRenderer.Fragment;
            KeepElementPointsTransparentRenderer.Link();*/
        }

        private void CreateLayerSurfaceRenderer()
        {
            //Меняем условие компиляции только в геометрическом шейдере фрагментный и вершинный шейдер берем из KeepElementSurfaceRenderer
            //Без прозрачности
            LayerSurfaceRenderer = new ShaderProgramCreator();
            ChangeCompilationCondition(2, ShaderCollections.keepElementsGeometry, "#define LAYER\n");

            LayerSurfaceRenderer.Vertex = KeepElementSurfaceRenderer.Vertex;
            LayerSurfaceRenderer.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.keepElementsGeometry);
            LayerSurfaceRenderer.Fragment = KeepElementSurfaceRenderer.Fragment;
            LayerSurfaceRenderer.Link();
            //С прозрачностью. Вариант с прозрачностью пока выпилен, есть артефакты в рисовании
            /*/LayerSurfaceTransparentRenderer = new ShaderProgramCreator();

            LayerSurfaceTransparentRenderer.Vertex = LayerSurfaceRenderer.Vertex;
            LayerSurfaceTransparentRenderer.Geometry = LayerSurfaceRenderer.Geometry;
            LayerSurfaceTransparentRenderer.Fragment = KeepElementSurfaceTransparentRenderer.Fragment;
            LayerSurfaceTransparentRenderer.Link();*/
        }

        private void CreateLayerWireframeRenderer()
        {
            //Меняем условие компиляции в геометрическом шейдере на WIREFRAME, остальное берем из LayerSurfaceRenderer и LayerSurfaceTransparentRenderer
            //Без прозрачности
            LayerWireframeRenderer = new ShaderProgramCreator();
            ChangeCompilationCondition(1, ShaderCollections.keepElementsGeometry, "#define WIREFRAME\n");

            LayerWireframeRenderer.Vertex = LayerSurfaceRenderer.Vertex;
            LayerWireframeRenderer.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.keepElementsGeometry);
            LayerWireframeRenderer.Fragment = LayerSurfaceRenderer.Fragment;
            LayerWireframeRenderer.Link();
            //С прозрачностью. Вариант с прозрачностью пока выпилен, есть артефакты в рисовании
            /*LayerWireframeTransparentRenderer = new ShaderProgramCreator();

            LayerWireframeTransparentRenderer.Vertex = LayerWireframeRenderer.Vertex;
            LayerWireframeTransparentRenderer.Geometry = LayerWireframeRenderer.Geometry;
            LayerWireframeTransparentRenderer.Fragment = KeepElementSurfaceTransparentRenderer.Fragment;
            LayerWireframeTransparentRenderer.Link();*/
        }

        private void CreateLayerPointsRenderer()
        {
            //Меняем условие компиляции в геометрическом шейдере на POINTS, вершинный шейдер берем из KeepElementsPointsRenderer
            //Без прозрачности
            LayerPointsRenderer = new ShaderProgramCreator();
            ChangeCompilationCondition(1, ShaderCollections.keepElementsGeometry, "#define POINTS\n");

            LayerPointsRenderer.Vertex = KeepElementPointsRenderer.Vertex;
            LayerPointsRenderer.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.keepElementsGeometry);
            LayerPointsRenderer.Fragment = LayerSurfaceRenderer.Fragment;
            LayerPointsRenderer.Link();
            //С прозрачностью, Вариант с прозрачностью пока выпилен, есть артефакты в рисовании
            /*LayerPointsTransparentRenderer = new ShaderProgramCreator();

            LayerPointsTransparentRenderer.Vertex = LayerPointsRenderer.Vertex;
            LayerPointsTransparentRenderer.Geometry = LayerPointsRenderer.Geometry;
            LayerPointsTransparentRenderer.Fragment = KeepElementSurfaceTransparentRenderer.Fragment;
            LayerPointsTransparentRenderer.Link();*/
        }

        /// <summary>
        /// Создать ограничивающие параллелепипеды для 3д элементов, вызывать только для vbo типа 3D SurfaceObjects
        /// </summary>
        /// <param name="vbo">[In]3D SurfaceObjects</param>
        public void Create3DBoundingBoxes(SurfaceObjects vbo)
        {
            if (leftUpBuffer == 0 && rightDownBuffer == 0)
            {
                if (vbo.SeparatorsLength == 0)
                    throw new Exception("Отсутствует разметка, вызовите CreateSeparators");
                ClipObject = vbo;
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
            /*
            if (IsTransparent)
            {
                BeforeDrawingTransparent(vbo, elements);//В режиме прозрачности пока не работает
            }
            else
                BeforeDrawing(vbo, elements);*/
            BeforeDrawing(vbo, elements);
        }

        private void BeforeDrawing(VBObject vbo, DrawElements elements)
        {
            if (ClipMode == ClipMode.Default || elements == DrawElements.Lines)
                return;
            if (ClipObject != null)//Только если был задан 3д объект отсечения
            {
                ShaderProgramCreator program = null;
                if (elements == DrawElements.Points)
                {
                    program = ClipMode == ClipMode.KeepElement ? KeepElementPointsRenderer : LayerPointsRenderer;
                    program.Bind();
                    program.SetUniform("pointsColor", PointsColor);
                    SwapBuffersAndRenderSettings(vbo, ClipObject);
                }
                else if (elements == DrawElements.Surfaces)
                {
                    program = ClipMode == ClipMode.KeepElement ? KeepElementSurfaceRenderer : LayerSurfaceRenderer;
                    program.Bind();
                }
                else if (elements == DrawElements.Wireframe)
                {
                    program = ClipMode == ClipMode.KeepElement ? KeepElementWireframeRenderer : LayerWireframeRenderer;
                    program.Bind();
                    program.SetCustomAttributes(((SurfaceObjects)vbo).EdgeBuffer, "wire", 1, 3, Gl.GL_UNSIGNED_BYTE);
                }
                var lighting = Gl.glIsEnabled(Gl.GL_LIGHTING);
                program.SetUniform("isLighting", new float[] { lighting });
                program.SetUniform("clipEquat", ClipEquat);
                if (ClipMode == ClipMode.Layered)
                {
                    program.SetUniform("layerThickness", new float[] { LayerThickness });
                    program.SetUniform("scaleFactor", new float [] { ScaleFactor });
                }
                program.SetCustomAttributes(leftUpBuffer, "inLeftUp");
                program.SetCustomAttributes(rightDownBuffer, "inRightDown");          
            }
        }
        /*//Работает, но плохо есть артефакты в рисовании, пока выпилил
        private void BeforeDrawingTransparent(VBObject vbo, DrawElements elements)
        {
            var index = (int)elements;
            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, AverageColorRenderer.fbo[index]);
            ShaderProgramCreator program = null;
            if (elements == DrawElements.Points)
            {
                program = ClipMode == ClipMode.KeepElement ? KeepElementPointsTransparentRenderer : LayerPointsTransparentRenderer;
                program.Bind();
                program.SetUniform("pointsColor", PointsColor);
                SwapBuffersAndRenderSettings(vbo, PointTranformObject);
            }
            else if (elements == DrawElements.Surfaces)
            {
                Gl.glUseProgram(0);
                Gl.glColorMask(Gl.GL_FALSE, Gl.GL_FALSE, Gl.GL_FALSE, Gl.GL_FALSE);//Проход только по буферу глубины
                vbo.Draw();
                Gl.glColorMask(Gl.GL_TRUE, Gl.GL_TRUE, Gl.GL_TRUE, Gl.GL_TRUE);


                program = ClipMode == ClipMode.KeepElement ? KeepElementSurfaceTransparentRenderer : LayerSurfaceTransparentRenderer;
                program.Bind();
                Gl.glDrawBuffers(2, new int[] { Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_COLOR_ATTACHMENT1_EXT });
                Gl.glDisable(Gl.GL_DEPTH_TEST);
                Gl.glEnable(Gl.GL_BLEND);
                Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE);
                Gl.glBlendEquation(Gl.GL_FUNC_ADD);
            }
            else if (elements == DrawElements.Wireframe)
            {
                Gl.glDrawBuffer(Gl.GL_COLOR_ATTACHMENT0_EXT);
                if (!AverageColorRenderer.ShowSurfaceBackEdges)
                {
                    Gl.glEnable(Gl.GL_CULL_FACE);
                    Gl.glCullFace(Gl.GL_BACK);
                }

                program = ClipMode == ClipMode.KeepElement ? KeepElementWireframeTransparentRenderer : LayerWireframeTransparentRenderer;
                program.Bind();
            }
            var lighting = Gl.glIsEnabled(Gl.GL_LIGHTING);
            program.SetUniform("isLighting", new float[] { lighting });
            program.SetUniform("clipEquat", ClipEquat);
            program.SetCustomAttributes(leftUpBuffer, "inLeftUp");
            program.SetCustomAttributes(rightDownBuffer, "inRightDown");
        }*/

        /// <summary>
        /// Выполнить действия после вызова glDrawElements
        /// </summary>
        /// <param name="vbo">[In]Вбо-объект, который заканчивает отрисовку</param>
        /// <param name="elements">[In]Элемент отрисовки</param>
        public void DoActionsAfterDrawing(VBObject vbo, DrawElements elements)
        {
            /*if (IsTransparent)
                AfterDrawingTransparent(vbo, elements);//В режиме прозрачности пока не работает
            else
                AfterDrawing(vbo, elements);*/
            AfterDrawing(vbo, elements);
        }

        private void AfterDrawing(VBObject vbo, DrawElements elements)
        {
            if (ClipMode == ClipMode.Default || elements == DrawElements.Lines)
                return;
            if (ClipObject != null)//Только если был задан 3д объект отсечения
            {
                ShaderProgramCreator program = null;
                if (elements == DrawElements.Surfaces)
                    program = ClipMode == ClipMode.KeepElement ? KeepElementSurfaceRenderer : LayerSurfaceRenderer;
                else if (elements == DrawElements.Wireframe)
                    program = ClipMode == ClipMode.KeepElement ? KeepElementWireframeRenderer : LayerWireframeRenderer;
                else if (elements == DrawElements.Points)
                {
                    program = ClipMode == ClipMode.KeepElement ? KeepElementPointsRenderer : LayerPointsRenderer;
                    SwapBuffersAndRenderSettings(vbo, ClipObject);
                }
                program.UnsetCustomAttributes("inLeftUp");
                program.UnsetCustomAttributes("inRightDown");
                if (elements == DrawElements.Wireframe)
                    program.UnsetCustomAttributes("wire", 3);
                program.Unbind();
            }
        }
        /*//Работает, но плохо есть артефакты в рисовании, пока выпилил
        private void AfterDrawingTransparent(VBObject vbo, DrawElements elements)
        {
            ShaderProgramCreator program = null;
            if (elements == DrawElements.Points)
            {
                program = ClipMode == ClipMode.KeepElement ? KeepElementPointsTransparentRenderer : LayerPointsTransparentRenderer;
                SwapBuffersAndRenderSettings(vbo, PointTranformObject);
            }
            else if (elements == DrawElements.Surfaces)
            {
                program = ClipMode == ClipMode.KeepElement ? KeepElementSurfaceTransparentRenderer : LayerSurfaceTransparentRenderer;
                Gl.glEnable(Gl.GL_DEPTH_TEST);
                Gl.glDisable(Gl.GL_BLEND);
            }
            else if (elements == DrawElements.Wireframe)
            {
                program = ClipMode == ClipMode.KeepElement ? KeepElementWireframeTransparentRenderer : LayerWireframeTransparentRenderer;
                if (!AverageColorRenderer.ShowSurfaceBackEdges)
                    Gl.glDisable(Gl.GL_CULL_FACE);
            }
            program.UnsetCustomAttributes("inLeftUp");
            program.UnsetCustomAttributes("inRightDown");
            program.Unbind();
            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, 0);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);//Необходимо вызывать чтобы избежать артефакты при рендеринге
        }*/

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
            //KeepElementSurfaceTransparentRenderer.Dispose();

            LayerSurfaceRenderer?.Dispose();
            //LayerSurfaceTransparentRenderer.Dispose();

            KeepElementWireframeRenderer?.Dispose();
            //KeepElementWireframeTransparentRenderer.Dispose();

            LayerWireframeRenderer?.Dispose();
            //LayerWireframeTransparentRenderer.Dispose();

            KeepElementPointsRenderer?.Dispose();
            //KeepElementPointsTransparentRenderer.Dispose();

            LayerPointsRenderer?.Dispose();
            //LayerPointsTransparentRenderer.Dispose();

            KeepElementSurfaceRenderer = null;
            //KeepElementSurfaceTransparentRenderer = null;

            LayerSurfaceRenderer = null;
            //LayerSurfaceTransparentRenderer = null;

            KeepElementWireframeRenderer = null;
            //KeepElementWireframeTransparentRenderer = null;

            LayerWireframeRenderer = null;
            //LayerWireframeTransparentRenderer = null;

            KeepElementPointsRenderer = null;
            //KeepElementPointsTransparentRenderer = null;

            LayerPointsRenderer = null;
            //LayerPointsTransparentRenderer = null;
        }
        
        private void ChangeCompilationCondition(int position, string[] source, string newCondition)
        {
            source[position] = newCondition;
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
        
        private void SwapBuffersAndRenderSettings(VBObject pointVbo, VBObject surfVbo)
        {
            SwapBuffers(pointVbo, surfVbo);
            SwapSettings(pointVbo, surfVbo);
        }

        private void SwapBuffers(VBObject pointVbo, VBObject surfVbo)
        {
            var temp = pointVbo.PointersBuffer;
            pointVbo.PointersBuffer = surfVbo.PointersBuffer;
            surfVbo.PointersBuffer = temp;

            temp = pointVbo.CoordsBuffer;
            pointVbo.CoordsBuffer = surfVbo.CoordsBuffer;
            surfVbo.CoordsBuffer = temp;

            temp = pointVbo.ColorsBuffer;
            pointVbo.ColorsBuffer = surfVbo.ColorsBuffer;
            surfVbo.ColorsBuffer = temp;

            temp = pointVbo.NormalsBuffer;
            pointVbo.NormalsBuffer = surfVbo.NormalsBuffer;
            surfVbo.NormalsBuffer = temp;
        }

        private void SwapSettings(VBObject pointVbo, VBObject surfVbo)
        {
            var temp = pointVbo.PtrLength;
            pointVbo.PtrLength = surfVbo.PtrLength;
            surfVbo.PtrLength = temp;

            temp = pointVbo.Gl_DisplayMode;
            pointVbo.Gl_DisplayMode = surfVbo.Gl_DisplayMode;
            surfVbo.Gl_DisplayMode = temp;

            var glType = pointVbo.GL_ObjType;
            pointVbo.GL_ObjType = surfVbo.GL_ObjType;
            surfVbo.GL_ObjType = glType;
        }
    }
}
