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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaseModule.Reflect
{
    public partial class ReflectControl : UserControl
    {
        private Point MouseLastPos { get; set; }

        private bool PreventRedraw { get; set; }

        private Pen Pen { get; set; }

        /// <summary>
        /// Обновляет плоскость отражения на сцене
        /// </summary>
        public event Action<string, float[]> UpdateReflectPlane;

        public event Action<string, float[]> CreateReflectObj;

        public event Action<string> ShowObjs;

        public ReflectControl()
        {
            InitializeComponent();
        }

        private void OnChangeNormal(object sender, EventArgs e)
        {
            //var tb = sender as ColorSlider;

            //var label = tableLayoutPanel1.Controls.OfType<Label>()
            //                                      .Where(c => c.TabIndex == tb.TabIndex)
            //                                      .First();
            //var text = label.Text.Split(' ');
            //label.Text = text[0] + " " + Plane[tb.TabIndex].ToString("0.##");

            var plane = new float[4];
            plane[0] = sldA.Value / 100.0f;
            plane[1] = sldB.Value / 100.0f;
            plane[2] = sldC.Value / 100.0f;
            plane[3] = float.Parse(txbD.Text);

            if (!PreventRedraw && comboBox1.SelectedItem != null)
            {
                UpdateReflectPlane?.Invoke(comboBox1.SelectedItem.ToString(), plane);
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && comboBox1.SelectedItem != null)
            {
                var sign = Math.Sign(e.X - MouseLastPos.X);
                var delta = float.Parse(txudDeltaD.Text, NumberStyles.Any);

                var d = float.Parse(txbD.Text);
                d += sign * delta;
                txbD.Text = d.ToString("0.##");

                var plane = new float[4];
                plane[0] = sldA.Value / 100.0f;
                plane[1] = sldB.Value / 100.0f;
                plane[2] = sldC.Value / 100.0f;
                plane[3] = d;

                UpdateReflectPlane?.Invoke(comboBox1.SelectedItem.ToString(), plane);
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
            var rBtn = sender as RadioButton;
            var strVec = rBtn.Tag.ToString().Split(' ');
            var vec = strVec.Select(x => float.Parse(x)).ToArray();

            sldA.Value = (int)(vec[0] * 100);
            sldB.Value = (int)(vec[1] * 100);
            sldC.Value = (int)(vec[2] * 100);

            if (comboBox1.SelectedItem != null)
            {
                //var vector = TransformVector(vec);
                //UpdateControlNormal(vector);
                UpdateReflectPlane?.Invoke(comboBox1.SelectedItem.ToString(), vec);
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Pen = new Pen(SystemColors.Control);
            //Plane = new float[4] { 1, 0, 0, 0 };
            txudDeltaD.SelectedItem = 2;
        }

        public void SetGlObjs(IEnumerable<string> objsName)
        {
            foreach (var item in objsName)
                if (!comboBox1.Items.Contains(item))
                    comboBox1.Items.Add(item);
        }


        private void OnResetShifting(object sender, EventArgs e)
        {
            //Plane[3] = 0;
            txbD.Text = "0";
            sldA.Value = 100;
            sldB.Value = 0;
            sldC.Value = 0;
            if (!PreventRedraw && comboBox1.SelectedItem != null)
            {
                var plane = new float[4];
                plane[0] = sldA.Value;
                plane[1] = sldB.Value;
                plane[2] = sldC.Value;
                plane[3] = 0;
                UpdateReflectPlane?.Invoke(comboBox1.SelectedItem.ToString(), plane);
            }
        }

        private void OnCreateCopy(object sender, EventArgs e)
        {
            var d = float.Parse(txbD.Text);

            var plane = new float[4];
            plane[0] = sldA.Value / 100.0f;
            plane[1] = sldB.Value / 100.0f;
            plane[2] = sldC.Value / 100.0f;
            plane[3] = d;

            //var vec = TransformVector(new float[] { Plane[0], Plane[1], Plane[2], 0 });

            //UpdateControlNormal(vec);
            CreateReflectObj?.Invoke(comboBox1.SelectedItem.ToString(), plane);
        }


        private void UpdateControlNormal(Vector<float> vector)
        {
            PreventRedraw = true;
            sldA.Value = (int)(vector[0] * 100 + 100);
            sldA.Value = (int)(vector[1] * 100 + 100);
            sldA.Value = (int)(vector[2] * 100 + 100);
            OnResetShifting(this, null);
            PreventRedraw = false;
        }

        //private Vector<float> TransformVector(float[] vector)
        //{
        //    var evnt = new MatrixEvent();
        //    var name = comboBox1.SelectedItem.ToString();
        //    MatrixEvent?.Invoke(name, evnt);
        //    var mat = Matrix<float>.Build.Dense(4, 4, evnt.Matrix);
        //    mat = mat.Inverse();
        //    var vec = Vector<float>.Build.Dense(vector);
        //    vec = vec.Normalize(2);
        //    vec = mat.Multiply(vec);
        //    vec = vec.Normalize(2);
        //    vec[0] = vec[0].Round(2);
        //    vec[1] = vec[1].Round(2);
        //    vec[2] = vec[2].Round(2);
        //    return vec;
        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCreateCopy.Enabled = true;
            ShowObjs?.Invoke(comboBox1.SelectedItem.ToString());
        }
    }
}