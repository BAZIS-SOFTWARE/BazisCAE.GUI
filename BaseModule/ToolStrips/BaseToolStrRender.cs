using BaseModule.ControlsComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.ToolStrips
{
    public class BaseToolStrRender: ToolStripProfessionalRenderer
    {
        public Color TopColor { get; set; } = Color.Silver;
        public Color BottomColor { get; set; } = Color.WhiteSmoke;
        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            //base.OnRenderSplitButtonBackground(e);

            var sbtn = e.Item as ToolStripSplitButton;

            Font _TabFont = new Font(FontFamily.GenericSansSerif, (float)14, FontStyle.Regular, GraphicsUnit.Pixel);
            SizeF messageSize = e.Graphics.MeasureString(sbtn.ToolTipText, _TabFont);

            var shiftBottomRect_Y = 19;
            var shiftUpmRect_Y = 2;
            var shiftRect_X = 4;

            Rectangle rectangle = new Rectangle(0, shiftUpmRect_Y, e.Item.Size.Width - shiftRect_X, e.Item.Size.Height - shiftBottomRect_Y);
            e.Graphics.FillRectangle(Brushes.White, rectangle);
            if (sbtn.Pressed | sbtn.Selected)
            {
                rectangle = new Rectangle(0, shiftUpmRect_Y, e.Item.Size.Width - shiftRect_X, e.Item.Size.Height - shiftBottomRect_Y);
                e.Graphics.FillRectangle(Brushes.DarkGray, rectangle);
            }
            var shiftTriangle_Y = 30;
            var shiftTriangle_X = sbtn.Width - sbtn.DropDownButtonWidth / 2;

            sbtn.Width = (int)messageSize.Width + 2 * sbtn.DropDownButtonWidth;

            rectangle = new Rectangle(0, shiftUpmRect_Y, e.Item.Size.Width - shiftRect_X, e.Item.Size.Height - shiftBottomRect_Y);
            e.Graphics.DrawRectangle(Pens.LightGray, rectangle);
            DrawTriangle(shiftTriangle_X, shiftTriangle_Y, e);
            

            e.Graphics.DrawString(sbtn.ToolTipText, _TabFont, SystemBrushes.WindowText,
                sbtn.Width / 2 - messageSize.Width / 2, sbtn.Height / 2 - messageSize.Height / 1.5f);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            e.Graphics.DrawLine(Pens.LightGray, new Point(2, 6), new Point(2, 30));
            //FillRoundedRectangle(e.Graphics, Pens.Gray, Brushes.LightGray,2, 6, 3, 25, 2);
        }

        public void FillRoundedRectangle(Graphics g, Pen pen, Brush brush, int x, int y, int width, int height, int radius)
        {
            Rectangle corner = new Rectangle(x, y, radius, radius);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(corner, 180, 90);
            corner.X = x + width - radius;
            path.AddArc(corner, 270, 90);
            corner.Y = y + height - radius;
            path.AddArc(corner, 0, 90);
            corner.X = x;
            path.AddArc(corner, 90, 90);
            path.CloseFigure();

            g.FillPath(brush, path);

            if (pen != null)
            {
                g.DrawPath(pen, path);
            }
        }

        private static void DrawTriangle(int x, int y, ToolStripItemRenderEventArgs e)
        {
            var points = new Point[]
            {
                        new Point(x,e.Item.Size.Height - 3 - y),
                        new Point(x - 4,e.Item.Size.Height + 1 - y),
                        new Point(x - 7,e.Item.Size.Height - 3 - y)
            };
            e.Graphics.FillPolygon(Brushes.Black, points);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
 
            Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 14);

            var btn = e.Item as ToolStripButton;

            if (btn.Selected | btn.Pressed | btn.Checked)
                {
                    e.Graphics.FillRectangle(Brushes.DarkGray, rectangle);
                    e.Graphics.DrawRectangle(Pens.DarkGray, rectangle);
                }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var rectangle = new Rectangle(0, 0, e.Item.Width, e.Item.Height);
            e.Graphics.FillRectangle(SystemBrushes.Control, rectangle);
        }


        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            var tls = e.ToolStrip;

            if (tls.Text != "")
            {
                var gr = e.Graphics;
                var parentSize = tls.Parent.Size;
                ComponentsPainter.PaintGradientRectangle(gr, new Point(0, parentSize.Height - 16),tls.Width, parentSize.Height, TopColor, BottomColor);

                SizeF messageSize = gr.MeasureString(tls.Text, ComponentsPainter.Font);
                var x = tls.Width / 2 - messageSize.Width / 2;
                var y = parentSize.Height - messageSize.Height;
                gr.DrawString(tls.Text, ComponentsPainter.Font, SystemBrushes.WindowText, x, y);
            }            
        }
        
    }
}
