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
            this.скрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пересчитатьНаУзлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigator
            // 
            this.BasePage.NavigatorControl.Size = new System.Drawing.Size(205, 553);
            // 
            // scenePage
            // 
            this.BasePage.ScenePage.Size = new System.Drawing.Size(673, 367);
            // 
            // consoleControl
            // 
            this.BasePage.ConsoleControl.Size = new System.Drawing.Size(673, 181);
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
            this.скрытьToolStripMenuItem.Click += new System.EventHandler(this.скрытьРезультатыToolStripMenuItem_Click);
            // 
            // пересчитатьНаУзлыToolStripMenuItem
            // 
            this.пересчитатьНаУзлыToolStripMenuItem.Name = "пересчитатьНаУзлыToolStripMenuItem";
            this.пересчитатьНаУзлыToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.пересчитатьНаУзлыToolStripMenuItem.Text = "Пересчитать на узлы";
            this.пересчитатьНаУзлыToolStripMenuItem.Click += new System.EventHandler(this.пересчитатьНаУзлыToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // ResultPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ResultPage";
            this.Size = new System.Drawing.Size(895, 558);
            this.Load += new System.EventHandler(this.ResultPage_Load);
            this.resultsMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList treeNodesImageList;
        private System.Windows.Forms.ContextMenuStrip resultsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem скрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пересчитатьНаУзлыToolStripMenuItem;
    }
}
