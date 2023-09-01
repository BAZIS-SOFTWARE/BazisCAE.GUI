namespace TaskModule.BasicAdvisorControls
{
    partial class LoadControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.player = new PlayerControl.Player();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnHideAll = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnAddNewRow = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txbStopTime = new System.Windows.Forms.TextBox();
            this.txbStartTime = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbLRF = new System.Windows.Forms.CheckBox();
            this.cmbGr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbLoadFunction = new System.Windows.Forms.ComboBox();
            this.cmbKind = new System.Windows.Forms.ComboBox();
            this.chbZ = new System.Windows.Forms.CheckBox();
            this.chbY = new System.Windows.Forms.CheckBox();
            this.chbX = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(561, 508);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.player);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Controls.Add(this.btnHideAll);
            this.groupBox3.Controls.Add(this.btnClearAll);
            this.groupBox3.Controls.Add(this.btnShowAll);
            this.groupBox3.Controls.Add(this.btnAddNewRow);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txbStopTime);
            this.groupBox3.Controls.Add(this.txbStartTime);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(1, 151);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(559, 135);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Время действия";
            // 
            // player
            // 
            this.player.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player.CheckState = PlayerControl.CheckState.start;
            this.player.CurrentValue = 0;
            this.player.Location = new System.Drawing.Point(170, 77);
            this.player.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.player.MinimumSize = new System.Drawing.Size(215, 45);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(361, 45);
            this.player.SliderBarInnerColor = System.Drawing.Color.Gold;
            this.player.SliderBarOuterColor = System.Drawing.Color.DarkGoldenrod;
            this.player.SliderElapsedInnerColor = System.Drawing.Color.Chartreuse;
            this.player.SliderElapsedOuterColor = System.Drawing.Color.DarkGreen;
            this.player.StartValue = 0;
            this.player.StopValue = 100;
            this.player.TabIndex = 20;
            this.player.CheckingEvent += new System.Action<object, float>(this.player_CheckingEvent);
            this.player.StopCheckingEvent += new System.Action<object>(this.player_StopCheckingEvent);
            this.player.StartCheckingEvent += new System.Action<object>(this.player_StartCheckingEvent);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(11, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Стоп, сек.";
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(74, 77);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(26, 26);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // btnHideAll
            // 
            this.btnHideAll.AutoSize = true;
            this.btnHideAll.Image = ((System.Drawing.Image)(resources.GetObject("btnHideAll.Image")));
            this.btnHideAll.Location = new System.Drawing.Point(138, 77);
            this.btnHideAll.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(26, 26);
            this.btnHideAll.TabIndex = 19;
            this.btnHideAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHideAll.UseVisualStyleBackColor = true;
            this.btnHideAll.Click += new System.EventHandler(this.HideAllDataButton_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.AutoSize = true;
            this.btnClearAll.Image = ((System.Drawing.Image)(resources.GetObject("btnClearAll.Image")));
            this.btnClearAll.Location = new System.Drawing.Point(42, 77);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(26, 26);
            this.btnClearAll.TabIndex = 19;
            this.btnClearAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.ClearAllDataButton_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.AutoSize = true;
            this.btnShowAll.Image = ((System.Drawing.Image)(resources.GetObject("btnShowAll.Image")));
            this.btnShowAll.Location = new System.Drawing.Point(106, 77);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(26, 26);
            this.btnShowAll.TabIndex = 19;
            this.btnShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.ShowDataButton_Click);
            // 
            // btnAddNewRow
            // 
            this.btnAddNewRow.AutoSize = true;
            this.btnAddNewRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewRow.Image")));
            this.btnAddNewRow.Location = new System.Drawing.Point(10, 77);
            this.btnAddNewRow.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.btnAddNewRow.Name = "btnAddNewRow";
            this.btnAddNewRow.Size = new System.Drawing.Size(26, 26);
            this.btnAddNewRow.TabIndex = 19;
            this.btnAddNewRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewRow.UseVisualStyleBackColor = true;
            this.btnAddNewRow.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(11, 22);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Старт, сек.";
            // 
            // txbStopTime
            // 
            this.txbStopTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStopTime.Location = new System.Drawing.Point(170, 46);
            this.txbStopTime.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbStopTime.Name = "txbStopTime";
            this.txbStopTime.Size = new System.Drawing.Size(361, 20);
            this.txbStopTime.TabIndex = 1;
            // 
            // txbStartTime
            // 
            this.txbStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStartTime.Location = new System.Drawing.Point(170, 19);
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.Size = new System.Drawing.Size(361, 20);
            this.txbStartTime.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column10,
            this.Column12,
            this.Column1,
            this.startColumn,
            this.stopColumn});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(1, 286);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(559, 221);
            this.dataGridView.TabIndex = 23;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Группа объектов";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Вид";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Направление";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Функция";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
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
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.chbLRF);
            this.groupBox1.Controls.Add(this.cmbGr);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbLoadFunction);
            this.groupBox1.Controls.Add(this.cmbKind);
            this.groupBox1.Controls.Add(this.chbZ);
            this.groupBox1.Controls.Add(this.chbY);
            this.groupBox1.Controls.Add(this.chbX);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(559, 148);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры нагрузки";
            // 
            // chbLRF
            // 
            this.chbLRF.AutoSize = true;
            this.chbLRF.Location = new System.Drawing.Point(347, 61);
            this.chbLRF.Name = "chbLRF";
            this.chbLRF.Size = new System.Drawing.Size(100, 17);
            this.chbLRF.TabIndex = 44;
            this.chbLRF.Text = "Произвольное";
            this.chbLRF.UseVisualStyleBackColor = true;
            this.chbLRF.CheckedChanged += new System.EventHandler(this.ChbDirection_CheckedChanged);
            // 
            // cmbGr
            // 
            this.cmbGr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGr.FormattingEnabled = true;
            this.cmbGr.Location = new System.Drawing.Point(170, 84);
            this.cmbGr.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbGr.Name = "cmbGr";
            this.cmbGr.Size = new System.Drawing.Size(361, 21);
            this.cmbGr.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Группа объектов";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Вид";
            // 
            // cmbLoadFunction
            // 
            this.cmbLoadFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLoadFunction.FormattingEnabled = true;
            this.cmbLoadFunction.Location = new System.Drawing.Point(170, 111);
            this.cmbLoadFunction.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbLoadFunction.Name = "cmbLoadFunction";
            this.cmbLoadFunction.Size = new System.Drawing.Size(361, 21);
            this.cmbLoadFunction.TabIndex = 36;
            // 
            // cmbKind
            // 
            this.cmbKind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKind.FormattingEnabled = true;
            this.cmbKind.Items.AddRange(new object[] {
            "Сила",
            "Перемещение"});
            this.cmbKind.Location = new System.Drawing.Point(170, 30);
            this.cmbKind.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbKind.Name = "cmbKind";
            this.cmbKind.Size = new System.Drawing.Size(361, 21);
            this.cmbKind.TabIndex = 36;
            // 
            // chbZ
            // 
            this.chbZ.AutoSize = true;
            this.chbZ.Location = new System.Drawing.Point(308, 61);
            this.chbZ.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.chbZ.Name = "chbZ";
            this.chbZ.Size = new System.Drawing.Size(33, 17);
            this.chbZ.TabIndex = 41;
            this.chbZ.Tag = "2";
            this.chbZ.Text = "Z";
            this.chbZ.UseVisualStyleBackColor = true;
            this.chbZ.CheckedChanged += new System.EventHandler(this.ChbDirection_CheckedChanged);
            // 
            // chbY
            // 
            this.chbY.AutoSize = true;
            this.chbY.Location = new System.Drawing.Point(269, 61);
            this.chbY.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.chbY.Name = "chbY";
            this.chbY.Size = new System.Drawing.Size(33, 17);
            this.chbY.TabIndex = 40;
            this.chbY.Tag = "1";
            this.chbY.Text = "Y";
            this.chbY.UseVisualStyleBackColor = true;
            this.chbY.CheckedChanged += new System.EventHandler(this.ChbDirection_CheckedChanged);
            // 
            // chbX
            // 
            this.chbX.AutoSize = true;
            this.chbX.Location = new System.Drawing.Point(230, 61);
            this.chbX.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.chbX.Name = "chbX";
            this.chbX.Size = new System.Drawing.Size(33, 17);
            this.chbX.TabIndex = 39;
            this.chbX.Tag = "0";
            this.chbX.Text = "X";
            this.chbX.UseVisualStyleBackColor = true;
            this.chbX.CheckedChanged += new System.EventHandler(this.ChbDirection_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(9, 114);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Функция, F(t), Н - сек.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Направление";
            // 
            // LoadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "LoadControl";
            this.Size = new System.Drawing.Size(561, 508);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddNewRow;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbStopTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbStartTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbGr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbKind;
        private System.Windows.Forms.CheckBox chbZ;
        private System.Windows.Forms.CheckBox chbY;
        private System.Windows.Forms.CheckBox chbX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbLoadFunction;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.CheckBox chbLRF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn startColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stopColumn;
        private PlayerControl.Player player;
    }
}
