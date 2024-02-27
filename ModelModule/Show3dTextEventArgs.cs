using Geometry;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ModelModule
{
    public class Show3dTextEventArgs : EventArgs, IEnumerable<Tuple<string, Point3D>>
    {
        List<Tuple<string, Point3D>> curveCenters;

        public Show3dTextEventArgs(List<Tuple<string, Point3D>> curveCenters)
        {
            this.curveCenters = curveCenters;
        }

        public IEnumerator<Tuple<string, Point3D>> GetEnumerator()
        {
            foreach (var curveCenter in curveCenters)
            {
                yield return curveCenter;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}