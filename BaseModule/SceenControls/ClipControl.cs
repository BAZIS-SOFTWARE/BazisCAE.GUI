using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using UserControlsEx;

namespace BaseModule.SceenControls
{
    /// <summary>
    /// Режим отсечения, устанавливаемый при отрисовке модели
    /// </summary>
    public enum ClipRegime
    {
        /// <summary>
        /// По умолчанию, с разрезанием элемента
        /// </summary>
        Default,
        /// <summary>
        /// Послойное, сохраняет элементы только в месте сечения
        /// </summary>
        Layered,
        /// <summary>
        /// Полное отображение 3д элементов в месте сечения и в положительной полуплоскости сечения
        /// </summary>
        KeepElement
    }
    public partial class ClipControl : UserControl
    {
        private CultureInfo culture;
        private bool IsMouseDown { get; set; }
        private Point MouseLastPos { get; set; }

        private bool PreventRedraw { get; set; }

        private Pen Pen { get; set; }

        private Plane plane;
        /// <summary>
        /// Включить\выключить плоскость отсечения
        /// </summary>
        public event Action<bool> SwitchOnOff;
        /// <summary>
        /// Задать плоскость отсечения
        /// </summary>
        public event Action<Plane> SetClipPlaneEvent;
        /// <summary>
        /// Перерисовывает плоскость отсечения на сцене
        /// </summary>
        public event Action RedrawClipPlane;
        /// <summary>
        /// Смена режима отображения для 3д элементов
        /// </summary>
        public event Action<ClipRegime> ChangeClipMode;
        /// <summary>
        /// Смена толщины слоя
        /// </summary>
        public event Action<float> ChangeLayerThickness;
        public ClipControl()
        {
            InitializeComponent();
            domainUpDown1.SelectedItem = 2;
            culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.NumberFormat.CurrencyDecimalSeparator = ".";
            Pen = new Pen(SystemColors.Control);

            plane.Z = -1;
        }

        private void OnChangeValue(object sender, EventArgs e)
        {
            if (colorSlider1.Value == colorSlider2.Value && colorSlider1.Value == colorSlider3.Value && colorSlider1.Value == 100)
                return;
            var tb = sender as ColorSlider;
            var value = (tb.Value - 100) * 0.01f;
            var label = tableLayoutPanel1.Controls.OfType<Label>()
                                                  .Where(c => c.TabIndex == tb.TabIndex)
                                                  .First();
            var text = label.Text.Split(' ');
            label.Text = text[0] + " " + value.ToString("0.##");
            if (tb.TabIndex == 0)
                plane.X = value;
            else if (tb.TabIndex == 1)
                plane.Y = value;
            else
                plane.Z = value;
            if (!PreventRedraw)
            {
                SetClipPlaneEvent(plane);
                RedrawClipPlane?.Invoke();
            }
        }

        //private void NormalizeDirection()
        //{
        //    var isZeroNormal = colorSlider1.Value == colorSlider2.Value &&
        //                       colorSlider2.Value == colorSlider3.Value &&
        //                       colorSlider1.Value == 100;
        //    if (!isZeroNormal)
        //    {
        //        //var normal = Vector.GetVectorNorm(ClipPlane.Normal);
        //        ClipPlane.Normal._x = normal._x;
        //        ClipPlane.Normal._y = normal._y;
        //        ClipPlane.Normal._z = normal._z;купать?
        //    }
        //}

