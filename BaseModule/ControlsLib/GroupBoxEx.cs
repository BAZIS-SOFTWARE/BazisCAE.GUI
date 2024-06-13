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
        int fullHeigth;



        public GroupBoxEx()
        {
            InitializeComponent();
        }

        public void Expand()
        {

        }

        private void GroupBoxEx_Paint(object sender, PaintEventArgs e)
        {
            var textSize = TextRenderer.MeasureText(Text, Font);

            if (Height == textSize.Height + 10)
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
            var textSize = TextRenderer.MeasureText(Text, Font);
            if (e.Location.X > textSize.Width + 5 & e.Location.X < textSize.Width + 15 && e.Location.Y <= 10)
            {
                if (Height == textSize.Height + 10)
                {
                    Height = fullHeigth;
                }

                else
                {
                    var temp = Height;
                    fullHeigth = temp;
                    Height = textSize.Height + 10;
                }

            }
        }

        public void GetChildControlExpandHeight(Control cntr, ref int heigth)
        {
            var borderStep = 20;

            foreach (Control control in cntr.Controls)
            {
                if (control.Controls.Count > 0)
                {
                    GetChildControlExpandHeight(control, ref heigth);
                    //heigth -= borderStep;
                }

                else
                {
                    if (control is TextBox txb | control is ComboBox cmb | control is Button | control is PictureBox | control is RadioButton)
                    {
                        if (control.Location.Y > heigth)
                        {
                            heigth = control.Location.Y + control.Height;
                        }    
                    }
                }
            }
            heigth += borderStep;
        }
    }
}
