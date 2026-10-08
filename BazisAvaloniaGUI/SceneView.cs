using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.OpenGL;
using Avalonia.OpenGL.Controls;
using Avalonia.Rendering;
using Avalonia.Threading;
using BazisGUI.Scene.Core;
using BazisGUI.Scene.Core.Input;
using BazisGUI.Scene.EventsArgs;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using OpenTK.Graphics.OpenGL;
using OperationalController;

namespace BazisAvaloniaGUI;

internal class SceneView : OpenGlControlBase, ICustomHitTest
{
    private readonly SceneProjectPresenter presenter = new();
    private readonly SceneSelection selection = new();
    private readonly HashSet<ISetInfo> changedSets = new(ReferenceEqualityComparer.Instance);
    private SceneController? controller;
    private IProjectController? project;
    private bool projectNeedsDisplay;
    private int width;
    private int height;
    private SceneMouseButton pressedButton;

    public event EventHandler<Exception>? ProjectDisplayFailed;
    public event Action<int, bool>? SelectionApplied;

    public ObjType? SelectedObjectType { get; set; }

    public bool HideInsideSurfaces
    {
        get => project?.HideInsideSurfaces ?? false;
        set
        {
            if (project != null)
                project.SetHideInsideSurfaces(value);
        }
    }

    public SceneView()
    {
        Focusable = true;
    }

    /// <summary>Делает поверхность OpenGL доступной для событий указателя.</summary>
    bool ICustomHitTest.HitTest(Point point) => new Rect(Bounds.Size).Contains(point);

    /// <summary>Передаёт загруженный проект в поток рендера для создания VBO.</summary>
    public void ShowProject(IProjectController project)
    {
        if (this.project != null)
            this.project.Message -= OnProjectMessage;
        this.project = project;
        project.Message += OnProjectMessage;
        changedSets.Clear();
        projectNeedsDisplay = true;
        RequestNextFrameRendering();
    }

    /// <summary>Ставит изменённые наборы в очередь обновления на следующем кадре OpenGL.</summary>
    private void OnProjectMessage(object? sender, ProjectMessageEventArgs e)
    {
        if (!ReferenceEquals(sender, project))
            return;
        if (!Dispatcher.UIThread.CheckAccess())
        {
            Dispatcher.UIThread.Post(() => OnProjectMessage(sender, e));
            return;
        }

        foreach (var change in e.Changes)
        {
            if (change is ViewChange viewChange)
            {
                foreach (var set in viewChange.AffectedSets)
                    changedSets.Add(set);
            }
            else if (change is ProjectChange projectChange && projectChange.ChangeKind != ProjectChange.ProjectChangeKind.PropertyChanged
                || change is GeoChange or MeshChange or SetDelete or SetRename)
                projectNeedsDisplay = true;
        }
        RequestNextFrameRendering();
    }

    protected override void OnOpenGlInit(GlInterface gl)
    {
        GL.LoadBindings(new AvaloniaGlBindingsContext(gl));
        controller = new SceneController();
        controller.GetCamera().Width = 1;
        controller.GetCamera().Height = 1;
        controller.RenderRequested += RequestRendering;
        controller.SelectionChanged += OnSelectionChanged;
        controller.Initialization();
        projectNeedsDisplay = project != null;
    }

    protected override void OnOpenGlRender(GlInterface gl, int fb)
    {
        if (controller == null)
            return;

        var scaling = TopLevel.GetTopLevel(this)?.RenderScaling ?? 1;
        var nextWidth = Math.Max(1, (int)Math.Ceiling(Bounds.Width * scaling));
        var nextHeight = Math.Max(1, (int)Math.Ceiling(Bounds.Height * scaling));
        if (width != nextWidth || height != nextHeight)
        {
            width = nextWidth;
            height = nextHeight;
            controller.Resize(width, height);
        }

        if (projectNeedsDisplay && project != null)
        {
            projectNeedsDisplay = false;
            try
            {
                presenter.Display(project, controller);
                changedSets.Clear();
            }
            catch (Exception error)
            {
                Dispatcher.UIThread.Post(() => ProjectDisplayFailed?.Invoke(this, error));
            }
        }
        else if (changedSets.Count > 0 && project != null)
        {
            try
            {
                presenter.Refresh(project, controller, changedSets);
                changedSets.Clear();
            }
            catch (Exception error)
            {
                Dispatcher.UIThread.Post(() => ProjectDisplayFailed?.Invoke(this, error));
            }
        }

        controller.DisplayObjects(fb);
    }

    protected override void OnOpenGlDeinit(GlInterface gl)
    {
        if (controller == null)
            return;

        controller.RenderRequested -= RequestRendering;
        controller.SelectionChanged -= OnSelectionChanged;
        controller.VboController.DeleteAllVBObjects();
        controller.Dispose();
        controller = null;
    }

