namespace BaseModule.ControlsLib
{
    partial class StandartToolStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StandartToolStrip));
            this.btnCreateNewProject = new System.Windows.Forms.ToolStripButton();
            this.btnOpenProject = new System.Windows.Forms.ToolStripButton();
            this.btnSaveProject = new System.Windows.Forms.ToolStripButton();
            this.btnImportMesh = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // btnCreateNewProject
            // 
            this.btnCreateNewProject.AutoSize = false;
            this.btnCreateNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreateNewProject.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateNewProject.Image")));
            this.btnCreateNewProject.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCreateNewProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCreateNewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateNewProject.Name = "btnCreateNewProject";
            this.btnCreateNewProject.Size = new System.Drawing.Size(36, 50);
            this.btnCreateNewProject.Tag = "0";
            this.btnCreateNewProject.Text = "Создать новый проект";
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.AutoSize = false;
            this.btnOpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenProject.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenProject.Image")));
            this.btnOpenProject.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(36, 50);
            this.btnOpenProject.Tag = "1";
            this.btnOpenProject.Text = "Открыть проект";
            // 
            // btnSaveProject
            // 
            this.btnSaveProject.AutoSize = false;
            this.btnSaveProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveProject.Enabled = false;
            this.btnSaveProject.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveProject.Image")));
            this.btnSaveProject.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSaveProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveProject.Name = "btnSaveProject";
            this.btnSaveProject.Size = new System.Drawing.Size(36, 50);
            this.btnSaveProject.Tag = "2";
            this.btnSaveProject.Text = "Сохранить проект";
            // 
            // btnImportMesh
            // 
            this.btnImportMesh.AutoSize = false;
            this.btnImportMesh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImportMesh.Enabled = false;
            this.btnImportMesh.Image = ((System.Drawing.Image)(resources.GetObject("btnImportMesh.Image")));
            this.btnImportMesh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImportMesh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnImportMesh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportMesh.Name = "btnImportMesh";
            this.btnImportMesh.Size = new System.Drawing.Size(36, 50);
            this.btnImportMesh.Tag = "4";
            this.btnImportMesh.Text = "Импортировать сетку";
            // 
            // StandartToolStrip
            // 
            this.Dock = System.Windows.Forms.DockStyle.None;
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateNewProject,
            this.btnOpenProject,
            this.btnSaveProject,
            this.btnImportMesh});
            this.Text = "Стандартные элементы";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnCreateNewProject;
        private System.Windows.Forms.ToolStripButton btnOpenProject;
        private System.Windows.Forms.ToolStripButton btnSaveProject;
        private System.Windows.Forms.ToolStripButton btnImportMesh;
    }
}
