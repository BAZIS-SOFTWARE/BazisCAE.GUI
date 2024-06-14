namespace BaseModule.CrossSection
{
    partial class CrossSectionControl
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
            this.btnCreateCross = new System.Windows.Forms.Button();
            this.chbSelectPoints = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbPoint1 = new System.Windows.Forms.TextBox();
            this.txbPoint2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbPoint3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtXY = new System.Windows.Forms.RadioButton();
            this.rbtXZ = new System.Windows.Forms.RadioButton();
            this.rbtYZ = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemoveCross = new System.Windows.Forms.Button();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateCross
            // 
            this.btnCreateCross.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreateCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateCross.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateCross.Location = new System.Drawing.Point(60, 210);
            this.btnCreateCross.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCreateCross.Name = "btnCreateCross";
            this.btnCreateCross.Size = new System.Drawing.Size(95, 32);
            this.btnCreateCross.TabIndex = 16;
            this.btnCreateCross.Text = "Построить";
            this.btnCreateCross.UseVisualStyleBackColor = true;
            this.btnCreateCross.Click += new System.EventHandler(this.btnCreatePlane_Click);
            // 
            // chbSelectPoints
            // 
            this.chbSelectPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chbSelectPoints.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.chbSelectPoints, 2);
            this.chbSelectPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbSelectPoints.Location = new System.Drawing.Point(60, 102);
            this.chbSelectPoints.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chbSelectPoints.Name = "chbSelectPoints";
            this.chbSelectPoints.Size = new System.Drawing.Size(116, 34);
            this.chbSelectPoints.TabIndex = 13;
            this.chbSelectPoints.Text = "Задать по точкам";
            this.chbSelectPoints.UseVisualStyleBackColor = true;
            this.chbSelectPoints.CheckedChanged += new System.EventHandler(this.chbSelectPoints_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Точка 1";
            // 
            // txbPoint1
            // 
            this.txbPoint1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txbPoint1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel3.SetColumnSpan(this.txbPoint1, 2);
            this.txbPoint1.Location = new System.Drawing.Point(62, 7);
            this.txbPoint1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txbPoint1.Name = "txbPoint1";
            this.txbPoint1.Size = new System.Drawing.Size(201, 20);
            this.txbPoint1.TabIndex = 17;
            this.txbPoint1.Text = "0;0;0";
            // 
            // txbPoint2
            // 
            this.txbPoint2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txbPoint2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel3.SetColumnSpan(this.txbPoint2, 2);
            this.txbPoint2.Location = new System.Drawing.Point(62, 41);
            this.txbPoint2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txbPoint2.Name = "txbPoint2";
            this.txbPoint2.Size = new System.Drawing.Size(201, 20);
            this.txbPoint2.TabIndex = 18;
            this.txbPoint2.Text = "0;0;0";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Точка 2";
            // 
            // txbPoint3
            // 
            this.txbPoint3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txbPoint3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel3.SetColumnSpan(this.txbPoint3, 2);
            this.txbPoint3.Location = new System.Drawing.Point(62, 75);
            this.txbPoint3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txbPoint3.Name = "txbPoint3";
            this.txbPoint3.Size = new System.Drawing.Size(201, 20);
            this.txbPoint3.TabIndex = 19;
            this.txbPoint3.Text = "0;0;0";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(4, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Точка 3";
            // 
            // rbtXY
            // 
            this.rbtXY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtXY.AutoSize = true;
            this.rbtXY.Location = new System.Drawing.Point(8, 110);
            this.rbtXY.Margin = new System.Windows.Forms.Padding(0);
            this.rbtXY.Name = "rbtXY";
            this.rbtXY.Size = new System.Drawing.Size(39, 17);
            this.rbtXY.TabIndex = 5;
            this.rbtXY.TabStop = true;
            this.rbtXY.Text = "XY";
            this.rbtXY.UseVisualStyleBackColor = true;
            this.rbtXY.CheckedChanged += new System.EventHandler(this.RbtXY_CheckedChanged);
            // 
            // rbtXZ
            // 
            this.rbtXZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtXZ.AutoSize = true;
            this.rbtXZ.Location = new System.Drawing.Point(8, 144);
            this.rbtXZ.Margin = new System.Windows.Forms.Padding(0);
            this.rbtXZ.Name = "rbtXZ";
            this.rbtXZ.Size = new System.Drawing.Size(39, 17);
            this.rbtXZ.TabIndex = 4;
            this.rbtXZ.TabStop = true;
            this.rbtXZ.Text = "XZ";
            this.rbtXZ.UseVisualStyleBackColor = true;
            this.rbtXZ.CheckedChanged += new System.EventHandler(this.RbtXZ_CheckedChanged);
            // 
            // rbtYZ
            // 
            this.rbtYZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtYZ.AutoSize = true;
            this.rbtYZ.Location = new System.Drawing.Point(8, 178);
            this.rbtYZ.Margin = new System.Windows.Forms.Padding(0);
            this.rbtYZ.Name = "rbtYZ";
            this.rbtYZ.Size = new System.Drawing.Size(39, 17);
            this.rbtYZ.TabIndex = 3;
            this.rbtYZ.TabStop = true;
            this.rbtYZ.Text = "YZ";
            this.rbtYZ.UseVisualStyleBackColor = true;
            this.rbtYZ.CheckedChanged += new System.EventHandler(this.RbtYZ_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel3.Controls.Add(this.rbtYZ, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.rbtXZ, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.rbtXY, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txbPoint3, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txbPoint2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txbPoint1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCreateCross, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.chbSelectPoints, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.btnRemoveCross, 2, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(268, 248);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // btnRemoveCross
            // 
            this.btnRemoveCross.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCross.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveCross.Location = new System.Drawing.Point(165, 210);
            this.btnRemoveCross.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnRemoveCross.Name = "btnRemoveCross";
            this.btnRemoveCross.Size = new System.Drawing.Size(98, 32);
            this.btnRemoveCross.TabIndex = 20;
            this.btnRemoveCross.Text = "Удалить";
            this.btnRemoveCross.UseVisualStyleBackColor = true;
            this.btnRemoveCross.Click += new System.EventHandler(this.btnRemoveCross_Click);
            // 
            // CrossSectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CrossSectionControl";
            this.Size = new System.Drawing.Size(268, 248);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCreateCross;
        private System.Windows.Forms.CheckBox chbSelectPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbPoint1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton rbtYZ;
        private System.Windows.Forms.RadioButton rbtXZ;
        private System.Windows.Forms.RadioButton rbtXY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbPoint3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbPoint2;
        private System.Windows.Forms.Button btnRemoveCross;
    }
}
