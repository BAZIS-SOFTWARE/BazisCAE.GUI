namespace BaseModule.Tasks.HeatTreatmentModule
{
    partial class PinnedHTAdvControl
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
            this.heatTreatmentAdvisor1 = new TaskModule.HeatTreatmentModule.HeatTreatmentAdvisor();
            this.SuspendLayout();
            // 
            // heatTreatmentAdvisor1
            // 
            this.heatTreatmentAdvisor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heatTreatmentAdvisor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heatTreatmentAdvisor1.Location = new System.Drawing.Point(0, 15);
            this.heatTreatmentAdvisor1.Margin = new System.Windows.Forms.Padding(2);
            this.heatTreatmentAdvisor1.Name = "heatTreatmentAdvisor1";
            this.heatTreatmentAdvisor1.ProcessType = ProjectInterfaces.Tasks.ProcessType.Welding;
            this.heatTreatmentAdvisor1.Size = new System.Drawing.Size(587, 376);
            this.heatTreatmentAdvisor1.TabIndex = 0;
            // 
            // PinnedHTAdvControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.heatTreatmentAdvisor1);
            this.HeaderName = "Постановка задачи ТО";
            this.Name = "PinnedHTAdvControl";
            this.ResumeLayout(false);

        }

        #endregion

        private TaskModule.HeatTreatmentModule.HeatTreatmentAdvisor heatTreatmentAdvisor1;
    }
}
