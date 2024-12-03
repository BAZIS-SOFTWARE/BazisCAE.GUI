namespace BaseModule.Tasks.DataBases.MetallurgyGUI
{
    partial class CCTControl
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
            this.txbMinVel = new System.Windows.Forms.TextBox();
            this.txbMaxVel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudVels = new System.Windows.Forms.NumericUpDown();
            this.cmbPhases = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbIniTemp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbFinTemp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudVels)).BeginInit();
            this.SuspendLayout();
            // 
            // txbMinVel
            // 
            this.txbMinVel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMinVel.Location = new System.Drawing.Point(104, 14);
            this.txbMinVel.Name = "txbMinVel";
            this.txbMinVel.Size = new System.Drawing.Size(156, 20);
            this.txbMinVel.TabIndex = 0;
            this.txbMinVel.Text = "-0.01";
            // 
            // txbMaxVel
            // 
            this.txbMaxVel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxVel.Location = new System.Drawing.Point(104, 40);
            this.txbMaxVel.Name = "txbMaxVel";
            this.txbMaxVel.Size = new System.Drawing.Size(156, 20);
            this.txbMaxVel.TabIndex = 0;
            this.txbMaxVel.Text = "-100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Мин. скорость";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Мак. скорость";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Кол - во";
            // 
            // nudVels
            // 
            this.nudVels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudVels.Location = new System.Drawing.Point(104, 67);
            this.nudVels.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudVels.Name = "nudVels";
            this.nudVels.Size = new System.Drawing.Size(156, 20);
            this.nudVels.TabIndex = 3;
            this.nudVels.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cmbPhases
            // 
            this.cmbPhases.AccessibleName = "InitialPhase";
            this.cmbPhases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPhases.FormattingEnabled = true;
            this.cmbPhases.Location = new System.Drawing.Point(104, 93);
            this.cmbPhases.Name = "cmbPhases";
            this.cmbPhases.Size = new System.Drawing.Size(156, 21);
            this.cmbPhases.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Начальная фаза";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Начальная темп.";
            // 
            // txbIniTemp
            // 
            this.txbIniTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbIniTemp.Location = new System.Drawing.Point(104, 120);
            this.txbIniTemp.Name = "txbIniTemp";
            this.txbIniTemp.Size = new System.Drawing.Size(156, 20);
            this.txbIniTemp.TabIndex = 5;
            this.txbIniTemp.Text = "800";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Конечная темп.";
            // 
            // txbFinTemp
            // 
            this.txbFinTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbFinTemp.Location = new System.Drawing.Point(104, 146);
            this.txbFinTemp.Name = "txbFinTemp";
            this.txbFinTemp.Size = new System.Drawing.Size(156, 20);
            this.txbFinTemp.TabIndex = 5;
            this.txbFinTemp.Text = "20";
            // 
            // CCTControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txbFinTemp);
            this.Controls.Add(this.txbIniTemp);
            this.Controls.Add(this.cmbPhases);
            this.Controls.Add(this.nudVels);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbMaxVel);
            this.Controls.Add(this.txbMinVel);
            this.Name = "CCTControl";
            this.Size = new System.Drawing.Size(275, 232);
            ((System.ComponentModel.ISupportInitialize)(this.nudVels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbMinVel;
        private System.Windows.Forms.TextBox txbMaxVel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudVels;
        private System.Windows.Forms.ComboBox cmbPhases;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbIniTemp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbFinTemp;
    }
}
