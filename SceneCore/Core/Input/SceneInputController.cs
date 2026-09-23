using System;
using System.Drawing;
using BazisGUI.Scene.Core.Camera;
using BazisGUI.Scene.EventsArgs;
using BazisGUI.Scene.Interfaces;
using Geometry;

namespace BazisGUI.Scene.Core.Input
{
    /// <summary>
    /// Перенос BaseForm.GlControl_MouseMove/MouseDown/MouseUp/MouseWheel/KeyDown, без зависимости
    /// от System.Windows.Forms.MouseEventArgs/Keys — см. scene.avalonia.md, раздел 6.
    /// Выбор объектов (ScenePicker.SelectByPoint/SelectByRect) требует данных модели
    /// (IEnumerable&lt;ISetInfo&gt;), которых у Core нет — поэтому контроллер ввода только
    /// вычисляет прямоугольник выделения и сообщает о жесте через SelectionRequested;
    /// сам подбор объектов выполняет вызывающий код через SceneController.SelectByPoint/SelectByRect.
    /// </summary>
    public class SceneInputController
    {
        private readonly SceneCamera camera;
        private readonly RubberBandSelection rubberBand = new RubberBandSelection();

        private Point2D lastPosition;
        private bool moved;

        public Viewport Viewport { get; set; }
        public ViewAxis RotationAxis { get; set; } = ViewAxis.XYZ;
        public float RotationAngle { get; set; } = 2f;

        public event Action Invalidated;
        public event EventHandler<SelectObjectsEventArgs> SelectionRequested;
        public event Action<bool> RotationPointVisibilityChanged;
        public event Action FitToScreenRequested;

        public SceneInputController(SceneCamera camera)
        {
            this.camera = camera;
        }

        private Point2D ToCentered(Point2D p) => new Point2D(p._x - Viewport.Width / 2f, -p._y + Viewport.Height / 2f);

        public void OnPointerPressed(SceneMouseEventArgs args)
        {
            moved = false;
            lastPosition = args.Position;

            if (args.Button == SceneMouseButton.Middle)
                RotationPointVisibilityChanged?.Invoke(true);
            else if (args.Button == SceneMouseButton.Left)
                rubberBand.Begin(args.Position);
        }

        public void OnPointerMoved(SceneMouseEventArgs args)
        {
            var centered = ToCentered(args.Position);
            moved = true;

            if (args.Button == SceneMouseButton.Left && rubberBand.IsActive)
            {
                rubberBand.Update(args.Position);
            }
            else if (args.Button == SceneMouseButton.Right)
            {
                camera.Move(
                    new Point((int)centered._x, (int)centered._y),
                    new Point((int)ToCentered(lastPosition)._x, (int)ToCentered(lastPosition)._y),
                    camera.ScaleFactor);
            }
            else if (args.Button == SceneMouseButton.Middle)
            {
                var previous = ToCentered(lastPosition);
                const int moveCamZ = -5;
                var dx = (float)((centered._x - previous._x) * (2 * -moveCamZ) / Viewport.Width);
                var dy = (float)((centered._y - previous._y) * (2 * -moveCamZ) / Viewport.Height);
                camera.Rotate(dx, dy, RotationAxis, RotationAngle);
            }

            lastPosition = args.Position;
            Invalidated?.Invoke();
        }

        public void OnPointerReleased(SceneMouseEventArgs args)
        {
            if (args.Button == SceneMouseButton.Left)
            {
                var isSelected = (args.Modifiers & SceneModifierKeys.Shift) == 0;
                RectangleBox box;

                if (!moved)
                {
                    var p = ToCentered(rubberBand.Start);
                    box = new RectangleBox((int)p._x - 5, (int)p._x + 5, (int)p._y - 5, (int)p._y + 5);
                }
                else
                {
                    var start = ToCentered(rubberBand.Start);
                    var end = ToCentered(rubberBand.Current);
                    box = new RectangleBox((int)start._x, (int)end._x, (int)end._y, (int)start._y);
                }

                rubberBand.End();
                SelectionRequested?.Invoke(this, new SelectObjectsEventArgs(box, moved, isSelected));
            }
            else if (args.Button == SceneMouseButton.Middle)
            {
                RotationPointVisibilityChanged?.Invoke(false);
            }

            Invalidated?.Invoke();
        }

        public void OnWheelChanged(SceneMouseEventArgs args)
        {
            var steps = Math.Abs(args.Delta / 120);
            for (var i = 0; i < steps; i++)
                camera.Scale(args.Delta > 0 ? 1.1f : 0.9f);

            Invalidated?.Invoke();
        }

        public void OnKeyDown(SceneKeyEventArgs args)
        {
            if (args.Key == SceneKey.F)
                FitToScreenRequested?.Invoke();
        }
    }
}
