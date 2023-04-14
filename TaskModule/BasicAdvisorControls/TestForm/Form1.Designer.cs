namespace TestAdvisors
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.testControl1 = new BasicAdvisorControls.TestControl();
            this.SuspendLayout();
            // 
            // testControl1
            // 
            this.testControl1.AutoScroll = true;
            this.testControl1.AutoSize = true;
            this.testControl1.CheckCurrentTime = 0F;
            this.testControl1.CheckStartTime = 0F;
            this.testControl1.CheckState = BasicAdvisorControls.CheckState.start;
            this.testControl1.CheckStepTime = 0;
            this.testControl1.CheckStopTime = 0F;
            this.testControl1.CurentSelectedRowInfo = null;
            this.testControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testControl1.Location = new System.Drawing.Point(0, 0);
            this.testControl1.MinimumSize = new System.Drawing.Size(300, 300);
            this.testControl1.Name = "testControl1";
            this.testControl1.Size = new System.Drawing.Size(800, 450);
            this.testControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.testControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BasicAdvisorControls.TestControl testControl1;
    }
}

