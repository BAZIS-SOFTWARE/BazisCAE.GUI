using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UserControlsEx
{
    public static class ComponentsPainter
    {
        public static Font Font { get; set; } = new Font("Arial", 10);
        public static int ScreenDPI { get; set; } = 96; // 96 - 100%, 120 - 125%, 144 - 150%

        public static float ScreenScale 
        {
            get 
            {
                if (ScreenDPI == 120)
                    return 1.25f;
                else if (ScreenDPI == 144)
                    return 1.5f;       
                else return 1.0f;
            }
        }

        public static void PaintUnpinnedRectangle(Graphics graphics, Point locRect)
        {
            Pen blackPen1 = new Pen(Color.FromArgb(255, 0, 0, 0), 1);

            var rect = new Rectangle(locRect, new Size(8, 8));

            //graphics.DrawRectangle(blackPen1, rect);

            rect = new Rectangle(new Point(locRect.X + 2, locRect.Y), new Size(4, 4));

            graphics.DrawRectangle(blackPen1, rect);

            var loc1 = new Point(locRect.X + 4, locRect.Y + 4);
            var loc2 = new Point(locRect.X + 4, locRect.Y + 8);

            graphics.DrawLine(blackPen1, loc1, loc2);
        }

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

        public static void PaintFrameRectangle(Graphics graphics, float thickness,Color color,Point location, int width, int heigth)
        {
            var pen = new Pen(color, thickness);
            var rect = new Rectangle(location, new Size(width, heigth));
            graphics.DrawRectangle(pen, rect);
        }

        public static void PaintSimbolRectangle(Graphics graphics, Point location, string simb)
        {
            Pen blackPen1 = new Pen(Color.FromArgb(255, 0, 0, 0), 1);

            var rect = new Rectangle(location, new Size(8, 8));

            graphics.DrawRectangle(blackPen1, rect);

            if (simb == "+")
            {
                Pen blackPen2 = new Pen(Color.FromArgb(255, 0, 0, 0), 1.5f);

                var loc1 = new Point(location.X + 2, location.Y + 4);
                var loc2 = new Point(location.X + 6, location.Y + 4);

                graphics.DrawLine(blackPen2, loc1, loc2);

                var loc3 = new Point(location.X + 4, location.Y + 2);
                var loc4 = new Point(location.X + 4, location.Y + 6);

                graphics.DrawLine(blackPen2, loc3, loc4);
            }
            else if (simb == "-")
            {
                Pen blackPen2 = new Pen(Color.FromArgb(255, 0, 0, 0), 1.5f);

                var loc1 = new Point(location.X + 2, location.Y + 4);
                var loc2 = new Point(location.X + 6, location.Y + 4);

                graphics.DrawLine(blackPen2, loc1, loc2);
            }
        }
    }
}
