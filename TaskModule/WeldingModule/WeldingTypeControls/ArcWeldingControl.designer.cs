namespace TaskModule.WeldingModule.WeldingTypeControls
{
    partial class ArcWeldingControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArcWeldingControl));
            this.btnInfo = new System.Windows.Forms.Button();
            this.voltageTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.weldPoolTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.currentTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInfo
            // 
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.Location = new System.Drawing.Point(11, 84);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(11, 10, 3, 13);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(26, 26);
            this.btnInfo.TabIndex = 54;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // voltageTextBox
            // 
            this.voltageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voltageTextBox.Location = new System.Drawing.Point(178, 36);
            this.voltageTextBox.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.voltageTextBox.Name = "voltageTextBox";
            this.voltageTextBox.Size = new System.Drawing.Size(858, 20);
            this.voltageTextBox.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Напряжение, В";
            // 
            // weldPoolTextBox
            // 
            this.weldPoolTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weldPoolTextBox.Location = new System.Drawing.Point(178, 62);
            this.weldPoolTextBox.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.weldPoolTextBox.Name = "weldPoolTextBox";
            this.weldPoolTextBox.Size = new System.Drawing.Size(858, 20);
            this.weldPoolTextBox.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Ширина шва (L), мм";
            // 
            // currentTextBox
            // 
            this.currentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentTextBox.Location = new System.Drawing.Point(178, 10);
            this.currentTextBox.Margin = new System.Windows.Forms.Padding(178, 15, 15, 3);
            this.currentTextBox.Name = "currentTextBox";
            this.currentTextBox.Size = new System.Drawing.Size(858, 20);
            this.currentTextBox.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Ток, А";
            // 
            // ArcWeldingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.voltageTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.weldPoolTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.currentTextBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ArcWeldingControl";
            this.Size = new System.Drawing.Size(1051, 123);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.TextBox voltageTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox weldPoolTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox currentTextBox;
        private System.Windows.Forms.Label label1;
    }
}
