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
            this.components = new System.ComponentModel.Container();
            this.chbDTtMax = new System.Windows.Forms.CheckBox();
            this.txbDTtMax = new UserControlsEx.TextBoxEx(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.maxTMIter = new System.Windows.Forms.Label();
            this.lblSaveRateTM = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPriority = new UserControlsEx.ComboBoxEx(this.components);
            this.txbRelaxation = new UserControlsEx.TextBoxEx(this.components);
            this.txbPrecision = new UserControlsEx.TextBoxEx(this.components);
            this.txbSolverIterations = new UserControlsEx.TextBoxEx(this.components);
            this.cmbSolver = new UserControlsEx.ComboBoxEx(this.components);
            this.txbSaveRate = new UserControlsEx.TextBoxEx(this.components);
            this.txbIters = new UserControlsEx.TextBoxEx(this.components);
            this.txbInitConcentration = new UserControlsEx.TextBoxEx(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chbDTtMax
            // 
            this.chbDTtMax.AutoSize = true;
            this.chbDTtMax.Checked = true;
            this.chbDTtMax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDTtMax.Enabled = false;
            this.chbDTtMax.Location = new System.Drawing.Point(9, 7);
            this.chbDTtMax.Name = "chbDTtMax";
            this.chbDTtMax.Size = new System.Drawing.Size(167, 17);
            this.chbDTtMax.TabIndex = 110;
            this.chbDTtMax.Text = "Макс.концентр. (dCt max), %";
            this.chbDTtMax.UseVisualStyleBackColor = true;
            // 
            // txbDTtMax
            // 
            this.txbDTtMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDTtMax.BackColor = System.Drawing.SystemColors.Window;
            this.txbDTtMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbDTtMax.InputType = UserControlsEx.TXTBoxInputType.Text;
            this.txbDTtMax.IsValidating = true;
            this.txbDTtMax.Location = new System.Drawing.Point(178, 5);
            this.txbDTtMax.Margin = new System.Windows.Forms.Padding(178, 10, 20, 3);
            this.txbDTtMax.Name = "txbDTtMax";
            this.txbDTtMax.Size = new System.Drawing.Size(296, 20);
            this.txbDTtMax.TabIndex = 109;
            this.txbDTtMax.Text = "3";
            this.txbDTtMax.UserRegExCheck = null;
            this.txbDTtMax.UserRegExCheckErrorMessage = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 128;
            this.label4.Text = "Точность решения, у.ед.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 129;
            this.label3.Text = "Алгоритм решения";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 217);
            this.label12.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 132;
            this.label12.Text = "Приоритет";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 139);
            this.label1.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 130;
            this.label1.Text = "Кол-во итераций решения";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 191);
            this.label7.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 131;
            this.label7.Text = "Коэф. релаксации (w)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maxTMIter
            // 
            this.maxTMIter.AutoSize = true;
            this.maxTMIter.Location = new System.Drawing.Point(10, 60);
            this.maxTMIter.Margin = new System.Windows.Forms.Padding(7, 28, 3, 10);
            this.maxTMIter.Name = "maxTMIter";
            this.maxTMIter.Size = new System.Drawing.Size(134, 13);
            this.maxTMIter.TabIndex = 126;
            this.maxTMIter.Text = "Кол-во итераций на шаге";
            this.maxTMIter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxTMIter.UseWaitCursor = true;
            // 
            // lblSaveRateTM
            // 
            this.lblSaveRateTM.AutoSize = true;
            this.lblSaveRateTM.Location = new System.Drawing.Point(10, 86);
            this.lblSaveRateTM.Margin = new System.Windows.Forms.Padding(7, 28, 3, 10);
            this.lblSaveRateTM.Name = "lblSaveRateTM";
            this.lblSaveRateTM.Size = new System.Drawing.Size(136, 13);
            this.lblSaveRateTM.TabIndex = 127;
            this.lblSaveRateTM.Text = "Частота сохранений, шаг";
            this.lblSaveRateTM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSaveRateTM.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
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
            this.cmbPriority.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbPriority.IsValidating = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "Низкий",
            "НижеСреднего",
            "Средний",
            "ВышеСреднего",
            "Высокий",
            "Наивысший"});
            this.cmbPriority.Location = new System.Drawing.Point(178, 214);
            this.cmbPriority.Margin = new System.Windows.Forms.Padding(178, 3, 15, 7);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(296, 21);
            this.cmbPriority.TabIndex = 136;
            this.cmbPriority.Text = "Наивысший";
            this.cmbPriority.UserRegExCheck = null;
            this.cmbPriority.UserRegExCheckErrorMessage = null;
            // 
            // txbRelaxation
            // 
            this.txbRelaxation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRelaxation.BackColor = System.Drawing.SystemColors.Window;
            this.txbRelaxation.InputType = UserControlsEx.TXTBoxInputType.Text;
            this.txbRelaxation.IsValidating = true;
            this.txbRelaxation.Location = new System.Drawing.Point(178, 188);
            this.txbRelaxation.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbRelaxation.Name = "txbRelaxation";
            this.txbRelaxation.Size = new System.Drawing.Size(296, 20);
            this.txbRelaxation.TabIndex = 137;
            this.txbRelaxation.Text = "1.05";
            this.txbRelaxation.UserRegExCheck = null;
            this.txbRelaxation.UserRegExCheckErrorMessage = null;
            // 
            // txbPrecision
            // 
            this.txbPrecision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPrecision.BackColor = System.Drawing.SystemColors.Window;
            this.txbPrecision.InputType = UserControlsEx.TXTBoxInputType.Text;
            this.txbPrecision.IsValidating = true;
            this.txbPrecision.Location = new System.Drawing.Point(178, 162);
            this.txbPrecision.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbPrecision.Name = "txbPrecision";
            this.txbPrecision.Size = new System.Drawing.Size(296, 20);
            this.txbPrecision.TabIndex = 138;
            this.txbPrecision.Text = "0.01";
            this.txbPrecision.UserRegExCheck = null;
            this.txbPrecision.UserRegExCheckErrorMessage = null;
            // 
            // txbSolverIterations
            // 
            this.txbSolverIterations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSolverIterations.BackColor = System.Drawing.SystemColors.Window;
            this.txbSolverIterations.InputType = UserControlsEx.TXTBoxInputType.Text;
            this.txbSolverIterations.IsValidating = true;
            this.txbSolverIterations.Location = new System.Drawing.Point(178, 136);
            this.txbSolverIterations.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbSolverIterations.Name = "txbSolverIterations";
            this.txbSolverIterations.Size = new System.Drawing.Size(296, 20);
            this.txbSolverIterations.TabIndex = 139;
            this.txbSolverIterations.Text = "100";
            this.txbSolverIterations.UserRegExCheck = null;
            this.txbSolverIterations.UserRegExCheckErrorMessage = null;
            // 
            // cmbSolver
            // 
            this.cmbSolver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSolver.FormattingEnabled = true;
            this.cmbSolver.InputType = UserControlsEx.CMBInputType.Items;
            this.cmbSolver.IsValidating = true;
            this.cmbSolver.Items.AddRange(new object[] {
            "Gauss_direct",
            "SOR_iterative",
            "CG_iterative"});
            this.cmbSolver.Location = new System.Drawing.Point(178, 110);
            this.cmbSolver.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.cmbSolver.Name = "cmbSolver";
            this.cmbSolver.Size = new System.Drawing.Size(296, 21);
            this.cmbSolver.TabIndex = 140;
            this.cmbSolver.Text = "SOR_iterative";
            this.cmbSolver.UserRegExCheck = null;
            this.cmbSolver.UserRegExCheckErrorMessage = null;
            // 
            // txbSaveRate
            // 
            this.txbSaveRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSaveRate.BackColor = System.Drawing.SystemColors.Window;
            this.txbSaveRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbSaveRate.InputType = UserControlsEx.TXTBoxInputType.Text;
            this.txbSaveRate.IsValidating = true;
            this.txbSaveRate.Location = new System.Drawing.Point(178, 84);
            this.txbSaveRate.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbSaveRate.Name = "txbSaveRate";
            this.txbSaveRate.Size = new System.Drawing.Size(296, 20);
            this.txbSaveRate.TabIndex = 141;
            this.txbSaveRate.Text = "1";
            this.txbSaveRate.UserRegExCheck = null;
            this.txbSaveRate.UserRegExCheckErrorMessage = null;
            // 
            // txbIters
            // 
            this.txbIters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbIters.BackColor = System.Drawing.SystemColors.Window;
            this.txbIters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbIters.InputType = UserControlsEx.TXTBoxInputType.Text;
            this.txbIters.IsValidating = true;
            this.txbIters.Location = new System.Drawing.Point(178, 58);
            this.txbIters.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbIters.Name = "txbIters";
            this.txbIters.Size = new System.Drawing.Size(296, 20);
            this.txbIters.TabIndex = 142;
            this.txbIters.Text = "2";
            this.txbIters.UserRegExCheck = null;
            this.txbIters.UserRegExCheckErrorMessage = null;
            // 
            // txbInitConcentration
            // 
            this.txbInitConcentration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbInitConcentration.BackColor = System.Drawing.SystemColors.Window;
            this.txbInitConcentration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbInitConcentration.InputType = UserControlsEx.TXTBoxInputType.Text;
            this.txbInitConcentration.IsValidating = true;
            this.txbInitConcentration.Location = new System.Drawing.Point(178, 32);
            this.txbInitConcentration.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbInitConcentration.Name = "txbInitConcentration";
            this.txbInitConcentration.Size = new System.Drawing.Size(296, 20);
            this.txbInitConcentration.TabIndex = 143;
            this.txbInitConcentration.Text = "0.18";
            this.txbInitConcentration.UserRegExCheck = null;
            this.txbInitConcentration.UserRegExCheckErrorMessage = null;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(399, 249);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 7, 20, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 144;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChemTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.button1);
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
            this.Name = "ChemTaskControl";
            this.Size = new System.Drawing.Size(494, 288);
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
        private System.Windows.Forms.Button button1;
    }
}
