namespace TestUserControlsEx
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
            this.playerControl1 = new BaseModule.Player.PlayerControl();
            this.SuspendLayout();
            // 
            // playerControl1
            // 
            this.playerControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playerControl1.CheckState = BaseModule.Player.CheckState.start;
            this.playerControl1.CurrentValue = 50;
            this.playerControl1.Location = new System.Drawing.Point(127, 69);
            this.playerControl1.Margin = new System.Windows.Forms.Padding(0);
            this.playerControl1.MinimumSize = new System.Drawing.Size(215, 35);
            this.playerControl1.Name = "playerControl1";
            this.playerControl1.ShowTextValue = true;
            this.playerControl1.Size = new System.Drawing.Size(363, 35);
            this.playerControl1.SliderBarInnerColor = System.Drawing.Color.DarkSlateBlue;
            this.playerControl1.SliderBarOuterColor = System.Drawing.Color.SkyBlue;
            this.playerControl1.SliderElapsedInnerColor = System.Drawing.Color.Chartreuse;
            this.playerControl1.SliderElapsedOuterColor = System.Drawing.Color.DarkGreen;
            this.playerControl1.SpeedValue = 500;
            this.playerControl1.StartValue = 0;
            this.playerControl1.StopValue = 100;
            this.playerControl1.TabIndex = 3;
            this.playerControl1.TextValueColor = System.Drawing.Color.Black;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.playerControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private BaseModule.Player.PlayerControl playerControl1;
    }
}

