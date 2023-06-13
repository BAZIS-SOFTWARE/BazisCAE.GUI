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
            this.chbShowModel = new System.Windows.Forms.CheckBox();
            this.btnCreatePlane = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbShowModel
            // 
            this.chbShowModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chbShowModel.AutoSize = true;
            this.chbShowModel.Location = new System.Drawing.Point(76, 139);
            this.chbShowModel.Name = "chbShowModel";
            this.chbShowModel.Size = new System.Drawing.Size(189, 17);
            this.chbShowModel.TabIndex = 11;
            this.chbShowModel.Text = "Показать модель";
            this.chbShowModel.UseVisualStyleBackColor = true;
            this.chbShowModel.CheckedChanged += new System.EventHandler(this.chbShowModel_CheckedChanged);
            // 
            // btnCreatePlane
            // 
            this.btnCreatePlane.AutoSize = true;
            this.btnCreatePlane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreatePlane.Location = new System.Drawing.Point(76, 167);
            this.btnCreatePlane.Name = "btnCreatePlane";
            this.btnCreatePlane.Size = new System.Drawing.Size(189, 33);
            this.btnCreatePlane.TabIndex = 16;
            this.btnCreatePlane.Text = "Построить сечение";
            this.btnCreatePlane.UseVisualStyleBackColor = true;
            this.btnCreatePlane.Click += new System.EventHandler(this.btnCreatePlane_Click_1);
            // 
            // chbSelectPoints
            // 
            this.chbSelectPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chbSelectPoints.AutoSize = true;
            this.chbSelectPoints.Location = new System.Drawing.Point(76, 102);
            this.chbSelectPoints.Name = "chbSelectPoints";
            this.chbSelectPoints.Size = new System.Drawing.Size(116, 27);
            this.chbSelectPoints.TabIndex = 13;
            this.chbSelectPoints.Text = "Задать по точкам";
            this.chbSelectPoints.UseVisualStyleBackColor = true;
            this.chbSelectPoints.CheckedChanged += new System.EventHandler(this.chbSelectPoints_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Точка 1";
            // 
            // txbPoint1
            // 
            this.txbPoint1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPoint1.Location = new System.Drawing.Point(76, 6);
            this.txbPoint1.Name = "txbPoint1";
            this.txbPoint1.Size = new System.Drawing.Size(189, 20);
            this.txbPoint1.TabIndex = 17;
            this.txbPoint1.Text = "0;0;0";
            // 
            // txbPoint2
            // 
            this.txbPoint2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPoint2.Location = new System.Drawing.Point(76, 39);
            this.txbPoint2.Name = "txbPoint2";
            this.txbPoint2.Size = new System.Drawing.Size(189, 20);
            this.txbPoint2.TabIndex = 18;
            this.txbPoint2.Text = "0;0;0";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Точка 2";
            // 
            // txbPoint3
            // 
            this.txbPoint3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPoint3.Location = new System.Drawing.Point(76, 72);
            this.txbPoint3.Name = "txbPoint3";
            this.txbPoint3.Size = new System.Drawing.Size(189, 20);
            this.txbPoint3.TabIndex = 19;
            this.txbPoint3.Text = "0;0;0";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Точка 3";
            // 
            // rbtXY
            // 
            this.rbtXY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtXY.AutoSize = true;
            this.rbtXY.Location = new System.Drawing.Point(17, 107);
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
            this.rbtXZ.Location = new System.Drawing.Point(17, 139);
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
            this.rbtYZ.Location = new System.Drawing.Point(17, 175);
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
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.41936F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.58064F));
            this.tableLayoutPanel3.Controls.Add(this.rbtYZ, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.rbtXZ, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.rbtXY, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txbPoint3, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txbPoint2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txbPoint1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.chbShowModel, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.chbSelectPoints, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.btnCreatePlane, 1, 5);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.41026F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.94872F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(268, 203);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // CrossSectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "CrossSectionControl";
            this.Size = new System.Drawing.Size(268, 203);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chbShowModel;
        private System.Windows.Forms.Button btnCreatePlane;
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
    }
}
