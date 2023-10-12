namespace ModelModule
{
    partial class SurfaceControl
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
            this.boxSurface = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnBump = new System.Windows.Forms.RadioButton();
            this.rbtnProgressive = new System.Windows.Forms.RadioButton();
            this.rbtnBeta = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.boxSurface.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxSurface
            // 
            this.boxSurface.Controls.Add(this.tableLayoutPanel1);
            this.boxSurface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxSurface.Location = new System.Drawing.Point(0, 0);
            this.boxSurface.Margin = new System.Windows.Forms.Padding(0);
            this.boxSurface.Name = "boxSurface";
            this.boxSurface.Size = new System.Drawing.Size(230, 280);
            this.boxSurface.TabIndex = 1;
            this.boxSurface.TabStop = false;
            this.boxSurface.Text = "Настройки поверхности";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(224, 259);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.rbtnBump);
            this.panel1.Controls.Add(this.rbtnProgressive);
            this.panel1.Controls.Add(this.rbtnBeta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 151);
            this.panel1.TabIndex = 4;
            // 
            // rbtnBump
            // 
            this.rbtnBump.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnBump.AutoSize = true;
            this.rbtnBump.Location = new System.Drawing.Point(27, 88);
            this.rbtnBump.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnBump.Name = "rbtnBump";
            this.rbtnBump.Size = new System.Drawing.Size(172, 20);
            this.rbtnBump.TabIndex = 2;
            this.rbtnBump.Tag = "Bump";
            this.rbtnBump.Text = "Альтернативно слева";
            this.rbtnBump.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnBump.UseVisualStyleBackColor = true;
            // 
            // rbtnProgressive
            // 
            this.rbtnProgressive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnProgressive.AutoSize = true;
            this.rbtnProgressive.Checked = true;
            this.rbtnProgressive.Location = new System.Drawing.Point(27, 32);
            this.rbtnProgressive.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnProgressive.Name = "rbtnProgressive";
            this.rbtnProgressive.Size = new System.Drawing.Size(69, 20);
            this.rbtnProgressive.TabIndex = 1;
            this.rbtnProgressive.TabStop = true;
            this.rbtnProgressive.Tag = "Left";
            this.rbtnProgressive.Text = "Слева";
            this.rbtnProgressive.UseVisualStyleBackColor = true;
            // 
            // rbtnBeta
            // 
            this.rbtnBeta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnBeta.AutoSize = true;
            this.rbtnBeta.Location = new System.Drawing.Point(27, 60);
            this.rbtnBeta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnBeta.Name = "rbtnBeta";
            this.rbtnBeta.Size = new System.Drawing.Size(77, 20);
            this.rbtnBeta.TabIndex = 3;
            this.rbtnBeta.Tag = "Beta";
            this.rbtnBeta.Text = "Справа";
            this.rbtnBeta.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Расположение:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(27, 122);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(180, 20);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Tag = "Bump";
            this.radioButton1.Text = "Альтернативно справа";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 151);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 108);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Число углов:";
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(80, 37);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(35, 20);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "";
            this.radioButton2.Text = "3";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(80, 70);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(35, 20);
            this.radioButton3.TabIndex = 6;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "";
            this.radioButton3.Text = "4";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // SurfaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.boxSurface);
            this.Name = "SurfaceControl";
            this.Size = new System.Drawing.Size(230, 280);
            this.boxSurface.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxSurface;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnBump;
        private System.Windows.Forms.RadioButton rbtnProgressive;
        private System.Windows.Forms.RadioButton rbtnBeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label2;
    }
}
