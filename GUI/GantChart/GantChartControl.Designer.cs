namespace BazisGUI.GantChart
{
    partial class cntrГант
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
            dataGridView = new System.Windows.Forms.DataGridView();
            CondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CondTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { CondName, CondTime });
            dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView.Location = new System.Drawing.Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.Size = new System.Drawing.Size(385, 373);
            dataGridView.TabIndex = 0;
            dataGridView.CellPainting += dataGridView_CellPainting;
            dataGridView.SortCompare += dataGridView_SortCompare;
            // 
            // CondName
            // 
            CondName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            CondName.HeaderText = "Условие";
            CondName.Name = "CondName";
            CondName.ReadOnly = true;
            CondName.Width = 78;
            // 
            // CondTime
            // 
            CondTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            CondTime.HeaderText = "Время";
            CondTime.Name = "CondTime";
            CondTime.ReadOnly = true;
            // 
            // cntrГант
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(dataGridView);
            Name = "cntrГант";
            Size = new System.Drawing.Size(385, 373);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CondTime;
    }
}
