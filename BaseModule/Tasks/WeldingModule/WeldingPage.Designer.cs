
namespace BaseModule.Tasks.WeldingModule
{
    partial class WeldingPage
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
            ((System.ComponentModel.ISupportInitialize)(this.EmbeddedSplitContainer)).BeginInit();
            this.EmbeddedSplitContainer.Panel1.SuspendLayout();
            this.EmbeddedSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePage
            // 
            this.BasePage.Size = new System.Drawing.Size(1153, 546);
            // 
            // splitContainerEx
            // 
            this.EmbeddedSplitContainer.Size = new System.Drawing.Size(1153, 546);
            // 
            // WeldingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "WeldingPage";
            this.EmbeddedSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EmbeddedSplitContainer)).EndInit();
            this.EmbeddedSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
    }
}
