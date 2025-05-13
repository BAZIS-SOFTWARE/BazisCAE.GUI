using Scene.Interfaces;
using System.Windows.Forms.VisualStyles;
using Tao.OpenGl;

namespace Scene.VBO
{
    /// <summary>
    /// SurfaceObjects class
    /// </summary>
    public class SurfaceObjects : VBObject
    {
        /// <inheritdoc/>
        public int FrameBuffer { get; private set; } = 0;//Нужно свойство для изменения прозрачности ребер
        /// <inheritdoc/>
        public int EdgeBuffer { get; private set; } = 0;
        /// <inheritdoc/>
        public int SeparatorBuffer { get; private set; } = 0;

        /// <inheritdoc/>
        public float[] FrameColors
        {
            get
            {
                var colors = new float[FrameLength];
                VBO.GetSubData(FrameBuffer, 0, colors.Length * sizeof(float), colors);
                return colors;

            }
            set
            {
                VBO.SetSubData(FrameBuffer, 0, value.Length * sizeof(float), value);
            }
        }

        /// <inheritdoc/>
        public bool[] EdgeFlags
        {
            get
            {
                var edges = new bool[EdgesLength];
                VBO.GetSubData(EdgeBuffer, 0, edges.Length * sizeof(bool), edges);
                return edges;
            }
            set
            {
                VBO.SetSubData(EdgeBuffer, 0, value.Length * sizeof(bool), value);
            }
        }
        /// <inheritdoc/>
        public int[] Separators
        {
            get
            {
                var separators = new int[SeparatorsLength];
                VBO.GetSubData(SeparatorBuffer, 0, separators.Length * sizeof(int), separators);
                return separators;

            }
            set
            {
                VBO.SetSubData(SeparatorBuffer, 0, value.Length * sizeof(int), value);
            }
        }


        /// <summary>
        /// SurfaceObjects
        /// </summary>
        /// <param name="edges"></param>
        /// ribbers for couple of points
        /// strides for points
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

        public SurfaceObjects(bool[] edges, int[] ptrs, float[] glCoords, float[] glColors, float[] glNormals, string objName) : 
            base(ptrs, glCoords, glColors, glNormals, objName)
        {
            var edgeBuff = 0;

            VBO.VertexDataInit(ref edgeBuff, edges,sizeof(bool));
            EdgesLength = edges.Length;
            EdgeBuffer = edgeBuff;

            ViewMode = ObjView.LinesSurface;
            GL_ObjType = GLObjType.triangle;
            Gl_LineWidth = 2.0f;
            //Gl_Face = 1028;
            var frameColors = new float[glColors.Length];

            var length = frameColors.Length / 4;
            for (int i = 3; i < frameColors.Length; i+= 4)
                frameColors[i] = 1;

            var frameBuff = 0;
            VBO.VertexDataInit(ref frameBuff, frameColors, sizeof(float));
            FrameBuffer = frameBuff;
            FrameLength = frameColors.Length;
        }
        /// <inheritdoc/>
        public void CreateSeparators(int[] separators)
        {
            var sepBuffer = 0;
            VBO.VertexDataInit(ref sepBuffer, separators, sizeof(int));
            SeparatorsLength = separators.Length;
            SeparatorBuffer = sepBuffer;
        }

        /// <inheritdoc/>

        public override void Load()
        {
            if (ViewState)
            {
                if (ViewMode == ObjView.Lines)
                {
                    Gl_DisplayMode = 6913;
                    //AverageColorRenderer.SetRenderSettings(2);
                    ActiveDrawingObject?.DoActionsBeforeDrawing(this, DrawElements.Wireframe);
                    Draw();
                    ActiveDrawingObject?.DoActionsAfterDrawing(this, DrawElements.Wireframe);
                    //AverageColorRenderer.RestoreRenderSettings(2);
                }
                else if (ViewMode == ObjView.Surface)
                {
                    Gl_DisplayMode = 6914;
                    //AverageColorRenderer.SetSurfaceRenderSettings(Draw);
                    ActiveDrawingObject?.DoActionsBeforeDrawing(this, DrawElements.Surfaces);
                    Draw();
                    ActiveDrawingObject?.DoActionsAfterDrawing(this, DrawElements.Surfaces);
                }
                else
                {
                    Gl_DisplayMode = 6914;
                    //AverageColorRenderer.SetSurfaceRenderSettings(Draw);
                    ActiveDrawingObject?.DoActionsBeforeDrawing(this, DrawElements.Surfaces);
                    Draw();
                    ActiveDrawingObject?.DoActionsAfterDrawing(this, DrawElements.Surfaces);
                    //AverageColorRenderer.SetRenderSettings(2);
                    var temp = ColorsBuffer;
                    ColorsBuffer = FrameBuffer;
                    Gl_DisplayMode = 6913;
                    Gl.glDepthFunc(Gl.GL_LEQUAL);
                    ActiveDrawingObject?.DoActionsBeforeDrawing(this, DrawElements.Wireframe);
                    Draw();
                    ActiveDrawingObject?.DoActionsAfterDrawing(this, DrawElements.Wireframe);
                    Gl.glDepthFunc(Gl.GL_LESS);
                    ColorsBuffer = temp;
                    //AverageColorRenderer.RestoreRenderSettings(2);
                }
            }      
        }
/// <inheritdoc/>

        public override void Draw()
        {
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);//По советам ЛГБТшников перенес сюда
            Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);
            Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);
            Gl.glEnableClientState(Gl.GL_EDGE_FLAG_ARRAY);
            VBO.LoadVertexBuffers(this);
            VBO.LoadNormalBuffer(this);
            VBO.LoadEdgeBuffer(EdgeBuffer);
            VBO.Draw(this, PtrLength);
            VBO.UnLoadAllBuffers();
            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);
            Gl.glDisableClientState(Gl.GL_NORMAL_ARRAY);
            Gl.glDisableClientState(Gl.GL_EDGE_FLAG_ARRAY);
        }
    }
}
