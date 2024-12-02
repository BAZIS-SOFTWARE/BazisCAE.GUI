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
        [Category("Shifting")]
        [Description("Включить сдвиг по клику")]
        public bool SwitchShifting { get; set; } = true;
        [Category("Shifting")]
        [Description("Задать сдвиг по клику")]
        public int IncrementShifting { get; set; } = 50;

        [Category("Shifting")]
        [Description("Задать размер кнопки сдвига")]
        public Size IncrementButtonSize { get; set; } = new Size(50, 5);

        public SplitContainerEx()
        {
            InitializeComponent();
        }

        private void SplitContainerEx_Paint(object sender, PaintEventArgs e)
        {
            if(SwitchShifting)
            {
                Point[] points;
                if (Orientation == Orientation.Vertical)
                {
                    var locRect = new Point(
                        Panel1.Width + SplitterWidth / 2 - IncrementButtonSize.Width / 2,
                        Panel1.Height / 2 - IncrementButtonSize.Height / 2);
                    var rect = new Rectangle(locRect, new Size(IncrementButtonSize.Width, IncrementButtonSize.Height));
                    e.Graphics.DrawRectangle(Pens.DarkGray, rect);

                    var x = Panel1.Width + SplitterWidth / 2;
                    var y = Panel1.Height / 2 - IncrementButtonSize.Height / 2;

                    points = new Point[]
                    {
                        new Point(x + 2, y + 24),
                        new Point(x - 1, y + 27),
                        new Point(x + 2, y + 31)
                    };
                }
                else
                {
                    var locRect = new Point(
                        Panel1.Width / 2 - IncrementButtonSize.Width / 2,
                        Panel1.Height - IncrementButtonSize.Height / 2 + SplitterWidth / 2 - 1);
                    var rect = new Rectangle(locRect, new Size(IncrementButtonSize.Width, IncrementButtonSize.Height));
                    e.Graphics.DrawRectangle(Pens.DarkGray, rect);

                    var x = Panel1.Width / 2 - IncrementButtonSize.Width / 2;
                    var y = Panel1.Height + SplitterWidth / 2 - 1;

                    points = new Point[]
                            {
                        new Point(x + 21, y - 1),
                        new Point(x + 27, y - 1),
                        new Point(x + 24, y + 2)
                            };
                }
                e.Graphics.FillPolygon(Brushes.Black, points);
            }
            
        }

        private void SplitContainerEx_MouseClick(object sender, MouseEventArgs e)
        {
            if(SwitchShifting)
            {
                if (Orientation == Orientation.Vertical)
                {
                    var x = Panel1.Width + SplitterWidth / 2;
                    var y = Panel1.Height / 2 - IncrementButtonSize.Height / 2;

                    if (e.Location.X > x & e.Location.X < x + SplitterWidth &&
                        e.Location.Y > y & e.Location.Y < y + IncrementButtonSize.Height)
                    {
                        IsSplitterFixed = true;
                        SplitterDistance -= IncrementShifting;
                    }
                    else
                        IsSplitterFixed = false;
                }
                else
                {
                    var x = Panel1.Width / 2 - IncrementButtonSize.Width / 2;
                    var y = Panel1.Height + SplitterWidth / 2;

                    if (e.Location.X > x & e.Location.X < x + +IncrementButtonSize.Width &&
                        e.Location.Y > y - 3 & e.Location.Y < y + 3)
                    {
                        IsSplitterFixed = true;
                        SplitterDistance += IncrementShifting;
                    }
                    else
                        IsSplitterFixed = false;
                }
            }
            
        }
    }
}
