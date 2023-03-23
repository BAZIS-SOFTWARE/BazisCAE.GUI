namespace ToolStrips
{
    partial class MeshToolStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeshToolStrip));
            this.btnBoundaryElements2D = new System.Windows.Forms.ToolStripButton();
            this.btnMeshGenerator = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // btnBoundaryElements2D
            // 
            this.btnBoundaryElements2D.AutoSize = false;
            this.btnBoundaryElements2D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBoundaryElements2D.Image = ((System.Drawing.Image)(resources.GetObject("btnBoundaryElements2D.Image")));
            this.btnBoundaryElements2D.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBoundaryElements2D.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBoundaryElements2D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBoundaryElements2D.Name = "btnBoundaryElements2D";
            this.btnBoundaryElements2D.Size = new System.Drawing.Size(36, 50);
            this.btnBoundaryElements2D.Tag = "0";
            this.btnBoundaryElements2D.Text = "Создать 2D элементы на поверхности";
            // 
            // btnMeshGenerator
            // 
            this.btnMeshGenerator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMeshGenerator.Image = ((System.Drawing.Image)(resources.GetObject("btnMeshGenerator.Image")));
            this.btnMeshGenerator.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMeshGenerator.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMeshGenerator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMeshGenerator.Name = "btnMeshGenerator";
            this.btnMeshGenerator.Size = new System.Drawing.Size(36, 22);
            this.btnMeshGenerator.Tag = "1";
            this.btnMeshGenerator.Text = "Генератор сетки";
            // 
            // MeshToolStrip
            // 
            this.Dock = System.Windows.Forms.DockStyle.None;
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBoundaryElements2D,
            this.btnMeshGenerator});
            this.Text = "Сетка";
            this.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MeshToolStrip_ItemClicked);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnBoundaryElements2D;
        private System.Windows.Forms.ToolStripButton btnMeshGenerator;
    }
}
