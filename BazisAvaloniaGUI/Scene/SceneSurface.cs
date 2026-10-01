using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.OpenGL;
using Avalonia.OpenGL.Controls;
using Avalonia.Rendering;
using Avalonia.Threading;
using BazisGUI.Scene.Core;
using BazisGUI.Scene.Core.Capture;
using BazisGUI.Scene.Core.Input;
using BazisGUI.Scene.EventsArgs;
using BazisGUI.Scene.Interfaces;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using OpenTK.Graphics.OpenGL;
using OperationalController;
using OperationalController.ModelScenePresentator;

namespace BazisAvaloniaGUI;

/// <summary>
/// OpenGL-поверхность сцены: рендер, ввод (мышь/клавиатура) и выбор объектов.
/// Разметки нет — OpenGlControlBase рисуется кодом; контейнер/представление — SceneView.axaml.
/// </summary>
internal class SceneSurface : OpenGlControlBase, ICustomHitTest
{
    private readonly SceneProjectPresenter presenter = new();
    private readonly SceneSelection selection = new();
    private readonly HashSet<ISetInfo> changedSets = new(ReferenceEqualityComparer.Instance);
    private SceneController? controller;
    private ProjectController? project;
    private bool projectNeedsDisplay;
    private int width;
    private int height;
    private SceneMouseButton pressedButton;

    /// <summary>Имя GL-объекта с граничными рёбрами модели (кнопка «Контуры»).</summary>
    private const string ContoursVboName = "Boundary";

    /// <summary>Снимок экрана делается сразу после ближайшей отрисовки — из обработчика кнопки буфер ещё пуст.</summary>
    private bool captureRequested;

    public event EventHandler<Exception>? ProjectDisplayFailed;
    public event Action<int, bool>? SelectionApplied;

    /// <summary>Сцена получила проект — UI может перечитать его наборы.</summary>
    public event Action<ProjectController>? ProjectShown;

    public ObjType? SelectedObjectType { get; set; }

    public bool HideInsideSurfaces
    {
        get => project?.ModelView.HideInsideSurfaces ?? false;
        set
        {
            if (project != null)
                project.ModelView.HideInsideSurfaces = value;
        }
    }

    public SceneSurface()
    {
        Focusable = true;
    }

    /// <summary>Отображение базиса (три оси + сфера в начале координат).</summary>
    public bool DisplayBasis
    {
        get => controller?.DisplayBasis ?? false;
        set
        {
            if (controller == null)
                return;

            controller.DisplayBasis = value;
            RequestNextFrameRendering();
        }
    }

    /// <summary>Сообщение для строки состояния окна (снимок экрана и т.п.).</summary>
    public event Action<string>? MessageReported;

    /// <summary>Вписывает объекты модели в окно сцены.</summary>
    public void FitToScreen()
    {
        if (controller == null)
            return;

        controller.FitObjectsToScreen();
        RequestNextFrameRendering();
    }

    /// <summary>Задаёт режим отображения (стороны / рёбра / стороны+рёбра) для наборов поверхностей и элементов.</summary>
    public void SetViewMode(ViewMode mode)
    {
        if (controller == null || project == null)
            return;

        var modelView = project.ModelView;
        using (modelView.BeginUpdate())
        {
            foreach (var type in new[] { ObjType.Поверхность, ObjType.Элемент2D, ObjType.Элемент3D })
                foreach (var set in project.GetModelSetsInfo(type))
                    modelView.SetViewMode(set, mode);
        }

        RequestNextFrameRendering();
    }

    /// <summary>Показывает или скрывает контуры модели (граничные рёбра), как кнопка «Контуры» в WinForms.</summary>
    public void SetContoursVisible(bool visible)
    {
        if (controller == null || project == null)
            return;

        controller.DeleteVBObjects(ContoursVboName);
        if (visible)
        {
            var nodes = project.FindBoundaryEdges();
            var edges = project.CreateBoundaryEdges(nodes);
            var linePresenter = new PresentersCreator().CreateLineObjectsPresenter(edges.ToList(), System.Drawing.Color.DarkGray);
            linePresenter.Name = ContoursVboName;

            var vbo = presenter.CreateVbo(linePresenter, controller.VboController);
            if (vbo != null)
                controller.VboController.AddVbo(vbo);
        }

        RequestNextFrameRendering();
    }

    /// <summary>Просит снять текущий кадр в PNG: снимок делается сразу после ближайшей отрисовки.</summary>
    public void RequestScreenShot()
    {
        if (controller == null)
            return;

        captureRequested = true;
        RequestNextFrameRendering();
    }

    /// <summary>Делает поверхность OpenGL доступной для событий указателя.</summary>
    bool ICustomHitTest.HitTest(Point point) => new Rect(Bounds.Size).Contains(point);

    /// <summary>Передаёт загруженный проект в поток рендера для создания VBO.</summary>
    public void ShowProject(ProjectController project)
    {
        if (this.project != null)
            this.project.ModelView.Changed -= OnModelViewChanged;
        this.project = project;
        project.ModelView.Changed += OnModelViewChanged;
        changedSets.Clear();
        projectNeedsDisplay = true;
        RequestNextFrameRendering();
        ProjectShown?.Invoke(project);
    }

    /// <summary>
    /// Выравнивает камеру по координатной плоскости (XY/XZ/YZ) и запрашивает перерисовку.
    /// Масштаб сохраняется: SceneController.PlaneObjs берёт текущий ScaleFactor камеры.
    /// </summary>
    public void SetPlane(ViewPlane plane)
    {
        if (controller == null)
            return;

        controller.PlaneObjs(plane);
        RequestNextFrameRendering();
    }

    /// <summary>
    /// Задаёт ось вращения для протягивания мышью: X/Y/Z — только вокруг этой оси, XYZ — свободный поворот.
    /// Перерисовка не нужна: вид не меняется, режим влияет только на последующие движения мыши.
    /// </summary>
    public void SetRotationAxis(ViewAxis axis)
    {
        if (controller == null)
            return;

        controller.RotationAxis = axis;
    }

    /// <summary>
    /// Разовый поворот сцены на заданный угол вокруг оси (кнопки поворота на 90°) с перерисовкой.
    /// </summary>
    public void RotateBy(ViewAxis axis, float angle)
    {
        if (controller == null)
            return;

        controller.RotateObjs(axis, angle);
        RequestNextFrameRendering();
    }

    /// <summary>Ставит изменённые наборы в очередь обновления на следующем кадре OpenGL.</summary>
    private void OnModelViewChanged(object? sender, ModelViewChangedEventArgs e)
    {
        foreach (var set in e.GetChangedSets())
            changedSets.Add(set);
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

        if (captureRequested)
        {
            captureRequested = false;
            CaptureScreenShot();
        }
    }

    /// <summary>Читает готовый кадр и сохраняет его в PNG рядом с приложением.</summary>
    private void CaptureScreenShot()
    {
        if (controller == null)
            return;

        try
        {
            var png = controller.CaptureScreenshot(new GlFrameGrabber());
            var path = Path.Combine(AppContext.BaseDirectory, "screenShot.png");
            File.WriteAllBytes(path, png);
            Dispatcher.UIThread.Post(() => MessageReported?.Invoke($"Снимок экрана сохранён: {path}"));
        }
        catch (Exception error)
        {
            Dispatcher.UIThread.Post(() => ProjectDisplayFailed?.Invoke(this, error));
        }
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
