using System;
using System.Drawing;
using System.Windows.Forms;

namespace BazisGUI.SettingsControls
{
    public partial class LightingControl : UserControl
    {
        public Action<Point> SetBallPositionEvent;
        public Point BallPosition { get; set; } = new Point(0, 0);
        private int ballRadius = 5;
        private Rectangle ballBounds;
        private bool isPointInsideBall;
        private bool isMouseDownState;

        private Brush ballBrush;

        public LightingControl()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            ballBounds.Width = 2 * ballRadius;
            ballBounds.Height = 2 * ballRadius;

            ballBounds.X = panel.Width / 2 + BallPosition.X - ballRadius;
            ballBounds.Y = panel.Height / 2 - BallPosition.Y - ballRadius;

            isPointInsideBall = false;
            isMouseDownState = false;

            ballBrush = new SolidBrush(Color.Black);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }

        private void OnMove(object sender, MouseEventArgs e)
        {
            if (isPointInsideBall)
            {
                var status = false;
                if (e.X - ballRadius > 0 && e.X + ballRadius < panel.Width)
                    status = true;
                if (e.Y - ballRadius >= 0 && e.Y + ballRadius <= panel.Height && status == true)
                {
                    BallPosition = new Point(e.X - (Width / 2), -e.Y + (Height / 2));

                    ballBounds.X = e.X - ballRadius;
                    ballBounds.Y = e.Y - ballRadius;

                    panel.Invalidate();
                }
            }
        }

        private void OnDown(object sender, MouseEventArgs e)
        {
            if (!isMouseDownState)
            {
                var xDif = e.X - (Width / 2) - BallPosition.X;
                var xPow = xDif * xDif;
                var yDif = -e.Y + (Height / 2) - BallPosition.Y;
                var yPow = yDif * yDif;
                if (xPow + yPow <= ballRadius * ballRadius)
                    isPointInsideBall = true;
                isMouseDownState = true;
            }
        }

        private void OnUp(object sender, MouseEventArgs e)
        {
            isPointInsideBall = false;
            isMouseDownState = false;

            SetBallPositionEvent(BallPosition);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(ballBrush, ballBounds);
        }

        private void panel_MouseLeave(object sender, EventArgs e)
        {
            isPointInsideBall = false;
            isMouseDownState = false;
        }
    }
}
