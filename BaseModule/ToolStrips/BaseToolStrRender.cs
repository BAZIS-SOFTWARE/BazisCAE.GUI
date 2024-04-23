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



        protected override void OnRenderLabelBackground(ToolStripItemRenderEventArgs e)
        {
            var lbl = e.Item as ToolStripLabel;
            
            var gr = e.Graphics;

            var recHeigth = 15;

            var locRect = new Point(0, lbl.Height - recHeigth);

            var linGrBrush = new LinearGradientBrush(
   new Point(0, lbl.Height),
   new Point(0, lbl.Height + 15),
   BottomColor,   // Opaque red
   TopColor);  // Opaque blue

            var rect = new Rectangle(locRect, new Size(lbl.Width, 15));

            e.Graphics.FillRectangle(linGrBrush, rect);

        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            var tls = e.ToolStrip;

            if(tls.Text != "")
            {
                var gr = e.Graphics;

                Font _TabFont = new Font(FontFamily.GenericSansSerif, (float)11, FontStyle.Regular, GraphicsUnit.Pixel);
                SizeF messageSize = gr.MeasureString(tls.Text, _TabFont);
                var xc = tls.Width / 2 - messageSize.Width / 2;
                var yc = tls.Height - messageSize.Height;
                PointF p = new PointF(xc, yc - 2);

                var locRect = new Point(0, (int)yc + 2);

                var linGrBrush = new LinearGradientBrush(
       new Point(0, (int)yc),
       new Point(0, tls.Height),
       BottomColor,   // Opaque red
       TopColor);  // Opaque blue

                var rect = new Rectangle(locRect, new Size(tls.Width, tls.Height));

                e.Graphics.FillRectangle(linGrBrush, rect);

                gr.DrawString(tls.Text, _TabFont, SystemBrushes.WindowText, p);
            }            
        }
        
    }
}
