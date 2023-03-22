namespace ConnectionControl
{
    partial class AboutControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblProductKey = new System.Windows.Forms.Label();
            this.lblKeyInfo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLicenseKind = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Лицензия принадлежит :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ключ продукта :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Информация о ключе :";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(156, 19);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(13, 13);
            this.lblCompanyName.TabIndex = 3;
            this.lblCompanyName.Text = "?";
            // 
            // lblProductKey
            // 
            this.lblProductKey.AutoSize = true;
            this.lblProductKey.Location = new System.Drawing.Point(156, 47);
            this.lblProductKey.Name = "lblProductKey";
            this.lblProductKey.Size = new System.Drawing.Size(13, 13);
            this.lblProductKey.TabIndex = 3;
            this.lblProductKey.Text = "?";
            // 
            // lblKeyInfo
            // 
            this.lblKeyInfo.AutoSize = true;
            this.lblKeyInfo.Location = new System.Drawing.Point(156, 71);
            this.lblKeyInfo.Name = "lblKeyInfo";
            this.lblKeyInfo.Size = new System.Drawing.Size(13, 13);
            this.lblKeyInfo.TabIndex = 3;
            this.lblKeyInfo.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Вид лицензии :";
            // 
            // lblLicenseKind
            // 
            this.lblLicenseKind.AutoSize = true;
            this.lblLicenseKind.Location = new System.Drawing.Point(156, 99);
            this.lblLicenseKind.Name = "lblLicenseKind";
            this.lblLicenseKind.Size = new System.Drawing.Size(13, 13);
            this.lblLicenseKind.TabIndex = 3;
            this.lblLicenseKind.Text = "?";
            // 
            // AboutControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLicenseKind);
            this.Controls.Add(this.lblKeyInfo);
            this.Controls.Add(this.lblProductKey);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AboutControl";
            this.Size = new System.Drawing.Size(483, 140);
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblProductKey;
        private System.Windows.Forms.Label lblKeyInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLicenseKind;
    }
}