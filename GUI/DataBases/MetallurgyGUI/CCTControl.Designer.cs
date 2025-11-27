namespace BazisGUI.DataBases.MetallurgyGUI
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
            txbMinVel = new System.Windows.Forms.TextBox();
            txbMaxVel = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            nudVels = new System.Windows.Forms.NumericUpDown();
            cmbPhases = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            txbIniTemp = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            txbFinTemp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)nudVels).BeginInit();
            SuspendLayout();
            // 
            // txbMinVel
            // 
            txbMinVel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbMinVel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbMinVel.Location = new System.Drawing.Point(121, 16);
            txbMinVel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbMinVel.Name = "txbMinVel";
            txbMinVel.Size = new System.Drawing.Size(181, 23);
            txbMinVel.TabIndex = 0;
            txbMinVel.Text = "-0.01";
            // 
            // txbMaxVel
            // 
            txbMaxVel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbMaxVel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbMaxVel.Location = new System.Drawing.Point(121, 46);
            txbMaxVel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbMaxVel.Name = "txbMaxVel";
            txbMaxVel.Size = new System.Drawing.Size(181, 23);
            txbMaxVel.TabIndex = 0;
            txbMaxVel.Text = "-100";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 20);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(88, 15);
            label1.TabIndex = 1;
            label1.Text = "Мин. скорость";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(20, 50);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(86, 15);
            label2.TabIndex = 1;
            label2.Text = "Мак. скорость";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(59, 80);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(52, 15);
            label3.TabIndex = 1;
            label3.Text = "Кол - во";
            // 
            // nudVels
            // 
            nudVels.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudVels.Location = new System.Drawing.Point(121, 77);
            nudVels.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudVels.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nudVels.Name = "nudVels";
            nudVels.Size = new System.Drawing.Size(182, 23);
            nudVels.TabIndex = 3;
            nudVels.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // cmbPhases
            // 
            cmbPhases.AccessibleName = "InitialPhase";
            cmbPhases.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbPhases.FormattingEnabled = true;
            cmbPhases.Location = new System.Drawing.Point(121, 107);
            cmbPhases.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbPhases.Name = "cmbPhases";
            cmbPhases.Size = new System.Drawing.Size(181, 23);
            cmbPhases.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(8, 111);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(96, 15);
            label4.TabIndex = 1;
            label4.Text = "Начальная фаза";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 142);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(100, 15);
            label5.TabIndex = 1;
            label5.Text = "Начальная темп.";
            // 
            // txbIniTemp
            // 
            txbIniTemp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbIniTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbIniTemp.Location = new System.Drawing.Point(121, 138);
            txbIniTemp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbIniTemp.Name = "txbIniTemp";
            txbIniTemp.Size = new System.Drawing.Size(181, 23);
            txbIniTemp.TabIndex = 5;
            txbIniTemp.Text = "800";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(14, 172);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(93, 15);
            label6.TabIndex = 1;
            label6.Text = "Конечная темп.";
            // 
            // txbFinTemp
            // 
            txbFinTemp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txbFinTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txbFinTemp.Location = new System.Drawing.Point(121, 168);
            txbFinTemp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txbFinTemp.Name = "txbFinTemp";
            txbFinTemp.Size = new System.Drawing.Size(181, 23);
            txbFinTemp.TabIndex = 5;
            txbFinTemp.Text = "20";
            // 
            // CCTControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txbFinTemp);
            Controls.Add(txbIniTemp);
            Controls.Add(cmbPhases);
            Controls.Add(nudVels);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txbMaxVel);
            Controls.Add(txbMinVel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "CCTControl";
            Size = new System.Drawing.Size(321, 268);
            ((System.ComponentModel.ISupportInitialize)nudVels).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
