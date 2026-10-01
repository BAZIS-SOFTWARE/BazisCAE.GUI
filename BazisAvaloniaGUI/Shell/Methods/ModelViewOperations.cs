using Model.Interfaces;
using Model.Interfaces.ObjectsCollections;
using OperationalController;
using Project.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BazisAvaloniaGUI.Shell
{
    internal partial class MainWindow
    {
        // Обновление буферов по ModelView.Changed (SubscribeToModelView, ModelView_Changed, RefreshModelSetBuffer,
        // RecolorModelSetBuffer) выполняет SceneView; точки подключения — в Scene/SceneConnection.cs.

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
