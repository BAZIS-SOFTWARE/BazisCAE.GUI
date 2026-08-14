using Model.Interfaces;
using OperationalController.GeomObjsCreator;
using System;
using System.Drawing;
using System.Linq;

namespace BazisGUI
{
    public partial class BaseForm
    {
        private void CreateChamfer(double length, double angle, bool isByAngle, bool reflected)
        {
            try
            {
                var objs = project.GetModelObjects(ObjType.Кривая);
                var selObjs = objs.Where(x => x.Color == settingsConfig.SelectObjectColor).Select(x => x.Number).ToArray();
                var s = project.CreateChamfer(selObjs, length, angle, isByAngle, reflected);
                VBOController.DeleteAllVBObjects();
                CreateVBObjects("Объекты");
                PresentMeshData();
                DisplayObjects();
            }
            catch (Exception ex) 
            {
                console.PrintInfo(ex.Message, Color.Red);
            }
            RequestClearChamferPreview();
        }

        private void PreviewChamfer(double length, double angle, bool isByAngle, bool reflected)
        {
            try
            {
                var objs = project.GetModelObjects(ObjType.Кривая);
                var selObjs = objs.Where(x => x.Color == settingsConfig.SelectObjectColor).Select(x => x.Number).ToArray();
                var previewDatas = project.PreviewChamfer(selObjs, length, angle, isByAngle, reflected);
                DisplayChamferPreview(previewDatas);
            }
            catch (Exception ex)
            {
                console.PrintInfo(ex.Message, Color.Red);
                RequestClearChamferPreview();
            }
        }
        private const string ChamferPreviewName = "ChamferPreview";

        private void DisplayChamferPreview(ChamferPreviewData[] previewData)
        {
            // Создание/удаление VBO должно выполняться в потоке WinForms/GL.
            if (InvokeRequired)
            {
                BeginInvoke(new Action(
                    () => DisplayChamferPreview(previewData)));

                return;
            }

            ClearChamferPreview(redraw: false);

            if (previewData == null || previewData.Length == 0)
            {
                DisplayObjects();
                return;
            }

            var segments = previewData
                .SelectMany(data => data.CreateSegments())
                .ToArray();

            // GL.Lines воспринимает каждую пару вершин как отдельный отрезок.
            float[] coordinates = segments
                .SelectMany(segment => new[]
                {
                    segment.P0._x,
                    segment.P0._y,
                    segment.P0._z,

                    segment.P1._x,
                    segment.P1._y,
                    segment.P1._z
                })
                .ToArray();

            int vertexCount = coordinates.Length / 3;

            int[] indices = Enumerable
                .Range(0, vertexCount)
                .ToArray();

            // Чёрный цвет RGBA для каждой вершины.
            float[] colors = Enumerable
                .Range(0, vertexCount)
                .SelectMany(_ => new[]
                {
                    0.0f,
                    0.0f,
                    0.0f,
                    1.0f
                })
                .ToArray();

            // LineObjects нормали не использует, но конструктор их ожидает.
            float[] normals = new float[vertexCount * 3];

            var previewVbo = VBOController.CreateLineVBObjects(
                indices,
                coordinates,
                colors,
                normals,
                Array.Empty<bool>(),
                ChamferPreviewName);

            previewVbo.Gl_LineWidth = 3.0f;

            // Необходимо для существующего режима усреднённого рендера.
            previewVbo.ActiveDrawingObject =
                averageColorRenderer.IsEnable
                    ? averageColorRenderer
                    : null;

            VBOController.AddVbo(previewVbo);
            DisplayObjects();
        }

        private void ClearChamferPreview(bool redraw = true)
        {
            if (!VBOController.DeleteVBObjects(ChamferPreviewName))
                return;

            if (redraw)
                DisplayObjects();
        }
    }
}
