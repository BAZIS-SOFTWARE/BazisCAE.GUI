using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UserControlsEx
{
    public class BaseToolStrRender: ToolStripProfessionalRenderer
    {
        public Color BackGroundColor { get; set; } = Color.Gainsboro;
        public Color FrameColor { get; set; } = Color.DarkGray;
        public Color ItemPressColor { get; set; } = Color.Black;
        public Color ItemSelectColor { get; set; } = Color.Gray;
        public Color ItemBackGroundColor { get; set; } = Color.FromArgb(255, 228, 228, 228);
        public Point IconLocation { get; set; } = new Point(0, 8);
        public Point ItemLocation { get; set; } = new Point(4, 4);
        public int SplitButtonClickWidth { get; set; } = 16;
        public int SplitButtonHeight { get; set; } = 34;
        public int TextBoxHeight { get; set; } = 16;
        public int SplitButtonTriangleSize { get; set; } = 6;
        public bool GeneralFrame { get; set; } = true;
        public bool ItemFrame { get; set; } = true;
        public bool TextBoxFrame { get; set; } = true;

        public Point ImageRectangleSize { get; set; } = new Point(26, 26);

        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var spb = e.Item;

            var rectangle = new Rectangle(ItemLocation.X, ItemLocation.Y,
spb.Width - 2 * ItemLocation.X, SplitButtonHeight - 2 * ItemLocation.Y);

            //e.Graphics.FillRectangle(new SolidBrush(ItemBackGroundColor), rectangle);

            if (spb.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(ItemSelectColor), rectangle);
            }

            if (ItemFrame)
            {
                e.Graphics.DrawRectangle(new Pen(FrameColor, 1.0f), rectangle);

                if (e.ToolStrip.LayoutStyle == ToolStripLayoutStyle.HorizontalStackWithOverflow)

                    rectangle = new Rectangle(spb.Width - SplitButtonClickWidth - ItemLocation.X, ItemLocation.Y,
        SplitButtonClickWidth, SplitButtonHeight - 2 * ItemLocation.Y);
                else
                    rectangle = new Rectangle(ItemLocation.X, SplitButtonHeight - SplitButtonClickWidth,
spb.Width - 2 * ItemLocation.X, SplitButtonClickWidth - ItemLocation.Y);


                e.Graphics.DrawRectangle(new Pen(FrameColor, 1.0f), rectangle);
            }

            Point centre;
            if (e.ToolStrip.LayoutStyle == ToolStripLayoutStyle.HorizontalStackWithOverflow)
                centre = new Point(spb.Width - ItemLocation.X - SplitButtonClickWidth / 2, (spb.Height - TextBoxHeight) / 2);
            else
                centre = new Point(spb.Width / 2, SplitButtonHeight - SplitButtonClickWidth / 2 - ItemLocation.Y);

            var points = CreateTriangle(centre, SplitButtonTriangleSize);
            e.Graphics.FillPolygon(Brushes.Black, points);

            SizeF messageSize = e.Graphics.MeasureString(spb.ToolTipText, e.ToolStrip.Font);
            e.Graphics.DrawString(spb.ToolTipText, e.ToolStrip.Font, SystemBrushes.WindowText,
5, spb.Height / 2 - messageSize.Height);

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
            var rectangle = new Rectangle(x, y, ImageRectangleSize.X, ImageRectangleSize.Y);
            e.Graphics.DrawImage(e.Image, rectangle);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var btn = e.Item as ToolStripButton;
            var rectangle = new Rectangle(ItemLocation.X, ItemLocation.Y, btn.Width - 2 * ItemLocation.X, btn.Width - 2 * ItemLocation.X);

            e.Graphics.FillRectangle(new SolidBrush(ItemBackGroundColor), rectangle);

            if(ItemFrame)
                e.Graphics.DrawRectangle(new Pen(FrameColor, 1.0f), rectangle);
 

            if (btn.Pressed | btn.Checked)
            {
                e.Graphics.DrawRectangle(new Pen(ItemPressColor, 2.0f), rectangle);
            }

            if (btn.Selected)
                e.Graphics.FillRectangle(new SolidBrush(ItemSelectColor), rectangle); 
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
    
                var rectangle = new Rectangle(0, 0, tls.Width - 4, tls.Height - 4);

                e.Graphics.FillRectangle(new SolidBrush(BackGroundColor), rectangle);

                if(GeneralFrame)
                    e.Graphics.DrawRectangle(new Pen(FrameColor, 1.0f), rectangle);

                if(TextBoxFrame)
                {
                    rectangle = new Rectangle(0, tls.Height - 4 - TextBoxHeight, tls.Width - 4, TextBoxHeight);
                    e.Graphics.DrawRectangle(new Pen(FrameColor, 1.0f), rectangle);
                }

                SizeF messageSize = gr.MeasureString(tls.Text, e.ToolStrip.Font);
                var x = tls.Width / 2 - messageSize.Width / 2;
                var y = tls.Height - messageSize.Height - 2;
                gr.DrawString(tls.Text, e.ToolStrip.Font, SystemBrushes.WindowText, x, y);
            }            
        }
        
    }
}
