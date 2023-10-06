namespace BazisGUI.SettingsControl
{
    partial class SettingsControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chbLighting = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelBackGroundColor = new System.Windows.Forms.Panel();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.panelSelectionColor = new System.Windows.Forms.Panel();
            this.chbTransparency = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.lblSolverPath = new System.Windows.Forms.Label();
            this.btnBackGroundColor = new System.Windows.Forms.Button();
            this.btnSelectGroupColor = new System.Windows.Forms.Button();
            this.panelSelectionGroupColor = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.21161F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.78839F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 302);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(392, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки сцены";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.44296F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.55704F));
            this.tableLayoutPanel2.Controls.Add(this.btnSelectColor, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelSelectionColor, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.chbLighting, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.chbTransparency, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnBackGroundColor, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelBackGroundColor, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnSelectGroupColor, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panelSelectionGroupColor, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(384, 170);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // chbLighting
            // 
            this.chbLighting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbLighting.AutoSize = true;
            this.chbLighting.Location = new System.Drawing.Point(310, 144);
            this.chbLighting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbLighting.Name = "chbLighting";
            this.chbLighting.Size = new System.Drawing.Size(18, 17);
            this.chbLighting.TabIndex = 8;
            this.chbLighting.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Освещение";
            // 
            // panelBackGroundColor
            // 
            this.panelBackGroundColor.BackColor = System.Drawing.Color.White;
            this.panelBackGroundColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackGroundColor.Location = new System.Drawing.Point(259, 72);
            this.panelBackGroundColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelBackGroundColor.Name = "panelBackGroundColor";
            this.panelBackGroundColor.Size = new System.Drawing.Size(121, 26);
            this.panelBackGroundColor.TabIndex = 4;
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.AutoSize = true;
            this.btnSelectColor.Location = new System.Drawing.Point(4, 4);
            this.btnSelectColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSelectColor.Size = new System.Drawing.Size(247, 26);
            this.btnSelectColor.TabIndex = 0;
            this.btnSelectColor.Text = "выбрать цвет выделения объектов";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
            // 
            // panelSelectionColor
            // 
            this.panelSelectionColor.BackColor = System.Drawing.Color.LawnGreen;
            this.panelSelectionColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSelectionColor.Location = new System.Drawing.Point(259, 4);
            this.panelSelectionColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelSelectionColor.Name = "panelSelectionColor";
            this.panelSelectionColor.Size = new System.Drawing.Size(121, 26);
            this.panelSelectionColor.TabIndex = 3;
            // 
            // chbTransparency
            // 
            this.chbTransparency.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbTransparency.AutoSize = true;
            this.chbTransparency.Location = new System.Drawing.Point(310, 110);
            this.chbTransparency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbTransparency.Name = "chbTransparency";
            this.chbTransparency.Size = new System.Drawing.Size(18, 17);
            this.chbTransparency.TabIndex = 5;
            this.chbTransparency.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Прозрачность";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(268, 272);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 205);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(392, 59);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки решателя";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblSolverPath, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(384, 36);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.AutoEllipsis = true;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(4, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(248, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Задать путь к решателю";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblSolverPath
            // 
            this.lblSolverPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSolverPath.AutoEllipsis = true;
            this.lblSolverPath.AutoSize = true;
            this.lblSolverPath.Location = new System.Drawing.Point(313, 10);
            this.lblSolverPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSolverPath.Name = "lblSolverPath";
            this.lblSolverPath.Size = new System.Drawing.Size(14, 16);
            this.lblSolverPath.TabIndex = 6;
            this.lblSolverPath.Text = "?";
            // 
            // btnBackGroundColor
            // 
            this.btnBackGroundColor.AutoSize = true;
            this.btnBackGroundColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBackGroundColor.Location = new System.Drawing.Point(4, 72);
            this.btnBackGroundColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnBackGroundColor.Name = "btnBackGroundColor";
            this.btnBackGroundColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBackGroundColor.Size = new System.Drawing.Size(247, 26);
            this.btnBackGroundColor.TabIndex = 2;
            this.btnBackGroundColor.Text = "выбрать цвет заднего фона";
            this.btnBackGroundColor.UseVisualStyleBackColor = true;
            this.btnBackGroundColor.Click += new System.EventHandler(this.btnBackGroundColor_Click);
            // 
            // btnSelectGroupColor
            // 
            this.btnSelectGroupColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectGroupColor.Location = new System.Drawing.Point(3, 37);
            this.btnSelectGroupColor.Name = "btnSelectGroupColor";
            this.btnSelectGroupColor.Size = new System.Drawing.Size(249, 28);
            this.btnSelectGroupColor.TabIndex = 9;
            this.btnSelectGroupColor.Text = "выбрать цвет выделения групп";
            this.btnSelectGroupColor.UseVisualStyleBackColor = true;
            this.btnSelectGroupColor.Click += new System.EventHandler(this.btnSelectGroupColor_Click);
            // 
            // panelSelectionGroupColor
            // 
            this.panelSelectionGroupColor.BackColor = System.Drawing.Color.Yellow;
            this.panelSelectionGroupColor.Location = new System.Drawing.Point(258, 37);
            this.panelSelectionGroupColor.Name = "panelSelectionGroupColor";
            this.panelSelectionGroupColor.Size = new System.Drawing.Size(123, 28);
            this.panelSelectionGroupColor.TabIndex = 10;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(400, 0);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(400, 302);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelBackGroundColor;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.Panel panelSelectionColor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblSolverPath;
        private System.Windows.Forms.CheckBox chbLighting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbTransparency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBackGroundColor;
        private System.Windows.Forms.Button btnSelectGroupColor;
        private System.Windows.Forms.Panel panelSelectionGroupColor;
    }
}
