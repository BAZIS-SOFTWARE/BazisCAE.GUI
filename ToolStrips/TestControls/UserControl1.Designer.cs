namespace TestControls
{
    partial class UserControl1
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.instrumentToolStrip1 = new ToolStrips.InstrumentToolStrip();
            this.compoToolStrip1 = new ToolStrips.CompoToolStrip();
            this.viewToolStrip1 = new ToolStrips.MeshToolStrip();
            this.displayToolStrip1 = new ToolStrips.DisplayToolStrip();
            this.standartToolStrip1 = new ToolStrips.StandartToolStrip();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.instrumentToolStrip1);
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.compoToolStrip1);
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.standartToolStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1004, 377);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1004, 536);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.viewToolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.displayToolStrip1);
            // 
            // instrumentToolStrip1
            // 
            this.instrumentToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.instrumentToolStrip1.Location = new System.Drawing.Point(139, 0);
            this.instrumentToolStrip1.Name = "instrumentToolStrip1";
            this.instrumentToolStrip1.Size = new System.Drawing.Size(120, 53);
            this.instrumentToolStrip1.TabIndex = 10;
            this.instrumentToolStrip1.Text = "instrumentToolStrip1";
            // 
            // compoToolStrip1
            // 
            this.compoToolStrip1.CanOverflow = false;
            this.compoToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.compoToolStrip1.Location = new System.Drawing.Point(275, 0);
            this.compoToolStrip1.Name = "compoToolStrip1";
            this.compoToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.compoToolStrip1.Size = new System.Drawing.Size(480, 53);
            this.compoToolStrip1.TabIndex = 7;
            this.compoToolStrip1.Text = "compoToolStrip1";
            // 
            // viewToolStrip1
            // 
            this.viewToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.viewToolStrip1.Location = new System.Drawing.Point(3, 0);
            this.viewToolStrip1.Name = "viewToolStrip1";
            this.viewToolStrip1.Size = new System.Drawing.Size(444, 53);
            this.viewToolStrip1.TabIndex = 9;
            this.viewToolStrip1.Text = "viewToolStrip1";
            // 
            // displayToolStrip1
            // 
            this.displayToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.displayToolStrip1.Location = new System.Drawing.Point(526, 0);
            this.displayToolStrip1.Name = "displayToolStrip1";
            this.displayToolStrip1.Size = new System.Drawing.Size(372, 53);
            this.displayToolStrip1.TabIndex = 10;
            this.displayToolStrip1.Text = "Отображение";
            // 
            // standartToolStrip1
            // 
            this.standartToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.standartToolStrip1.Location = new System.Drawing.Point(3, 53);
            this.standartToolStrip1.Name = "standartToolStrip1";
            this.standartToolStrip1.Size = new System.Drawing.Size(192, 53);
            this.standartToolStrip1.TabIndex = 11;
            this.standartToolStrip1.Text = "Стандартные элементы";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1004, 536);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private ToolStrips.InstrumentToolStrip instrumentToolStrip1;
        private ToolStrips.CompoToolStrip compoToolStrip1;
        private ToolStrips.MeshToolStrip viewToolStrip1;
        private ToolStrips.DisplayToolStrip displayToolStrip1;
        private ToolStrips.StandartToolStrip standartToolStrip1;
    }
}
