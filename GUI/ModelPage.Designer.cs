namespace BazisGUI
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
            this.SuspendLayout();
            // 
            // navigator
            // 
            this.BasePage.NavigatorControl.Size = new System.Drawing.Size(245, 666);
            // 
            // scenePage
            // 
            this.BasePage.ScenePage.BackColor = System.Drawing.Color.DimGray;
            this.BasePage.ScenePage.Size = new System.Drawing.Size(803, 443);
            // 
            // consoleControl
            // 
            this.BasePage.ConsoleControl.Size = new System.Drawing.Size(803, 218);
            // 
            // ModelPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ModelPage";
            this.BasePage.SelectionGroupColor = System.Drawing.Color.Lime;
            this.Size = new System.Drawing.Size(1065, 671);
            //this.BasePage.DeleteSelectedObjectsEvent += new System.Action(this.ModelPage_DeleteSelectedObjectsEvent);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
