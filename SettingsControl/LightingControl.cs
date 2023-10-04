using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI.SettingsControl
{
    public partial class LightingControl : UserControl
    {
        private Point ballPosition;
        private int ballRadius;
        private Rectangle ballBounds;
        private bool isPointInsideBall;
        private bool isMouseDownState;

        private Brush ballBrush;

        public LightingControl()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            var initX = panel1.Width / 2;
            var initY = panel1.Height / 2;
            ballPosition = new Point(initX, initY);
            ballRadius = 5;
            ballBounds.Width = 2 * ballRadius;
            ballBounds.Height = 2 * ballRadius;
            UpdateBounds(initX, initY);
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
                if (e.X - ballRadius > 0 && e.X + ballRadius < panel1.Width)
                    status = true;
                if (e.Y - ballRadius >= 0 && e.Y + ballRadius <= panel1.Height && status == true)
                {
                    ballPosition.X = e.X;
                    ballPosition.Y = e.Y;
                    UpdateBounds(e.X, e.Y);
                    panel1.Invalidate();
                    //SceneControl Set Lighting Vector component.X, component.Y
                    //Redraw scene control;
                }
            }
        }

        private void OnDown(object sender, MouseEventArgs e)
        {
            if (!isMouseDownState)
            {
                var xDif = e.X - ballPosition.X;
                var xPow = xDif * xDif;
                var yDif = e.Y - ballPosition.Y;
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
        }

        private void OnChange(object sender, EventArgs e)
        {
            label2.Text = (colorSlider1.Value * 0.1f).ToString();
        }

        private void OnPaint(object sender, PaintEventArgs e) => e.Graphics.FillEllipse(ballBrush, ballBounds);

        private void UpdateBounds(int x, int y)
        {
            ballBounds.X = x - ballRadius;
            ballBounds.Y = y - ballRadius;
        }
    }
}
