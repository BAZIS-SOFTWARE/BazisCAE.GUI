using BazisGUI.Scene.Core;
using BazisGUI.Scene.EventsArgs;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using OperationalController;

namespace BazisAvaloniaGUI;

internal class SceneSelection
{
    /// <summary>Применяет найденные на сцене объекты к выбору в представлении модели.</summary>
    public int Apply(IProjectController project, SceneController scene, ObjType? selectedType, SelectObjectsEventArgs selection)
    {
        var sourceSets = selectedType.HasValue
            ? project.GetModelSetsInfo(selectedType.Value)
            : project.GetAllModelSetsInfo();
        var sets = new List<ISetInfo>(sourceSets);
        var hits = new List<InfoObjectsEventArgs>();
        void CollectHit(object? sender, InfoObjectsEventArgs hit) => hits.Add(hit);

        scene.InfoRequested += CollectHit;
        try
        {
            if (selection.IsSorted)
                scene.SelectByRect(sets, selection.SelectionBox, selection.IsSelected, project.GetVisible);
            else
            {
                var box = selection.SelectionBox;
                var point = new Point2D((box.Left + box.Right) / 2, (box.Bottom + box.Top) / 2);
                scene.SelectByPoint(sets, point, selection.IsSelected, project.GetVisible);
            }
        }
        finally
        {
            scene.InfoRequested -= CollectHit;
        }

        var count = 0;
        using (project.BeginViewUpdate())
        {
            foreach (var hit in hits)
            {
                var set = sets.Find(item => item.Name == hit.ObjsName);
                if (set == null)
                    continue;

                var numbers = new List<int>(hit.GetObjectsIndexes());
                count += numbers.Count;
                if (selection.IsSelected)
                    project.Select(set.ObjType, numbers);
                else
                    project.Deselect(set.ObjType, numbers);
            }
        }
        return count;
    }

}
