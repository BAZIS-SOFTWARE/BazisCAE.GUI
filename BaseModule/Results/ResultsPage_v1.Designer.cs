namespace BaseModule.Results
{
    partial class ResultsPage_v1
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
            this.resultsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.скрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пересчитатьНаУзлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPage1 = new BaseModule.ToolStripPage();
            this.resultsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultsMenuStrip
            // 
            this.resultsMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.resultsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скрытьToolStripMenuItem,
            this.пересчитатьНаУзлыToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.resultsMenuStrip.Name = "resultsMenuStrip";
            this.resultsMenuStrip.Size = new System.Drawing.Size(191, 70);
            // 
            // скрытьToolStripMenuItem
            // 
            this.скрытьToolStripMenuItem.Name = "скрытьToolStripMenuItem";
            this.скрытьToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.скрытьToolStripMenuItem.Text = "Скрыть";
            // 
            // пересчитатьНаУзлыToolStripMenuItem
            // 
            this.пересчитатьНаУзлыToolStripMenuItem.Name = "пересчитатьНаУзлыToolStripMenuItem";
            this.пересчитатьНаУзлыToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.пересчитатьНаУзлыToolStripMenuItem.Text = "Пересчитать на узлы";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // toolStripPage1
            // 
            this.toolStripPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripPage1.Location = new System.Drawing.Point(0, 0);
            this.toolStripPage1.Name = "toolStripPage1";
            this.toolStripPage1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripPage1.Size = new System.Drawing.Size(896, 561);
            this.toolStripPage1.TabIndex = 0;
            // 
            // ResultsPage_v1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripPage1);
            this.Name = "ResultsPage_v1";
            this.Size = new System.Drawing.Size(896, 561);
            this.resultsMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStripPage toolStripPage1;
        private System.Windows.Forms.ContextMenuStrip resultsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem скрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пересчитатьНаУзлыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
    }
}
