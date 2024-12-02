using System;
using System.Drawing;

namespace BasicControls.ProgressBarEx.Functions.Drawing
{
    public class MySize
    {
        public static CompareOutputTypes Compare(Size S1, Size S2)
        {
            if (S1.Height == S2.Height && S1.Width == S2.Width)
                return CompareOutputTypes.Equal;
            if (S1.Height <= S2.Height && S1.Width <= S2.Width)
                return CompareOutputTypes.Smaller;
            if (S1.Height <= S2.Height && S1.Width >= S2.Width)
                return CompareOutputTypes.Unknown;
            return CompareOutputTypes.Larger;

        }
        public enum CompareOutputTypes { Smaller, Equal, Larger,Unknown };
    }
    
}
