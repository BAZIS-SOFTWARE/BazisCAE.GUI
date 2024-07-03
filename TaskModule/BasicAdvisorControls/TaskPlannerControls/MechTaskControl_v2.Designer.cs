using BaseModule.ControlsLib;

namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    partial class MechTaskControl_v2
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
            this.label6 = new System.Windows.Forms.Label();
            this.chbPlastisity = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPriority = new BaseModule.ControlsLib.ComboBoxEx(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSolver = new BaseModule.ControlsLib.ComboBoxEx(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txbRelaxation = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.txbPrecision = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txbSolverIterations = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txbIters = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.maxTMIter = new System.Windows.Forms.Label();
            this.txbSaveRate = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.lblSaveRateTM = new System.Windows.Forms.Label();
            this.txbBodyTemp = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.chbUMax = new System.Windows.Forms.CheckBox();
            this.txbMaxSiSt = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.txbMaxU = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.txbMaxDU = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(8, 13);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 153;
            this.label6.Text = "Макс. разница dU, >0";
            // 
            // chbPlastisity
            // 
            this.chbPlastisity.AutoSize = true;
            this.chbPlastisity.Checked = true;
            this.chbPlastisity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPlastisity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbPlastisity.Location = new System.Drawing.Point(9, 64);
            this.chbPlastisity.Name = "chbPlastisity";
            this.chbPlastisity.Size = new System.Drawing.Size(175, 17);
            this.chbPlastisity.TabIndex = 152;
            this.chbPlastisity.Text = "Пласт. деформации Si/St, >1 ";
            this.chbPlastisity.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 222);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 145;
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
            this.cmbPriority.InputType = BaseModule.ControlsLib.CMBInputType.Items;
            this.cmbPriority.IsValidating = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "Низкий",
            "НижеСреднего",
            "Средний",
            "ВышеСреднего",
            "Высокий",
            "Наивысший"});
            this.cmbPriority.Location = new System.Drawing.Point(190, 271);
            this.cmbPriority.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(573, 21);
            this.cmbPriority.TabIndex = 151;
            this.cmbPriority.Text = "Наивысший";
            this.cmbPriority.UserRegExCheck = null;
            this.cmbPriority.UserRegExCheckErrorMessage = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 146;
            this.label3.Text = "Алгоритм решения";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbSolver
            // 
            this.cmbSolver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbSolver.FormattingEnabled = true;
            this.cmbSolver.InputType = BaseModule.ControlsLib.CMBInputType.Items;
            this.cmbSolver.IsValidating = true;
            this.cmbSolver.Items.AddRange(new object[] {
            "Gauss_direct",
            "SOR_iterative",
            "CG_iterative"});
            this.cmbSolver.Location = new System.Drawing.Point(190, 166);
            this.cmbSolver.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.cmbSolver.Name = "cmbSolver";
            this.cmbSolver.Size = new System.Drawing.Size(573, 21);
            this.cmbSolver.TabIndex = 149;
            this.cmbSolver.Text = "SOR_iterative";
            this.cmbSolver.UserRegExCheck = null;
            this.cmbSolver.UserRegExCheckErrorMessage = null;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(8, 274);
            this.label12.Margin = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 150;
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
            this.txbRelaxation.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Float | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbRelaxation.IsValidating = true;
            this.txbRelaxation.Location = new System.Drawing.Point(190, 245);
            this.txbRelaxation.Margin = new System.Windows.Forms.Padding(190, 3, 15, 3);
            this.txbRelaxation.Name = "txbRelaxation";
            this.txbRelaxation.Size = new System.Drawing.Size(573, 20);
            this.txbRelaxation.TabIndex = 142;
            this.txbRelaxation.Text = "1.25";
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
            this.txbPrecision.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Float | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbPrecision.IsValidating = true;
            this.txbPrecision.Location = new System.Drawing.Point(190, 219);
            this.txbPrecision.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbPrecision.Name = "txbPrecision";
            this.txbPrecision.Size = new System.Drawing.Size(573, 20);
            this.txbPrecision.TabIndex = 143;
            this.txbPrecision.Text = "0.0001";
            this.txbPrecision.UserRegExCheck = null;
            this.txbPrecision.UserRegExCheckErrorMessage = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 197);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 147;
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
            this.txbSolverIterations.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Integer | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbSolverIterations.IsValidating = true;
            this.txbSolverIterations.Location = new System.Drawing.Point(190, 193);
            this.txbSolverIterations.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbSolverIterations.Name = "txbSolverIterations";
            this.txbSolverIterations.Size = new System.Drawing.Size(573, 20);
            this.txbSolverIterations.TabIndex = 144;
            this.txbSolverIterations.Text = "100";
            this.txbSolverIterations.UserRegExCheck = null;
            this.txbSolverIterations.UserRegExCheckErrorMessage = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(8, 248);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 148;
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
            this.txbIters.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Integer | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbIters.IsValidating = true;
            this.txbIters.Location = new System.Drawing.Point(190, 114);
            this.txbIters.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbIters.Name = "txbIters";
            this.txbIters.Size = new System.Drawing.Size(573, 20);
            this.txbIters.TabIndex = 138;
            this.txbIters.Text = "25";
            this.txbIters.UserRegExCheck = null;
            this.txbIters.UserRegExCheckErrorMessage = null;
            // 
            // maxTMIter
            // 
            this.maxTMIter.AutoSize = true;
            this.maxTMIter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxTMIter.Location = new System.Drawing.Point(8, 121);
            this.maxTMIter.Margin = new System.Windows.Forms.Padding(8, 28, 3, 10);
            this.maxTMIter.Name = "maxTMIter";
            this.maxTMIter.Size = new System.Drawing.Size(134, 13);
            this.maxTMIter.TabIndex = 139;
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
            this.txbSaveRate.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Integer | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbSaveRate.IsValidating = true;
            this.txbSaveRate.Location = new System.Drawing.Point(190, 140);
            this.txbSaveRate.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbSaveRate.Name = "txbSaveRate";
            this.txbSaveRate.Size = new System.Drawing.Size(573, 20);
            this.txbSaveRate.TabIndex = 140;
            this.txbSaveRate.Text = "5";
            this.txbSaveRate.UserRegExCheck = null;
            this.txbSaveRate.UserRegExCheckErrorMessage = null;
            // 
            // lblSaveRateTM
            // 
            this.lblSaveRateTM.AutoSize = true;
            this.lblSaveRateTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSaveRateTM.Location = new System.Drawing.Point(8, 147);
            this.lblSaveRateTM.Margin = new System.Windows.Forms.Padding(8, 28, 3, 10);
            this.lblSaveRateTM.Name = "lblSaveRateTM";
            this.lblSaveRateTM.Size = new System.Drawing.Size(136, 13);
            this.lblSaveRateTM.TabIndex = 141;
            this.lblSaveRateTM.Text = "Частота сохранений, шаг";
            this.lblSaveRateTM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSaveRateTM.UseWaitCursor = true;
            // 
            // txbBodyTemp
            // 
            this.txbBodyTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBodyTemp.BackColor = System.Drawing.SystemColors.Window;
            this.txbBodyTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbBodyTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbBodyTemp.InputType = BaseModule.ControlsLib.TXTBoxInputType.Float;
            this.txbBodyTemp.IsValidating = true;
            this.txbBodyTemp.Location = new System.Drawing.Point(190, 88);
            this.txbBodyTemp.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbBodyTemp.Name = "txbBodyTemp";
            this.txbBodyTemp.Size = new System.Drawing.Size(573, 20);
            this.txbBodyTemp.TabIndex = 136;
            this.txbBodyTemp.Text = "20";
            this.txbBodyTemp.UserRegExCheck = null;
            this.txbBodyTemp.UserRegExCheckErrorMessage = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 137;
            this.label2.Text = "Температура, С°";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbUMax
            // 
            this.chbUMax.AutoSize = true;
            this.chbUMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbUMax.Location = new System.Drawing.Point(9, 38);
            this.chbUMax.Name = "chbUMax";
            this.chbUMax.Size = new System.Drawing.Size(159, 17);
            this.chbUMax.TabIndex = 135;
            this.chbUMax.Text = "Макс. перемещения U, >0";
            this.chbUMax.UseVisualStyleBackColor = true;
            // 
            // txbMaxSiSt
            // 
            this.txbMaxSiSt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxSiSt.BackColor = System.Drawing.SystemColors.Window;
            this.txbMaxSiSt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbMaxSiSt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbMaxSiSt.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Float | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbMaxSiSt.IsValidating = true;
            this.txbMaxSiSt.Location = new System.Drawing.Point(190, 62);
            this.txbMaxSiSt.Margin = new System.Windows.Forms.Padding(190, 3, 15, 3);
            this.txbMaxSiSt.Name = "txbMaxSiSt";
            this.txbMaxSiSt.Size = new System.Drawing.Size(573, 20);
            this.txbMaxSiSt.TabIndex = 134;
            this.txbMaxSiSt.Text = "1.25";
            this.txbMaxSiSt.UserRegExCheck = null;
            this.txbMaxSiSt.UserRegExCheckErrorMessage = null;
            // 
            // txbMaxU
            // 
            this.txbMaxU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxU.BackColor = System.Drawing.SystemColors.Window;
            this.txbMaxU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbMaxU.Enabled = false;
            this.txbMaxU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbMaxU.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Float | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbMaxU.IsValidating = true;
            this.txbMaxU.Location = new System.Drawing.Point(190, 36);
            this.txbMaxU.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbMaxU.Name = "txbMaxU";
            this.txbMaxU.Size = new System.Drawing.Size(573, 20);
            this.txbMaxU.TabIndex = 133;
            this.txbMaxU.Text = "0.05";
            this.txbMaxU.UserRegExCheck = null;
            this.txbMaxU.UserRegExCheckErrorMessage = null;
            // 
            // txbMaxDU
            // 
            this.txbMaxDU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxDU.BackColor = System.Drawing.SystemColors.Window;
            this.txbMaxDU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbMaxDU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbMaxDU.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Float | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbMaxDU.IsValidating = true;
            this.txbMaxDU.Location = new System.Drawing.Point(190, 10);
            this.txbMaxDU.Margin = new System.Windows.Forms.Padding(178, 10, 15, 3);
            this.txbMaxDU.Name = "txbMaxDU";
            this.txbMaxDU.Size = new System.Drawing.Size(573, 20);
            this.txbMaxDU.TabIndex = 132;
            this.txbMaxDU.Text = "0.0005";
            this.txbMaxDU.UserRegExCheck = null;
            this.txbMaxDU.UserRegExCheckErrorMessage = null;
            // 
            // MechTaskControl_v2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
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
            this.Controls.Add(this.txbMaxSiSt);
            this.Controls.Add(this.txbMaxU);
            this.Controls.Add(this.txbMaxDU);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MinimumSize = new System.Drawing.Size(0, 300);
            this.Name = "MechTaskControl_v2";
            this.Size = new System.Drawing.Size(778, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chbPlastisity;
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
        private TextBoxEx txbBodyTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbUMax;
        private TextBoxEx txbMaxSiSt;
        private TextBoxEx txbMaxU;
        private TextBoxEx txbMaxDU;
    }
}
