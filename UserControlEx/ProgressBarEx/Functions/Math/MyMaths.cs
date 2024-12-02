using System;

namespace BasicControls.ProgressBarEx.Functions.Math
{
    public class MyMaths
    {
        protected static double Percent(float Range, float Percent)
        {
            return System.Math.Ceiling(Range *Percent / 100);
        }
        public static int Percent(int Range, int Percent)
        {
            return (int)MyMaths.Percent((float)Range,(float)Percent);
        }
    }
}
