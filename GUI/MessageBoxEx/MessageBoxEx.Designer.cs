namespace BazisGUI.MessageBoxEx
{
    partial class MessageBoxEx
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
            this.message = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.messagePanel = new System.Windows.Forms.Panel();
            this.messagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(20, 29);
            this.message.Margin = new System.Windows.Forms.Padding(20, 0, 3, 20);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(49, 13);
            this.message.TabIndex = 0;
            this.message.Text = "message";
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Location = new System.Drawing.Point(3, -1);
            this.title.Margin = new System.Windows.Forms.Padding(3);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(229, 13);
            this.title.TabIndex = 0;
            this.title.Text = "Загрузка данных. Пожалуйста подождите...";
            // 
            // messagePanel
            // 
            this.messagePanel.BackColor = System.Drawing.SystemColors.Control;
            this.messagePanel.Controls.Add(this.message);
            this.messagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messagePanel.Location = new System.Drawing.Point(0, 15);
            this.messagePanel.Margin = new System.Windows.Forms.Padding(0);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(288, 61);
            this.messagePanel.TabIndex = 1;
            // 
            // MessageBoxEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.messagePanel);
            this.Controls.Add(this.title);
            this.Name = "MessageBoxEx";
            this.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.Size = new System.Drawing.Size(288, 76);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MessageBoxEx_Paint);
            this.messagePanel.ResumeLayout(false);
            this.messagePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel messagePanel;
    }
}
