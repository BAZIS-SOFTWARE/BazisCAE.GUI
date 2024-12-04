using UserControlsEx;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskPlannerControl_v2));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView = new UserControlsEx.DataGridViewEx(this.components);
            this.Kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Settings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddNewTask = new System.Windows.Forms.Button();
            this.PrevResultLoadBtn = new System.Windows.Forms.Button();
            this.btnLoadParameters = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.txbStartStep = new UserControlsEx.TextBoxEx(this.components);
            this.btnGenTCF = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbMaxStep = new UserControlsEx.TextBoxEx(this.components);
            this.txbMinStep = new UserControlsEx.TextBoxEx(this.components);
            this.chbAddByTaskConditions = new System.Windows.Forms.CheckBox();
            this.btnClearAllTask = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txbStartTime = new UserControlsEx.TextBoxEx(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txbStopTime = new UserControlsEx.TextBoxEx(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.grbTaskKind = new System.Windows.Forms.GroupBox();
            this.chbFurtherComp = new System.Windows.Forms.CheckBox();
            this.rbtHardnessTask = new System.Windows.Forms.RadioButton();
            this.rbtMechTask = new System.Windows.Forms.RadioButton();
            this.rbtTermoTask = new System.Windows.Forms.RadioButton();
            this.rbtChemicalTask = new System.Windows.Forms.RadioButton();
            this.rbtTermoMechTask = new System.Windows.Forms.RadioButton();
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
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grbTaskKind, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
            this.dataGridView.Location = new System.Drawing.Point(7, 348);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(7);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(686, 372);
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
            this.groupBox1.Controls.Add(this.btnAddNewTask);
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
            this.groupBox1.Controls.Add(this.txbStartTime);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txbStopTime);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(7, 115);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(686, 219);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Временные параметры";
            // 
            // btnAddNewTask
            // 
            this.btnAddNewTask.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddNewTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddNewTask.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewTask.Image")));
            this.btnAddNewTask.Location = new System.Drawing.Point(11, 178);
            this.btnAddNewTask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.btnAddNewTask.Name = "btnAddNewTask";
            this.btnAddNewTask.Size = new System.Drawing.Size(27, 27);
            this.btnAddNewTask.TabIndex = 132;
            this.btnAddNewTask.Text = "  a_p";
            this.btnAddNewTask.UseVisualStyleBackColor = true;
            this.btnAddNewTask.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // PrevResultLoadBtn
            // 
            this.PrevResultLoadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PrevResultLoadBtn.AutoSize = true;
            this.PrevResultLoadBtn.Enabled = false;
            this.PrevResultLoadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrevResultLoadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.PrevResultLoadBtn.Location = new System.Drawing.Point(259, 178);
            this.PrevResultLoadBtn.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.PrevResultLoadBtn.Name = "PrevResultLoadBtn";
            this.PrevResultLoadBtn.Size = new System.Drawing.Size(160, 27);
            this.PrevResultLoadBtn.TabIndex = 131;
            this.PrevResultLoadBtn.Text = "Предыдущие условия";
            this.PrevResultLoadBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PrevResultLoadBtn.UseVisualStyleBackColor = true;
            this.PrevResultLoadBtn.Click += new System.EventHandler(this.PrevResultLoadButton_Click);
            // 
            // btnLoadParameters
            // 
            this.btnLoadParameters.AutoSize = true;
            this.btnLoadParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnLoadParameters.Image = global::BaseModule.Properties.Resources.OpenDB;
            this.btnLoadParameters.Location = new System.Drawing.Point(110, 178);
            this.btnLoadParameters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.btnLoadParameters.Name = "btnLoadParameters";
            this.btnLoadParameters.Size = new System.Drawing.Size(27, 27);
            this.btnLoadParameters.TabIndex = 129;
            this.btnLoadParameters.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadParameters.UseVisualStyleBackColor = true;
            this.btnLoadParameters.Click += new System.EventHandler(this.btnLoadParameters_Click);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StopButton.AutoSize = true;
            this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.StopButton.Location = new System.Drawing.Point(599, 178);
            this.StopButton.Margin = new System.Windows.Forms.Padding(3, 1, 15, 1);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(67, 27);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Стоп";
            this.StopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // txbStartStep
            // 
            this.txbStartStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartStep.BackColor = System.Drawing.SystemColors.Window;
            this.txbStartStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbStartStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txbStartStep.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbStartStep.IsValidating = true;
            this.txbStartStep.Location = new System.Drawing.Point(190, 80);
            this.txbStartStep.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txbStartStep.Name = "txbStartStep";
            this.txbStartStep.Size = new System.Drawing.Size(476, 20);
            this.txbStartStep.TabIndex = 76;
            this.txbStartStep.Tag = "2";
            this.txbStartStep.Text = "0.1";
            this.txbStartStep.UserRegExCheck = null;
            this.txbStartStep.UserRegExCheckErrorMessage = null;
            // 
            // btnGenTCF
            // 
            this.btnGenTCF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenTCF.AutoSize = true;
            this.btnGenTCF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenTCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnGenTCF.Location = new System.Drawing.Point(425, 178);
            this.btnGenTCF.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnGenTCF.Name = "btnGenTCF";
            this.btnGenTCF.Size = new System.Drawing.Size(96, 27);
            this.btnGenTCF.TabIndex = 2;
            this.btnGenTCF.Text = "Создать *.tcf";
            this.btnGenTCF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenTCF.UseVisualStyleBackColor = true;
            this.btnGenTCF.Click += new System.EventHandler(this.btnGenTCF_Click);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.AutoSize = true;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.StartButton.Location = new System.Drawing.Point(527, 178);
            this.StartButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(66, 27);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Старт";
            this.StartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
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
            this.txbMaxStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbMaxStep.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbMaxStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txbMaxStep.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbMaxStep.IsValidating = true;
            this.txbMaxStep.Location = new System.Drawing.Point(190, 132);
            this.txbMaxStep.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txbMaxStep.Name = "txbMaxStep";
            this.txbMaxStep.Size = new System.Drawing.Size(476, 20);
            this.txbMaxStep.TabIndex = 74;
            this.txbMaxStep.Tag = "4";
            this.txbMaxStep.Text = "100";
            this.txbMaxStep.UserRegExCheck = null;
            this.txbMaxStep.UserRegExCheckErrorMessage = null;
            // 
            // txbMinStep
            // 
            this.txbMinStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMinStep.BackColor = System.Drawing.SystemColors.Window;
            this.txbMinStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbMinStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txbMinStep.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbMinStep.IsValidating = true;
            this.txbMinStep.Location = new System.Drawing.Point(190, 106);
            this.txbMinStep.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txbMinStep.Name = "txbMinStep";
            this.txbMinStep.Size = new System.Drawing.Size(476, 20);
            this.txbMinStep.TabIndex = 75;
            this.txbMinStep.Tag = "3";
            this.txbMinStep.Text = "0.00001";
            this.txbMinStep.UserRegExCheck = null;
            this.txbMinStep.UserRegExCheckErrorMessage = null;
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
            this.btnClearAllTask.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearAllTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAllTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClearAllTask.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAllTask.Image")));
            this.btnClearAllTask.Location = new System.Drawing.Point(44, 178);
            this.btnClearAllTask.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.btnClearAllTask.Name = "btnClearAllTask";
            this.btnClearAllTask.Size = new System.Drawing.Size(27, 27);
            this.btnClearAllTask.TabIndex = 53;
            this.btnClearAllTask.Text = "  d_p";
            this.btnClearAllTask.UseVisualStyleBackColor = true;
            this.btnClearAllTask.Click += new System.EventHandler(this.ClearAllDataButton_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(77, 178);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(27, 27);
            this.btnRefresh.TabIndex = 53;
            this.btnRefresh.Text = "  r_p";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // txbStartTime
            // 
            this.txbStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartTime.BackColor = System.Drawing.SystemColors.Window;
            this.txbStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txbStartTime.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbStartTime.IsValidating = true;
            this.txbStartTime.Location = new System.Drawing.Point(190, 28);
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(15, 15, 20, 3);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.Size = new System.Drawing.Size(476, 20);
            this.txbStartTime.TabIndex = 44;
            this.txbStartTime.Tag = "0";
            this.txbStartTime.UserRegExCheck = null;
            this.txbStartTime.UserRegExCheckErrorMessage = null;
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
            this.txbStopTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbStopTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txbStopTime.InputType = ((UserControlsEx.TXTBoxInputType)((UserControlsEx.TXTBoxInputType.Float | UserControlsEx.TXTBoxInputType.Positive)));
            this.txbStopTime.IsValidating = true;
            this.txbStopTime.Location = new System.Drawing.Point(190, 54);
            this.txbStopTime.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txbStopTime.Name = "txbStopTime";
            this.txbStopTime.Size = new System.Drawing.Size(476, 20);
            this.txbStopTime.TabIndex = 40;
            this.txbStopTime.Tag = "1";
            this.txbStopTime.UserRegExCheck = null;
            this.txbStopTime.UserRegExCheckErrorMessage = null;
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
            this.grbTaskKind.Controls.Add(this.rbtHardnessTask);
            this.grbTaskKind.Controls.Add(this.rbtMechTask);
            this.grbTaskKind.Controls.Add(this.rbtTermoTask);
            this.grbTaskKind.Controls.Add(this.rbtChemicalTask);
            this.grbTaskKind.Controls.Add(this.rbtTermoMechTask);
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
            this.chbFurtherComp.Location = new System.Drawing.Point(11, 50);
            this.chbFurtherComp.Name = "chbFurtherComp";
            this.chbFurtherComp.Size = new System.Drawing.Size(126, 17);
            this.chbFurtherComp.TabIndex = 87;
            this.chbFurtherComp.Text = "Продолжить расчет";
            this.chbFurtherComp.UseVisualStyleBackColor = true;
            // 
            // rbtHardnessTask
            // 
            this.rbtHardnessTask.AutoSize = true;
            this.rbtHardnessTask.BackColor = System.Drawing.Color.Transparent;
            this.rbtHardnessTask.Enabled = false;
            this.rbtHardnessTask.Location = new System.Drawing.Point(441, 27);
            this.rbtHardnessTask.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.rbtHardnessTask.Name = "rbtHardnessTask";
            this.rbtHardnessTask.Size = new System.Drawing.Size(79, 17);
            this.rbtHardnessTask.TabIndex = 86;
            this.rbtHardnessTask.Tag = "1";
            this.rbtHardnessTask.Text = "Твердость";
            this.rbtHardnessTask.UseVisualStyleBackColor = false;
            // 
            // rbtMechTask
            // 
            this.rbtMechTask.AutoSize = true;
            this.rbtMechTask.BackColor = System.Drawing.Color.Transparent;
            this.rbtMechTask.Location = new System.Drawing.Point(207, 27);
            this.rbtMechTask.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.rbtMechTask.Name = "rbtMechTask";
            this.rbtMechTask.Size = new System.Drawing.Size(98, 17);
            this.rbtMechTask.TabIndex = 78;
            this.rbtMechTask.Tag = "2";
            this.rbtMechTask.Text = "Механическая";
            this.rbtMechTask.UseVisualStyleBackColor = false;
            // 
            // rbtTermoTask
            // 
            this.rbtTermoTask.AutoSize = true;
            this.rbtTermoTask.BackColor = System.Drawing.Color.Transparent;
            this.rbtTermoTask.Checked = true;
            this.rbtTermoTask.Location = new System.Drawing.Point(109, 27);
            this.rbtTermoTask.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.rbtTermoTask.Name = "rbtTermoTask";
            this.rbtTermoTask.Size = new System.Drawing.Size(93, 17);
            this.rbtTermoTask.TabIndex = 79;
            this.rbtTermoTask.TabStop = true;
            this.rbtTermoTask.Tag = "1";
            this.rbtTermoTask.Text = "Термическая";
            this.rbtTermoTask.UseVisualStyleBackColor = false;
            // 
            // rbtChemicalTask
            // 
            this.rbtChemicalTask.AutoSize = true;
            this.rbtChemicalTask.BackColor = System.Drawing.Color.Transparent;
            this.rbtChemicalTask.Enabled = false;
            this.rbtChemicalTask.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtChemicalTask.Location = new System.Drawing.Point(11, 27);
            this.rbtChemicalTask.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.rbtChemicalTask.Name = "rbtChemicalTask";
            this.rbtChemicalTask.Size = new System.Drawing.Size(95, 17);
            this.rbtChemicalTask.TabIndex = 80;
            this.rbtChemicalTask.Tag = "0";
            this.rbtChemicalTask.Text = "Химмическая";
            this.rbtChemicalTask.UseVisualStyleBackColor = false;
            // 
            // rbtTermoMechTask
            // 
            this.rbtTermoMechTask.AutoSize = true;
            this.rbtTermoMechTask.BackColor = System.Drawing.Color.Transparent;
            this.rbtTermoMechTask.Location = new System.Drawing.Point(310, 27);
            this.rbtTermoMechTask.Name = "rbtTermoMechTask";
            this.rbtTermoMechTask.Size = new System.Drawing.Size(130, 17);
            this.rbtTermoMechTask.TabIndex = 81;
            this.rbtTermoMechTask.Text = "Термомеханическая";
            this.rbtTermoMechTask.UseVisualStyleBackColor = false;
            // 
            // TaskPlannerControl_v2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TaskPlannerControl_v2";
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
        private TextBoxEx txbStartStep;
        private System.Windows.Forms.Button btnGenTCF;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private TextBoxEx txbMaxStep;
        private TextBoxEx txbMinStep;
        private System.Windows.Forms.CheckBox chbAddByTaskConditions;
        private System.Windows.Forms.Button btnClearAllTask;
        private System.Windows.Forms.Button btnRefresh;
        private TextBoxEx txbStartTime;
        private System.Windows.Forms.Label label9;
        private TextBoxEx txbStopTime;
        private System.Windows.Forms.Label label10;
        private DataGridViewEx dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Settings;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Time;
        private System.Windows.Forms.GroupBox grbTaskKind;
        private System.Windows.Forms.CheckBox chbFurtherComp;
        private System.Windows.Forms.RadioButton rbtHardnessTask;
        private System.Windows.Forms.RadioButton rbtMechTask;
        private System.Windows.Forms.RadioButton rbtTermoTask;
        private System.Windows.Forms.RadioButton rbtChemicalTask;
        private System.Windows.Forms.RadioButton rbtTermoMechTask;
        private System.Windows.Forms.Button btnAddNewTask;
    }
}
