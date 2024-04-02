using MB.Controls;

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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grbHeatFlux = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbMediaTemp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFunc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEl = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.processColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elGroupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.player = new PlayerControl.Player();
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
            this.rbtTermoCycle = new System.Windows.Forms.RadioButton();
            this.rbtHeatFlow = new System.Windows.Forms.RadioButton();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(616, 731);
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
            this.grbHeatFlux.Location = new System.Drawing.Point(1, 76);
            this.grbHeatFlux.Margin = new System.Windows.Forms.Padding(1);
            this.grbHeatFlux.Name = "grbHeatFlux";
            this.grbHeatFlux.Padding = new System.Windows.Forms.Padding(0);
            this.grbHeatFlux.Size = new System.Drawing.Size(614, 153);
            this.grbHeatFlux.TabIndex = 18;
            this.grbHeatFlux.TabStop = false;
            this.grbHeatFlux.Text = "Параметры теплового потока";
            this.grbHeatFlux.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grbTask_MouseClick);
            this.grbHeatFlux.Paint += new System.Windows.Forms.PaintEventHandler(this.grbTask_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Температура среды, °C";
            // 
            // txbMediaTemp
            // 
            this.txbMediaTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMediaTemp.BackColor = System.Drawing.SystemColors.Window;
            this.txbMediaTemp.Location = new System.Drawing.Point(228, 103);
            this.txbMediaTemp.Margin = new System.Windows.Forms.Padding(4, 4, 37, 12);
            this.txbMediaTemp.Name = "txbMediaTemp";
            this.txbMediaTemp.Size = new System.Drawing.Size(366, 22);
            this.txbMediaTemp.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Группа элементов";
            // 
            // cmbFunc
            // 
            this.cmbFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFunc.FormattingEnabled = true;
            this.cmbFunc.Location = new System.Drawing.Point(228, 70);
            this.cmbFunc.Margin = new System.Windows.Forms.Padding(4, 4, 37, 4);
            this.cmbFunc.Name = "cmbFunc";
            this.cmbFunc.Size = new System.Drawing.Size(366, 24);
            this.cmbFunc.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 16);
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
            this.cmbEl.Location = new System.Drawing.Point(228, 37);
            this.cmbEl.Margin = new System.Windows.Forms.Padding(4, 18, 20, 4);
            this.cmbEl.Name = "cmbEl";
            this.cmbEl.Size = new System.Drawing.Size(366, 24);
            this.cmbEl.TabIndex = 18;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.processColumn,
            this.elGroupColumn,
            this.matColumn,
            this.Column1,
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
            this.dataGridView.Location = new System.Drawing.Point(1, 509);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(614, 221);
            this.dataGridView.TabIndex = 14;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
            this.dataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridView_SortCompare);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DataGridView_UserDeletingRow);
            // 
            // processColumn
            // 
            this.processColumn.HeaderText = "Вид процесса";
            this.processColumn.MinimumWidth = 6;
            this.processColumn.Name = "processColumn";
            this.processColumn.ReadOnly = true;
            // 
            // elGroupColumn
            // 
            this.elGroupColumn.HeaderText = "Группа оболочек / узлов";
            this.elGroupColumn.MinimumWidth = 6;
            this.elGroupColumn.Name = "elGroupColumn";
            this.elGroupColumn.ReadOnly = true;
            // 
            // matColumn
            // 
            this.matColumn.HeaderText = "Коэф.теплоотдачи";
            this.matColumn.MinimumWidth = 6;
            this.matColumn.Name = "matColumn";
            this.matColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Температура среды";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // startColumn
            // 
            this.startColumn.HeaderText = "Старт";
            this.startColumn.MinimumWidth = 6;
            this.startColumn.Name = "startColumn";
            this.startColumn.ReadOnly = true;
            // 
            // stopColumn
            // 
            this.stopColumn.HeaderText = "Стоп";
            this.stopColumn.MinimumWidth = 6;
            this.stopColumn.Name = "stopColumn";
            this.stopColumn.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.player);
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
            this.groupBox1.Location = new System.Drawing.Point(1, 352);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(614, 157);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Время действия";
            // 
            // player
            // 
            this.player.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player.AutoSize = true;
            this.player.CheckState = PlayerControl.CheckState.start;
            this.player.CurrentValue = 0;
            this.player.Location = new System.Drawing.Point(228, 87);
            this.player.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.player.MinimumSize = new System.Drawing.Size(287, 55);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(366, 55);
            this.player.SliderBarInnerColor = System.Drawing.Color.Gold;
            this.player.SliderBarOuterColor = System.Drawing.Color.DarkGoldenrod;
            this.player.SliderElapsedInnerColor = System.Drawing.Color.Chartreuse;
            this.player.SliderElapsedOuterColor = System.Drawing.Color.DarkGreen;
            this.player.SpeedValue = 500;
            this.player.StartValue = 0;
            this.player.StopValue = 100;
            this.player.TabIndex = 14;
            this.player.CheckingEvent += new System.Action<object, float>(this.player_CheckingEvent);
            this.player.StopCheckingEvent += new System.Action<object>(this.player_StopCheckingEvent);
            this.player.StartCheckingEvent += new System.Action<object>(this.player_StartCheckingEvent);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Стоп, сек.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Старт, сек.";
            // 
            // txbStopTime
            // 
            this.txbStopTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStopTime.Location = new System.Drawing.Point(228, 55);
            this.txbStopTime.Margin = new System.Windows.Forms.Padding(4, 4, 37, 4);
            this.txbStopTime.Name = "txbStopTime";
            this.txbStopTime.Size = new System.Drawing.Size(366, 22);
            this.txbStopTime.TabIndex = 1;
            // 
            // btnHideAll
            // 
            this.btnHideAll.AutoSize = true;
            this.btnHideAll.Image = global::TaskModule.Properties.Resources.HideAll;
            this.btnHideAll.Location = new System.Drawing.Point(185, 87);
            this.btnHideAll.Margin = new System.Windows.Forms.Padding(4, 18, 4, 0);
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(35, 32);
            this.btnHideAll.TabIndex = 13;
            this.btnHideAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHideAll.UseVisualStyleBackColor = true;
            this.btnHideAll.Click += new System.EventHandler(this.HideAllDataButton_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.AutoSize = true;
            this.btnShowAll.Image = global::TaskModule.Properties.Resources.ShowAll;
            this.btnShowAll.Location = new System.Drawing.Point(143, 87);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(4, 18, 4, 0);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(35, 32);
            this.btnShowAll.TabIndex = 13;
            this.btnShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.ShowDataButton_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = global::TaskModule.Properties.Resources.Refresh;
            this.btnRefresh.Location = new System.Drawing.Point(100, 87);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 18, 4, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(35, 32);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.AutoSize = true;
            this.btnClearAll.Image = global::TaskModule.Properties.Resources.delete;
            this.btnClearAll.Location = new System.Drawing.Point(57, 87);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(4, 18, 4, 0);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(35, 32);
            this.btnClearAll.TabIndex = 13;
            this.btnClearAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.ClearAllDataButton_Click);
            // 
            // btnAddNewRow
            // 
            this.btnAddNewRow.AutoSize = true;
            this.btnAddNewRow.Image = global::TaskModule.Properties.Resources.Add;
            this.btnAddNewRow.Location = new System.Drawing.Point(13, 87);
            this.btnAddNewRow.Margin = new System.Windows.Forms.Padding(4, 18, 4, 0);
            this.btnAddNewRow.Name = "btnAddNewRow";
            this.btnAddNewRow.Size = new System.Drawing.Size(35, 32);
            this.btnAddNewRow.TabIndex = 13;
            this.btnAddNewRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewRow.UseVisualStyleBackColor = true;
            this.btnAddNewRow.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // txbStartTime
            // 
            this.txbStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartTime.Location = new System.Drawing.Point(228, 23);
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(4, 4, 37, 4);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.Size = new System.Drawing.Size(366, 22);
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
            this.grbTermoCycle.Location = new System.Drawing.Point(1, 231);
            this.grbTermoCycle.Margin = new System.Windows.Forms.Padding(1);
            this.grbTermoCycle.Name = "grbTermoCycle";
            this.grbTermoCycle.Padding = new System.Windows.Forms.Padding(0);
            this.grbTermoCycle.Size = new System.Drawing.Size(614, 119);
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
            this.cmbTermoCycle.Location = new System.Drawing.Point(228, 70);
            this.cmbTermoCycle.Margin = new System.Windows.Forms.Padding(4, 4, 37, 12);
            this.cmbTermoCycle.Name = "cmbTermoCycle";
            this.cmbTermoCycle.Size = new System.Drawing.Size(366, 24);
            this.cmbTermoCycle.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 41);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Группа узлов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 74);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 16);
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
            this.cmbNode.Location = new System.Drawing.Point(228, 37);
            this.cmbNode.Margin = new System.Windows.Forms.Padding(4, 4, 37, 4);
            this.cmbNode.Name = "cmbNode";
            this.cmbNode.Size = new System.Drawing.Size(366, 24);
            this.cmbNode.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.rbtTermoCycle);
            this.groupBox4.Controls.Add(this.rbtHeatFlow);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(1, 1);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox4.Size = new System.Drawing.Size(614, 73);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Вид условия";
            // 
            // rbtTermoCycle
            // 
            this.rbtTermoCycle.AutoSize = true;
            this.rbtTermoCycle.Location = new System.Drawing.Point(163, 34);
            this.rbtTermoCycle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtTermoCycle.Name = "rbtTermoCycle";
            this.rbtTermoCycle.Size = new System.Drawing.Size(101, 20);
            this.rbtTermoCycle.TabIndex = 21;
            this.rbtTermoCycle.TabStop = true;
            this.rbtTermoCycle.Text = "Термоцикл";
            this.rbtTermoCycle.UseVisualStyleBackColor = true;
            this.rbtTermoCycle.CheckedChanged += new System.EventHandler(this.termocycleRadioButton_CheckedChanged);
            // 
            // rbtHeatFlow
            // 
            this.rbtHeatFlow.AutoSize = true;
            this.rbtHeatFlow.Location = new System.Drawing.Point(13, 34);
            this.rbtHeatFlow.Margin = new System.Windows.Forms.Padding(4, 18, 4, 4);
            this.rbtHeatFlow.Name = "rbtHeatFlow";
            this.rbtHeatFlow.Size = new System.Drawing.Size(134, 20);
            this.rbtHeatFlow.TabIndex = 20;
            this.rbtHeatFlow.TabStop = true;
            this.rbtHeatFlow.Text = "Тепловой поток";
            this.rbtHeatFlow.UseVisualStyleBackColor = true;
            this.rbtHeatFlow.CheckedChanged += new System.EventHandler(this.mediaRadioButton_CheckedChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // WeldingMediaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MinimumSize = new System.Drawing.Size(400, 369);
            this.Name = "WeldingMediaControl";
            this.Size = new System.Drawing.Size(616, 731);
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
        private System.Windows.Forms.RadioButton rbtTermoCycle;
        private System.Windows.Forms.RadioButton rbtHeatFlow;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnClearAll;
        private PlayerControl.Player player;
        private System.Windows.Forms.DataGridViewTextBoxColumn processColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn elGroupColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn startColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stopColumn;
    }
}
