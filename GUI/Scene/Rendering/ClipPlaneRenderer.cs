
using BazisGUI.Scene.VBO;
using Geometry;
using System;
using Tao.OpenGl;

namespace BazisGUI.Scene
{
    /// <summary>
    /// Класс для визуализации отсекающей плоскости
    /// </summary>
    internal class ClipPlaneRenderer
    {
        /// <summary>
        /// Возвращает программу для отрисовки
        /// </summary>
        internal ShaderProgramCreator Program { get; set; }
        /// <summary>
        /// Конструктор класса-визуализатора отсекающей плоскости
        /// </summary>
        public ClipPlaneRenderer()
        {
            Program = new ShaderProgramCreator();
            Program.CreateShaderFromString(Gl.GL_VERTEX_SHADER, ShaderCollections.clipPlaneVertex);
            Program.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.clipPlaneGeometry);
            Program.CreateShaderFromString(Gl.GL_FRAGMENT_SHADER, ShaderCollections.clipPlaneFragment);
            Program.Link();
        }
        /// <summary>
        /// Очищает все неуправляемые ресурсы
        /// </summary>
        public void Dispose() => Program.Dispose();
    }
}
