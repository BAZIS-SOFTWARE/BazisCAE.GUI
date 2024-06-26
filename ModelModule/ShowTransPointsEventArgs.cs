using System.Collections.Generic;
using System;

namespace ModelModule
{
    public class ShowTransPointsEventArgs
    {
        List<int> curvesNumbers;

        public ShowTransPointsEventArgs(List<int> curvesNumbers)
        {
            this.curvesNumbers = curvesNumbers;
        }

        public IEnumerator<int> GetNumbers()
        {
            foreach (var item in curvesNumbers)
            {
                yield return item;
            }
        }
    }
}