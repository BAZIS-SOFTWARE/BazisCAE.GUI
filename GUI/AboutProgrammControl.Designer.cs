namespace BazisGUI
{
    partial class AboutProgrammControl
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutProgrammControl));
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            lblVersion = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            richTextBox = new System.Windows.Forms.RichTextBox();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.41646F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.58354F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            tableLayoutPanel.Controls.Add(label1, 0, 0);
            tableLayoutPanel.Controls.Add(lblVersion, 0, 1);
            tableLayoutPanel.Controls.Add(pictureBox1, 1, 0);
            tableLayoutPanel.Controls.Add(richTextBox, 0, 2);
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(1, 1);
            tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.91057F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.08943F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new System.Drawing.Size(710, 321);
            tableLayoutPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(207, 70);
            label1.TabIndex = 2;
            label1.Text = "ПО BAZISGUI предназначено для формирования расчетных моделей с целью проведения последующих инженерных расчетов.";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            lblVersion.Location = new System.Drawing.Point(0, 70);
            lblVersion.Margin = new System.Windows.Forms.Padding(0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(207, 53);
            lblVersion.TabIndex = 3;
            lblVersion.Text = "Обратная связь \r\nInfo@bazisnet.ru";
            // 
            // pictureBox1
            // 
            tableLayoutPanel.SetColumnSpan(pictureBox1, 2);
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(211, 3);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel.SetRowSpan(pictureBox1, 4);
            pictureBox1.Size = new System.Drawing.Size(495, 315);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // richTextBox
            // 
            richTextBox.BackColor = System.Drawing.SystemColors.Control;
            richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            richTextBox.Location = new System.Drawing.Point(4, 126);
            richTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            richTextBox.Name = "richTextBox";
            richTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            tableLayoutPanel.SetRowSpan(richTextBox, 2);
            richTextBox.Size = new System.Drawing.Size(199, 192);
            richTextBox.TabIndex = 6;
            richTextBox.Text = resources.GetString("richTextBox.Text");
            // 
            // AboutProgrammControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(712, 323);
            Name = "AboutProgrammControl";
            Padding = new System.Windows.Forms.Padding(1);
            Size = new System.Drawing.Size(712, 323);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
