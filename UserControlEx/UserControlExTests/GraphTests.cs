using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserControlsEx.Graph.Functions;

namespace UserControlExTests
{
    [TestClass]
    public class GraphTests
    {
        [DataTestMethod]
        [DataRow(20, 300, 210, 190, 100.0f, 204.2857f)]
        [DataRow(20, 300, 190, 220, 100.0f, 198.5714f)]
        [DataRow(600, 1500, 210, 190, 700.0f, 207.7778f)]
        [DataRow(1500, 600, 210, 190, 700.0f, 192.2222f)]
        [DataRow(1500, 600, 210, 190, 1700.0f, 210)]
        [DataRow(300, 20, 50, 5, 15, 5)]
        [DataRow(20, 300, 210, 190, 10, 210)]
        [DataRow(600, 1500, 50, 5, 2000, 5)]
        [DataRow(600, 1500, 5, 50, 2000, 50)]
        public void TestInterpolationTwoPointsFloat(float x1, float x2, float y1, float y2, float xn, float resu)
        {
            //arrange
            var xAr = new float[] { x1, x2 };
            var yAr = new float[] { y1, y2 };

            //act
            var resu_i = InterpolationSearch.InterpolatedValueTwoPoints(x1, x2, y1, y2, xn);

            //assert
            Assert.AreEqual(resu, resu_i, 0.0001f);
        }
    }
}
