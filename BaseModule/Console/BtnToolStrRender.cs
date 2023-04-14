using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.Console
{
    public class BtnToolStrRender : ToolStripRenderer
    {
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {

            Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 10, e.Item.Size.Height - 1);
            if (e.Item is ToolStripButton tsBtn)
            {
                if (tsBtn.Selected | tsBtn.Pressed | tsBtn.Checked)
                {
                    e.Graphics.FillRectangle(Brushes.DarkGray, rectangle);
                }
            }
        }

        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 10, e.Item.Size.Height - 1);

            //rectangle = new Rectangle(0, 0, e.Item.Size.Width - 10, e.Item.Size.Height - 1);
            if (e.Item is ToolStripSplitButton tssBtn)
            {
                if (tssBtn.Selected | tssBtn.Pressed)
                {
                    e.Graphics.FillRectangle(Brushes.DarkGray, rectangle);
                    
                }
                DrawTriangle(e);
            }
        }

        private static void DrawTriangle(ToolStripItemRenderEventArgs e)
        {
            var shiftY = 3;
            var shiftX = 15;
            var points = new Point[]
            {
                        new Point(shiftX,e.Item.Size.Height - 3 - shiftY),
                        new Point(shiftX - 4,e.Item.Size.Height - 0 - shiftY),
                        new Point(shiftX - 7,e.Item.Size.Height - 3 - shiftY)
            };
            e.Graphics.FillPolygon(Brushes.Black, points);
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            var tls = e.ToolStrip;

            var gr = e.Graphics;

            Font _TabFont = new Font(FontFamily.GenericSansSerif, (float)12, FontStyle.Regular, GraphicsUnit.Pixel);
            SizeF messageSize = gr.MeasureString(tls.Text, _TabFont);
            var xc = tls.Width / 2;
            var yc = tls.Height / 2 + messageSize.Height;
            PointF p = new PointF(xc, yc);

            var rectangle = new Rectangle((int)xc, (int)yc, (int)messageSize.Width +10, (int)messageSize.Height);           

            gr.DrawLine(Pens.LightGray, new Point(tls.Width - 10, 10), new Point(tls.Width - 10, tls.Height - 10));         

            DrawSidewaysText(gr, _TabFont, SystemBrushes.WindowText, rectangle, tls.Text);
            //gr.DrawString(tls.Text, _TabFont, SystemBrushes.WindowText, p);
        }
        private void DrawSidewaysText(Graphics gr, Font font, Brush brush, Rectangle bounds, string txt)
        {
            var strFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            // Создаем поворот прямоугольника в начале координат.

            Rectangle rotated_bounds = new Rectangle(0, 0, bounds.Width, bounds.Height);

            //GraphicsState state = gr.Save();
            // Поворот.
            //gr.ResetTransform();
            

            // Переместите, чтобы переместить прямоугольник в правильное положение.
            gr.TranslateTransform(bounds.Left, bounds.Bottom,
                MatrixOrder.Append);
            gr.RotateTransform(-90);
            gr.FillRectangle(SystemBrushes.Control, rotated_bounds);
            // Рисуем текст.
            gr.DrawString(txt, font, brush, rotated_bounds, strFormat);

            //gr.Restore(state);
        }
    }
}
