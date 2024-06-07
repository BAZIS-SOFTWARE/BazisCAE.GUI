using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaseModule.ControlsComponents
{
    public static class ComponentsPainter
    {
        public static Font Font { get; set; }
        public static void PaintCloseRectangle(Graphics graphics, Point locRect)
        {
            Pen blackPen1 = new Pen(Color.FromArgb(255, 0, 0, 0), 1);

            var rect = new Rectangle(locRect, new Size(8, 8));

            graphics.DrawRectangle(blackPen1, rect);

            Pen blackPen2 = new Pen(Color.FromArgb(255, 0, 0, 0), 1.5f);

            var loc1 = new Point(locRect.X + 1, locRect.Y + 1);
            var loc2 = new Point(locRect.X + 7, locRect.Y + 7);

            graphics.DrawLine(blackPen2, loc1, loc2);

            var loc3 = new Point(locRect.X + 1, locRect.Y + 7);
            var loc4 = new Point(locRect.X + 7, locRect.Y + 1);

            graphics.DrawLine(blackPen2, loc3, loc4);
        }

        public static void PaintGradientRectangle(Graphics graphics, Point location, int width, int heigth, Color upColor, Color downColor)
        {
            var linGrBrush = new LinearGradientBrush(
            new Point(location.X, location.Y),
            new Point(location.X, heigth),
            downColor,   // Opaque red
   upColor);  // Opaque blue

            var rect = new Rectangle(location, new Size(width, heigth));

            graphics.FillRectangle(linGrBrush, rect);
        }
    }
}
