using System;
using System.Drawing;
using System.ComponentModel;

namespace BasicControls.ProgressBarEx.Controls
{
    public class ProgressBarBoxed:ProgressBar
    {
        public ProgressBarBoxed():base()
        {
            _InnerGridType = InnerGridTypes.Full;
            ActiveBlockColor = Color.Red;
            NumberOfBlocks = 5;
        }


        #region Drawing
        private int _MaxBlockToDraw=-1;
        protected override void DrawBackground(Graphics g)
        {
            if (_iPercent == 0)
            {
                FillRectangle(g, ClientRectangle, xBrushes[BrushBackGround]);
            }
            for (int i = 0; i < _MaxBlockToDraw; i++)
            {
                FillRectangle(g, _BlockRects[i], xBrushes[BrushProgress]);
            }
            if(_MaxBlockToDraw<_NumberOfBlocks&&_MaxBlockToDraw>-1)
                FillRectangle(g, _BlockRects[_MaxBlockToDraw], xBrushes[BrushActiveBlock]);

            DrawInnerGrid(g);
        }

        protected void DrawInnerGrid(Graphics g)
        {
            if (_InnerGridType == InnerGridTypes.None)
                return;
            int MaxGrid = 0;
            if(_InnerGridType==InnerGridTypes.UntilActive)
                MaxGrid = _MaxBlockToDraw+1;
            if (_InnerGridType == InnerGridTypes.Full)
                MaxGrid = _NumberOfBlocks;
            if (MaxGrid > _NumberOfBlocks)
                MaxGrid = _NumberOfBlocks;
            for (int i = 0; i < MaxGrid; i++)
            {
                Point[] PathAround = Functions.Drawing.MyRectangle.PathAround(_BlockRects[i]);
                g.DrawLine(xPens[PenBorder], PathAround[1], PathAround[2]);
            }

        }


        #endregion

        #region Overrides
        [Description("Value Value"), Category("Progress")]
        public override int Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                int Temp = _MaxBlockToDraw;
                _TurnOffInvalidation = true;
                base.Value = value;
                ComputeMaxBlockToDraw();
                if (_MaxBlockToDraw == Temp)
                    _TurnOffInvalidation = true;
                Invalidate();
            }
        }
       #endregion

        #region Blocks
        private void ComputeMaxBlockToDraw()
        {
            if (_iPercent > 0)
                _MaxBlockToDraw = (int)Math.Floor(_fPercent / 100 * _NumberOfBlocks);
            else
                _MaxBlockToDraw = -1;
            //if (_MaxBlockToDraw > _NumberOfBlocks-1)
            //    _MaxBlockToDraw = _NumberOfBlocks-1;
        }
        protected const string BrushActiveBlock = "BrushActiveBlock";
        private InnerGridTypes _InnerGridType;

        [Description("Inner Grid Type"), Category("Blocks")]
        public InnerGridTypes InnerGridType
        {
            get { return _InnerGridType; }
            set 
            { 
                _InnerGridType = value;
                Invalidate();
            }
        }



        private Color _ActiveBlockColor;
        [Description("Active Block Color"), Category("ProgressApearance")]
        public Color ActiveBlockColor
        {
            get
            {
                return _ActiveBlockColor;
            }
            set
            {
                xBrushes[BrushActiveBlock] = new SolidBrush(value);
                _ActiveBlockColor = value;
                Invalidate();
            }
        }
        private int _NumberOfBlocks;
        [Description("Number of Blocks"),Category("Blocks")]
        public int NumberOfBlocks
        {
            get 
            { 
                return _NumberOfBlocks; 
            }
            set 
            {
                if (value < 2)
                    throw new ArgumentOutOfRangeException("NumberOfBlocks", "Value must greater than 1");
                _NumberOfBlocks = value;
                ComputeMaxBlockToDraw();
                PrepareBlocks();
                Invalidate();
            }
        }
        
        protected Rectangle[] _BlockRects = null;

        protected void PrepareBlocks()
        {
            _BlockRects = Functions.Drawing.MyRectangle.SplitInParts(ClientRectangle, _NumberOfBlocks, Functions.Drawing.MyRectangle.SplitType.Horizontal);
        }
        public Rectangle[] GetBlocks()
        {
            return _BlockRects;
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            PrepareBlocks();            
            base.OnSizeChanged(e);
        }
        #endregion

        #region Hidding Properties
        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
        }
        [Browsable(false)]
        public override TextAlignmentTypes  TextAlign
        {
            get 
	        { 
		         return base.TextAlign;
	        }
        }
        [Browsable(false)]
        public override TextColorTypes TextColorType
        {
            get
            {
                return base.TextColorType;
            }
        }

        [Browsable(false)]
        public override bool DisplayProgress
        {
            get
            {
                return base.DisplayProgress;
            }
        }

        [Browsable(false)]
        public override int RollBlockPercent
        {
            get
            {
                return base.RollBlockPercent;
            }
        }
        [Browsable(false)]
        public override RollingTypes RollingType
        {
            get
            {
                return base.RollingType;
            }
        }
        [Browsable(false)]
        public override int RollTimer
        {
            get
            {
                return base.RollTimer;
            }
        }

        #endregion


        public enum InnerGridTypes { None, UntilActive, Full }
    }

}
