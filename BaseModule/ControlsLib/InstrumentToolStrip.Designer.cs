namespace BaseModule.ControlsLib
{
    partial class InstrumentToolStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstrumentToolStrip));
            this.btnMakePhoto = new System.Windows.Forms.ToolStripButton();
            this.btnMeasure = new System.Windows.Forms.ToolStripButton();
            this.btnCrossSection = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // btnMakePhoto
            // 
            this.btnMakePhoto.AutoSize = false;
            this.btnMakePhoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMakePhoto.Image = ((System.Drawing.Image)(resources.GetObject("btnMakePhoto.Image")));
            this.btnMakePhoto.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMakePhoto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMakePhoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMakePhoto.Name = "btnMakePhoto";
            this.btnMakePhoto.Size = new System.Drawing.Size(36, 50);
            this.btnMakePhoto.Tag = "2";
            this.btnMakePhoto.Text = "Сделать снимок";
            // 
            // btnMeasure
            // 
            this.btnMeasure.AutoSize = false;
            this.btnMeasure.CheckOnClick = true;
            this.btnMeasure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMeasure.Image = ((System.Drawing.Image)(resources.GetObject("btnMeasure.Image")));
            this.btnMeasure.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMeasure.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMeasure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(36, 50);
            this.btnMeasure.Tag = "0";
            this.btnMeasure.Text = "Измерения";
            // 
            // btnCrossSection
            // 
            this.btnCrossSection.AutoSize = false;
            this.btnCrossSection.CheckOnClick = true;
            this.btnCrossSection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCrossSection.Image = ((System.Drawing.Image)(resources.GetObject("btnCrossSection.Image")));
            this.btnCrossSection.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrossSection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCrossSection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCrossSection.Name = "btnCrossSection";
            this.btnCrossSection.Size = new System.Drawing.Size(36, 50);
            this.btnCrossSection.Tag = "1";
            this.btnCrossSection.Text = "Сделать сечение";
            // 
            // InstrumentToolStrip
            // 
            this.Dock = System.Windows.Forms.DockStyle.None;
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMeasure,
            this.btnCrossSection,
            this.btnMakePhoto});
            this.Text = "Инструменты";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnMakePhoto;
        private System.Windows.Forms.ToolStripButton btnMeasure;
        private System.Windows.Forms.ToolStripButton btnCrossSection;
    }
}
