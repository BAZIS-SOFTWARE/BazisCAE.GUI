using PrFunctionLib;
using PrMesh;
using PrScene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace PrScene
{
    public class Node : Object  // настройки для группы узлов
    {

        public List<int> [] CommonElements{get;set;}

        public Coord3D[][] NormalsCoords { get; }

        public Node(float[][] coord)
        {
            Count = coord.GetLength(0);
            GlCoord = new float[Count * 3];
            GlMasterColor = new float[Count * 3];
            GlSlaveColor = new float[Count * 3];
            GlPtr = new int[Count];
            GlObjType = GlObjType.point;
            Gl_PointSize = 4.5f;
            CommonElements = new List<int>[Count];

            NormalsCoords = new Coord3D[Count][];
            for (int i = 0; i < CommonElements.Length; i++)
            {
                CommonElements[i] = new List<int>();
            }
            Color = new Color(0, 0, 1);

            for (int i = 0; i < Count; i++)
            {
                GlPtr[i] = i;

                GlMasterColor[3 * i + 0] = Color.red;
                GlMasterColor[3 * i + 1] = Color.green;
                GlMasterColor[3 * i + 2] = Color.blue;

                GlSlaveColor[3 * i + 0] = Color.red;
                GlSlaveColor[3 * i + 1] = Color.green;
                GlSlaveColor[3 * i + 2] = Color.blue;

                GlCoord[(3 * i) + 0] = coord[i][0];
                GlCoord[(3 * i) + 1] = coord[i][1];
                GlCoord[(3 * i) + 2] = coord[i][2];

                NormalsCoords[i] = new Coord3D[2];
                NormalsCoords[i][0]._x = coord[i][0];
                NormalsCoords[i][0]._y = coord[i][1];
                NormalsCoords[i][0]._z = coord[i][2];

                NormalsCoords[i][1]._x = coord[i][0];
                NormalsCoords[i][1]._y = coord[i][1];
                NormalsCoords[i][1]._z = coord[i][2];
            }


            VBO.VertexInit(ColorsBuffer, GlMasterColor);
            VBO.IndexInit(IndicesBuffer, GlPtr);
            VBO.VertexInit(VertexBuffer, GlCoord);
        }

        public override bool IsObjShowen(int ind)
        {
            if (ind == 0) return true;
            else if (GlPtr[ind] != 0) return true;
            else return false;
        }

        public override Coord3D GetCentreCoords(int ind)
        {
            var coord = new Coord3D();
            coord._x = GlCoord[(3 * ind) + 0];
            coord._y = GlCoord[(3 * ind) + 1];
            coord._z = GlCoord[(3 * ind) + 2];
            return coord;
        }

        public void Fill_GlCorColPtr(int ind, string line)
        {
            var splitLine = line.Split(' ');
            var index = ind;

            var x = float.Parse(splitLine[0]);
            var y = float.Parse(splitLine[1]);
            var z = float.Parse(splitLine[2]);

            GlCoord[(3 * index) + 0] = x;
            GlCoord[(3 * index) + 1] = y;
            GlCoord[(3 * index) + 2] = z;
        }
    }
}
