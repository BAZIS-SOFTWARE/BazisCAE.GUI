using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BazisGUI.AdvanceSelection
{
    public class NullableRadioButton : Control
    {
        private bool _checked;

        public NullableRadioButton()
        {
            this.AutoSize = true;
            this.Cursor = Cursors.Hand;

            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            this.BackColor = Color.Transparent;
            this.Click += NullableRadioButton_Click;
        }

        private void NullableRadioButton_Click(object sender, EventArgs e)
        {
            Checked = !Checked;
            CheckedChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool Checked
        {
            get => _checked;
            set
            {
                if (_checked != value)
                {
                    _checked = value;
                    Invalidate();
                }
            }
        }

        public event EventHandler CheckedChanged;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            float scale = DeviceDpi / 96f;
            int radius = (int)(6 * scale); // фиксированный радиус круга, как у стандартного RadioButton
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Цвета в зависимости от состояния
            Color borderColor = Enabled ? Color.Black : SystemColors.GrayText;
            Color fillColor = Enabled ? Color.Black : SystemColors.GrayText;
            Color textColor = Enabled ? ForeColor : SystemColors.GrayText;

            using var borderPen = new Pen(borderColor);
            using var textBrush = new SolidBrush(textColor);
            using var fillBrush = new SolidBrush(fillColor);

            // Нарисовать внешний круг
            g.DrawEllipse(borderPen, 0, 0, radius * 2, radius * 2);

            // Если выбран — закрасить внутренний круг
            if (_checked)
                g.FillEllipse(fillBrush, radius / 2, radius / 2, radius, radius);

            // Рисуем текст справа
            using var brush = new SolidBrush(ForeColor);
            g.DrawString(Text, Font, textBrush, radius * 2 + 4, radius - Font.Height / 2);
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            float scale = DeviceDpi / 96f;
            int radius = (int)(6 * scale);

            using var g = CreateGraphics();
            var textSize = g.MeasureString(Text, Font);

            int width = radius * 2 + (int)(4 * scale) + (int)textSize.Width;
            int height = Math.Max(radius * 2, (int)textSize.Height);

            return new Size(width, height);
        }

        protected override void OnDpiChangedAfterParent(EventArgs e)
        {
            base.OnDpiChangedAfterParent(e);
            Invalidate();
            PerformLayout();
        }
    }
}
