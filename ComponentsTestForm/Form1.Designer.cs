using BaseModule.ControlsLib;

namespace ComponentsTestForm
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
            this.weldingAdvisor1 = new TaskModule.WeldingModule.WeldingAdvisor();
            this.SuspendLayout();
            // 
            // weldingAdvisor1
            // 
            this.weldingAdvisor1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.weldingAdvisor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weldingAdvisor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weldingAdvisor1.Location = new System.Drawing.Point(0, 0);
            this.weldingAdvisor1.Margin = new System.Windows.Forms.Padding(2);
            this.weldingAdvisor1.Name = "weldingAdvisor1";
            this.weldingAdvisor1.ProcessType = ProjectInterfaces.Tasks.ProcessType.Welding;
            this.weldingAdvisor1.Size = new System.Drawing.Size(1241, 778);
            this.weldingAdvisor1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 778);
            this.Controls.Add(this.weldingAdvisor1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private TaskModule.WeldingModule.WeldingAdvisor weldingAdvisor1;
    }
}

