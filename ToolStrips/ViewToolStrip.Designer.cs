namespace ToolStrips
{
    partial class ViewToolStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewToolStrip));
            this.btnSetPlaneXY = new System.Windows.Forms.ToolStripButton();
            this.btnSetPlaneXZ = new System.Windows.Forms.ToolStripButton();
            this.btnSetPlaneYZ = new System.Windows.Forms.ToolStripButton();
            this.btnRotX = new System.Windows.Forms.ToolStripButton();
            this.btnRotY = new System.Windows.Forms.ToolStripButton();
            this.btnFitMesh = new System.Windows.Forms.ToolStripButton();
            this.btnRotZ = new System.Windows.Forms.ToolStripButton();
            this.btnRotHor90 = new System.Windows.Forms.ToolStripButton();
            this.btnRotVer90 = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // btnSetPlaneXY
            // 
            this.btnSetPlaneXY.AutoSize = false;
            this.btnSetPlaneXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetPlaneXY.Image = ((System.Drawing.Image)(resources.GetObject("btnSetPlaneXY.Image")));
            this.btnSetPlaneXY.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetPlaneXY.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSetPlaneXY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetPlaneXY.Name = "btnSetPlaneXY";
            this.btnSetPlaneXY.Size = new System.Drawing.Size(36, 50);
            this.btnSetPlaneXY.Tag = "0";
            this.btnSetPlaneXY.Text = "Плоскость XY";
            // 
            // btnSetPlaneXZ
            // 
            this.btnSetPlaneXZ.AutoSize = false;
            this.btnSetPlaneXZ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetPlaneXZ.Image = ((System.Drawing.Image)(resources.GetObject("btnSetPlaneXZ.Image")));
            this.btnSetPlaneXZ.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetPlaneXZ.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSetPlaneXZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetPlaneXZ.Name = "btnSetPlaneXZ";
            this.btnSetPlaneXZ.Size = new System.Drawing.Size(36, 50);
            this.btnSetPlaneXZ.Tag = "1";
            this.btnSetPlaneXZ.Text = "Плоскость XZ";
            // 
            // btnSetPlaneYZ
            // 
            this.btnSetPlaneYZ.AutoSize = false;
            this.btnSetPlaneYZ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetPlaneYZ.Image = ((System.Drawing.Image)(resources.GetObject("btnSetPlaneYZ.Image")));
            this.btnSetPlaneYZ.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetPlaneYZ.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSetPlaneYZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetPlaneYZ.Name = "btnSetPlaneYZ";
            this.btnSetPlaneYZ.Size = new System.Drawing.Size(36, 50);
            this.btnSetPlaneYZ.Tag = "2";
            this.btnSetPlaneYZ.Text = "Плоскость YZ";
            // 
            // btnRotX
            // 
            this.btnRotX.AutoSize = false;
            this.btnRotX.CheckOnClick = true;
            this.btnRotX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRotX.Image = ((System.Drawing.Image)(resources.GetObject("btnRotX.Image")));
            this.btnRotX.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRotX.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRotX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRotX.Name = "btnRotX";
            this.btnRotX.Size = new System.Drawing.Size(36, 50);
            this.btnRotX.Tag = "3";
            this.btnRotX.Text = "Вращение вокруг X";
            // 
            // btnRotY
            // 
            this.btnRotY.AutoSize = false;
            this.btnRotY.CheckOnClick = true;
            this.btnRotY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRotY.Image = ((System.Drawing.Image)(resources.GetObject("btnRotY.Image")));
            this.btnRotY.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRotY.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRotY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRotY.Name = "btnRotY";
            this.btnRotY.Size = new System.Drawing.Size(36, 50);
            this.btnRotY.Tag = "4";
            this.btnRotY.Text = "Вращение вокруг Y";
            // 
            // btnFitMesh
            // 
            this.btnFitMesh.AutoSize = false;
            this.btnFitMesh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFitMesh.Image = ((System.Drawing.Image)(resources.GetObject("btnFitMesh.Image")));
            this.btnFitMesh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFitMesh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFitMesh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFitMesh.Name = "btnFitMesh";
            this.btnFitMesh.Size = new System.Drawing.Size(36, 50);
            this.btnFitMesh.Tag = "8";
            this.btnFitMesh.Text = "вписать модель в экран";
            this.btnFitMesh.ToolTipText = "Вписать модель в экран";
            // 
            // btnRotZ
            // 
            this.btnRotZ.AutoSize = false;
            this.btnRotZ.CheckOnClick = true;
            this.btnRotZ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRotZ.Image = ((System.Drawing.Image)(resources.GetObject("btnRotZ.Image")));
            this.btnRotZ.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRotZ.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRotZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRotZ.Name = "btnRotZ";
            this.btnRotZ.Size = new System.Drawing.Size(36, 50);
            this.btnRotZ.Tag = "5";
            this.btnRotZ.Text = "Вращение вокруг Z";
            // 
            // btnRotHor90
            // 
            this.btnRotHor90.AutoSize = false;
            this.btnRotHor90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRotHor90.Image = ((System.Drawing.Image)(resources.GetObject("btnRotHor90.Image")));
            this.btnRotHor90.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRotHor90.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRotHor90.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRotHor90.Name = "btnRotHor90";
            this.btnRotHor90.Size = new System.Drawing.Size(36, 50);
            this.btnRotHor90.Tag = "6";
            this.btnRotHor90.Text = "Повернуть на 90 горизонтально";
            // 
            // btnRotVer90
            // 
            this.btnRotVer90.AutoSize = false;
            this.btnRotVer90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRotVer90.Image = ((System.Drawing.Image)(resources.GetObject("btnRotVer90.Image")));
            this.btnRotVer90.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRotVer90.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRotVer90.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRotVer90.Name = "btnRotVer90";
            this.btnRotVer90.Size = new System.Drawing.Size(36, 50);
            this.btnRotVer90.Tag = "7";
            this.btnRotVer90.Text = "Повернуть на 90 вертикально";
            // 
            // ViewToolStrip
            // 
            this.Dock = System.Windows.Forms.DockStyle.None;
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSetPlaneXY,
            this.btnSetPlaneXZ,
            this.btnSetPlaneYZ,
            this.btnRotX,
            this.btnRotY,
            this.btnRotZ,
            this.btnRotHor90,
            this.btnRotVer90,
            this.btnFitMesh});
            this.Text = "Вид";
            this.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ViewToolStrip_ItemClicked);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnSetPlaneXY;
        private System.Windows.Forms.ToolStripButton btnSetPlaneXZ;
        private System.Windows.Forms.ToolStripButton btnSetPlaneYZ;
        private System.Windows.Forms.ToolStripButton btnRotX;
        private System.Windows.Forms.ToolStripButton btnRotY;
        private System.Windows.Forms.ToolStripButton btnFitMesh;
        private System.Windows.Forms.ToolStripButton btnRotZ;
        private System.Windows.Forms.ToolStripButton btnRotHor90;
        private System.Windows.Forms.ToolStripButton btnRotVer90;
    }
}
