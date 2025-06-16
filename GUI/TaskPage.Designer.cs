

using System.Windows.Forms;

namespace BazisGUI
{
    partial class TaskPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskPage));
            this.treeNodesImageList = new System.Windows.Forms.ImageList(this.components);
            this.taskMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagram_gantt_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.материалToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закреплениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нагрузкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нагревToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.средаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx)).BeginInit();
            this.splitContainerEx.Panel1.SuspendLayout();
            this.splitContainerEx.SuspendLayout();
            this.taskMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerEx
            // 
            this.splitContainerEx.Size = new System.Drawing.Size(1153, 522);
            this.splitContainerEx.SplitterDistance = 1118;
            // 
            // basePage
            // 
            this.basePage.Size = new System.Drawing.Size(1118, 522);
            // 
            // treeNodesImageList
            // 
            this.treeNodesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeNodesImageList.ImageStream")));
            this.treeNodesImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeNodesImageList.Images.SetKeyName(0, "CloseFolder.png");
            this.treeNodesImageList.Images.SetKeyName(1, "OpenFolder.png");
            this.treeNodesImageList.Images.SetKeyName(2, "Инфо.bmp");
            this.treeNodesImageList.Images.SetKeyName(3, "Материалы.bmp");
            this.treeNodesImageList.Images.SetKeyName(4, "Среда.bmp");
            this.treeNodesImageList.Images.SetKeyName(5, "Нагрев.bmp");
            this.treeNodesImageList.Images.SetKeyName(6, "Закрепление.bmp");
            this.treeNodesImageList.Images.SetKeyName(7, "Нагрузки.bmp");
            this.treeNodesImageList.Images.SetKeyName(8, "CompInfo.png");
            // 
            // taskMenuStrip
            // 
            this.taskMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.taskMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem,
            this.diagram_gantt_toolStripMenuItem,
            this.добавитьToolStripMenuItem,
            this.расчетToolStripMenuItem});
            this.taskMenuStrip.Name = "taskMenuStrip";
            this.taskMenuStrip.Size = new System.Drawing.Size(214, 114);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // diagram_gantt_toolStripMenuItem
            // 
            this.diagram_gantt_toolStripMenuItem.Name = "diagram_gantt_toolStripMenuItem";
            this.diagram_gantt_toolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.diagram_gantt_toolStripMenuItem.Text = "Показать на диаграммме";
            this.diagram_gantt_toolStripMenuItem.Click += new System.EventHandler(this.diagram_gantt_toolStripMenuItem_Click);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.материалToolStripMenuItem,
            this.закреплениеToolStripMenuItem,
            this.нагрузкаToolStripMenuItem,
            this.нагревToolStripMenuItem,
            this.средаToolStripMenuItem});
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // материалToolStripMenuItem
            // 
            this.материалToolStripMenuItem.Name = "материалToolStripMenuItem";
            this.материалToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.материалToolStripMenuItem.Text = "Материал";
            this.материалToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Navigator_AddPhysicalData);
            // 
            // закреплениеToolStripMenuItem
            // 
            this.закреплениеToolStripMenuItem.Name = "закреплениеToolStripMenuItem";
            this.закреплениеToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.закреплениеToolStripMenuItem.Text = "Закрепление";
            this.закреплениеToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Navigator_AddPhysicalData);
            // 
            // нагрузкаToolStripMenuItem
            // 
            this.нагрузкаToolStripMenuItem.Name = "нагрузкаToolStripMenuItem";
            this.нагрузкаToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.нагрузкаToolStripMenuItem.Text = "Нагрузка";
            this.нагрузкаToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Navigator_AddPhysicalData);
            // 
            // нагревToolStripMenuItem
            // 
            this.нагревToolStripMenuItem.Name = "нагревToolStripMenuItem";
            this.нагревToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.нагревToolStripMenuItem.Text = "Нагрев";
            this.нагревToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Navigator_AddPhysicalData);
            // 
            // средаToolStripMenuItem
            // 
            this.средаToolStripMenuItem.Name = "средаToolStripMenuItem";
            this.средаToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.средаToolStripMenuItem.Text = "Среда";
            this.средаToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Navigator_AddPhysicalData);
            // 
            // расчетToolStripMenuItem
            // 
            this.расчетToolStripMenuItem.Name = "расчетToolStripMenuItem";
            this.расчетToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.расчетToolStripMenuItem.Text = "Расчет";
            this.расчетToolStripMenuItem.Click += new System.EventHandler(this.расчетToolStripMenuItem_Click);
            // 
            // TaskPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TaskPage";
            this.Size = new System.Drawing.Size(1163, 612);
            this.splitContainerEx.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEx)).EndInit();
            this.splitContainerEx.ResumeLayout(false);
            this.taskMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList treeNodesImageList;
        private ContextMenuStrip taskMenuStrip;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ToolStripMenuItem diagram_gantt_toolStripMenuItem;
        private ToolStripMenuItem добавитьToolStripMenuItem;
        private ToolStripMenuItem материалToolStripMenuItem;
        private ToolStripMenuItem закреплениеToolStripMenuItem;
        private ToolStripMenuItem нагрузкаToolStripMenuItem;
        private ToolStripMenuItem нагревToolStripMenuItem;
        private ToolStripMenuItem средаToolStripMenuItem;
        private ToolStripMenuItem расчетToolStripMenuItem;
        //ToolStrip taskToolStrip;
    }
}
