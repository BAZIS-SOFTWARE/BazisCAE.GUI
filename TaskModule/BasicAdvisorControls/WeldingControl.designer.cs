namespace AdvisorControls
{
    partial class WeldingControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeldingControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.chbEnergyCalibration = new System.Windows.Forms.CheckBox();
            this.chbShifting = new System.Windows.Forms.CheckBox();
            this.btnStopChecking = new System.Windows.Forms.Button();
            this.colorSlider = new MB.Controls.ColorSlider();
            this.txbStartTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStopPoint = new System.Windows.Forms.ComboBox();
            this.cmbStartPoint = new System.Windows.Forms.ComboBox();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnCheckDinamic = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.addRowButton = new System.Windows.Forms.Button();
            this.txbShiftX = new System.Windows.Forms.TextBox();
            this.txbVelosity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEnergyCalibration = new System.Windows.Forms.ComboBox();
            this.cmbRef = new System.Windows.Forms.ComboBox();
            this.cmbTraj = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ИсточникСварки = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ОбластьСварки = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ПараметрыДвижения = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtLW = new System.Windows.Forms.RadioButton();
            this.rbtFSW = new System.Windows.Forms.RadioButton();
            this.rbtARC = new System.Windows.Forms.RadioButton();
            this.cmbWeldZone = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grbWeldRegime = new System.Windows.Forms.GroupBox();
            this.txbShiftY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbShiftZ = new System.Windows.Forms.TextBox();
            this.txbAngle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoScrollMinSize = new System.Drawing.Size(0, 300);
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grbWeldRegime, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(573, 638);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnClearAll);
            this.groupBox1.Controls.Add(this.chbEnergyCalibration);
            this.groupBox1.Controls.Add(this.chbShifting);
            this.groupBox1.Controls.Add(this.btnStopChecking);
            this.groupBox1.Controls.Add(this.colorSlider);
            this.groupBox1.Controls.Add(this.txbStartTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbStopPoint);
            this.groupBox1.Controls.Add(this.cmbStartPoint);
            this.groupBox1.Controls.Add(this.btnHide);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.btnCheckDinamic);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.addRowButton);
            this.groupBox1.Controls.Add(this.txbAngle);
            this.groupBox1.Controls.Add(this.txbShiftZ);
            this.groupBox1.Controls.Add(this.txbShiftY);
            this.groupBox1.Controls.Add(this.txbShiftX);
            this.groupBox1.Controls.Add(this.txbVelosity);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbEnergyCalibration);
            this.groupBox1.Controls.Add(this.cmbRef);
            this.groupBox1.Controls.Add(this.cmbTraj);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(1, 117);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.MinimumSize = new System.Drawing.Size(300, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(571, 281);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры движения";
            // 
            // btnClearAll
            // 
            this.btnClearAll.AutoSize = true;
            this.btnClearAll.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAll.Image")));
            this.btnClearAll.Location = new System.Drawing.Point(44, 242);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(26, 26);
            this.btnClearAll.TabIndex = 52;
            this.btnClearAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.ClearAllDataButton_Click);
            // 
            // chbEnergyCalibration
            // 
            this.chbEnergyCalibration.AutoSize = true;
            this.chbEnergyCalibration.Location = new System.Drawing.Point(10, 80);
            this.chbEnergyCalibration.Name = "chbEnergyCalibration";
            this.chbEnergyCalibration.Size = new System.Drawing.Size(148, 17);
            this.chbEnergyCalibration.TabIndex = 49;
            this.chbEnergyCalibration.Text = "Корректировка энергии";
            this.chbEnergyCalibration.UseVisualStyleBackColor = true;
            this.chbEnergyCalibration.CheckedChanged += new System.EventHandler(this.ChbEnergyCalib_CheckedChanged);
            // 
            // chbShifting
            // 
            this.chbShifting.AutoSize = true;
            this.chbShifting.Location = new System.Drawing.Point(10, 161);
            this.chbShifting.Name = "chbShifting";
            this.chbShifting.Size = new System.Drawing.Size(139, 17);
            this.chbShifting.TabIndex = 49;
            this.chbShifting.Text = "Положение источника";
            this.chbShifting.UseVisualStyleBackColor = true;
            this.chbShifting.CheckedChanged += new System.EventHandler(this.ChbShifting_CheckedChanged);
            // 
            // btnStopChecking
            // 
            this.btnStopChecking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStopChecking.Image = ((System.Drawing.Image)(resources.GetObject("btnStopChecking.Image")));
            this.btnStopChecking.Location = new System.Drawing.Point(212, 242);
            this.btnStopChecking.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnStopChecking.Name = "btnStopChecking";
            this.btnStopChecking.Size = new System.Drawing.Size(28, 26);
            this.btnStopChecking.TabIndex = 46;
            this.btnStopChecking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStopChecking.UseVisualStyleBackColor = true;
            this.btnStopChecking.Click += new System.EventHandler(this.StopChecking_Click);
            // 
            // colorSlider
            // 
            this.colorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSlider.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider.BarInnerColor = System.Drawing.Color.Gold;
            this.colorSlider.BarOuterColor = System.Drawing.Color.DarkGoldenrod;
            this.colorSlider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider.LargeChange = ((uint)(5u));
            this.colorSlider.Location = new System.Drawing.Point(246, 242);
            this.colorSlider.Margin = new System.Windows.Forms.Padding(3, 3, 28, 0);
            this.colorSlider.Maximum = 10;
            this.colorSlider.Minimum = 1;
            this.colorSlider.Name = "colorSlider";
            this.colorSlider.Size = new System.Drawing.Size(298, 26);
            this.colorSlider.SmallChange = ((uint)(1u));
            this.colorSlider.TabIndex = 45;
            this.colorSlider.Text = "colorSlider";
            this.colorSlider.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider.Value = 1;
            this.colorSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CheckVelocitySlider_Scroll);
            // 
            // txbStartTime
            // 
            this.txbStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartTime.Location = new System.Drawing.Point(178, 211);
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.Size = new System.Drawing.Size(366, 20);
            this.txbStartTime.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Старт, сек.";
            // 
            // cmbStopPoint
            // 
            this.cmbStopPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStopPoint.FormattingEnabled = true;
            this.cmbStopPoint.Location = new System.Drawing.Point(178, 132);
            this.cmbStopPoint.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbStopPoint.Name = "cmbStopPoint";
            this.cmbStopPoint.Size = new System.Drawing.Size(366, 21);
            this.cmbStopPoint.TabIndex = 36;
            // 
            // cmbStartPoint
            // 
            this.cmbStartPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStartPoint.FormattingEnabled = true;
            this.cmbStartPoint.Location = new System.Drawing.Point(178, 105);
            this.cmbStartPoint.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbStartPoint.Name = "cmbStartPoint";
            this.cmbStartPoint.Size = new System.Drawing.Size(366, 21);
            this.cmbStartPoint.TabIndex = 35;
            // 
            // btnHide
            // 
            this.btnHide.AutoSize = true;
            this.btnHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHide.Image = ((System.Drawing.Image)(resources.GetObject("btnHide.Image")));
            this.btnHide.Location = new System.Drawing.Point(144, 242);
            this.btnHide.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(28, 26);
            this.btnHide.TabIndex = 39;
            this.btnHide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.HideAllDataButton_Click);
            // 
            // btnShow
            // 
            this.btnShow.AutoSize = true;
            this.btnShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShow.Image = ((System.Drawing.Image)(resources.GetObject("btnShow.Image")));
            this.btnShow.Location = new System.Drawing.Point(110, 242);
            this.btnShow.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(28, 26);
            this.btnShow.TabIndex = 39;
            this.btnShow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.ShowDataButton_Click);
            // 
            // btnCheckDinamic
            // 
            this.btnCheckDinamic.AutoSize = true;
            this.btnCheckDinamic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCheckDinamic.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckDinamic.Image")));
            this.btnCheckDinamic.Location = new System.Drawing.Point(178, 242);
            this.btnCheckDinamic.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnCheckDinamic.Name = "btnCheckDinamic";
            this.btnCheckDinamic.Size = new System.Drawing.Size(28, 26);
            this.btnCheckDinamic.TabIndex = 39;
            this.btnCheckDinamic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckDinamic.UseVisualStyleBackColor = true;
            this.btnCheckDinamic.Click += new System.EventHandler(this.StartChecking_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(76, 242);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(28, 26);
            this.btnRefresh.TabIndex = 40;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // addRowButton
            // 
            this.addRowButton.AutoSize = true;
            this.addRowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addRowButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.addRowButton.Image = ((System.Drawing.Image)(resources.GetObject("addRowButton.Image")));
            this.addRowButton.Location = new System.Drawing.Point(10, 242);
            this.addRowButton.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(28, 26);
            this.addRowButton.TabIndex = 40;
            this.addRowButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addRowButton.UseVisualStyleBackColor = true;
            this.addRowButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // txbShiftX
            // 
            this.txbShiftX.Enabled = false;
            this.txbShiftX.Location = new System.Drawing.Point(205, 159);
            this.txbShiftX.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbShiftX.Name = "txbShiftX";
            this.txbShiftX.Size = new System.Drawing.Size(45, 20);
            this.txbShiftX.TabIndex = 31;
            this.txbShiftX.Text = "0";
            // 
            // txbVelosity
            // 
            this.txbVelosity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbVelosity.Location = new System.Drawing.Point(178, 185);
            this.txbVelosity.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbVelosity.Name = "txbVelosity";
            this.txbVelosity.Size = new System.Drawing.Size(366, 20);
            this.txbVelosity.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Точка остановки сварки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Опорная линия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Линия движения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Точка начала сварки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Скорость сварки, мм/cек.";
            // 
            // cmbEnergyCalibration
            // 
            this.cmbEnergyCalibration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEnergyCalibration.Enabled = false;
            this.cmbEnergyCalibration.FormattingEnabled = true;
            this.cmbEnergyCalibration.Location = new System.Drawing.Point(178, 78);
            this.cmbEnergyCalibration.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbEnergyCalibration.Name = "cmbEnergyCalibration";
            this.cmbEnergyCalibration.Size = new System.Drawing.Size(366, 21);
            this.cmbEnergyCalibration.TabIndex = 29;
            // 
            // cmbRef
            // 
            this.cmbRef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRef.FormattingEnabled = true;
            this.cmbRef.Location = new System.Drawing.Point(178, 51);
            this.cmbRef.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbRef.Name = "cmbRef";
            this.cmbRef.Size = new System.Drawing.Size(366, 21);
            this.cmbRef.TabIndex = 29;
            // 
            // cmbTraj
            // 
            this.cmbTraj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTraj.FormattingEnabled = true;
            this.cmbTraj.Location = new System.Drawing.Point(178, 24);
            this.cmbTraj.Margin = new System.Windows.Forms.Padding(3, 25, 28, 3);
            this.cmbTraj.Name = "cmbTraj";
            this.cmbTraj.Size = new System.Drawing.Size(366, 21);
            this.cmbTraj.TabIndex = 29;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.NullValue = " ";
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ИсточникСварки,
            this.ОбластьСварки,
            this.startColumn,
            this.stopColumn,
            this.ПараметрыДвижения});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(1, 400);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridView.RowHeadersWidth = 20;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView.Size = new System.Drawing.Size(571, 237);
            this.dataGridView.TabIndex = 25;
            this.dataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_DefaultValuesNeeded);
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DataGridView_UserDeletingRow);
            // 
            // ИсточникСварки
            // 
            this.ИсточникСварки.HeaderText = "Источник сварки";
            this.ИсточникСварки.Name = "ИсточникСварки";
            this.ИсточникСварки.ReadOnly = true;
            this.ИсточникСварки.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ОбластьСварки
            // 
            this.ОбластьСварки.HeaderText = "Область сварки";
            this.ОбластьСварки.Name = "ОбластьСварки";
            this.ОбластьСварки.ReadOnly = true;
            // 
            // startColumn
            // 
            this.startColumn.HeaderText = "Старт";
            this.startColumn.Name = "startColumn";
            this.startColumn.ReadOnly = true;
            // 
            // stopColumn
            // 
            this.stopColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle17.NullValue = "0";
            this.stopColumn.DefaultCellStyle = dataGridViewCellStyle17;
            this.stopColumn.HeaderText = "Стоп";
            this.stopColumn.Name = "stopColumn";
            this.stopColumn.ReadOnly = true;
            // 
            // ПараметрыДвижения
            // 
            this.ПараметрыДвижения.HeaderText = "Параметры движения";
            this.ПараметрыДвижения.Name = "ПараметрыДвижения";
            this.ПараметрыДвижения.ReadOnly = true;
            this.ПараметрыДвижения.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.rbtLW);
            this.groupBox3.Controls.Add(this.rbtFSW);
            this.groupBox3.Controls.Add(this.rbtARC);
            this.groupBox3.Controls.Add(this.cmbWeldZone);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(1, 1);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(571, 95);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Вид сварки";
            // 
            // rbtLW
            // 
            this.rbtLW.AutoSize = true;
            this.rbtLW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtLW.Location = new System.Drawing.Point(262, 28);
            this.rbtLW.Name = "rbtLW";
            this.rbtLW.Size = new System.Drawing.Size(75, 17);
            this.rbtLW.TabIndex = 22;
            this.rbtLW.TabStop = true;
            this.rbtLW.Text = "Лазерная";
            this.rbtLW.UseVisualStyleBackColor = true;
            this.rbtLW.Click += new System.EventHandler(this.rbtLW_CheckedChanged);
            // 
            // rbtFSW
            // 
            this.rbtFSW.AutoSize = true;
            this.rbtFSW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtFSW.Location = new System.Drawing.Point(84, 28);
            this.rbtFSW.Name = "rbtFSW";
            this.rbtFSW.Size = new System.Drawing.Size(172, 17);
            this.rbtFSW.TabIndex = 22;
            this.rbtFSW.TabStop = true;
            this.rbtFSW.Text = "Трением с перемешиванием";
            this.rbtFSW.UseVisualStyleBackColor = true;
            this.rbtFSW.Click += new System.EventHandler(this.fswRadioButton_CheckedChanged);
            // 
            // rbtARC
            // 
            this.rbtARC.AutoSize = true;
            this.rbtARC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbtARC.Location = new System.Drawing.Point(10, 28);
            this.rbtARC.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.rbtARC.Name = "rbtARC";
            this.rbtARC.Size = new System.Drawing.Size(68, 17);
            this.rbtARC.TabIndex = 21;
            this.rbtARC.TabStop = true;
            this.rbtARC.Text = "Дуговая";
            this.rbtARC.UseVisualStyleBackColor = true;
            this.rbtARC.Click += new System.EventHandler(this.arcwRadioButton_CheckedChanged);
            // 
            // cmbWeldZone
            // 
            this.cmbWeldZone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWeldZone.FormattingEnabled = true;
            this.cmbWeldZone.Location = new System.Drawing.Point(178, 58);
            this.cmbWeldZone.Margin = new System.Windows.Forms.Padding(3, 10, 28, 3);
            this.cmbWeldZone.Name = "cmbWeldZone";
            this.cmbWeldZone.Size = new System.Drawing.Size(366, 21);
            this.cmbWeldZone.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Область сварки";
            // 
            // grbWeldRegime
            // 
            this.grbWeldRegime.AutoSize = true;
            this.grbWeldRegime.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbWeldRegime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbWeldRegime.ForeColor = System.Drawing.Color.Black;
            this.grbWeldRegime.Location = new System.Drawing.Point(1, 98);
            this.grbWeldRegime.Margin = new System.Windows.Forms.Padding(1);
            this.grbWeldRegime.MinimumSize = new System.Drawing.Size(0, 15);
            this.grbWeldRegime.Name = "grbWeldRegime";
            this.grbWeldRegime.Padding = new System.Windows.Forms.Padding(2);
            this.grbWeldRegime.Size = new System.Drawing.Size(571, 17);
            this.grbWeldRegime.TabIndex = 30;
            this.grbWeldRegime.TabStop = false;
            this.grbWeldRegime.Text = "Источник сварки";
            // 
            // txbShiftY
            // 
            this.txbShiftY.Enabled = false;
            this.txbShiftY.Location = new System.Drawing.Point(281, 159);
            this.txbShiftY.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbShiftY.Name = "txbShiftY";
            this.txbShiftY.Size = new System.Drawing.Size(45, 20);
            this.txbShiftY.TabIndex = 31;
            this.txbShiftY.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "dX";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 162);
            this.label8.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "dY";
            // 
            // txbShiftZ
            // 
            this.txbShiftZ.Enabled = false;
            this.txbShiftZ.Location = new System.Drawing.Point(359, 159);
            this.txbShiftZ.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbShiftZ.Name = "txbShiftZ";
            this.txbShiftZ.Size = new System.Drawing.Size(45, 20);
            this.txbShiftZ.TabIndex = 31;
            this.txbShiftZ.Text = "0";
            // 
            // txbAngle
            // 
            this.txbAngle.Enabled = false;
            this.txbAngle.Location = new System.Drawing.Point(451, 159);
            this.txbAngle.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbAngle.Name = "txbAngle";
            this.txbAngle.Size = new System.Drawing.Size(45, 20);
            this.txbAngle.TabIndex = 31;
            this.txbAngle.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(335, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "dZ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(413, 162);
            this.label11.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 53;
            this.label11.Text = "Угол";
            // 
            // WeldingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "WeldingControl";
            this.Size = new System.Drawing.Size(573, 638);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbStartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbWeldZone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbStopPoint;
        private System.Windows.Forms.ComboBox cmbStartPoint;
        private System.Windows.Forms.Button btnCheckDinamic;
        private System.Windows.Forms.Button addRowButton;
        private System.Windows.Forms.TextBox txbVelosity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTraj;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox grbWeldRegime;
        private System.Windows.Forms.GroupBox groupBox3;
        private MB.Controls.ColorSlider colorSlider;
        private System.Windows.Forms.Button btnStopChecking;
        private System.Windows.Forms.RadioButton rbtFSW;
        private System.Windows.Forms.RadioButton rbtARC;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.RadioButton rbtLW;
        private System.Windows.Forms.TextBox txbShiftX;
        private System.Windows.Forms.CheckBox chbShifting;
        private System.Windows.Forms.ComboBox cmbEnergyCalibration;
        private System.Windows.Forms.CheckBox chbEnergyCalibration;
        private System.Windows.Forms.ComboBox cmbRef;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ИсточникСварки;
        private System.Windows.Forms.DataGridViewTextBoxColumn ОбластьСварки;
        private System.Windows.Forms.DataGridViewTextBoxColumn startColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stopColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ПараметрыДвижения;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbAngle;
        private System.Windows.Forms.TextBox txbShiftZ;
        private System.Windows.Forms.TextBox txbShiftY;
    }
}
