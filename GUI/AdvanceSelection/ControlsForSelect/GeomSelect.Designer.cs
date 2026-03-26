using System.Windows.Forms;

namespace BazisGUI.AdvanceSelection.ControlsForSelect
{
    partial class GeomSelect
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
            generalPanel = new TableLayoutPanel();
            rbtVolume = new RadioButton();
            rbtSurface = new RadioButton();
            rbtCurve = new RadioButton();
            generalPanel.SuspendLayout();
            SuspendLayout();
            // 
            // generalPanel
            // 
            generalPanel.AutoSize = true;
            generalPanel.ColumnCount = 1;
            generalPanel.ColumnStyles.Add(new ColumnStyle());
            generalPanel.Controls.Add(rbtVolume);
            generalPanel.Controls.Add(rbtSurface);
            generalPanel.Controls.Add(rbtCurve);
            generalPanel.Dock = DockStyle.Fill;
            generalPanel.Location = new System.Drawing.Point(0, 0);
            generalPanel.Name = "generalPanel";
            generalPanel.RowCount = 3;
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            generalPanel.Size = new System.Drawing.Size(400, 90);
            generalPanel.TabIndex = 0;
            // 
            // rbtVolume
            // 
            rbtVolume.Anchor = AnchorStyles.Left;
            rbtVolume.AutoSize = true;
            rbtVolume.Location = new System.Drawing.Point(3, 5);
            rbtVolume.Name = "rbtVolume";
            rbtVolume.Padding = new Padding(5, 0, 0, 0);
            rbtVolume.Size = new System.Drawing.Size(77, 19);
            rbtVolume.TabIndex = 8;
            rbtVolume.TabStop = true;
            rbtVolume.Text = "Объемы";
            rbtVolume.Checked = true;
            // 
            // rbtSurface
            // 
            rbtSurface.Anchor = AnchorStyles.Left;
            rbtSurface.AutoSize = true;
            rbtSurface.Location = new System.Drawing.Point(3, 35);
            rbtSurface.Name = "rbtSurface";
            rbtSurface.Padding = new Padding(5, 0, 0, 0);
            rbtSurface.Size = new System.Drawing.Size(102, 19);
            rbtSurface.TabIndex = 8;
            rbtSurface.TabStop = true;
            rbtSurface.Text = "Поверхности";
            // 
            // rbtCurve
            // 
            rbtCurve.Anchor = AnchorStyles.Left;
            rbtCurve.AutoSize = true;
            rbtCurve.Location = new System.Drawing.Point(3, 65);
            rbtCurve.Name = "rbtCurve";
            rbtCurve.Padding = new Padding(5, 0, 0, 0);
            rbtCurve.Size = new System.Drawing.Size(72, 19);
            rbtCurve.TabIndex = 8;
            rbtCurve.TabStop = true;
            rbtCurve.Text = "Кривые";
            // 
            // GeomSelect
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(generalPanel);
            Name = "GeomSelect";
            Size = new System.Drawing.Size(225, 90);
            generalPanel.ResumeLayout(false);
            generalPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel generalPanel;

        private RadioButton rbtVolume;
        private RadioButton rbtSurface;
        private RadioButton rbtCurve;
    }
}
