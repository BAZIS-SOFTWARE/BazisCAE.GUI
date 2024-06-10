using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseModule.ControlsLib
{
    public partial class TabControlEx : TabControl
    {
        public Color SelectColor { get; set; }


        public TabControlEx()
        {
            InitializeComponent();
        }

        public virtual void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _TextBrush;

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

                _TextBrush = new SolidBrush(System.Drawing.Color.White);
            }
            else
            {
                _TextBrush = new System.Drawing.SolidBrush(e.ForeColor);
            }
            g.DrawString(TabPages[e.Index].Text, e.Font, _TextBrush,
        new PointF(_TabBounds.X + _TabBounds.Width / 2, _TabBounds.Height - e.Font.Height), new StringFormat(_StringFlags));
        }
    }
}
