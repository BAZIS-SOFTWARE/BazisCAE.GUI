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
        public event Action<object> CheckBoxClickEvent;


        int fullHeigth;
        [Category("General")]
        [Description("Включить или выключить сворачиваемость")]
        public bool IsRollable { get; set; } = true;

        [Category("General")]
        [Description("Изменить состояние проверяемости")]
        public bool CheckState
        {
            get { return chb.Checked; }
            set { chb.Checked = value; }
        }
        [Category("General")]
        [Description("Включить или выключить проверяемость")]
        public bool IsCheckable 
        {
            get { return chb.Visible; }
            set 
            { 
                chb.Visible = value;
            }
        } 

        [Category("General")]
        [Description("Свернуть или развернуть элемент")]

        public bool IsExpanded
        {
            get
            {
                if (IsRollable)
                {
                    var textSize = TextRenderer.MeasureText(Text, Font);
                    if (Height == textSize.Height + this.MinimumSize.Height)
                        return false;
                    else return true;
                }
                else return false;
            }

            set
            {
                if (IsRollable)
                {
                    var textSize = TextRenderer.MeasureText(Text, Font);
                    if (value)
                        Height = fullHeigth;
                    else
                    {
                        var temp = Height;
                        fullHeigth = temp;
                        Height = textSize.Height + this.MinimumSize.Height;
                    }

                }
            }
        }

        public GroupBoxEx()
        {
            InitializeComponent();
        }

        private void GroupBoxEx_Paint(object sender, PaintEventArgs e)
        {
            var textSize = TextRenderer.MeasureText(Text, Font);

            if (IsCheckable)
            {
                chb.Location = new Point(this.Width - (int)(chb.Width * 1.5f), textSize.Height / 2 - chb.Height / 2);
            }

            if (IsRollable)
            {
                var location = new Point(textSize.Width + 4, textSize.Height / 2 - 4);

                if (Height == textSize.Height + this.MinimumSize.Height)
                    ComponentsPainter.PaintSimbolRectangle(e.Graphics, location, "+");
                else
                    ComponentsPainter.PaintSimbolRectangle(e.Graphics, location, "-");
            }

        }

        private void GroupBoxEx_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsRollable)
            {
                var textSize = TextRenderer.MeasureText(Text, Font);
                if (e.Location.X > textSize.Width + 5 & e.Location.X < textSize.Width + 15 && e.Location.Y <= 10)
                {
                    if (Height == textSize.Height + this.MinimumSize.Height)
                    {
                        Height = fullHeigth;
                    }

                    else
                    {
                        var temp = Height;
                        fullHeigth = temp;
                        Height = textSize.Height + this.MinimumSize.Height;
                    }

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

        private void chb_Click(object sender, EventArgs e)
        {
            bool flag;
            if (chb.Checked)
                flag = true;
            else
                flag = false;

            foreach (Control item in this.Controls)
            {
                if (item.Name != "chb")
                    item.Enabled = flag;
            }

            CheckBoxClickEvent?.Invoke(this);

        }
    }
}
