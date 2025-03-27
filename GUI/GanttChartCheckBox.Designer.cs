using System.Drawing;
using System.Windows.Forms;

namespace BazisGUI
{
    partial class GanttChartCheckBox
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
            splitContainer = new SplitContainer();
            checkedListBox = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(checkedListBox);
            splitContainer.Size = new Size(1502, 891);
            splitContainer.SplitterDistance = 500;
            splitContainer.TabIndex = 0;
            // 
            // checkedListBox
            // 
            checkedListBox.CheckOnClick = true;
            checkedListBox.Dock = DockStyle.Fill;
            checkedListBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkedListBox.FormattingEnabled = true;
            checkedListBox.Location = new Point(0, 0);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(500, 891);
            checkedListBox.TabIndex = 0;
            checkedListBox.SelectedIndexChanged += checkedListBox_SelectedIndexChanged;
            checkedListBox.DoubleClick += checkedListBox_DoubleClick;
            // 
            // GanttChartControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer);
            Name = "GanttChartControl";
            Size = new Size(1502, 891);
            splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer;
        private CheckedListBox checkedListBox;
    }
}
