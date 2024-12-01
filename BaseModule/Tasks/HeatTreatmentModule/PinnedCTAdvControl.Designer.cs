namespace BaseModule.Tasks.HeatTreatmentModule
{
    partial class PinnedCTAdvControl
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
            this.chemicalTreatmentAdvisor1 = new TaskModule.HeatTreatmentModule.ChemicalTreatmentAdvisor();
            this.SuspendLayout();
            // 
            // chemicalTreatmentAdvisor1
            // 
            this.chemicalTreatmentAdvisor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chemicalTreatmentAdvisor1.Location = new System.Drawing.Point(0, 15);
            this.chemicalTreatmentAdvisor1.Margin = new System.Windows.Forms.Padding(0);
            this.chemicalTreatmentAdvisor1.Name = "chemicalTreatmentAdvisor1";
            this.chemicalTreatmentAdvisor1.ProcessType = ProjectInterfaces.Tasks.ProcessType.Welding;
            this.chemicalTreatmentAdvisor1.Size = new System.Drawing.Size(576, 343);
            this.chemicalTreatmentAdvisor1.TabIndex = 0;
            // 
            // PinnedCTAdvControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chemicalTreatmentAdvisor1);
            this.HeaderName = "Постановка задачи диффузии";
            this.Name = "PinnedCTAdvControl";
            this.Size = new System.Drawing.Size(576, 358);
            this.ResumeLayout(false);

        }

        #endregion

        private TaskModule.HeatTreatmentModule.ChemicalTreatmentAdvisor chemicalTreatmentAdvisor1;
    }
}
