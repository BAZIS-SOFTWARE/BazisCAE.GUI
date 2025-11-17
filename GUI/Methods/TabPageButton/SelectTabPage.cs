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
            btn.Anchor = btnSelect.Anchor;
            btn.AutoSize = btnSelect.AutoSize;
            //lbl.Location = new System.Drawing.Point(4, 7);
            btn.Name = name;

            var g = btn.CreateGraphics();
            var length = g.MeasureString(btn.Tag.ToString(), btn.Font);

            btn.Size = new Size((int)length.Width, (int)length.Height);
            btn.Text = name;

            btn.Margin = new Padding(0, 0, 3, 3);
            btn.FlatStyle = FlatStyle.Flat;

            return btn;
        }
        private void button1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            var btn = sender as Button;

            //if (bool.Parse(btn.Tag.ToString()))
            //    g.DrawRectangle(new Pen(Color.Black, 1.5f),
            //        1, 1, btn.Width - 3, btn.Height - 3);

            // Создаем объект StringFormat
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Center;

            var length = g.MeasureString(btn.Tag.ToString(), btn.Font);
            // Создаем объект RotateTransform
            g.RotateTransform(-90); // Поворачиваем на 45 градусов
            
            // Рисуем текст
            g.DrawString(btn.Tag.ToString(), btn.Font, Brushes.Black, -length.Width/2, length.Height, sf);
        }
        
    }
}
