using System;
using System.Drawing;
using Tao.OpenGl;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;


namespace BazisGUI.Scene
{
    /// <summary>
    /// Класс для корректной визуализации прозрачных и непрозрачных объектов на сцене
    /// </summary>
    public class AverageColorRenderer : IDisposable, IActiveDrawingObject
    {
        int nodesDepthTex = 0;//Буфер глубины для узлов
        int nodesColorTex = 0;//Текстура цвета для узлов
        int linesDepthTex = 0;//Буфер глубины для 1D-элементов
        int linesColorTex = 0;//Текстура цвета для линий
        int frameDepthTex = 0;//Буфер глубины для ребер
        int frameColorTex = 0;//Текстура цвета для ребер
        int opaqueDepthTex = 0;//Буфер глубины непрозрачных объектов
        int opaqueColorTex = 0;//Текстура цвета непрозрачных объектов
        int transpDepthTex = 0;//Общий буфер глубины для объектов типа Surface и LineSurface
        int transpColorTex = 0;//Текстура цвета для объектов типа Surface и LineSurface
        int transpCountTex = 0;//Текстура количества фрагменетов накопленных при смешивании

        int quadDisplayList = 0;//Список отображения для рендера на плоскость
        public uint[] fbo { get; private set; } = new uint[5];//0 - узлы, 1 - линии, 2 - ребра поверхностей, 3 - непрозрач. поверхности и текст,
                                                                     //4 - прозрач. поверхности

        int surfacePassCount = 0;
        ///
        public ShaderProgramCreator SurfaceShader { get; private set; }//Программа смешивания объектов типа Surface и LineSurface
        ///
        public ShaderProgramCreator BlendShader { get; private set; }//Программа финального смешивания основных и вспомогательных объектов
        /// <summary>
        /// Включить расчет освещения
        /// </summary>
        public bool IsLighting { get; set; }
        /// <summary>
        /// Игнорировать задние ребра сурфейсов
        /// </summary>
        public bool ShowSurfaceBackEdges { get; set; }
        /// <summary>
        /// Установка заднего цвета - используется при смешивании цветов
        /// </summary>
        public Color BackgroundColor { get; set; }
        /// <summary>
        /// Включение\выключения усредненного рендера
        /// </summary>
        public bool IsEnable { get; set; }
        ///
        public AverageColorRenderer(int width, int height)
        {
            SurfaceShader = new ShaderProgramCreator();

            var bV_1 = ShaderCollections.baseVertex[1];
            ChangeCompilationCondition(1, ShaderCollections.baseVertex, "#define TRANSPARENT\n");

            SurfaceShader.CreateShaderFromString(Gl.GL_VERTEX_SHADER, ShaderCollections.baseVertex);
            SurfaceShader.CreateShaderFromString(Gl.GL_FRAGMENT_SHADER, ShaderCollections.baseFragment);
            SurfaceShader.Link();

            ChangeCompilationCondition(1, ShaderCollections.baseVertex, bV_1);

            BlendShader = new ShaderProgramCreator();
            BlendShader.CreateShaderFromString(Gl.GL_VERTEX_SHADER, ShaderCollections.averageColorFinalBlendVertex);
            BlendShader.CreateShaderFromString(Gl.GL_FRAGMENT_SHADER, ShaderCollections.averageColorFinalBlendFragment);
            BlendShader.Link();

            InitBuffers(width, height);
            MakeFullScreenQuad();
            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, 0);
        }


