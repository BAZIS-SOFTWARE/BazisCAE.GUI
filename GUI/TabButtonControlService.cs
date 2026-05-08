using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BazisGUI
{
    public class TabButtonControlService
    {
        private Panel container;
        private Dictionary<string, Button> buttons;
        private Dictionary<string, Control> controls;

        public TabButtonControlService(Panel container) 
        { 
            this.container = container;
            buttons = new();
            controls = new();
        }

        public Button GetButton(string name) => buttons[name];
        public Control GetControl(string name) => controls[name];
        public IEnumerable<string> GetNames() => buttons.Keys;

        public void AddControl(string name, Control control)
        {
            name = name.Replace("cntr", "").Replace("btnTab", "");
            if (buttons.ContainsKey(name))
                return;

            var btn = CreateTabButton(name);

            control.Name = $"cntr{name}";
            control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            SetControlSize(control);

            container.Controls.Add(btn);
            container.Controls.Add(control);
            buttons[name] = btn;
            controls[name] = control;

            control.BringToFront();
        }

        public void RemoveControl(string name)
        {
            if (!buttons.ContainsKey(name))
                return;

            container.Controls.Remove(GetButton(name));
            container.Controls.Remove(GetControl(name));

            buttons.Remove(name);
            controls.Remove(name);
        }

        public Button CreateTabButton(string name)
        {
            var btn = new Button();
            if (buttons.Count > 0)
            {
                var first = buttons.First().Value;

                btn.Anchor = first.Anchor;
                btn.AutoSize = first.AutoSize;

                var g = first.CreateGraphics();
                var textSize = g.MeasureString(name, first.Font);
                btn.Size = new Size((int)textSize.Height, (int)textSize.Width);

                btn.Margin = first.Margin;
                btn.FlatStyle = first.FlatStyle;
            }

            else
            {
                var refButton = new Button();
                btn.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                btn.AutoSize = false;

                var g = refButton.CreateGraphics();
                var textSize = g.MeasureString(name, refButton.Font);
                btn.Size = new Size((int)textSize.Height, (int)textSize.Width);

                btn.Margin = refButton.Margin;
                btn.FlatStyle = default;
            }

            btn.MinimumSize = new Size(27, 130);
            btn.Tag = true;
            btn.Name = $"btnTab{name}";
            //btn.Text = name;

            btn.MouseDown += button_MouseDown;
            btn.Paint += buttonTab_Paint;

            return btn;
        }

        public void ShowTabButton(string btnName)
        {
            var max_y = 0;

            for (int i = 0; i < container.Controls.Count; i++)
            {
                var cntr = container.Controls[i];
                if (cntr.Name.Contains("btnTab") && cntr.Visible && cntr.Location.Y > max_y)
                    max_y = cntr.Location.Y;
            }

            var show = container.Controls.Find(btnName, false)[0];
            show.Visible = true;
            show.Location = new Point(0, max_y + show.Height + show.Margin.Bottom);
        }

        public void HideTabButton(string btnName)
        {
            var hide = container.Controls.Find(btnName, false)[0];
            hide.Visible = false;

            for (int i = 0; i < container.Controls.Count; i++)
            {
                var cntr = container.Controls[i];
                if (cntr.Name.Contains("btnTab") && cntr.Visible && cntr.Location.Y > hide.Location.Y)
                {
                    var temp_x = cntr.Location.X;
                    var temp_y = cntr.Location.Y;
                    cntr.Location = new Point(temp_x, temp_y - hide.Location.Y);
                }
            }
        }

        private void SetControlSize(Control control)
        {
            var btn = buttons.Values.FirstOrDefault();
            var maxWidth = btn == null ? 6 : btn.Margin.Left + btn.Margin.Right;

            var width = container.Width - container.Padding.Right - container.Padding.Left - control.Margin.Right - control.Margin.Left - maxWidth;
            var height = container.Height - container.Padding.Top - container.Padding.Bottom - control.Margin.Top - control.Margin.Bottom;

            control.Size = new Size(width, height);
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            var btn = sender as Button;
            btn.Tag = true;

            for (int i = 0; i < container.Controls.Count; i++)
            {
                var cntr = container.Controls[i];
                if (cntr.Name.Contains("btnTab") & cntr.Visible)
                {
                    var tabPage = GetControl(cntr.Name.Replace("cntr", "").Replace("btnTab", ""));
                    SetControlSize(tabPage);

                    if (cntr.Name != btn.Name)
                    {
                        cntr.Tag = false;
                        tabPage.Visible = false;

                    }
                    else
                    {
                        tabPage.Visible = true;
                        tabPage.BringToFront();
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
