using System.Windows.Forms;

namespace BazisGUI.AdvanceSelection.ControlsForSelect
{
    partial class MeshSelect
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
            generalPanel.SuspendLayout();
            SuspendLayout();

            // 
            // generalPanel
            // 
            generalPanel.ColumnCount = 1;
            generalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            generalPanel.RowCount = 5;
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            generalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));

            generalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            generalPanel.AutoSize = true;
            generalPanel.Location = new System.Drawing.Point(0, 0);
            generalPanel.Name = "generalPanel";
            generalPanel.TabIndex = 0;


            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            generalPanel.ResumeLayout(false);
            generalPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel generalPanel;
        private RadioButton rbtSet;
        private RadioButton rbtSurface;
    }
}
