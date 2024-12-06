

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
            this.taskMenuStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.удалитьToolStripMenuItem});
            this.taskMenuStrip.Name = "taskMenuStrip";
            this.taskMenuStrip.Size = new System.Drawing.Size(119, 26);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // TaskPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TaskPage";
            this.Size = new System.Drawing.Size(1163, 612);
            this.ChangedGroupNameEvent += new System.Action(this.TaskPage_ChangedGroupNameEvent);
            this.CreatedMeshGroupEvent += new System.Action(this.TaskPage_CreatedMeshGroupEvent);
            this.DeleteAllGroupsEvent += new System.Action(this.TaskPage_DeleteAllGroupsEvent);
            this.DeleteGroupEvent += new System.Action(this.TaskPage_DeleteGroupEvent);
            this.DeleteObjectsEvent += new System.Action(this.TaskPage_DeleteGroupEvent);
            this.DeleteSelectedObjectsEvent += new System.Action(this.TaskPage_DeleteGroupEvent);
            this.taskMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList treeNodesImageList;
        private ContextMenuStrip taskMenuStrip;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        //ToolStrip taskToolStrip;
    }
}
