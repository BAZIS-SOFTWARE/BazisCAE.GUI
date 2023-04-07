namespace AdvisorControls
{
    partial class MaterialsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialsControl));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.elGroupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStopCheck = new System.Windows.Forms.Button();
            this.CheckVelocitySlider = new MB.Controls.ColorSlider();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEl = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.elGroupColumn,
            this.matColumn,
            this.startColumn,
            this.stopColumn});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(1, 207);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(776, 391);
            this.dataGridView.TabIndex = 14;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DataGridView_UserDeletingRow);
            // 
            // elGroupColumn
            // 
            this.elGroupColumn.HeaderText = "Группа элементов";
            this.elGroupColumn.Name = "elGroupColumn";
            this.elGroupColumn.ReadOnly = true;
            // 
            // matColumn
            // 
            this.matColumn.HeaderText = "Материал";
            this.matColumn.Name = "matColumn";
            this.matColumn.ReadOnly = true;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(778, 599);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnStopCheck);
            this.groupBox1.Controls.Add(this.CheckVelocitySlider);
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
            this.groupBox1.Location = new System.Drawing.Point(1, 97);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(776, 108);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Время действия";
            // 
            // btnStopCheck
            // 
            this.btnStopCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStopCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnStopCheck.Image")));
            this.btnStopCheck.Location = new System.Drawing.Point(205, 69);
            this.btnStopCheck.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnStopCheck.Name = "btnStopCheck";
            this.btnStopCheck.Size = new System.Drawing.Size(27, 26);
            this.btnStopCheck.TabIndex = 49;
            this.btnStopCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStopCheck.UseVisualStyleBackColor = true;
            this.btnStopCheck.Click += new System.EventHandler(this.StopChecking_Click);
            // 
            // CheckVelocitySlider
            // 
            this.CheckVelocitySlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckVelocitySlider.BackColor = System.Drawing.Color.Transparent;
            this.CheckVelocitySlider.BarInnerColor = System.Drawing.Color.Gold;
            this.CheckVelocitySlider.BarOuterColor = System.Drawing.Color.DarkGoldenrod;
            this.CheckVelocitySlider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.CheckVelocitySlider.LargeChange = ((uint)(5u));
            this.CheckVelocitySlider.Location = new System.Drawing.Point(238, 69);
            this.CheckVelocitySlider.Margin = new System.Windows.Forms.Padding(3, 3, 28, 0);
            this.CheckVelocitySlider.Maximum = 10;
            this.CheckVelocitySlider.Minimum = 1;
            this.CheckVelocitySlider.Name = "CheckVelocitySlider";
            this.CheckVelocitySlider.Size = new System.Drawing.Size(510, 26);
            this.CheckVelocitySlider.SmallChange = ((uint)(1u));
            this.CheckVelocitySlider.TabIndex = 48;
            this.CheckVelocitySlider.Text = "colorSlider";
            this.CheckVelocitySlider.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.CheckVelocitySlider.Value = 1;
            this.CheckVelocitySlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CheckVelocitySlider_Scroll);
            // 
            // btnCheckDinamic
            // 
            this.btnCheckDinamic.AutoSize = true;
            this.btnCheckDinamic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCheckDinamic.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckDinamic.Image")));
            this.btnCheckDinamic.Location = new System.Drawing.Point(172, 69);
            this.btnCheckDinamic.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnCheckDinamic.Name = "btnCheckDinamic";
            this.btnCheckDinamic.Size = new System.Drawing.Size(27, 26);
            this.btnCheckDinamic.TabIndex = 47;
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
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Старт, сек.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbStopTime
            // 
            this.txbStopTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbStopTime.Location = new System.Drawing.Point(172, 43);
            this.txbStopTime.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbStopTime.Name = "txbStopTime";
            this.txbStopTime.Size = new System.Drawing.Size(576, 20);
            this.txbStopTime.TabIndex = 1;
            // 
            // btnHideAll
            // 
            this.btnHideAll.AutoSize = true;
            this.btnHideAll.Image = ((System.Drawing.Image)(resources.GetObject("btnHideAll.Image")));
            this.btnHideAll.Location = new System.Drawing.Point(140, 69);
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
            this.btnShowAll.Location = new System.Drawing.Point(107, 69);
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
            this.btnRefresh.Location = new System.Drawing.Point(76, 69);
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
            this.btnClearAll.Location = new System.Drawing.Point(44, 69);
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
            this.btnAddNewRow.Location = new System.Drawing.Point(11, 69);
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
            this.txbStartTime.Location = new System.Drawing.Point(172, 19);
            this.txbStartTime.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.Size = new System.Drawing.Size(576, 20);
            this.txbStartTime.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbMat);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbEl);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(1, 1);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox2.Size = new System.Drawing.Size(776, 94);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выбор материала";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Группа элементов";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbMat
            // 
            this.cmbMat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMat.FormattingEnabled = true;
            this.cmbMat.Location = new System.Drawing.Point(172, 57);
            this.cmbMat.Name = "cmbMat";
            this.cmbMat.Size = new System.Drawing.Size(576, 21);
            this.cmbMat.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Материал";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbEl
            // 
            this.cmbEl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEl.FormattingEnabled = true;
            this.cmbEl.Location = new System.Drawing.Point(172, 30);
            this.cmbEl.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.cmbEl.Name = "cmbEl";
            this.cmbEl.Size = new System.Drawing.Size(576, 21);
            this.cmbEl.TabIndex = 14;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // MaterialsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MaterialsControl";
            this.Size = new System.Drawing.Size(778, 599);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbStopTime;
        private System.Windows.Forms.Button btnAddNewRow;
        private System.Windows.Forms.TextBox txbStartTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEl;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnHideAll;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnStopCheck;
        private MB.Controls.ColorSlider CheckVelocitySlider;
        private System.Windows.Forms.Button btnCheckDinamic;
        private System.Windows.Forms.DataGridViewTextBoxColumn elGroupColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stopColumn;
    }
}
