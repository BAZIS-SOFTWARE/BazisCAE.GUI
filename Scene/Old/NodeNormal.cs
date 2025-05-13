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
    public class NodeNormal : Object
    {
        public Coord3D[][] Coords { get; set; }

        public NodeNormal(Coord3D[][] coords)
        {
            Count = coords.GetLength(0);
            Color = new Color(1, 0, 0);

            GlCoord = new float[6 * Count];
            GlMasterColor = new float[6 * Count];
            GlSlaveColor = new float[6 * Count];
            GlPtr = new int[2 * Count];
            GlObjType = GlObjType.line;
            Gl_LineWidth = 3.5f;
            Gl_PointSize = 3.5f;

            for (int i = 0; i < Count; i++)
            {
                    GlCoord[6 * i + 0] = coords[i][0]._x;
                    GlCoord[6 * i + 1] = coords[i][0]._y;
                    GlCoord[6 * i + 2] = coords[i][0]._z;
                    // summ node coord + nodeNormal coord = normalLine
                    GlCoord[6 * i + 3] = coords[i][1]._x;
                    GlCoord[6 * i + 4] = coords[i][1]._y;
                    GlCoord[6 * i + 5] = coords[i][1]._z;

                    GlMasterColor[6 * i + 0] = Color.red;
                    GlMasterColor[6 * i + 1] = Color.green;
                    GlMasterColor[ 6 * i + 2] = Color.blue;

                    GlMasterColor[6 * i + 3] = Color.red;
                    GlMasterColor[6 * i + 4] = Color.green;
                    GlMasterColor[6 * i + 5] = Color.blue;

                    GlPtr[2 * i + 0] = 2 * i + 0;
                    GlPtr[2 * i + 1] = 2 * i + 1;              
            }

            Coords = coords;

            VBO.VertexInit(VertexBuffer, GlCoord);
            VBO.VertexInit(ColorsBuffer, GlMasterColor);
            VBO.IndexInit(IndicesBuffer, GlPtr);
        }      

        public override bool IsObjShowen(int ind)
        {
            throw new NotImplementedException();
        }

        public override Coord3D GetCentreCoords(int ind)
        {
            throw new NotImplementedException();
        }
    }
}
