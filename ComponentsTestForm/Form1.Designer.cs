using BaseModule.ControlsLib;

namespace ComponentsTestForm
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
            this.components = new System.ComponentModel.Container();
            this.gmshGeneralMeshControl1 = new ModelModule.GMSHGeneralMeshControl();
            this.groupBoxEx1 = new BaseModule.ControlsLib.GroupBoxEx();
            this.textBoxValidator1 = new BaseModule.ControlsLib.TextBoxEx(this.components);
            this.cmbValidator1 = new BaseModule.ControlsLib.ComboBoxEx(this.components);
            this.cmbValidator2 = new BaseModule.ControlsLib.ComboBoxEx(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gmshGeneralMeshControl1
            // 
            this.gmshGeneralMeshControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gmshGeneralMeshControl1.Location = new System.Drawing.Point(45, 11);
            this.gmshGeneralMeshControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gmshGeneralMeshControl1.Name = "gmshGeneralMeshControl1";
            this.gmshGeneralMeshControl1.Size = new System.Drawing.Size(501, 660);
            this.gmshGeneralMeshControl1.TabIndex = 0;
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.CheckState = true;
            this.groupBoxEx1.Controls.Add(this.button1);
            this.groupBoxEx1.Controls.Add(this.cmbValidator2);
            this.groupBoxEx1.Controls.Add(this.textBoxValidator1);
            this.groupBoxEx1.IsCheckable = true;
            this.groupBoxEx1.IsRollable = true;
            this.groupBoxEx1.Location = new System.Drawing.Point(600, 126);
            this.groupBoxEx1.MinimumSize = new System.Drawing.Size(0, 10);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Size = new System.Drawing.Size(200, 157);
            this.groupBoxEx1.TabIndex = 1;
            this.groupBoxEx1.TabStop = false;
            this.groupBoxEx1.Text = "groupBoxEx1";
            // 
            // textBoxValidator1
            // 
            this.textBoxValidator1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxValidator1.InputType = BaseModule.ControlsLib.TXTBoxInputType.Integer;
            this.textBoxValidator1.IsValidating = true;
            this.textBoxValidator1.Location = new System.Drawing.Point(17, 33);
            this.textBoxValidator1.Name = "textBoxValidator1";
            this.textBoxValidator1.Size = new System.Drawing.Size(121, 20);
            this.textBoxValidator1.TabIndex = 2;
            this.textBoxValidator1.UserRegExCheck = null;
            this.textBoxValidator1.UserRegExCheckErrorMessage = "Введите только текст!";
            // 
            // cmbValidator1
            // 
            this.cmbValidator1.FormattingEnabled = true;
            this.cmbValidator1.InputType = BaseModule.ControlsLib.CMBInputType.Items;
            this.cmbValidator1.IsValidating = true;
            this.cmbValidator1.Location = new System.Drawing.Point(665, 310);
            this.cmbValidator1.Name = "cmbValidator1";
            this.cmbValidator1.Size = new System.Drawing.Size(121, 21);
            this.cmbValidator1.TabIndex = 2;
            this.cmbValidator1.UserRegExCheck = null;
            this.cmbValidator1.UserRegExCheckErrorMessage = null;
            // 
            // cmbValidator2
            // 
            this.cmbValidator2.FormattingEnabled = true;
            this.cmbValidator2.InputType = BaseModule.ControlsLib.CMBInputType.Items;
            this.cmbValidator2.IsValidating = true;
            this.cmbValidator2.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.cmbValidator2.Location = new System.Drawing.Point(17, 59);
            this.cmbValidator2.Name = "cmbValidator2";
            this.cmbValidator2.Size = new System.Drawing.Size(121, 21);
            this.cmbValidator2.TabIndex = 3;
            this.cmbValidator2.UserRegExCheck = null;
            this.cmbValidator2.UserRegExCheckErrorMessage = null;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(111, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 778);
            this.Controls.Add(this.cmbValidator1);
            this.Controls.Add(this.groupBoxEx1);
            this.Controls.Add(this.gmshGeneralMeshControl1);
            this.Name = "Form1";
            this.Text = "е";
            this.groupBoxEx1.ResumeLayout(false);
            this.groupBoxEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ModelModule.GMSHGeneralMeshControl gmshGeneralMeshControl1;
        private GroupBoxEx groupBoxEx1;
        private BaseModule.ControlsLib.ComboBoxEx cmbValidator2;
        private BaseModule.ControlsLib.TextBoxEx textBoxValidator1;
        private BaseModule.ControlsLib.ComboBoxEx cmbValidator1;
        private System.Windows.Forms.Button button1;
    }
}

