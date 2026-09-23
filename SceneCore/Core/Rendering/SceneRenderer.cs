using System;
using BazisGUI.Scene.Core.Layers;
using BazisGUI.Scene; // AverageColorRenderer, Advanced3DClipper (существующий переиспользуемый GL-слой)
using OpenTK.Graphics.OpenGL;

namespace BazisGUI.Scene.Core.Rendering
{
    /// <summary>
    /// Замена BaseForm.DisplayObjects(): не вызывает SwapBuffers — буферами владеет
    /// композитор Avalonia (см. scene.avalonia.md, раздел 6). Гасит buffer clear/reset
    /// один раз за кадр и затем проходит по SceneLayerCollection в порядке Order —
    /// вместо явной последовательности вызовов DisplayXxxEvent из старого кода.
    /// Оборачивание AverageColorRenderer.DoActionsBeforeDrawing/AfterDrawing в старом коде
    /// шло тремя отдельными участками (базис, геометрия, текст); здесь упрощено до одного
    /// прохода на весь кадр — по объектам VBOController ActiveDrawingObject сейчас и так
    /// не назначается (закомментировано в VBOController.CreateXxxVBObjects), так что это
    /// не меняет наблюдаемое поведение. Условие прозрачности читается напрямую из
    /// transparency.IsEnable (а не из отдельного флага настроек) — в старом коде оба
    /// значения всегда выставлялись синхронно.
    /// </summary>
    public class SceneRenderer : ISceneRenderer, IDisposable
    {
        private readonly SceneLayerCollection layers;
        private readonly AverageColorRenderer transparency;
        private readonly Advanced3DClipper clipper;

        public SceneRenderer(SceneLayerCollection layers, AverageColorRenderer transparency, Advanced3DClipper clipper)
        {
            this.layers = layers;
            this.transparency = transparency;
            this.clipper = clipper;
        }

        public void Render(IRenderContext context)
        {
            ClearBuffers(context);
            ResetViewMatrix(context);

            foreach (var layer in layers.GetOrdered())
                if (layer.IsVisible)
                    layer.Draw(context);

            if (transparency.IsEnable && !clipper.IsEnable)
                transparency.BlendFramebuffers();

            GL.Finish();
        }

        private void ClearBuffers(IRenderContext context)
        {
            var bg = context.Settings.BackGroundColor;
            GL.ClearColor(bg.R / 255f, bg.G / 255f, bg.B / 255f, 0);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (transparency.IsEnable && !clipper.IsEnable)
                transparency.ClearColors();
        }

        private static void ResetViewMatrix(IRenderContext context)
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.LoadMatrix(context.Camera.GetViewMatrix().AsColumnMajorArray());
        }

        public void Reshape(int width, int height) => transparency.Reshape(width, height);

        public void Dispose()
        {
            transparency.Dispose();
            clipper.Dispose();
        }
    }
}
