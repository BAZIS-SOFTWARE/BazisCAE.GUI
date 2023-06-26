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
            this.SuspendLayout();
            // 
            // rbtnDistance
            // 
            this.rbtnDistance.AutoSize = true;
            this.rbtnDistance.Location = new System.Drawing.Point(3, 4);
            this.rbtnDistance.Name = "rbtnDistance";
            this.rbtnDistance.Size = new System.Drawing.Size(107, 17);
            this.rbtnDistance.TabIndex = 0;
            this.rbtnDistance.Text = "Расстояние, мм";
            this.rbtnDistance.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbtnDistance.UseVisualStyleBackColor = true;
            this.rbtnDistance.Click += new System.EventHandler(this.Rbtn_Click);
            // 
            // rbtnPath
            // 
            this.rbtnPath.AutoSize = true;
            this.rbtnPath.Location = new System.Drawing.Point(3, 73);
            this.rbtnPath.Name = "rbtnPath";
            this.rbtnPath.Size = new System.Drawing.Size(71, 17);
            this.rbtnPath.TabIndex = 1;
            this.rbtnPath.Text = "Путь, мм";
            this.rbtnPath.UseVisualStyleBackColor = true;
            this.rbtnPath.Click += new System.EventHandler(this.Rbtn_Click);
            // 
            // rbtSquare
            // 
            this.rbtSquare.AutoSize = true;
            this.rbtSquare.Location = new System.Drawing.Point(3, 50);
            this.rbtSquare.Name = "rbtSquare";
            this.rbtSquare.Size = new System.Drawing.Size(106, 17);
            this.rbtSquare.TabIndex = 2;
            this.rbtSquare.Text = "Площадь, мм^2";
            this.rbtSquare.UseVisualStyleBackColor = true;
            this.rbtSquare.Click += new System.EventHandler(this.Rbtn_Click);
            // 
            // rbtVolume
            // 
            this.rbtVolume.AutoSize = true;
            this.rbtVolume.Location = new System.Drawing.Point(3, 27);
            this.rbtVolume.Name = "rbtVolume";
            this.rbtVolume.Size = new System.Drawing.Size(94, 17);
            this.rbtVolume.TabIndex = 3;
            this.rbtVolume.Text = "Объем, мм^3";
            this.rbtVolume.UseVisualStyleBackColor = true;
            this.rbtVolume.Click += new System.EventHandler(this.Rbtn_Click);
            // 
            // cmbMeasureObjects
            // 
            this.cmbMeasureObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMeasureObjects.FormattingEnabled = true;
            this.cmbMeasureObjects.Items.AddRange(new object[] {
            "Между двумя точками",
            "Между точкой и плоскостью"});
            this.cmbMeasureObjects.Location = new System.Drawing.Point(126, 3);
            this.cmbMeasureObjects.Name = "cmbMeasureObjects";
            this.cmbMeasureObjects.Size = new System.Drawing.Size(274, 21);
            this.cmbMeasureObjects.TabIndex = 4;
            this.cmbMeasureObjects.SelectedIndexChanged += new System.EventHandler(this.cmbMeasureObjects_SelectedIndexChanged);
            // 
            // btnMeasure
            // 
            this.btnMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMeasure.AutoSize = true;
            this.btnMeasure.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMeasure.Image = global::BaseModule.Properties.Resources.Measure_32x32;
            this.btnMeasure.Location = new System.Drawing.Point(362, 243);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(38, 38);
            this.btnMeasure.TabIndex = 5;
            this.btnMeasure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMeasure.UseVisualStyleBackColor = true;
            this.btnMeasure.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // MeasuringSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMeasure);
            this.Controls.Add(this.cmbMeasureObjects);
            this.Controls.Add(this.rbtVolume);
            this.Controls.Add(this.rbtSquare);
            this.Controls.Add(this.rbtnPath);
            this.Controls.Add(this.rbtnDistance);
            this.Name = "MeasuringSet";
            this.Size = new System.Drawing.Size(412, 294);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnDistance;
        private System.Windows.Forms.RadioButton rbtnPath;
        private System.Windows.Forms.RadioButton rbtSquare;
        private System.Windows.Forms.RadioButton rbtVolume;
        private System.Windows.Forms.ComboBox cmbMeasureObjects;
        private System.Windows.Forms.Button btnMeasure;
    }
}