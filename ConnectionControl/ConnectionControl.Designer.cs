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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.txbKey = new System.Windows.Forms.TextBox();
            this.txbPort = new System.Windows.Forms.TextBox();
            this.txbServerAdress = new System.Windows.Forms.TextBox();
            this.rbtNetLic = new System.Windows.Forms.RadioButton();
            this.rbtLocalLic = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ключ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Порт :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ip адресс :";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 164);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 13);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Статус";
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(257, 159);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txbKey
            // 
            this.txbKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbKey.Enabled = false;
            this.txbKey.Location = new System.Drawing.Point(70, 77);
            this.txbKey.Name = "txbKey";
            this.txbKey.Size = new System.Drawing.Size(262, 20);
            this.txbKey.TabIndex = 6;
            this.txbKey.Click += new System.EventHandler(this.txbKey_Click);
            // 
            // txbPort
            // 
            this.txbPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPort.Enabled = false;
            this.txbPort.Location = new System.Drawing.Point(70, 51);
            this.txbPort.Name = "txbPort";
            this.txbPort.Size = new System.Drawing.Size(262, 20);
            this.txbPort.TabIndex = 7;
            // 
            // txbServerAdress
            // 
            this.txbServerAdress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbServerAdress.Enabled = false;
            this.txbServerAdress.Location = new System.Drawing.Point(70, 26);
            this.txbServerAdress.Name = "txbServerAdress";
            this.txbServerAdress.Size = new System.Drawing.Size(262, 20);
            this.txbServerAdress.TabIndex = 8;
            // 
            // rbtNetLic
            // 
            this.rbtNetLic.AutoSize = true;
            this.rbtNetLic.Location = new System.Drawing.Point(94, 3);
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
            this.rbtLocalLic.AutoSize = true;
            this.rbtLocalLic.Location = new System.Drawing.Point(3, 3);
            this.rbtLocalLic.Name = "rbtLocalLic";
            this.rbtLocalLic.Size = new System.Drawing.Size(79, 17);
            this.rbtLocalLic.TabIndex = 5;
            this.rbtLocalLic.TabStop = true;
            this.rbtLocalLic.Text = "локальная";
            this.rbtLocalLic.UseVisualStyleBackColor = true;
            this.rbtLocalLic.CheckedChanged += new System.EventHandler(this.rbt_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Действие :";
            // 
            // cmbAction
            // 
            this.cmbAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Items.AddRange(new object[] {
            "Проверить соединение"});
            this.cmbAction.Location = new System.Drawing.Point(70, 132);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(262, 21);
            this.cmbAction.TabIndex = 16;
            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbAction_SelectedIndexChanged);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.AutoSize = true;
            this.btnSaveSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveSettings.Location = new System.Drawing.Point(205, 103);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(126, 23);
            this.btnSaveSettings.TabIndex = 10;
            this.btnSaveSettings.Text = "Сохранить настройки";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // ConnectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.cmbAction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txbKey);
            this.Controls.Add(this.txbPort);
            this.Controls.Add(this.txbServerAdress);
            this.Controls.Add(this.rbtNetLic);
            this.Controls.Add(this.rbtLocalLic);
            this.MaximumSize = new System.Drawing.Size(0, 192);
            this.MinimumSize = new System.Drawing.Size(343, 192);
            this.Name = "ConnectionControl";
            this.Size = new System.Drawing.Size(343, 192);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txbKey;
        private System.Windows.Forms.TextBox txbPort;
        private System.Windows.Forms.TextBox txbServerAdress;
        private System.Windows.Forms.RadioButton rbtNetLic;
        private System.Windows.Forms.RadioButton rbtLocalLic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}
