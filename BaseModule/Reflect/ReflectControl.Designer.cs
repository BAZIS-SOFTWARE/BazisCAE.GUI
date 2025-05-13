using UserControlsEx;

namespace BaseModule.Reflect
{
    partial class ReflectControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rbtXY = new System.Windows.Forms.RadioButton();
            this.rbtZX = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.sldA = new UserControlsEx.ColorSlider();
            this.sldB = new UserControlsEx.ColorSlider();
            this.sldC = new UserControlsEx.ColorSlider();
            this.txbD = new UserControlsEx.TextBoxEx(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtYZ = new System.Windows.Forms.RadioButton();
            this.btnDelReflectedObjs = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbSelector = new UserControlsEx.ComboBoxEx(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.btnCreateCopy = new System.Windows.Forms.Button();
            this.txudDeltaD = new System.Windows.Forms.DomainUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtXY
            // 
            this.rbtXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtXY.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtXY.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.rbtXY, 2);
            this.rbtXY.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.rbtXY.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.rbtXY.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rbtXY.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rbtXY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtXY.Location = new System.Drawing.Point(3, 63);
            this.rbtXY.Name = "rbtXY";
            this.rbtXY.Size = new System.Drawing.Size(84, 24);
            this.rbtXY.TabIndex = 2;
            this.rbtXY.Tag = "0 0 1 0";
            this.rbtXY.Text = "XY";
            this.rbtXY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtXY.UseVisualStyleBackColor = true;
            this.rbtXY.Click += new System.EventHandler(this.OnChoicePlane);
            this.rbtXY.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // rbtZX
            // 
            this.rbtZX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtZX.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtZX.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.rbtZX, 2);
            this.rbtZX.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.rbtZX.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.rbtZX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rbtZX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rbtZX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtZX.Location = new System.Drawing.Point(3, 33);
            this.rbtZX.Name = "rbtZX";
            this.rbtZX.Size = new System.Drawing.Size(84, 24);
            this.rbtZX.TabIndex = 1;
            this.rbtZX.Tag = "0 1 0 0";
            this.rbtZX.Text = "ZX";
            this.rbtZX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtZX.UseVisualStyleBackColor = true;
            this.rbtZX.Click += new System.EventHandler(this.OnChoicePlane);
            this.rbtZX.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label8, 2);
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(105, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Дельта D:";
            // 
            // sldA
            // 
            this.sldA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sldA.BackColor = System.Drawing.Color.Transparent;
            this.sldA.BarInnerColor = System.Drawing.Color.Silver;
            this.sldA.BarOuterColor = System.Drawing.Color.Silver;
            this.sldA.BarPenColor = System.Drawing.Color.Black;
            this.sldA.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.tableLayoutPanel1.SetColumnSpan(this.sldA, 2);
            this.sldA.ElapsedInnerColor = System.Drawing.Color.Silver;
            this.sldA.ElapsedOuterColor = System.Drawing.Color.Silver;
            this.sldA.LargeChange = ((uint)(5u));
            this.sldA.Location = new System.Drawing.Point(138, 3);
            this.sldA.Name = "sldA";
            this.sldA.ShowTextValue = true;
            this.sldA.Size = new System.Drawing.Size(109, 24);
            this.sldA.SmallChange = ((uint)(1u));
            this.sldA.TabIndex = 0;
            this.sldA.Tag = "";
            this.sldA.TextValueColor = System.Drawing.Color.Black;
            this.sldA.ThumbPenColor = System.Drawing.Color.Black;
            this.sldA.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            this.sldA.ThumbSize = 12;
            this.sldA.Value = 100;
            this.sldA.ValueChanged += new System.EventHandler(this.OnChangeNormal);
            // 
            // sldB
            // 
            this.sldB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sldB.BackColor = System.Drawing.Color.Transparent;
            this.sldB.BarInnerColor = System.Drawing.Color.Silver;
            this.sldB.BarOuterColor = System.Drawing.Color.Silver;
            this.sldB.BarPenColor = System.Drawing.Color.Black;
            this.sldB.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.tableLayoutPanel1.SetColumnSpan(this.sldB, 2);
            this.sldB.ElapsedInnerColor = System.Drawing.Color.Silver;
            this.sldB.ElapsedOuterColor = System.Drawing.Color.Silver;
            this.sldB.LargeChange = ((uint)(5u));
            this.sldB.Location = new System.Drawing.Point(138, 33);
            this.sldB.Name = "sldB";
            this.sldB.ShowTextValue = true;
            this.sldB.Size = new System.Drawing.Size(109, 24);
            this.sldB.SmallChange = ((uint)(1u));
            this.sldB.TabIndex = 1;
            this.sldB.Tag = "";
            this.sldB.TextValueColor = System.Drawing.Color.Black;
            this.sldB.ThumbPenColor = System.Drawing.Color.Black;
            this.sldB.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            this.sldB.ThumbSize = 12;
            this.sldB.Value = 100;
            this.sldB.ValueChanged += new System.EventHandler(this.OnChangeNormal);
            // 
            // sldC
            // 
            this.sldC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sldC.BackColor = System.Drawing.Color.Transparent;
            this.sldC.BarInnerColor = System.Drawing.Color.Silver;
            this.sldC.BarOuterColor = System.Drawing.Color.Silver;
            this.sldC.BarPenColor = System.Drawing.Color.Black;
            this.sldC.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.tableLayoutPanel1.SetColumnSpan(this.sldC, 2);
            this.sldC.ElapsedInnerColor = System.Drawing.Color.Silver;
            this.sldC.ElapsedOuterColor = System.Drawing.Color.Silver;
            this.sldC.LargeChange = ((uint)(5u));
            this.sldC.Location = new System.Drawing.Point(138, 63);
            this.sldC.Name = "sldC";
            this.sldC.ShowTextValue = true;
            this.sldC.Size = new System.Drawing.Size(109, 24);
            this.sldC.SmallChange = ((uint)(1u));
            this.sldC.TabIndex = 2;
            this.sldC.Tag = "";
            this.sldC.TextValueColor = System.Drawing.Color.Black;
            this.sldC.ThumbPenColor = System.Drawing.Color.Black;
            this.sldC.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            this.sldC.ThumbSize = 12;
            this.sldC.Value = 100;
            this.sldC.ValueChanged += new System.EventHandler(this.OnChangeNormal);
            // 
            // txbD
            // 
            this.txbD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.txbD, 2);
            this.txbD.InputType = UserControlsEx.TXTBoxInputType.Float;
            this.txbD.IsValidating = true;
            this.txbD.Location = new System.Drawing.Point(155, 97);
            this.txbD.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.txbD.Name = "txbD";
            this.txbD.Size = new System.Drawing.Size(75, 20);
            this.txbD.TabIndex = 0;
            this.txbD.Text = "0";
            this.txbD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbD.UserRegExCheck = null;
            this.txbD.UserRegExCheckErrorMessage = null;
            this.txbD.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(103, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "D:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(99, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Tag = "";
            this.label3.Text = "C: 0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(99, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Tag = "";
            this.label2.Text = "B: 0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(99, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "";
            this.label1.Text = "A: 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbtYZ
            // 
            this.rbtYZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtYZ.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtYZ.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.rbtYZ, 2);
            this.rbtYZ.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.rbtYZ.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.rbtYZ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rbtYZ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rbtYZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtYZ.Location = new System.Drawing.Point(3, 3);
            this.rbtYZ.Name = "rbtYZ";
            this.rbtYZ.Size = new System.Drawing.Size(84, 24);
            this.rbtYZ.TabIndex = 0;
            this.rbtYZ.Tag = "1 0 0 0";
            this.rbtYZ.Text = "YZ";
            this.rbtYZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtYZ.UseVisualStyleBackColor = true;
            this.rbtYZ.Click += new System.EventHandler(this.OnChoicePlane);
            this.rbtYZ.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // btnDelReflectedObjs
            // 
            this.btnDelReflectedObjs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnDelReflectedObjs, 2);
            this.btnDelReflectedObjs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelReflectedObjs.Location = new System.Drawing.Point(2, 93);
            this.btnDelReflectedObjs.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelReflectedObjs.Name = "btnDelReflectedObjs";
            this.btnDelReflectedObjs.Size = new System.Drawing.Size(86, 27);
            this.btnDelReflectedObjs.TabIndex = 13;
            this.btnDelReflectedObjs.Text = "Сброс";
            this.btnDelReflectedObjs.UseVisualStyleBackColor = true;
            this.btnDelReflectedObjs.Click += new System.EventHandler(this.OnResetShifting);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel1.Controls.Add(this.rbtXY, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbtZX, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.sldA, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.sldB, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.sldC, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txbD, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbtYZ, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelReflectedObjs, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbSelector, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCreateCopy, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.txudDeltaD, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 200);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cmbSelector
            // 
            this.cmbSelector.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.cmbSelector, 4);
            this.cmbSelector.FormattingEnabled = true;
            this.cmbSelector.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbSelector.IsValidating = true;
            this.cmbSelector.Location = new System.Drawing.Point(3, 143);
            this.cmbSelector.Name = "cmbSelector";
            this.cmbSelector.Size = new System.Drawing.Size(174, 21);
            this.cmbSelector.TabIndex = 14;
            this.cmbSelector.UserRegExCheck = null;
            this.cmbSelector.UserRegExCheckErrorMessage = null;
            this.cmbSelector.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label5, 4);
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(61, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Источник:";
            // 
            // btnCreateCopy
            // 
            this.btnCreateCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCopy.Enabled = false;
            this.btnCreateCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateCopy.Location = new System.Drawing.Point(183, 140);
            this.btnCreateCopy.Name = "btnCreateCopy";
            this.btnCreateCopy.Size = new System.Drawing.Size(64, 27);
            this.btnCreateCopy.TabIndex = 17;
            this.btnCreateCopy.Text = "Задать";
            this.btnCreateCopy.UseVisualStyleBackColor = true;
            this.btnCreateCopy.Click += new System.EventHandler(this.OnCreateCopy);
            // 
            // txudDeltaD
            // 
            this.txudDeltaD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txudDeltaD.Items.Add("1");
            this.txudDeltaD.Items.Add("0.1");
            this.txudDeltaD.Items.Add("0.01");
            this.txudDeltaD.Items.Add("0.001");
            this.txudDeltaD.Location = new System.Drawing.Point(190, 176);
            this.txudDeltaD.Name = "txudDeltaD";
            this.txudDeltaD.Size = new System.Drawing.Size(50, 20);
            this.txudDeltaD.TabIndex = 20;
            this.txudDeltaD.Text = "0.01";
            this.txudDeltaD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ReflectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReflectControl";
            this.Size = new System.Drawing.Size(250, 200);
            this.Load += new System.EventHandler(this.OnLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rbtXY;
        private System.Windows.Forms.RadioButton rbtZX;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label8;
        private ColorSlider sldA;
        private ColorSlider sldB;
        private ColorSlider sldC;
        private TextBoxEx txbD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtYZ;
        private System.Windows.Forms.Button btnDelReflectedObjs;
        private ComboBoxEx cmbSelector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCreateCopy;
        private System.Windows.Forms.DomainUpDown txudDeltaD;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
