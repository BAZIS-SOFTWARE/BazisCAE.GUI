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
            components = new System.ComponentModel.Container();
            generalPanel = new TableLayoutPanel();
            rbtVolume = new RadioButton();
            rbtSurface = new RadioButton();
            rbtCurve = new RadioButton();
            generalPanel.SuspendLayout();
            SuspendLayout();

            // 
            // generalPanel
            // 
            generalPanel.ColumnCount = 1;
            generalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            generalPanel.RowCount = 3;
            //generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.333f));
            //generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.333f));
            //generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.333f));

            generalPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
            generalPanel.Controls.Add(rbtVolume);
            generalPanel.Controls.Add(rbtSurface);
            generalPanel.Controls.Add(rbtCurve);
            generalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            generalPanel.AutoSize = true;
            generalPanel.Location = new System.Drawing.Point(0, 0);
            generalPanel.Name = "generalPanel";
            generalPanel.TabIndex = 0;

            //
            // rbtSet
            //
            rbtVolume.Anchor = AnchorStyles.Left;
            rbtVolume.AutoSize = true;
            rbtVolume.Padding = new Padding(5,0,0,0);
            rbtVolume.Name = "rbtSet";
            rbtVolume.TabIndex = 8;
            rbtVolume.TabStop = true;
            rbtVolume.Text = "Объемы";
            rbtVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            rbtVolume.UseVisualStyleBackColor = true;
            //
            // rbtSurface
            //
            rbtSurface.Anchor = AnchorStyles.Left;
            rbtSurface.AutoSize = true;
            rbtSurface.Padding = new Padding(5, 0, 0, 0);
            rbtSurface.Name = "rbtSurface";
            rbtSurface.TabIndex = 8;
            rbtSurface.TabStop = true;
            rbtSurface.Text = "Поверхности";
            rbtSurface.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            rbtSurface.UseVisualStyleBackColor = true;
            //
            // rbtDirection
            //
            rbtCurve.Anchor = AnchorStyles.Left;
            rbtCurve.AutoSize = true;
            rbtCurve.Padding = new Padding(5, 0, 0, 0);
            rbtCurve.Name = "rbtDirection";
            rbtCurve.TabIndex = 8;
            rbtCurve.TabStop = true;
            rbtCurve.Text = "Кривые";
            rbtCurve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            rbtCurve.UseVisualStyleBackColor = true;


            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(generalPanel);
            Size = new System.Drawing.Size(400, 90);
            generalPanel.ResumeLayout(false);
            generalPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel generalPanel;

        private RadioButton rbtVolume;
        private RadioButton rbtSurface;
        private RadioButton rbtCurve;
    }
}
