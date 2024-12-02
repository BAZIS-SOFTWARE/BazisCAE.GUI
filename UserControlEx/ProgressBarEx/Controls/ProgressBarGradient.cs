using System;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;


namespace BasicControls.ProgressBarEx.Controls
{
    public class ProgressBarGradient:ProgressBar
    {
        public ProgressBarGradient():base()
        {
            _GradientPercent = 100;
            GradientType = GradientTypes.FullWidthGradient;
        }

        #region Drawing

        public new Rectangle[] Prepare3Parts()
        {
            Rectangle xRec = ClientRectangle;
            int MiddleWidth = Functions.Math.MyMaths.Percent(xRec.Width, _GradientPercent);
            xRec.Inflate(MiddleWidth, 0);
            int Left = Functions.Math.MyMaths.Percent(ClientRectangle.Width + MiddleWidth, _iPercent);
            int Right = xRec.Width - MiddleWidth - Left;
            return Functions.Drawing.MyRectangle.SplitByPixels(xRec, new int[] { Left, MiddleWidth, Right }, Functions.Drawing.MyRectangle.SplitType.Horizontal);
        }
        public Rectangle[] Prepare4Parts()
        {
            Rectangle[] xRecs = Prepare3Parts();
            Rectangle[] xMiddleparts = Functions.Drawing.MyRectangle.SplitByPercent(xRecs[1], new int[] { 50, 50 }, Functions.Drawing.MyRectangle.SplitType.Horizontal);
            return new Rectangle[] { xRecs[0], xMiddleparts[0], xMiddleparts[1], xRecs[2] };
        }
        protected override void DrawBackgroundRolling(Graphics g)
        {
            if (_iPercent == 0)
            {
                FillRectangle(g, ClientRectangle, xBrushes[BrushBackGround]);
                //return;
            }
            Rectangle[] xRecs = Prepare4Parts();
            xRecs[1].Width++;
            BrushAndFill(g, xRecs[2], _ColorProgress, BackColor);
            BrushAndFill(g, xRecs[1], BackColor, _ColorProgress);

        }
        protected override void DrawBackground(Graphics g)
        {
            if (_iPercent == 0)
            {
                FillRectangle(g, ClientRectangle, xBrushes[BrushBackGround]);
                //return;
            }
            Rectangle[] xRecs = null;
            xRecs = Prepare3Parts();
            Rectangle xRectLeft = xRecs[0];
            Rectangle xRectMiddle = xRecs[1];
            Rectangle xRectRight = xRecs[2];
            xRectLeft.Width++;
            BrushAndFill(g, xRectMiddle, _ColorProgress, BackColor);
            FillRectangle(g, xRectLeft, xBrushes[BrushProgress]);
            FillRectangle(g, xRectRight, xBrushes[BrushBackGround]);

        }
        protected void BrushAndFill(Graphics g, Rectangle xRec, Color xColor1, Color xColor2)
        {
            if (xRec.Width == 0)
                return;
            Brush xBrush = new LinearGradientBrush(xRec, xColor1, xColor2, 0f);
            g.FillRectangle(xBrush, xRec);
            xBrush.Dispose();
        }


        #endregion
        
        #region Gradient
//        protected const string BrushGradient = "BrushGradient";
//        protected const string BrushGradientReversed = "BrushGradientReversed";

        private int _GradientPercent;
        [Description("Gradient Percentage of Control"), Category("Gradient")]
        public int GradientPercent
        {
            get
            {
                return _GradientPercent;
            }
            set
            {
                if (value < 1 || value > 100)
                    throw new ArgumentOutOfRangeException("GradientPercent", "Must be between 1 and 100");
                if (_GradientType == GradientTypes.FullWidthGradient)
                    return;
                _GradientPercent = value;
                Invalidate();
            }
        }

        private GradientTypes _GradientType;
        [Description("Gradient Type"), Category("Gradient")]
        public GradientTypes GradientType
        {
            get
            {
                return _GradientType;
            }
            set
            {
                if (value == GradientTypes.SpecificWidthGradient)
                    _GradientPercent = 50;
                if (value == GradientTypes.FullWidthGradient)
                    _GradientPercent = 100;
                _GradientType = value;
                Invalidate();
            }
        }


        #endregion

        #region Hidding Properties
        [Browsable(false)]
        public override int RollBlockPercent
        {
            get
            {
                return base.RollBlockPercent;
            }
        }
        #endregion

        public enum GradientTypes
        {
            SpecificWidthGradient,
            FullWidthGradient
        }




    }
}
