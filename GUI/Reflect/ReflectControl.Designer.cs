using UserControlsEx;

namespace BazisGUI.Reflect
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
            components = new System.ComponentModel.Container();
            radioButton6 = new System.Windows.Forms.RadioButton();
            radioButton5 = new System.Windows.Forms.RadioButton();
            radioButton4 = new System.Windows.Forms.RadioButton();
            radioButton3 = new System.Windows.Forms.RadioButton();
            label8 = new System.Windows.Forms.Label();
            trackBar1 = new ColorSlider();
            trackBar2 = new ColorSlider();
            trackBar3 = new ColorSlider();
            textBox1 = new TextBoxEx(components);
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            radioButton1 = new System.Windows.Forms.RadioButton();
            radioButton2 = new System.Windows.Forms.RadioButton();
            button1 = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            comboBox1 = new ComboBoxEx(components);
            label5 = new System.Windows.Forms.Label();
            btnCreateCopy = new System.Windows.Forms.Button();
            domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // radioButton6
            // 
            radioButton6.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            radioButton6.Appearance = System.Windows.Forms.Appearance.Button;
            radioButton6.AutoSize = true;
            radioButton6.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            radioButton6.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            radioButton6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            radioButton6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            radioButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radioButton6.Location = new System.Drawing.Point(72, 74);
            radioButton6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new System.Drawing.Size(60, 27);
            radioButton6.TabIndex = 2;
            radioButton6.Tag = "0 0 -1 0";
            radioButton6.Text = "YX";
            radioButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            radioButton6.UseVisualStyleBackColor = true;
            radioButton6.CheckedChanged += OnChoicePlane;
            radioButton6.Paint += OnPaint;
            // 
            // radioButton5
            // 
            radioButton5.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            radioButton5.Appearance = System.Windows.Forms.Appearance.Button;
            radioButton5.AutoSize = true;
            radioButton5.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            radioButton5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            radioButton5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            radioButton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            radioButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radioButton5.Location = new System.Drawing.Point(4, 74);
            radioButton5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new System.Drawing.Size(60, 27);
            radioButton5.TabIndex = 2;
            radioButton5.Tag = "0 0 1 0";
            radioButton5.Text = "XY";
            radioButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            radioButton5.UseVisualStyleBackColor = true;
            radioButton5.CheckedChanged += OnChoicePlane;
            radioButton5.Paint += OnPaint;
            // 
            // radioButton4
            // 
            radioButton4.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            radioButton4.Appearance = System.Windows.Forms.Appearance.Button;
            radioButton4.AutoSize = true;
            radioButton4.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            radioButton4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            radioButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            radioButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radioButton4.Location = new System.Drawing.Point(72, 39);
            radioButton4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new System.Drawing.Size(60, 27);
            radioButton4.TabIndex = 1;
            radioButton4.Tag = "0 -1 0 0";
            radioButton4.Text = "XZ";
            radioButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += OnChoicePlane;
            radioButton4.Paint += OnPaint;
            // 
            // radioButton3
            // 
            radioButton3.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            radioButton3.AutoSize = true;
            radioButton3.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            radioButton3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            radioButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            radioButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radioButton3.Location = new System.Drawing.Point(4, 39);
            radioButton3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new System.Drawing.Size(60, 27);
            radioButton3.TabIndex = 1;
            radioButton3.Tag = "0 1 0 0";
            radioButton3.Text = "ZX";
            radioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += OnChoicePlane;
            radioButton3.Paint += OnPaint;
            // 
            // label8
            // 
            label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            label8.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label8, 2);
            label8.Enabled = false;
            label8.Location = new System.Drawing.Point(174, 234);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(59, 15);
            label8.TabIndex = 1;
            label8.Text = "Дельта D:";
            // 
            // trackBar1
            // 
            trackBar1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBar1.BackColor = System.Drawing.Color.Transparent;
            trackBar1.BarInnerColor = System.Drawing.Color.Silver;
            trackBar1.BarOuterColor = System.Drawing.Color.Silver;
            trackBar1.BarPenColor = System.Drawing.Color.Black;
            trackBar1.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            tableLayoutPanel1.SetColumnSpan(trackBar1, 2);
            trackBar1.ElapsedInnerColor = System.Drawing.Color.Silver;
            trackBar1.ElapsedOuterColor = System.Drawing.Color.Silver;
            trackBar1.LargeChange = 5U;
            trackBar1.Location = new System.Drawing.Point(208, 3);
            trackBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            trackBar1.Maximum = 200;
            trackBar1.Name = "trackBar1";
            trackBar1.ShowTextValue = false;
            trackBar1.Size = new System.Drawing.Size(168, 28);
            trackBar1.SmallChange = 1U;
            trackBar1.TabIndex = 0;
            trackBar1.Tag = "";
            trackBar1.TextValueColor = System.Drawing.Color.Black;
            trackBar1.ThumbPenColor = System.Drawing.Color.Black;
            trackBar1.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            trackBar1.ThumbSize = 12;
            trackBar1.Value = 200;
            trackBar1.ValueChanged += OnChangeNormal;
            // 
            // trackBar2
            // 
            trackBar2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBar2.BackColor = System.Drawing.Color.Transparent;
            trackBar2.BarInnerColor = System.Drawing.Color.Silver;
            trackBar2.BarOuterColor = System.Drawing.Color.Silver;
            trackBar2.BarPenColor = System.Drawing.Color.Black;
            trackBar2.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            tableLayoutPanel1.SetColumnSpan(trackBar2, 2);
            trackBar2.ElapsedInnerColor = System.Drawing.Color.Silver;
            trackBar2.ElapsedOuterColor = System.Drawing.Color.Silver;
            trackBar2.LargeChange = 5U;
            trackBar2.Location = new System.Drawing.Point(208, 38);
            trackBar2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            trackBar2.Maximum = 200;
            trackBar2.Name = "trackBar2";
            trackBar2.ShowTextValue = false;
            trackBar2.Size = new System.Drawing.Size(168, 28);
            trackBar2.SmallChange = 1U;
            trackBar2.TabIndex = 1;
            trackBar2.Tag = "";
            trackBar2.TextValueColor = System.Drawing.Color.Black;
            trackBar2.ThumbPenColor = System.Drawing.Color.Black;
            trackBar2.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            trackBar2.ThumbSize = 12;
            trackBar2.Value = 100;
            trackBar2.ValueChanged += OnChangeNormal;
            // 
            // trackBar3
            // 
            trackBar3.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBar3.BackColor = System.Drawing.Color.Transparent;
            trackBar3.BarInnerColor = System.Drawing.Color.Silver;
            trackBar3.BarOuterColor = System.Drawing.Color.Silver;
            trackBar3.BarPenColor = System.Drawing.Color.Black;
            trackBar3.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            tableLayoutPanel1.SetColumnSpan(trackBar3, 2);
            trackBar3.ElapsedInnerColor = System.Drawing.Color.Silver;
            trackBar3.ElapsedOuterColor = System.Drawing.Color.Silver;
            trackBar3.LargeChange = 5U;
            trackBar3.Location = new System.Drawing.Point(208, 73);
            trackBar3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            trackBar3.Maximum = 200;
            trackBar3.Name = "trackBar3";
            trackBar3.ShowTextValue = false;
            trackBar3.Size = new System.Drawing.Size(168, 28);
            trackBar3.SmallChange = 1U;
            trackBar3.TabIndex = 2;
            trackBar3.Tag = "";
            trackBar3.TextValueColor = System.Drawing.Color.Black;
            trackBar3.ThumbPenColor = System.Drawing.Color.Black;
            trackBar3.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            trackBar3.ThumbSize = 12;
            trackBar3.Value = 100;
            trackBar3.ValueChanged += OnChangeNormal;
            // 
            // textBox1
            // 
            textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tableLayoutPanel1.SetColumnSpan(textBox1, 2);
            textBox1.InputType = TXTBoxInputType.Float;
            textBox1.IsValidating = true;
            textBox1.Location = new System.Drawing.Point(208, 113);
            textBox1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(168, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "0";
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox1.UserRegExCheck = null;
            textBox1.UserRegExCheckErrorMessage = null;
            textBox1.MouseMove += OnMouseMove;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(161, 117);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(18, 15);
            label4.TabIndex = 3;
            label4.Text = "D:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(156, 80);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(27, 15);
            label3.TabIndex = 2;
            label3.Tag = "";
            label3.Text = "C: 0";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(157, 45);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(26, 15);
            label2.TabIndex = 1;
            label2.Tag = "";
            label2.Text = "B: 0";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(156, 10);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(27, 15);
            label1.TabIndex = 0;
            label1.Tag = "";
            label1.Text = "A: 1";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton1
            // 
            radioButton1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            radioButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            radioButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            radioButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radioButton1.Location = new System.Drawing.Point(4, 4);
            radioButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(60, 27);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Tag = "1 0 0 0";
            radioButton1.Text = "YZ";
            radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += OnChoicePlane;
            radioButton1.Paint += OnPaint;
            // 
            // radioButton2
            // 
            radioButton2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            radioButton2.AutoSize = true;
            radioButton2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            radioButton2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            radioButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            radioButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radioButton2.Location = new System.Drawing.Point(72, 4);
            radioButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new System.Drawing.Size(60, 27);
            radioButton2.TabIndex = 0;
            radioButton2.Tag = "-1 0 0 0";
            radioButton2.Text = "ZY";
            radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += OnChoicePlane;
            radioButton2.Paint += OnPaint;
            // 
            // button1
            // 
            tableLayoutPanel1.SetColumnSpan(button1, 2);
            button1.Dock = System.Windows.Forms.DockStyle.Fill;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button1.Location = new System.Drawing.Point(2, 107);
            button1.Margin = new System.Windows.Forms.Padding(2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(132, 35);
            button1.TabIndex = 13;
            button1.Text = "Сброс";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnResetShifting;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            tableLayoutPanel1.Controls.Add(radioButton6, 1, 2);
            tableLayoutPanel1.Controls.Add(radioButton5, 0, 2);
            tableLayoutPanel1.Controls.Add(radioButton4, 1, 1);
            tableLayoutPanel1.Controls.Add(radioButton3, 0, 1);
            tableLayoutPanel1.Controls.Add(trackBar1, 3, 0);
            tableLayoutPanel1.Controls.Add(trackBar2, 3, 1);
            tableLayoutPanel1.Controls.Add(trackBar3, 3, 2);
            tableLayoutPanel1.Controls.Add(textBox1, 3, 3);
            tableLayoutPanel1.Controls.Add(label4, 2, 3);
            tableLayoutPanel1.Controls.Add(label3, 2, 2);
            tableLayoutPanel1.Controls.Add(label2, 2, 1);
            tableLayoutPanel1.Controls.Add(label1, 2, 0);
            tableLayoutPanel1.Controls.Add(radioButton1, 0, 0);
            tableLayoutPanel1.Controls.Add(radioButton2, 1, 0);
            tableLayoutPanel1.Controls.Add(button1, 0, 3);
            tableLayoutPanel1.Controls.Add(comboBox1, 0, 5);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(btnCreateCopy, 4, 5);
            tableLayoutPanel1.Controls.Add(domainUpDown1, 4, 6);
            tableLayoutPanel1.Controls.Add(label8, 2, 6);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanel1.Size = new System.Drawing.Size(380, 285);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(comboBox1, 4);
            comboBox1.FormattingEnabled = true;
            comboBox1.InputType = CMBInputType.Items;
            comboBox1.IsValidating = true;
            comboBox1.Location = new System.Drawing.Point(4, 167);
            comboBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(264, 23);
            comboBox1.TabIndex = 14;
            comboBox1.UserRegExCheck = null;
            comboBox1.UserRegExCheckErrorMessage = null;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            label5.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label5, 4);
            label5.Enabled = false;
            label5.Location = new System.Drawing.Point(104, 144);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(64, 15);
            label5.TabIndex = 16;
            label5.Text = "Источник:";
            // 
            // btnCreateCopy
            // 
            btnCreateCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            btnCreateCopy.Enabled = false;
            btnCreateCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCreateCopy.Location = new System.Drawing.Point(274, 161);
            btnCreateCopy.Margin = new System.Windows.Forms.Padding(2);
            btnCreateCopy.Name = "btnCreateCopy";
            btnCreateCopy.Size = new System.Drawing.Size(104, 35);
            btnCreateCopy.TabIndex = 17;
            btnCreateCopy.Text = "Задать";
            btnCreateCopy.UseVisualStyleBackColor = true;
            btnCreateCopy.Click += OnSetCopyName;
            // 
            // domainUpDown1
            // 
            domainUpDown1.Anchor = System.Windows.Forms.AnchorStyles.None;
            domainUpDown1.Items.Add("1");
            domainUpDown1.Items.Add("0.1");
            domainUpDown1.Items.Add("0.01");
            domainUpDown1.Items.Add("0.001");
            domainUpDown1.Location = new System.Drawing.Point(297, 230);
            domainUpDown1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new System.Drawing.Size(58, 23);
            domainUpDown1.TabIndex = 20;
            domainUpDown1.Text = "0.01";
            domainUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ReflectControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ReflectControl";
            Size = new System.Drawing.Size(380, 285);
            Load += OnLoad;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
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
