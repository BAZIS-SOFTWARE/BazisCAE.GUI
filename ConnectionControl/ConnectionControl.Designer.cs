namespace ConnectionControl
{
    partial class ConnectionControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.txbPort = new System.Windows.Forms.TextBox();
            this.txbServerAdress = new System.Windows.Forms.TextBox();
            this.rbtNetLic = new System.Windows.Forms.RadioButton();
            this.rbtLocalLic = new System.Windows.Forms.RadioButton();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Порт :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ip адресс сервера:";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(54, 148);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 13);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Статус";
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(303, 93);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(144, 24);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txbPort
            // 
            this.txbPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txbPort, 2);
            this.txbPort.Location = new System.Drawing.Point(153, 65);
            this.txbPort.Name = "txbPort";
            this.txbPort.Size = new System.Drawing.Size(294, 20);
            this.txbPort.TabIndex = 7;
            // 
            // txbServerAdress
            // 
            this.txbServerAdress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txbServerAdress, 2);
            this.txbServerAdress.Enabled = false;
            this.txbServerAdress.Location = new System.Drawing.Point(153, 35);
            this.txbServerAdress.Name = "txbServerAdress";
            this.txbServerAdress.Size = new System.Drawing.Size(294, 20);
            this.txbServerAdress.TabIndex = 8;
            // 
            // rbtNetLic
            // 
            this.rbtNetLic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtNetLic.AutoSize = true;
            this.rbtNetLic.Location = new System.Drawing.Point(303, 6);
            this.rbtNetLic.Name = "rbtNetLic";
            this.rbtNetLic.Size = new System.Drawing.Size(66, 17);
            this.rbtNetLic.TabIndex = 4;
            this.rbtNetLic.TabStop = true;
            this.rbtNetLic.Text = "сетевая";
            this.rbtNetLic.UseVisualStyleBackColor = true;
            this.rbtNetLic.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // rbtLocalLic
            // 
            this.rbtLocalLic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtLocalLic.AutoSize = true;
            this.rbtLocalLic.Location = new System.Drawing.Point(153, 6);
            this.rbtLocalLic.Name = "rbtLocalLic";
            this.rbtLocalLic.Size = new System.Drawing.Size(79, 17);
            this.rbtLocalLic.TabIndex = 5;
            this.rbtLocalLic.TabStop = true;
            this.rbtLocalLic.Text = "локальная";
            this.rbtLocalLic.UseVisualStyleBackColor = true;
            this.rbtLocalLic.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.AutoSize = true;
            this.btnSaveSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveSettings.Location = new System.Drawing.Point(153, 93);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(144, 24);
            this.btnSaveSettings.TabIndex = 10;
            this.btnSaveSettings.Text = "Сохранить настройки";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveSettings, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnApply, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rbtLocalLic, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbtNetLic, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txbPort, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txbServerAdress, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAnswer, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(450, 192);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Вид лицензии";
            // 
            // lblAnswer
            // 
            this.lblAnswer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAnswer.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblAnswer, 2);
            this.lblAnswer.Location = new System.Drawing.Point(153, 149);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(13, 13);
            this.lblAnswer.TabIndex = 17;
            this.lblAnswer.Text = "?";
            // 
            // ConnectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(0, 192);
            this.MinimumSize = new System.Drawing.Size(343, 192);
            this.Name = "ConnectionControl";
            this.Size = new System.Drawing.Size(450, 192);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txbPort;
        private System.Windows.Forms.TextBox txbServerAdress;
        private System.Windows.Forms.RadioButton rbtNetLic;
        private System.Windows.Forms.RadioButton rbtLocalLic;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAnswer;
    }
}
