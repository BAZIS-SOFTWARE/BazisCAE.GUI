using BazisGUI.Scene;
using BazisGUI.Scene.Core;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using OperationalController;

namespace BazisAvaloniaGUI.Scene;

internal class SceneProjectPresenter
{
    /// <summary>Создаёт GL-объекты для видимых наборов загруженного проекта.</summary>
    public void Display(ProjectController project, SceneController scene, bool fitToScreen = true)
    {
        var vboController = scene.VboController;
        vboController.DeleteAllVBObjects();

        Refresh(project, scene, project.GetAllModelSetsInfo());
        if (fitToScreen)
            scene.FitObjectsToScreen();
    }

    /// <summary>
    /// Перестраивает GL-объекты только для наборов с изменившимся представлением.
    /// Как BaseForm.RefreshModelSetBuffer: объект рисования (прозрачность, отсекатель) переходит к новому буферу.
    /// </summary>
    public void Refresh(ProjectController project, SceneController scene, IEnumerable<ISetInfo> sets)
    {
        var vboController = scene.VboController;
        foreach (var set in sets)
        {
            var drawingObject = vboController.FindVBObj(set.Name)?.ActiveDrawingObject;
            vboController.DeleteVBObjects(set.Name);
            if (set.NumberOfObjects == 0)
                continue;

            var vbo = CreateVbo(project.CreateModelObjectsPresentor(set), scene);
            if (vbo == null)
                continue;

            if (drawingObject != null)
                vbo.ActiveDrawingObject = drawingObject;
            else if (set.ObjType == ObjType.Элемент3D && scene.Advanced3DClipper.ClipMode != ClipMode.None)
                vbo.ActiveDrawingObject = scene.Advanced3DClipper;

            vboController.AddVbo(vbo);
        }
    }

    /// <summary>
    /// Обновляет цвета буферов наборов без пересборки геометрии — BaseForm.RecolorModelSetBuffer.
    /// Если буфера набора на сцене нет (например, вместо модели показано поле результатов), ничего не делает.
    /// </summary>
    public void Recolor(ProjectController project, SceneController scene, IEnumerable<ISetInfo> sets)
    {
        foreach (var set in sets)
            SetAttribute(scene, project.CreateModelObjectsPresentor(set), "цвет");
    }

    /// <summary>
    /// Перенос BaseForm.SetVBObjectAttribute: обновляет цвета ("цвет") или координаты буфера,
    /// созданного ранее по тому же представлению.
    /// </summary>
    public void SetAttribute(SceneController scene, IObjsPresenter presenter, string attribName)
    {
        var vbo = scene.VboController.FindVBObj(presenter.Name);
        if (vbo == null || presenter.Count() == 0)
            return;

        if (attribName == "цвет")
            vbo.PointsColors = presenter.CreateVertexes(vbo.ColorLength, "цвет");
        else
            vbo.PointsCoords = presenter.CreateVertexes(vbo.CoordLength, "координаты");
    }

    /// <summary>Перестройка кастомных GL-объектов (например, контуров или полей результатов) по существующему презентатору.</summary>
    public void Refresh(SceneController scene, IObjsPresenter presenter)
    {
        var vboController = scene.VboController;
        vboController.DeleteVBObjects(presenter.Name);
        if (presenter.Count() == 0)
            return;
        var vbo = CreateVbo(presenter, scene);
        if (vbo == null)
            return;

        vboController.AddVbo(vbo);
    }

    /// <summary>
    /// Создаёт GL-объект из презентера: разбор массивов и выбор типа объекта (BaseForm.TryCreateVBObject).
    /// Возвращает null, если у презентера нет вершин (рисовать нечего).
    /// </summary>
    public VBObject? CreateVbo(IObjsPresenter presenter, SceneController scene)
    {
        var vboController = scene.VboController;
        var indexes = presenter.CreateIndexes();
        var pointers = presenter.CreatePointers(indexes.Item1);
        if (pointers.Length == 0)
            return null;

        var coordinates = presenter.CreateVertexes(indexes.Item2, "координаты");
        var colors = presenter.CreateVertexes(indexes.Item3, "цвет");
        var normals = presenter.CreateVertexes(indexes.Item2, "нормаль");
        var edges = presenter.CreateEdgeFlags(indexes.Item4);
        var name = presenter.Name;

        VBObject vbo;
        if (presenter.PresenterType == PresenterType.Surface)
        {
            if (presenter is not ISurfaceObjsPresenter surface)
                throw new InvalidOperationException("Surface presenter is required.");

            var separators = surface.CreateSeparators();
            var view = presenter.ViewMode switch
            {
                ViewMode.Line => ObjView.Lines,
                ViewMode.LineSurface => ObjView.LinesSurface,
                _ => ObjView.Surface
            };
            vbo = vboController.CreateSurfaceVBObjects(pointers, coordinates, colors, normals, edges, name, separators, view);
        }
        else if (presenter.PresenterType == PresenterType.Line)
            vbo = vboController.CreateLineVBObjects(pointers, coordinates, colors, normals, edges, name);
        else
            vbo = vboController.CreatePointVBObjects(pointers, coordinates, colors, normals, name);

        var transparency = scene.AverageColorRenderer;
        vbo.ActiveDrawingObject = transparency != null && transparency.IsEnable ? transparency : null;
        return vbo;
    }
}
