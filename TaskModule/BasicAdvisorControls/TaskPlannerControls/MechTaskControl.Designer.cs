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
            this.chbDStMax = new System.Windows.Forms.CheckBox();
            this.chbDSiMax = new System.Windows.Forms.CheckBox();
            this.chbDUtMax = new System.Windows.Forms.CheckBox();
            this.chbDUiMax = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbMaxDSt = new System.Windows.Forms.TextBox();
            this.txbMaxDSi = new System.Windows.Forms.TextBox();
            this.txbMaxDUt = new System.Windows.Forms.TextBox();
            this.txbMaxDUi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 243);
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
            this.cmbPriority.Location = new System.Drawing.Point(208, 292);
            this.cmbPriority.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(520, 21);
            this.cmbPriority.TabIndex = 120;
            this.cmbPriority.Text = "Наивысший";
            this.cmbPriority.SelectedIndexChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 190);
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
            this.cmbSolver.Location = new System.Drawing.Point(208, 187);
            this.cmbSolver.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbSolver.Name = "cmbSolver";
            this.cmbSolver.Size = new System.Drawing.Size(519, 21);
            this.cmbSolver.TabIndex = 118;
            this.cmbSolver.SelectedIndexChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 295);
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
            this.txbRelaxation.Enabled = false;
            this.txbRelaxation.Location = new System.Drawing.Point(208, 266);
            this.txbRelaxation.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbRelaxation.Name = "txbRelaxation";
            this.txbRelaxation.Size = new System.Drawing.Size(520, 20);
            this.txbRelaxation.TabIndex = 111;
            this.txbRelaxation.Text = "*";
            this.txbRelaxation.EnabledChanged += new System.EventHandler(this.Txb_EnabledChanged);
            this.txbRelaxation.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // txbPrecision
            // 
            this.txbPrecision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPrecision.BackColor = System.Drawing.SystemColors.Window;
            this.txbPrecision.Enabled = false;
            this.txbPrecision.Location = new System.Drawing.Point(208, 240);
            this.txbPrecision.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbPrecision.Name = "txbPrecision";
            this.txbPrecision.Size = new System.Drawing.Size(519, 20);
            this.txbPrecision.TabIndex = 112;
            this.txbPrecision.Text = "*";
            this.txbPrecision.EnabledChanged += new System.EventHandler(this.Txb_EnabledChanged);
            this.txbPrecision.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 217);
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
            this.txbSolverIterations.Enabled = false;
            this.txbSolverIterations.Location = new System.Drawing.Point(208, 214);
            this.txbSolverIterations.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbSolverIterations.Name = "txbSolverIterations";
            this.txbSolverIterations.Size = new System.Drawing.Size(519, 20);
            this.txbSolverIterations.TabIndex = 113;
            this.txbSolverIterations.Text = "*";
            this.txbSolverIterations.EnabledChanged += new System.EventHandler(this.Txb_EnabledChanged);
            this.txbSolverIterations.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 269);
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
            this.txbIters.Location = new System.Drawing.Point(208, 135);
            this.txbIters.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbIters.Name = "txbIters";
            this.txbIters.Size = new System.Drawing.Size(519, 20);
            this.txbIters.TabIndex = 107;
            this.txbIters.Text = "25";
            this.txbIters.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // maxTMIter
            // 
            this.maxTMIter.AutoSize = true;
            this.maxTMIter.Location = new System.Drawing.Point(10, 138);
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
            this.txbSaveRate.Location = new System.Drawing.Point(208, 161);
            this.txbSaveRate.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbSaveRate.Name = "txbSaveRate";
            this.txbSaveRate.Size = new System.Drawing.Size(519, 20);
            this.txbSaveRate.TabIndex = 109;
            this.txbSaveRate.Text = "5";
            this.txbSaveRate.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // lblSaveRateTM
            // 
            this.lblSaveRateTM.AutoSize = true;
            this.lblSaveRateTM.Location = new System.Drawing.Point(10, 164);
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
            this.txbBodyTemp.Location = new System.Drawing.Point(208, 109);
            this.txbBodyTemp.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbBodyTemp.Name = "txbBodyTemp";
            this.txbBodyTemp.Size = new System.Drawing.Size(519, 20);
            this.txbBodyTemp.TabIndex = 105;
            this.txbBodyTemp.Text = "20";
            this.txbBodyTemp.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Температура, С°";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbDStMax
            // 
            this.chbDStMax.AutoSize = true;
            this.chbDStMax.Location = new System.Drawing.Point(9, 85);
            this.chbDStMax.Name = "chbDStMax";
            this.chbDStMax.Size = new System.Drawing.Size(182, 17);
            this.chbDStMax.TabIndex = 104;
            this.chbDStMax.Text = "Макс. напряжений (dSt max), %";
            this.chbDStMax.UseVisualStyleBackColor = true;
            this.chbDStMax.CheckedChanged += new System.EventHandler(this.CheBox_CheckedChanged);
            // 
            // chbDSiMax
            // 
            this.chbDSiMax.AutoSize = true;
            this.chbDSiMax.Location = new System.Drawing.Point(9, 59);
            this.chbDSiMax.Name = "chbDSiMax";
            this.chbDSiMax.Size = new System.Drawing.Size(181, 17);
            this.chbDSiMax.TabIndex = 103;
            this.chbDSiMax.Text = "Макс. напряжений (dSi max), %";
            this.chbDSiMax.UseVisualStyleBackColor = true;
            this.chbDSiMax.CheckedChanged += new System.EventHandler(this.CheBox_CheckedChanged);
            // 
            // chbDUtMax
            // 
            this.chbDUtMax.AutoSize = true;
            this.chbDUtMax.Location = new System.Drawing.Point(9, 33);
            this.chbDUtMax.Name = "chbDUtMax";
            this.chbDUtMax.Size = new System.Drawing.Size(178, 17);
            this.chbDUtMax.TabIndex = 102;
            this.chbDUtMax.Text = "Макс. перемещения (dUt max)";
            this.chbDUtMax.UseVisualStyleBackColor = true;
            this.chbDUtMax.CheckedChanged += new System.EventHandler(this.CheBox_CheckedChanged);
            // 
            // chbDUiMax
            // 
            this.chbDUiMax.AutoSize = true;
            this.chbDUiMax.Checked = true;
            this.chbDUiMax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDUiMax.Enabled = false;
            this.chbDUiMax.Location = new System.Drawing.Point(9, 7);
            this.chbDUiMax.Name = "chbDUiMax";
            this.chbDUiMax.Size = new System.Drawing.Size(177, 17);
            this.chbDUiMax.TabIndex = 101;
            this.chbDUiMax.Text = "Макс. перемещений (dUi max)";
            this.chbDUiMax.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 86);
            this.label13.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 100;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 34);
            this.label10.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 99;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbMaxDSt
            // 
            this.txbMaxDSt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxDSt.BackColor = System.Drawing.SystemColors.Window;
            this.txbMaxDSt.Enabled = false;
            this.txbMaxDSt.Location = new System.Drawing.Point(208, 83);
            this.txbMaxDSt.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbMaxDSt.Name = "txbMaxDSt";
            this.txbMaxDSt.Size = new System.Drawing.Size(519, 20);
            this.txbMaxDSt.TabIndex = 98;
            this.txbMaxDSt.Text = "*";
            this.txbMaxDSt.EnabledChanged += new System.EventHandler(this.Txb_EnabledChanged);
            this.txbMaxDSt.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // txbMaxDSi
            // 
            this.txbMaxDSi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxDSi.BackColor = System.Drawing.SystemColors.Window;
            this.txbMaxDSi.Enabled = false;
            this.txbMaxDSi.Location = new System.Drawing.Point(208, 57);
            this.txbMaxDSi.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbMaxDSi.Name = "txbMaxDSi";
            this.txbMaxDSi.Size = new System.Drawing.Size(519, 20);
            this.txbMaxDSi.TabIndex = 97;
            this.txbMaxDSi.Text = "*";
            this.txbMaxDSi.EnabledChanged += new System.EventHandler(this.Txb_EnabledChanged);
            this.txbMaxDSi.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // txbMaxDUt
            // 
            this.txbMaxDUt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxDUt.BackColor = System.Drawing.SystemColors.Window;
            this.txbMaxDUt.Enabled = false;
            this.txbMaxDUt.Location = new System.Drawing.Point(208, 31);
            this.txbMaxDUt.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbMaxDUt.Name = "txbMaxDUt";
            this.txbMaxDUt.Size = new System.Drawing.Size(519, 20);
            this.txbMaxDUt.TabIndex = 96;
            this.txbMaxDUt.Text = "*";
            this.txbMaxDUt.EnabledChanged += new System.EventHandler(this.Txb_EnabledChanged);
            this.txbMaxDUt.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // txbMaxDUi
            // 
            this.txbMaxDUi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxDUi.BackColor = System.Drawing.SystemColors.Window;
            this.txbMaxDUi.Location = new System.Drawing.Point(208, 5);
            this.txbMaxDUi.Margin = new System.Windows.Forms.Padding(3, 5, 28, 3);
            this.txbMaxDUi.Name = "txbMaxDUi";
            this.txbMaxDUi.Size = new System.Drawing.Size(520, 20);
            this.txbMaxDUi.TabIndex = 95;
            this.txbMaxDUi.Text = "0.0005";
            this.txbMaxDUi.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // MechTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
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
            this.Controls.Add(this.txbBodyTemp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbDStMax);
            this.Controls.Add(this.chbDSiMax);
            this.Controls.Add(this.chbDUtMax);
            this.Controls.Add(this.chbDUiMax);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txbMaxDSt);
            this.Controls.Add(this.txbMaxDSi);
            this.Controls.Add(this.txbMaxDUt);
            this.Controls.Add(this.txbMaxDUi);
            this.Name = "MechTaskControl";
            this.Size = new System.Drawing.Size(755, 318);
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
        private System.Windows.Forms.CheckBox chbDStMax;
        private System.Windows.Forms.CheckBox chbDSiMax;
        private System.Windows.Forms.CheckBox chbDUtMax;
        private System.Windows.Forms.CheckBox chbDUiMax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbMaxDSt;
        private System.Windows.Forms.TextBox txbMaxDSi;
        private System.Windows.Forms.TextBox txbMaxDUt;
        private System.Windows.Forms.TextBox txbMaxDUi;
    }
}
