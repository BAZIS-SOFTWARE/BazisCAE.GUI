using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using Scene.VBO;
using Tao.OpenGl;

namespace Scene
{
    internal class ElementSelector : IDisposable
    {
        private ShaderProgramCreator program = new ShaderProgramCreator();
        internal ElementSelector()
        {
            program.CreateShaderFromString(Gl.GL_VERTEX_SHADER, ShaderCollections.vertexBarycentricSolver);
            program.CreateShaderFromString(Gl.GL_GEOMETRY_SHADER_EXT, ShaderCollections.geometryBarycentricSolver);
            program.Link();
        }

        internal int PickElement(SurfaceObjects obj, Point screenMousePos, Color selectionColor)
        {
            



            return 0;
        }

        public void Dispose()
        {
            program?.Dispose();
        }
    }
}
