using BazisGUI.Localization;
using MasterInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlsEx;

namespace BazisGUI
{
    public class TabButtonControlService
    {
        private IContainer container;
        private Dictionary<string, (Button, Control)> linkedComponents;

        public TabButtonControlService(IContainer container) 
        { 
            this.container = container;
        }

        public Button GetButton(string name) => linkedComponents[name].Item1;
        public Control GetControl(string name) => linkedComponents[name].Item2;
        public IEnumerable<string> GetNames() => linkedComponents.Keys;

        public void Provide(string name, Control control)
        {
            if (control is ILocalizableHeaderControl locControl)
            {

            }
            else
            {

            }
        }

        public Button CreateTabButton(string name)
        {
            var btn = new Button();
            if (linkedComponents.Count > 0)
            {
                var first = linkedComponents.First().Value.Item1;

                btn.Anchor = first.Anchor;
                btn.AutoSize = first.AutoSize;

                var g = first.CreateGraphics();
                var textSize = g.MeasureString(name, first.Font);
                btn.Size = new Size((int)textSize.Width, (int)textSize.Height);

                btn.Margin = first.Margin;
                btn.FlatStyle = first.FlatStyle;
            }

            else
            {
                btn.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                btn.AutoSize = true;

                var g = default(Button).CreateGraphics();
                var textSize = g.MeasureString(name, default(Button).Font);
                btn.Size = new Size((int)textSize.Width, (int)textSize.Height);

                btn.Margin = default(Button).Margin;
                btn.FlatStyle = default;
            }

            btn.Name = $"btnTab{name}";
            btn.Text = name;
            btn.Paint += buttonTab_Paint;

            return btn;
        }

        public void ShowTabButton(string btnName)
        {
            var max_y = 0;

            for (int i = 0; i < splitContainer3.Panel1.Controls.Count; i++)
            {
                var cntr = splitContainer3.Panel1.Controls[i];
                if (cntr.Name.Contains("btnTab") & cntr.Visible == true)
                    if (cntr.Location.Y > max_y)
                        max_y = cntr.Location.Y;
            }

            var show = splitContainer3.Panel1.Controls.Find(btnName, false)[0];
            show.Visible = true;
            show.Location = new Point(0, max_y + show.Height + show.Margin.Bottom);
        }

        public void HideTabButton(string btnName)
        {
            var hide = splitContainer3.Panel1.Controls.Find(btnName, false)[0];
            hide.Visible = false;

            for (int i = 0; i < splitContainer3.Panel1.Controls.Count; i++)
            {
                var cntr = splitContainer3.Panel1.Controls[i];
                if (cntr.Name.Contains("btnTab") & cntr.Visible == true)
                {
                    if (cntr.Location.Y > hide.Location.Y)
                    {
                        var temp_x = cntr.Location.X;
                        var temp_y = cntr.Location.Y;
                        cntr.Location = new Point(temp_x, temp_y -
                            hide.Location.Y);
                    }

                }
            }
        }




        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            var btn = sender as Button;

            btn.Tag = true;

            for (int i = 0; i < splitContainer3.Panel1.Controls.Count; i++)
            {
                var cntr = splitContainer3.Panel1.Controls[i];
                if (cntr.Name.Contains("btnTab") & cntr.Visible)
                {
                    if (cntr is ILocalizableHeaderControl locCntr)
                    {

                    }

                    else if (cntr is ILocalizableMaster locMaster)
                    {

                    }

                    else
                    {

                    }

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

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (bool.Parse(btn.Tag.ToString()))
            {
                using var pen = new Pen(Color.Black, 1.5f);
                g.DrawRectangle(pen, 1, 1, btn.Width, btn.Height);
            }

            var text = btn.Name.Replace("btnTab", "");
            var size = g.MeasureString(text, btn.Font);

            var state = g.Save();

            g.TranslateTransform(btn.Width / 2f, btn.Height / 2f);
            g.RotateTransform(-90);

            g.DrawString(text, btn.Font, Brushes.Black, -size.Width / 2f, -size.Height / 2f);
            g.Restore(state);
        }
    }
}
