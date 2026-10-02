using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using System;
using System.Drawing;

namespace BazisAvaloniaGUI.SettingsControls
{
    /// <summary>
    /// Avalonia-аналог LightingControl: положение источника света задаётся перетаскиванием точки на панели.
    /// Координаты положения отсчитываются от центра панели, ось Y направлена вверх.
    /// </summary>
    internal sealed class LightingControl : UserControl
    {
        public Action<System.Drawing.Point> SetBallPositionEvent;
        public System.Drawing.Point BallPosition { get; set; }
        private int BallRadius { get; set; }
        private bool IsPointInsideBall { get; set; }
        private bool IsMouseDownState { get; set; }

        private IBrush BallBrush { get; set; }

        private readonly BallPanel panel;

        public LightingControl()
        {
            panel = new BallPanel(this);
            panel.PointerPressed += OnDown;
            panel.PointerMoved += OnMove;
            panel.PointerReleased += OnUp;
            panel.PointerExited += panel_MouseLeave;

            // tableLayoutPanel1: панель и пустая строка 20 px снизу.
            var layout = new Grid { RowDefinitions = new RowDefinitions("*,20") };
            layout.Children.Add(panel);
            Content = layout;

            Loaded += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            BallRadius = 5;
            BallPosition = new System.Drawing.Point();
            BallBrush = Brushes.Black;
            panel.InvalidateVisual();
        }

        private void OnMove(object sender, PointerEventArgs e)
        {
            var position = e.GetPosition(panel);
            if (IsPointInsideBall && IsMouseDownState)
            {
                var status = false;
                if (position.X - BallRadius >= 0 && position.X + BallRadius < panel.Bounds.Width)
                    status = true;
                if (position.Y - BallRadius >= 0 && position.Y + BallRadius < panel.Bounds.Height && status == true)
                {
                    BallPosition = new System.Drawing.Point((int)position.X - (int)(panel.Bounds.Width / 2), -(int)position.Y + (int)(panel.Bounds.Height / 2));
                    panel.InvalidateVisual();
                }
            }
        }

        private void OnDown(object sender, PointerPressedEventArgs e)
        {
            var position = e.GetPosition(panel);
            if (!IsMouseDownState)
            {
                // Как в WinForms: центр считается по размеру всего контрола, а не панели.
                var xDif = (int)position.X - (int)(Bounds.Width / 2) - BallPosition.X;
                var xPow = xDif * xDif;
                var yDif = -(int)position.Y + (int)(Bounds.Height / 2) - BallPosition.Y;
                var yPow = yDif * yDif;
                if (xPow + yPow <= BallRadius * BallRadius)
                    IsPointInsideBall = true;
                IsMouseDownState = true;
            }
        }

        private void OnUp(object sender, PointerReleasedEventArgs e)
        {
            IsPointInsideBall = false;
            IsMouseDownState = false;

            SetBallPositionEvent(BallPosition);
        }

        private void OnPaint(DrawingContext context)
        {
            if (BallBrush == null)
                return;

            var leftX = BallPosition.X + panel.Bounds.Width / 2 - BallRadius;
            var leftY = -BallPosition.Y + panel.Bounds.Height / 2 - BallRadius;
            var rect = new Rect(leftX, leftY, BallRadius * 2, BallRadius * 2);
            context.DrawEllipse(BallBrush, null, rect);
        }

        private void panel_MouseLeave(object sender, PointerEventArgs e)
        {
            IsPointInsideBall = false;
            IsMouseDownState = false;
        }

        /// <summary>Панель с отрисовкой точки (в WinForms — Panel с обработчиком Paint).</summary>
        private sealed class BallPanel(LightingControl owner) : Control
        {
            public override void Render(DrawingContext context)
            {
                context.FillRectangle(Brushes.Transparent, new Rect(Bounds.Size));
                owner.OnPaint(context);
            }
        }
    }
}
