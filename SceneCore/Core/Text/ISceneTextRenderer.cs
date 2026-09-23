using BazisGUI.Scene.Core.Rendering;

namespace BazisGUI.Scene.Core.Text
{
    public interface ISceneTextRenderer
    {
        void SetFont(string family, float size);
        void DrawText3D(TextLabel label, IRenderContext context);
        void DrawText2D(TextLabel label, IRenderContext context);
    }
}
