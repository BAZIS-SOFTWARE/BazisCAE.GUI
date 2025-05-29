using Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using Tao.OpenGl;

namespace Scene
{
    internal static class ScaleBar
    {
        private const float textOffsetX = 0.02f;
        private const float textOffsetY = 0.005f;

        private const float offsetX = 0.250f;
        private const float offsetY = 0.025f;
        private const float blockAspectRatio = 8f;

        private static int coordsBuffer;
        private static int colorsBuffer;

        private static int indexLineBuffer;
        private static int indexTriangleBuffer;

        private static float blockSizeX;
        private static float blockSizeY;

        private static List<float> coords = new List<float>();
        private static List<float> colors = new List<float>();

        private static List<int> triangleIndices = new List<int>();
        private static List<int> lineIndices = new List<int>();

        private static int lineIndicesCount;
        private static int triangleIndicesCount;
        private static int blocks;
        private static float diagonal;

        internal static float OffsetX { get; set; }
        internal static float OffsetY { get; set; }
        internal static int FontBase { get; set; }

        internal static void Create(float bbDiagonal, int blockCounts = 4)
        {
            blocks = blockCounts;
            diagonal = bbDiagonal;

            Delete();
            CreateBuffers();

            var blockAreaX = 1 - offsetX * 2;
            blockSizeX = blockAreaX / blockCounts;
            blockSizeY = blockSizeX *  1 / blockAspectRatio;

            CreatePoints(blockCounts);
            CreateIndices(blockCounts);
            CreateColors();

            SendDataToGPU();
            ClearData();
        }

        internal static void Delete()
        {
            Gl.glDeleteBuffers(1, ref coordsBuffer);
            Gl.glDeleteBuffers(1, ref colorsBuffer);
            Gl.glDeleteBuffers(1, ref indexLineBuffer);
            Gl.glDeleteBuffers(1, ref indexTriangleBuffer);

            coordsBuffer = 0;
            colorsBuffer = 0;
            indexLineBuffer = 0;
            indexTriangleBuffer = 0;
        }

        internal static void Draw()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glOrtho(0.0f, 1.0f, 0.0f, 1.0f, -1.0f, 1.0f);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glTranslatef(OffsetX, OffsetY, 0);

            Gl.glEnableClientState(Gl.GL_INDEX_ARRAY);
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);

            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, indexTriangleBuffer);

            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, coordsBuffer);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, IntPtr.Zero);

            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, colorsBuffer);
            Gl.glColorPointer(3, Gl.GL_FLOAT, 0, IntPtr.Zero);

            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
            Gl.glDrawElements(Gl.GL_TRIANGLES, triangleIndicesCount, Gl.GL_UNSIGNED_INT, IntPtr.Zero);

            Gl.glLineWidth(1);
            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, indexLineBuffer);
            Gl.glDrawElements(Gl.GL_LINES, lineIndicesCount, Gl.GL_UNSIGNED_INT, IntPtr.Zero);

            DrawText();

            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, 0);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);

            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);

            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix();
        }

        private static void DrawText()
        {
            var offset = diagonal / blocks;
            for(var i = 0; i <= blocks; ++i)
            {
                var value = i * offset;
                var text = value.ToString("0.00");

                var textXOffset = text.Length / 2f * textOffsetX;

                var scaleY = (i + 1) & 1;
                var scaleInvY = i & 1;
                var x = i * blockSizeX + offsetX - textOffsetX;
                var y = scaleY * blockSizeY + offsetY + textOffsetY - scaleInvY * offsetY;

                DrawText(text, x, y);
            }
        }

        private static void DrawText(string text, float x, float y)
        {
            Gl.glRasterPos3f(x, y, 0);
            Gl.glPushAttrib(Gl.GL_LIST_BASE);
            Gl.glListBase(FontBase);
            Gl.glCallLists(text.Length, Gl.GL_UNSIGNED_SHORT, text);
            Gl.glPopAttrib();
        }

        private static void CreateBuffers()
        {
            Gl.glGenBuffers(1, out coordsBuffer);
            Gl.glGenBuffers(1, out colorsBuffer);

            Gl.glGenBuffers(1, out indexLineBuffer);
            Gl.glGenBuffers(1, out indexTriangleBuffer);
        }


        private static void CreatePoints(int blockCounts)
        {
            var firstPnt = new float[] { offsetX, offsetY, 0 };
            var lastPnt = new float[] { offsetX, offsetY + blockSizeY, 0 };

            coords.AddRange(firstPnt);
            coords.AddRange(lastPnt);

            for (var i = 0; i < blockCounts; ++i)
            {
                firstPnt[0] = (i + 1) * blockSizeX + offsetX;
                lastPnt[0] = (i + 1) * blockSizeX + offsetX;

                coords.AddRange(firstPnt);
                coords.AddRange(lastPnt);
            }
        }

        private static void CreateIndices(int blockCounts)
        {
            var indices = 0;
            for (var i = 0; i < blockCounts; ++i)
            {
                if ((i & 1) == 0)
                {
                    triangleIndices.AddRange(new int[] { indices, indices + 2, indices + 3, indices, indices + 3, indices + 1 });
                    indices += 4;
                }
                else
                    lineIndices.AddRange(new int[] { indices - 2, indices, indices, indices + 1, indices + 1, indices - 1 });
                
            }
        }

        private static void CreateColors() => colors.AddRange(new float[coords.Count]);

        private static void SendDataToGPU()
        {
            var coordsArray = coords.ToArray();
            var colorsArray = colors.ToArray();
            var lineArray = lineIndices.ToArray();
            var triangleArray = triangleIndices.ToArray();

            lineIndicesCount = lineArray.Length;
            triangleIndicesCount = triangleArray.Length;

            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, coordsBuffer);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(coordsArray.Length * sizeof(float)), coordsArray, Gl.GL_STREAM_DRAW);

            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, colorsBuffer);
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, (IntPtr)(colorsArray.Length * sizeof(float)), colorsArray, Gl.GL_STREAM_DRAW);

            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, indexLineBuffer);
            Gl.glBufferData(Gl.GL_ELEMENT_ARRAY_BUFFER, (IntPtr)(lineArray.Length * sizeof(int)), lineArray, Gl.GL_STREAM_DRAW);

            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, indexTriangleBuffer);
            Gl.glBufferData(Gl.GL_ELEMENT_ARRAY_BUFFER, (IntPtr)(triangleArray.Length * sizeof(int)), triangleArray, Gl.GL_STREAM_DRAW);

            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, 0);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, 0);
        }

        private static void ClearData()
        {
            coords.Clear();
            colors.Clear();
            lineIndices.Clear();
            triangleIndices.Clear();
        }
    }
}
