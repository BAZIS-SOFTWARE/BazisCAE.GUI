using BaseModule.Tasks.DataBases;

namespace DataBasesForm
{
    partial class DataBasesForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialsDataBasePage1 = new MaterialsDataBasePage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.functionDataBasePage1 = new FunctionDataBasePage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialsDataBasePage1
            // 
            this.materialsDataBasePage1.DataExtension = null;
            this.materialsDataBasePage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialsDataBasePage1.LabelEditFlag = false;
            this.materialsDataBasePage1.Location = new System.Drawing.Point(3, 3);
            this.materialsDataBasePage1.Margin = new System.Windows.Forms.Padding(1);
            this.materialsDataBasePage1.Name = "materialsDataBasePage1";
            this.materialsDataBasePage1.Size = new System.Drawing.Size(702, 388);
            this.materialsDataBasePage1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(716, 420);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.materialsDataBasePage1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(708, 394);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Материалы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.functionDataBasePage1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(708, 394);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Функции";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // functionDataBasePage1
            // 
            this.functionDataBasePage1.DataExtension = null;
            this.functionDataBasePage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.functionDataBasePage1.LabelEditFlag = false;
            this.functionDataBasePage1.Location = new System.Drawing.Point(3, 3);
            this.functionDataBasePage1.Margin = new System.Windows.Forms.Padding(1);
            this.functionDataBasePage1.Name = "functionDataBasePage1";
            this.functionDataBasePage1.Size = new System.Drawing.Size(702, 388);
            this.functionDataBasePage1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 420);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialsDataBasePage materialsDataBasePage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private FunctionDataBasePage functionDataBasePage1;
    }
}

