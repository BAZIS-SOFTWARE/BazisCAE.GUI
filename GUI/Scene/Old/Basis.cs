
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using PrFunctionLib;

namespace PrScene
{
    public class Basis : Object
    {
        public Transform position;

        public Basis()
        {
            Gl_LineWidth = 2.5f;

            GlCoord = new float[18];
            GlMasterColor = new float[18];
            GlSlaveColor = new float[18];
            GlPtr = new int[6];
            GlObjType = GlObjType.line;

            var coord = new float[][]
            {
                new float[3]{0, 0, 0 },
                new float[3]{0 + 0.025f, 0, 0 },
                new float[3]{0, 0, 0 },
                new float[3]{0, 0 + 0.025f, 0 },
                new float[3]{0, 0, 0 },
                new float[3]{0, 0, 0 + 0.025f},
            };

            var color = new float[][]
            {
                new float[3]{1.0f, 0.5f, 0.0f},
                new float[3]{1.0f, 0.5f, 0.0f },
                new float[3]{0.0f, 1.0f, 0.0f },
                new float[3]{0.0f, 1.0f, 0.0f },
                new float[3]{0.0f, 0.0f, 1.0f},
                new float[3]{0.0f, 0.0f, 1.0f},
            };
            var ptr = new int[] { 0, 1, 2, 3, 4, 5 };

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GlCoord[3 *i + j] = coord[i][j];
                    GlMasterColor[3 * i + j] = color[i][j];
                }
                
            }
            GlPtr = ptr;
            VBO.VertexInit(VertexBuffer , GlCoord);
            VBO.VertexInit(ColorsBuffer, GlMasterColor);
            VBO.IndexInit(IndicesBuffer, GlPtr);
        }

        public override Coord3D GetCentreCoords(int ind)
        {
            return new Coord3D();
        }

        public override bool IsObjShowen(int ind)
        {
            throw new NotImplementedException();
        }
    }
}
