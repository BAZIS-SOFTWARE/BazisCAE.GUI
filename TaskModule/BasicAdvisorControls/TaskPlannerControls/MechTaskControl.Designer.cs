namespace AdvisorControls.TaskPlannerControls
{
    partial class MechTaskControl
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
            this.txbBodyTemp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbUMax = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbMaxSiSt = new System.Windows.Forms.TextBox();
            this.txbMaxU = new System.Windows.Forms.TextBox();
            this.txbMaxDU = new System.Windows.Forms.TextBox();
            this.chbPlastisity = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 245);
            this.label4.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 114;
            this.label4.Text = "Точность решения, у.ед.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPriority
            // 
            this.cmbPriority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPriority.DisplayMember = "0";
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "Низкий",
            "НижеСреднего",
            "Средний",
            "ВышеСреднего",
            "Высокий",
            "Наивысший"});
            this.cmbPriority.Location = new System.Drawing.Point(207, 294);
            this.cmbPriority.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(465, 21);
            this.cmbPriority.TabIndex = 120;
            this.cmbPriority.Text = "Наивысший";
            this.cmbPriority.SelectedIndexChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 192);
            this.label3.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 115;
            this.label3.Text = "Алгоритм решения";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbSolver
            // 
            this.cmbSolver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSolver.FormattingEnabled = true;
            this.cmbSolver.Items.AddRange(new object[] {
            "Gauss_direct",
            "SOR_iterative",
            "CG_iterative"});
            this.cmbSolver.Location = new System.Drawing.Point(207, 189);
            this.cmbSolver.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbSolver.Name = "cmbSolver";
            this.cmbSolver.Size = new System.Drawing.Size(464, 21);
            this.cmbSolver.TabIndex = 118;
            this.cmbSolver.Text = "SOR_iterative";
            this.cmbSolver.SelectedIndexChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 297);
            this.label12.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 119;
            this.label12.Text = "Приоритет";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbRelaxation
            // 
            this.txbRelaxation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRelaxation.BackColor = System.Drawing.SystemColors.Window;
            this.txbRelaxation.Location = new System.Drawing.Point(207, 268);
            this.txbRelaxation.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbRelaxation.Name = "txbRelaxation";
            this.txbRelaxation.Size = new System.Drawing.Size(465, 20);
            this.txbRelaxation.TabIndex = 111;
            this.txbRelaxation.Text = "1.25";
            this.txbRelaxation.EnabledChanged += new System.EventHandler(this.Txb_EnabledChanged);
            this.txbRelaxation.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // txbPrecision
            // 
            this.txbPrecision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPrecision.BackColor = System.Drawing.SystemColors.Window;
            this.txbPrecision.Location = new System.Drawing.Point(207, 242);
            this.txbPrecision.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbPrecision.Name = "txbPrecision";
            this.txbPrecision.Size = new System.Drawing.Size(464, 20);
            this.txbPrecision.TabIndex = 112;
            this.txbPrecision.Text = "0.0001";
            this.txbPrecision.EnabledChanged += new System.EventHandler(this.Txb_EnabledChanged);
            this.txbPrecision.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 219);
            this.label1.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 116;
            this.label1.Text = "Кол-во итераций решения";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbSolverIterations
            // 
            this.txbSolverIterations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSolverIterations.BackColor = System.Drawing.SystemColors.Window;
            this.txbSolverIterations.Location = new System.Drawing.Point(207, 216);
            this.txbSolverIterations.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbSolverIterations.Name = "txbSolverIterations";
            this.txbSolverIterations.Size = new System.Drawing.Size(464, 20);
            this.txbSolverIterations.TabIndex = 113;
            this.txbSolverIterations.Text = "100";
            this.txbSolverIterations.EnabledChanged += new System.EventHandler(this.Txb_EnabledChanged);
            this.txbSolverIterations.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 271);
            this.label7.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 117;
            this.label7.Text = "Коэф. релаксации (w)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbIters
            // 
            this.txbIters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbIters.BackColor = System.Drawing.SystemColors.Window;
            this.txbIters.Location = new System.Drawing.Point(207, 137);
            this.txbIters.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbIters.Name = "txbIters";
            this.txbIters.Size = new System.Drawing.Size(464, 20);
            this.txbIters.TabIndex = 107;
            this.txbIters.Text = "25";
            this.txbIters.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // maxTMIter
            // 
            this.maxTMIter.AutoSize = true;
            this.maxTMIter.Location = new System.Drawing.Point(9, 140);
            this.maxTMIter.Margin = new System.Windows.Forms.Padding(7, 28, 3, 10);
            this.maxTMIter.Name = "maxTMIter";
            this.maxTMIter.Size = new System.Drawing.Size(134, 13);
            this.maxTMIter.TabIndex = 108;
            this.maxTMIter.Text = "Кол-во итераций на шаге";
            this.maxTMIter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxTMIter.UseWaitCursor = true;
            // 
            // txbSaveRate
            // 
            this.txbSaveRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSaveRate.BackColor = System.Drawing.SystemColors.Window;
            this.txbSaveRate.Location = new System.Drawing.Point(207, 163);
            this.txbSaveRate.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbSaveRate.Name = "txbSaveRate";
            this.txbSaveRate.Size = new System.Drawing.Size(464, 20);
            this.txbSaveRate.TabIndex = 109;
            this.txbSaveRate.Text = "5";
            this.txbSaveRate.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // lblSaveRateTM
            // 
            this.lblSaveRateTM.AutoSize = true;
            this.lblSaveRateTM.Location = new System.Drawing.Point(9, 166);
            this.lblSaveRateTM.Margin = new System.Windows.Forms.Padding(7, 28, 3, 10);
            this.lblSaveRateTM.Name = "lblSaveRateTM";
            this.lblSaveRateTM.Size = new System.Drawing.Size(136, 13);
            this.lblSaveRateTM.TabIndex = 110;
            this.lblSaveRateTM.Text = "Частота сохранений, шаг";
            this.lblSaveRateTM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSaveRateTM.UseWaitCursor = true;
            // 
            // txbBodyTemp
            // 
            this.txbBodyTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBodyTemp.BackColor = System.Drawing.SystemColors.Window;
            this.txbBodyTemp.Location = new System.Drawing.Point(207, 111);
            this.txbBodyTemp.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbBodyTemp.Name = "txbBodyTemp";
            this.txbBodyTemp.Size = new System.Drawing.Size(464, 20);
            this.txbBodyTemp.TabIndex = 105;
            this.txbBodyTemp.Text = "20";
            this.txbBodyTemp.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Температура, С°";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbUMax
            // 
            this.chbUMax.AutoSize = true;
            this.chbUMax.Location = new System.Drawing.Point(8, 61);
            this.chbUMax.Name = "chbUMax";
            this.chbUMax.Size = new System.Drawing.Size(159, 17);
            this.chbUMax.TabIndex = 102;
            this.chbUMax.Text = "Макс. перемещения U, >0";
            this.chbUMax.UseVisualStyleBackColor = true;
            this.chbUMax.CheckedChanged += new System.EventHandler(this.chbUMax_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 68);
            this.label13.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 100;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 99;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbMaxSiSt
            // 
            this.txbMaxSiSt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxSiSt.BackColor = System.Drawing.SystemColors.Window;
            this.txbMaxSiSt.Location = new System.Drawing.Point(207, 85);
            this.txbMaxSiSt.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbMaxSiSt.Name = "txbMaxSiSt";
            this.txbMaxSiSt.Size = new System.Drawing.Size(464, 20);
            this.txbMaxSiSt.TabIndex = 97;
            this.txbMaxSiSt.Text = "1.25";
            this.txbMaxSiSt.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // txbMaxU
            // 
            this.txbMaxU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxU.BackColor = System.Drawing.SystemColors.Window;
            this.txbMaxU.Enabled = false;
            this.txbMaxU.Location = new System.Drawing.Point(207, 59);
            this.txbMaxU.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbMaxU.Name = "txbMaxU";
            this.txbMaxU.Size = new System.Drawing.Size(464, 20);
            this.txbMaxU.TabIndex = 96;
            this.txbMaxU.Text = "0.05";
            this.txbMaxU.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // txbMaxDU
            // 
            this.txbMaxDU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxDU.BackColor = System.Drawing.SystemColors.Window;
            this.txbMaxDU.Location = new System.Drawing.Point(207, 33);
            this.txbMaxDU.Margin = new System.Windows.Forms.Padding(3, 5, 28, 3);
            this.txbMaxDU.Name = "txbMaxDU";
            this.txbMaxDU.Size = new System.Drawing.Size(465, 20);
            this.txbMaxDU.TabIndex = 95;
            this.txbMaxDU.Text = "0.0005";
            this.txbMaxDU.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // chbPlastisity
            // 
            this.chbPlastisity.AutoSize = true;
            this.chbPlastisity.Checked = true;
            this.chbPlastisity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPlastisity.Location = new System.Drawing.Point(8, 7);
            this.chbPlastisity.Name = "chbPlastisity";
            this.chbPlastisity.Size = new System.Drawing.Size(189, 17);
            this.chbPlastisity.TabIndex = 130;
            this.chbPlastisity.Text = "Учет пластических деформаций";
            this.chbPlastisity.UseVisualStyleBackColor = true;
            this.chbPlastisity.CheckedChanged += new System.EventHandler(this.chbPlastisity_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 131;
            this.label6.Text = "Макс. разница dU, >0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 13);
            this.label8.TabIndex = 132;
            this.label8.Text = "Макс. отношение Si/St, >1";
            // 
            // MechTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chbPlastisity);
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
            this.Controls.Add(this.txbBodyTemp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbUMax);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txbMaxSiSt);
            this.Controls.Add(this.txbMaxU);
            this.Controls.Add(this.txbMaxDU);
            this.Name = "MechTaskControl";
            this.Size = new System.Drawing.Size(700, 320);
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
        private System.Windows.Forms.TextBox txbBodyTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbUMax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbMaxSiSt;
        private System.Windows.Forms.TextBox txbMaxU;
        private System.Windows.Forms.TextBox txbMaxDU;
        private System.Windows.Forms.CheckBox chbPlastisity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}
