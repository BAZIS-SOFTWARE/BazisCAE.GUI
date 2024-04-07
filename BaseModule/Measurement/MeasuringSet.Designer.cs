namespace BaseModule
{
    partial class MeasuringSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbtnDistance = new System.Windows.Forms.RadioButton();
            this.rbtnPath = new System.Windows.Forms.RadioButton();
            this.rbtSquare = new System.Windows.Forms.RadioButton();
            this.rbtVolume = new System.Windows.Forms.RadioButton();
            this.cmbMeasureObjects = new System.Windows.Forms.ComboBox();
            this.btnMeasure = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnDistance
            // 
            this.rbtnDistance.AutoSize = true;
            this.rbtnDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtnDistance.Location = new System.Drawing.Point(16, 18);
            this.rbtnDistance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnDistance.Name = "rbtnDistance";
            this.rbtnDistance.Size = new System.Drawing.Size(133, 21);
            this.rbtnDistance.TabIndex = 0;
            this.rbtnDistance.Text = "Расстояние, мм";
            this.rbtnDistance.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbtnDistance.UseVisualStyleBackColor = true;
            this.rbtnDistance.Click += new System.EventHandler(this.Rbtn_Click);
            // 
            // rbtnPath
            // 
            this.rbtnPath.AutoSize = true;
            this.rbtnPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtnPath.Location = new System.Drawing.Point(16, 103);
            this.rbtnPath.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnPath.Name = "rbtnPath";
            this.rbtnPath.Size = new System.Drawing.Size(86, 21);
            this.rbtnPath.TabIndex = 1;
            this.rbtnPath.Text = "Путь, мм";
            this.rbtnPath.UseVisualStyleBackColor = true;
            this.rbtnPath.Click += new System.EventHandler(this.Rbtn_Click);
            // 
            // rbtSquare
            // 
            this.rbtSquare.AutoSize = true;
            this.rbtSquare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtSquare.Location = new System.Drawing.Point(16, 76);
            this.rbtSquare.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtSquare.Name = "rbtSquare";
            this.rbtSquare.Size = new System.Drawing.Size(130, 21);
            this.rbtSquare.TabIndex = 2;
            this.rbtSquare.Text = "Площадь, мм^2";
            this.rbtSquare.UseVisualStyleBackColor = true;
            this.rbtSquare.Click += new System.EventHandler(this.Rbtn_Click);
            // 
            // rbtVolume
            // 
            this.rbtVolume.AutoSize = true;
            this.rbtVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtVolume.Location = new System.Drawing.Point(16, 47);
            this.rbtVolume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtVolume.Name = "rbtVolume";
            this.rbtVolume.Size = new System.Drawing.Size(115, 21);
            this.rbtVolume.TabIndex = 3;
            this.rbtVolume.Text = "Объем, мм^3";
            this.rbtVolume.UseVisualStyleBackColor = true;
            this.rbtVolume.Click += new System.EventHandler(this.Rbtn_Click);
            // 
            // cmbMeasureObjects
            // 
            this.cmbMeasureObjects.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmbMeasureObjects.Enabled = false;
            this.cmbMeasureObjects.FormattingEnabled = true;
            this.cmbMeasureObjects.Items.AddRange(new object[] {
            "Между двумя точками",
            "Между точкой и плоскостью"});
            this.cmbMeasureObjects.Location = new System.Drawing.Point(208, 58);
            this.cmbMeasureObjects.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.cmbMeasureObjects.Name = "cmbMeasureObjects";
            this.cmbMeasureObjects.Size = new System.Drawing.Size(173, 24);
            this.cmbMeasureObjects.TabIndex = 4;
            this.cmbMeasureObjects.SelectedIndexChanged += new System.EventHandler(this.cmbMeasureObjects_SelectedIndexChanged);
            // 
            // btnMeasure
            // 
            this.btnMeasure.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMeasure.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMeasure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMeasure.Location = new System.Drawing.Point(207, 149);
            this.btnMeasure.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(174, 32);
            this.btnMeasure.TabIndex = 5;
            this.btnMeasure.Text = "Измерить";
            this.btnMeasure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMeasure.UseVisualStyleBackColor = true;
            this.btnMeasure.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.72414F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.27586F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbMeasureObjects, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMeasure, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(388, 190);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtVolume);
            this.panel1.Controls.Add(this.rbtnDistance);
            this.panel1.Controls.Add(this.rbtSquare);
            this.panel1.Controls.Add(this.rbtnPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 137);
            this.panel1.TabIndex = 6;
            // 
            // MeasuringSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(291, 190);
            this.Name = "MeasuringSet";
            this.Size = new System.Drawing.Size(388, 190);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnDistance;
        private System.Windows.Forms.RadioButton rbtnPath;
        private System.Windows.Forms.RadioButton rbtSquare;
        private System.Windows.Forms.RadioButton rbtVolume;
        private System.Windows.Forms.ComboBox cmbMeasureObjects;
        private System.Windows.Forms.Button btnMeasure;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}