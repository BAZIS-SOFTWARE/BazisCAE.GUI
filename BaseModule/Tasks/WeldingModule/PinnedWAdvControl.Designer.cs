namespace TaskModule.BasicTaskAdvisor
{
    partial class PinnedWAdvControl
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
            this.weldingAdvisor = new BaseModule.Tasks.WeldingModule.WeldingAdvisor();
            this.SuspendLayout();
            // 
            // weldingAdvisor1
            // 
            this.weldingAdvisor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.weldingAdvisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weldingAdvisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weldingAdvisor.Location = new System.Drawing.Point(0, 15);
            this.weldingAdvisor.Margin = new System.Windows.Forms.Padding(2);
            this.weldingAdvisor.Name = "weldingAdvisor1";
            this.weldingAdvisor.ProcessType = ProjectInterfaces.Tasks.ProcessType.Welding;
            this.weldingAdvisor.Size = new System.Drawing.Size(627, 370);
            this.weldingAdvisor.TabIndex = 0;
            // 
            // PinnedWAdvControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.weldingAdvisor);
            this.HeaderName = "Постановщик задачи сварки";
            this.Name = "PinnedWAdvControl";
            this.Size = new System.Drawing.Size(627, 385);
            this.ResumeLayout(false);

        }

        #endregion

        private BaseModule.Tasks.WeldingModule.WeldingAdvisor weldingAdvisor;
    }
}
