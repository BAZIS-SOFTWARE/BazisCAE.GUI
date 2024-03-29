namespace ResultModule
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
            this.txbMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbMin = new System.Windows.Forms.TextBox();
            this.updPrecision = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.chbMaxMinAuto = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upd_YCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upd_XCoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updIntervals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updPrecision)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 227F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.chbShowScale, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.upd_YCoord, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.upd_XCoord, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.updIntervals, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txbMax, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txbMin, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.updPrecision, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.86143F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.21657F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.922F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 300);
            this.tableLayoutPanel1.TabIndex = 43;
            // 
            // chbShowScale
            // 
            this.chbShowScale.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbShowScale.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chbShowScale, 4);
            this.chbShowScale.Location = new System.Drawing.Point(21, 14);
            this.chbShowScale.Margin = new System.Windows.Forms.Padding(21, 3, 5, 3);
            this.chbShowScale.Name = "chbShowScale";
            this.chbShowScale.Size = new System.Drawing.Size(137, 21);
            this.chbShowScale.TabIndex = 41;
            this.chbShowScale.Text = "Показать шкалу";
            this.chbShowScale.UseVisualStyleBackColor = true;
            this.chbShowScale.Click += new System.EventHandler(this.chbShowScale_Click);
            // 
            // upd_YCoord
            // 
            this.upd_YCoord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.upd_YCoord.Location = new System.Drawing.Point(471, 256);
            this.upd_YCoord.Margin = new System.Windows.Forms.Padding(5, 0, 5, 3);
            this.upd_YCoord.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.upd_YCoord.Name = "upd_YCoord";
            this.upd_YCoord.Size = new System.Drawing.Size(124, 23);
            this.upd_YCoord.TabIndex = 34;
            this.upd_YCoord.Value = new decimal(new int[] {
            170,
            0,
            0,
            0});
            this.upd_YCoord.Leave += new System.EventHandler(this.upd_YCoord_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 4);
            this.label4.Location = new System.Drawing.Point(21, 206);
            this.label4.Margin = new System.Windows.Forms.Padding(21, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 17);
            this.label4.TabIndex = 36;
            this.label4.Text = "Положение шкалы";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(416, 261);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "по Y :";
            // 
            // upd_XCoord
            // 
            this.upd_XCoord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.upd_XCoord.Location = new System.Drawing.Point(232, 256);
            this.upd_XCoord.Margin = new System.Windows.Forms.Padding(5, 0, 5, 3);
            this.upd_XCoord.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.upd_XCoord.Name = "upd_XCoord";
            this.upd_XCoord.Size = new System.Drawing.Size(123, 23);
            this.upd_XCoord.TabIndex = 34;
            this.upd_XCoord.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.upd_XCoord.Leave += new System.EventHandler(this.upd_XCoord_Leave);
            // 
            // updIntervals
            // 
            this.updIntervals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.updIntervals.Location = new System.Drawing.Point(471, 139);
            this.updIntervals.Margin = new System.Windows.Forms.Padding(5, 0, 5, 3);
            this.updIntervals.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updIntervals.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.updIntervals.Name = "updIntervals";
            this.updIntervals.Size = new System.Drawing.Size(124, 23);
            this.updIntervals.TabIndex = 39;
            this.updIntervals.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updIntervals.Leave += new System.EventHandler(this.updIntervals_Leave);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(379, 144);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 17);
            this.label9.TabIndex = 40;
            this.label9.Text = "Интервалы";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 261);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "по X :";
            // 
            // txbMax
            // 
            this.txbMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMax.Location = new System.Drawing.Point(232, 69);
            this.txbMax.Margin = new System.Windows.Forms.Padding(5, 0, 5, 3);
            this.txbMax.Name = "txbMax";
            this.txbMax.Size = new System.Drawing.Size(123, 23);
            this.txbMax.TabIndex = 15;
            this.txbMax.Text = "1";
            this.txbMax.Leave += new System.EventHandler(this.txbMax_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Min";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "Точность";
            // 
            // txbMin
            // 
            this.txbMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMin.Location = new System.Drawing.Point(471, 69);
            this.txbMin.Margin = new System.Windows.Forms.Padding(5, 0, 5, 3);
            this.txbMin.Name = "txbMin";
            this.txbMin.Size = new System.Drawing.Size(124, 23);
            this.txbMin.TabIndex = 17;
            this.txbMin.Text = "0";
            this.txbMin.Leave += new System.EventHandler(this.txbMin_Leave);
            // 
            // updPrecision
            // 
            this.updPrecision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.updPrecision.Location = new System.Drawing.Point(232, 139);
            this.updPrecision.Margin = new System.Windows.Forms.Padding(5, 0, 5, 3);
            this.updPrecision.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.updPrecision.Name = "updPrecision";
            this.updPrecision.Size = new System.Drawing.Size(123, 23);
            this.updPrecision.TabIndex = 34;
            this.updPrecision.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.updPrecision.Leave += new System.EventHandler(this.updPrecision_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chbMaxMinAuto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 66);
            this.panel1.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Max";
            // 
            // chbMaxMinAuto
            // 
            this.chbMaxMinAuto.AutoSize = true;
            this.chbMaxMinAuto.Location = new System.Drawing.Point(21, 23);
            this.chbMaxMinAuto.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.chbMaxMinAuto.Name = "chbMaxMinAuto";
            this.chbMaxMinAuto.Size = new System.Drawing.Size(199, 26);
            this.chbMaxMinAuto.TabIndex = 0;
            this.chbMaxMinAuto.Text = "Уточнить значения";
            this.chbMaxMinAuto.UseVisualStyleBackColor = true;
            this.chbMaxMinAuto.CheckedChanged += new System.EventHandler(this.chbMaxMinAuto_CheckedChanged);
            // 
            // ScalePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "ScalePage";
            this.Size = new System.Drawing.Size(600, 300);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upd_YCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upd_XCoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updIntervals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updPrecision)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox txbMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbMin;
        private System.Windows.Forms.NumericUpDown updPrecision;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbMaxMinAuto;
    }
}
