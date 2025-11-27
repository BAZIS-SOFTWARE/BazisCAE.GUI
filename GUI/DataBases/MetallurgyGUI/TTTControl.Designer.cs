namespace BazisGUI.DataBases.MetallurgyGUI
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
            txbFinTemp = new System.Windows.Forms.TextBox();
            txbIniTemp = new System.Windows.Forms.TextBox();
            nudTemps = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            txbMaxPhase = new System.Windows.Forms.TextBox();
            txbMinPhase = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            cmbPhases = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            txbMaxTime = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)nudTemps).BeginInit();
            SuspendLayout();
            // 
            // txbFinTemp
            // 
            txbFinTemp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbFinTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbFinTemp.Location = new System.Drawing.Point(121, 125);
            txbFinTemp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbFinTemp.Name = "txbFinTemp";
            txbFinTemp.Size = new System.Drawing.Size(296, 23);
            txbFinTemp.TabIndex = 11;
            txbFinTemp.Text = "20";
            // 
            // txbIniTemp
            // 
            txbIniTemp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbIniTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbIniTemp.Location = new System.Drawing.Point(121, 95);
            txbIniTemp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbIniTemp.Name = "txbIniTemp";
            txbIniTemp.Size = new System.Drawing.Size(296, 23);
            txbIniTemp.TabIndex = 12;
            txbIniTemp.Text = "800";
            // 
            // nudTemps
            // 
            nudTemps.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudTemps.Location = new System.Drawing.Point(121, 65);
            nudTemps.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudTemps.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nudTemps.Name = "nudTemps";
            nudTemps.Size = new System.Drawing.Size(296, 23);
            nudTemps.TabIndex = 10;
            nudTemps.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 37);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(92, 15);
            label2.TabIndex = 8;
            label2.Text = "Мак. фаза, у.ед.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 7);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(94, 15);
            label1.TabIndex = 9;
            label1.Text = "Мин. фаза, у.ед.";
            // 
            // txbMaxPhase
            // 
            txbMaxPhase.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbMaxPhase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbMaxPhase.Location = new System.Drawing.Point(121, 33);
            txbMaxPhase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbMaxPhase.Name = "txbMaxPhase";
            txbMaxPhase.Size = new System.Drawing.Size(296, 23);
            txbMaxPhase.TabIndex = 6;
            txbMaxPhase.Text = "1";
            // 
            // txbMinPhase
            // 
            txbMinPhase.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbMinPhase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbMinPhase.Location = new System.Drawing.Point(121, 3);
            txbMinPhase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbMinPhase.Name = "txbMinPhase";
            txbMinPhase.Size = new System.Drawing.Size(296, 23);
            txbMinPhase.TabIndex = 7;
            txbMinPhase.Text = "0.01";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(26, 98);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(82, 15);
            label3.TabIndex = 13;
            label3.Text = "Мак. темп, °С";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(26, 128);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(84, 15);
            label4.TabIndex = 14;
            label4.Text = "Мин. темп, °С";
            // 
            // cmbPhases
            // 
            cmbPhases.AccessibleName = "InitialPhase";
            cmbPhases.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbPhases.FormattingEnabled = true;
            cmbPhases.Location = new System.Drawing.Point(121, 155);
            cmbPhases.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbPhases.Name = "cmbPhases";
            cmbPhases.Size = new System.Drawing.Size(296, 23);
            cmbPhases.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(8, 158);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(96, 15);
            label5.TabIndex = 15;
            label5.Text = "Начальная фаза";
            // 
            // txbMaxTime
            // 
            txbMaxTime.AccessibleName = "Время";
            txbMaxTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbMaxTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbMaxTime.Location = new System.Drawing.Point(121, 186);
            txbMaxTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbMaxTime.Name = "txbMaxTime";
            txbMaxTime.Size = new System.Drawing.Size(296, 23);
            txbMaxTime.TabIndex = 17;
            txbMaxTime.Text = "1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(37, 189);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(66, 15);
            label6.TabIndex = 18;
            label6.Text = "Время, сек";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(57, 67);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(52, 15);
            label7.TabIndex = 19;
            label7.Text = "Кол - во";
            // 
            // TTTControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txbMaxTime);
            Controls.Add(cmbPhases);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txbFinTemp);
            Controls.Add(txbIniTemp);
            Controls.Add(nudTemps);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txbMaxPhase);
            Controls.Add(txbMinPhase);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "TTTControl";
            Size = new System.Drawing.Size(421, 225);
            ((System.ComponentModel.ISupportInitialize)nudTemps).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
