namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    partial class HeatTaskControl_v2
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
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSolver = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txbRelaxation = new System.Windows.Forms.TextBox();
            this.txbPrecision = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbSolverIterations = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbIters = new System.Windows.Forms.TextBox();
            this.maxTMIter = new System.Windows.Forms.Label();
            this.txbSaveRate = new System.Windows.Forms.TextBox();
            this.lblSaveRateTM = new System.Windows.Forms.Label();
            this.txbInitTemp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbDTtMax = new System.Windows.Forms.CheckBox();
            this.txbDTtMax = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "Точность решения, у.ед.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPriority
            // 
            this.cmbPriority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPriority.DisplayMember = "0";
            this.cmbPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "Низкий",
            "НижеСреднего",
            "Средний",
            "ВышеСреднего",
            "Высокий",
            "Наивысший"});
            this.cmbPriority.Location = new System.Drawing.Point(190, 220);
            this.cmbPriority.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(341, 21);
            this.cmbPriority.TabIndex = 140;
            this.cmbPriority.Text = "Наивысший";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 135;
            this.label3.Text = "Алгоритм решения";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbSolver
            // 
            this.cmbSolver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbSolver.FormattingEnabled = true;
            this.cmbSolver.Items.AddRange(new object[] {
            "Gauss_direct",
            "SOR_iterative",
            "CG_iterative"});
            this.cmbSolver.Location = new System.Drawing.Point(190, 115);
            this.cmbSolver.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.cmbSolver.Name = "cmbSolver";
            this.cmbSolver.Size = new System.Drawing.Size(341, 21);
            this.cmbSolver.TabIndex = 138;
            this.cmbSolver.Text = "SOR_iterative";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(8, 223);
            this.label12.Margin = new System.Windows.Forms.Padding(20, 10, 3, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 139;
            this.label12.Text = "Приоритет";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbRelaxation
            // 
            this.txbRelaxation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRelaxation.BackColor = System.Drawing.SystemColors.Window;
            this.txbRelaxation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbRelaxation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbRelaxation.Location = new System.Drawing.Point(190, 194);
            this.txbRelaxation.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbRelaxation.Name = "txbRelaxation";
            this.txbRelaxation.Size = new System.Drawing.Size(341, 20);
            this.txbRelaxation.TabIndex = 131;
            this.txbRelaxation.Text = "1.05";
            // 
            // txbPrecision
            // 
            this.txbPrecision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPrecision.BackColor = System.Drawing.SystemColors.Window;
            this.txbPrecision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPrecision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbPrecision.Location = new System.Drawing.Point(190, 168);
            this.txbPrecision.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbPrecision.Name = "txbPrecision";
            this.txbPrecision.Size = new System.Drawing.Size(341, 20);
            this.txbPrecision.TabIndex = 132;
            this.txbPrecision.Text = "0.01";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 136;
            this.label1.Text = "Кол-во итераций решения";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbSolverIterations
            // 
            this.txbSolverIterations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSolverIterations.BackColor = System.Drawing.SystemColors.Window;
            this.txbSolverIterations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbSolverIterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbSolverIterations.Location = new System.Drawing.Point(190, 142);
            this.txbSolverIterations.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbSolverIterations.Name = "txbSolverIterations";
            this.txbSolverIterations.Size = new System.Drawing.Size(341, 20);
            this.txbSolverIterations.TabIndex = 133;
            this.txbSolverIterations.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(8, 199);
            this.label7.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 137;
            this.label7.Text = "Коэф. релаксации (w)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbIters
            // 
            this.txbIters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbIters.BackColor = System.Drawing.SystemColors.Window;
            this.txbIters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbIters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbIters.Location = new System.Drawing.Point(190, 63);
            this.txbIters.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbIters.Name = "txbIters";
            this.txbIters.Size = new System.Drawing.Size(341, 20);
            this.txbIters.TabIndex = 127;
            this.txbIters.Text = "2";
            // 
            // maxTMIter
            // 
            this.maxTMIter.AutoSize = true;
            this.maxTMIter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxTMIter.Location = new System.Drawing.Point(8, 66);
            this.maxTMIter.Margin = new System.Windows.Forms.Padding(8, 28, 3, 10);
            this.maxTMIter.Name = "maxTMIter";
            this.maxTMIter.Size = new System.Drawing.Size(134, 13);
            this.maxTMIter.TabIndex = 128;
            this.maxTMIter.Text = "Кол-во итераций на шаге";
            this.maxTMIter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxTMIter.UseWaitCursor = true;
            // 
            // txbSaveRate
            // 
            this.txbSaveRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSaveRate.BackColor = System.Drawing.SystemColors.Window;
            this.txbSaveRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbSaveRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbSaveRate.Location = new System.Drawing.Point(190, 89);
            this.txbSaveRate.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbSaveRate.Name = "txbSaveRate";
            this.txbSaveRate.Size = new System.Drawing.Size(341, 20);
            this.txbSaveRate.TabIndex = 129;
            this.txbSaveRate.Text = "1";
            // 
            // lblSaveRateTM
            // 
            this.lblSaveRateTM.AutoSize = true;
            this.lblSaveRateTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSaveRateTM.Location = new System.Drawing.Point(8, 92);
            this.lblSaveRateTM.Margin = new System.Windows.Forms.Padding(8, 28, 3, 10);
            this.lblSaveRateTM.Name = "lblSaveRateTM";
            this.lblSaveRateTM.Size = new System.Drawing.Size(136, 13);
            this.lblSaveRateTM.TabIndex = 130;
            this.lblSaveRateTM.Text = "Частота сохранений, шаг";
            this.lblSaveRateTM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSaveRateTM.UseWaitCursor = true;
            // 
            // txbInitTemp
            // 
            this.txbInitTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbInitTemp.BackColor = System.Drawing.SystemColors.Window;
            this.txbInitTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbInitTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbInitTemp.Location = new System.Drawing.Point(190, 37);
            this.txbInitTemp.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbInitTemp.Name = "txbInitTemp";
            this.txbInitTemp.Size = new System.Drawing.Size(341, 20);
            this.txbInitTemp.TabIndex = 124;
            this.txbInitTemp.Text = "20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 125;
            this.label2.Text = "Начальная температура, С°";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbDTtMax
            // 
            this.chbDTtMax.AutoSize = true;
            this.chbDTtMax.Checked = true;
            this.chbDTtMax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDTtMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbDTtMax.Location = new System.Drawing.Point(10, 13);
            this.chbDTtMax.Margin = new System.Windows.Forms.Padding(10, 7, 3, 3);
            this.chbDTtMax.Name = "chbDTtMax";
            this.chbDTtMax.Size = new System.Drawing.Size(151, 17);
            this.chbDTtMax.TabIndex = 126;
            this.chbDTtMax.Text = "Макс. темп. (dTt max), C°";
            this.chbDTtMax.UseVisualStyleBackColor = true;
            // 
            // txbDTtMax
            // 
            this.txbDTtMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDTtMax.BackColor = System.Drawing.SystemColors.Window;
            this.txbDTtMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbDTtMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbDTtMax.Location = new System.Drawing.Point(190, 10);
            this.txbDTtMax.Margin = new System.Windows.Forms.Padding(178, 10, 15, 3);
            this.txbDTtMax.Name = "txbDTtMax";
            this.txbDTtMax.Size = new System.Drawing.Size(341, 20);
            this.txbDTtMax.TabIndex = 123;
            this.txbDTtMax.Text = "1500";
            // 
            // HeatTaskControl_v2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSolver);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txbRelaxation);
            this.Controls.Add(this.txbPrecision);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbSolverIterations);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbIters);
            this.Controls.Add(this.maxTMIter);
            this.Controls.Add(this.txbSaveRate);
            this.Controls.Add(this.lblSaveRateTM);
            this.Controls.Add(this.txbInitTemp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbDTtMax);
            this.Controls.Add(this.txbDTtMax);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MinimumSize = new System.Drawing.Size(0, 250);
            this.Name = "HeatTaskControl_v2";
            this.Size = new System.Drawing.Size(546, 250);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSolver;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbRelaxation;
        private System.Windows.Forms.TextBox txbPrecision;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbSolverIterations;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbIters;
        private System.Windows.Forms.Label maxTMIter;
        private System.Windows.Forms.TextBox txbSaveRate;
        private System.Windows.Forms.Label lblSaveRateTM;
        private System.Windows.Forms.TextBox txbInitTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbDTtMax;
        private System.Windows.Forms.TextBox txbDTtMax;
    }
}
