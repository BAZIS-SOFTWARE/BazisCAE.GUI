using UserControlsEx;

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
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPriority = new UserControlsEx.ComboBoxEx(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSolver = new UserControlsEx.ComboBoxEx(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txbRelaxation = new UserControlsEx.TextBoxEx(this.components);
            this.txbPrecision = new UserControlsEx.TextBoxEx(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txbSolverIterations = new UserControlsEx.TextBoxEx(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txbIters = new UserControlsEx.TextBoxEx(this.components);
            this.maxTMIter = new System.Windows.Forms.Label();
            this.txbSaveRate = new UserControlsEx.TextBoxEx(this.components);
            this.lblSaveRateTM = new System.Windows.Forms.Label();
            this.txbInitTemp = new UserControlsEx.TextBoxEx(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.chbDTtMax = new System.Windows.Forms.CheckBox();
            this.txbDTtMax = new UserControlsEx.TextBoxEx(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 176);
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
            this.cmbPriority.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbPriority.IsValidating = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "Низкий",
            "НижеСреднего",
            "Средний",
            "ВышеСреднего",
            "Высокий",
            "Наивысший"});
            this.cmbPriority.Location = new System.Drawing.Point(190, 225);
            this.cmbPriority.Margin = new System.Windows.Forms.Padding(178, 3, 15, 7);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(490, 21);
            this.cmbPriority.TabIndex = 140;
            this.cmbPriority.Text = "Наивысший";
            this.cmbPriority.UserRegExCheck = null;
            this.cmbPriority.UserRegExCheckErrorMessage = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 123);
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
            this.cmbSolver.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbSolver.IsValidating = true;
            this.cmbSolver.Items.AddRange(new object[] {
            "Gauss_direct",
            "SOR_iterative",
            "CG_iterative"});
            this.cmbSolver.Location = new System.Drawing.Point(190, 120);
            this.cmbSolver.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.cmbSolver.Name = "cmbSolver";
            this.cmbSolver.Size = new System.Drawing.Size(490, 21);
            this.cmbSolver.TabIndex = 138;
            this.cmbSolver.Text = "SOR_iterative";
            this.cmbSolver.UserRegExCheck = null;
            this.cmbSolver.UserRegExCheckErrorMessage = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(8, 228);
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
            this.txbRelaxation.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbRelaxation.IsValidating = true;
            this.txbRelaxation.Location = new System.Drawing.Point(190, 199);
            this.txbRelaxation.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbRelaxation.Name = "txbRelaxation";
            this.txbRelaxation.Size = new System.Drawing.Size(490, 20);
            this.txbRelaxation.TabIndex = 131;
            this.txbRelaxation.Text = "1.05";
            this.txbRelaxation.UserRegExCheck = null;
            this.txbRelaxation.UserRegExCheckErrorMessage = null;
            // 
            // txbPrecision
            // 
            this.txbPrecision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPrecision.BackColor = System.Drawing.SystemColors.Window;
            this.txbPrecision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPrecision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbPrecision.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbPrecision.IsValidating = true;
            this.txbPrecision.Location = new System.Drawing.Point(190, 173);
            this.txbPrecision.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbPrecision.Name = "txbPrecision";
            this.txbPrecision.Size = new System.Drawing.Size(490, 20);
            this.txbPrecision.TabIndex = 132;
            this.txbPrecision.Text = "0.01";
            this.txbPrecision.UserRegExCheck = null;
            this.txbPrecision.UserRegExCheckErrorMessage = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 150);
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
            this.txbSolverIterations.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Integer | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbSolverIterations.IsValidating = true;
            this.txbSolverIterations.Location = new System.Drawing.Point(190, 147);
            this.txbSolverIterations.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbSolverIterations.Name = "txbSolverIterations";
            this.txbSolverIterations.Size = new System.Drawing.Size(490, 20);
            this.txbSolverIterations.TabIndex = 133;
            this.txbSolverIterations.Text = "100";
            this.txbSolverIterations.UserRegExCheck = null;
            this.txbSolverIterations.UserRegExCheckErrorMessage = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(8, 204);
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
            this.txbIters.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Integer | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbIters.IsValidating = true;
            this.txbIters.Location = new System.Drawing.Point(190, 68);
            this.txbIters.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbIters.Name = "txbIters";
            this.txbIters.Size = new System.Drawing.Size(490, 20);
            this.txbIters.TabIndex = 127;
            this.txbIters.Text = "2";
            this.txbIters.UserRegExCheck = null;
            this.txbIters.UserRegExCheckErrorMessage = null;
            // 
            // maxTMIter
            // 
            this.maxTMIter.AutoSize = true;
            this.maxTMIter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxTMIter.Location = new System.Drawing.Point(8, 71);
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
            this.txbSaveRate.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Integer | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbSaveRate.IsValidating = true;
            this.txbSaveRate.Location = new System.Drawing.Point(190, 94);
            this.txbSaveRate.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbSaveRate.Name = "txbSaveRate";
            this.txbSaveRate.Size = new System.Drawing.Size(490, 20);
            this.txbSaveRate.TabIndex = 129;
            this.txbSaveRate.Text = "1";
            this.txbSaveRate.UserRegExCheck = null;
            this.txbSaveRate.UserRegExCheckErrorMessage = null;
            // 
            // lblSaveRateTM
            // 
            this.lblSaveRateTM.AutoSize = true;
            this.lblSaveRateTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSaveRateTM.Location = new System.Drawing.Point(8, 97);
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
            this.txbInitTemp.InputType = UserControlsEx.TXTBoxInputType.Float;
            this.txbInitTemp.IsValidating = true;
            this.txbInitTemp.Location = new System.Drawing.Point(190, 42);
            this.txbInitTemp.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbInitTemp.Name = "txbInitTemp";
            this.txbInitTemp.Size = new System.Drawing.Size(490, 20);
            this.txbInitTemp.TabIndex = 124;
            this.txbInitTemp.Text = "20";
            this.txbInitTemp.UserRegExCheck = null;
            this.txbInitTemp.UserRegExCheckErrorMessage = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 45);
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
            this.chbDTtMax.Location = new System.Drawing.Point(10, 18);
            this.chbDTtMax.Margin = new System.Windows.Forms.Padding(10, 7, 3, 3);
            this.chbDTtMax.Name = "chbDTtMax";
            this.chbDTtMax.Size = new System.Drawing.Size(151, 17);
            this.chbDTtMax.TabIndex = 126;
            this.chbDTtMax.Text = "Макс. темп. (dTt max), C°";
            this.chbDTtMax.UseVisualStyleBackColor = true;
            this.chbDTtMax.CheckedChanged += new System.EventHandler(this.chbDTtMax_CheckedChanged);
            // 
            // txbDTtMax
            // 
            this.txbDTtMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDTtMax.BackColor = System.Drawing.SystemColors.Window;
            this.txbDTtMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbDTtMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbDTtMax.InputType = UserControlsEx.TXTBoxInputType.Float;
            this.txbDTtMax.IsValidating = true;
            this.txbDTtMax.Location = new System.Drawing.Point(190, 18);
            this.txbDTtMax.Margin = new System.Windows.Forms.Padding(178, 15, 20, 3);
            this.txbDTtMax.Name = "txbDTtMax";
            this.txbDTtMax.Size = new System.Drawing.Size(490, 20);
            this.txbDTtMax.TabIndex = 123;
            this.txbDTtMax.Text = "1500";
            this.txbDTtMax.UserRegExCheck = null;
            this.txbDTtMax.UserRegExCheckErrorMessage = null;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(605, 260);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 7, 20, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 141;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HeatTaskControl_v2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.button1);
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
            this.MaximumSize = new System.Drawing.Size(700, 300);
            this.Name = "HeatTaskControl_v2";
            this.Size = new System.Drawing.Size(700, 299);
            this.Tag = "260";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private ComboBoxEx cmbPriority;
        private System.Windows.Forms.Label label3;
        private ComboBoxEx cmbSolver;
        private System.Windows.Forms.Label label12;
        private TextBoxEx txbRelaxation;
        private TextBoxEx txbPrecision;
        private System.Windows.Forms.Label label1;
        private TextBoxEx txbSolverIterations;
        private System.Windows.Forms.Label label7;
        private TextBoxEx txbIters;
        private System.Windows.Forms.Label maxTMIter;
        private TextBoxEx txbSaveRate;
        private System.Windows.Forms.Label lblSaveRateTM;
        private TextBoxEx txbInitTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbDTtMax;
        private TextBoxEx txbDTtMax;
        private System.Windows.Forms.Button button1;
    }
}
