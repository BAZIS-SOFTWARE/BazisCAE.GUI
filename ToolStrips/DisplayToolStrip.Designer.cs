namespace ToolStrips
{
    partial class DisplayToolStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayToolStrip));
            this.btnNodeNormals = new System.Windows.Forms.ToolStripButton();
            this.btnTitleInfo = new System.Windows.Forms.ToolStripButton();
            this.btnVolumeNodes = new System.Windows.Forms.ToolStripButton();
            this.btnBoundaryContours = new System.Windows.Forms.ToolStripButton();
            this.btnElementsFramesAndSurfaces = new System.Windows.Forms.ToolStripButton();
            this.btnSurfaceNodes = new System.Windows.Forms.ToolStripButton();
            this.btnElementsFrames = new System.Windows.Forms.ToolStripButton();
            this.btnElementsSurfaces = new System.Windows.Forms.ToolStripButton();
            this.btnElementsNormals = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SuspendLayout();
            // 
            // btnNodeNormals
            // 
            this.btnNodeNormals.AutoSize = false;
            this.btnNodeNormals.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNodeNormals.Image = ((System.Drawing.Image)(resources.GetObject("btnNodeNormals.Image")));
            this.btnNodeNormals.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNodeNormals.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNodeNormals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNodeNormals.Name = "btnNodeNormals";
            this.btnNodeNormals.Size = new System.Drawing.Size(36, 50);
            this.btnNodeNormals.Tag = "6";
            this.btnNodeNormals.Text = "Показать нормали узлов";
            // 
            // btnTitleInfo
            // 
            this.btnTitleInfo.AutoSize = false;
            this.btnTitleInfo.CheckOnClick = true;
            this.btnTitleInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTitleInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnTitleInfo.Image")));
            this.btnTitleInfo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTitleInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTitleInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTitleInfo.Name = "btnTitleInfo";
            this.btnTitleInfo.Size = new System.Drawing.Size(36, 50);
            this.btnTitleInfo.Tag = "0";
            this.btnTitleInfo.Text = "О проекте";
            // 
            // btnVolumeNodes
            // 
            this.btnVolumeNodes.AutoSize = false;
            this.btnVolumeNodes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVolumeNodes.Image = ((System.Drawing.Image)(resources.GetObject("btnVolumeNodes.Image")));
            this.btnVolumeNodes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVolumeNodes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnVolumeNodes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVolumeNodes.Name = "btnVolumeNodes";
            this.btnVolumeNodes.Size = new System.Drawing.Size(36, 50);
            this.btnVolumeNodes.Tag = "1";
            this.btnVolumeNodes.Text = "Показать все узлы";
            this.btnVolumeNodes.ToolTipText = "Показать все поверхности";
            // 
            // btnBoundaryContours
            // 
            this.btnBoundaryContours.AutoSize = false;
            this.btnBoundaryContours.CheckOnClick = true;
            this.btnBoundaryContours.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBoundaryContours.Image = ((System.Drawing.Image)(resources.GetObject("btnBoundaryContours.Image")));
            this.btnBoundaryContours.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBoundaryContours.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBoundaryContours.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBoundaryContours.Name = "btnBoundaryContours";
            this.btnBoundaryContours.Size = new System.Drawing.Size(36, 50);
            this.btnBoundaryContours.Tag = "8";
            this.btnBoundaryContours.Text = "Показать контуры модели";
            // 
            // btnElementsFramesAndSurfaces
            // 
            this.btnElementsFramesAndSurfaces.AutoSize = false;
            this.btnElementsFramesAndSurfaces.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnElementsFramesAndSurfaces.Image = ((System.Drawing.Image)(resources.GetObject("btnElementsFramesAndSurfaces.Image")));
            this.btnElementsFramesAndSurfaces.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnElementsFramesAndSurfaces.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnElementsFramesAndSurfaces.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnElementsFramesAndSurfaces.Name = "btnElementsFramesAndSurfaces";
            this.btnElementsFramesAndSurfaces.Size = new System.Drawing.Size(36, 50);
            this.btnElementsFramesAndSurfaces.Tag = "3";
            this.btnElementsFramesAndSurfaces.Text = "Показать поверхности и ребра элементов";
            // 
            // btnSurfaceNodes
            // 
            this.btnSurfaceNodes.AutoSize = false;
            this.btnSurfaceNodes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSurfaceNodes.Image = ((System.Drawing.Image)(resources.GetObject("btnSurfaceNodes.Image")));
            this.btnSurfaceNodes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSurfaceNodes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSurfaceNodes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSurfaceNodes.Name = "btnSurfaceNodes";
            this.btnSurfaceNodes.Size = new System.Drawing.Size(36, 50);
            this.btnSurfaceNodes.Tag = "2";
            this.btnSurfaceNodes.Text = "Показать узлы на открытых поверхностях";
            this.btnSurfaceNodes.ToolTipText = "Показать открытые поверхности";
            // 
            // btnElementsFrames
            // 
            this.btnElementsFrames.AutoSize = false;
            this.btnElementsFrames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnElementsFrames.Image = ((System.Drawing.Image)(resources.GetObject("btnElementsFrames.Image")));
            this.btnElementsFrames.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnElementsFrames.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnElementsFrames.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnElementsFrames.Name = "btnElementsFrames";
            this.btnElementsFrames.Size = new System.Drawing.Size(36, 50);
            this.btnElementsFrames.Tag = "4";
            this.btnElementsFrames.Text = "Показать ребра элементов";
            // 
            // btnElementsSurfaces
            // 
            this.btnElementsSurfaces.AutoSize = false;
            this.btnElementsSurfaces.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnElementsSurfaces.Image = ((System.Drawing.Image)(resources.GetObject("btnElementsSurfaces.Image")));
            this.btnElementsSurfaces.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnElementsSurfaces.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnElementsSurfaces.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnElementsSurfaces.Name = "btnElementsSurfaces";
            this.btnElementsSurfaces.Size = new System.Drawing.Size(36, 50);
            this.btnElementsSurfaces.Tag = "5";
            this.btnElementsSurfaces.Text = "Показать поверхности элементов";
            // 
            // btnElementsNormals
            // 
            this.btnElementsNormals.AutoSize = false;
            this.btnElementsNormals.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnElementsNormals.Image = ((System.Drawing.Image)(resources.GetObject("btnElementsNormals.Image")));
            this.btnElementsNormals.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnElementsNormals.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnElementsNormals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnElementsNormals.Name = "btnElementsNormals";
            this.btnElementsNormals.Size = new System.Drawing.Size(36, 50);
            this.btnElementsNormals.Tag = "7";
            this.btnElementsNormals.Text = "Показать нормали элементов";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // DisplayToolStrip
            // 
            this.Dock = System.Windows.Forms.DockStyle.None;
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTitleInfo,
            this.toolStripSeparator2,
            this.btnVolumeNodes,
            this.btnSurfaceNodes,
            this.toolStripSeparator1,
            this.btnElementsFramesAndSurfaces,
            this.btnElementsFrames,
            this.btnElementsSurfaces,
            this.btnNodeNormals,
            this.btnElementsNormals,
            this.btnBoundaryContours});
            this.Text = "Отображение";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnNodeNormals;
        private System.Windows.Forms.ToolStripButton btnTitleInfo;
        private System.Windows.Forms.ToolStripButton btnVolumeNodes;
        private System.Windows.Forms.ToolStripButton btnBoundaryContours;
        private System.Windows.Forms.ToolStripButton btnElementsFramesAndSurfaces;
        private System.Windows.Forms.ToolStripButton btnSurfaceNodes;
        private System.Windows.Forms.ToolStripButton btnElementsFrames;
        private System.Windows.Forms.ToolStripButton btnElementsSurfaces;
        private System.Windows.Forms.ToolStripButton btnElementsNormals;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
