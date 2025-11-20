using BazisGUI.Properties;
using BazisGUI.Scene.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BazisGUI
{
    public partial class BaseForm
    {
        public Button CreateTabButton(string name)
        {
            var btn = new Button();
            btn.Anchor = btnTabНавигатор.Anchor;
            btn.AutoSize = btnTabНавигатор.AutoSize;
            //lbl.Location = new System.Drawing.Point(4, 7);
            
            btn.Name = $"btnTab{name}";

            var g = btnTabНавигатор.CreateGraphics();
            var length = g.MeasureString(btnTabНавигатор.Tag.ToString(), btnTabНавигатор.Font);

            btn.Size = new Size((int)length.Width, (int)length.Height);           

            btn.Margin = btnTabНавигатор.Margin;
            btn.FlatStyle = btnTabНавигатор.FlatStyle;
            btn.Paint += buttonTab_Paint;
            btn.Tag = false;
            return btn;
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            var btn = sender as Button;

            btn.Tag = true;

            for (int i = 0; i < splitContainer3.Panel1.Controls.Count; i++)
            {
                var cntr = splitContainer3.Panel1.Controls[i];
                if (cntr.Name.Contains("btnTab") & cntr.Visible == true)
                {
                    var searchName = cntr.Name.Replace("btnTab", "");
                    var tabPage = splitContainer3.Panel1.Controls[$"cntr{searchName}"];
                    if (cntr.Name != btn.Name)
                    {
                        cntr.Tag = false;
                        tabPage.Visible = false;
                    }                
                    else
                    {
                        tabPage.Visible = true;
                    }
                }

            }
        }


        private void buttonTab_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            var btn = sender as Button;

            if (bool.Parse(btn.Tag.ToString()))
                g.DrawRectangle(new Pen(Color.Black, 1.5f),
                    1, 1, btn.Width - 3, btn.Height - 3);

            // Создаем объект StringFormat
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Center;

            var text = btn.Name.Replace("btnTab", "");

            var length = g.MeasureString(text, btn.Font);
            // Создаем объект RotateTransform
            g.RotateTransform(-90); // Поворачиваем на 45 градусов
            
            // Рисуем текст
            g.DrawString(text, btn.Font, Brushes.Black, -length.Width/2, length.Height, sf);
        }
        
    }
}
