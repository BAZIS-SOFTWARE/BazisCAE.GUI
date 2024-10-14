namespace ResultModule
{
    partial class ExportControl
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cmbTasksResults = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNodeGroupName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbExtentionType = new System.Windows.Forms.ComboBox();
            this.rbGrid = new System.Windows.Forms.RadioButton();
            this.rbResults = new System.Windows.Forms.RadioButton();
            this.btnSaveBD = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.richTextBox1, 2);
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(136, 40);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(7);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(315, 183);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseClick);
            // 
            // cmbTasksResults
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbTasksResults, 2);
            this.cmbTasksResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTasksResults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTasksResults.FormattingEnabled = true;
            this.cmbTasksResults.Location = new System.Drawing.Point(136, 5);
            this.cmbTasksResults.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.cmbTasksResults.Name = "cmbTasksResults";
            this.cmbTasksResults.Size = new System.Drawing.Size(315, 21);
            this.cmbTasksResults.Sorted = true;
            this.cmbTasksResults.TabIndex = 0;
            this.cmbTasksResults.SelectedIndexChanged += new System.EventHandler(this.cmbTasksResults_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(45, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(45, 8, 40, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Задача";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(30, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(30, 90, 30, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Интервалы";
            // 
            // cmbNodeGroupName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbNodeGroupName, 2);
            this.cmbNodeGroupName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbNodeGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeGroupName.FormattingEnabled = true;
            this.cmbNodeGroupName.Location = new System.Drawing.Point(136, 262);
            this.cmbNodeGroupName.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.cmbNodeGroupName.Name = "cmbNodeGroupName";
            this.cmbNodeGroupName.Size = new System.Drawing.Size(315, 21);
            this.cmbNodeGroupName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 265);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Группа результатов";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbTasksResults, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExport, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbExtentionType, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbNodeGroupName, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.rbGrid, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbResults, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveBD, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.34783F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.65218F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(458, 360);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(307, 324);
            this.btnExport.Margin = new System.Windows.Forms.Padding(7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(144, 29);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Экспортировать";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 295);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Формат экспорта";
            // 
            // cmbExtentionType
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbExtentionType, 2);
            this.cmbExtentionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbExtentionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExtentionType.FormattingEnabled = true;
            this.cmbExtentionType.Location = new System.Drawing.Point(136, 291);
            this.cmbExtentionType.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.cmbExtentionType.Name = "cmbExtentionType";
            this.cmbExtentionType.Size = new System.Drawing.Size(315, 21);
            this.cmbExtentionType.TabIndex = 8;
            // 
            // rbGrid
            // 
            this.rbGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbGrid.AutoCheck = false;
            this.rbGrid.AutoSize = true;
            this.rbGrid.Location = new System.Drawing.Point(134, 235);
            this.rbGrid.Margin = new System.Windows.Forms.Padding(5);
            this.rbGrid.Name = "rbGrid";
            this.rbGrid.Size = new System.Drawing.Size(161, 17);
            this.rbGrid.TabIndex = 9;
            this.rbGrid.TabStop = true;
            this.rbGrid.Text = "Сетка";
            this.rbGrid.UseVisualStyleBackColor = true;
            this.rbGrid.CheckedChanged += new System.EventHandler(this.rbGrid_CheckedChanged);
            // 
            // rbResults
            // 
            this.rbResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbResults.AutoCheck = false;
            this.rbResults.AutoSize = true;
            this.rbResults.Location = new System.Drawing.Point(305, 235);
            this.rbResults.Margin = new System.Windows.Forms.Padding(5);
            this.rbResults.Name = "rbResults";
            this.rbResults.Size = new System.Drawing.Size(148, 17);
            this.rbResults.TabIndex = 10;
            this.rbResults.TabStop = true;
            this.rbResults.Text = "Результаты";
            this.rbResults.UseVisualStyleBackColor = true;
            this.rbResults.CheckedChanged += new System.EventHandler(this.rbResults_CheckedChanged);
            // 
            // btnSaveBD
            // 
            this.btnSaveBD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBD.Location = new System.Drawing.Point(136, 324);
            this.btnSaveBD.Margin = new System.Windows.Forms.Padding(7);
            this.btnSaveBD.Name = "btnSaveBD";
            this.btnSaveBD.Size = new System.Drawing.Size(157, 29);
            this.btnSaveBD.TabIndex = 11;
            this.btnSaveBD.Text = "Сохранить интервал в БД";
            this.btnSaveBD.UseVisualStyleBackColor = true;
            this.btnSaveBD.Click += new System.EventHandler(this.btnSaveBD_Click);
            // 
            // ExportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ExportControl";
            this.Size = new System.Drawing.Size(458, 360);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox cmbTasksResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNodeGroupName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbExtentionType;
        private System.Windows.Forms.RadioButton rbGrid;
        private System.Windows.Forms.RadioButton rbResults;
        private System.Windows.Forms.Button btnSaveBD;
    }
}
