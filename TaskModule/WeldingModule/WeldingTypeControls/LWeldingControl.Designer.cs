using BaseModule.ControlsLib.Validation;

namespace TaskModule.WeldingModule.WeldingTypeControls
{
    partial class LWeldingControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LWeldingControl));
            this.txbBeamBottomDiam = new BaseModule.ControlsLib.Validation.TextBoxValidator(this.components);
            this.txbBeamUpperDiam = new BaseModule.ControlsLib.Validation.TextBoxValidator(this.components);
            this.txbPower = new BaseModule.ControlsLib.Validation.TextBoxValidator(this.components);
            this.txbBeamLenght = new BaseModule.ControlsLib.Validation.TextBoxValidator(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbBeamBottomDiam
            // 
            this.txbBeamBottomDiam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBeamBottomDiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbBeamBottomDiam.InputType = BaseModule.ControlsLib.Validation.TXTBoxInputType.Text;
            this.txbBeamBottomDiam.IsValidating = true;
            this.txbBeamBottomDiam.Location = new System.Drawing.Point(228, 108);
            this.txbBeamBottomDiam.Margin = new System.Windows.Forms.Padding(237, 4, 20, 4);
            this.txbBeamBottomDiam.Name = "txbBeamBottomDiam";
            this.txbBeamBottomDiam.Size = new System.Drawing.Size(3973, 23);
            this.txbBeamBottomDiam.TabIndex = 45;
            // 
            // txbBeamUpperDiam
            // 
            this.txbBeamUpperDiam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBeamUpperDiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbBeamUpperDiam.InputType = BaseModule.ControlsLib.Validation.TXTBoxInputType.Text;
            this.txbBeamUpperDiam.IsValidating = true;
            this.txbBeamUpperDiam.Location = new System.Drawing.Point(228, 76);
            this.txbBeamUpperDiam.Margin = new System.Windows.Forms.Padding(237, 4, 20, 4);
            this.txbBeamUpperDiam.Name = "txbBeamUpperDiam";
            this.txbBeamUpperDiam.Size = new System.Drawing.Size(3973, 23);
            this.txbBeamUpperDiam.TabIndex = 44;
            // 
            // txbPower
            // 
            this.txbPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPower.InputType = BaseModule.ControlsLib.Validation.TXTBoxInputType.Text;
            this.txbPower.IsValidating = true;
            this.txbPower.Location = new System.Drawing.Point(228, 12);
            this.txbPower.Margin = new System.Windows.Forms.Padding(237, 12, 20, 4);
            this.txbPower.Name = "txbPower";
            this.txbPower.Size = new System.Drawing.Size(3973, 23);
            this.txbPower.TabIndex = 42;
            // 
            // txbBeamLenght
            // 
            this.txbBeamLenght.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBeamLenght.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbBeamLenght.InputType = BaseModule.ControlsLib.Validation.TXTBoxInputType.Text;
            this.txbBeamLenght.IsValidating = true;
            this.txbBeamLenght.Location = new System.Drawing.Point(228, 44);
            this.txbBeamLenght.Margin = new System.Windows.Forms.Padding(237, 4, 20, 4);
            this.txbBeamLenght.Name = "txbBeamLenght";
            this.txbBeamLenght.Size = new System.Drawing.Size(3973, 23);
            this.txbBeamLenght.TabIndex = 43;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 108);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(168, 17);
            this.label16.TabIndex = 41;
            this.label16.Text = "Диаметр конца (D3), мм";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(13, 78);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(207, 25);
            this.label15.TabIndex = 40;
            this.label15.Text = "Диаметр основания (D2), мм";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(11, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 17);
            this.label1.TabIndex = 38;
            this.label1.Text = "Мощность излучения, Дж";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 48);
            this.label12.Margin = new System.Windows.Forms.Padding(13, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(210, 17);
            this.label12.TabIndex = 39;
            this.label12.Text = "Глубина проплавления (L), мм";
            // 
            // btnInfo
            // 
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.Location = new System.Drawing.Point(15, 135);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(15, 12, 4, 12);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(36, 33);
            this.btnInfo.TabIndex = 46;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // LWeldingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.txbBeamBottomDiam);
            this.Controls.Add(this.txbBeamUpperDiam);
            this.Controls.Add(this.txbPower);
            this.Controls.Add(this.txbBeamLenght);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "LWeldingControl";
            this.Size = new System.Drawing.Size(4086, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBoxValidator txbBeamBottomDiam;
        private TextBoxValidator txbBeamUpperDiam;
        private TextBoxValidator txbPower;
        private TextBoxValidator txbBeamLenght;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnInfo;
    }
}
