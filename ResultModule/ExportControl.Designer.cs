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
            this.btnExport = new System.Windows.Forms.Button();
            this.cmbTasksResults = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNodeGroupName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(155, 70);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(418, 128);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(453, 328);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(143, 32);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Экспортировать";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cmbTasksResults
            // 
            this.cmbTasksResults.FormattingEnabled = true;
            this.cmbTasksResults.Location = new System.Drawing.Point(155, 48);
            this.cmbTasksResults.Name = "cmbTasksResults";
            this.cmbTasksResults.Size = new System.Drawing.Size(418, 24);
            this.cmbTasksResults.Sorted = true;
            this.cmbTasksResults.TabIndex = 0;
            this.cmbTasksResults.SelectedIndexChanged += new System.EventHandler(this.cmbTasksResults_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Задача";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Интервалы";
            // 
            // cmbNodeGroupName
            // 
            this.cmbNodeGroupName.FormattingEnabled = true;
            this.cmbNodeGroupName.Location = new System.Drawing.Point(155, 217);
            this.cmbNodeGroupName.Name = "cmbNodeGroupName";
            this.cmbNodeGroupName.Size = new System.Drawing.Size(418, 24);
            this.cmbNodeGroupName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Группа результатов";
            // 
            // ExportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNodeGroupName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTasksResults);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.richTextBox1);
            this.Name = "ExportControl";
            this.Size = new System.Drawing.Size(609, 382);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cmbTasksResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNodeGroupName;
        private System.Windows.Forms.Label label3;
    }
}
