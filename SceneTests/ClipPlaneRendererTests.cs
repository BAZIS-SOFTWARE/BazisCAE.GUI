using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scene;
using System.Collections.Generic;
using System.Linq;

namespace SceneTests
{
    [TestClass]
    public class ClipPlaneRendererTests
    {
        [DataTestMethod]
        [DataRow(new float[] { -1, 1,0, 0, 10,0}, new float[] { -1, 1, 0, 10, 10, 0 },202)]
        [DataRow(new float[] { -10, -10,0, 10, 10,10 }, new float[] { -10, -10, 0, 11, 11, 11 },1003)]
        public void FindBoundingBox(float[] bbx_crds_1, float[] bbx_crds_2, float maxVol)
        {
            var p0 = new Point3D(bbx_crds_1[0], bbx_crds_1[1], bbx_crds_1[2]);
            var p1 = new Point3D(bbx_crds_1[3], bbx_crds_1[4], bbx_crds_1[5]);
            var bbox1 = new BoundingBox(p0, p1);

            var p2 = new Point3D(bbx_crds_2[0], bbx_crds_2[1], bbx_crds_2[2]);
            var p3 = new Point3D(bbx_crds_2[3], bbx_crds_2[4], bbx_crds_2[5]);
            var bbox2 = new BoundingBox(p2, p3);

            var bboxes = new List<BoundingBox>() { bbox1, bbox2 };


            var max = bboxes.Max();

            Assert.AreEqual(max.GetSqrCoordsSum(), maxVol, 0.01f);
        }
    }
}