        /// <summary>
        /// Выполнить действия перед вызовом glDrawElements
        /// </summary>
        /// <param name="vbo">[In]Вбо-объект, который вызывает отрисовку</param>
        /// <param name="elements">[In]Элемент отрисовки</param>
        public void DoActionsBeforeDrawing(VBObject vbo, DrawElements elements)
        {
            var index = (int)elements;
            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, fbo[index]);
            if (elements == DrawElements.Surfaces)
            {
                Gl.glDrawBuffer(Gl.GL_BACK);
                Gl.glColorMask(Gl.GL_FALSE, Gl.GL_FALSE, Gl.GL_FALSE, Gl.GL_FALSE);//Проход только по буферу глубины
                vbo.Draw();
                Gl.glColorMask(Gl.GL_TRUE, Gl.GL_TRUE, Gl.GL_TRUE, Gl.GL_TRUE);

                Gl.glDrawBuffers(2, new int[] { Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_COLOR_ATTACHMENT1_EXT });
                Gl.glDisable(Gl.GL_DEPTH_TEST);
                Gl.glEnable(Gl.GL_BLEND);
                Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE);
                Gl.glBlendEquation(Gl.GL_FUNC_ADD);
                SurfaceShader.Bind();
                SurfaceShader.SetUniform("isLighting", new float[] { Convert.ToInt32(IsLighting) });
            }
            else if (elements == DrawElements.Wireframe)
            {
                Gl.glDrawBuffer(Gl.GL_COLOR_ATTACHMENT0_EXT);
                if (!ShowSurfaceBackEdges)
                {
                    Gl.glEnable(Gl.GL_CULL_FACE);
                    Gl.glCullFace(Gl.GL_BACK);
                }
            }
        }
        /// <summary>
        /// Выполнить действия после вызова glDrawElements
        /// </summary>
        /// <param name="vbo">[In]Вбо-объект, который заканчивает отрисовку</param>
        /// <param name="elements">[In]Элемент отрисовки</param>
        public void DoActionsAfterDrawing(VBObject vbo, DrawElements elements)
        {
            if (elements == DrawElements.Surfaces)
            {
                Gl.glEnable(Gl.GL_DEPTH_TEST);
                Gl.glDisable(Gl.GL_BLEND);
            }
            else if (elements == DrawElements.Wireframe)
            {
                if (!ShowSurfaceBackEdges)
                    Gl.glDisable(Gl.GL_CULL_FACE);
            }
            SurfaceShader.Unbind();
            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, 0);
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);//Необходимо вызывать чтобы избежать артефакты при рендеринге
        }
        /// <summary>
        /// Смешивает прозрачные и непрозрачные объекты отображая их на плоскость
        /// </summary>
        public void BlendFramebuffers()
        {
            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, 0);
            Gl.glDrawBuffer(Gl.GL_BACK);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glDisable(Gl.GL_BLEND);

            BlendShader.Bind();
            var back = new float[] { BackgroundColor.R / 255f, BackgroundColor.G / 255f, BackgroundColor.B / 255f };
            BlendShader.SetUniform("backColor", back);
            BlendShader.BindTextureRect("nodesDepth", nodesDepthTex, 0);
            BlendShader.BindTextureRect("nodesColor", nodesColorTex, 1);
            BlendShader.BindTextureRect("linesDepth", linesDepthTex, 2);
            BlendShader.BindTextureRect("linesColor", linesColorTex, 3);
            BlendShader.BindTextureRect("frameDepth", frameDepthTex, 4);
            BlendShader.BindTextureRect("frameColor", frameColorTex, 5);
            BlendShader.BindTextureRect("opaqueDepth", opaqueDepthTex, 6);
            BlendShader.BindTextureRect("opaqueColor", opaqueColorTex, 7);
            BlendShader.BindTextureRect("transpDepth", transpDepthTex, 8);
            BlendShader.BindTextureRect("transpColor", transpColorTex, 9);
            BlendShader.BindTextureRect("transpCount", transpCountTex, 10);
            Gl.glDepthMask(Gl.GL_FALSE);
            Gl.glCallList(quadDisplayList);
            Gl.glDepthMask(Gl.GL_TRUE);
            BlendShader.Unbind();
        }
        /// <summary>
        /// Очистка всех подключенных буфферов
        /// </summary>
        public void ClearColors()
        {
            for (var i = 0; i < 4; ++i)
            {
                Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, fbo[i]);
                Gl.glDrawBuffer(Gl.GL_COLOR_ATTACHMENT0_EXT);
                Gl.glClearDepth(1);
                Gl.glClearColor(0, 0, 0, 0);
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            }
            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, fbo[4]);
            Gl.glDrawBuffers(2, new int[] { Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_COLOR_ATTACHMENT1_EXT });
            Gl.glClearColor(0, 0, 0, 0);
            Gl.glClearDepth(1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, 0);
        }
        /// <summary>
        /// Изменяет размеры текстур при изменении окна
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Reshape(int width, int height)
        {
            DeleteBuffersAndTextures();
            InitBuffers(width, height);
            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, 0);
        }
        /// <summary>
        /// Освобождает все привязанные объекты OpenGL
        /// </summary>
        public void Dispose()
        {
            SurfaceShader.Dispose();
            BlendShader.Dispose();
            DeleteBuffersAndTextures();
            Gl.glDeleteLists(quadDisplayList, 15);
        }
        /// <summary>
        /// Задает плоскость, на которую будет отображаться результат смешивания 
        /// </summary>
        private void MakeFullScreenQuad()
        {
            quadDisplayList = Gl.glGenLists(15);
            Gl.glNewList(quadDisplayList, Gl.GL_COMPILE);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glOrtho(0.0, 1.0, 0.0, 1.0f, -1.0, 1.0f);
            Gl.glBegin(Gl.GL_QUADS);
            {
                Gl.glVertex2f(0.0f, 0.0f);
                Gl.glVertex2f(1.0f, 0.0f);
                Gl.glVertex2f(1.0f, 1.0f);
                Gl.glVertex2f(0.0f, 1.0f);
            }
            Gl.glEnd();
            Gl.glPopMatrix();
            Gl.glEndList();
        }
        /// <summary>
        /// Инициализация текстур с настройкой параметров
        /// </summary>
        /// <param name="texture">[In]Индеск текстуры</param>
        /// <param name="width">[In]Ширина текстуры</param>
        /// <param name="height">[In]Высота текстуры</param>
        /// <param name="intFormat">[In]Внутренний формат текстуры</param>
        /// <param name="format">[In]Формат пикселей в памяти</param>
        private void SetTexture(ref int texture, int width, int height, int intFormat, int format)
        {
            Gl.glBindTexture(Gl.GL_TEXTURE_RECTANGLE_ARB, texture);
            Gl.glTexParameterf(Gl.GL_TEXTURE_RECTANGLE_ARB, Gl.GL_TEXTURE_WRAP_S, Gl.GL_CLAMP);
            Gl.glTexParameterf(Gl.GL_TEXTURE_RECTANGLE_ARB, Gl.GL_TEXTURE_WRAP_T, Gl.GL_CLAMP);
            Gl.glTexParameterf(Gl.GL_TEXTURE_RECTANGLE_ARB, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
            Gl.glTexParameterf(Gl.GL_TEXTURE_RECTANGLE_ARB, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
            Gl.glTexImage2D(Gl.GL_TEXTURE_RECTANGLE_ARB, 0, intFormat,
                            width, height, 0, format, Gl.GL_FLOAT, IntPtr.Zero);
        }
        /// <summary>
        /// Инициализация фреймбуфферов, текстур
        /// </summary>
        private void InitBuffers(int width, int height)
        {
            Gle.glGenFramebuffers(5, fbo);

            Gl.glGenTextures(1, out nodesDepthTex);//Буфер глубины для узлов
            Gl.glGenTextures(1, out nodesColorTex);//Текстура цвета для узлов

            Gl.glGenTextures(1, out linesDepthTex);//Буфер глубины для 1D-элементов
            Gl.glGenTextures(1, out linesColorTex);//Текстура цвета 1D-элементов

            Gl.glGenTextures(1, out frameDepthTex);//Буфер глубины для ребер
            Gl.glGenTextures(1, out frameColorTex);//Текстура цвета для ребер

            Gl.glGenTextures(1, out opaqueDepthTex);//Общий буфер глубины для вспомогательных объектов
            Gl.glGenTextures(1, out opaqueColorTex);//Общий буфер глубины для вспомогательных объектов

            Gl.glGenTextures(1, out transpDepthTex);//Общий буфер глубины для объектов типа Surface и LineSurface
            Gl.glGenTextures(1, out transpColorTex);//Текстура цвета для объектов типа Surface и LineSurface
            Gl.glGenTextures(1, out transpCountTex);//Текстура количества фрагменетов накопленных при смешивании

            SetTexture(ref nodesDepthTex, width, height, Gl.GL_DEPTH_COMPONENT16, Gl.GL_DEPTH_COMPONENT);
            SetTexture(ref nodesColorTex, width, height, Gl.GL_RGBA32F_ARB, Gl.GL_RGBA);

            SetTexture(ref linesDepthTex, width, height, Gl.GL_DEPTH_COMPONENT16, Gl.GL_DEPTH_COMPONENT);
            SetTexture(ref linesColorTex, width, height, Gl.GL_RGBA32F_ARB, Gl.GL_RGBA);

            SetTexture(ref frameDepthTex, width, height, Gl.GL_DEPTH_COMPONENT16, Gl.GL_DEPTH_COMPONENT);
            SetTexture(ref frameColorTex, width, height, Gl.GL_RGBA32F_ARB, Gl.GL_RGBA);

            SetTexture(ref opaqueDepthTex, width, height, Gl.GL_DEPTH_COMPONENT16, Gl.GL_DEPTH_COMPONENT);
            SetTexture(ref opaqueColorTex, width, height, Gl.GL_RGBA32F_ARB, Gl.GL_RGBA);

            SetTexture(ref transpDepthTex, width, height, Gl.GL_DEPTH_COMPONENT16, Gl.GL_DEPTH_COMPONENT);
            SetTexture(ref transpColorTex, width, height, Gl.GL_RGBA32F_ARB, Gl.GL_RGBA);
            SetTexture(ref transpCountTex, width, height, Gle.GL_R32F, Gl.GL_RED);

            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, fbo[0]);
            Gle.glFramebufferTexture2D(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_DEPTH_ATTACHMENT_EXT, Gl.GL_TEXTURE_RECTANGLE_ARB, (uint)nodesDepthTex, 0);
            Gle.glFramebufferTexture2D(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_TEXTURE_RECTANGLE_ARB, (uint)nodesColorTex, 0);

            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, fbo[1]);
            Gle.glFramebufferTexture2D(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_DEPTH_ATTACHMENT_EXT, Gl.GL_TEXTURE_RECTANGLE_ARB, (uint)linesDepthTex, 0);
            Gle.glFramebufferTexture2D(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_TEXTURE_RECTANGLE_ARB, (uint)linesColorTex, 0);

            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, fbo[2]);
            Gle.glFramebufferTexture2D(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_DEPTH_ATTACHMENT_EXT, Gl.GL_TEXTURE_RECTANGLE_ARB, (uint)frameDepthTex, 0);
            Gle.glFramebufferTexture2D(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_TEXTURE_RECTANGLE_ARB, (uint)frameColorTex, 0);

            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, fbo[3]);
            Gle.glFramebufferTexture2D(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_DEPTH_ATTACHMENT_EXT, Gl.GL_TEXTURE_RECTANGLE_ARB, (uint)opaqueDepthTex, 0);
            Gle.glFramebufferTexture2D(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_TEXTURE_RECTANGLE_ARB, (uint)opaqueColorTex, 0);

            Gle.glBindFramebuffer(Gl.GL_FRAMEBUFFER_EXT, fbo[4]);
            Gle.glFramebufferTexture2D(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_DEPTH_ATTACHMENT_EXT, Gl.GL_TEXTURE_RECTANGLE_ARB, (uint)transpDepthTex, 0);
            Gle.glFramebufferTexture2D(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_TEXTURE_RECTANGLE_ARB, (uint)transpColorTex, 0);
            Gle.glFramebufferTexture2D(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT1_EXT, Gl.GL_TEXTURE_RECTANGLE_ARB, (uint)transpCountTex, 0);
        }
        /*
        /// <summary>
        /// Прикрепляет вершинный и фрагментный шейдер к указанной программе
        /// </summary>
        /// <param name="program">[In]Программа</param>
        /// <param name="vertexCode">[In]Массив строк кода вершинного шейдера</param>
        /// <param name="fragmentCode">[In]Массив строк кода фрагментного шейдера</param>
        private void AttachShadersToProgram(ShaderProgramCreator program, string[] vertexCode, string[] fragmentCode)
        {
            program.CreateShaderFromString(Gl.GL_VERTEX_SHADER, vertexCode);
            program.CreateShaderFromString(Gl.GL_FRAGMENT_SHADER, fragmentCode);
            program.Link();
        }*/
        /// <summary>
        /// Удаляет существующие фреймбуфферы и текстуры
        /// </summary>
        private void DeleteBuffersAndTextures()
        {
            Gle.glDeleteFramebuffers(5, fbo);
            Gl.glDeleteTextures(11, new int[] { nodesDepthTex, nodesColorTex, linesDepthTex, linesColorTex,
                                               frameDepthTex, frameColorTex, opaqueDepthTex, opaqueColorTex,
                                               transpDepthTex, transpColorTex, transpCountTex});
        }

        private void ChangeCompilationCondition(int position, string[] source, string newCondition)
        {
            source[position] = newCondition;
        }
    }
}
