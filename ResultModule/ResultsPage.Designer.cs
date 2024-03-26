namespace ResultModule
{
    partial class ResultPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultPage));
            this.treeNodesImageList = new System.Windows.Forms.ImageList(this.components);
            this.resultsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.скрытьРезультатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьЗначенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeNodesImageList
            // 
            this.treeNodesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeNodesImageList.ImageStream")));
            this.treeNodesImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeNodesImageList.Images.SetKeyName(0, "CloseFolder.png");
            this.treeNodesImageList.Images.SetKeyName(1, "OpenFolder.png");
            this.treeNodesImageList.Images.SetKeyName(2, "Инфо.bmp");
            this.treeNodesImageList.Images.SetKeyName(3, "NodeObjs.png");
            this.treeNodesImageList.Images.SetKeyName(4, "MeshObjs.png");
            // 
            // resultsMenuStrip
            // 
            this.resultsMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.resultsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скрытьРезультатыToolStripMenuItem,
            this.показатьЗначенияToolStripMenuItem});
            this.resultsMenuStrip.Name = "resultsMenuStrip";
            this.resultsMenuStrip.Size = new System.Drawing.Size(213, 52);
            // 
            // скрытьРезультатыToolStripMenuItem
            // 
            this.скрытьРезультатыToolStripMenuItem.Name = "скрытьРезультатыToolStripMenuItem";
            this.скрытьРезультатыToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.скрытьРезультатыToolStripMenuItem.Text = "Скрыть результаты";
            this.скрытьРезультатыToolStripMenuItem.Click += new System.EventHandler(this.скрытьРезультатыToolStripMenuItem_Click);
            // 
            // показатьЗначенияToolStripMenuItem
            // 
            this.показатьЗначенияToolStripMenuItem.CheckOnClick = true;
            this.показатьЗначенияToolStripMenuItem.Name = "показатьЗначенияToolStripMenuItem";
            this.показатьЗначенияToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.показатьЗначенияToolStripMenuItem.Text = "Показать значения";
            this.показатьЗначенияToolStripMenuItem.Click += new System.EventHandler(this.показатьЗначенияToolStripMenuItem_Click);
            // 
            // ResultPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ResultPage";
            this.Size = new System.Drawing.Size(1193, 687);
            this.Load += new System.EventHandler(this.ResultPage_Load);
            this.resultsMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList treeNodesImageList;
        private System.Windows.Forms.ContextMenuStrip resultsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem скрытьРезультатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьЗначенияToolStripMenuItem;
    }
}
