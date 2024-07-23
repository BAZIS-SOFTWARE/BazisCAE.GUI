using UserControlsEx;

namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    partial class ChemTaskControl
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
            this.chbDTtMax = new System.Windows.Forms.CheckBox();
            this.txbDTtMax = new TextBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.maxTMIter = new System.Windows.Forms.Label();
            this.lblSaveRateTM = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPriority = new ComboBoxEx();
            this.txbRelaxation = new TextBoxEx();
            this.txbPrecision = new TextBoxEx();
            this.txbSolverIterations = new TextBoxEx();
            this.cmbSolver = new ComboBoxEx();
            this.txbSaveRate = new TextBoxEx();
            this.txbIters = new TextBoxEx();
            this.txbInitConcentration = new TextBoxEx();
            this.SuspendLayout();
            // 
            // chbDTtMax
            // 
            this.chbDTtMax.AutoSize = true;
            this.chbDTtMax.Checked = true;
            this.chbDTtMax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDTtMax.Enabled = false;
            this.chbDTtMax.Location = new System.Drawing.Point(12, 9);
            this.chbDTtMax.Margin = new System.Windows.Forms.Padding(4);
            this.chbDTtMax.Name = "chbDTtMax";
            this.chbDTtMax.Size = new System.Drawing.Size(207, 20);
            this.chbDTtMax.TabIndex = 110;
            this.chbDTtMax.Text = "Макс.концентр. (dCt max), %";
            this.chbDTtMax.UseVisualStyleBackColor = true;
            // 
            // txbDTtMax
            // 
            this.txbDTtMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDTtMax.BackColor = System.Drawing.SystemColors.Window;
            this.txbDTtMax.Location = new System.Drawing.Point(237, 7);
            this.txbDTtMax.Margin = new System.Windows.Forms.Padding(237, 12, 20, 4);
            this.txbDTtMax.Name = "txbDTtMax";
            this.txbDTtMax.Size = new System.Drawing.Size(241, 22);
            this.txbDTtMax.TabIndex = 109;
            this.txbDTtMax.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 203);
            this.label4.Margin = new System.Windows.Forms.Padding(27, 12, 4, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 16);
            this.label4.TabIndex = 128;
            this.label4.Text = "Точность решения, у.ед.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(27, 12, 4, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 129;
            this.label3.Text = "Алгоритм решения";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 267);
            this.label12.Margin = new System.Windows.Forms.Padding(27, 12, 4, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 16);
            this.label12.TabIndex = 132;
            this.label12.Text = "Приоритет";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 171);
            this.label1.Margin = new System.Windows.Forms.Padding(27, 12, 4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 16);
            this.label1.TabIndex = 130;
            this.label1.Text = "Кол-во итераций решения";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 235);
            this.label7.Margin = new System.Windows.Forms.Padding(27, 12, 4, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 16);
            this.label7.TabIndex = 131;
            this.label7.Text = "Коэф. релаксации (w)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maxTMIter
            // 
            this.maxTMIter.AutoSize = true;
            this.maxTMIter.Location = new System.Drawing.Point(13, 74);
            this.maxTMIter.Margin = new System.Windows.Forms.Padding(9, 34, 4, 12);
            this.maxTMIter.Name = "maxTMIter";
            this.maxTMIter.Size = new System.Drawing.Size(170, 16);
            this.maxTMIter.TabIndex = 126;
            this.maxTMIter.Text = "Кол-во итераций на шаге";
            this.maxTMIter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxTMIter.UseWaitCursor = true;
            // 
            // lblSaveRateTM
            // 
            this.lblSaveRateTM.AutoSize = true;
            this.lblSaveRateTM.Location = new System.Drawing.Point(13, 106);
            this.lblSaveRateTM.Margin = new System.Windows.Forms.Padding(9, 34, 4, 12);
            this.lblSaveRateTM.Name = "lblSaveRateTM";
            this.lblSaveRateTM.Size = new System.Drawing.Size(170, 16);
            this.lblSaveRateTM.TabIndex = 127;
            this.lblSaveRateTM.Text = "Частота сохранений, шаг";
            this.lblSaveRateTM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSaveRateTM.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 12, 4, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 16);
            this.label2.TabIndex = 125;
            this.label2.Text = "Начальная концентрация, %";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cmbPriority.Location = new System.Drawing.Point(237, 264);
            this.cmbPriority.Margin = new System.Windows.Forms.Padding(237, 4, 20, 4);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(241, 24);
            this.cmbPriority.TabIndex = 136;
            this.cmbPriority.Text = "Наивысший";
            // 
            // txbRelaxation
            // 
            this.txbRelaxation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRelaxation.BackColor = System.Drawing.SystemColors.Window;
            this.txbRelaxation.Location = new System.Drawing.Point(237, 232);
            this.txbRelaxation.Margin = new System.Windows.Forms.Padding(237, 4, 20, 4);
            this.txbRelaxation.Name = "txbRelaxation";
            this.txbRelaxation.Size = new System.Drawing.Size(241, 22);
            this.txbRelaxation.TabIndex = 137;
            this.txbRelaxation.Text = "1.05";
            // 
            // txbPrecision
            // 
            this.txbPrecision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPrecision.BackColor = System.Drawing.SystemColors.Window;
            this.txbPrecision.Location = new System.Drawing.Point(237, 200);
            this.txbPrecision.Margin = new System.Windows.Forms.Padding(237, 4, 20, 4);
            this.txbPrecision.Name = "txbPrecision";
            this.txbPrecision.Size = new System.Drawing.Size(241, 22);
            this.txbPrecision.TabIndex = 138;
            this.txbPrecision.Text = "0.01";
            // 
            // txbSolverIterations
            // 
            this.txbSolverIterations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSolverIterations.BackColor = System.Drawing.SystemColors.Window;
            this.txbSolverIterations.Location = new System.Drawing.Point(237, 168);
            this.txbSolverIterations.Margin = new System.Windows.Forms.Padding(237, 4, 20, 4);
            this.txbSolverIterations.Name = "txbSolverIterations";
            this.txbSolverIterations.Size = new System.Drawing.Size(241, 22);
            this.txbSolverIterations.TabIndex = 139;
            this.txbSolverIterations.Text = "100";
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
            this.cmbSolver.Location = new System.Drawing.Point(237, 135);
            this.cmbSolver.Margin = new System.Windows.Forms.Padding(237, 4, 20, 4);
            this.cmbSolver.Name = "cmbSolver";
            this.cmbSolver.Size = new System.Drawing.Size(241, 24);
            this.cmbSolver.TabIndex = 140;
            this.cmbSolver.Text = "SOR_iterative";
            // 
            // txbSaveRate
            // 
            this.txbSaveRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSaveRate.BackColor = System.Drawing.SystemColors.Window;
            this.txbSaveRate.Location = new System.Drawing.Point(237, 103);
            this.txbSaveRate.Margin = new System.Windows.Forms.Padding(237, 4, 20, 4);
            this.txbSaveRate.Name = "txbSaveRate";
            this.txbSaveRate.Size = new System.Drawing.Size(241, 22);
            this.txbSaveRate.TabIndex = 141;
            this.txbSaveRate.Text = "1";
            // 
            // txbIters
            // 
            this.txbIters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbIters.BackColor = System.Drawing.SystemColors.Window;
            this.txbIters.Location = new System.Drawing.Point(237, 71);
            this.txbIters.Margin = new System.Windows.Forms.Padding(237, 4, 20, 4);
            this.txbIters.Name = "txbIters";
            this.txbIters.Size = new System.Drawing.Size(241, 22);
            this.txbIters.TabIndex = 142;
            this.txbIters.Text = "2";
            // 
            // txbInitConcentration
            // 
            this.txbInitConcentration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbInitConcentration.BackColor = System.Drawing.SystemColors.Window;
            this.txbInitConcentration.Location = new System.Drawing.Point(237, 39);
            this.txbInitConcentration.Margin = new System.Windows.Forms.Padding(237, 4, 20, 4);
            this.txbInitConcentration.Name = "txbInitConcentration";
            this.txbInitConcentration.Size = new System.Drawing.Size(241, 22);
            this.txbInitConcentration.TabIndex = 143;
            this.txbInitConcentration.Text = "0.18";
            // 
            // ChemTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.txbInitConcentration);
            this.Controls.Add(this.txbIters);
            this.Controls.Add(this.txbSaveRate);
            this.Controls.Add(this.cmbSolver);
            this.Controls.Add(this.txbSolverIterations);
            this.Controls.Add(this.txbPrecision);
            this.Controls.Add(this.txbRelaxation);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maxTMIter);
            this.Controls.Add(this.lblSaveRateTM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbDTtMax);
            this.Controls.Add(this.txbDTtMax);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChemTaskControl";
            this.Size = new System.Drawing.Size(498, 295);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbDTtMax;
        private TextBoxEx txbDTtMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label maxTMIter;
        private System.Windows.Forms.Label lblSaveRateTM;
        private System.Windows.Forms.Label label2;
        private ComboBoxEx cmbPriority;
        private TextBoxEx txbRelaxation;
        private TextBoxEx txbPrecision;
        private TextBoxEx txbSolverIterations;
        private ComboBoxEx cmbSolver;
        private TextBoxEx txbSaveRate;
        private TextBoxEx txbIters;
        private TextBoxEx txbInitConcentration;
    }
}
