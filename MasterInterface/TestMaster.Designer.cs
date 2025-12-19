namespace MasterInterface
{
    partial class TestMaster
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
            TableLayoutPanel = new TableLayoutPanel();
            lbl1 = new Label();
            SuspendLayout();
            //
            // TableLayoutPanel 
            //
            TableLayoutPanel.RowCount = 2;
            TableLayoutPanel.ColumnCount = 2;
            TableLayoutPanel.Dock = DockStyle.Fill;
            TableLayoutPanel.Controls.Add(lbl1, 0, 0);
            //
            // lbl1
            //
            lbl1.Text = "TestMaster";
            // 
            // TestMaster
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "TestMaster";
            Size = new Size(800, 450);
            ResumeLayout(false);
        }

        private TableLayoutPanel TableLayoutPanel;
        private Label lbl1;

        #endregion
    }
}
