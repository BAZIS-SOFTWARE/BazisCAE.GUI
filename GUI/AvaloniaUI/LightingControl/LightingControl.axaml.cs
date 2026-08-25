using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;

namespace BazisGUI.AvaloniaUI.LightingControl
{
    /// <summary>
    /// Контрол выбора положения источника света: на белом поле с рамкой рисуется
    /// чёрный шарик, который можно перетаскивать. Положение шарика задаётся
    /// относительно центра поля (ось Y инвертирована), как в WinForms-контроле
    /// <see cref="BazisGUI.SettingsControls.LightingControl"/>.
    /// </summary>
    /// <remarks>
    /// Отрисовка выполняется в <see cref="Render"/> — это прямой аналог события
    /// <c>Paint</c> в WinForms. Позиция шарика ограничивается пределами поля,
    /// поэтому шарик всегда виден.
    /// </remarks>
    public partial class LightingControl : UserControl
    {
        /// <summary>
        /// Радиус шарика в пикселях.
        /// </summary>
        private const double BallRadius = 6;

        private bool isPointInsideBall;
        private bool isMouseDown;

        /// <summary>
        /// Положение шарика относительно центра поля.
        /// </summary>
        public static readonly StyledProperty<Point> BallPositionProperty =
            AvaloniaProperty.Register<LightingControl, Point>(nameof(BallPosition));

        /// <summary>
        /// Событие фиксации положения шарика (поднимается при отпускании кнопки мыши).
        /// </summary>
        public event Action<Point> BallPositionCommitted;

        public LightingControl()
        {
            InitializeComponent();

            BallPositionProperty.Changed.AddClassHandler<LightingControl>(OnBallPositionChanged);

            // Перехватываем события указателя, чтобы шарик гарантированно реагировал на мышь.
            AddHandler(InputElement.PointerPressedEvent, OnPointerPressed, RoutingStrategies.Tunnel, true);
            AddHandler(InputElement.PointerMovedEvent, OnPointerMoved, RoutingStrategies.Tunnel, true);
            AddHandler(InputElement.PointerReleasedEvent, OnPointerReleased, RoutingStrategies.Tunnel, true);
            AddHandler(InputElement.PointerExitedEvent, OnPointerExited, RoutingStrategies.Tunnel, true);
        }

        /// <summary>
        /// Положение шарика относительно центра поля (ось Y направлена вверх).
        /// </summary>
        public Point BallPosition
        {
            get => GetValue(BallPositionProperty);
            set => SetValue(BallPositionProperty, value);
        }

        protected override Size MeasureOverride(Size availableSize)
            => new Size(230, 233);

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);
            InvalidateVisual();
        }

        protected override void OnSizeChanged(SizeChangedEventArgs e)
        {
            base.OnSizeChanged(e);
            InvalidateVisual();
        }

        private static void OnBallPositionChanged(LightingControl control, AvaloniaPropertyChangedEventArgs e)
            => control.InvalidateVisual();

        /// <summary>
        /// Отрисовка контрола (аналог события Paint в WinForms).
        /// </summary>
        public override void Render(DrawingContext context)
        {
            var w = Bounds.Width;
            var h = Bounds.Height;
            if (w <= 0 || h <= 0)
                return;

            // Фон поля.
            context.FillRectangle(Brushes.White, new Rect(0, 0, w, h));

            // Рамка, чтобы были видны границы поля.
            context.DrawRectangle(null, new Pen(Brushes.Gray, 1), new Rect(0, 0, w, h));

            // Позиция шарика, ограниченная пределами поля (чтобы он всегда был виден).
            var cx = Math.Clamp(BallPosition.X, -w / 2 + BallRadius, w / 2 - BallRadius);
            var cy = Math.Clamp(-BallPosition.Y, -h / 2 + BallRadius, h / 2 - BallRadius);
            var center = new Point(cx + w / 2, cy + h / 2);

            context.DrawEllipse(Brushes.Black, null, center, BallRadius, BallRadius);
        }

        private void OnPointerPressed(object sender, PointerPressedEventArgs e)
        {
            if (!e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
                return;

            var p = e.GetPosition(this);
            var xDif = p.X - Bounds.Width / 2 - BallPosition.X;
            var yDif = -p.Y + Bounds.Height / 2 - BallPosition.Y;
            isPointInsideBall = xDif * xDif + yDif * yDif <= BallRadius * BallRadius;
            isMouseDown = true;

            e.Pointer.Capture(this);
            e.Handled = true;
        }

        private void OnPointerMoved(object sender, PointerEventArgs e)
        {
            if (!isMouseDown || !isPointInsideBall)
                return;

            var p = e.GetPosition(this);
            var w = Bounds.Width;
            var h = Bounds.Height;

            if (p.X - BallRadius >= 0 && p.X + BallRadius <= w &&
                p.Y - BallRadius >= 0 && p.Y + BallRadius <= h)
            {
                BallPosition = new Point(p.X - w / 2, -p.Y + h / 2);
            }

            e.Handled = true;
        }

        private void OnPointerReleased(object sender, PointerReleasedEventArgs e)
        {
            isMouseDown = false;
            e.Pointer.Capture(null);
            BallPositionCommitted?.Invoke(BallPosition);
            e.Handled = true;
        }

        private void OnPointerExited(object sender, PointerEventArgs e)
        {
            isPointInsideBall = false;
            isMouseDown = false;
        }
    }
}
