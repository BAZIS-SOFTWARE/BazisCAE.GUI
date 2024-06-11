using BaseModule.ControlsComponents;
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
    public partial class GroupBoxEx : GroupBox
    {
        public int ShrinkageHeigth { get; set; } = 17;
        public GroupBoxEx()
        {
            InitializeComponent();
            if (ComponentsPainter.ScreenDPI == 120)
                ShrinkageHeigth = 20;
            if (ComponentsPainter.ScreenDPI == 144)
                ShrinkageHeigth = 23;
        }

        private void GroupBoxEx_Paint(object sender, PaintEventArgs e)
        {
            var textSize = TextRenderer.MeasureText(Text, Font);

            if (Height == ShrinkageHeigth)
            {
                ComponentsPainter.PaintSimbolRectangle(e.Graphics, new Point(textSize.Width + 4, textSize.Height / 2 - 4), "+");
            }
            else
            {
                ComponentsPainter.PaintSimbolRectangle(e.Graphics, new Point(textSize.Width + 4, textSize.Height / 2 - 4), "-");
            }
        }

        private void GroupBoxEx_MouseClick(object sender, MouseEventArgs e)
        {
            var textSize = TextRenderer.MeasureText(Text, Font).Width;
            if (e.Location.X > textSize + 5 & e.Location.X < textSize + 15 && e.Location.Y <= 10)
            {
                if (Height == ShrinkageHeigth)
                {
                    var heigth = 0;
                    GetChildControlExpandHeight(this, ref heigth);
                    Height = heigth;
                }

                else Height = ShrinkageHeigth;
            }
        }

        public void GetChildControlExpandHeight(Control cntr, ref int heigth)
        {
            var gap = 0;

            var mediumGap = 6;
            var borderStep = 20;
            heigth = borderStep;
            if (ComponentsPainter.ScreenDPI == 120)
            {
                mediumGap = 8;
                borderStep = 22;
            }

            if (ComponentsPainter.ScreenDPI == 144)
            {
                mediumGap = 10;
                borderStep = 24;
            }

            foreach (Control control in cntr.Controls)
            {
                if (control.Controls.Count > 0)
                {
                    heigth = 0;
                    GetChildControlExpandHeight(control, ref heigth);
                    heigth -= borderStep;
                }

                else
                {
                    if (control is TextBox txb | control is ComboBox cmb | control is Button | control is PictureBox | control is RadioButton)
                    {
                        heigth += control.Size.Height;
                        gap += mediumGap;
                    }
                }
            }
            heigth = heigth + gap + borderStep;
        }
    }
}
