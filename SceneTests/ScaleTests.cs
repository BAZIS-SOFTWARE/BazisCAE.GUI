using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scene;
using System;
using System.Drawing;
using System.Linq;

namespace SceneTests
{
    [TestClass]
    public class ScaleTests
    {
        [DataTestMethod]
        [DataRow(0.1f, 10.5f, 3, 1, 0)]
        [DataRow(0.1f, 10.5f, 3, 10, 2)]
        [DataRow(0.1f, 10.5f, 3, 11, 2)]
        [DataRow(0.1f, 10.5f, 3, 0, 0)]
        [DataRow(0.1f, 10.5f, 3, 5, 1)]
        public void GetColorFromValue(float min,float max, int ranges,float value, int answer)
        {
            var sc = new SceneControl();
            var scale = sc.CreateScaleObject(min, max, ranges, "", "");

            //assign

            //act
            var color = scale.GetValueColor(value);
            var colorIndex = scale.Select(x => x.Color).ToList().IndexOf(color);

            //assert
            Assert.AreEqual(answer, colorIndex);
        }

        [DataTestMethod]
        [DataRow(0.1f, 10.5f, 3)]
        [DataRow(0.1f, 10.5f, 5)]
        [DataRow(0.1f, 10.5f, 2)]
        public void GetMinMaxValue(float min, float max, int ranges)
        {
            //assign
            var sc = new SceneControl();
            var scale = sc.CreateScaleObject(min, max, ranges, "", "");

            //act

            //assert
            Assert.AreEqual(min, scale.MinValue);
            Assert.AreEqual(max, scale.MaxValue);
        }
    }
}
