using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using UserControlsEx;

namespace BaseModule.Reflect
{
    public partial class ReflectControl : UserControl
    {
        //private CultureInfo culture;

        private float[] Plane { get; set; }
        private Point MouseLastPos { get; set; }

        private bool PreventRedraw { get; set; }

        private string Message { get; set; }

        private Pen Pen { get; set; }
        /// <summary>
        /// Получает имена всех объектов от сцены
        /// </summary>
        public event Action<object, GlObjsNamesEvent> GlObjsEvent;
        /// <summary>
        /// Проверить валидность Gl-объектов
        /// </summary>
        public event Action<CheckGlObjsEvent> CheckGlObjs;
        /// <summary>
        /// Получить или обновить матрицу
        /// </summary>
        public event Action<string, MatrixEvent> MatrixEvent;
        /// <summary>
        /// Обновляет плоскость отражения на сцене
        /// </summary>
        public event Action<string, string, float[]> UpdateReflectPlane;
        /// <summary>
        /// Перерисовывает плоскость отражения на сцене
        /// </summary>
        public event Action RedrawReflectPlane;

        public ReflectControl()
        {
            InitializeComponent();
        }

        private void OnChangeNormal(object sender, EventArgs e)
        {
            var tb = sender as ColorSlider;
            Plane[tb.TabIndex] = tb.Value * 0.01f - 1;
            var label = tableLayoutPanel1.Controls.OfType<Label>()
                                                  .Where(c => c.TabIndex == tb.TabIndex)
                                                  .First();
            var text = label.Text.Split(' ');
            label.Text = text[0] + " " + Plane[tb.TabIndex].ToString("0.##");
            if (!PreventRedraw && comboBox1.SelectedItem != null)
            {
                UpdateReflectPlane?.Invoke(comboBox1.SelectedItem.ToString(), textBox2.Text, Plane);
                RedrawReflectPlane?.Invoke();
            }
        }

        private void OnEnableClipPlane(object sender, EventArgs e)
        {
            var controls = tableLayoutPanel1.Controls.OfType<System.Windows.Forms.Control>()
                                                     .Where(c => !c.Equals(sender));
            foreach (var control in controls)
                control.Enabled = checkBox1.Checked;
            if (comboBox1.SelectedItem != null)
            {
                var name = checkBox1.Checked ? comboBox1.SelectedItem.ToString() : "";
                UpdateReflectPlane?.Invoke(name, textBox2.Text, Plane);
                RedrawReflectPlane?.Invoke();
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && comboBox1.SelectedItem != null)
            {
                var sign = Math.Sign(e.X - MouseLastPos.X);
                var delta = float.Parse(domainUpDown1.Text, NumberStyles.Any);
                Plane[3] += sign * delta;
                textBox1.Text = Plane[3].ToString("0.##");
                UpdateReflectPlane?.Invoke(comboBox1.SelectedItem.ToString(), textBox2.Text, Plane);
                RedrawReflectPlane?.Invoke();
            }
            MouseLastPos = e.Location;
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
            if (comboBox1.SelectedItem != null)
            {
                var rBtn = sender as RadioButton;
                var strVec = rBtn.Tag.ToString().Split(' ');
                var vec = strVec.Select(x => float.Parse(x)).ToArray();
                var vector = TransformVector(vec);
                UpdateControlNormal(vector);
                UpdateReflectPlane?.Invoke(comboBox1.SelectedItem.ToString(), textBox2.Text, Plane);
                RedrawReflectPlane?.Invoke();
            }
        }

        ///Обновлять список при каждом клике
        private void OnChoiceModel(object sender, EventArgs e)
        {
            GetGlObjs();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            //culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            //culture.NumberFormat.CurrencyDecimalSeparator = ".";
            Pen = new Pen(SystemColors.Control);
            Plane = new float[4] { 1, 0, 0, 0 };
            domainUpDown1.SelectedItem = 2;
            GetGlObjs();
            comboBox1.SelectedItem = comboBox1.Items.IndexOf("Элементы2D") == -1 ? null : "Элементы2D";
        }

        private void GetGlObjs()
        {
            var glObjsEvent = new GlObjsNamesEvent();
            GlObjsEvent?.Invoke(this, glObjsEvent);
            foreach (var item in glObjsEvent.GlNames)
                if (!comboBox1.Items.Contains(item))
                    comboBox1.Items.Add(item);
        }

        private void OnChoiceSource(object sender, EventArgs e)
        {
            ChangeVBObject();
        }
        private void OnResetShifting(object sender, EventArgs e)
        {
            Plane[3] = 0;
            textBox1.Text = "0";
            if (!PreventRedraw && comboBox1.SelectedItem != null)
            {
                UpdateReflectPlane?.Invoke(comboBox1.SelectedItem.ToString(), textBox2.Text, Plane);
                RedrawReflectPlane?.Invoke();
            }
        }

        private void ChangeVBObject()
        {
            if (comboBox1.SelectedItem != null && checkBox1.Checked)
            {
                var ev = new CheckGlObjsEvent();
                ev.OriginalGlName = comboBox1.SelectedItem.ToString();
                ev.CopyGlName = textBox2.Text;
                CheckGlObjs?.Invoke(ev);
                if (string.IsNullOrEmpty(ev.Message))
                {
                    label7.Text = "";
                    toolTip1.SetToolTip(label7, "");
                    var vec = TransformVector(new float[] { Plane[0], Plane[1], Plane[2], 0 });
                    UpdateControlNormal(vec);
                    UpdateReflectPlane?.Invoke(comboBox1.SelectedItem.ToString(), textBox2.Text, Plane);
                    RedrawReflectPlane?.Invoke();
                }
                else
                {
                    label7.Text = "!";//Лучше помещать картинку с восклицательным знаком(не прошел валидацию) как в Базисе!
                    toolTip1.SetToolTip(label7, ev.Message);
                }
            }
        }

        private void OnSetCopyName(object sender, EventArgs e)
        {
            ChangeVBObject();
        }


        private void UpdateControlNormal(Vector<float> vector)
        {
            PreventRedraw = true;
            colorSlider1.Value = (int)(vector[0] * 100 + 100);
            colorSlider2.Value = (int)(vector[1] * 100 + 100);
            colorSlider3.Value = (int)(vector[2] * 100 + 100);
            OnResetShifting(this, null);
            PreventRedraw = false;
        }

        private Vector<float> TransformVector(float[] vector)
        {
            var evnt = new MatrixEvent();
            var name = comboBox1.SelectedItem.ToString();
            MatrixEvent?.Invoke(name, evnt);
            var mat = Matrix<float>.Build.Dense(4, 4, evnt.Matrix);
            mat = mat.Inverse();
            var vec = Vector<float>.Build.Dense(vector);
            vec = vec.Normalize(2);
            vec = mat.Multiply(vec);
            vec = vec.Normalize(2);
            vec[0] = vec[0].Round(2);
            vec[1] = vec[1].Round(2);
            vec[2] = vec[2].Round(2);
            return vec;
        }
    }

    public class MatrixEvent : EventArgs
    {
        public float[] Matrix { get; set; }
    }

    public class GlObjsNamesEvent : EventArgs
    {
        public IEnumerable<string> GlNames { get; set; }
    }

    public class CheckGlObjsEvent : EventArgs
    {
        public string OriginalGlName { get; internal set; }
        public string CopyGlName { get; internal set; }
        public string Message { get; set; }
    }
}