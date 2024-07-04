using BaseModule.ControlsLib;
using BaseModule.ControlsLib.Validation;

namespace TaskModule.WeldingModule.WeldingTypeControls
{
    partial class FSWeldingControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSWeldingControl));
            this.btnInfo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFrictionModule = new BaseModule.ControlsLib.ComboBoxEx(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txbAxisForce = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.txbPinUpperDiam = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.txbPinBottomDiam = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.txbPinLenght = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.txbShoulderDiam = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txbRotSpeed = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cmbYield = new BaseModule.ControlsLib.ComboBoxEx(this.components);
            this.rbtPin = new System.Windows.Forms.RadioButton();
            this.rbtShoulder = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnInfo
            // 
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.Location = new System.Drawing.Point(11, 255);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(11, 10, 3, 10);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(27, 27);
            this.btnInfo.TabIndex = 64;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 207);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Коэффициент трения";
            // 
            // cmbFrictionModule
            // 
            this.cmbFrictionModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFrictionModule.FormattingEnabled = true;
            this.cmbFrictionModule.InputType = ((BaseModule.ControlsLib.CMBInputType)((BaseModule.ControlsLib.CMBInputType.Items | BaseModule.ControlsLib.CMBInputType.Float)));
            this.cmbFrictionModule.IsValidating = true;
            this.cmbFrictionModule.Location = new System.Drawing.Point(171, 202);
            this.cmbFrictionModule.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.cmbFrictionModule.Name = "cmbFrictionModule";
            this.cmbFrictionModule.Size = new System.Drawing.Size(634, 21);
            this.cmbFrictionModule.TabIndex = 62;
            this.cmbFrictionModule.UserRegExCheck = null;
            this.cmbFrictionModule.UserRegExCheckErrorMessage = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Осевое усилие, Н";
            // 
            // txbAxisForce
            // 
            this.txbAxisForce.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAxisForce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbAxisForce.InputType = BaseModule.ControlsLib.TXTBoxInputType.Float;
            this.txbAxisForce.IsValidating = true;
            this.txbAxisForce.Location = new System.Drawing.Point(171, 73);
            this.txbAxisForce.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbAxisForce.Name = "txbAxisForce";
            this.txbAxisForce.Size = new System.Drawing.Size(634, 20);
            this.txbAxisForce.TabIndex = 59;
            this.txbAxisForce.UserRegExCheck = null;
            this.txbAxisForce.UserRegExCheckErrorMessage = null;
            // 
            // txbPinUpperDiam
            // 
            this.txbPinUpperDiam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPinUpperDiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPinUpperDiam.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Float | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbPinUpperDiam.IsValidating = true;
            this.txbPinUpperDiam.Location = new System.Drawing.Point(171, 177);
            this.txbPinUpperDiam.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbPinUpperDiam.Name = "txbPinUpperDiam";
            this.txbPinUpperDiam.Size = new System.Drawing.Size(634, 20);
            this.txbPinUpperDiam.TabIndex = 58;
            this.txbPinUpperDiam.UserRegExCheck = null;
            this.txbPinUpperDiam.UserRegExCheckErrorMessage = null;
            // 
            // txbPinBottomDiam
            // 
            this.txbPinBottomDiam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPinBottomDiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPinBottomDiam.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Float | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbPinBottomDiam.IsValidating = true;
            this.txbPinBottomDiam.Location = new System.Drawing.Point(171, 152);
            this.txbPinBottomDiam.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbPinBottomDiam.Name = "txbPinBottomDiam";
            this.txbPinBottomDiam.Size = new System.Drawing.Size(634, 20);
            this.txbPinBottomDiam.TabIndex = 57;
            this.txbPinBottomDiam.UserRegExCheck = null;
            this.txbPinBottomDiam.UserRegExCheckErrorMessage = null;
            // 
            // txbPinLenght
            // 
            this.txbPinLenght.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPinLenght.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPinLenght.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Float | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbPinLenght.IsValidating = true;
            this.txbPinLenght.Location = new System.Drawing.Point(171, 126);
            this.txbPinLenght.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbPinLenght.Name = "txbPinLenght";
            this.txbPinLenght.Size = new System.Drawing.Size(634, 20);
            this.txbPinLenght.TabIndex = 56;
            this.txbPinLenght.UserRegExCheck = null;
            this.txbPinLenght.UserRegExCheckErrorMessage = null;
            // 
            // txbShoulderDiam
            // 
            this.txbShoulderDiam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbShoulderDiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbShoulderDiam.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Float | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbShoulderDiam.IsValidating = true;
            this.txbShoulderDiam.Location = new System.Drawing.Point(171, 100);
            this.txbShoulderDiam.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.txbShoulderDiam.Name = "txbShoulderDiam";
            this.txbShoulderDiam.Size = new System.Drawing.Size(634, 20);
            this.txbShoulderDiam.TabIndex = 55;
            this.txbShoulderDiam.UserRegExCheck = null;
            this.txbShoulderDiam.UserRegExCheckErrorMessage = null;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 181);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 13);
            this.label16.TabIndex = 54;
            this.label16.Text = "Диаметр конца (D3)";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(8, 155);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(150, 15);
            this.label15.TabIndex = 53;
            this.label15.Text = "Диаметр основания (D2), мм";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "Длина бура (L), мм";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Диаметр плеча (D1), мм";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Скорость вращения, об/cек.";
            // 
            // txbRotSpeed
            // 
            this.txbRotSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRotSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbRotSpeed.InputType = ((BaseModule.ControlsLib.TXTBoxInputType)((BaseModule.ControlsLib.TXTBoxInputType.Float | BaseModule.ControlsLib.TXTBoxInputType.Positive)));
            this.txbRotSpeed.IsValidating = true;
            this.txbRotSpeed.Location = new System.Drawing.Point(171, 48);
            this.txbRotSpeed.Margin = new System.Windows.Forms.Padding(178, 10, 15, 3);
            this.txbRotSpeed.Name = "txbRotSpeed";
            this.txbRotSpeed.Size = new System.Drawing.Size(634, 20);
            this.txbRotSpeed.TabIndex = 50;
            this.txbRotSpeed.UserRegExCheck = null;
            this.txbRotSpeed.UserRegExCheckErrorMessage = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 233);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Предел текучести, МПа";
            // 
            // cmbYield
            // 
            this.cmbYield.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbYield.FormattingEnabled = true;
            this.cmbYield.InputType = ((BaseModule.ControlsLib.CMBInputType)((BaseModule.ControlsLib.CMBInputType.Items | BaseModule.ControlsLib.CMBInputType.Float)));
            this.cmbYield.IsValidating = true;
            this.cmbYield.Location = new System.Drawing.Point(171, 229);
            this.cmbYield.Margin = new System.Windows.Forms.Padding(178, 3, 15, 3);
            this.cmbYield.Name = "cmbYield";
            this.cmbYield.Size = new System.Drawing.Size(634, 21);
            this.cmbYield.TabIndex = 62;
            this.cmbYield.UserRegExCheck = null;
            this.cmbYield.UserRegExCheckErrorMessage = null;
            // 
            // rbtPin
            // 
            this.rbtPin.AutoSize = true;
            this.rbtPin.Location = new System.Drawing.Point(12, 15);
            this.rbtPin.Margin = new System.Windows.Forms.Padding(2);
            this.rbtPin.Name = "rbtPin";
            this.rbtPin.Size = new System.Drawing.Size(98, 17);
            this.rbtPin.TabIndex = 65;
            this.rbtPin.TabStop = true;
            this.rbtPin.Text = "Рабочая часть";
            this.rbtPin.UseVisualStyleBackColor = true;
            this.rbtPin.Click += new System.EventHandler(this.rbt_Click);
            // 
            // rbtShoulder
            // 
            this.rbtShoulder.AutoSize = true;
            this.rbtShoulder.Location = new System.Drawing.Point(107, 15);
            this.rbtShoulder.Margin = new System.Windows.Forms.Padding(2);
            this.rbtShoulder.Name = "rbtShoulder";
            this.rbtShoulder.Size = new System.Drawing.Size(96, 17);
            this.rbtShoulder.TabIndex = 66;
            this.rbtShoulder.TabStop = true;
            this.rbtShoulder.Text = "Опорный бурт";
            this.rbtShoulder.UseVisualStyleBackColor = true;
            this.rbtShoulder.Click += new System.EventHandler(this.rbt_Click);
            // 
            // FSWeldingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.rbtShoulder);
            this.Controls.Add(this.rbtPin);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbYield);
            this.Controls.Add(this.cmbFrictionModule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbAxisForce);
            this.Controls.Add(this.txbPinUpperDiam);
            this.Controls.Add(this.txbPinBottomDiam);
            this.Controls.Add(this.txbPinLenght);
            this.Controls.Add(this.txbShoulderDiam);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txbRotSpeed);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FSWeldingControl";
            this.Size = new System.Drawing.Size(820, 292);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Label label2;
        private ComboBoxEx cmbFrictionModule;
        private System.Windows.Forms.Label label1;
        private TextBoxEx txbAxisForce;
        private TextBoxEx txbPinUpperDiam;
        private TextBoxEx txbPinBottomDiam;
        private TextBoxEx txbPinLenght;
        private TextBoxEx txbShoulderDiam;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private TextBoxEx txbRotSpeed;
        private System.Windows.Forms.Label label5;
        private ComboBoxEx cmbYield;
        private System.Windows.Forms.RadioButton rbtPin;
        private System.Windows.Forms.RadioButton rbtShoulder;
    }
}
