namespace BaseModule.Clip
{
    partial class ClipControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.colorSlider3 = new UserControlsEx.ColorSlider();
            this.colorSlider2 = new UserControlsEx.ColorSlider();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnReject = new System.Windows.Forms.Button();
            this.colorSlider1 = new UserControlsEx.ColorSlider();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.domainUpDown1, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.colorSlider3, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.colorSlider2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioButton5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioButton4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnReject, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.colorSlider1, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // colorSlider3
            // 
            this.colorSlider3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSlider3.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider3.BarPenColor = System.Drawing.Color.Black;
            this.colorSlider3.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider3.LargeChange = ((uint)(5u));
            this.colorSlider3.Location = new System.Drawing.Point(139, 63);
            this.colorSlider3.Maximum = 200;
            this.colorSlider3.Name = "colorSlider3";
            this.colorSlider3.Size = new System.Drawing.Size(108, 24);
            this.colorSlider3.SmallChange = ((uint)(1u));
            this.colorSlider3.TabIndex = 2;
            this.colorSlider3.Text = "colorSlider3";
            this.colorSlider3.ThumbPenColor = System.Drawing.Color.Black;
            this.colorSlider3.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            this.colorSlider3.ThumbSize = 12;
            this.colorSlider3.ValueChanged += new System.EventHandler(this.OnChangeValue);
            // 
            // colorSlider2
            // 
            this.colorSlider2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSlider2.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider2.BarPenColor = System.Drawing.Color.Black;
            this.colorSlider2.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider2.LargeChange = ((uint)(5u));
            this.colorSlider2.Location = new System.Drawing.Point(139, 33);
            this.colorSlider2.Maximum = 200;
            this.colorSlider2.Name = "colorSlider2";
            this.colorSlider2.Size = new System.Drawing.Size(108, 24);
            this.colorSlider2.SmallChange = ((uint)(1u));
            this.colorSlider2.TabIndex = 1;
            this.colorSlider2.Text = "colorSlider2";
            this.colorSlider2.ThumbPenColor = System.Drawing.Color.Black;
            this.colorSlider2.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            this.colorSlider2.ThumbSize = 12;
            this.colorSlider2.ValueChanged += new System.EventHandler(this.OnChangeValue);
            // 
            // radioButton6
            // 
            this.radioButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton6.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.radioButton6.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioButton6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioButton6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.radioButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton6.Location = new System.Drawing.Point(46, 63);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(37, 24);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.TabStop = true;
            this.radioButton6.Tag = "100 100 0";
            this.radioButton6.Text = "YX";
            this.radioButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.Click += new System.EventHandler(this.OnChoicePlane);
            this.radioButton6.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // radioButton5
            // 
            this.radioButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton5.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton5.AutoSize = true;
            this.radioButton5.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.radioButton5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioButton5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioButton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.radioButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton5.Location = new System.Drawing.Point(3, 63);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(37, 24);
            this.radioButton5.TabIndex = 2;
            this.radioButton5.Tag = "100 100 200";
            this.radioButton5.Text = "XY";
            this.radioButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.Click += new System.EventHandler(this.OnChoicePlane);
            this.radioButton5.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // radioButton4
            // 
            this.radioButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton4.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton4.AutoSize = true;
            this.radioButton4.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.radioButton4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton4.Location = new System.Drawing.Point(46, 33);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(37, 24);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.Tag = "100 0 100";
            this.radioButton4.Text = "XZ";
            this.radioButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.Click += new System.EventHandler(this.OnChoicePlane);
            this.radioButton4.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton3.AutoSize = true;
            this.radioButton3.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.radioButton3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton3.Location = new System.Drawing.Point(3, 33);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(37, 24);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.Tag = "100 200 100";
            this.radioButton3.Text = "ZX";
            this.radioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.OnChoicePlane);
            this.radioButton3.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(43, 124);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 28);
            this.panel1.TabIndex = 12;
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.domainUpDown1.Items.Add("1");
            this.domainUpDown1.Items.Add("0.1");
            this.domainUpDown1.Items.Add("0.01");
            this.domainUpDown1.Items.Add("0.001");
            this.domainUpDown1.Location = new System.Drawing.Point(141, 128);
            this.domainUpDown1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(104, 20);
            this.domainUpDown1.TabIndex = 2;
            this.domainUpDown1.Text = "0.01";
            this.domainUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Дельта D:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(141, 97);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(104, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.textBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.textBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(102, 100);
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
            this.label3.Location = new System.Drawing.Point(96, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Tag = "";
            this.label3.Text = "C: -1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(98, 38);
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
            this.label1.Location = new System.Drawing.Point(98, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "";
            this.label1.Text = "A: 0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton1.AutoSize = true;
            this.radioButton1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.radioButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(37, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Tag = "200 100 100";
            this.radioButton1.Text = "YZ";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.OnChoicePlane);
            this.radioButton1.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton2.AutoSize = true;
            this.radioButton2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.radioButton2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.Location = new System.Drawing.Point(46, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(37, 24);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Tag = "0 100 100";
            this.radioButton2.Text = "ZY";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.OnChoicePlane);
            this.radioButton2.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.btnReject, 2);
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReject.Location = new System.Drawing.Point(0, 93);
            this.btnReject.Margin = new System.Windows.Forms.Padding(0);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(86, 27);
            this.btnReject.TabIndex = 13;
            this.btnReject.Text = "Сброс";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.OnResetShifting);
            // 
            // colorSlider1
            // 
            this.colorSlider1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSlider1.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider1.BarPenColor = System.Drawing.Color.Black;
            this.colorSlider1.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider1.LargeChange = ((uint)(5u));
            this.colorSlider1.Location = new System.Drawing.Point(139, 3);
            this.colorSlider1.Maximum = 200;
            this.colorSlider1.Name = "colorSlider1";
            this.colorSlider1.Size = new System.Drawing.Size(108, 24);
            this.colorSlider1.SmallChange = ((uint)(1u));
            this.colorSlider1.TabIndex = 0;
            this.colorSlider1.Text = "colorSlider1";
            this.colorSlider1.ThumbPenColor = System.Drawing.Color.Black;
            this.colorSlider1.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            this.colorSlider1.ThumbSize = 12;
            this.colorSlider1.ValueChanged += new System.EventHandler(this.OnChangeValue);
            // 
            // ClipControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ClipControl";
            this.Size = new System.Drawing.Size(250, 150);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button btnReject;
        private UserControlsEx.ColorSlider colorSlider3;
        private UserControlsEx.ColorSlider colorSlider2;
        private UserControlsEx.ColorSlider colorSlider1;
    }
}