    protected override void OnOpenGlLost()
    {
        controller = null;
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        Focus();
        if (controller == null)
            return;

        var point = e.GetCurrentPoint(this);
        var args = CreateMouseArgs(e);
        args.Button = point.Properties.IsLeftButtonPressed ? SceneMouseButton.Left
            : point.Properties.IsMiddleButtonPressed ? SceneMouseButton.Middle
            : point.Properties.IsRightButtonPressed ? SceneMouseButton.Right
            : SceneMouseButton.None;
        pressedButton = args.Button;
        if (pressedButton != SceneMouseButton.None)
            e.Pointer.Capture(this);
        if (pressedButton == SceneMouseButton.Left && project != null)
        {
            var start = new System.Drawing.Point((int)args.Position._x, height - (int)args.Position._y);
            controller.SelectionRectangle.winScrenePosit = start;
            controller.SelectionRectangle.winScreneCoord = start;
        }
        controller.OnPointerPressed(args);
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);
        if (controller == null || pressedButton == SceneMouseButton.None)
            return;

        var args = CreateMouseArgs(e);
        args.Button = pressedButton;
        if (pressedButton == SceneMouseButton.Left && project != null)
        {
            controller.SelectionRectangle.winScreneCoord = new System.Drawing.Point((int)args.Position._x, height - (int)args.Position._y);
            RequestNextFrameRendering();
        }
        controller.OnPointerMoved(args);
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
        if (controller == null)
            return;

        var args = CreateMouseArgs(e);
        args.Button = e.InitialPressMouseButton switch
        {
            MouseButton.Left => SceneMouseButton.Left,
            MouseButton.Middle => SceneMouseButton.Middle,
            MouseButton.Right => SceneMouseButton.Right,
            _ => SceneMouseButton.None
        };
        controller.OnPointerReleased(args);
        if (args.Button == SceneMouseButton.Left)
        {
            controller.SelectionRectangle.Remove();
            RequestNextFrameRendering();
        }
        pressedButton = SceneMouseButton.None;
        if (e.Pointer.Captured == this)
            e.Pointer.Capture(null);
    }

    protected override void OnPointerCaptureLost(PointerCaptureLostEventArgs e)
    {
        base.OnPointerCaptureLost(e);
        if (pressedButton == SceneMouseButton.Middle)
            controller?.OnPointerReleased(new SceneMouseEventArgs { Button = SceneMouseButton.Middle });
        if (pressedButton == SceneMouseButton.Left && controller != null)
        {
            controller.SelectionRectangle.Remove();
            RequestNextFrameRendering();
        }
        pressedButton = SceneMouseButton.None;
    }

    protected override void OnPointerWheelChanged(PointerWheelEventArgs e)
    {
        base.OnPointerWheelChanged(e);
        if (controller == null)
            return;

        var args = CreateMouseArgs(e);
        args.Delta = (int)Math.Round(e.Delta.Y * 120);
        controller.OnWheelChanged(args);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        if (controller == null)
            return;

        var args = new SceneKeyEventArgs
        {
            Key = e.Key == Key.F ? SceneKey.F : SceneKey.None,
            Modifiers = CreateModifiers(e.KeyModifiers)
        };
        controller.OnKeyDown(args);
    }

    private void RequestRendering()
    {
        Dispatcher.UIThread.Post(RequestNextFrameRendering);
    }

    /// <summary>Применяет выбор кликом или рамкой к текущему проекту.</summary>
    private void OnSelectionChanged(object? sender, SelectObjectsEventArgs e)
    {
        if (project == null || controller == null)
            return;

        try
        {
            var count = selection.Apply(project, controller, SelectedObjectType, e);
            SelectionApplied?.Invoke(count, e.IsSelected);
        }
        catch (Exception error)
        {
            ProjectDisplayFailed?.Invoke(this, error);
        }
    }

    private SceneMouseEventArgs CreateMouseArgs(PointerEventArgs e)
    {
        var position = e.GetPosition(this);
        var scaling = TopLevel.GetTopLevel(this)?.RenderScaling ?? 1;
        return new SceneMouseEventArgs
        {
            Position = new Point2D(position.X * scaling, position.Y * scaling),
            Modifiers = CreateModifiers(e.KeyModifiers)
        };
    }

    private SceneModifierKeys CreateModifiers(KeyModifiers modifiers)
    {
        var result = SceneModifierKeys.None;
        if (modifiers.HasFlag(KeyModifiers.Shift)) result |= SceneModifierKeys.Shift;
        if (modifiers.HasFlag(KeyModifiers.Control)) result |= SceneModifierKeys.Control;
        if (modifiers.HasFlag(KeyModifiers.Alt)) result |= SceneModifierKeys.Alt;
        return result;
    }
}
