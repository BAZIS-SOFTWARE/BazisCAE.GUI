namespace TaskModule.ToolStrips
{
    partial class HeatTreatmentTasksToolStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeatTreatmentTasksToolStrip));
            this.btnHeatTreatment = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // btnHeatTreatment
            // 
            this.btnHeatTreatment.AutoSize = false;
            this.btnHeatTreatment.CheckOnClick = true;
            this.btnHeatTreatment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHeatTreatment.Image = ((System.Drawing.Image)(resources.GetObject("btnHeatTreatment.Image")));
            this.btnHeatTreatment.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHeatTreatment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnHeatTreatment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHeatTreatment.Name = "btnHeatTreatment";
            this.btnHeatTreatment.Size = new System.Drawing.Size(36, 50);
            this.btnHeatTreatment.Tag = "1";
            this.btnHeatTreatment.Text = "ТО";
            // 
            // HeatTreatmentTasksToolStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHeatTreatment});
            this.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Text = "Задачи";
            this.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TasksToolStrip_ItemClicked);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripButton btnHeatTreatment;
    }
}
