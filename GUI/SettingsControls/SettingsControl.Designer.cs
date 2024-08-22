using UserControlsEx;

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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.panelSelectionObjsColor = new System.Windows.Forms.Panel();
            this.chbLighting = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbBackRibbers = new System.Windows.Forms.CheckBox();
            this.btnBackGroundColor = new System.Windows.Forms.Button();
            this.panelBackGroundColor = new System.Windows.Forms.Panel();
            this.btnSelectGroupColor = new System.Windows.Forms.Button();
            this.panelSelectionGroupColor = new System.Windows.Forms.Panel();
            this.clslLigthingIntensity = new ColorSlider();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.clslTransparency = new ColorSlider();
            this.chbTransparency = new System.Windows.Forms.CheckBox();
            this.lblSolverPath = new System.Windows.Forms.Label();
            this.btnSolverPath = new System.Windows.Forms.Button();
            this.lightingControl = new BazisGUI.SettingsControls.LightingControl();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.btnSelectColor, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelSelectionObjsColor, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chbLighting, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.chbBackRibbers, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnBackGroundColor, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelBackGroundColor, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnSelectGroupColor, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panelSelectionGroupColor, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lightingControl, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.clslLigthingIntensity, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.clslTransparency, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.chbTransparency, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.lblSolverPath, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.btnSolverPath, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.btnSaveConfig, 1, 10);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 11;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(470, 729);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 505);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel2.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(282, 128);
            this.panel2.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Прозрачность";
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.AutoSize = true;
            this.btnSelectColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelectColor.Location = new System.Drawing.Point(8, 8);
            this.btnSelectColor.Margin = new System.Windows.Forms.Padding(7);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSelectColor.Size = new System.Drawing.Size(268, 32);
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
            this.panelSelectionObjsColor.Location = new System.Drawing.Point(291, 8);
            this.panelSelectionObjsColor.Margin = new System.Windows.Forms.Padding(7);
            this.panelSelectionObjsColor.Name = "panelSelectionObjsColor";
            this.panelSelectionObjsColor.Size = new System.Drawing.Size(171, 32);
            this.panelSelectionObjsColor.TabIndex = 3;
            // 
            // chbLighting
            // 
            this.chbLighting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbLighting.AutoSize = true;
            this.chbLighting.Location = new System.Drawing.Point(369, 201);
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
            this.label1.Location = new System.Drawing.Point(63, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Внутренние ребра элементов";
            // 
            // chbBackRibbers
            // 
            this.chbBackRibbers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbBackRibbers.AutoSize = true;
            this.chbBackRibbers.Location = new System.Drawing.Point(369, 158);
            this.chbBackRibbers.Name = "chbBackRibbers";
            this.chbBackRibbers.Size = new System.Drawing.Size(15, 14);
            this.chbBackRibbers.TabIndex = 5;
            this.chbBackRibbers.UseVisualStyleBackColor = true;
            this.chbBackRibbers.Click += new System.EventHandler(this.chbBackRibbers_Click);
            // 
            // btnBackGroundColor
            // 
            this.btnBackGroundColor.AutoSize = true;
            this.btnBackGroundColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBackGroundColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackGroundColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBackGroundColor.Location = new System.Drawing.Point(8, 102);
            this.btnBackGroundColor.Margin = new System.Windows.Forms.Padding(7);
            this.btnBackGroundColor.Name = "btnBackGroundColor";
            this.btnBackGroundColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBackGroundColor.Size = new System.Drawing.Size(268, 32);
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
            this.panelBackGroundColor.Location = new System.Drawing.Point(291, 102);
            this.panelBackGroundColor.Margin = new System.Windows.Forms.Padding(7);
            this.panelBackGroundColor.Name = "panelBackGroundColor";
            this.panelBackGroundColor.Size = new System.Drawing.Size(171, 32);
            this.panelBackGroundColor.TabIndex = 4;
            // 
            // btnSelectGroupColor
            // 
            this.btnSelectGroupColor.AutoSize = true;
            this.btnSelectGroupColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectGroupColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectGroupColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelectGroupColor.Location = new System.Drawing.Point(8, 55);
            this.btnSelectGroupColor.Margin = new System.Windows.Forms.Padding(7);
            this.btnSelectGroupColor.Name = "btnSelectGroupColor";
            this.btnSelectGroupColor.Size = new System.Drawing.Size(268, 32);
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
            this.panelSelectionGroupColor.Location = new System.Drawing.Point(291, 55);
            this.panelSelectionGroupColor.Margin = new System.Windows.Forms.Padding(7);
            this.panelSelectionGroupColor.Name = "panelSelectionGroupColor";
            this.panelSelectionGroupColor.Size = new System.Drawing.Size(171, 32);
            this.panelSelectionGroupColor.TabIndex = 10;
            // 
            // clslLigthingIntensity
            // 
            this.clslLigthingIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clslLigthingIntensity.BackColor = System.Drawing.Color.Transparent;
            this.clslLigthingIntensity.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.clslLigthingIntensity.LargeChange = ((uint)(5u));
            this.clslLigthingIntensity.Location = new System.Drawing.Point(287, 444);
            this.clslLigthingIntensity.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.clslLigthingIntensity.Name = "clslLigthingIntensity";
            this.clslLigthingIntensity.Size = new System.Drawing.Size(179, 25);
            this.clslLigthingIntensity.SmallChange = ((uint)(1u));
            this.clslLigthingIntensity.TabIndex = 12;
            this.clslLigthingIntensity.Text = "colorSlider";
            this.clslLigthingIntensity.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.clslLigthingIntensity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.clslLigthingIntensity_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 189);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel2.SetRowSpan(this.panel1, 3);
            this.panel1.Size = new System.Drawing.Size(282, 314);
            this.panel1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Освещение";
            // 
            // clslTransparency
            // 
            this.clslTransparency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.clslTransparency.BackColor = System.Drawing.Color.Transparent;
            this.clslTransparency.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.clslTransparency.LargeChange = ((uint)(50u));
            this.clslTransparency.Location = new System.Drawing.Point(287, 574);
            this.clslTransparency.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.clslTransparency.Maximum = 99;
            this.clslTransparency.Name = "clslTransparency";
            this.clslTransparency.Size = new System.Drawing.Size(179, 25);
            this.clslTransparency.SmallChange = ((uint)(1u));
            this.clslTransparency.TabIndex = 14;
            this.clslTransparency.Text = "colorSlider1";
            this.clslTransparency.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.clslTransparency.Scroll += new System.Windows.Forms.ScrollEventHandler(this.clslTransparency_Scroll);
            // 
            // chbTransparency
            // 
            this.chbTransparency.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbTransparency.AutoSize = true;
            this.chbTransparency.Location = new System.Drawing.Point(369, 515);
            this.chbTransparency.Name = "chbTransparency";
            this.chbTransparency.Size = new System.Drawing.Size(15, 14);
            this.chbTransparency.TabIndex = 18;
            this.chbTransparency.UseVisualStyleBackColor = true;
            this.chbTransparency.Click += new System.EventHandler(this.chbTransparency_Click);
            // 
            // lblSolverPath
            // 
            this.lblSolverPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSolverPath.AutoSize = true;
            this.lblSolverPath.Location = new System.Drawing.Point(370, 651);
            this.lblSolverPath.Name = "lblSolverPath";
            this.lblSolverPath.Size = new System.Drawing.Size(13, 13);
            this.lblSolverPath.TabIndex = 20;
            this.lblSolverPath.Text = "?";
            // 
            // btnSolverPath
            // 
            this.btnSolverPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSolverPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolverPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSolverPath.Location = new System.Drawing.Point(8, 642);
            this.btnSolverPath.Margin = new System.Windows.Forms.Padding(7);
            this.btnSolverPath.Name = "btnSolverPath";
            this.btnSolverPath.Size = new System.Drawing.Size(268, 32);
            this.btnSolverPath.TabIndex = 21;
            this.btnSolverPath.Text = "задать путь к решателю";
            this.btnSolverPath.UseVisualStyleBackColor = true;
            this.btnSolverPath.Click += new System.EventHandler(this.btnSetSolverPath_Click);
            // 
            // lightingControl
            // 
            this.lightingControl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lightingControl.BallPosition = new System.Drawing.Point(0, 0);
            this.lightingControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lightingControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightingControl.Location = new System.Drawing.Point(286, 231);
            this.lightingControl.Margin = new System.Windows.Forms.Padding(2);
            this.lightingControl.Name = "lightingControl";
            this.lightingControl.Size = new System.Drawing.Size(181, 176);
            this.lightingControl.TabIndex = 11;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveConfig.Location = new System.Drawing.Point(291, 689);
            this.btnSaveConfig.Margin = new System.Windows.Forms.Padding(7);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(171, 32);
            this.btnSaveConfig.TabIndex = 22;
            this.btnSaveConfig.Text = "Сохранить";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(470, 729);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.Panel panelSelectionObjsColor;
        private System.Windows.Forms.CheckBox chbLighting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbBackRibbers;
        private System.Windows.Forms.Button btnBackGroundColor;
        private System.Windows.Forms.Panel panelBackGroundColor;
        private System.Windows.Forms.Button btnSelectGroupColor;
        private System.Windows.Forms.Panel panelSelectionGroupColor;
        private LightingControl lightingControl;
        private ColorSlider clslLigthingIntensity;
        private System.Windows.Forms.Panel panel1;
        private ColorSlider clslTransparency;
        private System.Windows.Forms.CheckBox chbTransparency;
        private System.Windows.Forms.Label lblSolverPath;
        private System.Windows.Forms.Button btnSolverPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveConfig;
    }
}
