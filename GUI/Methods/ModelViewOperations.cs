using BazisGUI.Scene;
using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using OperationalController;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        bool projectPresentationQueued;
        bool projectLoadedNotificationQueued;
        volatile bool suppressProjectMessages;

        const ModelViewChange RebuildChanges = ModelViewChange.Visibility | ModelViewChange.InsideSurfaces | ModelViewChange.ViewMode;
        const ModelViewChange ColorChanges = ModelViewChange.Selection | ModelViewChange.SetColor | ModelViewChange.ObjectColor | ModelViewChange.SelectionColor | ModelViewChange.Transparency;

        /// <summary>
        /// Обновляет буферы наборов, затронутых изменением представления, и запрашивает кадр.
        /// Событие само перечисляет затронутые наборы, поэтому обходить всю модель не нужно.
        /// </summary>
        private void Project_Message(object sender, ProjectMessageEventArgs e)
        {
            if (IsDisposed || suppressProjectMessages || !ReferenceEquals(sender, project))
                return;

            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Project_Message(sender, e)));
                return;
            }

            if (e.Change is ViewChange viewChange)
            {
                foreach (var setInfo in viewChange.AffectedSets)
                {
                    var kind = viewChange.GetChangeKind(setInfo);
                    if ((kind & RebuildChanges) != 0)
                        RefreshModelSetBuffer(setInfo);
                    else if ((kind & ColorChanges) != 0)
                        RecolorModelSetBuffer(setInfo);
                }
                RequestRedraw();
                return;
            }

            if (e.Change is ProjectChange projectChange && projectChange.ChangeKind == ProjectChangeKind.PropertyChanged)
            {
                if (projectChange.Property == ProjectProperty.Name && !string.IsNullOrWhiteSpace(lblStatus.Text))
                {
                    var folder = System.IO.Path.GetDirectoryName(lblStatus.Text);
                    lblStatus.Text = System.IO.Path.Combine(folder ?? string.Empty, project.Name);
                }
                else if (projectChange.Property == ProjectProperty.FilePath)
                    lblStatus.Text = project.FilePath ?? string.Empty;
                else if (projectChange.Property == ProjectProperty.MaterialsDB || projectChange.Property == ProjectProperty.FunctionsDB)
                    OnProjectLoaded?.Invoke();
                else if (projectChange.Property == ProjectProperty.TaskKind || projectChange.Property == ProjectProperty.TaskType)
                    PresentCondDataOnTree();
                return;
            }

            if (e.Change is CondChange)
            {
                PresentCondDataOnTree();
                return;
            }

            if (e.Change is MeshChange meshChange && meshChange.DataKind == MeshDataKind.Group)
            {
                PresentGroupDataOnTree();
                PresentCondDataOnTree();
                return;
            }

            if (e.Change is ProjectChange)
                projectLoadedNotificationQueued = true;
            if (e.Change is ProjectChange || e.Change is GeoChange || e.Change is MeshChange)
                QueueProjectPresentation();
        }

        /// <summary>
        /// Объединяет несколько изменений данных в одно обновление сцены и навигатора.
        /// </summary>
        private void QueueProjectPresentation()
        {
            if (projectPresentationQueued)
                return;
            projectPresentationQueued = true;
            BeginInvoke(new Action(() =>
            {
                projectPresentationQueued = false;
                if (IsDisposed || suppressProjectMessages)
                {
                    projectLoadedNotificationQueued = false;
                    return;
                }
                ClearAllDataOnScene();
                if (project.HasProject)
                    PresentProject();
                if (projectLoadedNotificationQueued)
                {
                    projectLoadedNotificationQueued = false;
                    OnProjectLoaded?.Invoke();
                }
                RequestRedraw();
            }));
        }

        /// <summary>
        /// Пересоздаёт буфер заданного набора с учётом состояния представления.
        /// </summary>
        private void RefreshModelSetBuffer(ISetInfo setInfo)
        {
            var oldBuffer = VBOController.FindVBObj(setInfo.Name);
            var drawingObject = oldBuffer?.ActiveDrawingObject;
            VBOController.DeleteVBObjects(setInfo.Name);
            if (setInfo.NumberOfObjects == 0)
                return;

            var presenter = project.CreateModelObjectsPresentor(setInfo);
            if (TryCreateVBObject(presenter, out var vbo))
            {
                if (drawingObject != null)
                    vbo.ActiveDrawingObject = drawingObject;
                else if (setInfo.ObjType == ObjType.Элемент3D && advanced3DClipper.ClipMode != ClipMode.None)
                    vbo.ActiveDrawingObject = advanced3DClipper;
                VBOController.AddVbo(vbo);
            }
        }

        /// <summary>
        /// Обновляет цвета буфера набора без пересборки геометрии.
        /// </summary>
        private void RecolorModelSetBuffer(ISetInfo setInfo)
        {
            var presenter = project.CreateModelObjectsPresentor(setInfo);
            SetVBObjectAttribute(presenter, "цвет");
        }

        /// <summary>
        /// Возвращает признак выделения объекта в текущем представлении.
        /// </summary>
        private bool IsSelected(IModelObject modelObject)
        {
            return project.IsSelected(modelObject.ObjType, modelObject.Number);
        }

        /// <summary>
        /// Возвращает видимые объекты заданного набора.
        /// </summary>
        private IEnumerable<int> GetVisibleNumbers(ISetInfo setInfo)
        {
            foreach (var number in setInfo.GetNumbers())
                if (project.GetVisible(setInfo.ObjType, number))
                    yield return number;
        }

        /// <summary>
        /// Применяет цвет выделения из настроек к текущему представлению.
        /// </summary>
        private void ApplySelectionColor()
        {
            if (project != null)
                project.SetSelectionColor(settingsConfig.SelectObjectColor);
        }

        /// <summary>
        /// Применяет настройки цвета выделения и прозрачности к текущему представлению.
        /// </summary>
        private void ApplyModelViewSettings()
        {
            if (project == null)
                return;

            project.SetSelectionColor(settingsConfig.SelectObjectColor);
            project.SetTransparency(GetModelViewTransparency());
        }

        /// <summary>
        /// Преобразует процент прозрачности интерфейса в альфа-канал представления.
        /// </summary>
        private byte GetModelViewTransparency()
        {
            var transparency = settingsConfig.TransparencyValue * byte.MaxValue / 100;
            return (byte)Math.Clamp(transparency, byte.MinValue, byte.MaxValue);
        }

        /// <summary>
        /// Возвращает цвет визуализации условия расчётной задачи.
        /// </summary>
        private Color GetConditionColor(DataKind dataKind)
        {
            if (dataKind == DataKind.Материал)
                return Color.FromArgb(255, 255, 0);
            if (dataKind == DataKind.Среда)
                return Color.FromArgb(255, 155, 0);
            if (dataKind == DataKind.Закрепление || dataKind == DataKind.Нагрузка)
                return Color.FromArgb(255, 0, 0);
            if (dataKind == DataKind.Нагрев)
                return Color.FromArgb(125, 155, 255, 0);

            return settingsConfig.SelectObjectColor;
        }
    }
}
