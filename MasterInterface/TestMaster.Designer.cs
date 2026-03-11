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
            cmbGroups = new ComboBox();
            cmbFunctions = new ComboBox();
            cmbMaterials = new ComboBox();
            cmbConditions = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // cmbGroups
            // 
            cmbGroups.FormattingEnabled = true;
            cmbGroups.Location = new Point(54, 32);
            cmbGroups.Name = "cmbGroups";
            cmbGroups.Size = new Size(215, 23);
            cmbGroups.TabIndex = 0;
            // 
            // cmbFunctions
            // 
            cmbFunctions.FormattingEnabled = true;
            cmbFunctions.Location = new Point(54, 83);
            cmbFunctions.Name = "cmbFunctions";
            cmbFunctions.Size = new Size(215, 23);
            cmbFunctions.TabIndex = 1;
            // 
            // cmbMaterials
            // 
            cmbMaterials.FormattingEnabled = true;
            cmbMaterials.Location = new Point(54, 130);
            cmbMaterials.Name = "cmbMaterials";
            cmbMaterials.Size = new Size(215, 23);
            cmbMaterials.TabIndex = 2;
            // 
            // cmbConditions
            // 
            cmbConditions.FormattingEnabled = true;
            cmbConditions.Location = new Point(54, 184);
            cmbConditions.Name = "cmbConditions";
            cmbConditions.Size = new Size(215, 23);
            cmbConditions.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(194, 279);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TestMaster
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(cmbConditions);
            Controls.Add(cmbMaterials);
            Controls.Add(cmbFunctions);
            Controls.Add(cmbGroups);
            Name = "TestMaster";
            Size = new Size(303, 340);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbGroups;
        private ComboBox cmbFunctions;
        private ComboBox cmbMaterials;
        private ComboBox cmbConditions;
        private Button button1;
    }
}
