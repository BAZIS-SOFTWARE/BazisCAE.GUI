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

    public class Tetra : Object// настройки для группы элементов
    {
        float[] glFrameColor;

        int[] colorsFrameBuffer = new int[] { 0 };
        int[] colorsSurfaceBuffer = new int[] { 0 };

        public int[] ColorsFrameBuffer { get { return colorsFrameBuffer; } }
        public int[] ColorsSurfaceBuffer { get { return colorsSurfaceBuffer; } }

        public Coord3D[][] SurfaceNormalsCoords { get; }

        public int[][] ElemsNodesNumbers { get; }
        public int NumberOfNodes { get; }

        public Tetra(float[][] nodeCoords, int[][] elemNodesNumbers, Coord3D[][]normalsCoords)
        {
            ElemsNodesNumbers = elemNodesNumbers;
            Count = elemNodesNumbers.GetLength(0);
            Color = Color.GenNewColor();

            GlCoord = new float[12 * Count];
            GlMasterColor = new float[12 * Count];
            GlSlaveColor = new float[12 * Count];
            GlPtr = new int[12 * Count];
            GlObjType = GlObjType.triangle;
            Gl_LineWidth = 2.0f;
            NumberOfNodes = 4;
            SurfaceNormalsCoords = new Coord3D[Count][];

            glFrameColor = new float[12 * Count];
            
            for (int i = 0; i < Count; i++)
            {
                GlPtr[12 * i + 0] = 4 * i + 0;
                GlPtr[12 * i + 1] = 4 * i + 1;
                GlPtr[12 * i + 2] = 4 * i + 2;
                GlPtr[12 * i + 3] = 4 * i + 0;
                GlPtr[12 * i + 4] = 4 * i + 2;
                GlPtr[12 * i + 5] = 4 * i + 3;
                GlPtr[12 * i + 6] = 4 * i + 0;
                GlPtr[12 * i + 7] = 4 * i + 3;
                GlPtr[12 * i + 8] = 4 * i + 1;
                GlPtr[12 * i + 9] = 4 * i + 1;
                GlPtr[12 * i + 10] = 4 * i + 2;
                GlPtr[12 * i + 11] = 4 * i + 3;

                if(i == 10)
                {

                }

                for (int j = 0; j < 4; j++)
                {
                    var colorAr = new Color[4];
                    colorAr[0] = new Color(Color.red, Color.green, Color.blue);
                    colorAr[1] = new Color(Color.red, Color.green, Color.blue);
                    colorAr[2] = new Color(Color.red, Color.green, Color.blue);
                    colorAr[3] = new Color(Color.red, Color.green, Color.blue);

                    GlSlaveColor[12 * i + (3 * j) + 0] = colorAr[j].red;
                    GlSlaveColor[12 * i + (3 * j) + 1] = colorAr[j].green;
                    GlSlaveColor[12 * i + (3 * j) + 2] = colorAr[j].blue;

                    GlMasterColor[12 * i + (3 * j) + 0] = colorAr[j].red;
                    GlMasterColor[12 * i + (3 * j) + 1] = colorAr[j].green;
                    GlMasterColor[12 * i + (3 * j) + 2] = colorAr[j].blue;
                }

                GlCoord[12 * i + 0] = nodeCoords[elemNodesNumbers[i][0]][0];
                GlCoord[12 * i + 1] = nodeCoords[elemNodesNumbers[i][0]][1];
                GlCoord[12 * i + 2] = nodeCoords[elemNodesNumbers[i][0]][2];
                GlCoord[12 * i + 3] = nodeCoords[elemNodesNumbers[i][1]][0];
                GlCoord[12 * i + 4] = nodeCoords[elemNodesNumbers[i][1]][1];
                GlCoord[12 * i + 5] = nodeCoords[elemNodesNumbers[i][1]][2];
                GlCoord[12 * i + 6] = nodeCoords[elemNodesNumbers[i][2]][0];
                GlCoord[12 * i + 7] = nodeCoords[elemNodesNumbers[i][2]][1];
                GlCoord[12 * i + 8] = nodeCoords[elemNodesNumbers[i][2]][2];
                GlCoord[12 * i + 9] = nodeCoords[elemNodesNumbers[i][3]][0];
                GlCoord[12 * i + 10] = nodeCoords[elemNodesNumbers[i][3]][1];
                GlCoord[12 * i + 11] = nodeCoords[elemNodesNumbers[i][3]][2];

                CalcSurfacesNormals(nodeCoords, elemNodesNumbers[i],i);
                CalcNodesNormals(SurfaceNormalsCoords[i], normalsCoords, elemNodesNumbers[i]);
            }
           
            VBO.IndexInit(IndicesBuffer, GlPtr);
            VBO.VertexInit(VertexBuffer, GlCoord);
            VBO.VertexInit(ColorsSurfaceBuffer, GlMasterColor);
            VBO.VertexInit(colorsFrameBuffer, glFrameColor);
        }

        public void CalcSurfacesNormals(float[][] nodesCoords, int[] elNodesNumbers,int ind)
        {
            Coord3D[] nodesOfElem = new Coord3D[elNodesNumbers.Length];
            for (int i = 0; i < elNodesNumbers.Length; i++)
            {
                nodesOfElem[i]._x = nodesCoords[elNodesNumbers[i]][0];
                nodesOfElem[i]._y = nodesCoords[elNodesNumbers[i]][1];
                nodesOfElem[i]._z = nodesCoords[elNodesNumbers[i]][2];
            }
            Coord3D centr;

            centr._x = (nodesOfElem[0]._x + nodesOfElem[1]._x + nodesOfElem[2]._x + nodesOfElem[3]._x) / 4;
            centr._y = (nodesOfElem[0]._y + nodesOfElem[1]._y + nodesOfElem[2]._y + nodesOfElem[3]._y) / 4;
            centr._z = (nodesOfElem[0]._z + nodesOfElem[1]._z + nodesOfElem[2]._z + nodesOfElem[3]._z) / 4;

            var vectors = GetVectorsCoords(nodesOfElem);
            var vectorsNormals = GetNormalOfVectors(vectors);
            //kfmaacrvy/mtZmvvvn281215
            var normalCoords = new Coord3D[8];

            for (int i = 0; i < 4; i++)
            {
                var nx = vectorsNormals[3 * i + 0];
                var ny = vectorsNormals[3 * i + 1];
                var nz = vectorsNormals[3 * i + 2];

                var nx2 = vectorsNormals[3 * i + 0] * vectorsNormals[3 * i + 0];
                var ny2 = vectorsNormals[3 * i + 1] * vectorsNormals[3 * i + 1];
                var nz2 = vectorsNormals[3 * i + 2] * vectorsNormals[3 * i + 2];

                var squaresumm = (nx2 + ny2 + nz2);
                var pt = GlPtr[3 * i + 0];
                var d = -(nx * nodesOfElem[pt]._x + ny * nodesOfElem[pt]._y + nz * nodesOfElem[pt]._z);

                var t = -(nx * centr._x + ny * centr._y + nz * centr._z + d) / squaresumm;

                normalCoords[2 * i + 0]._x = centr._x + nx * t;
                normalCoords[2 * i + 0]._y = centr._y + ny * t;
                normalCoords[2 * i + 0]._z = centr._z + nz * t;

                normalCoords[2 * i + 1]._x = normalCoords[2 * i + 0]._x - centr._x;
                normalCoords[2 * i + 1]._y = normalCoords[2 * i + 0]._y - centr._y;
                normalCoords[2 * i + 1]._z = normalCoords[2 * i + 0]._z - centr._z;

                var normLenght = Geometry.GetVectorLenght(normalCoords[2 * i + 1]);

                normalCoords[2 * i + 1]._x = (normalCoords[2 * i + 1]._x / normLenght) + normalCoords[2 * i + 0]._x;
                normalCoords[2 * i + 1]._y = (normalCoords[2 * i + 1]._y / normLenght) + normalCoords[2 * i + 0]._y;
                normalCoords[2 * i + 1]._z = (normalCoords[2 * i + 1]._z / normLenght) + normalCoords[2 * i + 0]._z;
            }
            SurfaceNormalsCoords[ind] = normalCoords;
        }

        public void CalcNodesNormals(Coord3D[] surfNormalsCoords, Coord3D[][] nodesCoords, int[] elNodesNumbers)
        {
            var ptr = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 1, 1, 2, 3 };
            var nodeNormalCoords = new Coord3D[8];
            
            for (int i = 0; i < 4; i++) // tetra's surfaces 
            {
                var dx = surfNormalsCoords[2 * i + 1]._x - surfNormalsCoords[2 * i + 0]._x;
                var dy = surfNormalsCoords[2 * i + 1]._y - surfNormalsCoords[2 * i + 0]._y;
                var dz = surfNormalsCoords[2 * i + 1]._z - surfNormalsCoords[2 * i + 0]._z;
                
                for (int j = 0; j < 3; j++) // tetra's surface's nodes
                {
                    var nodeNumb = elNodesNumbers[ptr[3 * i + j]];

                    nodesCoords[nodeNumb][1]._x = nodesCoords[nodeNumb][1]._x + dx;
                    nodesCoords[nodeNumb][1]._y = nodesCoords[nodeNumb][1]._y + dy;
                    nodesCoords[nodeNumb][1]._z = nodesCoords[nodeNumb][1]._z + dz;
                }
            }
        }

        public override Coord3D GetCentreCoords(int i)
        {
            var x = (GlCoord[12 * i + 0] + GlCoord[12 * i + 3] + GlCoord[12 * i + 6] + GlCoord[12 * i + 9]) / 4;
            var y = (GlCoord[12 * i + 1] + GlCoord[12 * i + 4] + GlCoord[12 * i + 7] + GlCoord[12 * i + 10]) / 4;
            var z = (GlCoord[12 * i + 2] + GlCoord[12 * i + 5] + GlCoord[12 * i + 8] + GlCoord[12 * i + 11]) / 4;

            return new Coord3D(x,y,z);
        }

        public Coord3D[] GetNodesCoords(int elemNumber)
        {
            var nodeCoords = new Coord3D[4];
            for (int i = 0; i < 4; i++)
            {
                var x = GlCoord[12 * elemNumber + (3 * i) + 0];
                var y = GlCoord[12 * elemNumber + (3 * i) + 1];
                var z = GlCoord[12 * elemNumber + (3 * i) + 2];
                nodeCoords[i] = new Coord3D(x, y, z);
            }
            return nodeCoords;
        }

        private float[] GetVectorsCoords(Coord3D[] nodes)
        {
            var vector = new float[24];
            var sides = 4;
            var ptr = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 1, 1, 2, 3 };

            for (int i = 0; i < sides; i++)
            {
                var n1 = 3 * i + 0; var n2 = 3 * i + 1; var n3 = 3 * i + 2;

                var x1 = nodes[ptr[n1]]._x; var x2 = nodes[ptr[n2]]._x; var x3 = nodes[ptr[n3]]._x;
                var y1 = nodes[ptr[n1]]._y; var y2 = nodes[ptr[n2]]._y; var y3 = nodes[ptr[n3]]._y;
                var z1 = nodes[ptr[n1]]._z; var z2 = nodes[ptr[n2]]._z; var z3 = nodes[ptr[n3]]._z;

                vector[6 * i + 0] = x2 - x1;
                vector[6 * i + 1] = y2 - y1;
                vector[6 * i + 2] = z2 - z1;

                vector[6 * i + 3] = x3 - x1;
                vector[6 * i + 4] = y3 - y1;
                vector[6 * i + 5] = z3 - z1;
            }
            return vector;
        }
        private float[] GetNormalOfVectors(float[] vectrs)
        {
            var normal = new float[12];
            var color = new float[] { 1, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                var a = new float[] { vectrs[6 * i + 0], vectrs[6 * i + 1], vectrs[6 * i + 2] };
                var b = new float[] { vectrs[6 * i + 3], vectrs[6 * i + 4], vectrs[6 * i + 5] };

                normal[3 * i + 0] = a[1] * b[2] - a[2] * b[1];
                normal[3 * i + 1] = a[2] * b[0] - a[0] * b[2];
                normal[3 * i + 2] = a[0] * b[1] - a[1] * b[0];
            }
            return normal;
        }

        public override bool IsObjShowen(int ind)
        {
            if (ind == 0) return true;
            else if (GlPtr[(12 * ind) + 0] != 0) return true;
            else return false;
        }
    }
}
