using BazisGUI.Scene.Interfaces;
using Tao.OpenGl;

namespace BazisGUI.Scene.VBO
{
    /// <summary>
    /// LineObjects
    /// </summary>
    public class LineObjects : VBObject
    {
        /// <summary>
        /// SurfaceObjects
        /// </summary>
        /// <param name="edges"></param>
        /// ribbers for couple of points
        /// <param name="ptrs"></param>
        /// pointers for every point of triangle
        /// <param name="glCoords"></param>
        /// coordinates for every point of triangle
        /// <param name="glColors"></param>
        /// colors for every point of triangle
        /// <param name="glNormals"></param>
        /// normals for every points of trialnge
        /// <param name="objName"></param>
        /// type of objects
        public LineObjects(bool[]edges,int[] ptrs, float[] glCoords, float[] glColors, float[] glNormals, string objName) : 
            base(ptrs, glCoords, glColors, glNormals, objName)
        {
            GL_ObjType = GLObjType.line;
            Gl_DisplayMode = 6913;
            Gl_LineWidth = 5.0f;
        }
/// <inheritdoc/>

        public override void Load()
        {
            if (ViewState)
            {
                //AverageColorRenderer.SetRenderSettings(1);
                ActiveDrawingObject?.DoActionsBeforeDrawing(this, DrawElements.Lines);
                Draw();
                ActiveDrawingObject?.DoActionsAfterDrawing(this, DrawElements.Lines);
                //AverageColorRenderer.RestoreRenderSettings(1);
            }
        }
/// <inheritdoc/>

        public override void Draw()
        {
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);//По советам ЛГБТшников перенес сюда
            Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);
            VBO.LoadVertexBuffers(this);
            VBO.Draw(this, PtrLength);
            VBO.UnLoadAllBuffers();
            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);
        }
    }
}
