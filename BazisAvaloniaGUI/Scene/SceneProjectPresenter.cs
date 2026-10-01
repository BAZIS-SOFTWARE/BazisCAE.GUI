using BazisGUI.Scene.Core;
using BazisGUI.Scene.Interfaces;
using BazisGUI.Scene.VBO;
using Model.Interfaces.ObjectsCollections;
using OperationalController;

namespace BazisAvaloniaGUI;

internal class SceneProjectPresenter
{
    /// <summary>Создаёт GL-объекты для видимых наборов загруженного проекта.</summary>
    public void Display(ProjectController project, SceneController scene)
    {
        var vboController = scene.VboController;
        vboController.DeleteAllVBObjects();

        Refresh(project, scene, project.GetAllModelSetsInfo());
        scene.FitObjectsToScreen();
    }

    /// <summary>Перестраивает GL-объекты только для наборов с изменившимся представлением.</summary>
    public void Refresh(ProjectController project, SceneController scene, IEnumerable<ISetInfo> sets)
    {
        var vboController = scene.VboController;
        foreach (var set in sets)
        {
            vboController.DeleteVBObjects(set.Name);
            if (set.NumberOfObjects == 0)
                continue;

            var vbo = CreateVbo(project.CreateModelObjectsPresentor(set), vboController);
            if (vbo == null)
                continue;

            vboController.AddVbo(vbo);
        }
    }

    /// <summary>
    /// Создаёт GL-объект из презентера: разбор массивов и выбор типа объекта.
    /// Возвращает null, если у презентера нет вершин (рисовать нечего).
    /// </summary>
    public VBObject? CreateVbo(IObjsPresenter presenter, VBOController vboController)
    {
        var indexes = presenter.CreateIndexes();
        var pointers = presenter.CreatePointers(indexes.Item1);
        if (pointers.Length == 0)
            return null;

        var coordinates = presenter.CreateVertexes(indexes.Item2, "координаты");
        var colors = presenter.CreateVertexes(indexes.Item3, "цвет");
        var normals = presenter.CreateVertexes(indexes.Item2, "нормаль");
        var edges = presenter.CreateEdgeFlags(indexes.Item4);
        var name = presenter.Name;

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
            return vboController.CreateSurfaceVBObjects(pointers, coordinates, colors, normals, edges, name, separators, view);
        }

        if (presenter.PresenterType == PresenterType.Line)
            return vboController.CreateLineVBObjects(pointers, coordinates, colors, normals, edges, name);

        return vboController.CreatePointVBObjects(pointers, coordinates, colors, normals, name);
    }
}