        private void OnEnableClipPlane(object sender, EventArgs e)
        {
            var controls = tableLayoutPanel1.Controls.OfType<Control>()
                                                     .Where(c => !c.Equals(sender));
            foreach (var control in controls)
                control.Enabled = checkBox1.Checked;

            var isObjCliped = checkBox1.Checked ? true : false; 
            panel2.Enabled = checkBox1.Checked;
            radioButton7.Enabled = checkBox1.Checked;
            radioButton8.Enabled = checkBox1.Checked;
            radioButton9.Enabled = checkBox1.Checked;

            label6.Enabled = false;
            textBox2.Enabled = false;

            SwitchOnOff?.Invoke(isObjCliped);
            SetClipPlaneEvent?.Invoke(plane);
            RedrawClipPlane?.Invoke();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked)
            {
                MouseLastPos = e.Location;
                IsMouseDown = true;
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown && checkBox1.Checked)
            {
                var txtControl = sender as Control;
                var delta = float.Parse(domainUpDown1.Text, NumberStyles.Any, culture);
                var sign = Math.Sign(e.X - MouseLastPos.X);
                MouseLastPos = e.Location;
                if (txtControl.Equals(textBox1))
                {
                    plane.D += sign * delta;
                    txtControl.Text = plane.D.ToString("0.##");
                }
                else
                {
                    var temp = float.Parse(txtControl.Text, NumberStyles.Any, culture) + sign * delta;
                    if (temp < 0.01f)
                        return;
                    txtControl.Text = temp.ToString("0.##");
                    ChangeLayerThickness?.Invoke(temp);
                }
                SetClipPlaneEvent?.Invoke(plane);
                RedrawClipPlane?.Invoke();
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var rBtn = sender as RadioButton;
            var rect = e.ClipRectangle;
            var borderSize = rBtn.FlatAppearance.BorderSize;
            var leftColor = rBtn.Checked ? SystemColors.ControlText : SystemColors.ControlLightLight;
            var rightColor = rBtn.Checked ? SystemColors.ControlLightLight : SystemColors.ControlText;
            var leftBorder = new PointF[] { new PointF(rect.Left, rect.Bottom), new PointF(rect.Left, rect.Top),
                                            new PointF(rect.Left, rect.Top), new PointF(rect.Right, rect.Top)};
            var rightBorder = new PointF[] { new PointF(rect.Left, rect.Bottom - borderSize), new PointF(rect.Right, rect.Bottom - borderSize),
                                             new PointF(rect.Right - borderSize, rect.Bottom), new PointF(rect.Right - borderSize, rect.Top)};
            Pen.Color = leftColor;
            Pen.Width = borderSize;
            e.Graphics.DrawLines(Pen, leftBorder);
            Pen.Color = rightColor;
            e.Graphics.DrawLines(Pen, rightBorder);
        }

        private void OnChoicePlane(object sender, EventArgs e)
        {
            var rBtn = sender as RadioButton;
            PreventRedraw = true;
            var values = rBtn.Tag.ToString().Split(' ');
            var activeTb = tableLayoutPanel1.Controls.OfType<ColorSlider>()
                                                     .Where(v => v.TabIndex == rBtn.TabIndex)
                                                     .First();
            activeTb.Value = int.Parse(values[rBtn.TabIndex]);
            var inactiveTbs = tableLayoutPanel1.Controls.OfType<ColorSlider>()
                                              .Where(v => v.TabIndex != rBtn.TabIndex)
                                              .ToList();
            for (var i = 0; i < inactiveTbs.Count; ++i)
            {
                var control = inactiveTbs[i];
                control.Value = int.Parse(values[control.TabIndex]);
            }
            PreventRedraw = false;

            SetClipPlaneEvent?.Invoke(plane);
            RedrawClipPlane?.Invoke();
        }

        private void OnResetShifting(object sender, EventArgs e)
        {
            plane.D = 0;
            textBox1.Text = "0";
            SetClipPlaneEvent?.Invoke(plane);
            RedrawClipPlane?.Invoke();
        }

        private void OnChangeDrawMode(object sender, EventArgs e)
        {
            var control = sender as RadioButton;

            label6.Enabled = radioButton9.Checked;
            textBox2.Enabled = radioButton9.Checked;

            var modeStr = control.Tag.ToString();

            var regime = (ClipRegime)Enum.Parse(typeof(ClipRegime), modeStr);
            ChangeClipMode?.Invoke(regime);
            RedrawClipPlane?.Invoke();
        }
    }
}
