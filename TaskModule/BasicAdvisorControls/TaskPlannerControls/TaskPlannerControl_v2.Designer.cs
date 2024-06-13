using BaseModule.ControlsLib;

namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    partial class TaskPlannerControl_v2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskPlannerControl_v2));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Settings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PrevResultLoadBtn = new System.Windows.Forms.Button();
            this.btnLoadParameters = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.txbStartStep = new System.Windows.Forms.TextBox();
            this.btnGenTCF = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbMaxStep = new System.Windows.Forms.TextBox();
            this.txbMinStep = new System.Windows.Forms.TextBox();
            this.chbAddByTaskConditions = new System.Windows.Forms.CheckBox();
            this.btnClearAllTask = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAddNewTask = new System.Windows.Forms.Button();
            this.txbStartTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbStopTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grbTaskKind = new System.Windows.Forms.GroupBox();
            this.chbFurtherComp = new System.Windows.Forms.CheckBox();
            this.cmbHardnessTask = new System.Windows.Forms.CheckBox();
            this.lblMechTask = new System.Windows.Forms.Label();
            this.lblHardness = new System.Windows.Forms.Label();
            this.lblTermoTask = new System.Windows.Forms.Label();
            this.lblChemicalTask = new System.Windows.Forms.Label();
            this.chbMechTask = new System.Windows.Forms.CheckBox();
            this.chbTermoTask = new System.Windows.Forms.CheckBox();
            this.chbChemicalTask = new System.Windows.Forms.CheckBox();
            this.chbLinkedCalc = new System.Windows.Forms.CheckBox();
            this.grbTaskSettings = new BaseModule.ControlsLib.GroupBoxEx();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbTaskKind.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grbTaskKind, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grbTaskSettings, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 727);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Kind,
            this.Settings,
            this.Time});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(7, 374);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(7);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(1112, 752);
            this.dataGridView.TabIndex = 14;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
            this.dataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.DataGridView_SortCompare);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DataGridView_UserDeletingRow);
            // 
            // Kind
            // 
            this.Kind.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Kind.HeaderText = "Вид";
            this.Kind.MinimumWidth = 6;
            this.Kind.Name = "Kind";
            this.Kind.ReadOnly = true;
            this.Kind.Width = 51;
            // 
            // Settings
            // 
            this.Settings.HeaderText = "Настройки";
            this.Settings.MinimumWidth = 6;
            this.Settings.Name = "Settings";
            this.Settings.ReadOnly = true;
            this.Settings.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Time.FalseValue = "пропустить";
            this.Time.HeaderText = "Статус";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Time.TrueValue = "выполнить";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.PrevResultLoadBtn);
            this.groupBox1.Controls.Add(this.btnLoadParameters);
            this.groupBox1.Controls.Add(this.StopButton);
            this.groupBox1.Controls.Add(this.txbStartStep);
            this.groupBox1.Controls.Add(this.btnGenTCF);
            this.groupBox1.Controls.Add(this.StartButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txbMaxStep);
            this.groupBox1.Controls.Add(this.txbMinStep);
            this.groupBox1.Controls.Add(this.chbAddByTaskConditions);
            this.groupBox1.Controls.Add(this.btnClearAllTask);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnAddNewTask);
            this.groupBox1.Controls.Add(this.txbStartTime);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txbStopTime);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(7, 144);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(686, 219);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Временные параметры";
            // 
            // PrevResultLoadBtn
            // 
            this.PrevResultLoadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PrevResultLoadBtn.AutoSize = true;
            this.PrevResultLoadBtn.Enabled = false;
            this.PrevResultLoadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.PrevResultLoadBtn.Location = new System.Drawing.Point(266, 179);
            this.PrevResultLoadBtn.Margin = new System.Windows.Forms.Padding(1, 1, 3, 1);
            this.PrevResultLoadBtn.Name = "PrevResultLoadBtn";
            this.PrevResultLoadBtn.Size = new System.Drawing.Size(160, 26);
            this.PrevResultLoadBtn.TabIndex = 131;
            this.PrevResultLoadBtn.Text = "Предыдущие условия";
            this.PrevResultLoadBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PrevResultLoadBtn.UseVisualStyleBackColor = true;
            // 
            // btnLoadParameters
            // 
            this.btnLoadParameters.AutoSize = true;
            this.btnLoadParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnLoadParameters.Image = global::TaskModule.Properties.Resources.ComputationFolder;
            this.btnLoadParameters.Location = new System.Drawing.Point(110, 179);
            this.btnLoadParameters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.btnLoadParameters.Name = "btnLoadParameters";
            this.btnLoadParameters.Size = new System.Drawing.Size(26, 26);
            this.btnLoadParameters.TabIndex = 129;
            this.btnLoadParameters.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadParameters.UseVisualStyleBackColor = true;
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StopButton.AutoSize = true;
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.StopButton.Location = new System.Drawing.Point(604, 178);
            this.StopButton.Margin = new System.Windows.Forms.Padding(3, 1, 15, 1);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(67, 26);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Стоп";
            this.StopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // txbStartStep
            // 
            this.txbStartStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartStep.BackColor = System.Drawing.SystemColors.Window;
            this.txbStartStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txbStartStep.Location = new System.Drawing.Point(190, 80);
            this.txbStartStep.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txbStartStep.Name = "txbStartStep";
            this.txbStartStep.Size = new System.Drawing.Size(481, 20);
            this.txbStartStep.TabIndex = 76;
            this.txbStartStep.Tag = "2";
            this.txbStartStep.Text = "0.1";
            // 
            // btnGenTCF
            // 
            this.btnGenTCF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenTCF.AutoSize = true;
            this.btnGenTCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnGenTCF.Location = new System.Drawing.Point(430, 179);
            this.btnGenTCF.Margin = new System.Windows.Forms.Padding(1, 1, 3, 1);
            this.btnGenTCF.Name = "btnGenTCF";
            this.btnGenTCF.Size = new System.Drawing.Size(96, 26);
            this.btnGenTCF.TabIndex = 2;
            this.btnGenTCF.Text = "Создать *.tcf";
            this.btnGenTCF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenTCF.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.AutoSize = true;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.StartButton.Location = new System.Drawing.Point(532, 179);
            this.StartButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(66, 26);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Старт";
            this.StartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(8, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Начальный шаг расчета, сек";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseWaitCursor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(8, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 13);
            this.label5.TabIndex = 71;
            this.label5.Text = "Максимальный шаг расчета, сек";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.UseWaitCursor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(8, 109);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 10, 3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "Минимальный шаг расчета, сек";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.UseWaitCursor = true;
            // 
            // txbMaxStep
            // 
            this.txbMaxStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxStep.BackColor = System.Drawing.SystemColors.Window;
            this.txbMaxStep.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbMaxStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txbMaxStep.Location = new System.Drawing.Point(190, 132);
            this.txbMaxStep.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txbMaxStep.Name = "txbMaxStep";
            this.txbMaxStep.Size = new System.Drawing.Size(481, 20);
            this.txbMaxStep.TabIndex = 74;
            this.txbMaxStep.Tag = "4";
            this.txbMaxStep.Text = "100";
            // 
            // txbMinStep
            // 
            this.txbMinStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMinStep.BackColor = System.Drawing.SystemColors.Window;
            this.txbMinStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txbMinStep.Location = new System.Drawing.Point(190, 106);
            this.txbMinStep.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txbMinStep.Name = "txbMinStep";
            this.txbMinStep.Size = new System.Drawing.Size(482, 20);
            this.txbMinStep.TabIndex = 75;
            this.txbMinStep.Tag = "3";
            this.txbMinStep.Text = "0.00001";
            // 
            // chbAddByTaskConditions
            // 
            this.chbAddByTaskConditions.AutoSize = true;
            this.chbAddByTaskConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chbAddByTaskConditions.Location = new System.Drawing.Point(11, 156);
            this.chbAddByTaskConditions.Name = "chbAddByTaskConditions";
            this.chbAddByTaskConditions.Size = new System.Drawing.Size(181, 17);
            this.chbAddByTaskConditions.TabIndex = 54;
            this.chbAddByTaskConditions.Text = "Добавить по условиям задачи";
            this.chbAddByTaskConditions.UseVisualStyleBackColor = true;
            // 
            // btnClearAllTask
            // 
            this.btnClearAllTask.AutoSize = true;
            this.btnClearAllTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClearAllTask.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAllTask.Image")));
            this.btnClearAllTask.Location = new System.Drawing.Point(43, 178);
            this.btnClearAllTask.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.btnClearAllTask.Name = "btnClearAllTask";
            this.btnClearAllTask.Size = new System.Drawing.Size(26, 26);
            this.btnClearAllTask.TabIndex = 53;
            this.btnClearAllTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearAllTask.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(75, 178);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(26, 26);
            this.btnRefresh.TabIndex = 53;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnAddNewTask
            // 
            this.btnAddNewTask.AutoSize = true;
            this.btnAddNewTask.FlatAppearance.BorderSize = 0;
            this.btnAddNewTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddNewTask.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewTask.Image")));
            this.btnAddNewTask.Location = new System.Drawing.Point(11, 178);
            this.btnAddNewTask.Margin = new System.Windows.Forms.Padding(11, 6, 3, 0);
            this.btnAddNewTask.Name = "btnAddNewTask";
            this.btnAddNewTask.Size = new System.Drawing.Size(26, 26);
            this.btnAddNewTask.TabIndex = 53;
            this.btnAddNewTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewTask.UseVisualStyleBackColor = true;
            // 
            // txbStartTime
            // 
            this.txbStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartTime.BackColor = System.Drawing.SystemColors.Window;
            this.txbStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txbStartTime.Location = new System.Drawing.Point(190, 28);
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(15, 15, 15, 3);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.Size = new System.Drawing.Size(481, 20);
            this.txbStartTime.TabIndex = 44;
            this.txbStartTime.Tag = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.Location = new System.Drawing.Point(8, 31);
            this.label9.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Время начала, сек";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbStopTime
            // 
            this.txbStopTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStopTime.BackColor = System.Drawing.SystemColors.Window;
            this.txbStopTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txbStopTime.Location = new System.Drawing.Point(190, 54);
            this.txbStopTime.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txbStopTime.Name = "txbStopTime";
            this.txbStopTime.Size = new System.Drawing.Size(481, 20);
            this.txbStopTime.TabIndex = 40;
            this.txbStopTime.Tag = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.Location = new System.Drawing.Point(8, 57);
            this.label10.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Время окончания, сек";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grbTaskKind
            // 
            this.grbTaskKind.Controls.Add(this.chbFurtherComp);
            this.grbTaskKind.Controls.Add(this.cmbHardnessTask);
            this.grbTaskKind.Controls.Add(this.lblMechTask);
            this.grbTaskKind.Controls.Add(this.lblHardness);
            this.grbTaskKind.Controls.Add(this.lblTermoTask);
            this.grbTaskKind.Controls.Add(this.lblChemicalTask);
            this.grbTaskKind.Controls.Add(this.chbMechTask);
            this.grbTaskKind.Controls.Add(this.chbTermoTask);
            this.grbTaskKind.Controls.Add(this.chbChemicalTask);
            this.grbTaskKind.Controls.Add(this.chbLinkedCalc);
            this.grbTaskKind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTaskKind.Location = new System.Drawing.Point(7, 7);
            this.grbTaskKind.Margin = new System.Windows.Forms.Padding(7);
            this.grbTaskKind.Name = "grbTaskKind";
            this.grbTaskKind.Size = new System.Drawing.Size(686, 94);
            this.grbTaskKind.TabIndex = 12;
            this.grbTaskKind.TabStop = false;
            this.grbTaskKind.Text = "Вид задачи";
            // 
            // chbFurtherComp
            // 
            this.chbFurtherComp.AutoSize = true;
            this.chbFurtherComp.Location = new System.Drawing.Point(310, 51);
            this.chbFurtherComp.Name = "chbFurtherComp";
            this.chbFurtherComp.Size = new System.Drawing.Size(126, 17);
            this.chbFurtherComp.TabIndex = 87;
            this.chbFurtherComp.Text = "Продолжить расчет";
            this.chbFurtherComp.UseVisualStyleBackColor = true;
            // 
            // cmbHardnessTask
            // 
            this.cmbHardnessTask.AutoSize = true;
            this.cmbHardnessTask.BackColor = System.Drawing.Color.Transparent;
            this.cmbHardnessTask.Enabled = false;
            this.cmbHardnessTask.Location = new System.Drawing.Point(11, 52);
            this.cmbHardnessTask.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.cmbHardnessTask.Name = "cmbHardnessTask";
            this.cmbHardnessTask.Size = new System.Drawing.Size(15, 14);
            this.cmbHardnessTask.TabIndex = 86;
            this.cmbHardnessTask.Tag = "1";
            this.cmbHardnessTask.UseVisualStyleBackColor = false;
            // 
            // lblMechTask
            // 
            this.lblMechTask.AutoSize = true;
            this.lblMechTask.Location = new System.Drawing.Point(224, 27);
            this.lblMechTask.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblMechTask.Name = "lblMechTask";
            this.lblMechTask.Size = new System.Drawing.Size(80, 13);
            this.lblMechTask.TabIndex = 85;
            this.lblMechTask.Text = "Механическая";
            this.lblMechTask.Click += new System.EventHandler(this.LblMechTask_Click);
            // 
            // lblHardness
            // 
            this.lblHardness.AutoSize = true;
            this.lblHardness.Enabled = false;
            this.lblHardness.Location = new System.Drawing.Point(28, 52);
            this.lblHardness.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblHardness.Name = "lblHardness";
            this.lblHardness.Size = new System.Drawing.Size(61, 13);
            this.lblHardness.TabIndex = 83;
            this.lblHardness.Text = "Твердость";
            // 
            // lblTermoTask
            // 
            this.lblTermoTask.AutoSize = true;
            this.lblTermoTask.Location = new System.Drawing.Point(126, 27);
            this.lblTermoTask.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblTermoTask.Name = "lblTermoTask";
            this.lblTermoTask.Size = new System.Drawing.Size(75, 13);
            this.lblTermoTask.TabIndex = 84;
            this.lblTermoTask.Text = "Термическая";
            this.lblTermoTask.Click += new System.EventHandler(this.LblTermoTask_Click);
            // 
            // lblChemicalTask
            // 
            this.lblChemicalTask.AutoSize = true;
            this.lblChemicalTask.Enabled = false;
            this.lblChemicalTask.Location = new System.Drawing.Point(28, 27);
            this.lblChemicalTask.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblChemicalTask.Name = "lblChemicalTask";
            this.lblChemicalTask.Size = new System.Drawing.Size(77, 13);
            this.lblChemicalTask.TabIndex = 82;
            this.lblChemicalTask.Text = "Химмическая";
            this.lblChemicalTask.Click += new System.EventHandler(this.LblChemicalTask_Click);
            // 
            // chbMechTask
            // 
            this.chbMechTask.AutoSize = true;
            this.chbMechTask.BackColor = System.Drawing.Color.Transparent;
            this.chbMechTask.Location = new System.Drawing.Point(207, 27);
            this.chbMechTask.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.chbMechTask.Name = "chbMechTask";
            this.chbMechTask.Size = new System.Drawing.Size(15, 14);
            this.chbMechTask.TabIndex = 78;
            this.chbMechTask.Tag = "2";
            this.chbMechTask.UseVisualStyleBackColor = false;
            // 
            // chbTermoTask
            // 
            this.chbTermoTask.AutoSize = true;
            this.chbTermoTask.BackColor = System.Drawing.Color.Transparent;
            this.chbTermoTask.Location = new System.Drawing.Point(109, 27);
            this.chbTermoTask.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.chbTermoTask.Name = "chbTermoTask";
            this.chbTermoTask.Size = new System.Drawing.Size(15, 14);
            this.chbTermoTask.TabIndex = 79;
            this.chbTermoTask.Tag = "1";
            this.chbTermoTask.UseVisualStyleBackColor = false;
            // 
            // chbChemicalTask
            // 
            this.chbChemicalTask.AutoSize = true;
            this.chbChemicalTask.BackColor = System.Drawing.Color.Transparent;
            this.chbChemicalTask.Enabled = false;
            this.chbChemicalTask.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chbChemicalTask.Location = new System.Drawing.Point(11, 27);
            this.chbChemicalTask.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.chbChemicalTask.Name = "chbChemicalTask";
            this.chbChemicalTask.Size = new System.Drawing.Size(15, 14);
            this.chbChemicalTask.TabIndex = 80;
            this.chbChemicalTask.Tag = "0";
            this.chbChemicalTask.UseVisualStyleBackColor = false;
            // 
            // chbLinkedCalc
            // 
            this.chbLinkedCalc.AutoSize = true;
            this.chbLinkedCalc.BackColor = System.Drawing.Color.Transparent;
            this.chbLinkedCalc.Location = new System.Drawing.Point(310, 27);
            this.chbLinkedCalc.Name = "chbLinkedCalc";
            this.chbLinkedCalc.Size = new System.Drawing.Size(128, 17);
            this.chbLinkedCalc.TabIndex = 81;
            this.chbLinkedCalc.Text = "Связанное решение";
            this.chbLinkedCalc.UseVisualStyleBackColor = false;
            // 
            // grbTaskSettings
            // 
            this.grbTaskSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTaskSettings.Location = new System.Drawing.Point(7, 115);
            this.grbTaskSettings.Margin = new System.Windows.Forms.Padding(7);
            this.grbTaskSettings.MinimumSize = new System.Drawing.Size(0, 15);
            this.grbTaskSettings.Name = "grbTaskSettings";
            this.grbTaskSettings.Size = new System.Drawing.Size(686, 15);
            this.grbTaskSettings.TabIndex = 13;
            this.grbTaskSettings.TabStop = false;
            this.grbTaskSettings.Text = "Настройки расчета";
            // 
            // TaskPlannerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TaskPlannerControl";
            this.Size = new System.Drawing.Size(700, 727);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbTaskKind.ResumeLayout(false);
            this.grbTaskKind.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button PrevResultLoadBtn;
        private System.Windows.Forms.Button btnLoadParameters;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.TextBox txbStartStep;
        private System.Windows.Forms.Button btnGenTCF;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbMaxStep;
        private System.Windows.Forms.TextBox txbMinStep;
        private System.Windows.Forms.CheckBox chbAddByTaskConditions;
        private System.Windows.Forms.Button btnClearAllTask;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAddNewTask;
        private System.Windows.Forms.TextBox txbStartTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbStopTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Settings;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Time;
        private System.Windows.Forms.GroupBox grbTaskKind;
        private System.Windows.Forms.CheckBox chbFurtherComp;
        private System.Windows.Forms.CheckBox cmbHardnessTask;
        private System.Windows.Forms.Label lblMechTask;
        private System.Windows.Forms.Label lblHardness;
        private System.Windows.Forms.Label lblTermoTask;
        private System.Windows.Forms.Label lblChemicalTask;
        private System.Windows.Forms.CheckBox chbMechTask;
        private System.Windows.Forms.CheckBox chbTermoTask;
        private System.Windows.Forms.CheckBox chbChemicalTask;
        private System.Windows.Forms.CheckBox chbLinkedCalc;
        private GroupBoxEx grbTaskSettings;
    }
}
