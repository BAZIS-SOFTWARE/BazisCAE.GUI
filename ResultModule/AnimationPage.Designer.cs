namespace ResultModule
{
    partial class AnimationPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimationPage));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.incrButton = new System.Windows.Forms.Button();
            this.decrButton = new System.Windows.Forms.Button();
            this.btnMoveToFinish = new System.Windows.Forms.Button();
            this.btnPlayResults = new System.Windows.Forms.Button();
            this.btnMoveToStart = new System.Windows.Forms.Button();
            this.colorSlider = new MB.Controls.ColorSlider();
            this.txbScale = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbResultNames = new System.Windows.Forms.ComboBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreateAnimation = new System.Windows.Forms.Button();
            this.txbDelayTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbDelTempScrs = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(413, 597);
            this.tableLayoutPanel2.TabIndex = 42;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 121);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Плеер";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.14712F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.85288F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txbScale, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(401, 102);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.incrButton);
            this.panel1.Controls.Add(this.decrButton);
            this.panel1.Controls.Add(this.btnMoveToFinish);
            this.panel1.Controls.Add(this.btnPlayResults);
            this.panel1.Controls.Add(this.btnMoveToStart);
            this.panel1.Controls.Add(this.colorSlider);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 45);
            this.panel1.TabIndex = 0;
            // 
            // incrButton
            // 
            this.incrButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.incrButton.BackColor = System.Drawing.SystemColors.Control;
            this.incrButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.incrButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.incrButton.Image = ((System.Drawing.Image)(resources.GetObject("incrButton.Image")));
            this.incrButton.Location = new System.Drawing.Point(361, 16);
            this.incrButton.Margin = new System.Windows.Forms.Padding(0);
            this.incrButton.Name = "incrButton";
            this.incrButton.Size = new System.Drawing.Size(15, 15);
            this.incrButton.TabIndex = 45;
            this.incrButton.UseVisualStyleBackColor = false;
            this.incrButton.Click += new System.EventHandler(this.incrButton_Click);
            // 
            // decrButton
            // 
            this.decrButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.decrButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decrButton.Image = ((System.Drawing.Image)(resources.GetObject("decrButton.Image")));
            this.decrButton.Location = new System.Drawing.Point(110, 16);
            this.decrButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.decrButton.Name = "decrButton";
            this.decrButton.Size = new System.Drawing.Size(15, 14);
            this.decrButton.TabIndex = 44;
            this.decrButton.UseVisualStyleBackColor = true;
            this.decrButton.Click += new System.EventHandler(this.decrButton_Click);
            // 
            // btnMoveToFinish
            // 
            this.btnMoveToFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveToFinish.Image")));
            this.btnMoveToFinish.Location = new System.Drawing.Point(76, 12);
            this.btnMoveToFinish.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnMoveToFinish.Name = "btnMoveToFinish";
            this.btnMoveToFinish.Size = new System.Drawing.Size(28, 26);
            this.btnMoveToFinish.TabIndex = 47;
            this.btnMoveToFinish.UseVisualStyleBackColor = true;
            this.btnMoveToFinish.Click += new System.EventHandler(this.btnMoveToFinish_Click);
            // 
            // btnPlayResults
            // 
            this.btnPlayResults.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayResults.Image")));
            this.btnPlayResults.Location = new System.Drawing.Point(48, 12);
            this.btnPlayResults.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.btnPlayResults.Name = "btnPlayResults";
            this.btnPlayResults.Size = new System.Drawing.Size(27, 26);
            this.btnPlayResults.TabIndex = 48;
            this.btnPlayResults.UseVisualStyleBackColor = true;
            this.btnPlayResults.Click += new System.EventHandler(this.btnPlayResults_Click);
            // 
            // btnMoveToStart
            // 
            this.btnMoveToStart.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveToStart.Image")));
            this.btnMoveToStart.Location = new System.Drawing.Point(21, 12);
            this.btnMoveToStart.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.btnMoveToStart.Name = "btnMoveToStart";
            this.btnMoveToStart.Size = new System.Drawing.Size(26, 26);
            this.btnMoveToStart.TabIndex = 49;
            this.btnMoveToStart.UseVisualStyleBackColor = true;
            this.btnMoveToStart.Click += new System.EventHandler(this.btnMoveToStart_Click);
            // 
            // colorSlider
            // 
            this.colorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSlider.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider.BarInnerColor = System.Drawing.Color.Gold;
            this.colorSlider.BarOuterColor = System.Drawing.Color.DarkGoldenrod;
            this.colorSlider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider.LargeChange = ((uint)(5u));
            this.colorSlider.Location = new System.Drawing.Point(125, 8);
            this.colorSlider.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.colorSlider.Name = "colorSlider";
            this.colorSlider.Size = new System.Drawing.Size(236, 30);
            this.colorSlider.SmallChange = ((uint)(1u));
            this.colorSlider.TabIndex = 50;
            this.colorSlider.Text = "colorSlider";
            this.colorSlider.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ColorSlider_Scroll);
            // 
            // txbScale
            // 
            this.txbScale.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbScale.Location = new System.Drawing.Point(250, 65);
            this.txbScale.Margin = new System.Windows.Forms.Padding(3, 0, 5, 3);
            this.txbScale.Name = "txbScale";
            this.txbScale.Size = new System.Drawing.Size(44, 20);
            this.txbScale.TabIndex = 20;
            this.txbScale.Text = "1";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Масшт.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 254);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Шаги по времени";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.cmbResultNames, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.richTextBox, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(401, 235);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // cmbResultNames
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.cmbResultNames, 2);
            this.cmbResultNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbResultNames.FormattingEnabled = true;
            this.cmbResultNames.Location = new System.Drawing.Point(3, 3);
            this.cmbResultNames.Name = "cmbResultNames";
            this.cmbResultNames.Size = new System.Drawing.Size(395, 21);
            this.cmbResultNames.TabIndex = 0;
            this.cmbResultNames.SelectedIndexChanged += new System.EventHandler(this.cmbResultNames_SelectedIndexChanged);
            // 
            // richTextBox
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.richTextBox, 2);
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(3, 33);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(395, 199);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            this.richTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 390);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(407, 204);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Создать анимацию";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel4.Controls.Add(this.btnCreateAnimation, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.txbDelayTime, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.chbDelTempScrs, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(401, 185);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // btnCreateAnimation
            // 
            this.btnCreateAnimation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreateAnimation.AutoSize = true;
            this.btnCreateAnimation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreateAnimation.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateAnimation.Image")));
            this.btnCreateAnimation.Location = new System.Drawing.Point(336, 119);
            this.btnCreateAnimation.Name = "btnCreateAnimation";
            this.btnCreateAnimation.Size = new System.Drawing.Size(38, 38);
            this.btnCreateAnimation.TabIndex = 3;
            this.btnCreateAnimation.UseVisualStyleBackColor = true;
            this.btnCreateAnimation.Click += new System.EventHandler(this.btnCreateAnimation_Click);
            // 
            // txbDelayTime
            // 
            this.txbDelayTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbDelayTime.Location = new System.Drawing.Point(190, 36);
            this.txbDelayTime.Name = "txbDelayTime";
            this.txbDelayTime.Size = new System.Drawing.Size(85, 20);
            this.txbDelayTime.TabIndex = 5;
            this.txbDelayTime.Text = "100";
            this.txbDelayTime.Leave += new System.EventHandler(this.txbDelayTime_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Задержка между слайдами";
            // 
            // chbDelTempScrs
            // 
            this.chbDelTempScrs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbDelTempScrs.AutoSize = true;
            this.chbDelTempScrs.Checked = true;
            this.chbDelTempScrs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDelTempScrs.Location = new System.Drawing.Point(225, 131);
            this.chbDelTempScrs.Name = "chbDelTempScrs";
            this.chbDelTempScrs.Size = new System.Drawing.Size(15, 14);
            this.chbDelTempScrs.TabIndex = 6;
            this.chbDelTempScrs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbDelTempScrs.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Удалить промежуточные результаты";
            // 
            // AnimationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "AnimationPage";
            this.Size = new System.Drawing.Size(413, 597);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button incrButton;
        private System.Windows.Forms.Button decrButton;
        private System.Windows.Forms.Button btnMoveToFinish;
        private System.Windows.Forms.Button btnPlayResults;
        private System.Windows.Forms.Button btnMoveToStart;
        private MB.Controls.ColorSlider colorSlider;
        private System.Windows.Forms.TextBox txbScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cmbResultNames;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnCreateAnimation;
        private System.Windows.Forms.TextBox txbDelayTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbDelTempScrs;
        private System.Windows.Forms.Label label3;
    }
}
