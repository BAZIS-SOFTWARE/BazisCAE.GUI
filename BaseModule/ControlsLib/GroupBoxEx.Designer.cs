namespace BaseModule.ControlsLib
{
    partial class GroupBoxEx
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
            this.chb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chb
            // 
            this.chb.AutoSize = true;
            this.chb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb.Location = new System.Drawing.Point(0, 0);
            this.chb.Name = "chb";
            this.chb.Size = new System.Drawing.Size(12, 11);
            this.chb.TabIndex = 0;
            this.chb.UseVisualStyleBackColor = true;
            this.chb.Visible = false;
            // 
            // GroupBoxEx
            // 
            this.Controls.Add(this.chb);
            this.MinimumSize = new System.Drawing.Size(0, 10);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GroupBoxEx_MouseClick);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GroupBoxEx_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chb;
    }
}
