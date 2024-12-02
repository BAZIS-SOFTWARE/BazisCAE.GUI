using System;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using MyComponents.Objects.Drawing;

internal class ResourceFinder
{

}
namespace BasicControls.ProgressBarEx.Controls
{
    //]
    //[ToolboxItem("gfdsgdf"), ToolboxBitmap(typeof(ProgressBar), "System.Windows.Forms.ProgressBar.bmp")]
    [ToolboxBitmap(typeof(ResourceFinder), "System.Windows.Forms.ProgressBar.bmp")]
    public class ProgressBar : System.Windows.Forms.Control
    {
        public ProgressBar()
        {
            _Minimum = 0;
            _Maximum = 100;
            _Step = 5;
            _TurnOffInvalidation = false;
            _DisplayProgress = false;
            _BorderType = BorderTypes.Single;
            _TextAlign=TextAlignmentTypes.Center;
            _TextColorType=TextColorTypes.Automatic;
            _RollBlockPercent = 20;
            _RollingType = RollingTypes.None;


            _TurnOffInvalidation = true;
            ColorProgress = Color.Blue;
            _TurnOffInvalidation = true;
            BorderColor = Color.Black;
            _TurnOffInvalidation = true;
            BackColor = Color.White;
            _TurnOffInvalidation = true;
            ForeColor = Color.White;
            Value = 50;
            Size = new Size(100, 20);
            RollTimer = 200;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                xBrushes.DisposeAll();
                xPens.DisposeAll();
            }
            base.Dispose(disposing);
        }


        #region Drawing

        protected BrushTable xBrushes = new BrushTable();
        protected PenTable xPens = new PenTable();
        protected Rectangle[] Prepare2Parts()
        {
            return Functions.Drawing.MyRectangle.SplitByPercent(ClientRectangle, new int[] { _iPercent, 100-_iPercent }, Functions.Drawing.MyRectangle.SplitType.Horizontal);
        }
        protected Rectangle[] Prepare3Parts()
        {
            Rectangle xRec = ClientRectangle;
            int MiddleWidth = Functions.Math.MyMaths.Percent(xRec.Width, _RollBlockPercent);
            xRec.Inflate(MiddleWidth, 0);
            int Left = Functions.Math.MyMaths.Percent(ClientRectangle.Width+MiddleWidth, _iPercent);
            int Right = xRec.Width - -MiddleWidth-Left;
            return Functions.Drawing.MyRectangle.SplitByPixels(xRec, new int[] { Left, MiddleWidth, Right }, Functions.Drawing.MyRectangle.SplitType.Horizontal);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            if (_RollingType == RollingTypes.None)
                DrawBackground(g);
            else
                DrawBackgroundRolling(g);
            if (_RollingType == RollingTypes.None)
                 DrawText(g);
            DrawBorder(g);
            g.Dispose();

        }
        protected virtual void DrawBackgroundRolling(Graphics g)
        {
            if (_iPercent == 0)
            {
                FillRectangle(g, ClientRectangle, xBrushes[BrushBackGround]);
            }
            Rectangle[] xRecs = Prepare3Parts();
            FillRectangle(g, xRecs[1], xBrushes[BrushProgress]);

        }
        protected virtual void DrawBackground(Graphics g)
        {
            if (_iPercent == 0)
            {
                FillRectangle(g, ClientRectangle, xBrushes[BrushBackGround]);
                //return;
            }
            Rectangle[] xRecs = null;
            xRecs = Prepare2Parts();
            Rectangle xRectLeft = xRecs[0];
            Rectangle xRectRight = xRecs[1];
            FillRectangle(g, xRectLeft, xBrushes[BrushProgress]);
            //BrushAndFill(g, xRectLeft, ColorProgress);
        }

