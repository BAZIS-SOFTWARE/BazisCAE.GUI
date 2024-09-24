namespace TaskModule.BasicTaskAdvisor
{
    partial class PinnedTaskAdvisorControl
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
            this.SuspendLayout();
            // 
            // PinnedTaskAdvisorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.Name = "PinnedTaskAdvisorControl";
            this.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.Size = new System.Drawing.Size(625, 383);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PinnedTaskAdvisorControl_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PinnedTaskAdvisorControl_MouseClick);
            this.Resize += new System.EventHandler(this.PinnedTaskAdvisorControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
