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
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.cmbTasksResults = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGroupName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rbGrid = new System.Windows.Forms.RadioButton();
            this.rbResults = new System.Windows.Forms.RadioButton();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSaveBD = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbExtentionType = new System.Windows.Forms.ComboBox();
            this.rbNodes = new System.Windows.Forms.RadioButton();
            this.rbElements = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.richTextBox, 2);
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(136, 34);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(7);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(315, 161);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Tag = "Intervals";
            this.richTextBox.Text = "";
            this.richTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseClick);
            // 
            // cmbTasksResults
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbTasksResults, 2);
            this.cmbTasksResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTasksResults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTasksResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTasksResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbTasksResults.FormattingEnabled = true;
            this.cmbTasksResults.Location = new System.Drawing.Point(136, 5);
            this.cmbTasksResults.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.cmbTasksResults.Name = "cmbTasksResults";
            this.cmbTasksResults.Size = new System.Drawing.Size(315, 21);
            this.cmbTasksResults.Sorted = true;
            this.cmbTasksResults.TabIndex = 0;
            this.cmbTasksResults.Tag = "TaskType";
            this.cmbTasksResults.SelectedIndexChanged += new System.EventHandler(this.cmbTasksResults_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(45, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(45, 8, 40, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 11);
            this.label1.TabIndex = 3;
            this.label1.Text = "Задача";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(30, 80, 10, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Интервалы";
            // 
            // cmbGroupName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbGroupName, 2);
            this.cmbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGroupName.FormattingEnabled = true;
            this.cmbGroupName.Location = new System.Drawing.Point(136, 263);
            this.cmbGroupName.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.cmbGroupName.Name = "cmbGroupName";
            this.cmbGroupName.Size = new System.Drawing.Size(315, 21);
            this.cmbGroupName.TabIndex = 5;
            this.cmbGroupName.Tag = "Group";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 266);
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
            this.tableLayoutPanel1.Controls.Add(this.richTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbTasksResults, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbGrid, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbResults, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnExport, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveBD, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbExtentionType, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cmbGroupName, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.rbNodes, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.rbElements, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.36634F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.63367F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(458, 360);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // rbGrid
            // 
            this.rbGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbGrid.AutoCheck = false;
            this.rbGrid.AutoSize = true;
            this.rbGrid.Location = new System.Drawing.Point(134, 207);
            this.rbGrid.Margin = new System.Windows.Forms.Padding(5);
            this.rbGrid.Name = "rbGrid";
            this.rbGrid.Size = new System.Drawing.Size(161, 17);
            this.rbGrid.TabIndex = 9;
            this.rbGrid.TabStop = true;
            this.rbGrid.Text = "Сетка";
            this.rbGrid.UseVisualStyleBackColor = true;
            this.rbGrid.Click += new System.EventHandler(this.rbGrid_Clicked);
            // 
            // rbResults
            // 
            this.rbResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbResults.AutoCheck = false;
            this.rbResults.AutoSize = true;
            this.rbResults.Location = new System.Drawing.Point(305, 207);
            this.rbResults.Margin = new System.Windows.Forms.Padding(5);
            this.rbResults.Name = "rbResults";
            this.rbResults.Size = new System.Drawing.Size(148, 17);
            this.rbResults.TabIndex = 10;
            this.rbResults.TabStop = true;
            this.rbResults.Text = "Результаты";
            this.rbResults.UseVisualStyleBackColor = true;
            this.rbResults.Click += new System.EventHandler(this.rbResults_Clicked);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(307, 322);
            this.btnExport.Margin = new System.Windows.Forms.Padding(7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(144, 31);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Экспортировать";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSaveBD
            // 
            this.btnSaveBD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBD.Location = new System.Drawing.Point(136, 322);
            this.btnSaveBD.Margin = new System.Windows.Forms.Padding(7);
            this.btnSaveBD.Name = "btnSaveBD";
            this.btnSaveBD.Size = new System.Drawing.Size(157, 31);
            this.btnSaveBD.TabIndex = 11;
            this.btnSaveBD.Text = "Сохранить интервал в БД";
            this.btnSaveBD.UseVisualStyleBackColor = true;
            this.btnSaveBD.Click += new System.EventHandler(this.btnSaveBD_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 294);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Формат экспорта";
            // 
            // cmbExtentionType
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbExtentionType, 2);
            this.cmbExtentionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExtentionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbExtentionType.FormattingEnabled = true;
            this.cmbExtentionType.Location = new System.Drawing.Point(136, 292);
            this.cmbExtentionType.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.cmbExtentionType.Name = "cmbExtentionType";
            this.cmbExtentionType.Size = new System.Drawing.Size(315, 21);
            this.cmbExtentionType.TabIndex = 8;
            this.cmbExtentionType.Tag = "Format";
            // 
            // rbNodes
            // 
            this.rbNodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbNodes.AutoCheck = false;
            this.rbNodes.AutoSize = true;
            this.rbNodes.Location = new System.Drawing.Point(134, 235);
            this.rbNodes.Margin = new System.Windows.Forms.Padding(5);
            this.rbNodes.Name = "rbNodes";
            this.rbNodes.Size = new System.Drawing.Size(161, 17);
            this.rbNodes.TabIndex = 12;
            this.rbNodes.TabStop = true;
            this.rbNodes.Text = "Узлы";
            this.rbNodes.UseVisualStyleBackColor = true;
            this.rbNodes.Click += new System.EventHandler(this.rbNodes_Clicked);
            // 
            // rbElements
            // 
            this.rbElements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbElements.AutoCheck = false;
            this.rbElements.AutoSize = true;
            this.rbElements.Location = new System.Drawing.Point(305, 235);
            this.rbElements.Margin = new System.Windows.Forms.Padding(5);
            this.rbElements.Name = "rbElements";
            this.rbElements.Size = new System.Drawing.Size(148, 17);
            this.rbElements.TabIndex = 13;
            this.rbElements.TabStop = true;
            this.rbElements.Text = "Элементы";
            this.rbElements.UseVisualStyleBackColor = true;
            this.rbElements.Click += new System.EventHandler(this.rbElements_Clicked);
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

        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.ComboBox cmbTasksResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGroupName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbExtentionType;
        private System.Windows.Forms.RadioButton rbGrid;
        private System.Windows.Forms.RadioButton rbResults;
        private System.Windows.Forms.Button btnSaveBD;
        private System.Windows.Forms.RadioButton rbNodes;
        private System.Windows.Forms.RadioButton rbElements;
    }
}
