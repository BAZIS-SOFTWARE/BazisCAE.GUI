using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlsEx
{
    public partial class SplitContainerEx : SplitContainer
    {
        public SplitContainerEx()
        {
            InitializeComponent();
        }

        private void SplitContainerEx_Paint(object sender, PaintEventArgs e)
        {
            Point[] points;
            if (Orientation == Orientation.Vertical)
            {
                var locRect = new Point(Panel1.Width - 1, Panel1.Height / 2);
                var rect = new Rectangle(locRect, new Size(5, 50));
                e.Graphics.DrawRectangle(Pens.DarkGray, rect);

                var x = Panel1.Width;
                var y = Panel1.Height / 2;

                points = new Point[]
                {
                        new Point(x + 3, y + 24),
                        new Point(x + 0, y + 27),
                        new Point(x + 3, y + 31)
                };
            }
            else
            {
                var locRect = new Point(Panel1.Width / 2, Panel1.Height - 1);
                var rect = new Rectangle(locRect, new Size(50, 5));
                e.Graphics.DrawRectangle(Pens.DarkGray, rect);

                var x = Panel1.Width / 2;
                var y = Panel1.Height;

                points = new Point[]
                {
                        new Point(x + 21, y),
                        new Point(x + 27, y),
                        new Point(x + 24, y + 3)
                };
            }
            e.Graphics.FillPolygon(Brushes.Black, points);
        }

        private void SplitContainerEx_MouseClick(object sender, MouseEventArgs e)
        {
            if(Orientation == Orientation.Vertical)
            {
                var x = Panel1.Width;
                var y = Panel1.Height / 2;

                if (e.Location.X > x & e.Location.X < x + SplitterWidth &&
                    e.Location.Y > y & e.Location.Y < y + 50)
                {
                    IsSplitterFixed = true;
                    SplitterDistance -= 100;
                }
                else
                    IsSplitterFixed = false;
            }
            else
            {
                var x = Panel1.Width / 2;
                var y = Panel1.Height;

                if (e.Location.X > x & e.Location.X < x + 50 &&
                    e.Location.Y > y - 3 & e.Location.Y < y + 3)
                {
                    IsSplitterFixed = true;
                    SplitterDistance += 50;
                }
                else
                    IsSplitterFixed = false;
            }
        }
    }
}
