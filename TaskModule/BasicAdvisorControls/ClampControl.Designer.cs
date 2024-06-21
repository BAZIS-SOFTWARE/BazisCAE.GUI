using BaseModule.ControlsLib;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using TaskModule.Validation;

namespace TaskModule.BasicAdvisorControls
{
    partial class ClampControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClampControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.player = new BaseModule.ControlsLib.Player();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txbStopTime = new ValidatingNumericTextBox(this.components);
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnHideAll = new System.Windows.Forms.Button();
            this.btnRefresh = new BtnValidate(this.components);
            this.btnAddNewRow = new BtnValidate(this.components);
            this.txbStartTime = new ValidatingNumericTextBox(this.components);
            this.cmbNodeGr = new CMBValidating(this.components);
            this.cmbKind = new CMBValidating(this.components);
            this.cmbStiffnessFunc = new ValidatingFunctionCMB(this.components);
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grbClampingParams = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chbLRF = new System.Windows.Forms.CheckBox();
            this.chbZ = new System.Windows.Forms.CheckBox();
            this.chbY = new System.Windows.Forms.CheckBox();
            this.chbX = new System.Windows.Forms.CheckBox();
            this.закрепленияTab_элComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbClampingParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grbClampingParams, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(801, 689);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.player);
            this.groupBox3.Controls.Add(this.btnClearAll);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txbStopTime);
            this.groupBox3.Controls.Add(this.btnShowAll);
            this.groupBox3.Controls.Add(this.btnHideAll);
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Controls.Add(this.btnAddNewRow);
            this.groupBox3.Controls.Add(this.txbStartTime);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(9, 283);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(783, 180);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Время действия";
            // 
            // player
            // 
            this.player.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player.AutoSize = true;
            this.player.CheckState = BaseModule.ControlsLib.CheckState.start;
            this.player.CurrentValue = 0;
            this.player.Location = new System.Drawing.Point(232, 105);
            this.player.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.player.MinimumSize = new System.Drawing.Size(287, 59);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(531, 59);
            this.player.SliderBarInnerColor = System.Drawing.Color.Gold;
            this.player.SliderBarOuterColor = System.Drawing.Color.DarkGoldenrod;
            this.player.SliderElapsedInnerColor = System.Drawing.Color.Chartreuse;
            this.player.SliderElapsedOuterColor = System.Drawing.Color.DarkGreen;
            this.player.SpeedValue = 500;
            this.player.StartValue = 0;
            this.player.StopValue = 100;
            this.player.TabIndex = 22;
            this.player.CheckingEvent += new System.Action<object, float>(this.player_CheckingEvent);
            this.player.StopCheckingEvent += new System.Action<object>(this.player_StopCheckingEvent);
            this.player.StartCheckingEvent += new System.Action<object>(this.player_StartCheckingEvent);
            // 
            // btnClearAll
            // 
            this.btnClearAll.AutoSize = true;
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAll.Image")));
            this.btnClearAll.Location = new System.Drawing.Point(57, 105);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(4, 20, 4, 0);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(37, 37);
            this.btnClearAll.TabIndex = 20;
            this.btnClearAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.ClearAllDataButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 75);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Стоп, сек.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 41);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "Старт, сек.";
            // 
            // txbStopTime
            // 
            this.txbStopTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStopTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbStopTime.IsNegativeValueAvailable = false;
            this.txbStopTime.Location = new System.Drawing.Point(232, 71);
            this.txbStopTime.Margin = new System.Windows.Forms.Padding(4, 4, 20, 4);
            this.txbStopTime.Name = "txbStopTime";
            this.txbStopTime.Size = new System.Drawing.Size(530, 23);
            this.txbStopTime.TabIndex = 1;
            // 
            // btnShowAll
            // 
            this.btnShowAll.AutoSize = true;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Image = ((System.Drawing.Image)(resources.GetObject("btnShowAll.Image")));
            this.btnShowAll.Location = new System.Drawing.Point(143, 105);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(4, 20, 4, 0);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(37, 37);
            this.btnShowAll.TabIndex = 19;
            this.btnShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.ShowDataButton_Click);
            // 
            // btnHideAll
            // 
            this.btnHideAll.AutoSize = true;
            this.btnHideAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideAll.Image = ((System.Drawing.Image)(resources.GetObject("btnHideAll.Image")));
            this.btnHideAll.Location = new System.Drawing.Point(185, 105);
            this.btnHideAll.Margin = new System.Windows.Forms.Padding(4, 20, 4, 0);
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(37, 37);
            this.btnHideAll.TabIndex = 19;
            this.btnHideAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHideAll.UseVisualStyleBackColor = true;
            this.btnHideAll.Click += new System.EventHandler(this.HideAllDataButton_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(100, 105);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 20, 4, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(37, 37);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.AddControl(txbStopTime);
            this.btnRefresh.AddControl(txbStartTime);
            this.btnRefresh.AddControl(cmbNodeGr);
            this.btnRefresh.AddControl(cmbKind);
            this.btnRefresh.AddControl(cmbStiffnessFunc);
            this.btnRefresh.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // btnAddNewRow
            // 
            this.btnAddNewRow.AutoSize = true;
            this.btnAddNewRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewRow.Image")));
            this.btnAddNewRow.Location = new System.Drawing.Point(15, 105);
            this.btnAddNewRow.Margin = new System.Windows.Forms.Padding(15, 20, 4, 0);
            this.btnAddNewRow.Name = "btnAddNewRow";
            this.btnAddNewRow.Size = new System.Drawing.Size(37, 37);
            this.btnAddNewRow.TabIndex = 19;
            this.btnAddNewRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewRow.UseVisualStyleBackColor = true;
            this.btnAddNewRow.AddControl(txbStopTime);
            this.btnAddNewRow.AddControl(txbStartTime);
            this.btnAddNewRow.AddControl(cmbNodeGr);
            this.btnAddNewRow.AddControl(cmbKind);
            this.btnAddNewRow.AddControl(cmbStiffnessFunc);
            this.btnAddNewRow.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // txbStartTime
            // 
            this.txbStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbStartTime.IsNegativeValueAvailable = false;
            this.txbStartTime.Location = new System.Drawing.Point(232, 37);
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(4, 20, 20, 4);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.Size = new System.Drawing.Size(530, 23);
            this.txbStartTime.TabIndex = 0;
            // 
            // cmbNodeGr
            // 
            this.cmbNodeGr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNodeGr.FormattingEnabled = true;
            this.cmbNodeGr.Location = new System.Drawing.Point(228, 31);
            this.cmbNodeGr.Margin = new System.Windows.Forms.Padding(237, 33, 20, 4);
            this.cmbNodeGr.Name = "cmbNodeGr";
            this.cmbNodeGr.Size = new System.Drawing.Size(535, 25);
            this.cmbNodeGr.TabIndex = 43;
            // 
            // cmbKind
            // 
            this.cmbKind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKind.FormattingEnabled = true;
            this.cmbKind.Items.AddRange(new object[] {
            "Жесткое"});
            this.cmbKind.Location = new System.Drawing.Point(227, 67);
            this.cmbKind.Margin = new System.Windows.Forms.Padding(4, 4, 37, 4);
            this.cmbKind.Name = "cmbKind";
            this.cmbKind.Size = new System.Drawing.Size(535, 25);
            this.cmbKind.TabIndex = 36;
            this.cmbKind.SelectedIndexChanged += new System.EventHandler(this.kindComboBox_SelectedIndexChanged);
            // 
            // cmbStiffnessFunc
            // 
            this.cmbStiffnessFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStiffnessFunc.Enabled = false;
            this.cmbStiffnessFunc.FormattingEnabled = true;
            this.cmbStiffnessFunc.Location = new System.Drawing.Point(227, 78);
            this.cmbStiffnessFunc.Margin = new System.Windows.Forms.Padding(20, 4, 20, 4);
            this.cmbStiffnessFunc.Name = "cmbStiffnessFunc";
            this.cmbStiffnessFunc.Size = new System.Drawing.Size(535, 25);
            this.cmbStiffnessFunc.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column10,
            this.Column12,
            this.Column1,
            this.startColumn,
            this.stopColumn});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(9, 481);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(783, 199);
            this.dataGridView.TabIndex = 23;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DataGridView_UserDeletingRow);
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Группа узлов";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.ToolTipText = "Название группы";
            this.Column9.Width = 95;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Вид";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.ToolTipText = "Вид условия";
            this.Column10.Width = 95;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Направление";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 95;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Функция";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.ToolTipText = "Функция f(U)";
            this.Column1.Width = 125;
            // 
            // startColumn
            // 
            this.startColumn.HeaderText = "Старт";
            this.startColumn.MinimumWidth = 6;
            this.startColumn.Name = "startColumn";
            this.startColumn.ReadOnly = true;
            this.startColumn.ToolTipText = "Сек.";
            this.startColumn.Width = 95;
            // 
            // stopColumn
            // 
            this.stopColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stopColumn.HeaderText = "Стоп";
            this.stopColumn.MinimumWidth = 6;
            this.stopColumn.Name = "stopColumn";
            this.stopColumn.ReadOnly = true;
            this.stopColumn.ToolTipText = "Сек.";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.cmbNodeGr);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbKind);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.groupBox1.MinimumSize = new System.Drawing.Size(467, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(783, 112);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид закрепления";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(15, 26, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "Группа узлов";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "Вид";
            // 
            // grbClampingParams
            // 
            this.grbClampingParams.AutoSize = true;
            this.grbClampingParams.Controls.Add(this.label4);
            this.grbClampingParams.Controls.Add(this.label2);
            this.grbClampingParams.Controls.Add(this.cmbStiffnessFunc);
            this.grbClampingParams.Controls.Add(this.chbLRF);
            this.grbClampingParams.Controls.Add(this.chbZ);
            this.grbClampingParams.Controls.Add(this.chbY);
            this.grbClampingParams.Controls.Add(this.chbX);
            this.grbClampingParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbClampingParams.Location = new System.Drawing.Point(9, 139);
            this.grbClampingParams.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.grbClampingParams.Name = "grbClampingParams";
            this.grbClampingParams.Size = new System.Drawing.Size(783, 126);
            this.grbClampingParams.TabIndex = 26;
            this.grbClampingParams.TabStop = false;
            this.grbClampingParams.Text = "Параметры закрепления";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 37, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "Функция, F(u) , Н.мм - у.ед.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 26, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "Направление";
            // 
            // chbLRF
            // 
            this.chbLRF.AutoSize = true;
            this.chbLRF.Location = new System.Drawing.Point(383, 44);
            this.chbLRF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbLRF.Name = "chbLRF";
            this.chbLRF.Size = new System.Drawing.Size(125, 21);
            this.chbLRF.TabIndex = 0;
            this.chbLRF.Tag = "3";
            this.chbLRF.Text = "Произвольное";
            this.chbLRF.UseVisualStyleBackColor = true;
            this.chbLRF.EnabledChanged += new System.EventHandler(this.chbLRF_EnabledChanged);
            this.chbLRF.Click += new System.EventHandler(this.ChbDirection_Click);
            // 
            // chbZ
            // 
            this.chbZ.AutoSize = true;
            this.chbZ.Location = new System.Drawing.Point(331, 44);
            this.chbZ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbZ.Name = "chbZ";
            this.chbZ.Size = new System.Drawing.Size(39, 21);
            this.chbZ.TabIndex = 0;
            this.chbZ.Tag = "2";
            this.chbZ.Text = "Z";
            this.chbZ.UseVisualStyleBackColor = true;
            this.chbZ.Click += new System.EventHandler(this.ChbDirection_Click);
            // 
            // chbY
            // 
            this.chbY.AutoSize = true;
            this.chbY.Location = new System.Drawing.Point(279, 44);
            this.chbY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbY.Name = "chbY";
            this.chbY.Size = new System.Drawing.Size(39, 21);
            this.chbY.TabIndex = 0;
            this.chbY.Tag = "1";
            this.chbY.Text = "Y";
            this.chbY.UseVisualStyleBackColor = true;
            this.chbY.Click += new System.EventHandler(this.ChbDirection_Click);
            // 
            // chbX
            // 
            this.chbX.AutoSize = true;
            this.chbX.Location = new System.Drawing.Point(227, 44);
            this.chbX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbX.Name = "chbX";
            this.chbX.Size = new System.Drawing.Size(39, 21);
            this.chbX.TabIndex = 0;
            this.chbX.Tag = "0";
            this.chbX.Text = "X";
            this.chbX.UseVisualStyleBackColor = true;
            this.chbX.Click += new System.EventHandler(this.ChbDirection_Click);
            // 
            // закрепленияTab_элComboBox
            // 
            this.закрепленияTab_элComboBox.FormattingEnabled = true;
            this.закрепленияTab_элComboBox.Location = new System.Drawing.Point(199, -39);
            this.закрепленияTab_элComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.закрепленияTab_элComboBox.Name = "закрепленияTab_элComboBox";
            this.закрепленияTab_элComboBox.Size = new System.Drawing.Size(304, 25);
            this.закрепленияTab_элComboBox.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-13, -35);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Группа узлов/элементов";
            // 
            // ClampControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.закрепленияTab_элComboBox);
            this.Controls.Add(this.label7);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(400, 392);
            this.Name = "ClampControl";
            this.Size = new System.Drawing.Size(801, 689);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbClampingParams.ResumeLayout(false);
            this.grbClampingParams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox закрепленияTab_элComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ValidatingNumericTextBox txbStopTime;
        private BtnValidate btnAddNewRow;
        private ValidatingNumericTextBox txbStartTime;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private CMBValidating cmbNodeGr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private CMBValidating cmbKind;
        private System.Windows.Forms.GroupBox grbClampingParams;
        private System.Windows.Forms.Label label2;
        private ValidatingFunctionCMB cmbStiffnessFunc;
        private System.Windows.Forms.Label label4;
        private BtnValidate btnRefresh;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.CheckBox chbLRF;
        private System.Windows.Forms.CheckBox chbZ;
        private System.Windows.Forms.CheckBox chbY;
        private System.Windows.Forms.CheckBox chbX;
        private Player player;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn startColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stopColumn;
    }
}
