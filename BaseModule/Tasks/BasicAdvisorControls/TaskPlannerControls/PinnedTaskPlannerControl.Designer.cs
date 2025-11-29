namespace BazisGUI.Tasks.BasicAdvisorControls.TaskPlannerControls
{
    partial class PinnedTaskPlannerControl
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
            this.taskPlannerControl_v21 = new BazisGUI.Tasks.BasicAdvisorControls.TaskPlannerControls.TaskPlannerControl_v2();
            this.SuspendLayout();
            // 
            // taskPlannerControl_v21
            // 
            this.taskPlannerControl_v21.BackColor = System.Drawing.SystemColors.Control;
            this.taskPlannerControl_v21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskPlannerControl_v21.Location = new System.Drawing.Point(0, 15);
            this.taskPlannerControl_v21.Margin = new System.Windows.Forms.Padding(0);
            this.taskPlannerControl_v21.Name = "taskPlannerControl_v21";
            this.taskPlannerControl_v21.Size = new System.Drawing.Size(491, 631);
            this.taskPlannerControl_v21.TabIndex = 0;
            // 
            // PinnedTaskPlannerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.taskPlannerControl_v21);
            this.HeaderName = "Планировщик";
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.Name = "PinnedTaskPlannerControl";
            this.Size = new System.Drawing.Size(491, 646);
            this.ResumeLayout(false);

        }

        #endregion

        private TaskPlannerControl_v2 taskPlannerControl_v21;
    }
}
