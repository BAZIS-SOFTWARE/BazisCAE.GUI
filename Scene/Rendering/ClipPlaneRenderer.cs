using Scene.VBO;
using Geometry;
using Tao.OpenGl;

namespace Scene
{
    /// <summary>
    /// Класс для визуализации отсекающей плоскости
    /// </summary>
    public class ClipPlaneRenderer
    {
        /// <summary>
        /// BoundingBox
        /// </summary>
        public BoundingBox BoundingBox { get; set; }

        BoundingBoxVBO boundingBoxVBO { get; set; }
        /// <summary>
        /// Возвращает программу для отрисовки
        /// </summary>
        private ShaderProgramCreator Program {  get; set; }
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
        /// Рисует плоскость отсечения, плоскость привязывается к координатам ограничивающего параллелепипеда 
        /// </summary>
        /// <param name="modelMatrix">Матрица модели IVBObject</param>
        /// <param name="normalSize">Размер нормали</param>
        public void Draw(float[] modelMatrix, float normalSize)
        {
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            boundingBoxVBO.Bind();

            Program.Bind();
            Program.SetUniform("modelMatrix", modelMatrix);//Матрица модели IVBObject
            Program.SetUniform("clipPlane", new float[] { 0, 0, -1, 0 });
            Program.SetUniform("normalSize", new float[] { normalSize });

            Gl.glLineWidth(2.5f);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, 18);

            Program.Unbind();

            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
        }
        public void Draw(Point3D leftUp, Point3D rightDown, float normalSize)
        {
            var halfX = (rightDown._x - leftUp._x) / 2;
            var halfY = (leftUp._y - rightDown._y) / 2;
            Gl.glColor3ub(0, 255, 0);
            Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glVertex3f(halfX, halfY, 0);
                Gl.glVertex3f(-halfX, halfY, 0);
                Gl.glVertex3f(-halfX, -halfY, 0);
                Gl.glVertex3f(halfX, -halfY, 0);
                Gl.glVertex3f(halfX, halfY, 0);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3f(halfX, halfY, 0);
                Gl.glVertex3f(halfX, halfY, normalSize);
                Gl.glVertex3f(-halfX, halfY, 0);
                Gl.glVertex3f(-halfX, halfY, normalSize);
                Gl.glVertex3f(-halfX, -halfY, 0);
                Gl.glVertex3f(-halfX, -halfY, normalSize);
                Gl.glVertex3f(halfX, -halfY, 0);
                Gl.glVertex3f(halfX, -halfY, normalSize);
            Gl.glEnd();
        }

        /// <summary>
        /// Динамическое удаление ограничивающего параллелепипеда(например при отжатии флажка CheckBox)
        /// </summary>
        public void DestroyBoundingBoxVBO()
        {
            if (boundingBoxVBO != null)
            {
                boundingBoxVBO.Dispose();
                boundingBoxVBO = null;
            }
        }
        /// <summary>
        /// Очищает все неуправляемые ресурсы
        /// </summary>
        public void Dispose()
        {
            DestroyBoundingBoxVBO();
            Program?.Dispose();
            Program = null;
        }

        internal void CreateBoudingBoxVBO(Point3D leftUpNear, Point3D rightDownFar)
        {
            boundingBoxVBO = new BoundingBoxVBO(leftUpNear, rightDownFar);
        }
    }
}
