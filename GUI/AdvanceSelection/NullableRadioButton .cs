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
            // Снимаем или ставим выбор
            Checked = !Checked;

            // Если нужна логика "только один выбран", её можно сделать на форме,
            // отслеживая событие CheckedChanged
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

            int radius = 6; // фиксированный радиус круга, как у стандартного RadioButton
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Нарисовать внешний круг
            g.DrawEllipse(Pens.Black, 0, 0, radius * 2, radius * 2);

            // Если выбран — закрасить внутренний круг
            if (_checked)
                g.FillEllipse(Brushes.Black, radius / 2, radius / 2, radius, radius);

            // Рисуем текст справа
            using var brush = new SolidBrush(ForeColor);
            g.DrawString(Text, Font, brush, radius * 2 + 4, radius - Font.Height / 2);
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            using var g = CreateGraphics();
            var textSize = g.MeasureString(Text, Font);
            return new Size((int)textSize.Width + 24, Math.Max((int)textSize.Height, 20));
        }
    }
}
