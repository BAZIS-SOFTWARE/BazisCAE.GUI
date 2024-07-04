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
            this.groupBoxEx1 = new BaseModule.ControlsLib.GroupBoxEx();
            this.txbTest = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.CheckState = false;
            this.groupBoxEx1.IsCheckable = true;
            this.groupBoxEx1.IsExpanded = true;
            this.groupBoxEx1.IsRollable = true;
            this.groupBoxEx1.Location = new System.Drawing.Point(118, 140);
            this.groupBoxEx1.MinimumSize = new System.Drawing.Size(0, 10);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Size = new System.Drawing.Size(252, 135);
            this.groupBoxEx1.TabIndex = 0;
            this.groupBoxEx1.TabStop = false;
            this.groupBoxEx1.Text = "groupBoxEx1";
            this.groupBoxEx1.CheckBoxClickEvent += new System.Action<object>(this.groupBoxEx1_CheckBoxClick);
            // 
            // txbTest
            // 
            this.txbTest.Location = new System.Drawing.Point(436, 255);
            this.txbTest.Name = "txbTest";
            this.txbTest.Size = new System.Drawing.Size(100, 20);
            this.txbTest.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 778);
            this.Controls.Add(this.txbTest);
            this.Controls.Add(this.groupBoxEx1);
            this.Name = "Form1";
            this.Text = "е";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBoxEx groupBoxEx1;
        private System.Windows.Forms.TextBox txbTest;
    }
}

