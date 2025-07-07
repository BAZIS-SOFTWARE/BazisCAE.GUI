using BazisGUI.Scene.Interfaces;
using Tao.OpenGl;

namespace BazisGUI.Scene.VBO
{
    /// <summary>
    /// PointObjects
    /// </summary>
    public class PointObjects : VBObject
    {
        /// <summary>
        /// PointObjects
        /// </summary>
        /// <param name="ptrs"></param>
        /// <param name="glCoords"></param>
        /// <param name="glColors"></param>
        /// <param name="glNormals"></param>
        /// <param name="objName"></param>
        public PointObjects(string objName,int[] ptrs, float[] glCoords, float[] glColors, float[] glNormals) : 
            base(objName,ptrs, glCoords, glColors, glNormals)
        {
            ViewMode = ObjView.Points;
            GL_ObjType = GLObjType.point;
            Gl_PointSize = 8.0f;
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

        /// <inheritdoc/>

        public override void Load()
        {
            if (ViewState)
            {
                //AverageColorRenderer.SetRenderSettings(0);
                ActiveDrawingObject?.DoActionsBeforeDrawing(this, DrawElements.Points);
                Draw();
                ActiveDrawingObject?.DoActionsAfterDrawing(this, DrawElements.Points);
            }
        }
    }
}
