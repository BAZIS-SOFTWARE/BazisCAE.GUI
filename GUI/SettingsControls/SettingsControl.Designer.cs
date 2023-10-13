namespace BazisGUI.SettingsControls
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
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.panelSelectionObjsColor = new System.Windows.Forms.Panel();
            this.chbLighting = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbTransparency = new System.Windows.Forms.CheckBox();
            this.btnBackGroundColor = new System.Windows.Forms.Button();
            this.panelBackGroundColor = new System.Windows.Forms.Panel();
            this.btnSelectGroupColor = new System.Windows.Forms.Button();
            this.panelSelectionGroupColor = new System.Windows.Forms.Panel();
            this.lightingControl = new BazisGUI.SettingsControls.LightingControl();
            this.colorSlider = new MB.Controls.ColorSlider();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.lblSolverPath = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(361, 423);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 330);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки сцены";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Controls.Add(this.btnSelectColor, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelSelectionObjsColor, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chbLighting, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.chbTransparency, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnBackGroundColor, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelBackGroundColor, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnSelectGroupColor, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panelSelectionGroupColor, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lightingControl, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.colorSlider, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.11267F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.88733F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(349, 311);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.AutoSize = true;
            this.btnSelectColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectColor.Location = new System.Drawing.Point(3, 3);
            this.btnSelectColor.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSelectColor.Size = new System.Drawing.Size(226, 24);
            this.btnSelectColor.TabIndex = 0;
            this.btnSelectColor.Text = "выбрать цвет выделения объектов";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectObjectColor_Click);
            // 
            // panelSelectionObjsColor
            // 
            this.panelSelectionObjsColor.BackColor = System.Drawing.Color.LawnGreen;
            this.panelSelectionObjsColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSelectionObjsColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSelectionObjsColor.Location = new System.Drawing.Point(235, 4);
            this.panelSelectionObjsColor.Name = "panelSelectionObjsColor";
            this.panelSelectionObjsColor.Size = new System.Drawing.Size(110, 22);
            this.panelSelectionObjsColor.TabIndex = 3;
            // 
            // chbLighting
            // 
            this.chbLighting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbLighting.AutoSize = true;
            this.chbLighting.Location = new System.Drawing.Point(282, 136);
            this.chbLighting.Name = "chbLighting";
            this.chbLighting.Size = new System.Drawing.Size(15, 14);
            this.chbLighting.TabIndex = 8;
            this.chbLighting.UseVisualStyleBackColor = true;
            this.chbLighting.Click += new System.EventHandler(this.chbLighting_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Прозрачность";
            // 
            // chbTransparency
            // 
            this.chbTransparency.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbTransparency.AutoSize = true;
            this.chbTransparency.Location = new System.Drawing.Point(282, 101);
            this.chbTransparency.Name = "chbTransparency";
            this.chbTransparency.Size = new System.Drawing.Size(15, 14);
            this.chbTransparency.TabIndex = 5;
            this.chbTransparency.UseVisualStyleBackColor = true;
            this.chbTransparency.Click += new System.EventHandler(this.chbTransparency_Click);
            // 
            // btnBackGroundColor
            // 
            this.btnBackGroundColor.AutoSize = true;
            this.btnBackGroundColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBackGroundColor.Location = new System.Drawing.Point(4, 62);
            this.btnBackGroundColor.Name = "btnBackGroundColor";
            this.btnBackGroundColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBackGroundColor.Size = new System.Drawing.Size(224, 24);
            this.btnBackGroundColor.TabIndex = 2;
            this.btnBackGroundColor.Text = "выбрать цвет заднего фона";
            this.btnBackGroundColor.UseVisualStyleBackColor = true;
            this.btnBackGroundColor.Click += new System.EventHandler(this.btnBackGroundColor_Click);
            // 
            // panelBackGroundColor
            // 
            this.panelBackGroundColor.BackColor = System.Drawing.Color.White;
            this.panelBackGroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBackGroundColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackGroundColor.Location = new System.Drawing.Point(235, 62);
            this.panelBackGroundColor.Name = "panelBackGroundColor";
            this.panelBackGroundColor.Size = new System.Drawing.Size(110, 24);
            this.panelBackGroundColor.TabIndex = 4;
            // 
            // btnSelectGroupColor
            // 
            this.btnSelectGroupColor.AutoSize = true;
            this.btnSelectGroupColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectGroupColor.Location = new System.Drawing.Point(3, 32);
            this.btnSelectGroupColor.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectGroupColor.Name = "btnSelectGroupColor";
            this.btnSelectGroupColor.Size = new System.Drawing.Size(226, 24);
            this.btnSelectGroupColor.TabIndex = 9;
            this.btnSelectGroupColor.Text = "выбрать цвет выделения групп";
            this.btnSelectGroupColor.UseVisualStyleBackColor = true;
            this.btnSelectGroupColor.Click += new System.EventHandler(this.btnSelectGroupColor_Click);
            // 
            // panelSelectionGroupColor
            // 
            this.panelSelectionGroupColor.BackColor = System.Drawing.Color.Yellow;
            this.panelSelectionGroupColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSelectionGroupColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSelectionGroupColor.Location = new System.Drawing.Point(235, 33);
            this.panelSelectionGroupColor.Name = "panelSelectionGroupColor";
            this.panelSelectionGroupColor.Size = new System.Drawing.Size(110, 22);
            this.panelSelectionGroupColor.TabIndex = 10;
            // 
            // lightingControl
            // 
            this.lightingControl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lightingControl.BallPosition = new System.Drawing.Point(54, 53);
            this.lightingControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lightingControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightingControl.Location = new System.Drawing.Point(234, 163);
            this.lightingControl.Margin = new System.Windows.Forms.Padding(2);
            this.lightingControl.Name = "lightingControl";
            this.lightingControl.Size = new System.Drawing.Size(112, 108);
            this.lightingControl.TabIndex = 11;
            // 
            // colorSlider
            // 
            this.colorSlider.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorSlider.LargeChange = ((uint)(5u));
            this.colorSlider.Location = new System.Drawing.Point(235, 279);
            this.colorSlider.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.colorSlider.Name = "colorSlider";
            this.colorSlider.Size = new System.Drawing.Size(110, 26);
            this.colorSlider.SmallChange = ((uint)(1u));
            this.colorSlider.TabIndex = 12;
            this.colorSlider.Text = "colorSlider";
            this.colorSlider.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.colorSlider_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 127);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel2.SetRowSpan(this.panel1, 3);
            this.panel1.Size = new System.Drawing.Size(230, 182);
            this.panel1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Освещение";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(242, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 24);
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
            this.groupBox2.Location = new System.Drawing.Point(3, 339);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 51);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки решателя";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblSolverPath, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(349, 32);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.AutoEllipsis = true;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(224, 24);
            this.button2.TabIndex = 5;
            this.button2.Text = "Задать путь к решателю";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSetSolverPath_Click);
            // 
            // lblSolverPath
            // 
            this.lblSolverPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSolverPath.AutoEllipsis = true;
            this.lblSolverPath.AutoSize = true;
            this.lblSolverPath.Location = new System.Drawing.Point(283, 9);
            this.lblSolverPath.Name = "lblSolverPath";
            this.lblSolverPath.Size = new System.Drawing.Size(13, 13);
            this.lblSolverPath.TabIndex = 6;
            this.lblSolverPath.Text = "?";
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(361, 423);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel panelSelectionObjsColor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblSolverPath;
        private System.Windows.Forms.CheckBox chbLighting;
        private System.Windows.Forms.CheckBox chbTransparency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBackGroundColor;
        private System.Windows.Forms.Button btnSelectGroupColor;
        private System.Windows.Forms.Panel panelSelectionGroupColor;
        private LightingControl lightingControl;
        private MB.Controls.ColorSlider colorSlider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}
