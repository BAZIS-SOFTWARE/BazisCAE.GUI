using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BazisGUI.Scene; // SceneScale (существующий переиспользуемый класс)
using BazisGUI.Scene.Core.Rendering;
using BazisGUI.Scene.Core.Text;
using Geometry;
using PostProc;

namespace BazisGUI.Scene.Core.Layers
{
    /// <summary>
    /// Перенос BaseForm.DisplaySceneScale(title, info) поверх переиспользуемого SceneScale
    /// (цветные прямоугольники шкалы рисует он же, без изменений). Центрирование заголовка
    /// раньше считалось через Graphics.MeasureString (System.Drawing.Common) — здесь заменено
    /// приблизительной оценкой ширины по количеству символов, так как GDI+ в ядре запрещён
    /// (см. scene.avalonia.md, раздел 2).
    /// </summary>
    public class SceneScaleLayer : ISceneLayer
    {
        private const float ApproxCharWidth = 6f;

        public string Name => "SceneScale";
        public int Order { get; set; } = 60;
        public bool IsVisible { get; set; } = true;

        private readonly ISceneTextRenderer textRenderer;
        private SceneScale scale;
        private IEnumerable<ItemRange> items;

        public SceneScaleLayer(ISceneTextRenderer textRenderer)
        {
            this.textRenderer = textRenderer;
        }

        public void Show(SceneScale scale, IEnumerable<ItemRange> items)
        {
            this.scale = scale;
            this.items = items;
        }

        public void Clear()
        {
            scale = null;
            items = null;
        }

        public void Draw(IRenderContext context)
        {
            if (scale == null || items == null)
                return;

            var itemList = items.ToList();
            if (itemList.Count == 0)
                return;

            var viewport = context.Viewport;
            var length = viewport.Height - scale.Coord_Y - 100;
            var gapY = 2;
            var cellSizeY = (length - (itemList.Count - 1) * gapY) / itemList.Count;
            var stepY = cellSizeY + gapY;

            scale.DisplayScale(scale.Coord_X, scale.Coord_Y, gapY, cellSizeY, stepY, itemList);

            var posY = scale.Coord_Y;
            foreach (var item in itemList)
            {
                DrawLabel(item.Min.ToString(), new Point3D(scale.Coord_X + 20, posY, -5), context);
                DrawLabel(item.Max.ToString(), new Point3D(scale.Coord_X + 20, posY + stepY, -5), context);
                posY += stepY;
            }

            DrawLabel(scale.Title, new Point3D(scale.Coord_X - scale.Title.Length * ApproxCharWidth / 2, posY + 30, -5), context);
            DrawLabel(scale.Info, new Point3D(scale.Coord_X - scale.Info.Length * ApproxCharWidth / 2, posY + 15, -5), context);
        }

        private void DrawLabel(string text, Point3D position, IRenderContext context)
        {
            textRenderer.DrawText3D(new TextLabel { Text = text, Color = Color.Black, Position3D = position }, context);
        }
    }
}
