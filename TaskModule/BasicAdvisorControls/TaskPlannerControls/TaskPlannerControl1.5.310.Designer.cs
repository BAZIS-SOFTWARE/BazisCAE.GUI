using System;

namespace TaskModule.BasicAdvisorControls.TaskPlannerControls
{
    partial class TaskPlannerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskPlannerControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblFileParameters = new System.Windows.Forms.Label();
            this.btnLoadParameters = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.txbStartStep = new System.Windows.Forms.TextBox();
            this.btnGenTCF = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbMaxStep = new System.Windows.Forms.TextBox();
            this.txbMinStep = new System.Windows.Forms.TextBox();
            this.chbAddByTaskConditions = new System.Windows.Forms.CheckBox();
            this.btnClearAllTask = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAddNewTask = new System.Windows.Forms.Button();
            this.txbStartTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbStopTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.grbTaskSettings = new System.Windows.Forms.GroupBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Settings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.grbTaskSettings, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 847);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.lblFileParameters);
            this.groupBox2.Controls.Add(this.btnLoadParameters);
            this.groupBox2.Controls.Add(this.StopButton);
            this.groupBox2.Controls.Add(this.txbStartStep);
            this.groupBox2.Controls.Add(this.btnGenTCF);
            this.groupBox2.Controls.Add(this.StartButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txbMaxStep);
            this.groupBox2.Controls.Add(this.txbMinStep);
            this.groupBox2.Controls.Add(this.chbAddByTaskConditions);
            this.groupBox2.Controls.Add(this.btnClearAllTask);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.btnAddNewTask);
            this.groupBox2.Controls.Add(this.txbStartTime);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txbStopTime);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(1, 107);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.groupBox2.MinimumSize = new System.Drawing.Size(300, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox2.Size = new System.Drawing.Size(598, 218);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Временные параметры";
            // 
            // lblFileParameters
            // 
            this.lblFileParameters.AutoSize = true;
            this.lblFileParameters.Location = new System.Drawing.Point(140, 184);
            this.lblFileParameters.Margin = new System.Windows.Forms.Padding(5, 8, 2, 8);
            this.lblFileParameters.Name = "lblFileParameters";
            this.lblFileParameters.Size = new System.Drawing.Size(200, 13);
            this.lblFileParameters.TabIndex = 130;
            this.lblFileParameters.Text = "Выберите директорию с *.tsf файлами";
            this.lblFileParameters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLoadParameters
            // 
            this.btnLoadParameters.AutoSize = true;
            this.btnLoadParameters.Image = global::TaskModule.Properties.Resources.ComputationFolder;
            this.btnLoadParameters.Location = new System.Drawing.Point(107, 177);
            this.btnLoadParameters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.btnLoadParameters.Name = "btnLoadParameters";
            this.btnLoadParameters.Size = new System.Drawing.Size(26, 26);
            this.btnLoadParameters.TabIndex = 129;
            this.btnLoadParameters.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadParameters.UseVisualStyleBackColor = true;
            this.btnLoadParameters.Click += new System.EventHandler(this.btnLoadParameters_Click);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StopButton.AutoSize = true;
            this.StopButton.Location = new System.Drawing.Point(506, 175);
            this.StopButton.Margin = new System.Windows.Forms.Padding(1);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(67, 28);
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
            this.txbStartStep.Location = new System.Drawing.Point(208, 72);
            this.txbStartStep.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbStartStep.Name = "txbStartStep";
            this.txbStartStep.Size = new System.Drawing.Size(365, 20);
            this.txbStartStep.TabIndex = 76;
            this.txbStartStep.Tag = "2";
            this.txbStartStep.Text = "0.1";
            this.txbStartStep.Leave += new System.EventHandler(this.TimeSettingsTextBox_Leave);
            // 
            // btnGenTCF
            // 
            this.btnGenTCF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenTCF.AutoSize = true;
            this.btnGenTCF.Location = new System.Drawing.Point(355, 175);
            this.btnGenTCF.Margin = new System.Windows.Forms.Padding(1);
            this.btnGenTCF.Name = "btnGenTCF";
            this.btnGenTCF.Size = new System.Drawing.Size(81, 28);
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
            this.StartButton.Location = new System.Drawing.Point(438, 175);
            this.StartButton.Margin = new System.Windows.Forms.Padding(1);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(66, 28);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Старт";
            this.StartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "Начальный шаг расчета, сек";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 126);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Максимальный шаг расчета, сек";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.UseWaitCursor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 101);
            this.label8.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 13);
            this.label8.TabIndex = 72;
            this.label8.Text = "Минимальный шаг расчета, сек";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.UseWaitCursor = true;
            // 
            // txbMaxStep
            // 
            this.txbMaxStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMaxStep.BackColor = System.Drawing.SystemColors.Window;
            this.txbMaxStep.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbMaxStep.Location = new System.Drawing.Point(208, 123);
            this.txbMaxStep.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbMaxStep.Name = "txbMaxStep";
            this.txbMaxStep.Size = new System.Drawing.Size(365, 20);
            this.txbMaxStep.TabIndex = 74;
            this.txbMaxStep.Tag = "4";
            this.txbMaxStep.Text = "100";
            this.txbMaxStep.Leave += new System.EventHandler(this.TimeSettingsTextBox_Leave);
            // 
            // txbMinStep
            // 
            this.txbMinStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMinStep.BackColor = System.Drawing.SystemColors.Window;
            this.txbMinStep.Location = new System.Drawing.Point(208, 98);
            this.txbMinStep.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbMinStep.Name = "txbMinStep";
            this.txbMinStep.Size = new System.Drawing.Size(365, 20);
            this.txbMinStep.TabIndex = 75;
            this.txbMinStep.Tag = "3";
            this.txbMinStep.Text = "0.00001";
            this.txbMinStep.Leave += new System.EventHandler(this.TimeSettingsTextBox_Leave);
            // 
            // chbAddByTaskConditions
            // 
            this.chbAddByTaskConditions.AutoSize = true;
            this.chbAddByTaskConditions.Location = new System.Drawing.Point(12, 152);
            this.chbAddByTaskConditions.Name = "chbAddByTaskConditions";
            this.chbAddByTaskConditions.Size = new System.Drawing.Size(181, 17);
            this.chbAddByTaskConditions.TabIndex = 54;
            this.chbAddByTaskConditions.Text = "Добавить по условиям задачи";
            this.chbAddByTaskConditions.UseVisualStyleBackColor = true;
            // 
            // btnClearAllTask
            // 
            this.btnClearAllTask.AutoSize = true;
            this.btnClearAllTask.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAllTask.Image")));
            this.btnClearAllTask.Location = new System.Drawing.Point(44, 177);
            this.btnClearAllTask.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.btnClearAllTask.Name = "btnClearAllTask";
            this.btnClearAllTask.Size = new System.Drawing.Size(26, 26);
            this.btnClearAllTask.TabIndex = 53;
            this.btnClearAllTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearAllTask.UseVisualStyleBackColor = true;
            this.btnClearAllTask.Click += new System.EventHandler(this.ClearAllDataButton_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(76, 177);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(26, 26);
            this.btnRefresh.TabIndex = 53;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // btnAddNewTask
            // 
            this.btnAddNewTask.AutoSize = true;
            this.btnAddNewTask.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewTask.Image")));
            this.btnAddNewTask.Location = new System.Drawing.Point(12, 177);
            this.btnAddNewTask.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.btnAddNewTask.Name = "btnAddNewTask";
            this.btnAddNewTask.Size = new System.Drawing.Size(26, 26);
            this.btnAddNewTask.TabIndex = 53;
            this.btnAddNewTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewTask.UseVisualStyleBackColor = true;
            this.btnAddNewTask.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // txbStartTime
            // 
            this.txbStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartTime.BackColor = System.Drawing.SystemColors.Window;
            this.txbStartTime.Location = new System.Drawing.Point(208, 20);
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.Size = new System.Drawing.Size(365, 20);
            this.txbStartTime.TabIndex = 44;
            this.txbStartTime.Tag = "0";
            this.txbStartTime.Leave += new System.EventHandler(this.TimeSettingsTextBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 10, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Время начала, сек";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbStopTime
            // 
            this.txbStopTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStopTime.BackColor = System.Drawing.SystemColors.Window;
            this.txbStopTime.Location = new System.Drawing.Point(208, 46);
            this.txbStopTime.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbStopTime.Name = "txbStopTime";
            this.txbStopTime.Size = new System.Drawing.Size(365, 20);
            this.txbStopTime.TabIndex = 40;
            this.txbStopTime.Tag = "1";
            this.txbStopTime.Leave += new System.EventHandler(this.TimeSettingsTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Время окончания, сек";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.chbFurtherComp);
            this.groupBox3.Controls.Add(this.cmbHardnessTask);
            this.groupBox3.Controls.Add(this.lblMechTask);
            this.groupBox3.Controls.Add(this.lblHardness);
            this.groupBox3.Controls.Add(this.lblTermoTask);
            this.groupBox3.Controls.Add(this.lblChemicalTask);
            this.groupBox3.Controls.Add(this.chbMechTask);
            this.groupBox3.Controls.Add(this.chbTermoTask);
            this.groupBox3.Controls.Add(this.chbChemicalTask);
            this.groupBox3.Controls.Add(this.chbLinkedCalc);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(1, 1);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(598, 87);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Выбор задачи";
            // 
            // chbFurtherComp
            // 
            this.chbFurtherComp.AutoSize = true;
            this.chbFurtherComp.Location = new System.Drawing.Point(311, 54);
            this.chbFurtherComp.Name = "chbFurtherComp";
            this.chbFurtherComp.Size = new System.Drawing.Size(126, 17);
            this.chbFurtherComp.TabIndex = 77;
            this.chbFurtherComp.Text = "Продолжить расчет";
            this.chbFurtherComp.UseVisualStyleBackColor = true;
            // 
            // cmbHardnessTask
            // 
            this.cmbHardnessTask.AutoSize = true;
            this.cmbHardnessTask.BackColor = System.Drawing.Color.Transparent;
            this.cmbHardnessTask.Enabled = false;
            this.cmbHardnessTask.Location = new System.Drawing.Point(12, 55);
            this.cmbHardnessTask.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.cmbHardnessTask.Name = "cmbHardnessTask";
            this.cmbHardnessTask.Size = new System.Drawing.Size(15, 14);
            this.cmbHardnessTask.TabIndex = 75;
            this.cmbHardnessTask.Tag = "1";
            this.cmbHardnessTask.UseVisualStyleBackColor = false;
            // 
            // lblMechTask
            // 
            this.lblMechTask.AutoSize = true;
            this.lblMechTask.Location = new System.Drawing.Point(225, 30);
            this.lblMechTask.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblMechTask.Name = "lblMechTask";
            this.lblMechTask.Size = new System.Drawing.Size(80, 13);
            this.lblMechTask.TabIndex = 7;
            this.lblMechTask.Text = "Механическая";
            this.lblMechTask.Click += new System.EventHandler(this.LblMechTask_Click);
            // 
            // lblHardness
            // 
            this.lblHardness.AutoSize = true;
            this.lblHardness.Enabled = false;
            this.lblHardness.Location = new System.Drawing.Point(29, 55);
            this.lblHardness.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblHardness.Name = "lblHardness";
            this.lblHardness.Size = new System.Drawing.Size(61, 13);
            this.lblHardness.TabIndex = 6;
            this.lblHardness.Text = "Твердость";
            this.lblHardness.Click += new System.EventHandler(this.LblTermoTask_Click);
            // 
            // lblTermoTask
            // 
            this.lblTermoTask.AutoSize = true;
            this.lblTermoTask.Location = new System.Drawing.Point(127, 30);
            this.lblTermoTask.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblTermoTask.Name = "lblTermoTask";
            this.lblTermoTask.Size = new System.Drawing.Size(75, 13);
            this.lblTermoTask.TabIndex = 6;
            this.lblTermoTask.Text = "Термическая";
            this.lblTermoTask.Click += new System.EventHandler(this.LblTermoTask_Click);
            // 
            // lblChemicalTask
            // 
            this.lblChemicalTask.AutoSize = true;
            this.lblChemicalTask.Enabled = false;
            this.lblChemicalTask.Location = new System.Drawing.Point(29, 30);
            this.lblChemicalTask.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblChemicalTask.Name = "lblChemicalTask";
            this.lblChemicalTask.Size = new System.Drawing.Size(77, 13);
            this.lblChemicalTask.TabIndex = 5;
            this.lblChemicalTask.Text = "Химмическая";
            this.lblChemicalTask.Click += new System.EventHandler(this.LblChemicalTask_Click);
            // 
            // chbMechTask
            // 
            this.chbMechTask.AutoSize = true;
            this.chbMechTask.BackColor = System.Drawing.Color.Transparent;
            this.chbMechTask.Location = new System.Drawing.Point(208, 30);
            this.chbMechTask.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.chbMechTask.Name = "chbMechTask";
            this.chbMechTask.Size = new System.Drawing.Size(15, 14);
            this.chbMechTask.TabIndex = 4;
            this.chbMechTask.Tag = "2";
            this.chbMechTask.UseVisualStyleBackColor = false;
            this.chbMechTask.CheckedChanged += new System.EventHandler(this.chbTaskKind_CheckedChange);
            // 
            // chbTermoTask
            // 
            this.chbTermoTask.AutoSize = true;
            this.chbTermoTask.BackColor = System.Drawing.Color.Transparent;
            this.chbTermoTask.Location = new System.Drawing.Point(110, 30);
            this.chbTermoTask.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.chbTermoTask.Name = "chbTermoTask";
            this.chbTermoTask.Size = new System.Drawing.Size(15, 14);
            this.chbTermoTask.TabIndex = 4;
            this.chbTermoTask.Tag = "1";
            this.chbTermoTask.UseVisualStyleBackColor = false;
            this.chbTermoTask.CheckedChanged += new System.EventHandler(this.chbTaskKind_CheckedChange);
            // 
            // chbChemicalTask
            // 
            this.chbChemicalTask.AutoSize = true;
            this.chbChemicalTask.BackColor = System.Drawing.Color.Transparent;
            this.chbChemicalTask.Enabled = false;
            this.chbChemicalTask.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chbChemicalTask.Location = new System.Drawing.Point(12, 30);
            this.chbChemicalTask.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.chbChemicalTask.Name = "chbChemicalTask";
            this.chbChemicalTask.Size = new System.Drawing.Size(15, 14);
            this.chbChemicalTask.TabIndex = 4;
            this.chbChemicalTask.Tag = "0";
            this.chbChemicalTask.UseVisualStyleBackColor = false;
            this.chbChemicalTask.CheckedChanged += new System.EventHandler(this.chbTaskKind_CheckedChange);
            // 
            // chbLinkedCalc
            // 
            this.chbLinkedCalc.AutoSize = true;
            this.chbLinkedCalc.BackColor = System.Drawing.Color.Transparent;
            this.chbLinkedCalc.Location = new System.Drawing.Point(311, 30);
            this.chbLinkedCalc.Name = "chbLinkedCalc";
            this.chbLinkedCalc.Size = new System.Drawing.Size(128, 17);
            this.chbLinkedCalc.TabIndex = 4;
            this.chbLinkedCalc.Text = "Связанное решение";
            this.chbLinkedCalc.UseVisualStyleBackColor = false;
            this.chbLinkedCalc.CheckedChanged += new System.EventHandler(this.chbLinkedCalc_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(1, 326);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 520);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список задач";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Kind,
            this.Settings,
            this.Time});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 16);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Size = new System.Drawing.Size(592, 501);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
            this.dataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridView_SortCompare);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DataGridView_UserDeletingRow);
            // 
            // grbTaskSettings
            // 
            this.grbTaskSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbTaskSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTaskSettings.Location = new System.Drawing.Point(1, 90);
            this.grbTaskSettings.Margin = new System.Windows.Forms.Padding(1);
            this.grbTaskSettings.MinimumSize = new System.Drawing.Size(0, 15);
            this.grbTaskSettings.Name = "grbTaskSettings";
            this.grbTaskSettings.Padding = new System.Windows.Forms.Padding(2);
            this.grbTaskSettings.Size = new System.Drawing.Size(598, 15);
            this.grbTaskSettings.TabIndex = 13;
            this.grbTaskSettings.TabStop = false;
            this.grbTaskSettings.Text = "Настройки расчета";
            this.grbTaskSettings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grbTask_MouseClick);
            this.grbTaskSettings.Paint += new System.Windows.Forms.PaintEventHandler(this.grbTask_Paint);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
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
            this.Settings.Width = 300;
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
            // TaskPlannerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(400, 700);
            this.Name = "TaskPlannerControl";
            this.Size = new System.Drawing.Size(600, 847);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbStartTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbStopTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnAddNewTask;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chbLinkedCalc;
        private System.Windows.Forms.Button btnClearAllTask;
        private System.Windows.Forms.CheckBox chbAddByTaskConditions;
        private System.Windows.Forms.TextBox txbStartStep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbMaxStep;
        private System.Windows.Forms.TextBox txbMinStep;
        private System.Windows.Forms.GroupBox grbTaskSettings;
        private System.Windows.Forms.CheckBox chbMechTask;
        private System.Windows.Forms.CheckBox chbTermoTask;
        private System.Windows.Forms.CheckBox chbChemicalTask;
        private System.Windows.Forms.Label lblChemicalTask;
        private System.Windows.Forms.Label lblMechTask;
        private System.Windows.Forms.Label lblTermoTask;
        private System.Windows.Forms.CheckBox cmbHardnessTask;
        private System.Windows.Forms.Label lblHardness;
        private System.Windows.Forms.CheckBox chbFurtherComp;
        private System.Windows.Forms.Label lblFileParameters;
        private System.Windows.Forms.Button btnLoadParameters;
        private System.Windows.Forms.Button btnGenTCF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Settings;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Time;
    }
}
