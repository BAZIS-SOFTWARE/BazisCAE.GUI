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
using Model.MeshObjects;
using Scene.Interfaces;


namespace SceneTests
{
    [TestClass]
    public class ElementSelectorTests
    {
        private SceneControl sceneControl;
        [TestInitialize]
        public void Init()
        {
            sceneControl = new SceneControl();
            sceneControl.Initialization();
        }

        [TestCleanup]
        public void CleanUp()
        {
            sceneControl.Dispose();
        }

        [DataTestMethod]
        [DataRow(new double[] { 0, 0, 0 }, 
                 new double[] { 0, 10, 0 }, 
                 new double[] { 10, -2, 0 }, 
                 new int[] { 1, 1 }, 
                 new double[] { 0.78, 0.12, 0.1})]
        [DataRow(new double[] { 0, 0, 0 },
                 new double[] { 0, 10, 0 },
                 new double[] { 10, -2, 0 },
                 new int[] { 0, 10 },
                 new double[] { 0.0, 1.0, 0.0 })]
        [DataRow(new double[] { 0, 0, 0 },
                 new double[] { 0, 10, 0 },
                 new double[] { 10, -2, 0 },
                 new int[] { 0, 4 },
                 new double[] { 0.6, 0.4, 0.0 })]
        [DataRow(new double[] { 0, 0, 0 },
                 new double[] { 0, 10, 0 },
                 new double[] { 10, -2, 0 },
                 new int[] { 4, 3 },
                 new double[] { 0.22, 0.38, 0.4 })]
        [DataRow(new double[] { 0, 0, 0 },
                 new double[] { 0, 10, 0 },
                 new double[] { 10, -2, 0 },
                 new int[] { 6, 7 },
                 new double[] { -0.42, 0.82, 0.6 })]
        [DataRow(new double[] { 0, 0, 0 },
                 new double[] { 0, 10, 0 },
                 new double[] { 10, -2, 0 },
                 new int[] { 5, 4 },
                 new double[] { 0.0 , 0.5, 0.5 })]
        public void TriangleTest(double[] a, double[] b, double[] c, int[] mouseCoords, double[] expected)
        {
            sceneControl.ElementSelector.MouseClick = new Point(mouseCoords[0], mouseCoords[1]);
            var result = sceneControl.ElementSelector.SolveBarycentric(a, b, c);

            Assert.AreEqual(expected[0], result[0], 1e-4);
            Assert.AreEqual(expected[1], result[1], 1e-4);
            Assert.AreEqual(expected[2], result[2], 1e-4);
        }
    }
}
