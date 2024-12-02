using System;


namespace BasicControls.ProgressBarEx.Functions.Drawing
{
    public class MyColor
    {
        public static System.Drawing.Color GetBestContrast(System.Drawing.Color BackColor)
        {

            int nThreshold = 105;

            int bgDelta = Convert.ToInt32((BackColor.R * 0.299) + (BackColor.G * 0.587) + (BackColor.B * 0.114));

            System.Drawing.Color ForeColor = (255 - bgDelta < nThreshold) ? System.Drawing.Color.Black : System.Drawing.Color.White;

            return ForeColor;

        }

    }
}
