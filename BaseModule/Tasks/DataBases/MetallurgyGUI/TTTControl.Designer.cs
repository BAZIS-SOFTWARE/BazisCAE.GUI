namespace BaseModule.Tasks.DataBases.MetallurgyGUI
{
    partial class TTTControl
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
            this.txbFinTemp = new System.Windows.Forms.TextBox();
            this.txbIniTemp = new System.Windows.Forms.TextBox();
            this.nudTemps = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbMaxPhase = new System.Windows.Forms.TextBox();
            this.txbMinPhase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPhases = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbMaxTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemps)).BeginInit();
            this.SuspendLayout();
            // 
            // txbFinTemp
            // 
            this.txbFinTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbFinTemp.Location = new System.Drawing.Point(104, 108);
            this.txbFinTemp.Name = "txbFinTemp";
            this.txbFinTemp.Size = new System.Drawing.Size(254, 20);
            this.txbFinTemp.TabIndex = 11;
            this.txbFinTemp.Text = "20";
            // 
            // txbIniTemp
            // 
            this.txbIniTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbIniTemp.Location = new System.Drawing.Point(104, 82);
            this.txbIniTemp.Name = "txbIniTemp";
            this.txbIniTemp.Size = new System.Drawing.Size(254, 20);
            this.txbIniTemp.TabIndex = 12;
            this.txbIniTemp.Text = "800";
            // 
            // nudTemps
            // 
            this.nudTemps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTemps.Location = new System.Drawing.Point(104, 56);
            this.nudTemps.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudTemps.Name = "nudTemps";
            this.nudTemps.Size = new System.Drawing.Size(254, 20);
            this.nudTemps.TabIndex = 10;
            this.nudTemps.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Мак. фаза, у.ед.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Мин. фаза, у.ед.";
            // 
            // txbMaxPhase
            // 
            this.txbMaxPhase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxPhase.Location = new System.Drawing.Point(104, 29);
            this.txbMaxPhase.Name = "txbMaxPhase";
            this.txbMaxPhase.Size = new System.Drawing.Size(254, 20);
            this.txbMaxPhase.TabIndex = 6;
            this.txbMaxPhase.Text = "1";
            // 
            // txbMinPhase
            // 
            this.txbMinPhase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMinPhase.Location = new System.Drawing.Point(104, 3);
            this.txbMinPhase.Name = "txbMinPhase";
            this.txbMinPhase.Size = new System.Drawing.Size(254, 20);
            this.txbMinPhase.TabIndex = 7;
            this.txbMinPhase.Text = "0.01";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Мак. темп, °С";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Мин. темп, °С";
            // 
            // cmbPhases
            // 
            this.cmbPhases.AccessibleName = "InitialPhase";
            this.cmbPhases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPhases.FormattingEnabled = true;
            this.cmbPhases.Location = new System.Drawing.Point(104, 134);
            this.cmbPhases.Name = "cmbPhases";
            this.cmbPhases.Size = new System.Drawing.Size(254, 21);
            this.cmbPhases.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Начальная фаза";
            // 
            // txbMaxTime
            // 
            this.txbMaxTime.AccessibleName = "Время";
            this.txbMaxTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxTime.Location = new System.Drawing.Point(104, 161);
            this.txbMaxTime.Name = "txbMaxTime";
            this.txbMaxTime.Size = new System.Drawing.Size(254, 20);
            this.txbMaxTime.TabIndex = 17;
            this.txbMaxTime.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Время, сек";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Кол - во";
            // 
            // TTTControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbMaxTime);
            this.Controls.Add(this.cmbPhases);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbFinTemp);
            this.Controls.Add(this.txbIniTemp);
            this.Controls.Add(this.nudTemps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbMaxPhase);
            this.Controls.Add(this.txbMinPhase);
            this.Name = "TTTControl";
            this.Size = new System.Drawing.Size(361, 195);
            ((System.ComponentModel.ISupportInitialize)(this.nudTemps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbFinTemp;
        private System.Windows.Forms.TextBox txbIniTemp;
        private System.Windows.Forms.NumericUpDown nudTemps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbMaxPhase;
        private System.Windows.Forms.TextBox txbMinPhase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPhases;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbMaxTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
