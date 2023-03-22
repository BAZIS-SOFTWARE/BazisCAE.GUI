namespace ResultControl
{
    partial class ScalePage
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
            this.chbShowScale = new System.Windows.Forms.CheckBox();
            this.upd_YCoord = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.upd_XCoord = new System.Windows.Forms.NumericUpDown();
            this.updIntervals = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbMin = new System.Windows.Forms.TextBox();
            this.updPrecision = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upd_YCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upd_XCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updIntervals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updPrecision)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chbShowScale, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.upd_YCoord, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.upd_XCoord, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.updIntervals, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txbMax, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txbMin, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.updPrecision, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.86143F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.21657F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.922F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(466, 322);
            this.tableLayoutPanel1.TabIndex = 43;
            // 
            // chbShowScale
            // 
            this.chbShowScale.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbShowScale.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chbShowScale, 4);
            this.chbShowScale.Location = new System.Drawing.Point(15, 11);
            this.chbShowScale.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.chbShowScale.Name = "chbShowScale";
            this.chbShowScale.Size = new System.Drawing.Size(109, 17);
            this.chbShowScale.TabIndex = 41;
            this.chbShowScale.Text = "Показать шкалу";
            this.chbShowScale.UseVisualStyleBackColor = true;
            this.chbShowScale.Click += new System.EventHandler(this.chbShowScale_Click);
            // 
            // upd_YCoord
            // 
            this.upd_YCoord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.upd_YCoord.Location = new System.Drawing.Point(311, 274);
            this.upd_YCoord.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.upd_YCoord.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.upd_YCoord.Name = "upd_YCoord";
            this.upd_YCoord.Size = new System.Drawing.Size(102, 20);
            this.upd_YCoord.TabIndex = 34;
            this.upd_YCoord.Value = new decimal(new int[] {
            170,
            0,
            0,
            0});
            this.upd_YCoord.ValueChanged += new System.EventHandler(this.upd_YCoord_ValueChanged);
            this.upd_YCoord.Leave += new System.EventHandler(this.upd_YCoord_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 4);
            this.label4.Location = new System.Drawing.Point(15, 222);
            this.label4.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Положение шкалы";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "по Y :";
            // 
            // upd_XCoord
            // 
            this.upd_XCoord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.upd_XCoord.Location = new System.Drawing.Point(103, 274);
            this.upd_XCoord.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.upd_XCoord.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.upd_XCoord.Name = "upd_XCoord";
            this.upd_XCoord.Size = new System.Drawing.Size(102, 20);
            this.upd_XCoord.TabIndex = 34;
            this.upd_XCoord.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.upd_XCoord.ValueChanged += new System.EventHandler(this.upd_XCoord_ValueChanged);
            this.upd_XCoord.VisibleChanged += new System.EventHandler(this.upd_XCoord_ValueChanged);
            // 
            // updIntervals
            // 
            this.updIntervals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.updIntervals.Location = new System.Drawing.Point(311, 152);
            this.updIntervals.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.updIntervals.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updIntervals.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updIntervals.Name = "updIntervals";
            this.updIntervals.Size = new System.Drawing.Size(102, 20);
            this.updIntervals.TabIndex = 39;
            this.updIntervals.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updIntervals.ValueChanged += new System.EventHandler(this.updIntervals_ValueChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(241, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Интервалы";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "по X :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 79);
            this.label2.TabIndex = 16;
            this.label2.Text = "Max";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbMax
            // 
            this.txbMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMax.Location = new System.Drawing.Point(103, 68);
            this.txbMax.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txbMax.Name = "txbMax";
            this.txbMax.Size = new System.Drawing.Size(102, 20);
            this.txbMax.TabIndex = 15;
            this.txbMax.Text = "1";
            this.txbMax.Leave += new System.EventHandler(this.txbMax_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Min";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Точность";
            // 
            // txbMin
            // 
            this.txbMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMin.Location = new System.Drawing.Point(311, 68);
            this.txbMin.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txbMin.Name = "txbMin";
            this.txbMin.Size = new System.Drawing.Size(102, 20);
            this.txbMin.TabIndex = 17;
            this.txbMin.Text = "0";
            this.txbMin.Leave += new System.EventHandler(this.txbMin_Leave);
            // 
            // updPrecision
            // 
            this.updPrecision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.updPrecision.Location = new System.Drawing.Point(103, 152);
            this.updPrecision.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.updPrecision.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.updPrecision.Name = "updPrecision";
            this.updPrecision.Size = new System.Drawing.Size(102, 20);
            this.updPrecision.TabIndex = 34;
            this.updPrecision.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.updPrecision.ValueChanged += new System.EventHandler(this.updPrecision_ValueChanged);
            // 
            // ScalePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ScalePage";
            this.Size = new System.Drawing.Size(466, 322);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upd_YCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upd_XCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updIntervals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updPrecision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chbShowScale;
        private System.Windows.Forms.NumericUpDown upd_YCoord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown upd_XCoord;
        private System.Windows.Forms.NumericUpDown updIntervals;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbMin;
        private System.Windows.Forms.NumericUpDown updPrecision;
    }
}
