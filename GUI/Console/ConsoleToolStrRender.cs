using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazisGUI.Console
{
    public class ConsoleToolStrRender : ToolStripRenderer
    {

        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);

            //rectangle = new Rectangle(0, 0, e.Item.Size.Width - 10, e.Item.Size.Height - 1);
            if (e.Item is ToolStripSplitButton tssBtn)
            {
                if (tssBtn.Selected | tssBtn.Pressed)
                {
                    e.Graphics.FillRectangle(Brushes.DarkGray, rectangle);
                    
                }
                DrawTriangle(e);
            }
        }

        private static void DrawTriangle(ToolStripItemRenderEventArgs e)
        {
            var shiftY = 3;
            var shiftX = 15;
            var points = new Point[]
            {
                        new Point(shiftX,e.Item.Size.Height - 3 - shiftY),
                        new Point(shiftX - 4,e.Item.Size.Height - 0 - shiftY),
                        new Point(shiftX - 7,e.Item.Size.Height - 3 - shiftY)
            };
            e.Graphics.FillPolygon(Brushes.Black, points);
        }       
    }
}
