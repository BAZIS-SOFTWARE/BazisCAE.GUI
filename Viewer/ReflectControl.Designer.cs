using UserControlsEx;

namespace Viewer
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
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBar1 = new UserControlsEx.ColorSlider();
            this.trackBar2 = new UserControlsEx.ColorSlider();
            this.trackBar3 = new UserControlsEx.ColorSlider();
            this.textBox1 = new UserControlsEx.TextBoxEx(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox1 = new UserControlsEx.ComboBoxEx(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.btnCreateCopy = new System.Windows.Forms.Button();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton6
            // 
            this.radioButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton6.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton6.AutoSize = true;
            this.radioButton6.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.radioButton6.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioButton6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioButton6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.radioButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton6.Location = new System.Drawing.Point(48, 63);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(39, 24);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.Tag = "0 0 -1 0";
            this.radioButton6.Text = "YX";
            this.radioButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.OnChoicePlane);
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
            this.radioButton5.Size = new System.Drawing.Size(39, 24);
            this.radioButton5.TabIndex = 2;
            this.radioButton5.Tag = "0 0 1 0";
            this.radioButton5.Text = "XY";
            this.radioButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.OnChoicePlane);
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
            this.radioButton4.Location = new System.Drawing.Point(48, 33);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(39, 24);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.Tag = "0 -1 0 0";
            this.radioButton4.Text = "XZ";
            this.radioButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.OnChoicePlane);
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
            this.radioButton3.Size = new System.Drawing.Size(39, 24);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.Tag = "0 1 0 0";
            this.radioButton3.Text = "ZX";
            this.radioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.OnChoicePlane);
            this.radioButton3.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
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
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.BackColor = System.Drawing.Color.Transparent;
            this.trackBar1.BarPenColor = System.Drawing.Color.Black;
            this.trackBar1.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.tableLayoutPanel1.SetColumnSpan(this.trackBar1, 2);
            this.trackBar1.LargeChange = ((uint)(5u));
            this.trackBar1.Location = new System.Drawing.Point(138, 3);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(109, 24);
            this.trackBar1.SmallChange = ((uint)(1u));
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Tag = "";
            this.trackBar1.ThumbPenColor = System.Drawing.Color.Black;
            this.trackBar1.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            this.trackBar1.ThumbSize = 12;
            this.trackBar1.Value = 200;
            this.trackBar1.ValueChanged += new System.EventHandler(this.OnChangeNormal);
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar2.BackColor = System.Drawing.Color.Transparent;
            this.trackBar2.BarPenColor = System.Drawing.Color.Black;
            this.trackBar2.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.tableLayoutPanel1.SetColumnSpan(this.trackBar2, 2);
            this.trackBar2.LargeChange = ((uint)(5u));
            this.trackBar2.Location = new System.Drawing.Point(138, 33);
            this.trackBar2.Maximum = 200;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(109, 24);
            this.trackBar2.SmallChange = ((uint)(1u));
            this.trackBar2.TabIndex = 1;
            this.trackBar2.Tag = "";
            this.trackBar2.ThumbPenColor = System.Drawing.Color.Black;
            this.trackBar2.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            this.trackBar2.ThumbSize = 12;
            this.trackBar2.Value = 100;
            this.trackBar2.ValueChanged += new System.EventHandler(this.OnChangeNormal);
            // 
            // trackBar3
            // 
            this.trackBar3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar3.BackColor = System.Drawing.Color.Transparent;
            this.trackBar3.BarPenColor = System.Drawing.Color.Black;
            this.trackBar3.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.tableLayoutPanel1.SetColumnSpan(this.trackBar3, 2);
            this.trackBar3.LargeChange = ((uint)(5u));
            this.trackBar3.Location = new System.Drawing.Point(138, 63);
            this.trackBar3.Maximum = 200;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(109, 24);
            this.trackBar3.SmallChange = ((uint)(1u));
            this.trackBar3.TabIndex = 2;
            this.trackBar3.Tag = "";
            this.trackBar3.ThumbPenColor = System.Drawing.Color.Black;
            this.trackBar3.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            this.trackBar3.ThumbSize = 12;
            this.trackBar3.Value = 100;
            this.trackBar3.ValueChanged += new System.EventHandler(this.OnChangeNormal);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox1, 2);
            this.textBox1.InputType = UserControlsEx.TXTBoxInputType.Float;
            this.textBox1.IsValidating = true;
            this.textBox1.Location = new System.Drawing.Point(155, 97);
            this.textBox1.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.UserRegExCheck = null;
            this.textBox1.UserRegExCheckErrorMessage = null;
            this.textBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
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
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.radioButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.radioButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(39, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "1 0 0 0";
            this.radioButton1.Text = "YZ";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.OnChoicePlane);
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
            this.radioButton2.Location = new System.Drawing.Point(48, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(39, 24);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Tag = "-1 0 0 0";
            this.radioButton2.Text = "ZY";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.OnChoicePlane);
            this.radioButton2.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 2);
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(2, 93);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 27);
            this.button1.TabIndex = 13;
            this.button1.Text = "Сброс";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnResetShifting);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel1.Controls.Add(this.radioButton6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioButton5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioButton4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.trackBar2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.trackBar3, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCreateCopy, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.domainUpDown1, 4, 6);
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
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.comboBox1, 4);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.InputType = UserControlsEx.CMBInputType.Items;
            this.comboBox1.IsValidating = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 143);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(174, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.UserRegExCheck = null;
            this.comboBox1.UserRegExCheckErrorMessage = null;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            this.btnCreateCopy.Click += new System.EventHandler(this.OnSetCopyName);
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.domainUpDown1.Items.Add("1");
            this.domainUpDown1.Items.Add("0.1");
            this.domainUpDown1.Items.Add("0.01");
            this.domainUpDown1.Items.Add("0.001");
            this.domainUpDown1.Location = new System.Drawing.Point(190, 176);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(50, 20);
            this.domainUpDown1.TabIndex = 20;
            this.domainUpDown1.Text = "0.01";
            this.domainUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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

        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label8;
        private ColorSlider trackBar1;
        private ColorSlider trackBar2;
        private ColorSlider trackBar3;
        private TextBoxEx textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button1;
        private ComboBoxEx comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCreateCopy;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
