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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.lblSolverPath = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.panelSelectionObjsColor = new System.Windows.Forms.Panel();
            this.chbLighting = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbBackRibbers = new System.Windows.Forms.CheckBox();
            this.btnBackGroundColor = new System.Windows.Forms.Button();
            this.panelBackGroundColor = new System.Windows.Forms.Panel();
            this.btnSelectGroupColor = new System.Windows.Forms.Button();
            this.panelSelectionGroupColor = new System.Windows.Forms.Panel();
            this.lightingControl = new BazisGUI.SettingsControls.LightingControl();
            this.colorSlider = new MB.Controls.ColorSlider();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.clslNodes = new MB.Controls.ColorSlider();
            this.colorSlider2 = new MB.Controls.ColorSlider();
            this.colorSlider3 = new MB.Controls.ColorSlider();
            this.colorSlider4 = new MB.Controls.ColorSlider();
            this.chbTransparency = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 523);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 50);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(348, 31);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(224, 23);
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
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(241, 579);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 514);
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
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.89815F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.10185F));
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
            this.tableLayoutPanel2.Controls.Add(this.colorSlider, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.clslNodes, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.colorSlider2, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.colorSlider3, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.colorSlider4, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.chbTransparency, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 11);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 12;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(348, 495);
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
            this.panelSelectionObjsColor.Size = new System.Drawing.Size(109, 22);
            this.panelSelectionObjsColor.TabIndex = 3;
            // 
            // chbLighting
            // 
            this.chbLighting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbLighting.AutoSize = true;
            this.chbLighting.Location = new System.Drawing.Point(282, 134);
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
            this.label1.Location = new System.Drawing.Point(37, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Внутренние ребра элементов";
            // 
            // chbBackRibbers
            // 
            this.chbBackRibbers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbBackRibbers.AutoSize = true;
            this.chbBackRibbers.Location = new System.Drawing.Point(282, 98);
            this.chbBackRibbers.Name = "chbBackRibbers";
            this.chbBackRibbers.Size = new System.Drawing.Size(15, 14);
            this.chbBackRibbers.TabIndex = 5;
            this.chbBackRibbers.UseVisualStyleBackColor = true;
            this.chbBackRibbers.Click += new System.EventHandler(this.chbTransparency_Click);
            // 
            // btnBackGroundColor
            // 
            this.btnBackGroundColor.AutoSize = true;
            this.btnBackGroundColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBackGroundColor.Location = new System.Drawing.Point(4, 62);
            this.btnBackGroundColor.Name = "btnBackGroundColor";
            this.btnBackGroundColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBackGroundColor.Size = new System.Drawing.Size(224, 22);
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
            this.panelBackGroundColor.Size = new System.Drawing.Size(109, 22);
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
            this.panelSelectionGroupColor.Size = new System.Drawing.Size(109, 22);
            this.panelSelectionGroupColor.TabIndex = 10;
            // 
            // lightingControl
            // 
            this.lightingControl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lightingControl.BallPosition = new System.Drawing.Point(54, 53);
            this.lightingControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lightingControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightingControl.Location = new System.Drawing.Point(234, 162);
            this.lightingControl.Margin = new System.Windows.Forms.Padding(2);
            this.lightingControl.Name = "lightingControl";
            this.lightingControl.Size = new System.Drawing.Size(111, 114);
            this.lightingControl.TabIndex = 11;
            // 
            // colorSlider
            // 
            this.colorSlider.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorSlider.LargeChange = ((uint)(5u));
            this.colorSlider.Location = new System.Drawing.Point(235, 284);
            this.colorSlider.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.colorSlider.Name = "colorSlider";
            this.colorSlider.Size = new System.Drawing.Size(109, 25);
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
            this.panel1.Location = new System.Drawing.Point(1, 124);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel2.SetRowSpan(this.panel1, 3);
            this.panel1.Size = new System.Drawing.Size(230, 189);
            this.panel1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Освещение";
            // 
            // clslNodes
            // 
            this.clslNodes.BackColor = System.Drawing.Color.Transparent;
            this.clslNodes.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.clslNodes.LargeChange = ((uint)(50u));
            this.clslNodes.Location = new System.Drawing.Point(235, 356);
            this.clslNodes.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.clslNodes.Name = "clslNodes";
            this.clslNodes.Size = new System.Drawing.Size(109, 25);
            this.clslNodes.SmallChange = ((uint)(1u));
            this.clslNodes.TabIndex = 14;
            this.clslNodes.Text = "colorSlider1";
            this.clslNodes.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            // 
            // colorSlider2
            // 
            this.colorSlider2.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider2.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider2.LargeChange = ((uint)(5u));
            this.colorSlider2.Location = new System.Drawing.Point(235, 390);
            this.colorSlider2.Name = "colorSlider2";
            this.colorSlider2.Size = new System.Drawing.Size(109, 25);
            this.colorSlider2.SmallChange = ((uint)(1u));
            this.colorSlider2.TabIndex = 15;
            this.colorSlider2.Text = "colorSlider2";
            this.colorSlider2.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            // 
            // colorSlider3
            // 
            this.colorSlider3.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider3.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider3.LargeChange = ((uint)(5u));
            this.colorSlider3.Location = new System.Drawing.Point(235, 426);
            this.colorSlider3.Name = "colorSlider3";
            this.colorSlider3.Size = new System.Drawing.Size(109, 25);
            this.colorSlider3.SmallChange = ((uint)(1u));
            this.colorSlider3.TabIndex = 16;
            this.colorSlider3.Text = "colorSlider3";
            this.colorSlider3.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            // 
            // colorSlider4
            // 
            this.colorSlider4.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider4.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider4.LargeChange = ((uint)(5u));
            this.colorSlider4.Location = new System.Drawing.Point(235, 462);
            this.colorSlider4.Name = "colorSlider4";
            this.colorSlider4.Size = new System.Drawing.Size(109, 25);
            this.colorSlider4.SmallChange = ((uint)(1u));
            this.colorSlider4.TabIndex = 17;
            this.colorSlider4.Text = "colorSlider4";
            this.colorSlider4.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            // 
            // chbTransparency
            // 
            this.chbTransparency.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbTransparency.AutoSize = true;
            this.chbTransparency.Location = new System.Drawing.Point(282, 325);
            this.chbTransparency.Name = "chbTransparency";
            this.chbTransparency.Size = new System.Drawing.Size(15, 14);
            this.chbTransparency.TabIndex = 18;
            this.chbTransparency.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Прозрачность";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Узлы";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Элементы 1D";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 434);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Элементы 2D";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(78, 470);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Элементы 3D";
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 610);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(360, 610);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
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
        private MB.Controls.ColorSlider colorSlider;
        private System.Windows.Forms.Panel panel1;
        private MB.Controls.ColorSlider clslNodes;
        private MB.Controls.ColorSlider colorSlider2;
        private MB.Controls.ColorSlider colorSlider3;
        private MB.Controls.ColorSlider colorSlider4;
        private System.Windows.Forms.CheckBox chbTransparency;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblSolverPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
