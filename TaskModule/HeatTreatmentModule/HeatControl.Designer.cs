using MB.Controls;

namespace TaskModule.HeatTreatmentModule
{
    partial class HeatControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grbHeatFlux = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.blackRank = new System.Windows.Forms.TextBox();
            this.radAndConvCoef = new System.Windows.Forms.RadioButton();
            this.fullCoef = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.StefanBolzmanConst = new System.Windows.Forms.TextBox();
            this.convExcFunc = new System.Windows.Forms.TextBox();
            this.cmbTempFunc = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbExchFunc = new System.Windows.Forms.ComboBox();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.grbHeatFlux.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grbHeatFlux, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(711, 741);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // grbHeatFlux
            // 
            this.grbHeatFlux.AutoSize = true;
            this.grbHeatFlux.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbHeatFlux.Controls.Add(this.label9);
            this.grbHeatFlux.Controls.Add(this.blackRank);
            this.grbHeatFlux.Controls.Add(this.radAndConvCoef);
            this.grbHeatFlux.Controls.Add(this.fullCoef);
            this.grbHeatFlux.Controls.Add(this.label7);
            this.grbHeatFlux.Controls.Add(this.StefanBolzmanConst);
            this.grbHeatFlux.Controls.Add(this.convExcFunc);
            this.grbHeatFlux.Controls.Add(this.cmbTempFunc);
            this.grbHeatFlux.Controls.Add(this.label8);
            this.grbHeatFlux.Controls.Add(this.label5);
            this.grbHeatFlux.Controls.Add(this.cmbExchFunc);
            this.grbHeatFlux.Controls.Add(this.label1);
            this.grbHeatFlux.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbHeatFlux.Location = new System.Drawing.Point(1, 76);
            this.grbHeatFlux.Margin = new System.Windows.Forms.Padding(1);
            this.grbHeatFlux.Name = "grbHeatFlux";
            this.grbHeatFlux.Padding = new System.Windows.Forms.Padding(0);
            this.grbHeatFlux.Size = new System.Drawing.Size(709, 220);
            this.grbHeatFlux.TabIndex = 18;
            this.grbHeatFlux.TabStop = false;
            this.grbHeatFlux.Text = "Параметры процесса";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 180);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "Температура среды, С°";
            // 
            // blackRank
            // 
            this.blackRank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blackRank.Enabled = false;
            this.blackRank.Location = new System.Drawing.Point(236, 145);
            this.blackRank.Margin = new System.Windows.Forms.Padding(4, 4, 37, 4);
            this.blackRank.Name = "blackRank";
            this.blackRank.Size = new System.Drawing.Size(454, 22);
            this.blackRank.TabIndex = 28;
            // 
            // radAndConvCoef
            // 
            this.radAndConvCoef.AutoSize = true;
            this.radAndConvCoef.Location = new System.Drawing.Point(366, 19);
            this.radAndConvCoef.Margin = new System.Windows.Forms.Padding(4);
            this.radAndConvCoef.Name = "radAndConvCoef";
            this.radAndConvCoef.Size = new System.Drawing.Size(240, 20);
            this.radAndConvCoef.TabIndex = 27;
            this.radAndConvCoef.Text = "Лучистый и конвективный коэф.";
            this.radAndConvCoef.UseVisualStyleBackColor = true;
            this.radAndConvCoef.CheckedChanged += new System.EventHandler(this.radAndConvCoef_CheckedChanged);
            // 
            // fullCoef
            // 
            this.fullCoef.AutoSize = true;
            this.fullCoef.Checked = true;
            this.fullCoef.Location = new System.Drawing.Point(236, 19);
            this.fullCoef.Margin = new System.Windows.Forms.Padding(4);
            this.fullCoef.Name = "fullCoef";
            this.fullCoef.Size = new System.Drawing.Size(119, 20);
            this.fullCoef.TabIndex = 27;
            this.fullCoef.TabStop = true;
            this.fullCoef.Text = "Полный коэф.";
            this.fullCoef.UseVisualStyleBackColor = true;
            this.fullCoef.CheckedChanged += new System.EventHandler(this.fullCoef_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "Конвек. коэф., Вт/мм2/C°";
            // 
            // StefanBolzmanConst
            // 
            this.StefanBolzmanConst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StefanBolzmanConst.Enabled = false;
            this.StefanBolzmanConst.Location = new System.Drawing.Point(236, 113);
            this.StefanBolzmanConst.Margin = new System.Windows.Forms.Padding(4, 4, 37, 4);
            this.StefanBolzmanConst.Name = "StefanBolzmanConst";
            this.StefanBolzmanConst.Size = new System.Drawing.Size(454, 22);
            this.StefanBolzmanConst.TabIndex = 25;
            // 
            // convExcFunc
            // 
            this.convExcFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.convExcFunc.Enabled = false;
            this.convExcFunc.Location = new System.Drawing.Point(236, 81);
            this.convExcFunc.Margin = new System.Windows.Forms.Padding(4, 4, 37, 4);
            this.convExcFunc.Name = "convExcFunc";
            this.convExcFunc.Size = new System.Drawing.Size(454, 22);
            this.convExcFunc.TabIndex = 24;
            // 
            // cmbTempFunc
            // 
            this.cmbTempFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTempFunc.FormattingEnabled = true;
            this.cmbTempFunc.Location = new System.Drawing.Point(236, 177);
            this.cmbTempFunc.Margin = new System.Windows.Forms.Padding(4, 4, 37, 4);
            this.cmbTempFunc.Name = "cmbTempFunc";
            this.cmbTempFunc.Size = new System.Drawing.Size(454, 24);
            this.cmbTempFunc.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 148);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Степень черноты, ?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Стеф. - Больцман, ?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Группа элементов";
            // 
            // cmbExchFunc
            // 
            this.cmbExchFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbExchFunc.FormattingEnabled = true;
            this.cmbExchFunc.Location = new System.Drawing.Point(236, 47);
            this.cmbExchFunc.Margin = new System.Windows.Forms.Padding(4, 4, 37, 4);
            this.cmbExchFunc.Name = "cmbExchFunc";
            this.cmbExchFunc.Size = new System.Drawing.Size(454, 24);
            this.cmbExchFunc.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Полный коэф., Вт/мм2/C°";
            // 
            // cmbEl
            // 
            this.cmbEl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEl.FormattingEnabled = true;
            this.cmbEl.Items.AddRange(new object[] {
            "test"});
            this.cmbEl.Location = new System.Drawing.Point(236, 30);
            this.cmbEl.Margin = new System.Windows.Forms.Padding(4, 18, 37, 4);
            this.cmbEl.Name = "cmbEl";
            this.cmbEl.Size = new System.Drawing.Size(454, 24);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = " ";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(1, 455);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(709, 285);
            this.dataGridView.TabIndex = 14;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
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
            this.groupBox1.Location = new System.Drawing.Point(1, 298);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(709, 157);
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
            this.player.Location = new System.Drawing.Point(236, 87);
            this.player.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.player.MinimumSize = new System.Drawing.Size(287, 55);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(454, 55);
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
            this.txbStopTime.Location = new System.Drawing.Point(236, 55);
            this.txbStopTime.Margin = new System.Windows.Forms.Padding(4, 4, 37, 4);
            this.txbStopTime.Name = "txbStopTime";
            this.txbStopTime.Size = new System.Drawing.Size(454, 22);
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
            this.txbStartTime.Location = new System.Drawing.Point(236, 23);
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(4, 4, 37, 4);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.Size = new System.Drawing.Size(454, 22);
            this.txbStartTime.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.cmbEl);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(1, 1);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox4.Size = new System.Drawing.Size(709, 73);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Область действия";
            // 
            // HeatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MinimumSize = new System.Drawing.Size(400, 369);
            this.Name = "HeatControl";
            this.Size = new System.Drawing.Size(711, 741);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grbHeatFlux.ResumeLayout(false);
            this.grbHeatFlux.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grbHeatFlux;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbExchFunc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEl;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbStopTime;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnAddNewRow;
        private System.Windows.Forms.TextBox txbStartTime;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbTempFunc;
        private PlayerControl.Player player;
        private System.Windows.Forms.DataGridViewTextBoxColumn processColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn elGroupColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn startColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stopColumn;
        private System.Windows.Forms.TextBox convExcFunc;
        private System.Windows.Forms.TextBox StefanBolzmanConst;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox blackRank;
        private System.Windows.Forms.RadioButton radAndConvCoef;
        private System.Windows.Forms.RadioButton fullCoef;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
