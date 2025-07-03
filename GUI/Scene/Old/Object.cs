using PrFunctionLib;
using PrMesh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace PrScene
{

    public enum ObjView
    {       
        NodeVolume,
        NodeSurface,
        TetraSurface,
        TetraFramesSurface,
        TetraFrames,
        TriaSurface,
        TriaFramesSurface,
        TriaFrames,
        Lines,
        Nodes = 0
    }

    public struct Transform
    {
        public float mov_x;
        public float mov_y;
        public float mov_z;
    }

    public enum GlObjType : int { point, line, triangle = 4, square = 7 };
    public abstract class Object
    {
       
        internal float[] GlCoord { get; set; }
        internal float[] GlMasterColor { get; set; }
        internal float[] GlSlaveColor { get; set; }
        internal int[] GlPtr { get; set; }

        int[] vertexBuffer = new int[] { 0 };
        int[] indicesBuffer = new int[] { 0 };
        int[] colorsBuffer = new int[] { 0 };

        internal int[] VertexBuffer { get { return vertexBuffer; } set { vertexBuffer = value; } }
        internal int[] ColorsBuffer { get { return colorsBuffer; } set { colorsBuffer = value; } }
        internal int[] IndicesBuffer { get { return indicesBuffer; } set { indicesBuffer = value; } }

        public GlObjType GlObjType { get; set; }
        public float Gl_PointSize { get; set; }
        public float Gl_LineWidth { get; set; }
        public int Gl_DisplayMode { get; set; }

        internal int Count { get; set; }
        internal Color Color { get; set; }
        public abstract bool IsObjShowen(int ind);
        public abstract Coord3D GetCentreCoords(int ind);

        //class FloatBuffer
        //{
        //    private float[] _floatBuffer;

        //    public int Length { get { return _floatBuffer.Length; } }
        //    public float this[int index] //вот как раз  get и set 
        //    {
        //        get { return _floatBuffer[index]; }
        //        set
        //        {
        //            if (value.GetType() == typeof(float))
        //            {
        //                _floatBuffer[index] = value;
        //            }
        //        }
        //    }
        //    public float [] GetArray
        //    {
        //        get { return _floatBuffer; }
        //        set { _floatBuffer = value; }
        //    }
        //    public FloatBuffer(int size)
        //    {
        //        _floatBuffer = new float[size];
        //    }
        //}
        //public class ListofGroups
        //{
        //    public String Head { get; set; }
        //    private readonly List<string> _subHead = new List<string>();
        //    private readonly List<string> _content = new List<string>();

        //    public IEnumerable<string> SubHead { get { return _subHead; } }
        //    public IEnumerable<string> Content { get { return _content; } }

        //    public void AddContent(String argValue)
        //    {
        //        _content.Add(argValue);
        //    }

        //    public void AddSubHeader(String argValue)
        //    {
        //        _subHead.Add(argValue);
        //    }
        //}
    }
}