namespace AdvisorControls.TaskPlannerControls
{
    partial class HeatTaskControl
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
            this.label5 = new System.Windows.Forms.Label();
            this.lblFileParameters = new System.Windows.Forms.Label();
            this.btnLoadParameters = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 116;
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
            this.cmbPriority.Location = new System.Drawing.Point(208, 214);
            this.cmbPriority.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(519, 21);
            this.cmbPriority.TabIndex = 122;
            this.cmbPriority.Text = "Наивысший";
            this.cmbPriority.SelectedIndexChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 117;
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
            this.cmbSolver.Location = new System.Drawing.Point(208, 109);
            this.cmbSolver.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbSolver.Name = "cmbSolver";
            this.cmbSolver.Size = new System.Drawing.Size(519, 21);
            this.cmbSolver.TabIndex = 120;
            this.cmbSolver.Text = "SOR_iterative";
            this.cmbSolver.SelectedIndexChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 217);
            this.label12.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 121;
            this.label12.Text = "Приоритет";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbRelaxation
            // 
            this.txbRelaxation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRelaxation.BackColor = System.Drawing.SystemColors.Window;
            this.txbRelaxation.Location = new System.Drawing.Point(208, 188);
            this.txbRelaxation.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbRelaxation.Name = "txbRelaxation";
            this.txbRelaxation.Size = new System.Drawing.Size(519, 20);
            this.txbRelaxation.TabIndex = 113;
            this.txbRelaxation.Text = "1.05";
            this.txbRelaxation.EnabledChanged += new System.EventHandler(this.Txb_EnabledChanged);
            this.txbRelaxation.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // txbPrecision
            // 
            this.txbPrecision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPrecision.BackColor = System.Drawing.SystemColors.Window;
            this.txbPrecision.Location = new System.Drawing.Point(208, 162);
            this.txbPrecision.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbPrecision.Name = "txbPrecision";
            this.txbPrecision.Size = new System.Drawing.Size(519, 20);
            this.txbPrecision.TabIndex = 114;
            this.txbPrecision.Text = "0.01";
            this.txbPrecision.EnabledChanged += new System.EventHandler(this.Txb_EnabledChanged);
            this.txbPrecision.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 139);
            this.label1.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 118;
            this.label1.Text = "Кол-во итераций решения";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbSolverIterations
            // 
            this.txbSolverIterations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSolverIterations.BackColor = System.Drawing.SystemColors.Window;
            this.txbSolverIterations.Location = new System.Drawing.Point(208, 136);
            this.txbSolverIterations.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbSolverIterations.Name = "txbSolverIterations";
            this.txbSolverIterations.Size = new System.Drawing.Size(519, 20);
            this.txbSolverIterations.TabIndex = 115;
            this.txbSolverIterations.Text = "100";
            this.txbSolverIterations.EnabledChanged += new System.EventHandler(this.Txb_EnabledChanged);
            this.txbSolverIterations.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 191);
            this.label7.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 119;
            this.label7.Text = "Коэф. релаксации (w)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbIters
            // 
            this.txbIters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbIters.BackColor = System.Drawing.SystemColors.Window;
            this.txbIters.Location = new System.Drawing.Point(208, 57);
            this.txbIters.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbIters.Name = "txbIters";
            this.txbIters.Size = new System.Drawing.Size(519, 20);
            this.txbIters.TabIndex = 109;
            this.txbIters.Text = "2";
            this.txbIters.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // maxTMIter
            // 
            this.maxTMIter.AutoSize = true;
            this.maxTMIter.Location = new System.Drawing.Point(10, 60);
            this.maxTMIter.Margin = new System.Windows.Forms.Padding(7, 28, 3, 10);
            this.maxTMIter.Name = "maxTMIter";
            this.maxTMIter.Size = new System.Drawing.Size(134, 13);
            this.maxTMIter.TabIndex = 110;
            this.maxTMIter.Text = "Кол-во итераций на шаге";
            this.maxTMIter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maxTMIter.UseWaitCursor = true;
            // 
            // txbSaveRate
            // 
            this.txbSaveRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSaveRate.BackColor = System.Drawing.SystemColors.Window;
            this.txbSaveRate.Location = new System.Drawing.Point(208, 83);
            this.txbSaveRate.Margin = new System.Windows.Forms.Padding(3, 3, 27, 3);
            this.txbSaveRate.Name = "txbSaveRate";
            this.txbSaveRate.Size = new System.Drawing.Size(519, 20);
            this.txbSaveRate.TabIndex = 111;
            this.txbSaveRate.Text = "1";
            this.txbSaveRate.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // lblSaveRateTM
            // 
            this.lblSaveRateTM.AutoSize = true;
            this.lblSaveRateTM.Location = new System.Drawing.Point(10, 86);
            this.lblSaveRateTM.Margin = new System.Windows.Forms.Padding(7, 28, 3, 10);
            this.lblSaveRateTM.Name = "lblSaveRateTM";
            this.lblSaveRateTM.Size = new System.Drawing.Size(136, 13);
            this.lblSaveRateTM.TabIndex = 112;
            this.lblSaveRateTM.Text = "Частота сохранений, шаг";
            this.lblSaveRateTM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSaveRateTM.UseWaitCursor = true;
            // 
            // txbInitTemp
            // 
            this.txbInitTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbInitTemp.BackColor = System.Drawing.SystemColors.Window;
            this.txbInitTemp.Location = new System.Drawing.Point(208, 31);
            this.txbInitTemp.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbInitTemp.Name = "txbInitTemp";
            this.txbInitTemp.Size = new System.Drawing.Size(519, 20);
            this.txbInitTemp.TabIndex = 106;
            this.txbInitTemp.Text = "20";
            this.txbInitTemp.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 107;
            this.label2.Text = "Начальная температура, С°";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbDTtMax
            // 
            this.chbDTtMax.AutoSize = true;
            this.chbDTtMax.Checked = true;
            this.chbDTtMax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDTtMax.Enabled = false;
            this.chbDTtMax.Location = new System.Drawing.Point(9, 7);
            this.chbDTtMax.Margin = new System.Windows.Forms.Padding(10, 7, 3, 3);
            this.chbDTtMax.Name = "chbDTtMax";
            this.chbDTtMax.Size = new System.Drawing.Size(188, 17);
            this.chbDTtMax.TabIndex = 108;
            this.chbDTtMax.Text = "Макс. температура (dTt max), C°";
            this.chbDTtMax.UseVisualStyleBackColor = true;
            // 
            // txbDTtMax
            // 
            this.txbDTtMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDTtMax.BackColor = System.Drawing.SystemColors.Window;
            this.txbDTtMax.Location = new System.Drawing.Point(208, 5);
            this.txbDTtMax.Margin = new System.Windows.Forms.Padding(3, 10, 28, 3);
            this.txbDTtMax.Name = "txbDTtMax";
            this.txbDTtMax.Size = new System.Drawing.Size(519, 20);
            this.txbDTtMax.TabIndex = 105;
            this.txbDTtMax.Text = "1500";
            this.txbDTtMax.TextChanged += new System.EventHandler(this.AllTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 248);
            this.label5.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 124;
            this.label5.Text = "Загрузить из файла";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFileParameters
            // 
            this.lblFileParameters.AutoSize = true;
            this.lblFileParameters.Location = new System.Drawing.Point(236, 248);
            this.lblFileParameters.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.lblFileParameters.Name = "lblFileParameters";
            this.lblFileParameters.Size = new System.Drawing.Size(165, 13);
            this.lblFileParameters.TabIndex = 125;
            this.lblFileParameters.Text = "Выберите файл с настройками";
            this.lblFileParameters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLoadParameters
            // 
            this.btnLoadParameters.AutoSize = true;
            this.btnLoadParameters.Image = global::TaskModule.Properties.Resources.ComputationFolder;
            this.btnLoadParameters.Location = new System.Drawing.Point(208, 241);
            this.btnLoadParameters.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnLoadParameters.Name = "btnLoadParameters";
            this.btnLoadParameters.Size = new System.Drawing.Size(26, 26);
            this.btnLoadParameters.TabIndex = 123;
            this.btnLoadParameters.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadParameters.UseVisualStyleBackColor = true;
            this.btnLoadParameters.Click += new System.EventHandler(this.btnLoadParameters_Click);
            // 
            // HeatTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.lblFileParameters);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLoadParameters);
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
            this.Name = "HeatTaskControl";
            this.Size = new System.Drawing.Size(755, 271);
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
        private System.Windows.Forms.Button btnLoadParameters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFileParameters;
    }
}
