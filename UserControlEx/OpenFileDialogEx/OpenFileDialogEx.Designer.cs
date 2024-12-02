namespace BasicControls.OpenFileDialogEx
{
    partial class OpenFileDialogEx
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
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.chbMergeResults = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chbMergeResults
            // 
            this.chbMergeResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbMergeResults.AutoSize = true;
            this.chbMergeResults.Location = new System.Drawing.Point(108, 240);
            this.chbMergeResults.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.chbMergeResults.Name = "chbMergeResults";
            this.chbMergeResults.Size = new System.Drawing.Size(153, 17);
            this.chbMergeResults.TabIndex = 0;
            this.chbMergeResults.Text = "Пересчитать результаты";
            this.chbMergeResults.UseVisualStyleBackColor = true;
            // 
            // OpenFileDialogEx
            // 
            this.Controls.Add(this.chbMergeResults);
            this.DoubleBuffered = true;
            this.Name = "OpenFileDialogEx";
            this.Size = new System.Drawing.Size(555, 267);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.CheckBox chbMergeResults;
    }
}