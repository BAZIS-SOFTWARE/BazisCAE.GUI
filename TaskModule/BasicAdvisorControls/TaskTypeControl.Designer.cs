namespace TaskModule.BasicAdvisorControls
{
    partial class TaskTypeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskTypeControl));
            this.rbt3D = new System.Windows.Forms.RadioButton();
            this.rbt2Daxi = new System.Windows.Forms.RadioButton();
            this.rbt2Dplane = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbt3D
            // 
            this.rbt3D.AutoSize = true;
            this.rbt3D.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbt3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbt3D.Location = new System.Drawing.Point(3, 365);
            this.rbt3D.Name = "rbt3D";
            this.rbt3D.Size = new System.Drawing.Size(203, 176);
            this.rbt3D.TabIndex = 5;
            this.rbt3D.TabStop = true;
            this.rbt3D.UseVisualStyleBackColor = true;
            this.rbt3D.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // rbt2Daxi
            // 
            this.rbt2Daxi.AutoSize = true;
            this.rbt2Daxi.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbt2Daxi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbt2Daxi.Location = new System.Drawing.Point(3, 184);
            this.rbt2Daxi.Name = "rbt2Daxi";
            this.rbt2Daxi.Size = new System.Drawing.Size(203, 175);
            this.rbt2Daxi.TabIndex = 4;
            this.rbt2Daxi.TabStop = true;
            this.rbt2Daxi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbt2Daxi.UseVisualStyleBackColor = true;
            this.rbt2Daxi.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // rbt2Dplane
            // 
            this.rbt2Dplane.AutoSize = true;
            this.rbt2Dplane.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbt2Dplane.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbt2Dplane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbt2Dplane.Enabled = false;
            this.rbt2Dplane.Location = new System.Drawing.Point(3, 3);
            this.rbt2Dplane.Name = "rbt2Dplane";
            this.rbt2Dplane.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbt2Dplane.Size = new System.Drawing.Size(203, 175);
            this.rbt2Dplane.TabIndex = 3;
            this.rbt2Dplane.TabStop = true;
            this.rbt2Dplane.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbt2Dplane.UseVisualStyleBackColor = true;
            this.rbt2Dplane.Click += new System.EventHandler(this.RadioButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(354, 216);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(354, 54);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(260, 72);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(354, 398);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(260, 109);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.67647F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.48529F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.02206F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbt2Dplane, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbt2Daxi, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rbt3D, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(731, 544);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(212, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 181);
            this.label2.TabIndex = 13;
            this.label2.Text = "2D осесимметрия";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(212, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 181);
            this.label1.TabIndex = 12;
            this.label1.Text = "2D плоскость";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(212, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 182);
            this.label3.TabIndex = 9;
            this.label3.Text = "3D";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TaskTypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(400, 0);
            this.Name = "TaskTypeControl";
            this.Size = new System.Drawing.Size(731, 544);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RadioButton rbt3D;
        public System.Windows.Forms.RadioButton rbt2Daxi;
        public System.Windows.Forms.RadioButton rbt2Dplane;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