        protected void DrawText(Graphics g)
        {
            if (!_DisplayProgress||_RollingType!=RollingTypes.None)
                return;
            string sProgress = _iPercent.ToString() + "%";
            StringFormat xFormat = new StringFormat();
            xFormat.LineAlignment = StringAlignment.Center;
            xFormat.Alignment = StringAlignment.Center;
            Rectangle TextRect = ClientRectangle;
            Color TextColor = ForeColor;
            Rectangle[] xRecs = Prepare2Parts();
            switch (_TextAlign)
            {
                case TextAlignmentTypes.Start:
                    TextRect = xRecs[0];
                    TextColor = Functions.Drawing.MyColor.GetBestContrast(_ColorProgress);
                    break;
                case TextAlignmentTypes.Center:
                    if(_iPercent>50)
                        TextColor = Functions.Drawing.MyColor.GetBestContrast(_ColorProgress);
                    else
                        TextColor = Functions.Drawing.MyColor.GetBestContrast(BackColor);
                    TextRect = ClientRectangle;
                    break;
                case TextAlignmentTypes.End:
                    TextRect = xRecs[1];
                    TextColor = Functions.Drawing.MyColor.GetBestContrast(BackColor);
                    break;
            }
            if (_TextColorType == TextColorTypes.Specific)
                TextColor = ForeColor;
            if(Functions.Drawing.MySize.Compare(g.MeasureString(sProgress,Font).ToSize(),TextRect.Size)==Functions.Drawing.MySize.CompareOutputTypes.Smaller)
                g.DrawString(sProgress, Font, new SolidBrush(TextColor), TextRect, xFormat);
        }
        private void DrawBorder(Graphics g)
        {
            switch (_BorderType)
            {
                case BorderTypes.None:
                    break;
                case BorderTypes.Single:
                    g.DrawLines(xPens[PenBorder],Functions.Drawing.MyRectangle.PathAround(ClientRectangle));
                    break;
            }
        }
        protected void FillRectangle(Graphics g, Rectangle xRec, Brush xBrush)
        {
            if (xRec.Width == 0)
                return;
            if (xBrush == null)
                return;
            g.FillRectangle(xBrush, xRec);
        }
        #endregion


