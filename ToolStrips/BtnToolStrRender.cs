using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolStrips
{
    public class BtnToolStrRender: ToolStripProfessionalRenderer
    {
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

            Font _TabFont = new Font(FontFamily.GenericSansSerif, (float)13, FontStyle.Regular, GraphicsUnit.Pixel);
            SizeF messageSize = gr.MeasureString(lbl.Text, _TabFont);

            lbl.Width = (int)messageSize.Width;

            var xc = lbl.Width / 2 - messageSize.Width / 2;
            var yc = lbl.Height / 2 - messageSize.Height;
            PointF p = new PointF(xc, yc);

            Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 14);
            gr.FillRectangle(SystemBrushes.ControlLight, rectangle);
            //gr.DrawLine(Pens.LightGray, new Point(18, lbl.Height - 10), new Point(lbl.Width - 5, lbl.Height - 10));

            gr.DrawString(lbl.Text, _TabFont, SystemBrushes.WindowText, p);

        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            var tls = e.ToolStrip;

            var gr = e.Graphics;

            Font _TabFont = new Font(FontFamily.GenericSansSerif, (float)11, FontStyle.Regular, GraphicsUnit.Pixel);
            SizeF messageSize = gr.MeasureString(tls.Text, _TabFont);
            var xc = tls.Width / 2 - messageSize.Width / 2;
            var yc = tls.Height - messageSize.Height;
            PointF p = new PointF(xc, yc);

            var rectangle = new Rectangle(0, 0, tls.Width, tls.Height);
            e.Graphics.FillRectangle(SystemBrushes.Control, rectangle);

            gr.DrawLine(Pens.LightGray, new Point(18, tls.Height - 10), new Point(tls.Width - 5, tls.Height - 10));

            rectangle = new Rectangle((int)xc, (int)yc, (int)messageSize.Width, (int)messageSize.Height);
            e.Graphics.FillRectangle(SystemBrushes.Control, rectangle);
            gr.DrawString(tls.Text, _TabFont, SystemBrushes.WindowText, p);


        }

        
    }
}
