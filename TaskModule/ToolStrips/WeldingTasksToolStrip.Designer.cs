namespace TaskModule.ToolStrips
{
    partial class WeldingTasksToolStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeldingTasksToolStrip));
            this.btnWelding = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // btnWelding
            // 
            this.btnWelding.AutoSize = false;
            this.btnWelding.CheckOnClick = true;
            this.btnWelding.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnWelding.Image = ((System.Drawing.Image)(resources.GetObject("btnWelding.Image")));
            this.btnWelding.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnWelding.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnWelding.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWelding.Name = "btnWelding";
            this.btnWelding.Size = new System.Drawing.Size(36, 50);
            this.btnWelding.Tag = "0";
            this.btnWelding.Text = "Сварка";
            // 
            // WeldingTasksToolStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnWelding});
            this.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Text = "Задачи";
            this.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TasksToolStrip_ItemClicked);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnWelding;
    }
}
