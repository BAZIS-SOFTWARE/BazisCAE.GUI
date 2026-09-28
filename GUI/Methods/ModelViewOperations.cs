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
        IModelView subscribedModelView;

        /// <summary>
        /// Подключает обновление сцены к состоянию представления текущего проекта.
        /// </summary>
        private void SubscribeToModelView()
        {
            var modelView = project?.ModelView;
            if (ReferenceEquals(subscribedModelView, modelView))
                return;

            if (subscribedModelView != null)
                subscribedModelView.Changed -= ModelView_Changed;

            subscribedModelView = modelView;
            ApplyModelViewSettings();
            if (subscribedModelView != null)
                subscribedModelView.Changed += ModelView_Changed;
        }

        const ModelViewChange RebuildChanges = ModelViewChange.Visibility | ModelViewChange.InsideSurfaces | ModelViewChange.ViewMode;
        const ModelViewChange ColorChanges = ModelViewChange.Selection | ModelViewChange.SetColor | ModelViewChange.ObjectColor | ModelViewChange.SelectionColor | ModelViewChange.Transparency;

        /// <summary>
        /// Обновляет буферы наборов, затронутых изменением представления, и запрашивает кадр.
        /// Событие само перечисляет затронутые наборы, поэтому обходить всю модель не нужно.
        /// </summary>
        private void ModelView_Changed(object sender, ModelViewChangedEventArgs e)
        {
            if (IsDisposed || project == null || !ReferenceEquals(sender, project.ModelView))
                return;

            if (InvokeRequired) // перенаправление в UI-поток, если вызов из другого потока (например, из BackgroundWorker)
            {
                BeginInvoke(new Action(() => ModelView_Changed(sender, e)));
                return;
            }

            foreach (var setInfo in e.GetChangedSets())
            {
                if (e.HasAny(setInfo, RebuildChanges))
                    RefreshModelSetBuffer(setInfo);
                else if (e.HasAny(setInfo, ColorChanges))
                    RecolorModelSetBuffer(setInfo);
            }

            RequestRedraw();
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
            return project.ModelView.IsSelected(modelObject.ObjType, modelObject.Number);
        }

        /// <summary>
        /// Возвращает видимые объекты заданного набора.
        /// </summary>
        private IEnumerable<int> GetVisibleNumbers(ISetInfo setInfo)
        {
            foreach (var number in setInfo.GetNumbers())
                if (project.ModelView.GetVisible(setInfo.ObjType, number))
                    yield return number;
        }

        /// <summary>
        /// Применяет цвет выделения из настроек к текущему представлению.
        /// </summary>
        private void ApplySelectionColor()
        {
            if (project != null)
                project.ModelView.SelectionColor = settingsConfig.SelectObjectColor;
        }

        /// <summary>
        /// Применяет настройки цвета выделения и прозрачности к текущему представлению.
        /// </summary>
        private void ApplyModelViewSettings()
        {
            if (project == null)
                return;

            project.ModelView.SelectionColor = settingsConfig.SelectObjectColor;
            project.ModelView.Transparency = GetModelViewTransparency();
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
