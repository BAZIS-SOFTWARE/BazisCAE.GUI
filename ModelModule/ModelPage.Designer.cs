namespace ModelModule
{
    partial class ModelPage
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
            this.toolStripContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1055, 591);
            this.toolStripContainer.Size = new System.Drawing.Size(1055, 671);
            // 
            // consoleControl
            // 
            this.consoleControl.Size = new System.Drawing.Size(794, 188);
            // 
            // scenePage
            // 
            this.scenePage.BackColor = System.Drawing.Color.DimGray;
            this.scenePage.Size = new System.Drawing.Size(794, 388);
            // 
            // navigator
            // 
            this.navigator.Size = new System.Drawing.Size(245, 581);
            // 
            // ModelPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ModelPage";
            this.Size = new System.Drawing.Size(1065, 671);
            this.DeleteSelectedObjectsEvent += new System.Action(this.ModelPage_DeleteSelectedObjectsEvent);
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
