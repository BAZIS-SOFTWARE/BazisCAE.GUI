using BaseModule.ControlsLib;
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
            this.txbBeamBottomDiam = new TextBoxEx(this.components);
            this.txbBeamUpperDiam = new TextBoxEx(this.components);
            this.txbPower = new TextBoxEx(this.components);
            this.txbBeamLenght = new TextBoxEx(this.components);
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
            this.txbBeamBottomDiam.InputType = BaseModule.ControlsLib.Validation.TXTBoxInputType.Float;
            this.txbBeamBottomDiam.IsValidating = true;
            this.txbBeamBottomDiam.Location = new System.Drawing.Point(171, 88);
            this.txbBeamBottomDiam.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbBeamBottomDiam.Name = "txbBeamBottomDiam";
            this.txbBeamBottomDiam.Size = new System.Drawing.Size(773, 20);
            this.txbBeamBottomDiam.TabIndex = 45;
            this.txbBeamBottomDiam.UserRegExCheck = null;
            this.txbBeamBottomDiam.UserRegExCheckErrorMessage = null;
            // 
            // txbBeamUpperDiam
            // 
            this.txbBeamUpperDiam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBeamUpperDiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbBeamUpperDiam.InputType = BaseModule.ControlsLib.Validation.TXTBoxInputType.Float;
            this.txbBeamUpperDiam.IsValidating = true;
            this.txbBeamUpperDiam.Location = new System.Drawing.Point(171, 62);
            this.txbBeamUpperDiam.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbBeamUpperDiam.Name = "txbBeamUpperDiam";
            this.txbBeamUpperDiam.Size = new System.Drawing.Size(773, 20);
            this.txbBeamUpperDiam.TabIndex = 44;
            this.txbBeamUpperDiam.UserRegExCheck = null;
            this.txbBeamUpperDiam.UserRegExCheckErrorMessage = null;
            // 
            // txbPower
            // 
            this.txbPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPower.InputType = BaseModule.ControlsLib.Validation.TXTBoxInputType.Float;
            this.txbPower.IsValidating = true;
            this.txbPower.Location = new System.Drawing.Point(171, 10);
            this.txbPower.Margin = new System.Windows.Forms.Padding(178, 10, 15, 3);
            this.txbPower.Name = "txbPower";
            this.txbPower.Size = new System.Drawing.Size(773, 20);
            this.txbPower.TabIndex = 42;
            this.txbPower.UserRegExCheck = null;
            this.txbPower.UserRegExCheckErrorMessage = null;
            // 
            // txbBeamLenght
            // 
            this.txbBeamLenght.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBeamLenght.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbBeamLenght.InputType = BaseModule.ControlsLib.Validation.TXTBoxInputType.Float;
            this.txbBeamLenght.IsValidating = true;
            this.txbBeamLenght.Location = new System.Drawing.Point(171, 36);
            this.txbBeamLenght.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbBeamLenght.Name = "txbBeamLenght";
            this.txbBeamLenght.Size = new System.Drawing.Size(773, 20);
            this.txbBeamLenght.TabIndex = 43;
            this.txbBeamLenght.UserRegExCheck = null;
            this.txbBeamLenght.UserRegExCheckErrorMessage = null;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(131, 13);
            this.label16.TabIndex = 41;
            this.label16.Text = "Диаметр конца (D3), мм";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(10, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(155, 20);
            this.label15.TabIndex = 40;
            this.label15.Text = "Диаметр основания (D2), мм";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Мощность излучения, Дж";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 39);
            this.label12.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Глубина проплавления (L), мм";
            // 
            // btnInfo
            // 
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.Location = new System.Drawing.Point(11, 110);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(11, 10, 3, 10);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(27, 27);
            this.btnInfo.TabIndex = 46;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // LWeldingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Size = new System.Drawing.Size(959, 147);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBoxEx txbBeamBottomDiam;
        private TextBoxEx txbBeamUpperDiam;
        private TextBoxEx txbPower;
        private TextBoxEx txbBeamLenght;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnInfo;
    }
}
