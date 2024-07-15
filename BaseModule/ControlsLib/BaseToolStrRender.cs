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

namespace BaseModule.ControlsLib
{
    public class BaseToolStrRender: ToolStripProfessionalRenderer
    {
        public Color FrameColor { get; set; } = Color.DarkGray;
        public Color TopColor { get; set; } = Color.FromArgb(255, 228, 228, 228);
        public Color BottomColor { get; set; } = Color.FromArgb(255, 228, 228, 228);
        public Color ItemPressColor { get; set; } = Color.Black;
        public Color ItemSelectColor { get; set; } = Color.Gray;
        public Color ItemBackGroundColor { get; set; } = Color.FromArgb(255, 228, 228, 228);

        public Point IconLocation { get; set; } = new Point(0, 3);

        public int SplitButtonWidth { get; set; } = 24;

        public int TextBoxHeight { get; set; } = 16;

        public int SplitButtonTriangleSize { get; set; } = 5;



        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var sbtn = e.Item as ToolStripSplitButton;

            ComponentsPainter.PaintFrameRectangle(e.Graphics, 1.0f, FrameColor, new Point(0, 0), sbtn.Width - 1, sbtn.Height - 15);
            ComponentsPainter.PaintFrameRectangle(e.Graphics, 1.0f, FrameColor, new Point(sbtn.Width - SplitButtonWidth, 0), SplitButtonWidth, sbtn.Height - 15);

            if (sbtn.Selected)
            {
                Rectangle rectangle = new Rectangle(0, 0, sbtn.Width, sbtn.Height - 15);
                e.Graphics.FillRectangle(new SolidBrush(ItemSelectColor), rectangle);
                //ComponentsPainter.PaintFrameRectangle(e.Graphics, 2.0f, ItemSelectColor, new Point(1, 1), sbtn.Width - 2, sbtn.Height - 17);
            }
            var centre = new Point(sbtn.Width - SplitButtonWidth / 2, (sbtn.Height - TextBoxHeight) / 2);

            var points = CreateTriangle(centre, SplitButtonTriangleSize);
            e.Graphics.FillPolygon(Brushes.Black, points);

            SizeF messageSize = e.Graphics.MeasureString(sbtn.ToolTipText, ComponentsPainter.Font);
            e.Graphics.DrawString(sbtn.ToolTipText, ComponentsPainter.Font, SystemBrushes.WindowText,
5, sbtn.Height / 2 - messageSize.Height);

            //sbtn.Width = (int)messageSize.Width + 2 * sbtn.DropDownButtonWidth;
            //}
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Black, new Point(2, 6), new Point(2, 30));
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

        private PointF[] CreateTriangle(Point centre, int sideLengh)
        {
            var h = 0.8660f * sideLengh;

            

            var points = new PointF[]
            {
                        new PointF(centre.X - sideLengh / 2, centre.Y - h / 3),
                        new PointF(centre.X + sideLengh / 2, centre.Y - h / 3),
                        new PointF(centre.X, centre.Y + 0.6666f * h)
            };

            return points;
        }

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            var x = e.ImageRectangle.X + IconLocation.X;
            var y = e.ImageRectangle.Y + IconLocation.Y;
            var rectangle = new Rectangle(x, y, e.ImageRectangle.Width, e.ImageRectangle.Height);
            e.Graphics.DrawImage(e.Image, rectangle);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var btn = e.Item as ToolStripButton;
            Rectangle rectangle = new Rectangle(0, 0, btn.Width, btn.Height - 15);

            e.Graphics.FillRectangle(new SolidBrush(ItemBackGroundColor), rectangle);

            ComponentsPainter.PaintFrameRectangle(e.Graphics, 1.0f, FrameColor, new Point(0, 0), btn.Width - 1, btn.Height - 15);
 

            if (btn.Pressed | btn.Checked)
            {
                ComponentsPainter.PaintFrameRectangle(e.Graphics, 2.0f, ItemPressColor, new Point(1, 1), btn.Width - 2, btn.Height - 17);
            }

            if (btn.Selected)
                e.Graphics.FillRectangle(new SolidBrush(ItemSelectColor), rectangle); 
            //ComponentsPainter.PaintFrameRectangle(e.Graphics, 2.0f, ItemSelectColor, new Point(1, 1), btn.Width - 2, btn.Height - 17);
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

                ComponentsPainter.PaintGradientRectangle(gr, new Point(0, 1),tls.Width - 4, parentSize.Height - 4, TopColor, BottomColor);
                ComponentsPainter.PaintFrameRectangle(gr, 1.0f,FrameColor, new Point(0, 1), tls.Width - 4, parentSize.Height - 4);
                ComponentsPainter.PaintFrameRectangle(gr, 1.0f, FrameColor, new Point(0, parentSize.Height - TextBoxHeight - 1), tls.Width - 2, TextBoxHeight);

                SizeF messageSize = gr.MeasureString(tls.Text, ComponentsPainter.Font);
                var x = tls.Width / 2 - messageSize.Width / 2;
                var y = parentSize.Height - messageSize.Height - 2;
                gr.DrawString(tls.Text, ComponentsPainter.Font, SystemBrushes.WindowText, x, y);
            }            
        }
        
    }
}
