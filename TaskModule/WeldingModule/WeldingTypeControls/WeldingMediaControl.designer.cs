using MB.Controls;
using System.Drawing;

namespace TaskModule.WeldingModule.WeldingTypeControls
{
    partial class WeldingMediaControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeldingMediaControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grbHeatFlux = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbMediaTemp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFunc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEl = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.elGroupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStopCheck = new System.Windows.Forms.Button();
            this.btnCheckVelocity = new ColorSlider();
            this.btnCheckDinamic = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbStopTime = new System.Windows.Forms.TextBox();
            this.btnHideAll = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnAddNewRow = new System.Windows.Forms.Button();
            this.txbStartTime = new System.Windows.Forms.TextBox();
            this.grbTermoCycle = new System.Windows.Forms.GroupBox();
            this.cmbTermoCycle = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbNode = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.termoRadioButton = new System.Windows.Forms.RadioButton();
            this.heatFlowRadioButton = new System.Windows.Forms.RadioButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.grbHeatFlux.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbTermoCycle.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grbHeatFlux, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.grbTermoCycle, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 594);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // grbHeatFlux
            // 
            this.grbHeatFlux.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbHeatFlux.Controls.Add(this.label5);
            this.grbHeatFlux.Controls.Add(this.txbMediaTemp);
            this.grbHeatFlux.Controls.Add(this.label2);
            this.grbHeatFlux.Controls.Add(this.cmbFunc);
            this.grbHeatFlux.Controls.Add(this.label1);
            this.grbHeatFlux.Controls.Add(this.cmbEl);
            this.grbHeatFlux.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbHeatFlux.Location = new System.Drawing.Point(1, 64);
            this.grbHeatFlux.Margin = new System.Windows.Forms.Padding(1);
            this.grbHeatFlux.Name = "grbHeatFlux";
            this.grbHeatFlux.Padding = new System.Windows.Forms.Padding(0);
            this.grbHeatFlux.Size = new System.Drawing.Size(398, 124);
            this.grbHeatFlux.TabIndex = 18;
            this.grbHeatFlux.TabStop = false;
            this.grbHeatFlux.Text = "Параметры теплового потока";
            this.grbHeatFlux.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grbTask_MouseClick);
            this.grbHeatFlux.Paint += new System.Windows.Forms.PaintEventHandler(this.grbTask_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Температура среды, °C";
            // 
            // txbMediaTemp
            // 
            this.txbMediaTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMediaTemp.BackColor = System.Drawing.SystemColors.Window;
            this.txbMediaTemp.Location = new System.Drawing.Point(171, 84);
            this.txbMediaTemp.Margin = new System.Windows.Forms.Padding(3, 3, 28, 10);
            this.txbMediaTemp.Name = "txbMediaTemp";
            this.txbMediaTemp.Size = new System.Drawing.Size(201, 20);
            this.txbMediaTemp.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Группа элементов";
            // 
            // cmbFunc
            // 
            this.cmbFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFunc.FormattingEnabled = true;
            this.cmbFunc.Location = new System.Drawing.Point(171, 57);
            this.cmbFunc.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbFunc.Name = "cmbFunc";
            this.cmbFunc.Size = new System.Drawing.Size(201, 21);
            this.cmbFunc.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Коэф. теплоотдачи, Вт/мм2";
            // 
            // cmbEl
            // 
            this.cmbEl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEl.FormattingEnabled = true;
            this.cmbEl.Items.AddRange(new object[] {
            "test"});
            this.cmbEl.Location = new System.Drawing.Point(171, 30);
            this.cmbEl.Margin = new System.Windows.Forms.Padding(3, 15, 28, 3);
            this.cmbEl.Name = "cmbEl";
            this.cmbEl.Size = new System.Drawing.Size(201, 21);
            this.cmbEl.TabIndex = 18;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.elGroupColumn,
            this.matColumn,
            this.Column1,
            this.Column2,
            this.startColumn,
            this.stopColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = " ";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(1, 401);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(398, 192);
            this.dataGridView.TabIndex = 14;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
            this.dataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridView_SortCompare);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DataGridView_UserDeletingRow);
            // 
            // elGroupColumn
            // 
            this.elGroupColumn.HeaderText = "Группа оболочек / узлов";
            this.elGroupColumn.Name = "elGroupColumn";
            this.elGroupColumn.ReadOnly = true;
            // 
            // matColumn
            // 
            this.matColumn.HeaderText = "Коэф.теплоотдачи";
            this.matColumn.Name = "matColumn";
            this.matColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Температура среды";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Температура тела";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // startColumn
            // 
            this.startColumn.HeaderText = "Старт";
            this.startColumn.Name = "startColumn";
            this.startColumn.ReadOnly = true;
            // 
            // stopColumn
            // 
            this.stopColumn.HeaderText = "Стоп";
            this.stopColumn.Name = "stopColumn";
            this.stopColumn.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnStopCheck);
            this.groupBox1.Controls.Add(this.btnCheckVelocity);
            this.groupBox1.Controls.Add(this.btnCheckDinamic);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbStopTime);
            this.groupBox1.Controls.Add(this.btnHideAll);
            this.groupBox1.Controls.Add(this.btnShowAll);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnClearAll);
            this.groupBox1.Controls.Add(this.btnAddNewRow);
            this.groupBox1.Controls.Add(this.txbStartTime);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(1, 289);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(398, 110);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Время действия";
            // 
            // btnStopCheck
            // 
            this.btnStopCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStopCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnStopCheck.Image")));
            this.btnStopCheck.Location = new System.Drawing.Point(204, 71);
            this.btnStopCheck.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnStopCheck.Name = "btnStopCheck";
            this.btnStopCheck.Size = new System.Drawing.Size(27, 26);
            this.btnStopCheck.TabIndex = 52;
            this.btnStopCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStopCheck.UseVisualStyleBackColor = true;
            this.btnStopCheck.Click += new System.EventHandler(this.StopChecking_Click);
            // 
            // btnCheckVelocity
            // 
            this.btnCheckVelocity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckVelocity.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckVelocity.BarInnerColor = System.Drawing.Color.Gold;
            this.btnCheckVelocity.BarOuterColor = System.Drawing.Color.DarkGoldenrod;
            this.btnCheckVelocity.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.btnCheckVelocity.LargeChange = ((uint)(5u));
            this.btnCheckVelocity.Location = new System.Drawing.Point(237, 71);
            this.btnCheckVelocity.Margin = new System.Windows.Forms.Padding(3, 3, 28, 0);
            this.btnCheckVelocity.Maximum = 10;
            this.btnCheckVelocity.Minimum = 1;
            this.btnCheckVelocity.Name = "btnCheckVelocity";
            this.btnCheckVelocity.Size = new System.Drawing.Size(135, 26);
            this.btnCheckVelocity.SmallChange = ((uint)(1u));
            this.btnCheckVelocity.TabIndex = 51;
            this.btnCheckVelocity.Text = "colorSlider";
            this.btnCheckVelocity.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.btnCheckVelocity.Value = 1;
            this.btnCheckVelocity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CheckVelocitySlider_Scroll);
            // 
            // btnCheckDinamic
            // 
            this.btnCheckDinamic.AutoSize = true;
            this.btnCheckDinamic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCheckDinamic.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckDinamic.Image")));
            this.btnCheckDinamic.Location = new System.Drawing.Point(171, 71);
            this.btnCheckDinamic.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnCheckDinamic.Name = "btnCheckDinamic";
            this.btnCheckDinamic.Size = new System.Drawing.Size(27, 26);
            this.btnCheckDinamic.TabIndex = 50;
            this.btnCheckDinamic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckDinamic.UseVisualStyleBackColor = true;
            this.btnCheckDinamic.Click += new System.EventHandler(this.StartChecking_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Стоп, сек.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Старт, сек.";
            // 
            // txbStopTime
            // 
            this.txbStopTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStopTime.Location = new System.Drawing.Point(171, 45);
            this.txbStopTime.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbStopTime.Name = "txbStopTime";
            this.txbStopTime.Size = new System.Drawing.Size(201, 20);
            this.txbStopTime.TabIndex = 1;
            // 
            // btnHideAll
            // 
            this.btnHideAll.AutoSize = true;
            this.btnHideAll.Image = ((System.Drawing.Image)(resources.GetObject("btnHideAll.Image")));
            this.btnHideAll.Location = new System.Drawing.Point(139, 71);
            this.btnHideAll.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(26, 26);
            this.btnHideAll.TabIndex = 13;
            this.btnHideAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHideAll.UseVisualStyleBackColor = true;
            this.btnHideAll.Click += new System.EventHandler(this.HideAllDataButton_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.AutoSize = true;
            this.btnShowAll.Image = ((System.Drawing.Image)(resources.GetObject("btnShowAll.Image")));
            this.btnShowAll.Location = new System.Drawing.Point(107, 71);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(26, 26);
            this.btnShowAll.TabIndex = 13;
            this.btnShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.ShowDataButton_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(75, 71);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(26, 26);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.AutoSize = true;
            this.btnClearAll.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAll.Image")));
            this.btnClearAll.Location = new System.Drawing.Point(43, 71);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(26, 26);
            this.btnClearAll.TabIndex = 13;
            this.btnClearAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.ClearAllDataButton_Click);
            // 
            // btnAddNewRow
            // 
            this.btnAddNewRow.AutoSize = true;
            this.btnAddNewRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewRow.Image")));
            this.btnAddNewRow.Location = new System.Drawing.Point(10, 71);
            this.btnAddNewRow.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnAddNewRow.Name = "btnAddNewRow";
            this.btnAddNewRow.Size = new System.Drawing.Size(26, 26);
            this.btnAddNewRow.TabIndex = 13;
            this.btnAddNewRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewRow.UseVisualStyleBackColor = true;
            this.btnAddNewRow.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // txbStartTime
            // 
            this.txbStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartTime.Location = new System.Drawing.Point(171, 19);
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.Size = new System.Drawing.Size(201, 20);
            this.txbStartTime.TabIndex = 0;
            // 
            // grbTermoCycle
            // 
            this.grbTermoCycle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbTermoCycle.Controls.Add(this.cmbTermoCycle);
            this.grbTermoCycle.Controls.Add(this.label7);
            this.grbTermoCycle.Controls.Add(this.label6);
            this.grbTermoCycle.Controls.Add(this.cmbNode);
            this.grbTermoCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTermoCycle.Location = new System.Drawing.Point(1, 190);
            this.grbTermoCycle.Margin = new System.Windows.Forms.Padding(1);
            this.grbTermoCycle.Name = "grbTermoCycle";
            this.grbTermoCycle.Padding = new System.Windows.Forms.Padding(0);
            this.grbTermoCycle.Size = new System.Drawing.Size(398, 97);
            this.grbTermoCycle.TabIndex = 20;
            this.grbTermoCycle.TabStop = false;
            this.grbTermoCycle.Text = "Параметры термоцикла";
            this.grbTermoCycle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grbTask_MouseClick);
            this.grbTermoCycle.Paint += new System.Windows.Forms.PaintEventHandler(this.grbTask_Paint);
            // 
            // cmbTermoCycle
            // 
            this.cmbTermoCycle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTermoCycle.FormattingEnabled = true;
            this.cmbTermoCycle.Location = new System.Drawing.Point(171, 57);
            this.cmbTermoCycle.Margin = new System.Windows.Forms.Padding(3, 3, 28, 10);
            this.cmbTermoCycle.Name = "cmbTermoCycle";
            this.cmbTermoCycle.Size = new System.Drawing.Size(201, 21);
            this.cmbTermoCycle.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Группа узлов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Функция, F(t), °С - сек.";
            // 
            // cmbNode
            // 
            this.cmbNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNode.FormattingEnabled = true;
            this.cmbNode.Items.AddRange(new object[] {
            "node"});
            this.cmbNode.Location = new System.Drawing.Point(171, 30);
            this.cmbNode.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbNode.Name = "cmbNode";
            this.cmbNode.Size = new System.Drawing.Size(201, 21);
            this.cmbNode.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.termoRadioButton);
            this.groupBox4.Controls.Add(this.heatFlowRadioButton);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(1, 1);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox4.Size = new System.Drawing.Size(398, 61);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Вид условия";
            // 
            // termoRadioButton
            // 
            this.termoRadioButton.AutoSize = true;
            this.termoRadioButton.Location = new System.Drawing.Point(122, 28);
            this.termoRadioButton.Name = "termoRadioButton";
            this.termoRadioButton.Size = new System.Drawing.Size(82, 17);
            this.termoRadioButton.TabIndex = 21;
            this.termoRadioButton.TabStop = true;
            this.termoRadioButton.Text = "Термоцикл";
            this.termoRadioButton.UseVisualStyleBackColor = true;
            this.termoRadioButton.CheckedChanged += new System.EventHandler(this.termocycleRadioButton_CheckedChanged);
            // 
            // heatFlowRadioButton
            // 
            this.heatFlowRadioButton.AutoSize = true;
            this.heatFlowRadioButton.Location = new System.Drawing.Point(10, 28);
            this.heatFlowRadioButton.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.heatFlowRadioButton.Name = "heatFlowRadioButton";
            this.heatFlowRadioButton.Size = new System.Drawing.Size(106, 17);
            this.heatFlowRadioButton.TabIndex = 20;
            this.heatFlowRadioButton.TabStop = true;
            this.heatFlowRadioButton.Text = "Тепловой поток";
            this.heatFlowRadioButton.UseVisualStyleBackColor = true;
            this.heatFlowRadioButton.CheckedChanged += new System.EventHandler(this.mediaRadioButton_CheckedChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // MediaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MediaControl";
            this.Size = new System.Drawing.Size(400, 594);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grbHeatFlux.ResumeLayout(false);
            this.grbHeatFlux.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbTermoCycle.ResumeLayout(false);
            this.grbTermoCycle.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grbHeatFlux;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbMediaTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFunc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEl;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbStopTime;
        private System.Windows.Forms.Button btnAddNewRow;
        private System.Windows.Forms.TextBox txbStartTime;
        private System.Windows.Forms.GroupBox grbTermoCycle;
        private System.Windows.Forms.ComboBox cmbTermoCycle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbNode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton termoRadioButton;
        private System.Windows.Forms.RadioButton heatFlowRadioButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn elGroupColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn startColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stopColumn;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnStopCheck;
        private MB.Controls.ColorSlider btnCheckVelocity;
        private System.Windows.Forms.Button btnCheckDinamic;
    }
}
