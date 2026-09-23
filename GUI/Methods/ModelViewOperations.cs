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

        /// <summary>
        /// Обновляет буферы модели после изменения состояния представления.
        /// </summary>
        private void ModelView_Changed(object sender, EventArgs e)
        {
            if (IsDisposed || project == null) // если форма уже закрыта или проект не загружен, то не перерисовываем сцену
                return;

            if (InvokeRequired) // перенаправление в UI-поток, если вызов из другого потока (например, из BackgroundWorker)
            {
                BeginInvoke(new Action(() => ModelView_Changed(sender, e)));
                return;
            }

            RefreshModelViewBuffers();
            RequestRedraw();
        }

        /// <summary>
        /// Пересоздаёт буферы наборов расчётной модели без затрагивания служебных объектов сцены.
        /// </summary>
        private void RefreshModelViewBuffers()
        {
            foreach (ObjType objType in Enum.GetValues(typeof(ObjType)))
            {
                foreach (var setInfo in project.GetModelSetsInfo(objType))
                    RefreshModelSetBuffer(setInfo);
            }
        }

        /// <summary>
        /// Пересоздаёт буфер заданного набора с учётом состояния представления.
        /// </summary>
        private void RefreshModelSetBuffer(ISetInfo setInfo)
        {
            VBOController.DeleteVBObjects(setInfo.Name);
            if (setInfo.NumberOfObjects == 0)
                return;

            var presenter = project.CreateModelObjectsPresentor(setInfo);
            if (TryCreateVBObject(presenter, out var vbo))
                VBOController.AddVbo(vbo);
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
