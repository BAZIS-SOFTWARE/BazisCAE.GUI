using BaseModule.ControlsLib;
using BaseModule.ControlsLib.Validation;
using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grbHeatFlux = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.blackRank = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.radAndConvCoef = new System.Windows.Forms.RadioButton();
            this.fullCoef = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.StefanBolzmanConst = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.convExcFunc = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.cmbTempFunc = new BaseModule.ControlsLib.ComboBoxEx(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbExchFunc = new BaseModule.ControlsLib.ComboBoxEx(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.elGroupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.player = new BaseModule.ControlsLib.Player();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbStopTime = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.btnHideAll = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnAddNewRow = new System.Windows.Forms.Button();
            this.txbStartTime = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbEl = new BaseModule.ControlsLib.ComboBoxEx(this.components);
            this.label2 = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(533, 602);
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
            this.grbHeatFlux.Location = new System.Drawing.Point(7, 82);
            this.grbHeatFlux.Margin = new System.Windows.Forms.Padding(7);
            this.grbHeatFlux.Name = "grbHeatFlux";
            this.grbHeatFlux.Padding = new System.Windows.Forms.Padding(0);
            this.grbHeatFlux.Size = new System.Drawing.Size(519, 181);
            this.grbHeatFlux.TabIndex = 18;
            this.grbHeatFlux.TabStop = false;
            this.grbHeatFlux.Text = "Параметры процесса";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Температура среды, С°";
            // 
            // blackRank
            // 
            this.blackRank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blackRank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blackRank.Enabled = false;
            this.blackRank.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Float | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.blackRank.IsValidating = true;
            this.blackRank.Location = new System.Drawing.Point(171, 118);
            this.blackRank.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.blackRank.Name = "blackRank";
            this.blackRank.Size = new System.Drawing.Size(328, 20);
            this.blackRank.TabIndex = 28;
            this.blackRank.UserRegExCheck = null;
            this.blackRank.UserRegExCheckErrorMessage = null;
            // 
            // radAndConvCoef
            // 
            this.radAndConvCoef.AutoSize = true;
            this.radAndConvCoef.Location = new System.Drawing.Point(274, 15);
            this.radAndConvCoef.Name = "radAndConvCoef";
            this.radAndConvCoef.Size = new System.Drawing.Size(191, 17);
            this.radAndConvCoef.TabIndex = 27;
            this.radAndConvCoef.Text = "Лучистый и конвективный коэф.";
            this.radAndConvCoef.UseVisualStyleBackColor = true;
            this.radAndConvCoef.CheckedChanged += new System.EventHandler(this.radAndConvCoef_CheckedChanged);
            // 
            // fullCoef
            // 
            this.fullCoef.AutoSize = true;
            this.fullCoef.Checked = true;
            this.fullCoef.Location = new System.Drawing.Point(171, 15);
            this.fullCoef.Name = "fullCoef";
            this.fullCoef.Size = new System.Drawing.Size(97, 17);
            this.fullCoef.TabIndex = 27;
            this.fullCoef.TabStop = true;
            this.fullCoef.Text = "Полный коэф.";
            this.fullCoef.UseVisualStyleBackColor = true;
            this.fullCoef.CheckedChanged += new System.EventHandler(this.fullCoef_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Конвек. коэф., Вт/мм2/C°";
            // 
            // StefanBolzmanConst
            // 
            this.StefanBolzmanConst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StefanBolzmanConst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StefanBolzmanConst.Enabled = false;
            this.StefanBolzmanConst.InputType = BaseModule.ControlsLib.TXTBoxInputType.Float;
            this.StefanBolzmanConst.IsValidating = true;
            this.StefanBolzmanConst.Location = new System.Drawing.Point(171, 92);
            this.StefanBolzmanConst.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.StefanBolzmanConst.Name = "StefanBolzmanConst";
            this.StefanBolzmanConst.Size = new System.Drawing.Size(328, 20);
            this.StefanBolzmanConst.TabIndex = 25;
            this.StefanBolzmanConst.UserRegExCheck = null;
            this.StefanBolzmanConst.UserRegExCheckErrorMessage = null;
            // 
            // convExcFunc
            // 
            this.convExcFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.convExcFunc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.convExcFunc.Enabled = false;
            this.convExcFunc.InputType = BaseModule.ControlsLib.TXTBoxInputType.Float;
            this.convExcFunc.IsValidating = true;
            this.convExcFunc.Location = new System.Drawing.Point(171, 66);
            this.convExcFunc.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.convExcFunc.Name = "convExcFunc";
            this.convExcFunc.Size = new System.Drawing.Size(328, 20);
            this.convExcFunc.TabIndex = 24;
            this.convExcFunc.UserRegExCheck = null;
            this.convExcFunc.UserRegExCheckErrorMessage = null;
            // 
            // cmbTempFunc
            // 
            this.cmbTempFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTempFunc.FormattingEnabled = true;
            this.cmbTempFunc.InputType = ((BaseModule.ControlsLib.CMBInputType)((BaseModule.ControlsLib.CMBInputType.Items | BaseModule.ControlsLib.CMBInputType.Float)));
            this.cmbTempFunc.IsValidating = true;
            this.cmbTempFunc.Location = new System.Drawing.Point(171, 144);
            this.cmbTempFunc.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.cmbTempFunc.Name = "cmbTempFunc";
            this.cmbTempFunc.Size = new System.Drawing.Size(328, 21);
            this.cmbTempFunc.TabIndex = 23;
            this.cmbTempFunc.UserRegExCheck = null;
            this.cmbTempFunc.UserRegExCheckErrorMessage = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Степень черноты, ?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Стеф. - Больцман, ?";
            // 
            // cmbExchFunc
            // 
            this.cmbExchFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbExchFunc.FormattingEnabled = true;
            this.cmbExchFunc.InputType = ((BaseModule.ControlsLib.CMBInputType)((BaseModule.ControlsLib.CMBInputType.Items | BaseModule.ControlsLib.CMBInputType.Float)));
            this.cmbExchFunc.IsValidating = true;
            this.cmbExchFunc.Location = new System.Drawing.Point(171, 38);
            this.cmbExchFunc.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.cmbExchFunc.Name = "cmbExchFunc";
            this.cmbExchFunc.Size = new System.Drawing.Size(328, 21);
            this.cmbExchFunc.TabIndex = 17;
            this.cmbExchFunc.UserRegExCheck = null;
            this.cmbExchFunc.UserRegExCheckErrorMessage = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Полный коэф., Вт/мм2/C°";
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
            this.dataGridView.Location = new System.Drawing.Point(7, 425);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(7);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(519, 170);
            this.dataGridView.TabIndex = 14;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DataGridView_UserDeletingRow);
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
            this.groupBox1.Location = new System.Drawing.Point(7, 277);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(519, 134);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Время действия";
            // 
            // player
            // 
            this.player.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player.AutoSize = true;
            this.player.CheckState = BaseModule.ControlsLib.CheckState.start;
            this.player.CurrentValue = 0;
            this.player.Location = new System.Drawing.Point(171, 76);
            this.player.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.player.MinimumSize = new System.Drawing.Size(215, 45);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(328, 45);
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
            this.label4.Location = new System.Drawing.Point(8, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Стоп, сек.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Старт, сек.";
            // 
            // txbStopTime
            // 
            this.txbStopTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStopTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbStopTime.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Float | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbStopTime.IsValidating = true;
            this.txbStopTime.Location = new System.Drawing.Point(171, 50);
            this.txbStopTime.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txbStopTime.Name = "txbStopTime";
            this.txbStopTime.Size = new System.Drawing.Size(328, 20);
            this.txbStopTime.TabIndex = 1;
            this.txbStopTime.UserRegExCheck = null;
            this.txbStopTime.UserRegExCheckErrorMessage = null;
            // 
            // btnHideAll
            // 
            this.btnHideAll.AutoSize = true;
            this.btnHideAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideAll.Image = global::TaskModule.Properties.Resources.HideAll;
            this.btnHideAll.Location = new System.Drawing.Point(139, 76);
            this.btnHideAll.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(28, 28);
            this.btnHideAll.TabIndex = 13;
            this.btnHideAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHideAll.UseVisualStyleBackColor = true;
            this.btnHideAll.Click += new System.EventHandler(this.HideAllDataButton_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.AutoSize = true;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Image = global::TaskModule.Properties.Resources.ShowAll;
            this.btnShowAll.Location = new System.Drawing.Point(107, 76);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(28, 28);
            this.btnShowAll.TabIndex = 13;
            this.btnShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.ShowDataButton_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::TaskModule.Properties.Resources.Refresh;
            this.btnRefresh.Location = new System.Drawing.Point(75, 76);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(28, 28);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.AutoSize = true;
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.Image = global::TaskModule.Properties.Resources.delete;
            this.btnClearAll.Location = new System.Drawing.Point(43, 76);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(28, 28);
            this.btnClearAll.TabIndex = 13;
            this.btnClearAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.ClearAllDataButton_Click);
            // 
            // btnAddNewRow
            // 
            this.btnAddNewRow.AutoSize = true;
            this.btnAddNewRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewRow.Image = global::TaskModule.Properties.Resources.Add;
            this.btnAddNewRow.Location = new System.Drawing.Point(11, 76);
            this.btnAddNewRow.Margin = new System.Windows.Forms.Padding(11, 15, 3, 0);
            this.btnAddNewRow.Name = "btnAddNewRow";
            this.btnAddNewRow.Size = new System.Drawing.Size(28, 28);
            this.btnAddNewRow.TabIndex = 13;
            this.btnAddNewRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewRow.UseVisualStyleBackColor = true;
            this.btnAddNewRow.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // txbStartTime
            // 
            this.txbStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbStartTime.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Float | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbStartTime.IsValidating = true;
            this.txbStartTime.Location = new System.Drawing.Point(171, 24);
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(15, 25, 15, 3);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.Size = new System.Drawing.Size(328, 20);
            this.txbStartTime.TabIndex = 0;
            this.txbStartTime.UserRegExCheck = null;
            this.txbStartTime.UserRegExCheckErrorMessage = null;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.cmbEl);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(7, 7);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox4.Size = new System.Drawing.Size(519, 61);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Область действия";
            // 
            // cmbEl
            // 
            this.cmbEl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEl.FormattingEnabled = true;
            this.cmbEl.InputType = BaseModule.ControlsLib.CMBInputType.Items;
            this.cmbEl.IsValidating = true;
            this.cmbEl.Items.AddRange(new object[] {
            "test"});
            this.cmbEl.Location = new System.Drawing.Point(171, 24);
            this.cmbEl.Margin = new System.Windows.Forms.Padding(3, 25, 20, 3);
            this.cmbEl.Name = "cmbEl";
            this.cmbEl.Size = new System.Drawing.Size(328, 21);
            this.cmbEl.TabIndex = 18;
            this.cmbEl.UserRegExCheck = null;
            this.cmbEl.UserRegExCheckErrorMessage = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Группа элементов";
            // 
            // HeatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "HeatControl";
            this.Size = new System.Drawing.Size(533, 602);
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
        private ComboBoxEx cmbExchFunc;
        private System.Windows.Forms.Label label1;
        private ComboBoxEx cmbEl;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private TextBoxEx txbStopTime;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.Button btnShowAll;
        private Button btnRefresh;
        private System.Windows.Forms.Button btnClearAll;
        private Button btnAddNewRow;
        private TextBoxEx txbStartTime;
        private System.Windows.Forms.GroupBox groupBox4;
        private ComboBoxEx cmbTempFunc;
        private Player player;
        private TextBoxEx convExcFunc;
        private TextBoxEx StefanBolzmanConst;
        private System.Windows.Forms.Label label9;
        private TextBoxEx blackRank;
        private System.Windows.Forms.RadioButton radAndConvCoef;
        private System.Windows.Forms.RadioButton fullCoef;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn elGroupColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn startColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stopColumn;
    }
}
