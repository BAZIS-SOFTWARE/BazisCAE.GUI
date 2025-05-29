using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scene;
using Scene.VBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tao.OpenGl;


namespace SceneTests
{
    [TestClass]
    public class BarycentricSolverTests
    {
        private SceneControl sceneControl;

        [TestInitialize]
        public void Init()
        {
            sceneControl = new SceneControl();
            sceneControl.Initialization();
        }
        [DataTestMethod]
        [DataRow(new float[] { 0, 0, 0, 0, 10, 0, 10, -2, 0 }, new int[] { 1, 1 })]       
        public void Smooth3DElement(float[] coords, int[] mouseCoords)
        {
            /*var ptrs = new int[] { 0, 1, 2 };
            sceneControl.CreateSurfaceVBObjects(ptrs, coords, new float[0], new float[0],
                                                new bool[0], "Элемент2D", new int[0], Scene.Interfaces.ObjView.Surface);
            var obj = sceneControl.FindVBObj("Элемент2D") as SurfaceObjects;

            var vp = new int[4];
            Gl.glGetIntegerv(Gl.GL_VIEWPORT, vp);

            sceneControl.selector.Viewport[0] = vp[2];
            sceneControl.selector.Viewport[1] = vp[3];

            sceneControl.selector.PickElement(obj, new Point(mouseCoords[0], mouseCoords[1]), Color.Green);*/
        }
    }
}
