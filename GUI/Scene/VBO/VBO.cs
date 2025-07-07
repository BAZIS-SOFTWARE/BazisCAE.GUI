
using BazisGUI.Scene.Interfaces;
using System;
using Tao.OpenGl;

namespace BazisGUI.Scene.VBO
{
    /// <summary>
    /// VBO methods
    /// </summary>
    public static class VBO
    {
        /// <summary>
        /// DeleteAllBuffers
        /// </summary>
        /// <param name="obj"></param>
        public static void DeleteAllBuffers(VBObject obj)
        {
            var buffers = new int[] { obj.PointersBuffer, obj.CoordsBuffer, obj.ColorsBuffer, obj.NormalsBuffer };
            Gl.glDeleteBuffers(buffers.Length, buffers);

            if (obj.GL_ObjType == GLObjType.triangle)
            {
                var sObj = obj as SurfaceObjects;
                buffers = new int[] { sObj.FrameBuffer, sObj.EdgeBuffer, sObj.SeparatorBuffer };
                Gl.glDeleteBuffers(buffers.Length, buffers);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public static void LoadVertexBuffers(VBObject obj)
        {

            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, obj.PointersBuffer);

            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, obj.CoordsBuffer);
            //IntObjPtr ObjPtr = new IntObjPtr(obj.GlCoord.Length);
            //Gl.glBufferSubData(Gl.GL_ARRAY_BUFFER, IntObjPtr.Zero, ObjPtr, obj.GlCoord);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, IntPtr.Zero);

            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, obj.ColorsBuffer);
            //ObjPtr = new IntObjPtr(obj.GlColor.Length);
            //Gl.glBufferSubData(Gl.GL_ARRAY_BUFFER, IntObjPtr.Zero, ObjPtr, obj.GlColor);
            Gl.glColorPointer(4, Gl.GL_FLOAT, 0, IntPtr.Zero);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public static void LoadNormalBuffer(VBObject obj)
        {
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, obj.NormalsBuffer);
            Gl.glNormalPointer(Gl.GL_FLOAT, 0, IntPtr.Zero);
        }

        /// <summary>
        /// LoadEdgeBuffer
        /// </summary>
        public static void LoadEdgeBuffer(int buffer)
        {
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, buffer);
            Gl.glEdgeFlagPointer(0, IntPtr.Zero);
        }
        /// <summary>
        /// Draw objects. indexLength - начало диапазона, IntPtr.Zero - конц диапазона
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="indexLength"></param>
        public static void Draw(VBObject obj, int indexLength)
        {

            Gl.glPointSize(obj.Gl_PointSize);
            Gl.glLineWidth(obj.Gl_LineWidth);

            Gl.glPolygonMode(obj.Gl_Face, obj.Gl_DisplayMode);

            //Gl.glEnable(Gl.GL_BLEND);
            //Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            //
            Gl.glDrawElements((int)obj.GL_ObjType, indexLength, Gl.GL_UNSIGNED_INT, IntPtr.Zero);

            //Gl.glDisable(Gl.GL_BLEND);
        }
        /// <summary>
        /// UnLoadAllBuffers
        /// </summary>
        public static void UnLoadAllBuffers()
        {
            //Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);
            //Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);
            //Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);
            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, 0);
        }
        /// <summary>
        /// IndexInit
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="indices"></param>
        public static void IndexDataInit(ref int buffer, int[] indices)
        {
            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, 0);
            Gl.glDeleteBuffers(1, ref buffer);
            Gl.glGenBuffers(1, out buffer);
            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, buffer);
            Gl.glBufferData(Gl.GL_ELEMENT_ARRAY_BUFFER,
                 (IntPtr)(indices.Length * sizeof(int)),
                              indices, Gl.GL_DYNAMIC_DRAW);
            //Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, 0);
        }
        /// <summary>
        /// BufferDataInit
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="data"></param>
        /// <param name="size"></param>
        public static void VertexDataInit<T>(ref int buffer, T[] data, int size)
        {
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);
            Gl.glDeleteBuffers(1, ref buffer);
            Gl.glGenBuffers(1, out buffer);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, buffer);

            Gl.glBufferData(Gl.GL_ARRAY_BUFFER,
                 (IntPtr)(data.Length * size),
                              data, Gl.GL_STREAM_DRAW);
        }
        /// <summary>
        /// SetSubData
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="data"></param>
        public static void SetSubData<T>(int buffer, int offset, int size,T[] data)
        {
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, buffer);
            Gl.glBufferSubData(Gl.GL_ARRAY_BUFFER, (IntPtr)offset, (IntPtr)size, data);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);
        }
        /// <summary>
        /// GetSubData
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="data"></param>
        public static void GetSubData<T>(int buffer, int offset, int size, T[] data)
        {
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, buffer);
            Gl.glGetBufferSubData(Gl.GL_ARRAY_BUFFER, (IntPtr)offset, (IntPtr)size, data);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);
        }

    }
}
