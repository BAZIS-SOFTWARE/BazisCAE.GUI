using System;
using BazisGUI.Scene.Core.Rendering;
using Geometry;
using OpenTK.Graphics.OpenGL;

namespace BazisGUI.Scene.Core.Text
{
    /// <summary>
    /// Целевая кросс-платформенная реализация текста: глифы растеризуются в текстурный атлас
    /// (GlyphAtlas), рисуются текстурированными квадами вместо GL.CallLists —
    /// см. scene.avalonia.md, раздел 6. 3D-текст рисуется как биллборд (по осям камеры),
    /// что при column-vector виде матрицы эквивалентно поведению RasterPos3 в старом коде:
    /// текст так же уменьшается с расстоянием/масштабом сцены.
    /// </summary>
    public class SkiaGlyphAtlasTextRenderer : ISceneTextRenderer, IDisposable
    {
        private readonly GlyphAtlas atlas = new GlyphAtlas();

        /// <summary>Множитель, переводящий пиксельный размер глифа в мировые единицы для DrawText3D.</summary>
        public float GlyphWorldScale { get; set; } = 0.02f;

        public void SetFont(string family, float size) => atlas.Build(family, size);

        public void DrawText3D(TextLabel label, IRenderContext context)
        {
            var view = context.Camera.GetViewMatrix();
            var right = new Point3D(view[0, 0], view[0, 1], view[0, 2]);
            var up = new Point3D(view[1, 0], view[1, 1], view[1, 2]);

            DrawGlyphQuads(label.Text, label.Position3D, right, up, GlyphWorldScale, label.Color);
        }

        public void DrawText2D(TextLabel label, IRenderContext context)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Ortho(0, context.Viewport.Width, 0, context.Viewport.Height, 0.1, 200);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();

            var origin = new Point3D((float)label.Position2D._x, (float)label.Position2D._y, -5);
            DrawGlyphQuads(label.Text, origin, new Point3D(1, 0, 0), new Point3D(0, 1, 0), 1f, label.Color);

            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();
        }

        private void DrawGlyphQuads(string text, Point3D origin, Point3D right, Point3D up, float scale, System.Drawing.Color color)
        {
            if (string.IsNullOrEmpty(text))
                return;

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.BindTexture(TextureTarget.Texture2D, atlas.Texture);
            GL.Color3(color.R / 255f, color.G / 255f, color.B / 255f);

            var cursor = 0f;
            GL.Begin(PrimitiveType.Quads);
            foreach (var ch in text)
            {
                var glyph = atlas.GetGlyph(ch);
                var w = glyph.Width * scale;
                var h = glyph.Height * scale;

                var baseP = origin.Sum(right.Mult(cursor));
                var p00 = baseP;
                var p10 = baseP.Sum(right.Mult(w));
                var p11 = baseP.Sum(right.Mult(w)).Sum(up.Mult(h));
                var p01 = baseP.Sum(up.Mult(h));

                GL.TexCoord2(glyph.U0, glyph.V1); GL.Vertex3(p00._x, p00._y, p00._z);
                GL.TexCoord2(glyph.U1, glyph.V1); GL.Vertex3(p10._x, p10._y, p10._z);
                GL.TexCoord2(glyph.U1, glyph.V0); GL.Vertex3(p11._x, p11._y, p11._z);
                GL.TexCoord2(glyph.U0, glyph.V0); GL.Vertex3(p01._x, p01._y, p01._z);

                cursor += glyph.Advance * scale;
            }
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D);
        }

        public void Dispose() => atlas.Dispose();
    }
}
