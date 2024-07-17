using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlsEx
{
    public partial class TabControlEx : TabControl
    {
        public Color SelectColor { get; set; }

        public Color UnSelectColor { get; set; }

        public Color FontColor { get; set; } = Color.Black;


        public TabControlEx()
        {
            InitializeComponent();
        }

        public virtual void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _TextBrush = new System.Drawing.SolidBrush(FontColor);

            // Get the item from the collection. 
            var _TabPage = TabPages[e.Index];        

            // Draw string. Center the text. 
            StringFormat _StringFlags = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Get the real bounds for the tab rectangle. 
            Rectangle _TabBounds = GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle. 
                g.FillRectangle(new SolidBrush(SelectColor), e.Bounds);
            }
            else
            {
                var rec = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width, e.Bounds.Height + 2));
                g.FillRectangle(new SolidBrush(UnSelectColor), rec);
            }


            g.DrawString(TabPages[e.Index].Text, e.Font, _TextBrush,
        new PointF(_TabBounds.X + _TabBounds.Width / 2, _TabBounds.Height - e.Font.Height), new StringFormat(_StringFlags));
        }
    }
}
