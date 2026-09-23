using BazisGUI.Scene.Core.Rendering;
using BazisGUI.Scene.Core.Text;

namespace BazisGUI.Scene.Core.Layers
{
    /// <summary>Заменяет DisplayText3DEvent/DisplayText2DEvent.</summary>
    public class TextLayer : ISceneLayer
    {
        public string Name => "Text";
        public int Order { get; set; } = 55;
        public bool IsVisible { get; set; } = true;

        public TextLabelCollection Labels { get; } = new TextLabelCollection();

        private readonly ISceneTextRenderer textRenderer;

        public TextLayer(ISceneTextRenderer textRenderer)
        {
            this.textRenderer = textRenderer;
        }

        public void Draw(IRenderContext context)
        {
            foreach (var label in Labels)
            {
                if (label.IsScreenSpace)
                    textRenderer.DrawText2D(label, context);
                else
                    textRenderer.DrawText3D(label, context);
            }
        }
    }
}
