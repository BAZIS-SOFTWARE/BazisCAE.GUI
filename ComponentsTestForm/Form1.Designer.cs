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
            this.gmshGeneralMeshControl1 = new ModelModule.GMSHGeneralMeshControl();
            this.groupBoxEx1 = new BaseModule.ControlsLib.GroupBoxEx();
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
            this.groupBoxEx1.IsCheckable = true;
            this.groupBoxEx1.IsRollable = true;
            this.groupBoxEx1.Location = new System.Drawing.Point(600, 126);
            this.groupBoxEx1.MinimumSize = new System.Drawing.Size(0, 10);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Size = new System.Drawing.Size(200, 100);
            this.groupBoxEx1.TabIndex = 1;
            this.groupBoxEx1.TabStop = false;
            this.groupBoxEx1.Text = "groupBoxEx1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 778);
            this.Controls.Add(this.groupBoxEx1);
            this.Controls.Add(this.gmshGeneralMeshControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ModelModule.GMSHGeneralMeshControl gmshGeneralMeshControl1;
        private GroupBoxEx groupBoxEx1;
    }
}

