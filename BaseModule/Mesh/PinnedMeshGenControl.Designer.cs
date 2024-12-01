namespace BaseModule.Mesh
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
            this.gmshGeneralMeshControl1 = new BaseModule.Mesh.GMSHGeneralMeshControl();
            this.SuspendLayout();
            // 
            // gmshGeneralMeshControl1
            // 
            this.gmshGeneralMeshControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmshGeneralMeshControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gmshGeneralMeshControl1.Location = new System.Drawing.Point(0, 15);
            this.gmshGeneralMeshControl1.Margin = new System.Windows.Forms.Padding(0);
            this.gmshGeneralMeshControl1.Name = "gmshGeneralMeshControl1";
            this.gmshGeneralMeshControl1.Size = new System.Drawing.Size(580, 573);
            this.gmshGeneralMeshControl1.TabIndex = 0;
            // 
            // PinnedMeshGenControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gmshGeneralMeshControl1);
            this.HeaderName = "Сеточный генератор";
            this.Name = "PinnedMeshGenControl";
            this.Size = new System.Drawing.Size(580, 588);
            this.ResumeLayout(false);

        }

        #endregion

        private GMSHGeneralMeshControl gmshGeneralMeshControl1;
    }
}
