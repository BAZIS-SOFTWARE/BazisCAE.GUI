using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using PrFunctionLib;
using PrMesh;

namespace PrScene
{
    public class Triangle : Object// настройки для группы элементов
    {
        float[] glFrameColor;
        public float[] GlFrameColor { get { return glFrameColor; } }

        int[] colorsFrameBuffer = new int[] { 0 };
        int[] colorsSurfaceBuffer = new int[] { 0 };
        public int[] ColorsFrameBuffer { get { return colorsFrameBuffer; } }
        public int[] ColorsSurfaceBuffer { get { return colorsSurfaceBuffer; } }

        public Coord3D[] normalCoords;

        //public int Count { get;}
        public int[][] ElemsNodesNumbers { get; set; }
        public int NumberOfNodes { get; }

        public Triangle(float[][] nodeCoord, int[][] elemNodesNumbers)
        {
            Count = elemNodesNumbers.GetLength(0);

            ElemsNodesNumbers = elemNodesNumbers;

            GlCoord = new float[9 * Count];
            GlMasterColor = new float[9 * Count];
            GlSlaveColor = new float[9 * Count];
            GlPtr = new int[9 * Count];
            GlObjType = GlObjType.triangle;
            Gl_LineWidth = 2.0f;
            NumberOfNodes = 3;

            glFrameColor = new float[9 * Count];
            

            Color = new Color(0, 0, 1);

            for (int i = 0; i < Count; i++)
            {
                GlPtr[3 * i + 0] = (3 * i) + 0;
                GlPtr[3 * i + 1] = (3 * i) + 1;
                GlPtr[3 * i + 2] = (3 * i) + 2;
            }
           
            for (int i = 0; i < Count; i++)
            {
                GlMasterColor[9 * i + 0] = Color.red;
                GlMasterColor[9 * i + 1] = Color.green;
                GlMasterColor[9 * i + 2] = Color.blue;
                GlMasterColor[9 * i + 3] = Color.red;
                GlMasterColor[9 * i + 4] = Color.green;
                GlMasterColor[9 * i + 5] = Color.blue;
                GlMasterColor[9 * i + 6] = Color.red;
                GlMasterColor[9 * i + 7] = Color.green;
                GlMasterColor[9 * i + 8] = Color.blue;
            }

            for (int i = 0; i < Count; i++)
            {
                GlCoord[9 * i + 0] = nodeCoord[elemNodesNumbers[i][0]][0];
                GlCoord[9 * i + 1] = nodeCoord[elemNodesNumbers[i][0]][1];
                GlCoord[9 * i + 2] = nodeCoord[elemNodesNumbers[i][0]][2];
                GlCoord[9 * i + 3] = nodeCoord[elemNodesNumbers[i][1]][0];
                GlCoord[9 * i + 4] = nodeCoord[elemNodesNumbers[i][1]][1];
                GlCoord[9 * i + 5] = nodeCoord[elemNodesNumbers[i][1]][2];
                GlCoord[9 * i + 6] = nodeCoord[elemNodesNumbers[i][2]][0];
                GlCoord[9 * i + 7] = nodeCoord[elemNodesNumbers[i][2]][1];
                GlCoord[9 * i + 8] = nodeCoord[elemNodesNumbers[i][2]][2];
            }
            VBO.IndexInit(IndicesBuffer, GlPtr);
            VBO.VertexInit(colorsFrameBuffer, glFrameColor);
            VBO.VertexInit(ColorsSurfaceBuffer, GlMasterColor);
        }

        public void Fill_GlCoordArray(float [] nodesToPass, int elemNumber,int [] nodesNumbers)//PerElemint elemNumber, int ind0, int ind1, int ind2, int ind3)
        {
            GlCoord[9 * elemNumber + 0] = nodesToPass[(3 * nodesNumbers[0]) + 0];
            GlCoord[9 * elemNumber + 1] = nodesToPass[(3 * nodesNumbers[0]) + 1];
            GlCoord[9 * elemNumber + 2] = nodesToPass[(3 * nodesNumbers[0]) + 2];
            GlCoord[9 * elemNumber + 3] = nodesToPass[(3 * nodesNumbers[1]) + 0];
            GlCoord[9 * elemNumber + 4] = nodesToPass[(3 * nodesNumbers[1]) + 1];
            GlCoord[9 * elemNumber + 5] = nodesToPass[(3 * nodesNumbers[1]) + 2];
            GlCoord[9 * elemNumber + 6] = nodesToPass[(3 * nodesNumbers[2]) + 0];
            GlCoord[9 * elemNumber + 7] = nodesToPass[(3 * nodesNumbers[2]) + 1];
            GlCoord[9 * elemNumber + 8] = nodesToPass[(3 * nodesNumbers[2]) + 2];
        }

        public override bool IsObjShowen(int ind)
        {
            if (ind == 0) return true;
            else if (GlPtr[(3 * ind) + 0] != 0) return true;
            else return false;
        }

        public override Coord3D GetCentreCoords(int i)
        {
            var x = (GlCoord[9 * i + 0] + GlCoord[9 * i + 3] + GlCoord[9 * i + 6]) / 3;
            var y = (GlCoord[9 * i + 1] + GlCoord[9 * i + 4] + GlCoord[9 * i + 7]) / 3;
            var z = (GlCoord[9 * i + 2] + GlCoord[9 * i + 5] + GlCoord[9 * i + 8]) / 3;

            return new Coord3D(x, y, z);
        }
    }
}
