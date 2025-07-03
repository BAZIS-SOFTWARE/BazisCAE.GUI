using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using PrFunctionLib;
using PrMesh;

namespace PrScene
{
    public class TetraNormal : Object
    {
        public TetraNormal(Coord3D [][] normalCoords)
        {
            Count = normalCoords.GetLength(0) * 4;
            Color = new Color(0, 1, 1);

            GlCoord = new float[6 * Count];
            GlMasterColor = new float[6 * Count];
            GlSlaveColor = new float[6 * Count];
            GlPtr = new int[2 * Count];
            GlObjType = GlObjType.line;

            Gl_LineWidth = 3.5f;
            Gl_PointSize = 3.5f;

            var tetraCount = normalCoords.GetLength(0);
            for (int i = 0; i < tetraCount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    GlCoord[24 * i + 6 * j + 0] = normalCoords[i][2 * j + 0]._x;
                    GlCoord[24 * i + 6 * j + 1] = normalCoords[i][2 * j + 0]._y;
                    GlCoord[24 * i + 6 * j + 2] = normalCoords[i][2 * j + 0]._z;

                    GlCoord[24 * i + 6 * j + 3] = normalCoords[i][2 * j + 1]._x;
                    GlCoord[24 * i + 6 * j + 4] = normalCoords[i][2 * j + 1]._y;
                    GlCoord[24 * i + 6 * j + 5] = normalCoords[i][2 * j + 1]._z;
                }

                for (int j = 0; j < 4; j++)
                {
                    GlMasterColor[24 * i + 6 * j + 0] = Color.red;
                    GlMasterColor[24 * i + 6 * j + 1] = Color.green;
                    GlMasterColor[24 * i + 6 * j + 2] = Color.blue;

                    GlMasterColor[24 * i + 6 * j + 3] = Color.red; ;
                    GlMasterColor[24 * i + 6 * j + 4] = Color.green;
                    GlMasterColor[24 * i + 6 * j + 5] = Color.blue;
                }
                for (int j = 0; j < 4; j++)
                {
                    GlPtr[8 * i + 2 * j + 0] = 8 * i + 2 * j + 0;
                    GlPtr[8 * i + 2 * j + 1] = 8 * i + 2 * j + 1;
                }
            }
            VBO.VertexInit(VertexBuffer, GlCoord);
            VBO.VertexInit(ColorsBuffer, GlMasterColor);
            VBO.IndexInit(IndicesBuffer, GlPtr);
        }

        public override Coord3D GetCentreCoords(int ind)
        {
            throw new NotImplementedException();
        }

        public void GetGlCorColPtr(ref Coord3D[] nodesCoordOfNormals, Color elemColor, int i)
        {
 

        }

        public override bool IsObjShowen(int ind)
        {
            throw new NotImplementedException();
        }
    }
}
