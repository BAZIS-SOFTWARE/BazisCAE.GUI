namespace ResultModule.Animation
{
    partial class PinnedAnimationControl
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
            this.animationPage = new ResultModule.Animation.AnimationPage();
            this.SuspendLayout();
            // 
            // animationPage
            // 
            this.animationPage.BackColor = System.Drawing.SystemColors.Control;
            this.animationPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animationPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.animationPage.Location = new System.Drawing.Point(0, 15);
            this.animationPage.Margin = new System.Windows.Forms.Padding(0);
            this.animationPage.Name = "animationPage";
            this.animationPage.Size = new System.Drawing.Size(325, 539);
            this.animationPage.TabIndex = 0;
            // 
            // PinnedAnimationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.animationPage);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.Name = "PinnedAnimationControl";
            this.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.Size = new System.Drawing.Size(325, 554);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PinnedTaskAdvisorControl_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PinnedTaskAdvisorControl_MouseClick);
            this.Resize += new System.EventHandler(this.PinnedTaskAdvisorControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public AnimationPage animationPage;
    }
}