        #region Values
        private int _Minimum;
        [Description("Minimum Value"), Category("Progress")] 
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value >= _Maximum)
                    throw new ArgumentOutOfRangeException("Minimum","Cannot be more than Maximum");
                _Minimum = value;
                Invalidate();
            }
        }
        private int _Maximum;
        [Description("Maximum Value"), Category("Progress")]
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value <= _Minimum)
                    throw new ArgumentOutOfRangeException("Maximum", "Cannot be less than Minimum");
                _Maximum = value;
                Invalidate();
            }
        }
        private int _Step;
        [Description("Step Value"), Category("Progress")]
        public int Step
        {
            get
            {
                return _Step;
            }
            set
            {
                _Step = value;
                Invalidate();
            }
        }
        protected bool _TurnOffInvalidation;
        protected new void Invalidate()
        {
            if (!_TurnOffInvalidation)
                base.Invalidate();
            _TurnOffInvalidation = false;
        }

        private int _Value;
        [Description("Value Value"), Category("Progress")]
        public virtual int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                int Temp = _iPercent;
                if (value < _Minimum || value>_Maximum)
                    throw new ArgumentOutOfRangeException("Value", "Must be between Minimum and Maximum");
                _Value = value;
                float Range = _Maximum - _Minimum;
                _fPercent = 100*(((float)_Value) / Range);
                _iPercent = (int)Math.Ceiling(_fPercent);
                if (_iPercent == Temp)
                    _TurnOffInvalidation = true;
                Invalidate();
            }
        }
        /// <summary>
        /// Performs Value Calculation based on Minimum,Maximum and Step
        /// </summary>
        public void PerformStep()
        {
            if (_Value + _Step <= _Maximum && _Value + _Step >= _Minimum)
            {
                Value += _Step;
                return;
            }
            if (_RollingType == RollingTypes.None)
                return;
            if (_RollingType == RollingTypes.Bouncing)
            {
                _Step = -Step;
                PerformStep();
                return;
            }
            if (_RollingType == RollingTypes.EdgeToEdge)
            {
                if (_Value + _Step > _Maximum)
                    Value += _Step - (_Maximum - _Minimum);
            }
        }

        protected int _iPercent = 0;
        protected float _fPercent = 0;



        #endregion

        #region ProgressApearance
        [Description("Back Color"), Category("ProgressApearance")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                xBrushes[BrushBackGround] = new SolidBrush(value);
                base.BackColor = value;
            }
        }
        [Description("Text Color"), Category("ProgressApearance")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                xBrushes[BrushText] = new SolidBrush(value);
                base.ForeColor = value;
            }
        }
        private bool _DisplayProgress;
        [Description("Display Progress Percentage"), Category("ProgressApearance")]
        public virtual bool DisplayProgress
        {
            get
            {
                return _DisplayProgress;
            }
            set
            {
                _DisplayProgress = value;
                Invalidate();
            }
        }

        protected const string BrushProgress = "BrushProgress";
        protected const string BrushBackGround = "BrushBackGround";
        protected const string BrushText = "BrushText";
        protected const string PenBorder = "PenBorder";

        protected Color _ColorProgress;
        [Description("Fill Color Start"), Category("ProgressApearance")]
        public Color ColorProgress
        {
            get 
            { 
                return _ColorProgress; 
            }
            set 
            { 
                _ColorProgress = value;
                xBrushes[BrushProgress] = new SolidBrush(_ColorProgress);
                Invalidate();
            }
        }

        private TextColorTypes _TextColorType;
        [Description("Percent Text Color Type"), Category("ProgressApearance")]
        public virtual TextColorTypes TextColorType
        {
            get 
            { 
                return _TextColorType; 
            }
            set 
            { 
                _TextColorType = value;
                Invalidate();
            }
        }
        private TextAlignmentTypes _TextAlign;
        [Description("Percent Text Align"), Category("ProgressApearance")]
        public virtual TextAlignmentTypes TextAlign
        {
            get 
            {
                return _TextAlign; 
            }
            set
            { 
                _TextAlign = value;
                Invalidate();
            }
        }
        private BorderTypes _BorderType;
        [Description("Border Type"), Category("ProgressApearance")]
        public BorderTypes BorderType
        {
            get
            {
                return _BorderType;
            }
            set
            {
                _BorderType = value;
                Invalidate();
            }
        }
        private Color _BorderColor;
        [Description("Border Color"), Category("ProgressApearance")]
        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                xPens[PenBorder] = new Pen(value, 1);
                _BorderColor = value;
                Invalidate();
            }
        }


        #endregion


        #region Rolling
        /*
        private Bitmap[] _RollImage = new Bitmap[100];
        private void PrepareRollImages()
        {
            int OriginalPercent=_iPercent;
            for(int i=0;i<100;i++)
            {
                if (_RollImage[i] == null)
                    _RollImage = new Bitmap(10, 10);
                Graphics g=Graphics.FromImage(_RollImage[i]);
                BrushAndFill(g, _RollImage[i].GetBounds(GraphicsUnit.Pixel));
                _iPercent=i;
                Rectangle[] xRecs = Prepare4Parts();
                if (_ProgressBarType == ProgressBarTypes.Simple)
                {
                    BrushAndFill(g, xRecs[1], _ColorStart);
                    BrushAndFill(g, xRecs[2], _ColorStart);
                }
                if (_ProgressBarType == ProgressBarTypes.SpecificWidthGradient || _ProgressBarType == ProgressBarTypes.FullWidthGradient)
                {
                    xRecs[1].Width++;
                    BrushAndFill(g, xRecs[2], _ColorStart, _ColorEnd);
                    BrushAndFill(g, xRecs[1], _ColorEnd, _ColorStart);
                }
                g.Dispose();
            }
        }
        */
        private int _RollBlockPercent;
        [Description("Middle Percentage of Control"), Category("Rolling")]
        public virtual int RollBlockPercent
        {
            get
            {
                return _RollBlockPercent;
            }
            set
            {
                if (value < 10 || value > 90)
                    throw new ArgumentOutOfRangeException("RollBlockPercent", "Must be between 10 and 90");
                _RollBlockPercent = value;
                Invalidate();
            }
        }
        private RollingTypes _RollingType;
        [Description("Rolling Type"), Category("Rolling")]
        public virtual RollingTypes RollingType
        {
            get
            {
                return _RollingType;
            }
            set
            {
                _RollingType = value;
                if (value == RollingTypes.None)
                {
                    RollStop();
                    Step = Math.Abs(Step);
                }
                else
                {
                    //throw new ArgumentException("Not Supported");
                    _Minimum = 0;
                    _Maximum = 100;
                    Value = 0;
                    //_RollImage.
                }
                Invalidate();
            }
        }
        private System.Windows.Forms.Timer _RollTimer = new System.Windows.Forms.Timer();
        [Description("Rolling Interval"), Category("Rolling")]
        public virtual int RollTimer
        {
            get
            {
                return _RollTimer.Interval;
            }
            set
            {
                _RollTimer.Interval = value;
            }
        }
        public void RollStart()
        {
            _RollTimer.Start();
        }
        public void RollStop()
        {
            _RollTimer.Stop();
        }
        private void _RollTimer_Tick(object sender, EventArgs e)
        {
            if(_Value>=_Maximum)
                if(_RollingType==RollingTypes.EdgeToEdge)
                    _Value=_Minimum;
                else
                    Step=-Step;
            PerformStep();
        }
        #endregion
    }


    public enum TextColorTypes
    {
        Specific,
        Automatic
    }

    public enum TextAlignmentTypes
    {
        Start,
        Center,
        End
    }
    public enum BorderTypes
    {
        None,
        Single
    }

    public enum RollingTypes
    { None,EdgeToEdge,Bouncing}
}
