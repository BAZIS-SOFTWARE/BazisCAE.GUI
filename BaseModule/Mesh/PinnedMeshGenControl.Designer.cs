namespace BazisGUI.Mesh
{
    partial class PinnedMeshGenControl
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
            this.gmshGeneralMeshControl = new global::BazisGUI.Mesh.GMSHGeneralMeshControl();
            this.SuspendLayout();
            // 
            // gmshGeneralMeshControl1
            // 
            this.gmshGeneralMeshControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmshGeneralMeshControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gmshGeneralMeshControl.Location = new System.Drawing.Point(0, 15);
            this.gmshGeneralMeshControl.Margin = new System.Windows.Forms.Padding(0);
            this.gmshGeneralMeshControl.Name = "gmshGeneralMeshControl1";
            this.gmshGeneralMeshControl.Size = new System.Drawing.Size(580, 573);
            this.gmshGeneralMeshControl.TabIndex = 0;
            // 
            // PinnedMeshGenControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gmshGeneralMeshControl);
            this.HeaderName = "Сеточный генератор";
            this.Name = "PinnedMeshGenControl";
            this.Size = new System.Drawing.Size(580, 588);
            this.ResumeLayout(false);

        }

        #endregion

        private GMSHGeneralMeshControl gmshGeneralMeshControl;
    }
}
