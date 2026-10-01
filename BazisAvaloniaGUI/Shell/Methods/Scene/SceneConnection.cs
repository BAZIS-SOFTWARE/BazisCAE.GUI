using BazisAvaloniaGUI.Scene;
using BazisAvaloniaGUI.Utilities;
using Geometry;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using OperationalController;
using System;
using System.Drawing;
using System.Linq;

namespace BazisAvaloniaGUI.Shell
{
    public enum SelectionType { Select, Objects, Figures, Points, Curves, Surfaces, Volumes, Nodes, Elements, Elements1D, Elements2D, Elements3D }

    /// <summary>
    /// Точки подключения сцены. Отображение, буферы, выбор объектов и кнопки сцены реализует SceneView;
    /// здесь сохранены имена методов BaseForm, через которые прикладная логика обращается к сцене,
    /// и они переадресованы в публичный API SceneView.
    /// </summary>
    internal partial class MainWindow
    {
        private SceneBuffers sceneBuffers;

        /// <summary>Аналог BaseForm.VBOController: операции с буферами отдельных наборов.</summary>
        private SceneBuffers VBOController => sceneBuffers ??= new SceneBuffers(scene);

        internal sealed class SceneBuffers(SceneView scene)
        {
            public void DeleteVBObjects(string objsName) => scene.RefreshProject();

            public void DeleteAllVBObjects() => scene.RefreshProject();

            // В BaseForm сюда передаётся VBObject, созданный CreateVBObject; создание буферов — часть сцены,
            // поэтому передаётся представление (presenter). Представления вне модели (например, "transPoints")
            // SceneView пока не показывает.
            public void AddVbo(IObjsPresenter presenter) => scene.RefreshProject();
        }

        /// <summary>В BaseForm создаёт VBObject; в Avalonia буферы создаёт сцена, поэтому возвращается представление.</summary>
        public IObjsPresenter CreateVBObject(IObjsPresenter presenter) => presenter;

        IModelView subscribedModelView;

        /// <summary>Передаёт проект сцене (в BaseForm — подписка на ModelView.Changed для обновления буферов).</summary>
        private void SubscribeToModelView()
        {
            var modelView = project?.ModelView;
            if (ReferenceEquals(subscribedModelView, modelView))
                return;

            subscribedModelView = modelView;
            // В BaseForm здесь ApplyModelViewSettings(): цвет выделения и ModelView.Transparency из settingsConfig.
            // Avalonia смешивает кадр OpenGL с окном по альфа-каналу (GLControl его игнорирует), поэтому
            // TransparencyValue = 0 делает грани невидимыми. Прозрачность передаётся сцене вместе с остальными
            // настройками отображения (см. SetGeneralSettings), здесь — только цвет выделения.
            ApplySelectionColor();
            if (project != null)
                scene.ShowProject(project);
        }

        public void CreateVBObjects(string objects) => scene.RefreshProject();

        public void CreateVBObjsByObjsType(ObjType objType) => scene.RefreshProject();

        public void DeleteVBObjects(string objects) => scene.RefreshProject();

        public void DeleteVBObjsByObjsType(ObjType objType) => scene.RefreshProject();

        private void RefreshModelSetBuffer(ISetInfo setInfo) => scene.RefreshProject();

        public void SetVBObjectAttribute(IObjsPresenter presenter, string attribName) => scene.RefreshProject();

        public void ClearAllDataOnScene()
        {
            DisplayGeometryObjectEvent = null;
            DisplayText2DEvent = null;
            DisplayText3DEvent = null;
        }

        // SceneView сам запрашивает кадр при изменении ModelView и после RefreshProject/ShowProject.
        public void RequestRedraw()
        {
        }

        // Отдельного метода вписывания у SceneView пока нет: ShowProject перестраивает буферы и вписывает модель в экран.
        public void FitObjectsToScreen()
        {
            if (project != null)
                scene.ShowProject(project);
        }

        // Вывод текста и вспомогательной геометрии на сцену — реализация сцены (в BaseForm — GL-события).
        Action DisplayGeometryObjectEvent { get; set; }
        Action DisplayText3DEvent { get; set; }
        Action DisplayText2DEvent { get; set; }

        public void DisplayText3D(string str, Color color, Point3D coord)
        {
        }

        public void DisplayText2D(string str, Color color, Point2D coord)
        {
        }

        /// <summary>Тип объектов для выбора на сцене (в BaseForm хранится в кнопке btnSelect).</summary>
        public SelectionType SelectedObjects
        {
            get => scene.SelectedObjectType.HasValue
                ? Converters.ConvertObjTypeToSelectionType(scene.SelectedObjectType.Value)
                : SelectionType.Objects;
            set
            {
                scene.SelectedObjectType = Converters.TryConvertSelectionTypeToObjType(value, out var objType) ? objType : null;
                SetBackColorToAllObjects();
            }
        }

        // Кнопки выбора типа объектов (btnSelect и objButtons) — часть сцены.
        public void PresentModelObjectsForSelection()
        {
        }

        internal void SetBackColorToAllObjects()
        {
            if (project != null)
                project.ModelView.ClearSelection();
        }

        /// <summary>
        /// Реакция оболочки на выбор, выполненный сценой: та часть SelectByPoint/SelectByRect из BaseForm,
        /// которая выводит сообщение в консоль и свойства объекта в панель.
        /// </summary>
        private void scene_SelectionApplied(int count, bool isSelected)
        {
            try
            {
                var selected = project?.ModelView.GetSelection().Take(2).ToList();
                if (count == 1 && selected?.Count == 1)
                {
                    var setInfo = project.GetModelSetInfo(selected[0].ObjType, selected[0].Number);
                    console.PrintInfo($"{Resources.SelectByPoint_ObjectSelected_Message} : {Localization.Localization.GetSelectionTypeLocalization(Converters.ConvertObjTypeToSelectionType(selected[0].ObjType))} {selected[0].Number}", Color.Black);
                    CreateObjectProperties(setInfo, selected[0].Number);
                }
                else
                {
                    var objStr = Declination(count);
                    if (isSelected)
                        console.PrintInfo($"{Resources.SelectByRect_Selected_Message} {count} {objStr}", Color.Black);
                    else
                        console.PrintInfo($"{Resources.SelectByRect_Hidden_Message} {count} {objStr}", Color.Black);
                }
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
        }
    }
}
