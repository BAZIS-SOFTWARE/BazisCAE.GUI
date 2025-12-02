namespace BazisGUI.CrossSection
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
            btnCreateCross = new System.Windows.Forms.Button();
            chbSelectPoints = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            txbPoint1 = new System.Windows.Forms.TextBox();
            txbPoint2 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txbPoint3 = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            rbtXY = new System.Windows.Forms.RadioButton();
            rbtXZ = new System.Windows.Forms.RadioButton();
            rbtYZ = new System.Windows.Forms.RadioButton();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            btnRemoveCross = new System.Windows.Forms.Button();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // btnCreateCross
            // 
            btnCreateCross.Dock = System.Windows.Forms.DockStyle.Fill;
            btnCreateCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCreateCross.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            btnCreateCross.Location = new System.Drawing.Point(67, 249);
            btnCreateCross.Margin = new System.Windows.Forms.Padding(2);
            btnCreateCross.Name = "btnCreateCross";
            btnCreateCross.Size = new System.Drawing.Size(118, 35);
            btnCreateCross.TabIndex = 16;
            btnCreateCross.Text = "Построить";
            btnCreateCross.UseVisualStyleBackColor = true;
            btnCreateCross.Click += btnCreatePlane_Click;
            // 
            // chbSelectPoints
            // 
            chbSelectPoints.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            chbSelectPoints.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(chbSelectPoints, 2);
            chbSelectPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            chbSelectPoints.Location = new System.Drawing.Point(71, 135);
            chbSelectPoints.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            chbSelectPoints.Name = "chbSelectPoints";
            chbSelectPoints.Size = new System.Drawing.Size(164, 35);
            chbSelectPoints.TabIndex = 13;
            chbSelectPoints.Text = "Задать с экрана по точкам";
            chbSelectPoints.UseVisualStyleBackColor = true;
            chbSelectPoints.CheckedChanged += chbSelectPoints_CheckedChanged;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            label1.Location = new System.Drawing.Point(9, 16);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 13);
            label1.TabIndex = 4;
            label1.Text = "Точка 1";
            // 
            // txbPoint1
            // 
            txbPoint1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            txbPoint1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tableLayoutPanel3.SetColumnSpan(txbPoint1, 2);
            txbPoint1.Location = new System.Drawing.Point(73, 11);
            txbPoint1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            txbPoint1.Name = "txbPoint1";
            txbPoint1.Size = new System.Drawing.Size(234, 23);
            txbPoint1.TabIndex = 17;
            txbPoint1.Text = "0;0;0";
            // 
            // txbPoint2
            // 
            txbPoint2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            txbPoint2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tableLayoutPanel3.SetColumnSpan(txbPoint2, 2);
            txbPoint2.Location = new System.Drawing.Point(73, 56);
            txbPoint2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            txbPoint2.Name = "txbPoint2";
            txbPoint2.Size = new System.Drawing.Size(234, 23);
            txbPoint2.TabIndex = 18;
            txbPoint2.Text = "0;0;0";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            label2.Location = new System.Drawing.Point(9, 61);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 13);
            label2.TabIndex = 5;
            label2.Text = "Точка 2";
            // 
            // txbPoint3
            // 
            txbPoint3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            txbPoint3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tableLayoutPanel3.SetColumnSpan(txbPoint3, 2);
            txbPoint3.Location = new System.Drawing.Point(73, 101);
            txbPoint3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            txbPoint3.Name = "txbPoint3";
            txbPoint3.Size = new System.Drawing.Size(234, 23);
            txbPoint3.TabIndex = 19;
            txbPoint3.Text = "0;0;0";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            label3.Location = new System.Drawing.Point(9, 106);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(46, 13);
            label3.TabIndex = 6;
            label3.Text = "Точка 3";
            // 
            // rbtXY
            // 
            rbtXY.Anchor = System.Windows.Forms.AnchorStyles.None;
            rbtXY.AutoSize = true;
            rbtXY.Location = new System.Drawing.Point(13, 143);
            rbtXY.Margin = new System.Windows.Forms.Padding(0);
            rbtXY.Name = "rbtXY";
            rbtXY.Size = new System.Drawing.Size(39, 19);
            rbtXY.TabIndex = 5;
            rbtXY.TabStop = true;
            rbtXY.Text = "XY";
            rbtXY.UseVisualStyleBackColor = true;
            rbtXY.CheckedChanged += RbtXY_CheckedChanged;
            // 
            // rbtXZ
            // 
            rbtXZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            rbtXZ.AutoSize = true;
            rbtXZ.Location = new System.Drawing.Point(13, 178);
            rbtXZ.Margin = new System.Windows.Forms.Padding(0);
            rbtXZ.Name = "rbtXZ";
            rbtXZ.Size = new System.Drawing.Size(39, 19);
            rbtXZ.TabIndex = 4;
            rbtXZ.TabStop = true;
            rbtXZ.Text = "XZ";
            rbtXZ.UseVisualStyleBackColor = true;
            rbtXZ.CheckedChanged += RbtXZ_CheckedChanged;
            // 
            // rbtYZ
            // 
            rbtYZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            rbtYZ.AutoSize = true;
            rbtYZ.Location = new System.Drawing.Point(13, 216);
            rbtYZ.Margin = new System.Windows.Forms.Padding(0);
            rbtYZ.Name = "rbtYZ";
            rbtYZ.Size = new System.Drawing.Size(39, 19);
            rbtYZ.TabIndex = 3;
            rbtYZ.TabStop = true;
            rbtYZ.Text = "YZ";
            rbtYZ.UseVisualStyleBackColor = true;
            rbtYZ.CheckedChanged += RbtYZ_CheckedChanged;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            tableLayoutPanel3.Controls.Add(rbtYZ, 0, 5);
            tableLayoutPanel3.Controls.Add(rbtXZ, 0, 4);
            tableLayoutPanel3.Controls.Add(rbtXY, 0, 3);
            tableLayoutPanel3.Controls.Add(label3, 0, 2);
            tableLayoutPanel3.Controls.Add(txbPoint3, 1, 2);
            tableLayoutPanel3.Controls.Add(label2, 0, 1);
            tableLayoutPanel3.Controls.Add(txbPoint2, 1, 1);
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(txbPoint1, 1, 0);
            tableLayoutPanel3.Controls.Add(btnCreateCross, 1, 6);
            tableLayoutPanel3.Controls.Add(chbSelectPoints, 1, 3);
            tableLayoutPanel3.Controls.Add(btnRemoveCross, 2, 6);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 7;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            tableLayoutPanel3.Size = new System.Drawing.Size(313, 286);
            tableLayoutPanel3.TabIndex = 14;
            // 
            // btnRemoveCross
            // 
            btnRemoveCross.Dock = System.Windows.Forms.DockStyle.Fill;
            btnRemoveCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRemoveCross.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            btnRemoveCross.Location = new System.Drawing.Point(189, 249);
            btnRemoveCross.Margin = new System.Windows.Forms.Padding(2);
            btnRemoveCross.Name = "btnRemoveCross";
            btnRemoveCross.Size = new System.Drawing.Size(122, 35);
            btnRemoveCross.TabIndex = 20;
            btnRemoveCross.Text = "Удалить";
            btnRemoveCross.UseVisualStyleBackColor = true;
            btnRemoveCross.Click += btnRemoveCross_Click;
            // 
            // CrossSectionControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(tableLayoutPanel3);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "CrossSectionControl";
            Size = new System.Drawing.Size(313, 286);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
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
