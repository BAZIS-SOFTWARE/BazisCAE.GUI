

using System.Windows.Forms;

namespace TaskModule
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
            // TaskPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "TaskPage";
            this.Size = new System.Drawing.Size(713, 495);
            this.Load += new System.EventHandler(this.TaskPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private BaseModule.BasePage basePage1;
        private System.Windows.Forms.ImageList treeNodesImageList;
        //ToolStrip taskToolStrip;
    }
}
