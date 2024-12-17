using UserControlsEx;

namespace BaseModule.Tasks.BasicAdvisorControls.TaskPlannerControls
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView = new UserControlsEx.DataGridViewEx(this.components);
            this.Kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Settings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadParameters = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.btnGenTCF = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.grbTaskKind = new System.Windows.Forms.GroupBox();
            this.rbtMechTask = new System.Windows.Forms.RadioButton();
            this.rbtTermoTask = new System.Windows.Forms.RadioButton();
            this.rbtChemicalTask = new System.Windows.Forms.RadioButton();
            this.rbtChemTermoTask = new System.Windows.Forms.RadioButton();
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
            this.dataGridView.Location = new System.Drawing.Point(7, 197);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(7);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(686, 523);
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
            this.groupBox1.Controls.Add(this.btnLoadParameters);
            this.groupBox1.Controls.Add(this.StopButton);
            this.groupBox1.Controls.Add(this.btnGenTCF);
            this.groupBox1.Controls.Add(this.StartButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(7, 115);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(686, 68);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Временные параметры";
            // 
            // btnLoadParameters
            // 
            this.btnLoadParameters.AutoSize = true;
            this.btnLoadParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnLoadParameters.Image = global::BaseModule.Properties.Resources.ComputationFolder;
            this.btnLoadParameters.Location = new System.Drawing.Point(11, 27);
            this.btnLoadParameters.Margin = new System.Windows.Forms.Padding(3, 14, 3, 0);
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
            this.StopButton.Location = new System.Drawing.Point(218, 27);
            this.StopButton.Margin = new System.Windows.Forms.Padding(3, 1, 15, 1);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(67, 27);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Стоп";
            this.StopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // btnGenTCF
            // 
            this.btnGenTCF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenTCF.AutoSize = true;
            this.btnGenTCF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenTCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnGenTCF.Location = new System.Drawing.Point(44, 27);
            this.btnGenTCF.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnGenTCF.Name = "btnGenTCF";
            this.btnGenTCF.Size = new System.Drawing.Size(96, 27);
            this.btnGenTCF.TabIndex = 2;
            this.btnGenTCF.Text = "Создать *.tsf";
            this.btnGenTCF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenTCF.UseVisualStyleBackColor = true;
            this.btnGenTCF.Click += new System.EventHandler(this.btnGenTSF_Click);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.AutoSize = true;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.StartButton.Location = new System.Drawing.Point(146, 27);
            this.StartButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(66, 27);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Старт";
            this.StartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // grbTaskKind
            // 
            this.grbTaskKind.Controls.Add(this.rbtMechTask);
            this.grbTaskKind.Controls.Add(this.rbtTermoTask);
            this.grbTaskKind.Controls.Add(this.rbtChemicalTask);
            this.grbTaskKind.Controls.Add(this.rbtChemTermoTask);
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
            // rbtChemTermoTask
            // 
            this.rbtChemTermoTask.AutoSize = true;
            this.rbtChemTermoTask.BackColor = System.Drawing.Color.Transparent;
            this.rbtChemTermoTask.Location = new System.Drawing.Point(11, 50);
            this.rbtChemTermoTask.Name = "rbtChemTermoTask";
            this.rbtChemTermoTask.Size = new System.Drawing.Size(133, 17);
            this.rbtChemTermoTask.TabIndex = 81;
            this.rbtChemTermoTask.Text = "Химико-термическая";
            this.rbtChemTermoTask.UseVisualStyleBackColor = false;
            // 
            // rbtTermoMechTask
            // 
            this.rbtTermoMechTask.AutoSize = true;
            this.rbtTermoMechTask.BackColor = System.Drawing.Color.Transparent;
            this.rbtTermoMechTask.Location = new System.Drawing.Point(150, 50);
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
        private System.Windows.Forms.Button btnLoadParameters;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button btnGenTCF;
        private System.Windows.Forms.Button StartButton;
        private DataGridViewEx dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Settings;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Time;
        private System.Windows.Forms.GroupBox grbTaskKind;
        private System.Windows.Forms.RadioButton rbtMechTask;
        private System.Windows.Forms.RadioButton rbtTermoTask;
        private System.Windows.Forms.RadioButton rbtChemicalTask;
        private System.Windows.Forms.RadioButton rbtTermoMechTask;
        private System.Windows.Forms.RadioButton rbtChemTermoTask;
    }
}
